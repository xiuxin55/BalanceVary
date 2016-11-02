using AuthorizationModel;
using Common;
using Common.Server;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace AuthorizationDAL
{
    public class AutoUpdateDAL
    {

        public List<AutoUpdateModel> CheckAutoUpdate(List<AutoUpdateModel> list, out bool IsHasUpdate)
        {
            List<AutoUpdateModel> localVersion = GetUpdateList();
            List<AutoUpdateModel> UpdateVersion = new List<AutoUpdateModel>();
            foreach (var item in localVersion)
            {
                bool ishas = false;
                foreach (var item2 in list)
                {
                    if (string.Compare(item.FileName, item2.FileName) > 0)
                    {
                        ishas = true;
                        if (item.Version == item2.Version)
                        {
                            UpdateVersion.Add(item);
                        }
                    }
                }
                if (!ishas)
                {
                    UpdateVersion.Add(item);
                }
            }
            IsHasUpdate = UpdateVersion.Count > 0;
            return UpdateVersion;
        }
        //下载文件
        public DownFileResult DownLoadFile(AutoUpdateModel filedata)
        {
            DownFileResult result = new DownFileResult();
            string path = CommonDataServer.AutoUpdatePath + filedata.FileName;
            if (!File.Exists(path))
            {
                result.IsSuccess = false;
                result.FileSize = 0;
                result.Message = "服务器不存在此文件";
                result.FileStream = new MemoryStream();
                return result;
            }
            Stream ms = new MemoryStream();
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            fs.CopyTo(ms);
            ms.Position = 0;  //重要，不为0的话，客户端读取有问题
            result.IsSuccess = true;
            result.FileSize = ms.Length;
            result.FileStream = ms;
            fs.Flush();
            fs.Close();
            return result;
        }
        private List<AutoUpdateModel> GetUpdateList()
        {
            string fullfile = CommonDataServer.AutoUpdatePath + "UpdateFileList.xml";
            if (!File.Exists(fullfile))
            {
                return null;
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
                sm.FileName  = xmlDoc.FirstChild.Attributes["FileName"].Value.ToString();
                sm.Version = xmlDoc.FirstChild.Attributes["Version"].Value.ToString();
                list.Add(sm);
            }
            return list;
        }

    }
}
