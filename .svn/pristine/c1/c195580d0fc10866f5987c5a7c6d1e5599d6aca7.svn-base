using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using BalanceReportDao.Common;
using BalanceReportModel;

namespace BalanceReportDao.Dao
{
    public class BalanceInfoDao
    {
        private static BalanceInfoDao _instance;

        public static BalanceInfoDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BalanceInfoDao();
                }
                return BalanceInfoDao._instance;
            }

        }

       
        /// <summary>
        /// 查询活期比
        /// </summary>
        /// <returns></returns>
        public string GetBalanceFromObject(string start,string end,string i)
        {

            string sql = string.Format(@"select SUM(CONVERT(decimal(18,4), b.Balance)) as money, a.AccountType,w.Institution 
                           from dbo.BalanceInfo b left join dbo.AccountInfo a on b.AccountNumber=a.AccountID left join dbo.WebsiteInfo w on a.WebsiteID=w.WebsiteID
                           where BalanceTime>='{0}' and BalanceTime<='{1}' and w.Institution='{2}' group by w.Institution,a.AccountType ", start, end, i);
            double vary=0, regular=0;
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    if (item["AccountType"].ToString() == "活期")
                    {
                        vary = double.Parse(item["money"].ToString());
                    }
                    if (item["AccountType"].ToString() == "定期")
                    {
                        regular = double.Parse(item["money"].ToString());
                    }
                }
                CommonSql.Instance.CloseDatabase();

            }
            if (regular + vary == 0)
            {
                return "0";
            }
            else
            {
                return ((vary / (regular + vary))*100).ToString("0.00")+"%";
            }
           
        }
        public List<BalanceVaryModel> ExcecuteBalanceVaryModel(string sql, string strwhere)
        {
            List<BalanceVaryModel> list = new List<BalanceVaryModel>();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    BalanceVaryModel um = new BalanceVaryModel();
                    um.ID = item["ID"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.DifferWebsite = item["DifferWebsite"].ToString();
                    um.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteManager = item["WebsiteManager"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.AmountMoney = item["AmountMoney"].ToString();
                    um.Name = item["Name"].ToString();
                    um.RegularMoney = item["RegularMoney"].ToString();
                    um.UnRegularMoney = item["UnRegularMoney"].ToString();
                    um.BalanceTime = item["BalanceTime"].ToString();
                    
                    um.ParentID = item["ParentID"].ToString();
                    list.Add(um);
                }
                sql = string.Format(@"select * from dbo.View_AccountEverydayBalance   {0} ", strwhere);
                 DataTable dt2 = CommonSql.Instance.SelectAll(sql);
                 foreach (DataRow item in dt2.Rows)
                 {
                     BalanceVaryModel um = new BalanceVaryModel();
                     BalanceVaryModel temp = list.Find(m => m.Name == item["WebsiteID"].ToString() && m.ID.Contains(item["BalanceTime"].ToString()));
                     um.ID = item["ID"].ToString();
                     um.WebsiteID = item["WebsiteID"].ToString();
                     um.DifferWebsite = item["DifferWebsite"].ToString();//代表定期年限
                     um.WebsiteAddress = item["WebsiteAddress"].ToString();
                     um.WebsiteTel = item["WebsiteTel"].ToString();
                     um.WebsiteManager = item["WebsiteManager"].ToString();
                     um.ManagerTelphone = item["ManagerTelphone"].ToString();
                     um.AmountMoney = item["AmountMoney"].ToString();
                     um.BalanceTime = item["BalanceTime"].ToString();
                     um.Name = item["Name"].ToString();
                     um.RegularMoney = item["RegularMoney"].ToString();
                     um.UnRegularMoney = item["UnRegularMoney"].ToString();
                     um.ParentID = temp.ID;
                     list.Add(um);
                 }
                CommonSql.Instance.CloseDatabase();

            }
            return list;
        }
    }
}
