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
                item.State = "未下载";
                foreach (var item2 in list)
                {
                    if (item.FileName == item2.FileName)
                    {
                        ishas = true;
                        if (string.Compare(item.Version, item2.Version) > 0)
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
        public string ReadUpadateXMLString()
        {
            string path = CommonDataServer.AutoUpdatePath + CommonDataServer.AutoUpdateConfigFile;
            if (File.Exists(path))
            {
                return File.ReadAllText(path);
            }
            return null;
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
                result.SendBytes = null;
                return result;
            } 
            FileInfo fi = new FileInfo(path);
            long len = fi.Length;
            FileStream fs = File.OpenRead(path);
            byte[] buffer = new byte[len];
            fs.Read(buffer, 0, (int)len);
            fs.Close();
            result.FileSize = len;
            result.SendBytes = buffer;
            result.IsSuccess = true;
            result.Filename = filedata.FileName;
            return result;
        }
        private List<AutoUpdateModel> GetUpdateList()
        {
            string fullfile = CommonDataServer.AutoUpdatePath + "UpdateFileList.xml";
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
                sm.FileName  = xmlDoc.FirstChild.Attributes["FileName"].Value.ToString();
                sm.Version = xmlDoc.FirstChild.Attributes["Version"].Value.ToString();
                if (string.IsNullOrWhiteSpace(sm.FileName))
                    continue;
                list.Add(sm);
            }
            return list;
        }

    }
}
