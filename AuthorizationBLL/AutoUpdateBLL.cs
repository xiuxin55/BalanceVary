
using AuthorizationDAL;
using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace AuthorizationBLL
{
    public class AutoUpdateBLL
    {
        AutoUpdateDAL dal = new AutoUpdateDAL();
        public List<AutoUpdateModel> CheckAutoUpdate(List<AutoUpdateModel> list, out bool IsHasUpdate)
        {


            return dal.CheckAutoUpdate(list, out IsHasUpdate);
        }
        public DownFileResult DownLoadFile(AutoUpdateModel filedata)
        {
            return dal.DownLoadFile(filedata);
        }
        public string ReadUpadateXMLString()
        {
            return dal.ReadUpadateXMLString();
        }
    }
}
