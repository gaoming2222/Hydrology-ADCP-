using DBManager.Interface;
using Entity;
using Hydrology.DBManager;
using Hydrology.DBManager.DB.SQLServer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBManager.DB.SQLServer
{
    public class CSQLStationMap : CSQLBase, IStationMapProxy
    {
        #region STATIC_MEMBER
        private const string CT_EntityName = "CEntityStationMap";   //  串口配置表对应的实体类名称
        private static readonly string CT_TableName = "StationMap"; //数据库串口配置表的名字
        private static readonly string CN_StationID = "StationID";    //站码
        private static readonly string CN_StationIDRef = "StationIDRef";    //站点映射码
        private static readonly string CN_StationID8 = "StationID8";     //站点8位码
        private static readonly string CN_StationID10 = "StationID10";   //站点10位码
        private const int CN_FIELD_COUNT = 4;
        #endregion


        #region PRIVATE_DATAMEMBER
        private List<int> m_listDelRows;            // 删除串口记录的链表
        private List<CEntityStationMap> m_listUpdateRows; // 更新用户信息的链表
        #endregion ///<PRIVATE_DATAMEMBER

        public CSQLStationMap() : base()
        {
            m_listDelRows = new List<int>();
            m_listUpdateRows = new List<CEntityStationMap>();

            m_tableDataAdded.Columns.Add(CN_StationID);
            m_tableDataAdded.Columns.Add(CN_StationIDRef);
            m_tableDataAdded.Columns.Add(CN_StationID8);
            m_tableDataAdded.Columns.Add(CN_StationID10);

            // 初始化互斥量
            m_mutexWriteToDB = CDBMutex.Mutex_TB_SerialPort;

        }
        /// <summary>
        /// 增加一行数据到站点映射表
        /// </summary>
        /// <param name="entity"></param>
        public void AddNewRow(CEntityStationMap entity)
        {
            m_mutexDataTable.WaitOne(); //等待互斥量
            DataRow row = m_tableDataAdded.NewRow();
            row[CN_StationID] = entity.StationID;
            row[CN_StationIDRef] = entity.StationIDRef;
            row[CN_StationID8] = entity.StationID8;
            row[CN_StationID10] = entity.StationID10;
            m_tableDataAdded.Rows.Add(row);
           
            if (m_tableDataAdded.Rows.Count >= 1)
            {
                // 如果超过最大值，写入数据库
                Task task = new Task(() => { AddDataToDB(); });
                task.Start();
            }
            else
            {
                // 没有超过缓存最大值，开启定时器进行检测,多次调用Start()会导致重新计数
                m_addTimer.Start();
            }
            m_mutexDataTable.ReleaseMutex();
        }
        /// <summary>
        /// 批量添加站点映射信息
        /// </summary>
        /// <param name="stationMapList"></param>
        /// <returns></returns>
        public bool AddRange(List<CEntityStationMap> stationMapList)
        {
            foreach (var item in stationMapList)
            {
                AddNewRow(item);
            }
            return AddDataToDB();
        }

        public bool DeleteRange(List<string> stationIDList)
        {
            StringBuilder sql = new StringBuilder();
            foreach (var item in stationIDList)
            {
                sql.AppendFormat("DELETE FROM {0} WHERE [{1}]={2}",
                CT_TableName,

                CN_StationID, item);
            }
            return base.ExecuteSQLCommand(sql.ToString());
        }

        public List<CEntityStationMap> QueryAll()
        {
            var result = new List<CEntityStationMap>();
            var sqlConn = CDBManager.GetInstacne().GetConnection();
            try
            {
                m_mutexWriteToDB.WaitOne();         // 取对数据库的唯一访问权
                m_mutexDataTable.WaitOne();         // 获取内存表的访问权
                sqlConn.Open();                     // 建立数据库连接

                String sqlStr = GetQuerySQL();

                SqlCommand sqlCmd = new SqlCommand(sqlStr, sqlConn);

                SqlDataReader reader = sqlCmd.ExecuteReader();

                Debug.Assert(reader.FieldCount == CN_FIELD_COUNT, CT_TableName + "表与类" + CT_EntityName + "中定义字段不符合");

                //  处理查询结果
                while (reader.Read())
                {
                    try
                    {
                        var stationMap = new CEntityStationMap();
                        stationMap.StationID = reader[CN_StationID].ToString();
                        stationMap.StationID = reader[CN_StationID].ToString();
                        stationMap.StationID = reader[CN_StationID].ToString();
                        stationMap.StationID = reader[CN_StationID].ToString();
                        result.Add(stationMap);
                    }
                    catch (Exception exp)
                    {
                        Debug.WriteLine(exp.Message);
                    }
                }
            }
            catch (Exception exp)
            {
                throw exp;
            }
            finally
            {
                sqlConn.Close();                    //  关闭数据库连接
                m_mutexDataTable.ReleaseMutex();    //  释放内存表的访问权
                m_mutexWriteToDB.ReleaseMutex();    //  释放数据库的访问权
            }
            return result;
        }

        public bool UpdateRange(List<CEntityStationMap> stationMapList)
        {
            StringBuilder sql = new StringBuilder();
            foreach (var item in stationMapList)
            {
                sql.AppendFormat("UPDATE {0} SET [{1}]='{2}',[{3}]='{4}',[{5}]='{6}' WHERE [{7}]={8}\r",
                    CT_TableName,
                    CN_StationIDRef, item.StationIDRef,
                    CN_StationID8, item.StationID8,
                    CN_StationID10, item.StationID10,
                    CN_StationID, item.StationID
                    );
            }
            return base.ExecuteSQLCommand(sql.ToString());
        }

        protected override bool AddDataToDB()
        {
            // 先获取对数据库的唯一访问权
            m_mutexWriteToDB.WaitOne();

            // 然后获取内存表的访问权
            m_mutexDataTable.WaitOne();

            if (m_tableDataAdded.Rows.Count <= 0)
            {
                m_mutexDataTable.ReleaseMutex();
                m_mutexWriteToDB.ReleaseMutex();
                return true;
            }
            //清空内存表的所有内容，把内容复制到临时表tmp中
            DataTable tmp = m_tableDataAdded.Copy();
            m_tableDataAdded.Rows.Clear();

            // 释放内存表的互斥量
            m_mutexDataTable.ReleaseMutex();

            try
            {
                //将临时表中的内容写入数据库
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(CDBManager.GetInstacne().GetConnectionString()))
                {
                    bulkCopy.DestinationTableName = CT_TableName;
                    bulkCopy.BatchSize = 1;
                    bulkCopy.BulkCopyTimeout = 1800;
                    //bulkCopy.ColumnMappings.Add(CN_RainID, CN_RainID);
                    bulkCopy.ColumnMappings.Add(CN_StationID, CN_StationID);
                    bulkCopy.ColumnMappings.Add(CN_StationIDRef, CN_StationIDRef);
                    bulkCopy.ColumnMappings.Add(CN_StationID8, CN_StationID8);
                    bulkCopy.ColumnMappings.Add(CN_StationID10, CN_StationID10);
                    try
                    {
                        bulkCopy.WriteToServer(tmp);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e.ToString());
                    }
                }
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                m_mutexWriteToDB.ReleaseMutex();
                return false;
            }
            Debug.WriteLine("###{0} :add {1} lines to stationmap db", DateTime.Now, tmp.Rows.Count);
            m_mutexWriteToDB.ReleaseMutex();
            return true;
        }

        private String GetQuerySQL()
        {
            return String.Format(
                "SELECT DISTINCT [{0}],[{1}],[{2}],[{3}] FROM {4}", 
                CN_StationID, CN_StationIDRef, CN_StationID8, CN_StationID10,
                CT_TableName
            );
        }
    }
}
