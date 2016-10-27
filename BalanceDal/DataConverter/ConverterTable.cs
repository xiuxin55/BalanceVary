using BalanceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BalanceDAL
{
    public partial  class ConverterTable
    {
        
        /// <summary>
        /// 每个公司变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable CompanyBalanceListConvertTable(List<CompanyBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "CompanyBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("CompanyName");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("ZoneType");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["CompanyName"] = item.CompanyName;
                dr["WebsiteID"] = item.WebsiteID;
                dr["ZoneType"] = item.ZoneType;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        /// 每个公司变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable CompanyBalanceListConvertTableAccount(List<CompanyBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "CompanyBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("AccountID");
            dtBalance.Columns.Add("CompanyName");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("ZoneType");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["AccountID"] = item.AccountID;
                dr["CompanyName"] = item.CompanyName;
                dr["WebsiteID"] = item.WebsiteID;
                dr["ZoneType"] = item.ZoneType;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        /// 账户、户名数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable AccountAndNameLinkInfoListConvertTableAccount(List<AccountAndNameLinkInfo> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "AccountAndNameLink";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("AccountID");
            dtBalance.Columns.Add("CompanyName");
           
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["AccountID"] = item.AccountID;
                dr["CompanyName"] = item.CompanyName;
               
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        /// 每个网点变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable WebsiteBalanceListConvertTable(List<WebsiteBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "WebsiteBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            dtBalance.Columns.Add("ZoneType");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["WebsiteID"] = item.WebsiteID;
                dr["ZoneType"] = item.ZoneType;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }


        /// <summary>
        /// 每个账户变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable AccountBalanceListConvertTable(List<AccountBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "AccountBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("AccountID");
            dtBalance.Columns.Add("SubAccountNumber");
            dtBalance.Columns.Add("AccountName");
            dtBalance.Columns.Add("AccountType");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["AccountID"] = item.AccountID;
                dr["SubAccountNumber"] = item.SubAccountNumber;
                dr["AccountName"] = item.AccountName;
                dr["AccountType"] = item.AccountType;
                dr["WebsiteID"] = item.WebsiteID;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        ///  部门变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable DepartmentBalanceListConvertTable(List<DepartmentBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "DepartmentBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("DepartmentID");
            dtBalance.Columns.Add("DepartmentName");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["DepartmentID"] = item.DepartmentID;
                dr["DepartmentName"] = item.DepartmentName;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        ///  客户经理变化数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable CustomerManagerBalanceListConvertTable(List<CustomerManagerBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "CustomerManagerBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("DepartmentID");
            dtBalance.Columns.Add("DepartmentName");
            dtBalance.Columns.Add("ManagerID");
            dtBalance.Columns.Add("ManagerName");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["DepartmentID"] = item.DepartmentID;
                dr["DepartmentName"] = item.DepartmentName;
                dr["ManagerID"] = item.ManagerID;
                dr["ManagerName"] = item.ManagerName;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
        /// <summary>
        ///  客户经理关联数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable AccountLinkListConvertTable(List<AccountLinkManagerInfo> list)
        {
            DataTable dt = new DataTable();
            dt.TableName = "AccountLinkManagerInfo";
            dt.Columns.Add("ID");
            dt.Columns.Add("ManagerID");
            dt.Columns.Add("ManagerName");
            dt.Columns.Add("DepartmentID");
            dt.Columns.Add("DepartmentName");
           
            dt.Columns.Add("AccountID");
            dt.Columns.Add("SubAccountNumber");
           
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                dr["ID"] = item.ID;
                dr["DepartmentID"] = item.DepartmentID;
                dr["DepartmentName"] = item.DepartmentName;
                dr["ManagerID"] = item.ManagerID;
                dr["ManagerName"] = item.ManagerName;
                dr["AccountID"] = item.AccountID ;
                dr["SubAccountNumber"] = item.SubAccountNumber;
               
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
    /// <summary>
    /// 薪资使用的转换
    /// </summary>
    public partial class ConverterTable
    {
        /// <summary>
        ///  薪资数据转换为DataTable
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static DataTable SalaryInfoListConvertTable(List<SalaryInfo> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "SalaryInfo";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("StaffCode");
            dtBalance.Columns.Add("StaffName");
            dtBalance.Columns.Add("JobSalary");
            dtBalance.Columns.Add("ProfessionAllowance");
            dtBalance.Columns.Add("YearCreditAllowance");
            dtBalance.Columns.Add("RetainsSalary");
            dtBalance.Columns.Add("SynthesizeAllowance");
            dtBalance.Columns.Add("ExpiredAllowance");
            dtBalance.Columns.Add("HouseAllowance");
            dtBalance.Columns.Add("ShouldSalary");
            dtBalance.Columns.Add("HouseFund");
            dtBalance.Columns.Add("PensionMoney");
            dtBalance.Columns.Add("UnionMoney");
            dtBalance.Columns.Add("HealthInsuranceMoney");
            dtBalance.Columns.Add("LossJobMoney");
            dtBalance.Columns.Add("BigDiseaseInsuranceMoney");
            dtBalance.Columns.Add("YearMoney");
            dtBalance.Columns.Add("TaxDeductable");
            dtBalance.Columns.Add("ChargebacksAmount");
            dtBalance.Columns.Add("RealSalary");
            dtBalance.Columns.Add("ShouldPerformance");
            dtBalance.Columns.Add("Reward");
            dtBalance.Columns.Add("Appraisals");
            dtBalance.Columns.Add("BucklupLastMonth");
            dtBalance.Columns.Add("Tax");
            dtBalance.Columns.Add("RiskMoney");
            dtBalance.Columns.Add("RealPerformance");
            dtBalance.Columns.Add("RealAmount");
            dtBalance.Columns.Add("Remark");
            dtBalance.Columns.Add("SalaryTime");
           
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["StaffCode"] = item.StaffCode;
                dr["StaffName"] = item.StaffName;
                dr["JobSalary"] = item.JobSalary;
                dr["ProfessionAllowance"] = item.ProfessionAllowance;
                dr["YearCreditAllowance"] = item.YearCreditAllowance;
                dr["RetainsSalary"] = item.RetainsSalary;
                dr["SynthesizeAllowance"] = item.SynthesizeAllowance;
                dr["ExpiredAllowance"] = item.ExpiredAllowance;
                dr["HouseAllowance"] = item.HouseAllowance;
                dr["ShouldSalary"] = item.ShouldSalary;
                dr["HouseFund"] = item.HouseFund;
                dr["PensionMoney"] = item.PensionMoney;
                dr["UnionMoney"] = item.UnionMoney;
                dr["HealthInsuranceMoney"] = item.HealthInsuranceMoney;
                dr["LossJobMoney"] = item.LossJobMoney;
                dr["BigDiseaseInsuranceMoney"] = item.BigDiseaseInsuranceMoney;
                dr["YearMoney"] = item.YearMoney;
                dr["TaxDeductable"] = item.TaxDeductable;
                dr["ChargebacksAmount"] = item.ChargebacksAmount;
                dr["RealSalary"] = item.RealSalary;
                dr["ShouldPerformance"] = item.ShouldPerformance;
                dr["Reward"] = item.Reward;
                dr["Appraisals"] = item.Appraisals;
                dr["BucklupLastMonth"] = item.BucklupLastMonth;
                dr["Tax"] = item.Tax;
                dr["RiskMoney"] = item.RiskMoney;
                dr["RealPerformance"] = item.RealPerformance;
                dr["RealAmount"] = item.RealAmount;
                dr["Remark"] = item.Remark;
                dr["SalaryTime"] = item.SalaryTime;
                
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
    }
}
