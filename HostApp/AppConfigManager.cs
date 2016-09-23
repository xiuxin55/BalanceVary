using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HostApp
{
    public class AppConfigManager
    {
        /// <summary>
        /// 通过ServiceCofig.xml 读取服务
        /// </summary>
        /// <returns></returns>
        public static List<ServiceModel> GetServiceList()
        {
            ArrayList contentarray = ConfigReader.GetServiceString(@"ServiceCofig.xml", "config/service");
            List<ServiceModel> list = new List<ServiceModel>();
            foreach (var item in contentarray)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                    return list;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(item.ToString());
                ServiceModel sm = new ServiceModel();
                sm.AssemblyName = xmlDoc.FirstChild.Attributes["assembly"].Value.ToString();
                sm.ClassName = xmlDoc.FirstChild.Attributes["class"].Value.ToString();
                sm.Describe = xmlDoc.FirstChild.Attributes["describe"].Value.ToString();
                sm.Name = sm.ClassName.Split('.').LastOrDefault();
                sm.IsStart = "未启动";
                sm.IsSelected = false;
                list.Add(sm);
            }
            return list;
        }
    }
    
 

}
