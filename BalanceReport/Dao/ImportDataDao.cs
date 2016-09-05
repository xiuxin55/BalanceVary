using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceReport.Models;
using System.Data;
using System.Windows.Forms;
using BalanceReport.Common;
using System.ComponentModel;
using BalanceReport.Views;
using System.Windows;
using System.Threading;

namespace BalanceReport.Dao
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
        public string NotHandleWebsiteInfo(out int result)
        {
           
            //string sql = @"select * from ImportData where WebsiteID not in (select distinct WebsiteID from WebsiteInfo) ";
            //DataTable dt = Common.CommonSql.Instance.SelectAll(sql);
            //List<string> sqllist = new List<string>();
            //foreach (DataRow item in dt.Rows)
            //{
            //    string insertsql = string.Format(@"insert into  WebsiteInfo(ID,WebsiteID) values('{0}','{1}')", Guid.NewGuid(), item["WebsiteID"].ToString());
            //    sqllist.Add(insertsql);
            //}
            //if (sqllist.Count>0 && Common.CommonSql.Instance.ConnectDatabase())
            //{
            //    if (!Common.CommonSql.Instance.SqlTransaction(sqllist))
            //    {
            //        return 0;
            //    }
            //    Common.CommonSql.Instance.CloseDatabase();
            //}

            //return sqllist.Count;
            string sql = @"select * from ImportData where WebsiteID not in (select distinct WebsiteID from WebsiteInfo) ";
            DataTable dt = Common.CommonSql.Instance.SelectAll(sql);

            List<string> strlist = new List<string>();
            string str = "";
            foreach (DataRow item in dt.Rows)
            {
                ImportDataModel dm = new ImportDataModel();
                dm.ID = Guid.NewGuid().ToString();

                dm.CustomerNumber = item["CustomerNumber"].ToString().Trim();

                dm.AccountName = item["AccountName"].ToString().Trim();
                dm.WebsiteID = item["WebsiteID"].ToString().Trim();
                 
                    strlist.Add("客户账号:" + dm.CustomerNumber + "   账户名称:" + dm.AccountName + "   所属网点号:" + dm.WebsiteID);
                
                
                
            }
            if (strlist.Count > 0)
            {
                str = "账户信息导入记录" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                CommonLog.Instance.WriteLog(strlist, str);
            }
            result = dt.Rows.Count;
            return str;
        }
       
        public List<ImportDataModel> ImportData(string filename,out int uncomplete)
        {
            uncomplete = 0;
            try
            {

                List<ImportDataModel> list = new List<ImportDataModel>();
                List<string> cmdtxts = new List<string>();
                DataTable dt = Common.NPOIHelper.Instance.Import(filename);
                double jinDu;
                Thread.CurrentThread.Join(1);
                DataTable dtImportData = new DataTable();
                dtImportData.TableName = "ImportData";
                dtImportData.Columns.Add("ID");
                dtImportData.Columns.Add("CustomerNumber");
                dtImportData.Columns.Add("SubAccountNumber");
                dtImportData.Columns.Add("AccountType");
                dtImportData.Columns.Add("AccountName");
                dtImportData.Columns.Add("WebsiteID");
                dtImportData.Columns.Add("CurrentBalance");
                dtImportData.Columns.Add("MoneyType");
                dtImportData.Columns.Add("ImportTime");
                DataTable dtAccountInfoImportInfo = new DataTable();
                dtAccountInfoImportInfo.TableName = "AccountInfoImportInfo";
                dtAccountInfoImportInfo.Columns.Add("ID");
                dtAccountInfoImportInfo.Columns.Add("AccountID");
                dtAccountInfoImportInfo.Columns.Add("AccountName");
                dtAccountInfoImportInfo.Columns.Add("AccountType");
                dtAccountInfoImportInfo.Columns.Add("WebsiteID");
                dtAccountInfoImportInfo.Columns.Add("ManagerID");
                dtAccountInfoImportInfo.Columns.Add("CorrelationState");
                dtAccountInfoImportInfo.Columns.Add("SubAccountNumber");

                DataTable dtBalanceInfoImportInfo = new DataTable();
                dtBalanceInfoImportInfo.TableName = "BalanceInfoImportInfo";
                dtBalanceInfoImportInfo.Columns.Add("ID");
                dtBalanceInfoImportInfo.Columns.Add("AccountNumber");
                dtBalanceInfoImportInfo.Columns.Add("SubAccountNumber");
                dtBalanceInfoImportInfo.Columns.Add("Balance");
                dtBalanceInfoImportInfo.Columns.Add("MoneyType");
                dtBalanceInfoImportInfo.Columns.Add("BalanceState");
                dtBalanceInfoImportInfo.Columns.Add("BalanceTime");
                foreach (DataRow item in dt.Rows)
                {
                    ImportDataModel dm = new ImportDataModel();
                    dm.ID = Guid.NewGuid().ToString();
                    try
                    {
                        dm.CustomerNumber = item["客户账号"].ToString().Trim();
                        dm.SubAccountNumber = item["子账号"].ToString().Trim();
                        dm.AccountType = item["定活标志"].ToString().Trim();
                        dm.AccountName = item["账户名称"].ToString().Trim();
                        dm.WebsiteID = item["开户机构"].ToString().Trim();
                        dm.CurrentBalance = item["当前余额"].ToString().Trim();
                        dm.MoneyType = item["币种"].ToString().Trim();
                    }
                    catch
                    {
                        dm.CustomerNumber = item[0].ToString().Trim();
                        dm.SubAccountNumber = item[1].ToString().Trim();
                        dm.AccountType = item[2].ToString().Trim();
                        dm.AccountName = item[3].ToString().Trim();
                        dm.WebsiteID = item[4].ToString().Trim();
                        dm.CurrentBalance = item[5].ToString().Trim();
                        dm.MoneyType = item[6].ToString().Trim();
                    }

                    dm.ImportTime = CommonData.Instance.ImportTime;// DateTime.Now.ToString("yyyy-MM-dd"); //hh:mm:ss
                
                    //string sql = string.Format(@"insert into ImportData(ID,CustomerNumber,SubAccountNumber,AccountType,AccountName,WebsiteID,CurrentBalance,MoneyType,ImportTime) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}')",
                    //    dm.ID, dm.CustomerNumber, dm.SubAccountNumber, dm.AccountType, dm.AccountName, dm.WebsiteID, dm.CurrentBalance, dm.MoneyType, dm.ImportTime);
                    DataRow dr1 = dtImportData.NewRow();
                    dr1[0] = Guid.NewGuid().ToString();
                    dr1[1] = dm.CustomerNumber;
                    dr1[2] = dm.SubAccountNumber;
                    dr1[3] = dm.AccountType;
                    dr1[4] = dm.AccountName;
                    dr1[5] = dm.WebsiteID;
                    dr1[6] = dm.CurrentBalance;
                    dr1[7] = dm.MoneyType;
                    dr1[8] = dm.ImportTime;
                    dtImportData.Rows.Add(dr1);
                    //cmdtxts.Add(sql);
                    //AccountInfoModel wim = AccountInfoDao.Instance.SelectObjectAccountID(dm.CustomerNumber);
                    //if (wim.ID == null)
                    //{
                    //    string sqlAccountInfo = string.Format(@"insert into  AccountInfo(ID,AccountID,AccountName,AccountType,WebsiteID,ManagerID ,CorrelationState)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Guid.NewGuid().ToString(), dm.CustomerNumber, dm.AccountName, dm.AccountType, dm.WebsiteID, "", "未关联");
                    //    cmdtxts.Add(sqlAccountInfo);
                    //    uncomplete++;


                    //    string sqlBalanceInfo = string.Format(@"insert into BalanceInfo(ID,AccountNumber,SubAccountNumber,Balance,BalanceState,BalanceTime,MoneyType) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", Guid.NewGuid().ToString(), dm.CustomerNumber, dm.SubAccountNumber, dm.CurrentBalance, "", dm.ImportTime, dm.MoneyType);
                    //    cmdtxts.Add(sqlBalanceInfo);
                    //}
                    //else
                    //{
                    //string sqlAccountInfo = string.Format(@"insert into  AccountInfoImportInfo(ID,AccountID,AccountName,AccountType,WebsiteID,ManagerID ,CorrelationState,SubAccountNumber)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')",
                    //    Guid.NewGuid().ToString(), dm.CustomerNumber, dm.AccountName, dm.AccountType, dm.WebsiteID, "", "未关联",dm.SubAccountNumber);
                    //    cmdtxts.Add(sqlAccountInfo);
                        DataRow dr2 = dtAccountInfoImportInfo.NewRow();
                        dr2[0] = Guid.NewGuid().ToString();
                        dr2[1] = dm.CustomerNumber;
                        dr2[2] = dm.AccountName;
                        dr2[3] = dm.AccountType;
                        dr2[4] = dm.WebsiteID;
                        dr2[5] = "";
                        dr2[6] = "未关联";
                        dr2[7] = dm.SubAccountNumber;
                        DataRow[] ddr = dtAccountInfoImportInfo.Select("AccountID='" + dm.CustomerNumber + "' and AccountName='" + dm.AccountName + "' and SubAccountNumber='" + dm.SubAccountNumber + "'");
                        if (ddr == null || ddr.Length == 0)
                        {
                            dtAccountInfoImportInfo.Rows.Add(dr2);
                        }
     
             
                     
                        //string sqlBalanceInfo = string.Format(@"insert into BalanceInfo(ID,AccountNumber,SubAccountNumber,Balance,BalanceState,BalanceTime,MoneyType) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", 
                        //    Guid.NewGuid().ToString(), dm.CustomerNumber, dm.SubAccountNumber, dm.CurrentBalance, "", dm.ImportTime, dm.MoneyType);
                        DataRow dr3 = dtBalanceInfoImportInfo.NewRow();
                        dr3[0] = Guid.NewGuid().ToString();
                        dr3[1] = dm.CustomerNumber;
                        dr3[2] = dm.SubAccountNumber;
                        dr3[3] = dm.CurrentBalance;
                        dr3[4] = dm.MoneyType;
                        dr3[5] = "";
                        dr3[6] = dm.ImportTime;
                       

                        dtBalanceInfoImportInfo.Rows.Add(dr3);
                        //cmdtxts.Add(sqlBalanceInfo);
                    //}

                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    }));
                }
                string transferinfo = @" insert into AccountInfo select NEWID(),[AccountID],[AccountName] ,[AccountType],[WebsiteID],[ManagerID]
                 ,[CorrelationState],SubAccountNumber from (select * from AccountInfoImportInfo ai where not  exists (select * from AccountInfo a  where a.AccountID =ai.AccountID and a.SubAccountNumber=ai.SubAccountNumber)) as x";
                cmdtxts.Add(transferinfo);
                cmdtxts.Add("delete from AccountInfoImportInfo");

                string deletesql = @"delete from BalanceInfo  where exists (select * from BalanceInfoImportInfo bii where BalanceInfo.AccountNumber=bii.AccountNumber and BalanceInfo.SubAccountNumber=bii.SubAccountNumber and BalanceInfo.BalanceTime=bii.BalanceTime)";
                cmdtxts.Add(deletesql);
                string insertBalanceInfo = @"insert into BalanceInfo select * from BalanceInfoImportInfo";
                cmdtxts.Add(insertBalanceInfo);
                cmdtxts.Add("delete from BalanceInfoImportInfo");
                List<DataTable> listtable = new List<DataTable>();
                listtable.Add(dtImportData);
                listtable.Add(dtAccountInfoImportInfo);
                listtable.Add(dtBalanceInfoImportInfo);
                if (Common.CommonSql.Instance.ConnectDatabase())
                {
                    if (!Common.CommonSql.Instance.SqlTransactionProcessBar(listtable, cmdtxts))
                    {
                        list = null;
                    }
                    Common.CommonSql.Instance.CloseDatabase();
                }
                return list;
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                App.Current.Dispatcher.Invoke(new Action(delegate()
                {
                    BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                    MW.pro.Visibility = Visibility.Collapsed;
                }));
            }
        }
        public List<ImportDataModel> MonthImportData(string filename, out int uncomplete)
        {
            uncomplete = 0;
            try
            {

                List<ImportDataModel> list = new List<ImportDataModel>();
                List<string> cmdtxts = new List<string>();
                DataTable dt = Common.NPOIHelper.Instance.ImportMonth(filename);
                double jinDu;
                Thread.CurrentThread.Join(1);
                DataTable dtImportData = new DataTable();
                dtImportData.TableName = "ImportData";
                dtImportData.Columns.Add("ID");
                dtImportData.Columns.Add("CustomerNumber");
                dtImportData.Columns.Add("SubAccountNumber");
                dtImportData.Columns.Add("AccountType");
                dtImportData.Columns.Add("AccountName");
                dtImportData.Columns.Add("WebsiteID");
                dtImportData.Columns.Add("CurrentBalance");
                dtImportData.Columns.Add("MoneyType");
                dtImportData.Columns.Add("ImportTime");
                DataTable dtAccountInfoImportInfo = new DataTable();
                dtAccountInfoImportInfo.TableName = "AccountInfoImportInfo";
                dtAccountInfoImportInfo.Columns.Add("ID");
                dtAccountInfoImportInfo.Columns.Add("AccountID");
                dtAccountInfoImportInfo.Columns.Add("AccountName");
                dtAccountInfoImportInfo.Columns.Add("AccountType");
                dtAccountInfoImportInfo.Columns.Add("WebsiteID");
                dtAccountInfoImportInfo.Columns.Add("ManagerID");
                dtAccountInfoImportInfo.Columns.Add("CorrelationState");
                dtAccountInfoImportInfo.Columns.Add("SubAccountNumber");

                DataTable dtBalanceInfoImportInfo = new DataTable();
                dtBalanceInfoImportInfo.TableName = "BalanceInfoImportInfo";
                dtBalanceInfoImportInfo.Columns.Add("ID");
                dtBalanceInfoImportInfo.Columns.Add("AccountNumber");
                dtBalanceInfoImportInfo.Columns.Add("SubAccountNumber");
                dtBalanceInfoImportInfo.Columns.Add("Balance");
                dtBalanceInfoImportInfo.Columns.Add("MoneyType");
                dtBalanceInfoImportInfo.Columns.Add("BalanceState");
                dtBalanceInfoImportInfo.Columns.Add("BalanceTime");
            
                DateTime dtime=DateTime.Parse(CommonData.Instance.ImportTime);
                int days = (dtime.AddMonths(1) - dtime).Days;
                for (int j = 2; j < dt.Rows.Count;j++ )
                {
                    DataRow item = dt.Rows[j];
                    ImportDataModel dm = new ImportDataModel();
                    dm.ID = Guid.NewGuid().ToString();
                  
                    dm.CustomerNumber = item[5].ToString().Trim();
                    dm.SubAccountNumber = item[6].ToString().Trim();
                    dm.AccountType = (item[7].ToString().Trim().Contains("活期") ? "活期" : "定期");
                    dm.AccountName = item[4].ToString().Trim();
                    dm.WebsiteID = item[0].ToString().Trim();
                    //dm.CurrentBalance = item[5].ToString().Trim();
                    dm.MoneyType = "人民币";
                    //}
                    for (int i = 0; i < days; i++)
                    {

                        string timestr = dtime.ToString("yyyy-MM") + "-" + (i + 1).ToString();
                        dm.ImportTime = DateTime.Parse(timestr).ToString("yyyy-MM-dd"); ;// DateTime.Now.ToString("yyyy-MM-dd"); //hh:mm:ss
                        dm.CurrentBalance = item[10 + i].ToString().Trim();

                       

                      
                        DataRow dr1 = dtImportData.NewRow();
                        dr1[0] = Guid.NewGuid().ToString();
                        dr1[1] = dm.CustomerNumber;
                        dr1[2] = dm.SubAccountNumber;
                        dr1[3] = dm.AccountType;
                        dr1[4] = dm.AccountName;
                        dr1[5] = dm.WebsiteID;
                        dr1[6] = dm.CurrentBalance;
                        dr1[7] = dm.MoneyType;
                        dr1[8] = dm.ImportTime;
                        dtImportData.Rows.Add(dr1);
                     
                        DataRow dr2 = dtAccountInfoImportInfo.NewRow();
                        dr2[0] = Guid.NewGuid().ToString();
                        dr2[1] = dm.CustomerNumber;
                        dr2[2] = dm.AccountName;
                        dr2[3] = dm.AccountType;
                        dr2[4] = dm.WebsiteID;
                        dr2[5] = "";
                        dr2[6] = "未关联";
                        dr2[7] = dm.SubAccountNumber;
                        DataRow[] ddr = dtAccountInfoImportInfo.Select("AccountID='" + dm.CustomerNumber + "' and AccountName='" + dm.AccountName + "' and SubAccountNumber='" + dm.SubAccountNumber + "'");
                        if (ddr == null || ddr.Length == 0)
                        {
                            dtAccountInfoImportInfo.Rows.Add(dr2);
                        }
     
                        DataRow dr3 = dtBalanceInfoImportInfo.NewRow();
                        dr3[0] = Guid.NewGuid().ToString();
                        dr3[1] = dm.CustomerNumber;
                        dr3[2] = dm.SubAccountNumber;
                        dr3[3] = dm.CurrentBalance;
                        dr3[4] = dm.MoneyType;
                        dr3[5] = "";
                        dr3[6] = dm.ImportTime;
                      
                        dtBalanceInfoImportInfo.Rows.Add(dr3);
                        //}
                    }
                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    }));
                }
                string transferinfo = @" insert into AccountInfo select NEWID(),[AccountID],[AccountName] ,[AccountType],[WebsiteID],[ManagerID]
                 ,[CorrelationState],SubAccountNumber from (select * from AccountInfoImportInfo ai where not  exists (select * from AccountInfo a  where a.AccountID =ai.AccountID and a.SubAccountNumber=ai.SubAccountNumber)) as x";
                cmdtxts.Add(transferinfo);
                cmdtxts.Add("delete from AccountInfoImportInfo");

                string deletesql = @"delete from BalanceInfo  where exists (select * from BalanceInfoImportInfo bii where BalanceInfo.AccountNumber=bii.AccountNumber and BalanceInfo.SubAccountNumber=bii.SubAccountNumber and BalanceInfo.BalanceTime=bii.BalanceTime)";
                cmdtxts.Add(deletesql);
                string insertBalanceInfo = @"insert into BalanceInfo select * from BalanceInfoImportInfo";
                cmdtxts.Add(insertBalanceInfo);
                cmdtxts.Add("delete from BalanceInfoImportInfo");
                List<DataTable> listtable = new List<DataTable>();
                listtable.Add(dtImportData);
                listtable.Add(dtAccountInfoImportInfo);
                listtable.Add(dtBalanceInfoImportInfo);
                if (Common.CommonSql.Instance.ConnectDatabase())
                {
                    if (!Common.CommonSql.Instance.SqlTransactionProcessBar(listtable,cmdtxts))
                    {
                        list = null;
                    }
                    Common.CommonSql.Instance.CloseDatabase();
                }
                return list;
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                App.Current.Dispatcher.Invoke(new Action(delegate()
                {
                    BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                    MW.pro.Visibility = Visibility.Collapsed;
                }));
            }
        }
        /// <summary>
        /// 提示存在未知网点网点号信息
        /// </summary>
        /// <returns></returns>
        public string  ManagerNotHandleWebsiteInfo(out int result )
        {

            string sql = @"select * from ManagersInfo where WebsiteID not in (select distinct WebsiteID from WebsiteInfo) ";
            DataTable dt = Common.CommonSql.Instance.SelectAll(sql);
        
            List<string> strlist = new List<string>();
            string str="";
                foreach (DataRow item in dt.Rows)
                {
                    ManagersInfoModel um = new ManagersInfoModel();
                    um.ID = Guid.NewGuid().ToString();
                    
                        um.ManagerID = item["ManagerID"].ToString().Trim();
                        um.ManagerName = item["ManagerName"].ToString().Trim();
                        um.WebsiteID = item["WebsiteID"].ToString().Trim();
                        strlist.Add("客户经理号:" + um.ManagerID + "   客户经理名字:" + um.ManagerName + "   所属网点号:" + um.WebsiteID);
                    
                  
                }
                if (strlist.Count > 0)
                {
                    str = "客户经理导入记录" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                    CommonLog.Instance.WriteLog(strlist, str);
                }
                result = dt.Rows.Count;
                return str;
        }
        public List<ManagersInfoModel> ManagersImportData(string filename)
        {
           
            try
            {

                List<ManagersInfoModel> list = new List<ManagersInfoModel>();
                List<string> cmdtxts = new List<string>();
                DataTable dt = Common.NPOIHelper.Instance.Import(filename);
                double jinDu;
                foreach (DataRow item in dt.Rows)
                {
                    ManagersInfoModel um = new ManagersInfoModel();
                    um.ID = Guid.NewGuid().ToString();
                    try
                    {
                        um.ManagerID = item["客户经理号"].ToString().Trim();
                        um.ManagerName = item["客户经理名字"].ToString().Trim();
                        um.ManagerTelphone = item["联系方式"].ToString().Trim();
                        um.ManagerEmail = item["邮箱"].ToString().Trim();
                        um.WebsiteID = item["所属网点号"].ToString().Trim();
                    }
                    catch
                    {
                        um.ManagerID = item[0].ToString().Trim();
                        um.ManagerName = item[1].ToString().Trim();
                        um.ManagerTelphone = item[2].ToString().Trim();
                        um.ManagerEmail = item[3].ToString().Trim();
                        um.WebsiteID = item[4].ToString().Trim();
                        
                    }
                    
                    list.Add(um);


                    string del = string.Format(@"delete from   ManagersInfo where ManagerID='{0}' and ManagerName='{1}'",  um.ManagerID, um.ManagerName);
                    cmdtxts.Add(del);
                    string sql = string.Format(@"insert into  ManagersInfo(ID,ManagerID,ManagerName,WebsiteID,WebsiteName,ManagerTelphone ,ManagerEmail) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", um.ID, um.ManagerID, um.ManagerName, um.WebsiteID, um.WebsiteName, um.ManagerTelphone, um.ManagerEmail);
                    cmdtxts.Add(sql);
                    //AccountInfoModel wim = AccountInfoDao.Instance.SelectObjectAccountID(dm.CustomerNumber);
                    //if (wim.ID == null)
                    //{
                    //    string sqlAccountInfo = string.Format(@"insert into  AccountInfo(ID,AccountID,AccountName,AccountType,WebsiteID,ManagerID ,CorrelationState)  values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", Guid.NewGuid().ToString(), dm.AccountName, dm.CustomerNumber, dm.AccountType, dm.WebsiteID, "", "未关联");
                    //    cmdtxts.Add(sqlAccountInfo);
                    //    uncomplete++;
                    //}
                    //string sqlBalanceInfo = string.Format(@"insert into BalanceInfo(ID,AccountNumber,SubAccountNumber,Balance,BalanceState,BalanceTime,MoneyType) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}') ", Guid.NewGuid().ToString(), dm.CustomerNumber, dm.SubAccountNumber, dm.CurrentBalance, "", dm.ImportTime, dm.MoneyType);
                    //cmdtxts.Add(sqlBalanceInfo);
                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    }));
                }
                if (Common.CommonSql.Instance.ConnectDatabase())
                {
                    if (!Common.CommonSql.Instance.SqlTransactionProcessBar(cmdtxts))
                    {
                        list = null;
                    }
                    Common.CommonSql.Instance.CloseDatabase();
                }
                return list;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }
            finally
            {
                App.Current.Dispatcher.Invoke(new Action(delegate()
                {
                    BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                    MW.pro.Visibility = Visibility.Collapsed;
                }));
            }
        }

        public bool  LinkImportData(string filename)
        {
            bool result = false;
            try
            {

                //List<ManagersInfoModel> list = new List<ManagersInfoModel>();
                List<string> cmdtxts = new List<string>();
                DataTable dt = Common.NPOIHelper.Instance.Import(filename);
                double jinDu;
                foreach (DataRow item in dt.Rows)
                {

                    string CompanyName = item["客户名称"].ToString().Trim();
                    string AccountID = item["账户号"].ToString().Trim();
                    string ManagerID = item["客户经理编号"].ToString().Trim();
                    string DepartmentID = item["部门编号"].ToString().Trim();
                    if (DepartmentID != "" && DepartmentID != "")
                    {
                        string sql = string.Format(@"UPDATE [AccountInfo] SET  [WebsiteID] = '{2}' ,[ManagerID] ='{3}',CorrelationState='已关联'
                     WHERE [AccountID]='{0}' and [AccountName]='{1}' ", AccountID, CompanyName, DepartmentID, ManagerID);
                        cmdtxts.Add(sql);
                    }
                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";
                    }));
                }
                if (Common.CommonSql.Instance.ConnectDatabase())
                {
                    if (!Common.CommonSql.Instance.SqlTransactionProcessBar(cmdtxts))
                    {
                        result = true;
                    }
                    else
                    {
                        result = false;
                    }
                    Common.CommonSql.Instance.CloseDatabase();
                }
                return result;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show(e.Message);
                return result;
            }
            finally
            {
                App.Current.Dispatcher.Invoke(new Action(delegate()
                {
                    BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                    MW.pro.Visibility = Visibility.Collapsed;
                }));
                //return result;
            }
        }
    }
}
