using System.IO;
using System.Text;
using System.Collections;
using System.Xml.XPath;
using System.Xml;


namespace Common
{
    public class ConfigReader
    {
        /// <summary>
        /// 根据指定的节点读取客户端配置文件信息
        /// </summary>
        /// <param name="nodePathName">节点名称</param>
        public static string GetConfigValue(string fileName, string nodePathName)
        {
            try
            {
                //配置内容的读取 
                ArrayList configValueLst = null;
                configValueLst = GetXmlString(
                     fileName, "Config/ClientPara/" + nodePathName);

                //定义内容的换行的处理
                string configValue = (string)configValueLst[0];
                //
                return configValue;
            }
            catch (System.Exception e)
            {
                return "";
            }
        }
        /// <summary>
        /// 定义xml文件的读操作
        /// </summary>
        /// <param name="fileName">文件名称(包含路径)</param>
        /// <param name="nodePathName">节点名称</param>
        /// <returns>定义节点值</returns>
        public static ArrayList GetXmlString(string fileName, string nodePathName)
        {
            XPathDocument xPathdoc;
            XPathNavigator xPathNav;
            XPathNodeIterator xPathNodeIter;
            ArrayList xmlContentLst = new ArrayList();
            try
            {
                xPathdoc = new XPathDocument(fileName);
                xPathNav = xPathdoc.CreateNavigator();
                xPathNodeIter = xPathNav.Select(nodePathName);
                for (int i = 0; i < xPathNodeIter.Count; i++)
                {
                    xPathNodeIter.MoveNext();
                    xmlContentLst.Add(xPathNodeIter.Current.Value);
                }
            }
            catch (System.Exception e)
            {
                e.ToString();
                xPathNodeIter = null;
                xPathNav = null;
                xPathdoc = null;
            }
            xPathNodeIter = null;
            xPathNav = null;
            xPathdoc = null;
            return xmlContentLst;
        }

        public static ArrayList GetServiceString(string fileName, string nodePathName)
        {
            ArrayList xmlContentLst = new ArrayList();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNode xn = xmlDoc.SelectSingleNode("config");
                foreach (XmlNode item in xn.ChildNodes)
                {
                    xmlContentLst.Add(item.OuterXml);
                }
            }
            catch (System.Exception e)
            {
                
            }
            
            return xmlContentLst;
        }

        public static ArrayList GetAutoUpdateString(string fileName, string nodePathName)
        {
            ArrayList xmlContentLst = new ArrayList();
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(fileName);
                XmlNode xn = xmlDoc.SelectSingleNode("UpdateFileList");
                foreach (XmlNode item in xn.ChildNodes)
                {
                    xmlContentLst.Add(item.OuterXml);
                }
            }
            catch (System.Exception e)
            {

            }

            return xmlContentLst;
        }
    }
}
