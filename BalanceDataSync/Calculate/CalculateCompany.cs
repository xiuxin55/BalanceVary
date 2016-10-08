using BalanceBLL;
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
        /// 计算公司余额变动
        /// </summary>
        public override void Caculate()
        {
            base.Caculate();
            foreach (var item in ImportDataList)
            {
                if (!CompanyBalanceVary.Keys.Contains(item.AccountName + "+" + item.WebsiteID))
                {
                    CompanyBalanceVary.Add(item.AccountName+"+"+item.WebsiteID, new List<CompanyBalance>());
                }
            }
            for (int i = 0; i <= (MaxTime.Day - MinTime.Day); i++)
            {
               
                foreach (var item in CompanyBalanceVary.Keys)
                {
                    CompanyBalance cb = new CompanyBalance();
                    cb.BalanceTime = MinTime.AddDays(i);
                    cb.ID = Guid.NewGuid().ToString();
                    cb.CompanyName = item.Split('+')[0];
                    cb.WebsiteID = item.Split('+')[1];
                    CompanyBalanceVary[item].Add(cb);
                }
            }
            foreach (var item in ImportDataList)
            {

                List<CompanyBalance> list=CompanyBalanceVary[item.AccountName + "+" + item.WebsiteID];
                CompanyBalance cb = list.Find(e => e.BalanceTime == item.DataTime);
                if(cb!=null)
                {
                   
                }
                else
                {
                    continue;
                }
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
                        item.AmountMoneyVary= item.AmountMoney - pre.AmountMoney;
                    }
                }
            }
            CompanyBalanceBLL cbbll = new CompanyBalanceBLL();
            CompanyBalance cbs = new CompanyBalance();
            cbs.BalanceTime = MinTime.AddDays(-1);
            List<CompanyBalance> preList = cbbll.Select(cbs);
            foreach (var item in preList)
            {
                CompanyBalance firstwb = CompanyBalanceVary[item.CompanyName + "+" + item.WebsiteID][0];
                firstwb.RegularMoneyVary = firstwb.RegularMoney - item.RegularMoney;
                firstwb.UnRegularMoneyVary = firstwb.UnRegularMoney - item.UnRegularMoney;
                firstwb.AmountMoneyVary = firstwb.AmountMoney - item.AmountMoney;
                firstwb.Rate = firstwb.UnRegularMoney == 0 ? "0" : (firstwb.RegularMoney / firstwb.UnRegularMoney) * 100 + "%";
            }
            List<CompanyBalance> insertResult = new List<CompanyBalance>();
            foreach (var item in CompanyBalanceVary.Values)
            {
                insertResult.AddRange(item);
            }
            cbbll.BatchInsert(insertResult);
        }

        public override void ClearData()
        {
            CompanyBalanceVary.Clear();
        }
    }
}
