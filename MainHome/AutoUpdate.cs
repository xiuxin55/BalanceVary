using Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using UserAuthorization.AutoUpdateService;

namespace MainHome
{
    public class AutoUpdate
    {
        public bool CheckAutoUpdate()
        {
            try
            {
                AutoUpdateServiceClient Client = new AutoUpdateServiceClient();
                bool isHasUpdate;
                AutoUpdateModel[] updatelist=  Client.CheckAutoUpdate(out isHasUpdate, GetUpdateList().ToArray());
                if (isHasUpdate)
                {
                    foreach (var item in updatelist)
                    {
                        if (item.FileName== "AutoUpdate.exe")
                        {
                            DownAutoUpdateEXE(item);
                            break;
                        }
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AutoUpdate), ex);
                throw ex;
            }
            

        }
        string fullfile = System.AppDomain.CurrentDomain.BaseDirectory + "UpdateFileList.xml";
        /// <summary>
        /// 更新自动更新程序
        /// </summary>
        /// <param name="model"></param>
        private void DownAutoUpdateEXE(AutoUpdateModel model)
        {
            XmlDocument xmlDoc = new XmlDocument();
            if (!File.Exists(fullfile))
            {
                xmlDoc = CreateXML();
            }
            else
            {
                xmlDoc.Load(fullfile);//加载xml文件，文件
            }
            AutoUpdateServiceClient Client = new AutoUpdateServiceClient();
            DownFileResult down = Client.DownLoadFile(model);
            if (!string.IsNullOrWhiteSpace(down.Filename))
            {
                FileStream fs = null;

                try
                {
                    fs = File.Create(System.AppDomain.CurrentDomain.BaseDirectory + down.Filename);
                    fs.Write(down.SendBytes, 0, down.SendBytes.Length);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {

                    if (fs != null)
                    {
                        fs.Close();
                    }
                }
                SetUpdateXML(xmlDoc, model);
            }
            xmlDoc.Save(fullfile);//再一次强调 ，一定要记得保存的该XML文件
        }

        private XmlDocument CreateXML()
        {
            // File.AppendAllText(fullfile,"");
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null);
            doc.AppendChild(dec);
            //创建一个根节点（一级）
            XmlElement root = doc.CreateElement("UpdateFileList");
            doc.AppendChild(root);
            return doc;
        }
        private void SetUpdateXML(XmlDocument xmlDoc, AutoUpdateModel model)
        {

            XmlNode xns = xmlDoc.SelectSingleNode("UpdateFileList");//查找要修改的节点

            XmlNodeList xnl = xns.ChildNodes;//取出所有的子节点
            bool isHasnode = false;
            foreach (XmlNode xn in xnl)
            {
                XmlElement xe = (XmlElement)xn;//将节点转换一下类型
                if (xe.GetAttribute("FileName") == model.FileName)//判断该子节点是否是要查找的节点
                {
                    xe.SetAttribute("Version", model.Version);//设置新值
                    isHasnode = true;
                }
            }
            if (!isHasnode)
            {
                XmlElement xe1 = xmlDoc.CreateElement("File");
                xe1.SetAttribute("FileName", model.FileName);
                xe1.SetAttribute("Version", model.Version);
                xns.AppendChild(xe1);
            }


        }
        private List<AutoUpdateModel> GetUpdateList()
        {
            string fullfile = System.AppDomain.CurrentDomain.BaseDirectory + "UpdateFileList.xml";
            if (!File.Exists(fullfile))
            {
                return new List<AutoUpdateModel>();
            }
            ArrayList contentarray = ConfigReader.GetAutoUpdateString(fullfile, "UpdateFileList/File");
            List<AutoUpdateModel> list = new List<AutoUpdateModel>();
            foreach (var item in contentarray)
            {
                if (string.IsNullOrWhiteSpace(item.ToString()))
                    continue;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(item.ToString());
                AutoUpdateModel sm = new AutoUpdateModel();
                sm.FileName = xmlDoc.FirstChild.Attributes["FileName"].Value.ToString();
                sm.Version = xmlDoc.FirstChild.Attributes["Version"].Value.ToString();
                list.Add(sm);
            }
            return list;
        }
    }
}
