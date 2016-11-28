using BalanceBLL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public partial class SyncDataHandler
    {
        List<PGPersonInfo> ImportPGPersonInfoDataList = new List<PGPersonInfo>();
        public void ImportPGPersonInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("PGPersonInfo"));
            foreach (var item in filelist)
            {
                try
                {

                    DateTime time ;
                    if (item.FileDateTime==null)
                    {
                        time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
                    }
                    else
                    {
                        time = DateTime.Parse(item.FileDateTime.Value.ToString("yyyy-MM") + "-01");
                    }
                    ImportPGPersonInfoDataList = ReadPersonExcel.ReadPGPersonInfoData(item.FilePath + item.FileName);
                    if (ImportPGPersonInfoDataList.Count == 0)
                    {
                        return;
                    }
                    PGPersonInfoBLL bll = new PGPersonInfoBLL();
                    bll.Delete(null);
                    foreach (var model in ImportPGPersonInfoDataList)
                    {
                        bll.Add(model);
                    }
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
    }
}