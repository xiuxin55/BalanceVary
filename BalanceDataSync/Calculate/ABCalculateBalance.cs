using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public abstract class ABCalculateBalance
    {
        protected List<ImportDataInfo> ImportDataList = new List<ImportDataInfo>();
        protected DateTime MinTime;
        protected DateTime MaxTime;
        public ABCalculateBalance(List<ImportDataInfo> importDataList)
        {
            this.ImportDataList = importDataList;
        }
        /// <summary>
        /// 获取数据中最大和最小时间
        /// </summary>
        protected void GetMinMaxTime()
        {
            MinTime = ImportDataList.Min(p => p.DataTime);
            MaxTime = ImportDataList.Max(p => p.DataTime);
        }
        public virtual void Caculate()
        {
            GetMinMaxTime();
            ClearData();
        }
        public abstract void ClearData();
    }
}
