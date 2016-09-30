using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class SyncDataHandler : ISyncDataHandler
    {

        List<ImportDataInfo> ImportDataList = new List<ImportDataInfo>();
        List<UploadFileInfo> UploadFileInfoList = new List<UploadFileInfo>();
        public SyncDataHandler(List<UploadFileInfo> uploadFileInfoList)
        {
            this.UploadFileInfoList = uploadFileInfoList;
        }
        /// <summary>
        /// 导入日数据
        /// </summary>
        public  void ImportDayData()
        {
            IEnumerable<UploadFileInfo> filelist= UploadFileInfoList.Where(p => p.FileName.ToLower().Contains("day"));
            foreach (var item in filelist)
            {
                ReadExcel.ReadDayData(item.FilePath+item.FileName,item.FileDateTime.Value);
                CalculateData();
            }
           
        }
        /// <summary>
        /// 导入月数据
        /// </summary>
        public  void ImportMonthData()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.ToLower().Contains("month"));
            foreach (var item in filelist)
            {
                ImportDataList=ReadExcel.ReadMonthData(item.FilePath + item.FileName, item.FileDateTime.Value);
                if (ImportDataList == null || ImportDataList.Count == 0)
                {
                    return;
                }
                CalculateData();
            }
        }
        private void CalculateData()
        {
            ABCalculateBalance cz = new CalculateZone(ImportDataList);
            ABCalculateBalance cw = new CalculateWebsite(ImportDataList);
            ABCalculateBalance cc = new CalculateCompany(ImportDataList);
            ABCalculateBalance ca = new CalculateAccount(ImportDataList);
            cz.Caculate();
            cw.Caculate();
            cc.Caculate();
            ca.Caculate();
        }
    }
}
