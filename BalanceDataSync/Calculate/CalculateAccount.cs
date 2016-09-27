using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class CalculateAccount : ICalculateBalance
    {
        List<ImportDataInfo> ImportDataList = new List<ImportDataInfo>();
        DateTime MinTime;
        DateTime MaxTime;
        /// <summary>
        /// 获取数据中最大和最小时间
        /// </summary>
        public void GetMinMaxTime()
        {
            MinTime = ImportDataList.Min(p => p.DataTime);
            MaxTime = ImportDataList.Max(p => p.DataTime);
        }
        /// <summary>
        /// 账户变动结果
        /// </summary>
        public List<AccountBalance> AccountBalanceVary = new List<AccountBalance>();

        /// <summary>
        /// 计算市行、县行余额变动
        /// </summary>
        public void Caculate()
        {
            foreach (var item in ImportDataList)
            {

            }
        }
    }
}
