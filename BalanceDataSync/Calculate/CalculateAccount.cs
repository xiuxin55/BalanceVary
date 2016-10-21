using BalanceBLL;
using BalanceModel;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceDataSync
{
    public class CalculateAccount : ABCalculateBalance
    {
        
        /// <summary>
        /// 账户变动结果
        /// </summary>
        public List<AccountBalance> AccountBalanceVary = new List<AccountBalance>();
        public CalculateAccount(List<ImportDataInfo> importDataList) : base(importDataList)
        {
        }

        /// <summary>
        /// 计算账户余额变动
        /// </summary>
        public override void Caculate()
        {
            base.Caculate();
            ConcurrentBag<DateTime> ImportTimeList = new ConcurrentBag<DateTime>();
            ConcurrentBag<AccountBalance> AccountBalanceVaryTemp = new ConcurrentBag<AccountBalance>();
            ConcurrentBag<int> MinTimeIndexList = new ConcurrentBag<int>();
            Parallel.For(0, ImportDataList.Count, i =>

            {
                ImportDataInfo item = ImportDataList[i];
                ImportDataInfo import = null;
                if (i>0  )
                {
                    if (ImportDataList[i - 1].AccountID == item.AccountID && ImportDataList[i - 1].SubAccountNumber == item.SubAccountNumber  && ImportDataList[i - 1].DataTime == item.DataTime.AddDays(-1))
                    {
                        import = ImportDataList[i - 1];
                    }
                    else
                    {
                        import = ImportDataList.Find(e => e.AccountID == item.AccountID && e.SubAccountNumber == item.SubAccountNumber && e.DataTime == item.DataTime.AddDays(-1));
                    }
                }
               
                import = import ?? new ImportDataInfo();
                AccountBalance ab = new AccountBalance();
                ab.ID = Guid.NewGuid().ToString();
                ab.AccountID = item.AccountID;
                ab.AccountName = item.AccountName;
                ab.AccountType = item.AccountType;
                ab.SubAccountNumber = item.SubAccountNumber;
                ab.WebsiteID = item.WebsiteID;
                ab.BalanceTime = item.DataTime;
                ab.Rate = "0%";
                if (item.AccountType == Common.Server.CommonDataServer.AccountTypeRegular)
                {
                    ab.RegularMoney = item.CurrentBalance;
                    ab.AmountMoney = item.CurrentBalance; ;
                    ab.RegularMoneyVary = item.CurrentBalance - import.CurrentBalance;
                    ab.AmountMoneyVary = ab.RegularMoneyVary;
                }
                if (item.AccountType == Common.Server.CommonDataServer.AccountTypeUnRegular)
                {
                    ab.UnRegularMoney = item.CurrentBalance;
                    ab.AmountMoney = item.CurrentBalance; ;
                    ab.UnRegularMoneyVary = item.CurrentBalance - import.CurrentBalance;
                    ab.AmountMoneyVary = ab.UnRegularMoneyVary;
                }
                AccountBalanceVaryTemp.Add(ab);
                if(item.DataTime==MinTime)
                {
                    MinTimeIndexList.Add(AccountBalanceVaryTemp.Count-1);
                }
                if (!ImportTimeList.Contains(item.DataTime))
                {
                    ImportTimeList.Add(item.DataTime);
                }

            });
            AccountBalanceVary = AccountBalanceVaryTemp.ToList();
            AccountBalanceBLL abbll = new AccountBalanceBLL();
            AccountBalance abs = new AccountBalance();
            abs.BalanceTime = MinTime.AddDays(-1);
            List<AccountBalance> preList = abbll.Select(abs);
            if (preList != null && preList.Count>0)
            {
                foreach (var index in MinTimeIndexList)
                {
                    AccountBalance firstwb = AccountBalanceVary[index];
                    AccountBalance item = preList.Find(e => e.BalanceTime == MinTime && e.AccountID == firstwb.AccountID && e.SubAccountNumber == firstwb.SubAccountNumber);
                    if (item == null)
                    {
                        continue;
                    }
                    firstwb.RegularMoneyVary = firstwb.RegularMoney - item.RegularMoney;
                    firstwb.UnRegularMoneyVary = firstwb.UnRegularMoney - item.UnRegularMoney;
                    firstwb.AmountMoneyVary = firstwb.AmountMoney - item.AmountMoney;
                    firstwb.Rate = firstwb.UnRegularMoney == 0 ? "0" : ((firstwb.RegularMoney / firstwb.UnRegularMoney) * 100).ToString("f2") + "%";
                }
            }
            abbll.BatchInsert(AccountBalanceVary, ImportTimeList.ToList());
        }
        public override void ClearData()
        {
            AccountBalanceVary.Clear();
        }
    }
}
