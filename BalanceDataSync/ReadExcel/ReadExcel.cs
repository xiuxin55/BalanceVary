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
                DataTable dt = NPOIHelper.Instance.ImportSalary(filename);
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
                    am.StaffCode = item["人员编码"] != null ? item["人员编码"].ToString().Trim() : "";
                    am.StaffName = item["人员姓名"] != null ? item["人员姓名"].ToString().Trim() : "";
                    am.JobSalary = item["岗位工资"] != null ? item["岗位工资"].ToString().Trim() : "0";
                    am.ProfessionAllowance = item["专业技术职务津贴"] != null ? item["专业技术职务津贴"].ToString().Trim() : "0";
                    am.YearCreditAllowance = item["保留年功津贴"] != null ? item["保留年功津贴"].ToString().Trim() : "0";
                    am.RetainsSalary = item["保留工资"] != null ? item["保留工资"].ToString().Trim() : "0";
                    am.SynthesizeAllowance = item["综合补贴"] != null ? item["综合补贴"].ToString().Trim() : "0";
                    am.ExpiredAllowance = item["过渡期补贴"] != null ? item["过渡期补贴"].ToString().Trim() : "0";
                    am.HouseAllowance = item["住房补贴"] != null ? item["住房补贴"].ToString().Trim() : "0";
                    am.ShouldSalary = item["应发工资"] != null ? item["应发工资"].ToString().Trim() : "0";
                    am.HouseFund = item["住房公积金实缴额(个人合计)"] != null ? item["住房公积金实缴额(个人合计)"].ToString().Trim() : "0";
                    am.PensionMoney = item["养老保险实缴额(个人)"] != null ? item["养老保险实缴额(个人)"].ToString().Trim() : "0";
                    am.UnionMoney = item["工会费"] != null ? item["工会费"].ToString().Trim() : "0";
                    am.HealthInsuranceMoney = item["医疗保险实缴额(个人)"] != null ? item["医疗保险实缴额(个人)"].ToString().Trim() : "0";
                    am.LossJobMoney = item["失业保险实缴额(个人)"] != null ? item["失业保险实缴额(个人)"].ToString().Trim() : "0";
                    am.BigDiseaseInsuranceMoney = item["大病医疗保险实缴额(个人)"] != null ? item["大病医疗保险实缴额(个人)"].ToString().Trim() : "0";
                    am.YearMoney = item["年金"] != null ? item["年金"].ToString().Trim() : "0";
                    am.TaxDeductable = item["扣款自定义项1(抵税)"] != null ? item["扣款自定义项1(抵税)"].ToString().Trim() : "0";
                    am.ChargebacksAmount = item["扣款合计"] != null ? item["扣款合计"].ToString().Trim() : "0";
                    am.RealSalary = item["实发工资"] != null ? item["实发工资"].ToString().Trim() : "0";
                    am.ShouldPerformance = item["应发绩效"] != null ? item["应发绩效"].ToString().Trim() : "0";
                    am.Reward = item["奖励"] != null ? item["奖励"].ToString().Trim() : "0";
                    am.Appraisals = item["考核"] != null ? item["考核"].ToString().Trim() : "0";
                    am.OvertimePay = item["加班费"] != null ? item["加班费"].ToString().Trim() : "0";
                    am.OtherIncome = item["其他收入"] != null ? item["其他收入"].ToString().Trim() : "0";
                    am.BucklupLastMonth = item["补扣上月"] != null ? item["补扣上月"].ToString().Trim() : "0";
                    am.Tax = item["税收"] != null ? item["税收"].ToString().Trim() : "0";
                    am.RiskMoney = item["风险金"] != null ? item["风险金"].ToString().Trim() : "0";
                    am.RealPerformance = item["实发绩效"] != null ? item["实发绩效"].ToString().Trim() : "0";
                    am.RealAmount = item["实发合计"] != null ? item["实发合计"].ToString().Trim() : "0";
                    am.Remark = item["备注说明"] != null ? item["备注说明"].ToString().Trim() : "0";
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
