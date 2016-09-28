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
       
        /// <summary>
        /// 导入日数据
        /// </summary>
        public  void ImportDayData()
        {

            CalculateData();
        }
        /// <summary>
        /// 导入月数据
        /// </summary>
        public  void ImportMonthData()
        {

            CalculateData();
        }
        private void CalculateData()
        {
            ABCalculateBalance cz = new CalculateZone(ImportDataList);
            ABCalculateBalance cw = new CalculateWebsite(ImportDataList);
            ABCalculateBalance cc = new CalculateCompany(ImportDataList);
            ABCalculateBalance ca = new CalculateAccount(ImportDataList);
            ca.Caculate();
            cw.Caculate();
            cz.Caculate();
            cc.Caculate();
        }
    }
}
