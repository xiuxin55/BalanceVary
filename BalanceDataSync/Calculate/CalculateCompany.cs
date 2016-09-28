using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class CalculateCompany : ABCalculateBalance
    {
        /// <summary>
        /// 公司变动结果
        /// </summary>
        public Dictionary<string, List<CompanyBalance>> CompanyBalanceVary = new Dictionary<string, List<CompanyBalance>>();

        public CalculateCompany(List<ImportDataInfo> importDataList) : base(importDataList)
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
                if (!CompanyBalanceVary.Keys.Contains(item.AccountName))
                {
                    CompanyBalanceVary.Add(item.AccountName, new List<CompanyBalance>());
                }
            }
            for (int i = 0; i < (MaxTime.Day - MinTime.Day); i++)
            {
                CompanyBalance cb = new CompanyBalance();
                cb.BalanceTime = MinTime.AddDays(i);
                foreach (var item in CompanyBalanceVary.Keys)
                {
                    CompanyBalanceVary[item].Add(cb);
                }
            }
            foreach (var item in ImportDataList)
            {

                List<CompanyBalance> list=CompanyBalanceVary[item.AccountName];
                CompanyBalance cb = list.Find(e => e.BalanceTime == item.DataTime);
                if (item.AccountType == CommonDataServer.AccountTypeRegular)
                {
                    //定期
                    cb.RegularMoney = cb.RegularMoney + item.CurrentBalance;
                }
                else
                {
                    //活期
                    cb.UnRegularMoney = cb.UnRegularMoney + item.CurrentBalance;
                }
                if (cb != null)
                {
                    cb.Rate = cb.UnRegularMoney == 0 ? "0" : (cb.RegularMoney / cb.UnRegularMoney) * 100 + "%";
                    cb.AmountMoney = cb.AmountMoney + item.CurrentBalance;
                }
            }
            //公司余额变动
            foreach (var cblist in CompanyBalanceVary.Values)
            {
                foreach (var item in cblist)
                {
                    int index = cblist.IndexOf(item);
                    if (index > 0)
                    {
                        CompanyBalance pre = cblist[index - 1];
                        item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                        item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                    }
                }
            }
        }

        public override void ClearData()
        {
            CompanyBalanceVary.Clear();
        }
    }
}
