using BalanceBLL;
using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class CalculateZone: ABCalculateBalance
    {
       
        /// <summary>
        /// 网点集合
        /// </summary>
        public List<WebsiteInfo> WebsiteList;
        /// <summary>
        /// 市行变动结果
        /// </summary>
        public List<ZoneBalance> CityZoneBalanceVary = new List<ZoneBalance>();
        /// <summary>
        /// 县行变动结果
        /// </summary>
        public List<ZoneBalance> CountyZoneBalanceVary = new List<ZoneBalance>();

        public CalculateZone(List<ImportDataInfo> importDataList) : base(importDataList)
        {

        }

        /// <summary>
        /// 计算市行、县行余额变动
        /// </summary>
        public override  void Caculate()
        {
            base.Caculate();
            for (int i = 0; i <= (MaxTime.Day- MinTime.Day); i++)
            {
                ZoneBalance zb = new ZoneBalance();
                zb.BalanceTime = MinTime.AddDays(i);
                CityZoneBalanceVary.Add(zb);
                ZoneBalance zb2 = new ZoneBalance();
                zb.BalanceTime = MinTime.AddDays(i);
                CountyZoneBalanceVary.Add(zb2);
            }
            WebsiteInfoBLL bll = new WebsiteInfoBLL();
            WebsiteList= bll.Select(null);
            foreach (var item in ImportDataList)
            {
                var site = WebsiteList.Find(e => e.WebsiteID == item.WebsiteID);
                if (site == null) { return; }
                ZoneBalance zb = null;
                if (site!=null && site.Institution== CommonDataServer.CityZoneCode)
                {
                     zb = CityZoneBalanceVary.Find(e => e.BalanceTime == item.DataTime);
                    
                }
                if (site != null && site.Institution == CommonDataServer.CountyZoneCode)
                {
                    zb = CountyZoneBalanceVary.Find(e => e.BalanceTime == item.DataTime);
                }
                if (item.AccountType == CommonDataServer.AccountTypeRegular)
                {
                    //定期
                    zb.RegularMoney = zb.RegularMoney + item.CurrentBalance;
                }
                else
                {
                    //活期
                    zb.UnRegularMoney = zb.UnRegularMoney + item.CurrentBalance;
                }
                if(zb!=null)
                {
                    zb.Rate = zb.UnRegularMoney == 0 ? "0" : (zb.RegularMoney / zb.UnRegularMoney) * 100 + "%";
                    zb.AmountMoney = zb.AmountMoney + item.CurrentBalance;
                }
            }
            
            //计算市行余额变动
            foreach (var item in CityZoneBalanceVary)
            {
                int index = CityZoneBalanceVary.IndexOf(item);
                if(index>0)
                {
                    ZoneBalance pre = CityZoneBalanceVary[index - 1];
                    item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                    item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                }
            }
            //计算县行余额变动
            foreach (var item in CountyZoneBalanceVary)
            {
                int index = CountyZoneBalanceVary.IndexOf(item);
                if (index > 0)
                {
                    ZoneBalance pre = CountyZoneBalanceVary[index - 1];
                    item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                    item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                }
            }
        }

        public override void ClearData()
        {
            CityZoneBalanceVary.Clear();
            CountyZoneBalanceVary.Clear();
        }
    }
}
