using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class CEntityEva
    {
        #region PROPERTY

        /// <summary>
        ///  测站中心的ID
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        ///  数据值的采集时间
        /// </summary>
        public DateTime TimeCollect { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public decimal? Temperature { get; set; }

        /// <summary>
        /// 电压
        /// </summary>
        public decimal? Voltage { get; set; }

        /// <summary>
        /// 蒸发值
        /// </summary>
        public decimal? Eva { get; set; }

        /// <summary>
        /// 雨量
        /// </summary>
        public decimal? Rain { get; set; }

        /// <summary>
        /// 蒸发模式
        /// </summary>
        public string type { get; set; }

        /// <summary>
        /// 小时表中的高度差DH
        /// </summary>
        public decimal? DH { get; set; }

        /// <summary>
        /// 日表中的日蒸发
        /// </summary>
        public decimal? E { get; set; }

        /// <summary>
        /// 日表中的日
        /// </summary>
        public decimal? P { get; set; }

        /// <summary>
        /// 转换后的蒸发
        /// </summary>
        public decimal? TE { get; set; }

        /// <summary>
        /// 转换后的雨量
        /// </summary>
        public decimal? TP { get; set; }


        /// <summary>
        /// 日表中的8点到20点的雨量和
        /// </summary>
        public decimal? P8 { get; set; }

        /// <summary>
        /// 日表中的20点到8点的雨量和
        /// </summary>
        public decimal? P20 { get; set; }

        /// <summary>
        /// 注水、排水说明
        /// </summary>
        public string act { get; set; }
        #endregion
    }
}
