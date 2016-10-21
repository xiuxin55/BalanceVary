using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Windows.Forms;
using BalanceModel.Models;

namespace BalanceReportDao.Dao
{
    public class ImportDataDao
    {
        private static ImportDataDao _instance;

        public static ImportDataDao Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ImportDataDao();
                }
                return ImportDataDao._instance;
            }

        }
        /// <summary>
        /// 提示补充网点号信息
        /// </summary>
        /// <returns></returns>
        public int NotHandleWebsiteInfo()
        {
           
            string sql = @"select * from ImportData where WebsiteID not in (select distinct WebsiteID from WebsiteInfo) ";
            DataTable dt = Common.CommonSql.Instance.SelectAll(sql);
            List<string> sqllist = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                string insertsql = string.Format(@"insert into  WebsiteInfo(ID,WebsiteID) values('{0}','{1}')", Guid.NewGuid(), item["WebsiteID"].ToString());
                sqllist.Add(insertsql);
            }
            if (sqllist.Count>0 && Common.CommonSql.Instance.ConnectDatabase())
            {
                if (!Common.CommonSql.Instance.SqlTransaction(sqllist))
                {
                    return 0;
                }
                Common.CommonSql.Instance.CloseDatabase();
            }

            return sqllist.Count;
        }

        public List<ImportDataModel> ImportData(string filename,out int uncomplete)
        {
            uncomplete = 0;
            try
            {
                
                List<ImportDataModel> list = new List<ImportDataModel>();
                List<string> cmdtxts = new List<string>();
                DataTable dt = Common.NPOIHelper.Import(filename);
                foreach (DataRow item in dt.Rows)
                {
                    ImportDataModel dm = new ImportDataModel();
                    dm.ID = Guid.NewGuid().ToString();
                    dm.CustomerNumber = item["客户账号"].ToString().Trim();
                    dm.SubAccountNumber = item["子账号"].ToString().Trim();
                    dm.AccountType = item["定活标志"].ToString().Trim();
                    dm.AccountName = item["账户名称"].ToString().Trim();
                    dm.WebsiteID = item["开户机构"].ToString().Trim();
                    dm.CurrentBalance = item["当前余额"].ToString().Trim();
                    dm.MoneyType = item["币种"].ToString().Trim();
                    dm.ImportTime = DateTime.Now.ToString("yyyy-MM-dd"); //hh:mm:ss
                    list.Add(dm);
                    string sql = string.Format(@"insert into ImportData(ID,CustomerNumber,SubAccountNumber,AccountType,AccountName,WebsiteID,CurrentBalance,MoneyType,ImportTime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                        dm.ID, dm.CustomerNumber,dm.SubAccountNumber, dm.AccountType, dm.AccountName, dm.WebsiteID, dm.CurrentBalance, dm.MoneyType, dm.ImportTime);

                    cmdtxts.Add(sql);
                    AccountInfoModel wim = AccountInfoDao.Instance.SelectObjectAccountID(dm.CustomerNumber);
                    if (wim.ID == null)
                    {
                        string sqlAccountInfo = string.Format(@"insert into  AccountInfo(ID,AccountID,AccountName,AccountType,WebsiteID,ManagerID ,CorrelationState)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Guid.NewGuid().ToString(), dm.AccountName, dm.CustomerNumber, dm.AccountType, dm.WebsiteID, "","未关联");
                        cmdtxts.Add(sqlAccountInfo);
                        uncomplete++;
                    }
                    string sqlBalanceInfo = string.Format(@"insert into BalanceInfo(ID,AccountNumber,SubAccountNumber,Balance,BalanceState,BalanceTime,MoneyType) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", Guid.NewGuid().ToString(), dm.CustomerNumber, dm.SubAccountNumber, dm.CurrentBalance, "", dm.ImportTime,dm.MoneyType);
                    cmdtxts.Add(sqlBalanceInfo);
                }
                if (Common.CommonSql.Instance.ConnectDatabase())
                {
                    if (!Common.CommonSql.Instance.SqlTransaction(cmdtxts))
                    {
                        list = null;
                    }
                    Common.CommonSql.Instance.CloseDatabase();
                }
                return list;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
