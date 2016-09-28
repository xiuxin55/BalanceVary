using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class CalculateWebsite: ABCalculateBalance
    {
       
        /// <summary>
        /// 网点集合
        /// </summary>
        public List<WebsiteInfo> WebsiteList;
        /// <summary>
        /// 网点变动结果
        /// </summary>
        public Dictionary<string, List<WebsiteBalance>> WebsiteBalanceVary =new  Dictionary<string, List<WebsiteBalance>>();

        public CalculateWebsite(List<ImportDataInfo> importDataList) : base(importDataList)
        {
        }

        /// <summary>
        /// 计算市行、县行余额变动
        /// </summary>
        public override void Caculate()
        {
            base.Caculate();
            for (int i = 0; i < (MaxTime.Day - MinTime.Day); i++)
            {
                WebsiteBalance wb = new WebsiteBalance();
                wb.BalanceTime = MinTime.AddDays(i);
                foreach (var item in WebsiteList)
                {
                    List<WebsiteBalance> temp;
                    WebsiteBalanceVary.TryGetValue(item.ID, out temp);
                    if (temp == null)
                    {
                        WebsiteBalanceVary[item.ID] = new List<WebsiteBalance>();
                    }
                    WebsiteBalanceVary[item.ID].Add(wb);
                }
            }
            foreach (var item in ImportDataList)
            {
                var site = WebsiteList.Find(e => e.ID == item.WebsiteID);
                List<WebsiteBalance> wblist;
                WebsiteBalanceVary.TryGetValue(item.ID, out wblist);
                if (wblist == null) { return; }
                WebsiteBalance wb = wblist.Find(e => e.BalanceTime == item.DataTime);
                if (item.AccountType == CommonDataServer.AccountTypeRegular)
                {
                    //定期
                    wb.RegularMoney = wb.RegularMoney + item.CurrentBalance;
                }
                else
                {
                    //活期
                    wb.UnRegularMoney = wb.UnRegularMoney + item.CurrentBalance;
                }
                if (wb != null)
                {
                    wb.Rate = wb.UnRegularMoney == 0 ? "0" : (wb.RegularMoney / wb.UnRegularMoney) * 100 + "%";
                    wb.AmountMoney = wb.AmountMoney + item.CurrentBalance;
                }
            }

            //计算网点余额变动
            foreach (var wblist in WebsiteBalanceVary.Values)
            {
                foreach (var item in wblist)
                {
                    int index = wblist.IndexOf(item);
                    if (index > 0)
                    {
                        WebsiteBalance pre = wblist[index - 1];
                        item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                        item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                    }
                }
            }
        }

        public override void ClearData()
        {
            WebsiteBalanceVary.Clear();
        }
    }
}
