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

            AutoUpdateServiceClient Client = new AutoUpdateServiceClient();
            bool isHasUpdate;
            Client.CheckAutoUpdate(out isHasUpdate, GetUpdateList().ToArray());
            if (isHasUpdate)
            {
                return true;
            }
            else
            {
                return false;
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
