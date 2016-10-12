using BalanceBLL;
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
            WebsiteInfoBLL bll = new WebsiteInfoBLL();
            WebsiteList = bll.Select(null);

            List<DateTime> ImportTimeList = new List<DateTime>();
            for (int i = 0; i <= (MaxTime.Day - MinTime.Day); i++)
            {
                foreach (var item in WebsiteList)
                {
                    WebsiteBalance wb = new WebsiteBalance();
                    wb.BalanceTime = MinTime.AddDays(i);
                    List<WebsiteBalance> temp;
                    WebsiteBalanceVary.TryGetValue(item.WebsiteID, out temp);
                    if (temp == null)
                    {
                        WebsiteBalanceVary[item.WebsiteID] = new List<WebsiteBalance>();
                    }
                    wb.ID = Guid.NewGuid().ToString();
                    wb.WebsiteID = item.WebsiteID;
                    wb.ZoneType = item.Institution;
                    wb.Rate = "0%";
                    WebsiteBalanceVary[item.WebsiteID].Add(wb);
                }
                ImportTimeList.Add(MinTime.AddDays(i));
            }
           
            foreach (var item in ImportDataList)
            {
                var site = WebsiteList.Find(e => e.WebsiteID == item.WebsiteID);
                List<WebsiteBalance> wblist;
                WebsiteBalanceVary.TryGetValue(item.WebsiteID, out wblist);
                if (wblist == null) { continue; }
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
                    wb.Rate = wb.UnRegularMoney == 0 ? "0" : ((wb.RegularMoney / wb.UnRegularMoney) * 100).ToString("f2") + "%";
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
                        item.AmountMoneyVary = item.AmountMoney - pre.AmountMoney;
                    }
                }
            }
             WebsiteBalanceBLL wbbll = new WebsiteBalanceBLL();
            WebsiteBalance w = new WebsiteBalance();
            w.BalanceTime = MinTime.AddDays(-1);
            List<WebsiteBalance> preList= wbbll.Select(w);
            foreach (var item in preList)
            {
                if(!WebsiteBalanceVary.Keys.Contains(item.WebsiteID))
                {
                    continue;
                }
                WebsiteBalance firstwb = WebsiteBalanceVary[item.WebsiteID][0];
                firstwb.RegularMoneyVary = firstwb.RegularMoney - item.RegularMoney;
                firstwb.UnRegularMoneyVary = firstwb.UnRegularMoney - item.UnRegularMoney;
                firstwb.AmountMoneyVary = firstwb.AmountMoney -item.AmountMoney ;
                firstwb.Rate = firstwb.UnRegularMoney == 0 ? "0" : ((firstwb.RegularMoney / firstwb.UnRegularMoney) * 100).ToString("f2") + "%";
                }
            List<WebsiteBalance> insertResult = new List<WebsiteBalance>();
            foreach (var item in WebsiteBalanceVary.Values)
            {
                insertResult.AddRange(item);
            }
            wbbll.BatchInsert(insertResult,ImportTimeList);

        }

        public override void ClearData()
        {
            WebsiteBalanceVary.Clear();
        }
    }
}
