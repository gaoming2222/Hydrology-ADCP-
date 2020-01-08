using System;
using System.Text;

namespace Hydrology.Entity
{
    public class CReportData
    {
        /// <summary>
        /// 数据采集时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 水量
        /// </summary>
        public Nullable<Decimal> Water { get; set; }
        /// <summary>
        /// 雨量
        /// </summary>
        public Nullable<Decimal> Rain { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public Nullable<Decimal> Voltge { get; set; }

        /**
         * 流速相关数据
         * */
        public Nullable<Decimal> Vm { get; set; }
        public Nullable<Decimal> W1 { get; set; }
        public Nullable<Decimal> Q { get; set; }
        public Nullable<Decimal> Q2 { get; set; }
        public Nullable<Decimal> v1 { get; set; }
        public Nullable<Decimal> v2 { get; set; }
        public Nullable<Decimal> v3 { get; set; }
        public Nullable<Decimal> v4 { get; set; }
        public Nullable<Decimal> v5 { get; set; }
        public Nullable<Decimal> v6 { get; set; }
        public Nullable<Decimal> v7 { get; set; }
        public Nullable<Decimal> v8 { get; set; }
        public Nullable<Decimal> beta1 { get; set; }
        public Nullable<Decimal> beta2 { get; set; }
        public Nullable<Decimal> beta3 { get; set; }
        public Nullable<Decimal> beta4 { get; set; }
        public Nullable<Decimal> W2 { get; set; }
        public string errorCode { get; set; }

        /// <summary>
        /// 蒸发
        /// </summary>
        public Nullable<Decimal> Evp { get; set; }
        /// <summary>
        /// 蒸发类型
        /// </summary>
        public string EvpType { get; set; }
        /// <summary>
        /// 温度
        /// </summary>
        public Nullable<Decimal> Temperature { get; set; }

    }

    public class CReportFsfx
    {
        /// <summary>
        /// 数据采集时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 水量
        /// </summary>
        public Nullable<Decimal> Water { get; set; }
        /// <summary>
        /// 雨量
        /// </summary>
        public Nullable<Decimal> Rain { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public Nullable<Decimal> Voltge { get; set; }

        /// <summary>
        /// 瞬时风向
        /// </summary>
        public Nullable<Decimal> shfx { get; set; }

        /// <summary>
        /// 瞬时风速
        /// </summary>
        public Nullable<decimal> shfs { get; set; }

        /// <summary>
        /// 一小时最大瞬时风向
        /// </summary>
        public Nullable<decimal> yxszdshfx { get; set; }

        /// <summary>
        /// 一小时最大瞬时风速
        /// </summary>
        public Nullable<decimal> yxszdshfs { get; set; }

        /// <summary>
        /// 一小时最大瞬时风速时间
        /// </summary>
        public DateTime maxTime { get; set; }

        /// <summary>
        /// 2分钟平均风向 
        /// </summary>
        public Nullable<Decimal> avg2fx { get; set; }

        /// <summary>
        /// 2分钟平均风速
        /// </summary>
        public Nullable<Decimal> avg2fs { get; set; }


        /// <summary>
        /// 10分钟平均风向 
        /// </summary>
        public Nullable<Decimal> avg10fx { get; set; }

        /// <summary>
        /// 10分钟平均风速
        /// </summary>
        public Nullable<Decimal> avg10fs { get; set; }


        /// <summary>
        /// 10分钟平均最大风向 
        /// </summary>
        public Nullable<Decimal> max10fx { get; set; }

        /// <summary>
        /// 10分钟平均最大风速
        /// </summary>
        public Nullable<Decimal> max10fs { get; set; }

        public DateTime max10tm { get; set; }
    }

    public class CReportObs {
        /// <summary>
        /// 数据采集时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 水量
        /// </summary>
        public Nullable<Decimal> Water { get; set; }
        /// <summary>
        /// 雨量
        /// </summary>
        public Nullable<Decimal> Rain { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public Nullable<Decimal> Voltge { get; set; }

        /// <summary>
        /// 深度
        /// </summary>
        public Nullable<Decimal> Depth { get; set; }

        /// <summary>
        /// 浊度
        /// </summary>
        public Nullable<Decimal> Ntu { get; set; }

        /// <summary>
        /// 泥
        /// </summary>
        public Nullable<Decimal> Mud { get; set; }

        /// <summary>
        /// 温度
        /// </summary>
        public Nullable<Decimal> Tmp { get; set; }

        /// <summary>
        /// 电导率
        /// </summary>
        public Nullable<Decimal> Cndcty { get; set; }

        /// <summary>
        /// 盐度
        /// </summary>
        public Nullable<Decimal> Salinity { get; set; }


        /// <summary>
        /// 电池
        /// </summary>
        public Nullable<Decimal> Batt { get; set; }
    }

    public class CReportPwdData
    {
        /// <summary>
        /// 数据采集时间
        /// </summary>
        public DateTime Time { get; set; }
        /// <summary>
        /// 水量
        /// </summary>
        public Nullable<Decimal> Water { get; set; }
        /// <summary>
        /// 雨量
        /// </summary>
        public Nullable<Decimal> Rain { get; set; }
        /// <summary>
        /// 电压
        /// </summary>
        public Nullable<Decimal> Voltge { get; set; }

        /// <summary>
        /// 1分钟能见度
        /// </summary>
        public Nullable<Decimal> Visi1min { get; set; }

        /// <summary>
        /// 10分钟能见度
        /// </summary>
        public Nullable<Decimal> Visi10min { get; set; }

    }

  
}
