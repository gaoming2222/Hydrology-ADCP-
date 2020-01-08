/************************************************************************************
* Copyright (c) 2019 All Rights Reserved.
*命名空间：DBManager
*文件名： XmlHelper
*创建人： XXX
*创建时间：2019-2-26 19:28:56
*描述
*=====================================================================
*修改标记
*修改时间：2019-2-26 19:28:56
*修改人：XXX
*描述：
************************************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Hydrology.DataMgr
{
    public class XmlHelper
    {
        
        public static string getXMLInfo()
        {
            //将XML文件加载进来
            string result = string.Empty;
            XDocument document = XDocument.Load("config\\zhongaopath.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            XElement path = root.Element("path");
            //获取name标签的值
            result = path.Value.ToString();
            return result;
            
        }

        public static Dictionary<string,string> getStationMapInfo()
        {
            //将XML文件加载进来
            Dictionary<string, string> result = new Dictionary<string, string>();
            XDocument document = XDocument.Load("config\\StationMap.xml");
            //获取到XML的根元素进行操作
            XElement root = document.Root;
            IEnumerable<XElement> enumerable = root.Elements();
            foreach (XElement item in enumerable)
            {
                string sid = "";
                string tid = "";
                foreach (XElement item1 in item.Elements())
                {
                    if(item1.Name == "sid")
                    {
                        sid = item1.Value;
                    }

                    if (item1.Name == "tid")
                    {
                        tid = item1.Value;
                    }
                }
                if (sid != "" && tid != "" && (!result.ContainsKey(sid)))
                {
                    result[sid] = tid;
                }
            }
            return result;

        }
    }
}