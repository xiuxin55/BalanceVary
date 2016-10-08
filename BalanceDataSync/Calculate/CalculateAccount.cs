using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            foreach (var item in ImportDataList)
            {
                ImportDataInfo import = ImportDataList.Find(e => e.AccountID == item.AccountID && e.SubAccountNumber == item.SubAccountNumber&&e.DataTime==item.DataTime.AddDays(-1));
                import = import ?? new ImportDataInfo();
                AccountBalance ab = new AccountBalance();
                ab.AccountID = item.AccountID;
                ab.AccountName = item.AccountName;
                ab.AccountType = item.AccountType;
                ab.SubAccountNumber = item.SubAccountNumber;
                ab.WebsiteID = item.WebsiteID;
                ab.BalanceTime = item.DataTime;
                if(item.AccountType ==Common.Server.CommonDataServer.AccountTypeRegular)
                {
                    ab.RegularMoney = item.CurrentBalance;
                    ab.RegularMoneyVary = item.CurrentBalance - import.CurrentBalance;
                }
                if (item.AccountType == Common.Server.CommonDataServer.AccountTypeUnRegular)
                {
                    ab.UnRegularMoney = item.CurrentBalance;
                    ab.UnRegularMoneyVary = item.CurrentBalance - import.CurrentBalance;
                }
                AccountBalanceVary.Add(ab);
            }
        }
        public override void ClearData()
        {
            AccountBalanceVary.Clear();
        }
    }
}
