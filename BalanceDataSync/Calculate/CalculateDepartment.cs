using BalanceBLL;
using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class CalculateDepartment : ABCalculateBalance
    {
       
        /// <summary>
        /// 部门集合
        /// </summary>
        public List<DepartmentInfo> DepartmentList;
        public List<AccountLinkManagerInfo> AccountLinkManagerList;
        /// <summary>
        /// 变动结果
        /// </summary>
        public Dictionary<string,List<DepartmentBalance>> DepartmentBalanceVary = new Dictionary<string, List<DepartmentBalance>>();

        public CalculateDepartment(List<ImportDataInfo> importDataList) : base(importDataList)
        {

        }

        /// <summary>
        /// 计算部门余额变动
        /// </summary>
        public override  void Caculate()
        {
            base.Caculate();
            DepartmentInfoBLL bll = new DepartmentInfoBLL();
            DepartmentList = bll.Select(null);
            AccountLinkManagerInfoBLL linkbll = new AccountLinkManagerInfoBLL();
            AccountLinkManagerList = linkbll.Select(null);
            List<DateTime> ImportTimeList = new List<DateTime>();
            for (int i = 0; i <= (MaxTime.Day - MinTime.Day); i++)
            {
                foreach (var item in DepartmentList)
                {
                    IEnumerable< AccountLinkManagerInfo> linklist=AccountLinkManagerList.Where(e => e.DepartmentName == item.DepartmentName);
                    if (linklist == null || linklist.Count()==0)
                    {
                        continue;
                    }
                    DepartmentBalance db = new DepartmentBalance();
                    db.BalanceTime = MinTime.AddDays(i);
                    List<DepartmentBalance> temp;
                    DepartmentBalanceVary.TryGetValue(item.DepartmentID+"+"+item.DepartmentName, out temp);
                    if (temp == null)
                    {
                        DepartmentBalanceVary[item.DepartmentID + "+" + item.DepartmentName] = new List<DepartmentBalance>();
                    }
                    db.ID = Guid.NewGuid().ToString();
                    db.DepartmentID = item.DepartmentID;
                    db.DepartmentName = item.DepartmentName;
                    db.Rate = "0%";
                    DepartmentBalanceVary[item.DepartmentID + "+" + item.DepartmentName].Add(db);
                }
                ImportTimeList.Add(MinTime.AddDays(i));
            }

            foreach (var item in ImportDataList)
            {
                bool iscalculate = false;
                string key = "";
                foreach (var linkitem in AccountLinkManagerList)
                {
                     if(linkitem.AccountID==item.AccountID)
                    {
                        if(string.IsNullOrWhiteSpace(linkitem.SubAccountNumber) )
                        {
                            key = linkitem.DepartmentID + "+" + linkitem.DepartmentName;
                            iscalculate = true;
                        }
                        else if(linkitem.SubAccountNumber ==item.SubAccountNumber)
                        {
                            key = linkitem.DepartmentID + "+" + linkitem.DepartmentName;
                            iscalculate = true;
                        }
                    }
                }
                if (!iscalculate )
                {
                    continue;
                }

                List<DepartmentBalance> dblist;
                DepartmentBalanceVary.TryGetValue(key, out dblist);
                if (dblist == null) { continue; }
                DepartmentBalance db = dblist.Find(e => e.BalanceTime == item.DataTime);
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
            foreach (var dblist in DepartmentBalanceVary.Values)
            {
                foreach (var item in dblist)
                {
                    int index = dblist.IndexOf(item);
                    if (index > 0)
                    {
                        DepartmentBalance pre = dblist[index - 1];
                        item.RegularMoneyVary = item.RegularMoney - pre.RegularMoney;
                        item.UnRegularMoneyVary = item.UnRegularMoney - pre.UnRegularMoney;
                        item.AmountMoneyVary = item.AmountMoney - pre.AmountMoney;
                    }
                }
            }
            DepartmentBalanceBLL dbbll = new DepartmentBalanceBLL();
            DepartmentBalance w = new DepartmentBalance();
            w.BalanceTime = MinTime.AddDays(-1);
            List<DepartmentBalance> preList = dbbll.Select(w);
            foreach (var item in preList)
            {
                if (!DepartmentBalanceVary.Keys.Contains(item.DepartmentID + "+" + item.DepartmentName))
                {
                    continue;
                }
                DepartmentBalance firstwb = DepartmentBalanceVary[item.DepartmentID + "+" + item.DepartmentName][0];
                firstwb.RegularMoneyVary = firstwb.RegularMoney - item.RegularMoney;
                firstwb.UnRegularMoneyVary = firstwb.UnRegularMoney - item.UnRegularMoney;
                firstwb.AmountMoneyVary = firstwb.AmountMoney - item.AmountMoney;
                firstwb.Rate = firstwb.UnRegularMoney == 0 ? "0" : ((firstwb.RegularMoney / firstwb.UnRegularMoney) * 100).ToString("f2") + "%";
            }
            List<DepartmentBalance> insertResult = new List<DepartmentBalance>();
            foreach (var item in DepartmentBalanceVary.Values)
            {
                insertResult.AddRange(item);
            }
            dbbll.BatchInsert(insertResult, ImportTimeList);
        }

        public override void ClearData()
        {
            DepartmentBalanceVary.Clear();
        }
    }
}
