using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BalanceReport.Models;
using BalanceReport.Common;
using System.Data;

namespace BalanceReport.Dao
{
    /// <summary>
    /// 操作账户
    /// </summary>
    public class AccountInfoDao
    {
        private static AccountInfoDao _instance;

        public static AccountInfoDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AccountInfoDao();
                }
                return AccountInfoDao._instance;
            }

        }

     
        /// <summary>
        /// model 查询
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<AccountInfoModel> GetAccountFromObject(AccountInfoModel model)
        {

            string sql = @"select a.ID,AccountID,AccountName,AccountType,m.ManagerID ,CorrelationState,a.SubAccountNumber,
                          m.ManagerName,m.ManagerTelphone ,ManagerEmail,w.WebsiteID,w.WebsiteName,WebsiteAddress,WebsiteTel,WebsiteManager,w.ManagerTelphone as WebsiteManagerTelphone,Institution
                          from AccountInfo a left join WebsiteInfo w on a.WebsiteID=w.WebsiteID
                          left join ManagersInfo m on a.ManagerID=m.ManagerID
                          where 1=1";
            if (!string.IsNullOrEmpty(model.AccountID))
            {
                sql = sql + " and AccountID like '%" + model.AccountID + "%'";
            }

            if (!string.IsNullOrEmpty(model.AccountName))
            {
                sql = sql + " and AccountName like '%" + model.AccountName + "%'";
            }
            if (model.CorrelationState != "全部")
            {
                sql = sql + " and CorrelationState ='" + model.CorrelationState + "'";
            }
            ObservableCollection<AccountInfoModel> list = new ObservableCollection<AccountInfoModel>();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    AccountInfoModel um = new AccountInfoModel();
                    um.ID = item["ID"].ToString();
                    um.AccountID = item["AccountID"].ToString();
                    um.AccountName = item["AccountName"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.ManagerID = item["ManagerID"].ToString();
                    um.AccountType = item["AccountType"].ToString();
                    um.CorrelationState = item["CorrelationState"].ToString();
                    um.SubAccountNumber = item["SubAccountNumber"].ToString();
                    um.WebsiteInfoObj = new WebsiteInfoModel();
                    um.WebsiteInfoObj.WebsiteName = item["WebsiteName"].ToString();
                    um.WebsiteInfoObj.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteInfoObj.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteInfoObj.WebsiteManager = item["WebsiteManager"].ToString();
                    um.WebsiteInfoObj.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.WebsiteInfoObj.Institution = item["Institution"].ToString();
                    um.ManagersInfoObj = new ManagersInfoModel();
                    um.ManagersInfoObj.ManagerName = item["ManagerName"].ToString();
                    um.ManagersInfoObj.ManagerEmail = item["ManagerEmail"].ToString();
                    um.ManagersInfoObj.ManagerTelphone = item["ManagerTelphone"].ToString();
                    list.Add(um);
                }
                CommonSql.Instance.CloseDatabase();

            }
            return list;
        }
        /// <summary>
        /// 根据网点号查询信息
        /// </summary>
        /// <param name="AccountID">网点号</param>
        /// <returns></returns>
        public AccountInfoModel SelectObjectAccountID(string AccountID, string SubAccountNumber)
        {
            string sql = string.Format(@"select * from AccountInfo where AccountID='{0}' and SubAccountNumber='{1}' ", AccountID, SubAccountNumber);
            AccountInfoModel um = new AccountInfoModel();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectObject(sql);
                foreach (DataRow item in dt.Rows)
                {

                    um.ID = item["ID"].ToString();
                    break;

                }
                CommonSql.Instance.CloseDatabase();

            }
            return um;
        }
        public bool Add(AccountInfoModel um)
        {

            string sql = string.Format(@"insert into  AccountInfo(ID,AccountID,AccountName,AccountType,WebsiteID,ManagerID ,CorrelationState,SubAccountNumber) 
                                 values('{0}','{1}','{2}','{3}','{4}','{5}','{6},'{7}')", um.ID, um.AccountID, um.AccountName, um.AccountType, um.WebsiteID, um.ManagerID, um.CorrelationState,um.SubAccountNumber);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
            }
            return false;
        }
        public bool Update(AccountInfoModel um,AccountInfoModel old)
        {
            List<string> cmdtxt = new List<string>();
            string sql = string.Format(@"update AccountInfo set AccountID='{0}',AccountName='{1}',AccountType='{2}',WebsiteID='{3}',ManagerID='{4}',CorrelationState='{5}',SubAccountNumber='{6}'  where ID='{7}'"
                , um.AccountID, um.AccountName, um.AccountType, um.WebsiteID, um.ManagerID,um.CorrelationState,um.SubAccountNumber, um.ID);

            cmdtxt.Add(sql);
            cmdtxt.Add(string.Format(@"update BalanceInfo set AccountNumber='{0}' where AccountNumber='{1}' and SubAccountNumber='{2}'", um.AccountID, old.AccountID,um.SubAccountNumber));
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.SqlTransaction(cmdtxt)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }

            }
            return false;
        }

        public bool Update(List<AccountInfoModel> list)
        {
            List<string> cmdtxt = new List<string>();
            foreach (AccountInfoModel um in list)
            {
                  string sql = string.Format(@"update AccountInfo set WebsiteID='{0}',ManagerID='{1}',CorrelationState='{2}'   where ID='{3}'"
                   ,  um.WebsiteID, um.ManagerID, um.CorrelationState, um.ID);
                  cmdtxt.Add(sql);
            }
          
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.SqlTransaction(cmdtxt)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }

            }
            return false;
        }
        public bool Delete(AccountInfoModel um)
        {
            string sql = string.Format(@"delete from AccountInfo where  ID='{0}'; delete from BalanceInfo where AccountNumber='{1}' and SubAccountNumber='{2}'", um.ID, um.AccountID,um.SubAccountNumber);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }

            }
            return false;
        }
    }
}
