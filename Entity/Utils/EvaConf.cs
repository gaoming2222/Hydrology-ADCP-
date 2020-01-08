using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Entity.Utils
{
    public class EvaConf
    {
        // 降雨转换系数
        [XmlElement("kp")]
        public static decimal kp;

        // 降雨转换系数
        [XmlElement("ke")]
        public static decimal ke;

        // 降雨转换系数
        [XmlElement("dh")]
        public static decimal dh;

        // 降雨转换系数
        [XmlElement("comP")]
        public static bool comP;

    }
}
