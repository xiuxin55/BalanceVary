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
        List<SalaryInfo> ImportSalaryInfoDataList = new List<SalaryInfo>();
        public void ImportSalaryInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("SalaryInfo"));
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
                    ImportSalaryInfoDataList = ReadExcel.ReadSalaryInfoData(item.FilePath + item.FileName, time);
                    if (ImportSalaryInfoDataList.Count == 0)
                    {
                        return;
                    }
                    SalaryInfoBLL bll = new SalaryInfoBLL();
                    bll.BatchInsert(ImportSalaryInfoDataList,new List<DateTime>() { time });
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