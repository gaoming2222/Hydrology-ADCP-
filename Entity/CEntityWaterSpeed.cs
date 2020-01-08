/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：Entity
*文件名： CEntityWaterSpeed
*创建人： XXX
*创建时间：2019-6-26 18:24:14
*描述
*=====================================================================
*修改标记
*修改时间：2019-6-26 18:24:14
*修改人：XXX
*描述：
************************************************************************************/
using Hydrology.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CEntityWaterSpeed
    {
        /// <summary>
        /// 测站ID
        /// </summary>
        public string STCD { get; set; }

        /// <summary>
        ///  雨量值的采集时间
        /// </summary>
        public DateTime DT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string EID { get; set; }

        /// <summary>
        /// 平均流速
        /// </summary>
        public Nullable<Decimal> AvgV { get; set; }

        /// <summary>
        /// 平均流速1
        /// </summary>
        public Nullable<Decimal> AvgV1 { get; set; }

        /// <summary>
        /// 平均流速2
        /// </summary>
        public Nullable<Decimal> AvgV2 { get; set; }

        /// <summary>
        /// 平均流速3
        /// </summary>
        public Nullable<Decimal> AvgV3 { get; set; }

        /// <summary>
        /// 平均流速4
        /// </summary>
        public Nullable<Decimal> AvgV4 { get; set; }

        /// <summary>
        /// 平均流速5
        /// </summary>
        public Nullable<Decimal> AvgV5 { get; set; }

        /// <summary>
        /// 平均流速6
        /// </summary>
        public Nullable<Decimal> AvgV6 { get; set; }

        /// <summary>
        /// 平均流速7
        /// </summary>
        public Nullable<Decimal> AvgV7 { get; set; }

        /// <summary>
        /// 平均流速8
        /// </summary>
        public Nullable<Decimal> AvgV8 { get; set; }


        /// <summary>
        /// 偏角1
        /// </summary>
        public Nullable<Decimal> beta1 { get; set; }

        /// <summary>
        /// 偏角1
        /// </summary>
        public Nullable<Decimal> beta2 { get; set; }


        /// <summary>
        /// 偏角1
        /// </summary>
        public Nullable<Decimal> beta3 { get; set; }

        /// <summary>
        /// 偏角1
        /// </summary>
        public Nullable<Decimal> beta4 { get; set; }


        /// <summary>
        /// 水位
        /// </summary>
        public Nullable<Decimal> W1 { get; set; }


        /// <summary>
        /// 原始流量
        /// </summary>
        public Nullable<Decimal> rawQ { get; set; }


        /// <summary>
        /// 流量
        /// </summary>
        public Nullable<Decimal> Q { get; set; }


        /// <summary>
        /// 水位2
        /// </summary>
        public Nullable<Decimal> W2 { get; set; }


        /// <summary>
        /// ??
        /// </summary>
        public Nullable<Decimal> Battery { get; set; }


        /// <summary>
        /// ??
        /// </summary>
        public Nullable<Decimal> WL { get; set; }


        /// <summary>
        /// ??
        /// </summary>
        public string ErrorCode { get; set; }


        /// <summary>
        /// ??
        /// </summary>
        public string Memo { get; set; }


        /// <summary>
        /// 数据实际入库时间
        /// </summary>
        public DateTime RevtDT { get; set; }

        /// <summary>
        /// 报文类型
        /// </summary>
        public EMessageType MessageType { get; set; }

        /// <summary>
        /// 通讯方式类型
        /// </summary>
        public EChannelType ChannelType { get; set; }


    }
}