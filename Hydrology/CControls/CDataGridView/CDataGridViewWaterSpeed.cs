/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：Hydrology.CControls.CDataGridView
*文件名： CDataGridViewWaterSpeed
*创建人： XXX
*创建时间：2019-6-27 10:10:28
*描述
*=====================================================================
*修改标记
*修改时间：2019-6-27 10:10:28
*修改人：XXX
*描述：
************************************************************************************/
using DBManager.DB.SQLServer;
using DBManager.Interface;
using Hydrology.DBManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Hydrology.CControls.CDataGridView
{
    class CDataGridViewWaterSpeed : CExDataGridView
    {
        #region 静态常
        public static readonly string CS_StationID = "站号";
        public static readonly string CS_StationName = "站名";
        public static readonly string CS_TimeCollected = "数据时间";
        public static readonly string CS_WaterStage = "水位";
        public static readonly string CS_V1 = "流速1";
        public static readonly string CS_V2 = "流速2";
        public static readonly string CS_V3 = "流速3";
        public static readonly string CS_V4 = "流速4";
        public static readonly string CS_WaterFlow = "流量";
        public static readonly string CS_TimeRecvd = "接受时间";
        public static readonly string CS_MsgType = "报文类型";
        public static readonly string CS_ChannelType = "通讯方式";
        public static readonly string CS_TimeFormat = "yyy-MM-dd HH:mm:ss";
        #endregion 静态常量


        // 查询相关信息
        private IWaterSpeedProxy m_proxyWaterSpeed;   //水量表的操作接口
        private string m_strStaionId;            //查询的测站ID
        private DateTime m_dateTimeStart;   //查询的起点日期
        private DateTime m_dateTimeEnd;     //查询的起点日期


        // 导出到Excel表格
        private ToolStripMenuItem m_menuItemExportToExcel;  //导出到Excel表格

        /// <summary>
        /// 构造方法初始话
        /// </summary>
        public CDataGridViewWaterSpeed() : base()
        {
            // 设定标题栏,默认有个隐藏列,默认非编辑模式
            this.Header = new string[]
            {
                CS_StationID,CS_StationName,CS_TimeCollected, CS_WaterStage, CS_V1,CS_V2,CS_V3,CS_V4,CS_WaterFlow ,CS_TimeRecvd,CS_ChannelType,CS_MsgType
            };
            this.BPartionPageEnable = false; //不启用分页功能
            m_proxyWaterSpeed = new CSQLWaterSpeed();
        }

        //private List<string> GetShowStringList(string station, string name, DateTime time)
        //{
        //    List<string> results = new List<string>();
        //}
    }
}