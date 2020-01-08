/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：DBManager.DB.SQLServer
*文件名： CSQLWaterSpeed
*创建人： XXX
*创建时间：2019-6-26 18:59:04
*描述
*=====================================================================
*修改标记
*修改时间：2019-6-26 18:59:04
*修改人：XXX
*描述：
************************************************************************************/
using DBManager.Interface;
using Hydrology.DBManager.DB.SQLServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using Hydrology.DBManager;
using System.Data.SqlClient;
using System.Data;
using Hydrology.Entity;

namespace DBManager.DB.SQLServer
{
    public class CSQLWaterSpeed : CSQLBase, IWaterSpeedProxy
    {
        public static readonly string CT_TableName = "RG30RawData";      //数据库中水量表的名字

        public static readonly string CN_StationId = "STCD"; //站点ID
        public static readonly string CN_DataTime = "DT";    //数据的采集时间
        public static readonly string CN_WaterStage = "W1";  //水位
        public static readonly string CN_V1 = "AvgV1";  //水位
        public static readonly string CN_V2 = "AvgV2";  //水位
        public static readonly string CN_V3 = "AvgV3";  //水位
        public static readonly string CN_V4 = "AvgV4";  //水位
        public static readonly string CN_WaterFlow = "Q";     //流量
        public static readonly string CN_WaterFlowMc = "rawQ";     //流量
        public static readonly string CN_TransType = "transtype";  //通讯方式
        public static readonly string CN_MsgType = "messagetype";  //报送类型
        public static readonly string CN_RecvDataTime = "recvdatatime";    //接收到数据的时间
       


        public void batchInsertRows(List<CEntityWaterSpeed> waterSpeedList)
        {
            if (waterSpeedList == null || waterSpeedList.Count == 0)
            {
                return;
            }
            // 记录超过写入上线条，或者时间超过1分钟，就将当前的数据写入数据库
            CDBLog.Instance.AddInfo("时差法流速数据：" + waterSpeedList.Count + "条");
            StringBuilder sql = new StringBuilder();

            foreach (CEntityWaterSpeed waterSpeed in waterSpeedList)
            {
                sql.Append("insert INTO RG30RawData(STCD,DT,AvgV1,AvgV2,AvgV3,AvgV4,W1,rawQ,Q,recvdatatime,transtype,messagetype) VALUES");
                sql.AppendFormat("({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}),", "'" + waterSpeed.STCD + "'", "'" + waterSpeed.DT.ToString(CDBParams.GetInstance().DBDateTimeFormat) + "'",
                    waterSpeed.AvgV1, waterSpeed.AvgV2, waterSpeed.AvgV3, waterSpeed.AvgV4, waterSpeed.W1,waterSpeed.rawQ,waterSpeed.Q,
                    "'" + waterSpeed.RevtDT.ToString(CDBParams.GetInstance().DBDateTimeFormat) + "'",
                    CEnumHelper.ChannelTypeToDBStr(waterSpeed.ChannelType).ToString(), CEnumHelper.MessageTypeToDBStr(waterSpeed.MessageType).ToString());
                sql.Remove(sql.Length - 1, 1);
                sql.Append(";");
            }
            try
            {
                string sql1 = sql.ToString().Substring(0, sql.ToString().Length - 1);
                //ExecuteSQLCommand(sql.ToString().Substring(0, sql.ToString().Length - 1));
                ExecuteSQLCommand(sql1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// 插入数据到RG30表，流速1，流量1，流量2
        /// </summary>
        /// <param name="waterSpeedList"></param>
        public void batchInsertRows2(List<CEntityWaterSpeed> waterSpeedList)
        {
            if (waterSpeedList == null || waterSpeedList.Count == 0)
            {
                return;
            }
            // 记录超过写入上线条，或者时间超过1分钟，就将当前的数据写入数据库
            CDBLog.Instance.AddInfo("时差法流速数据：" + waterSpeedList.Count + "条");
            StringBuilder sql = new StringBuilder();

            foreach (CEntityWaterSpeed waterSpeed in waterSpeedList)
            {
                sql.Append("insert INTO RG30RawData(STCD,DT,AvgV1,AvgV2,AvgV3,AvgV4,W1,rawQ,Q,recvdatatime,transtype,messagetype) VALUES");
                sql.AppendFormat("({0},{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11}),", "'" + waterSpeed.STCD + "'", "'" + waterSpeed.DT.ToString(CDBParams.GetInstance().DBDateTimeFormat) + "'",
                    waterSpeed.AvgV1, "NULL", "NULL", "NULL", "NULL", waterSpeed.rawQ, waterSpeed.Q,
                    "'" + waterSpeed.RevtDT.ToString(CDBParams.GetInstance().DBDateTimeFormat) + "'",
                    CEnumHelper.ChannelTypeToDBStr(waterSpeed.ChannelType).ToString(), CEnumHelper.MessageTypeToDBStr(waterSpeed.MessageType).ToString());
                sql.Remove(sql.Length - 1, 1);
                sql.Append(";");
            }
            try
            {
                string sql1 = sql.ToString().Substring(0, sql.ToString().Length - 1);
                //ExecuteSQLCommand(sql.ToString().Substring(0, sql.ToString().Length - 1));
                ExecuteSQLCommand(sql1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public List<CEntityWaterSpeed> QueryByTime(string station, DateTime start, DateTime end)
        {
            List<CEntityWaterSpeed> results = new List<CEntityWaterSpeed>();
            String sql = "select * from " + CT_TableName + " where STCD=" + station + " and DT between '" + start + "'and '" + end + "'" +  "order by DT desc;";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, CDBManager.GetInstacne().GetConnection());
            DataTable dataTableTemp = new DataTable();
            adapter.Fill(dataTableTemp);
            int flag = dataTableTemp.Rows.Count;
            if (flag == 0)
            {

            }
            else
            {
                for (int rowid = 0; rowid < dataTableTemp.Rows.Count; ++rowid)
                {
                    CEntityWaterSpeed waterSpeed = new CEntityWaterSpeed();
                    waterSpeed.STCD = dataTableTemp.Rows[rowid][CN_StationId].ToString();
                    waterSpeed.DT = DateTime.Parse(dataTableTemp.Rows[rowid][CN_DataTime].ToString());
                    if(dataTableTemp.Rows[rowid][CN_WaterStage].ToString() != null && dataTableTemp.Rows[rowid][CN_WaterStage].ToString() != "")
                    {
                        waterSpeed.W1 = decimal.Parse(dataTableTemp.Rows[rowid][CN_WaterStage].ToString());
                    }
                    else
                    {
                        waterSpeed.W1 = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_V1].ToString() != null && dataTableTemp.Rows[rowid][CN_V1].ToString() != "")
                    {
                        waterSpeed.AvgV1 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V1].ToString());
                    }
                    else
                    {
                        waterSpeed.AvgV1 = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_V2].ToString() != null && dataTableTemp.Rows[rowid][CN_V2].ToString() != "")
                    {
                        waterSpeed.AvgV2 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V2].ToString());
                    }
                    else
                    {
                        waterSpeed.AvgV2 = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_V3].ToString() != null && dataTableTemp.Rows[rowid][CN_V3].ToString() != "")
                    {
                        waterSpeed.AvgV3 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V3].ToString());
                    }
                    else
                    {
                        waterSpeed.AvgV3 = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_V4].ToString() != null && dataTableTemp.Rows[rowid][CN_V4].ToString() != "")
                    {
                        waterSpeed.AvgV4 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V4].ToString());
                    }
                    else
                    {
                        waterSpeed.AvgV4 = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_WaterFlowMc].ToString() != null && dataTableTemp.Rows[rowid][CN_WaterFlowMc].ToString() != "")
                    {
                        waterSpeed.rawQ = decimal.Parse(dataTableTemp.Rows[rowid][CN_WaterFlowMc].ToString());
                    }
                    else
                    {
                        waterSpeed.rawQ = null;
                    }

                    if (dataTableTemp.Rows[rowid][CN_WaterFlow].ToString() != null && dataTableTemp.Rows[rowid][CN_WaterFlow].ToString() != "")
                    {
                        waterSpeed.Q = decimal.Parse(dataTableTemp.Rows[rowid][CN_WaterFlow].ToString());
                    }
                    else
                    {
                        waterSpeed.Q = null;
                    }



                    //waterSpeed.AvgV1 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V1].ToString());
                    //waterSpeed.AvgV2 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V2].ToString());
                    //waterSpeed.AvgV3 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V3].ToString());
                    //waterSpeed.AvgV4 = decimal.Parse(dataTableTemp.Rows[rowid][CN_V4].ToString());
                    //waterSpeed.rawQ = decimal.Parse(dataTableTemp.Rows[rowid][CN_WaterFlowMc].ToString());
                    //waterSpeed.Q = decimal.Parse(dataTableTemp.Rows[rowid][CN_WaterFlow].ToString());
                    waterSpeed.RevtDT = DateTime.Parse(dataTableTemp.Rows[rowid][CN_RecvDataTime].ToString());
                    waterSpeed.ChannelType = CEnumHelper.DBStrToChannelType(dataTableTemp.Rows[rowid][CN_TransType].ToString());
                    waterSpeed.MessageType = CEnumHelper.DBStrToMessageType(dataTableTemp.Rows[rowid][CN_MsgType].ToString());
                    results.Add(waterSpeed);
                }
            }
            return results;
        }

        protected override bool AddDataToDB()
        {
            throw new NotImplementedException();
        }
    }
}