using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class ReadExcel
    {
        
        public static List<ImportDataInfo> ReadDayData(string filename, DateTime dtime)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return ImportDayData(fi.FullName,  dtime);
            }
            return null;
        }
        public static List<AccountLinkManagerInfo> ReadCustomerLinkData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return ImportCustomerLinkData(fi.FullName);
            }
            return null;
        }

        public static List<ImportDataInfo> ReadMonthData(string filename, DateTime dtime)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return ImportMonthData(fi.FullName,  dtime);
            }
            return null;
        }
        public static List<WebsiteInfo> ReadWebisteData()
        {
            if (Directory.Exists(CommonDataServer.UploadFileServerPath))
            {
                string[] files = Directory.GetFiles(CommonDataServer.UploadFileServerPath);

            }
            return null;
        }

        public static List<CustomerManagerInfo> ReadCustomerManagerData()
        {
            if (Directory.Exists(CommonDataServer.UploadFileServerPath))
            {
                string[] files = Directory.GetFiles(CommonDataServer.UploadFileServerPath);

            }
            return null;
        }

        public static List<CustomerManagerInfo> ReadTeamData()
        {
            if (Directory.Exists(CommonDataServer.UploadFileServerPath))
            {
                string[] files = Directory.GetFiles(CommonDataServer.UploadFileServerPath);
            }
            return null;
        }

        public static List<ImportDataInfo> ImportDayData(string filename,DateTime dtime)
        {
            try
            {

                List<ImportDataInfo> list = new List<ImportDataInfo>();
                DataTable dt = NPOIHelper.Instance.Import(filename);
                foreach (DataRow item in dt.Rows)
                {
                    ImportDataInfo dm = new ImportDataInfo();
                    dm.ID = Guid.NewGuid().ToString();
                    dm.DataTime = dtime;
                    try
                    {
                        dm.AccountID = item["客户账号"].ToString().Trim();
                        dm.SubAccountNumber = item["子账号"].ToString().Trim();
                        dm.AccountType = item["定活标志"].ToString().Trim().Contains("活期") ? 1 : 0;
                        dm.AccountName = item["账户名称"].ToString().Trim();
                        dm.WebsiteID = item["开户机构"].ToString().Trim();
                        dm.CurrentBalance =decimal.Parse(item["当前余额"].ToString().Trim());
                        dm.MoneyType = item["币种"].ToString().Trim();
                        list.Add(dm);
                    }
                    catch
                    {
                        dm.AccountID = item[0].ToString().Trim();
                        dm.SubAccountNumber = item[1].ToString().Trim();
                        dm.AccountType = item[2].ToString().Trim().Contains("活期") ? 1 : 0;
                        dm.AccountName = item[3].ToString().Trim();
                        dm.WebsiteID = item[4].ToString().Trim();
                        dm.CurrentBalance = decimal.Parse(item[5].ToString().Trim());
                        dm.MoneyType = item[6].ToString().Trim();
                        list.Add(dm);
                    }
                }
                return list;
            }
            catch (Exception e)
            {

                System.Windows.Forms.MessageBox.Show(e.Message);
                return null;
            }

        }
        public static List<ImportDataInfo> ImportMonthData(string filename, DateTime dtime)
        {
            try
            {
                List<ImportDataInfo> list = new List<ImportDataInfo>();
                DataTable dt = NPOIHelper.Instance.ImportMonth(filename);
                int days = (dtime.AddMonths(1) - dtime).Days;
                for (int j = 2; j < dt.Rows.Count; j++)
                {
                    DataRow item = dt.Rows[j];
                    if (string.IsNullOrWhiteSpace(item[0].ToString()))
                    {
                        continue;
                    }
                    for (int i = 0; i < days; i++)
                    {
                        ImportDataInfo dm = new ImportDataInfo();
                        dm.ID = Guid.NewGuid().ToString();
                        dm.WebsiteID = item[0].ToString().Trim();
                        dm.CustomerNumber = item[3].ToString().Trim();
                        dm.AccountName = item[2].ToString().Trim();
                        dm.AccountID = item[5].ToString().Trim();
                        dm.SubAccountNumber = item[6].ToString().Trim();
                        dm.AccountType = item[7].ToString().Trim().Contains("活期") ? 1 : 0;
                        dm.MoneyType = "人民币";
                        string timestr = dtime.ToString("yyyy-MM") + "-" + (i + 1).ToString();
                        dm.DataTime = DateTime.Parse(timestr);
                        dm.CurrentBalance =decimal.Parse(item[10 + i].ToString().Trim());
                        list.Add(dm);
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
               
        }


        public static List<AccountLinkManagerInfo> ImportCustomerLinkData(string filename)
        {
            try
            {
                List<AccountLinkManagerInfo> list = new List<AccountLinkManagerInfo>();
                DataTable dt = NPOIHelper.Instance.ImportAccountLink(filename);
                for (int j = 1; j < dt.Rows.Count; j++)
                {
                    DataRow item = dt.Rows[j];
                    if (string.IsNullOrWhiteSpace(item[0].ToString()))
                    {
                        continue;
                    }          
                    AccountLinkManagerInfo am = new AccountLinkManagerInfo();
                    am.ID = Guid.NewGuid().ToString();
                    am.AccountID = item["账户号"].ToString().Trim();
                    am.ManagerName = item["客户经理"].ToString().Trim();
           
                    // am.SubAccountNumber = item["子账号"].ToString().Trim();
                    // am.DepartmentID = item["部门编号"].ToString();
                    // am.ManagerID  = item["客户经理编号"].ToString();
                    am.DepartmentName = item["所属部门"].ToString();
                    list.Add(am);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

    }
}
