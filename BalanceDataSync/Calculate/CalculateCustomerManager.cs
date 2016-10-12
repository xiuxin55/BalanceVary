using BalanceBLL;
using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{

    public class CalculateCustomerManager : ABCalculateBalance
    {

        /// <summary>
        /// 客户经理集合
        /// </summary>
        public List<CustomerManagerInfo> CustomerManagerList;
        public List<AccountLinkManagerInfo> AccountLinkManagerList;
        /// <summary>
        /// 变动结果
        /// </summary>
        public Dictionary<string, List<CustomerManagerBalance>> CustomerManagerBalanceVary = new Dictionary<string, List<CustomerManagerBalance>>();

        public CalculateCustomerManager(List<ImportDataInfo> importDataList) : base(importDataList)
        {

        }

        /// <summary>
        /// 计算部门余额变动
        /// </summary>
        public override void Caculate()
        {
            base.Caculate();
            CustomerManagerInfoBLL bll = new CustomerManagerInfoBLL();
            CustomerManagerList = bll.Select(null);
            AccountLinkManagerInfoBLL linkbll = new AccountLinkManagerInfoBLL();
            AccountLinkManagerList = linkbll.Select(null);
            List<DateTime> ImportTimeList = new List<DateTime>();
            for (int i = 0; i <= (MaxTime.Day - MinTime.Day); i++)
            {
                foreach (var item in CustomerManagerList)
                {
                    IEnumerable<AccountLinkManagerInfo> linklist = AccountLinkManagerList.Where(e => e.ManagerName == item.ManagerName);
                    if (linklist == null || linklist.Count() == 0)
                    {
                        continue;
                    }
                    CustomerManagerBalance db = new CustomerManagerBalance();
                    db.BalanceTime = MinTime.AddDays(i);
                    List<CustomerManagerBalance> temp;
                    CustomerManagerBalanceVary.TryGetValue(item.ManagerID + "+" + item.ManagerName, out temp);
                    if (temp == null)
                    {
                        CustomerManagerBalanceVary[item.ManagerID + "+" + item.ManagerName] = new List<CustomerManagerBalance>();
                    }
                    db.ID = Guid.NewGuid().ToString();
                    db.DepartmentID  = item.DepartmentID;
                    db.DepartmentName = item.DepartmentName;
                    db.ManagerID = item.ManagerID;
                    db.ManagerName = item.ManagerName;
                    db.Rate = "0%";
                    CustomerManagerBalanceVary[item.ManagerID + "+" + item.ManagerName].Add(db);
                }
                ImportTimeList.Add(MinTime.AddDays(i));
            }

            foreach (var item in ImportDataList)
            {
                bool iscalculate = false;
                string key = "";
                foreach (var linkitem in AccountLinkManagerList)
                {
                    if (linkitem.AccountID == item.AccountID)
                    {
                        if (string.IsNullOrWhiteSpace(linkitem.SubAccountNumber))
                        {
                            key = linkitem.ManagerID + "+" + linkitem.ManagerName;
                            iscalculate = true;
                        }
                        else if (linkitem.SubAccountNumber == item.SubAccountNumber)
                        {
                            key = linkitem.ManagerID + "+" + linkitem.ManagerName;
                            iscalculate = true;
                        }
                    }
                }
                if (!iscalculate)
                {
                    continue;
                }

                List<CustomerManagerBalance> dblist;
                CustomerManagerBalanceVary.TryGetValue(key, out dblist);
                if (dblist == null) { continue; }
                CustomerManagerBalance db = dblist.Find(e => e.BalanceTime == item.DataTime);
                if (item.AccountType == CommonDataServer.AccountTypeRegular)
                {
                    //定期
                    db.RegularMoney = db.RegularMoney + item.CurrentBalance;
                }
                else
                {
                    //活期
                    db.UnRegularMoney = db.UnRegularMoney + item.CurrentBalance;
                }
                if (db != null)
                {
                    db.Rate = db.UnRegularMoney == 0 ? "0" : ((db.RegularMoney / db.UnRegularMoney) * 100).ToString("f2") + "%";
                    db.AmountMoney = db.AmountMoney + item.CurrentBalance;
                }
            }

            //计算部门余额变动
            foreach (var dblist in CustomerManagerBalanceVary.Values)
            {
                foreach (var item in dblist)
                {
                    int index = dblist.IndexOf(item);
                    if (index > 0)
                    {
                        CustomerManagerBalance pre = dblist[index - 1];
                        item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                        item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                        item.AmountMoneyVary = item.AmountMoney - pre.AmountMoney;
                    }
                }
            }
            CustomerManagerBalanceBLL dbbll = new CustomerManagerBalanceBLL();
            CustomerManagerBalance w = new CustomerManagerBalance();
            w.BalanceTime = MinTime.AddDays(-1);
            List<CustomerManagerBalance> preList = dbbll.Select(w);
            foreach (var item in preList)
            {
                if (!CustomerManagerBalanceVary.Keys.Contains(item.ManagerID + "+" + item.ManagerName))
                {
                    continue;
                }
                CustomerManagerBalance firstwb = CustomerManagerBalanceVary[item.ManagerID + "+" + item.ManagerName][0];
                firstwb.RegularMoneyVary = firstwb.RegularMoney - item.RegularMoney;
                firstwb.UnRegularMoneyVary = firstwb.UnRegularMoney - item.UnRegularMoney;
                firstwb.AmountMoneyVary = firstwb.AmountMoney - item.AmountMoney;
                firstwb.Rate = firstwb.UnRegularMoney == 0 ? "0" : ((firstwb.RegularMoney / firstwb.UnRegularMoney) * 100).ToString("f2") + "%";
            }
            List<CustomerManagerBalance> insertResult = new List<CustomerManagerBalance>();
            foreach (var item in CustomerManagerBalanceVary.Values)
            {
                insertResult.AddRange(item);
            }
            dbbll.BatchInsert(insertResult, ImportTimeList);
        }

        public override void ClearData()
        {
            CustomerManagerBalanceVary.Clear();
        }
    }
}
