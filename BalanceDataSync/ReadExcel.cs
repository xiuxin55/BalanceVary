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
        public static List<AccountAndNameLinkInfo> ReadAccountAndNameData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return AccountAndNameLinkData(fi.FullName);
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
                for (int j = 1; j < dt.Rows.Count; j++)
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

        public static List<AccountAndNameLinkInfo> AccountAndNameLinkData(string filename)
        {
            try
            {
                List<AccountAndNameLinkInfo> list = new List<AccountAndNameLinkInfo>();
                DataTable dt = NPOIHelper.Instance.ImportAccountLink(filename);
      
                if (! dt.Columns.Contains("账户号"))
                {
                    dt = NPOIHelper.Instance.ImportMonth(filename);
                }
                List<string> accountids = new List<string>();
                for (int j = 1; j < dt.Rows.Count; j++)
                {
                    DataRow item = dt.Rows[j];
                    if (string.IsNullOrWhiteSpace(item[0].ToString()))
                    {
                        continue;
                    }
                    if (!accountids.Contains(item["账户号"].ToString().Trim()))
                    {

                        accountids.Add(item["账户号"].ToString().Trim());
                        AccountAndNameLinkInfo am = new AccountAndNameLinkInfo();
                        am.ID = Guid.NewGuid().ToString();
                        am.AccountID = item["账户号"].ToString().Trim();
                        am.CompanyName = item["客户名称"].ToString().Trim();
                        list.Add(am);
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<SalaryInfo> ReadSalaryInfoData(string filename,DateTime? salarytime)
        {
            try
            {
                List<SalaryInfo> list = new List<SalaryInfo>();
                DataTable dt = NPOIHelper.Instance.ImportAccountLink(filename);
                bool ishas = true ;
                if (!dt.Columns.Contains("人员编码"))
                {
                    ishas = false;
                    dt = NPOIHelper.Instance.ImportMonth(filename);
                }
                for (int j = ishas?0:1; j < dt.Rows.Count; j++)
                {
                    DataRow item = dt.Rows[j];
                    if (string.IsNullOrWhiteSpace(item[0].ToString()))
                    {
                        continue;
                    }
                    SalaryInfo am = new SalaryInfo();
                    am.ID = Guid.NewGuid().ToString();
                    am.StaffCode = item[0]!=null? item[0].ToString().Trim():"";
                    am.StaffName = item[1] != null ? item[1].ToString().Trim() : "";
                    am.JobSalary = item[2] != null ? item[2].ToString().Trim() : "0";
                    am.ProfessionAllowance = item[3] != null ? item[3].ToString().Trim() : "0";
                    am.YearCreditAllowance = item[4] != null ? item[4].ToString().Trim() : "0";
                    am.RetainsSalary = item[5] != null ? item[5].ToString().Trim() : "0";
                    am.SynthesizeAllowance = item[6] != null ? item[6].ToString().Trim() : "0";
                    am.ExpiredAllowance = item[7] != null ? item[7].ToString().Trim() : "0";
                    am.HouseAllowance = item[8] != null ? item[8].ToString().Trim() : "0";
                    am.ShouldSalary = item[9] != null ? item[9].ToString().Trim() : "0";
                    am.HouseFund = item[10] != null ? item[10].ToString().Trim() : "0";
                    am.PensionMoney = item[11] != null ? item[11].ToString().Trim() : "0";
                    am.UnionMoney = item[12] != null ? item[12].ToString().Trim() : "0";
                    am.HealthInsuranceMoney = item[13] != null ? item[13].ToString().Trim() : "0";
                    am.LossJobMoney = item[14] != null ? item[14].ToString().Trim() : "0";
                    am.BigDiseaseInsuranceMoney = item[15] != null ? item[15].ToString().Trim() : "0";
                    am.YearMoney = item[16] != null ? item[16].ToString().Trim() : "0";
                    am.TaxDeductable = item[17] != null ? item[17].ToString().Trim() : "0";
                    am.ChargebacksAmount = item[18] != null ? item[18].ToString().Trim() : "0";
                    am.RealSalary = item[19] != null ? item[19].ToString().Trim() : "0";
                    am.ShouldPerformance = item[20] != null ? item[20].ToString().Trim() : "0";
                    am.Reward = item[21] != null ? item[21].ToString().Trim() : "0";
                    am.Appraisals = item[22] != null ? item[22].ToString().Trim() : "0";
                    am.BucklupLastMonth = item[23] != null ? item[23].ToString().Trim() : "0";
                    am.Tax = item[24] != null ? item[24].ToString().Trim() : "0";
                    am.RiskMoney = item[25] != null ? item[25].ToString().Trim() : "0";
                    am.RealPerformance = item[26] != null ? item[26].ToString().Trim() : "0";
                    am.RealAmount = item[27] != null ? item[27].ToString().Trim() : "0";
                    am.Remark = item[28] != null ? item[28].ToString().Trim() : "0";
                    am.SalaryTime = salarytime;
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
