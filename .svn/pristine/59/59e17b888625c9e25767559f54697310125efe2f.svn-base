using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using BalanceReportDao.Common;
using BalanceReportModel;
using BalanceReportDao.Dao;

namespace JqGridDemoWebForm
{
    /// <summary>
    /// BalanceSrv 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消对下行的注释。
    // [System.Web.Script.Services.ScriptService]
    public class BalanceSrv : System.Web.Services.WebService
    {
        /// <summary>
        /// 获取余额变动
        /// </summary>
        /// <param name="starttime">开始日期</param>
        /// <param name="endtime">结束日期</param>
        /// <param name="Insitusation">机构名称  县和市</param>
        /// <param name="WebsiteName">网点名</param>
        /// <param name="Company">公司名</param>
        /// <param name="Account">账号</param>
        /// <returns></returns>
        [WebMethod]
        public List<BalanceVaryModel> GetBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate,string except0)
        {
          
            if (Company == null) { Company = ""; }
            if (Account == null) { Account = ""; }
            if (Insitusation == "0") { Insitusation = "市行"; }
            else { { Insitusation = "县行"; } }
            string strwhere = string.Format(@" where Institution='{0}' and BalanceTime>='{1}' and BalanceTime<='{2}' ",
                                          Insitusation, starttime, endtime);
            string sql = "";
            if (!string.IsNullOrEmpty(WebsiteName))
            {
                WebsiteName = HttpUtility.UrlDecode(WebsiteName);
                sql = string.Format(@"select * from dbo.View_WebsiteEverydayBalance {0} and Name like '%{1}%'
                                         union select * from dbo.View_CompanyEverydayBalance {0} ",
                                            strwhere, WebsiteName);
            }
            else
            {
                sql = string.Format(@"select * from dbo.View_WebsiteEverydayBalance {0} 
                                         union select * from dbo.View_CompanyEverydayBalance {0} ",
                                            strwhere);
            }
            CommonSql.Instance.ConnetionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            List<BalanceVaryModel> BVMList = BalanceInfoDao.Instance.ExcecuteBalanceVaryModel(sql, strwhere);// new List<BalanceVaryModel>();
            List<BalanceVaryModel> WebsiteList = (from i in BVMList where i.ParentID == "" || i.ParentID == null select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> CompanyList = (from i in BVMList where i.ParentID != "" && i.Name.Contains(Company) && i.DifferWebsite == "公司" select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> AccountList = (from i in BVMList where i.ParentID != "" && i.Name.Contains(Account) && i.WebsiteID.Contains(Company) && i.DifferWebsite != "公司" && i.DifferWebsite != "网点" select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> InfoList = new List<BalanceVaryModel>();
            List<BalanceVaryModel> InfoListCompany = new List<BalanceVaryModel>();
            foreach (BalanceVaryModel item in AccountList)
            {
                InfoList.Add(item);
                foreach (BalanceVaryModel item2 in CompanyList)
                {
                    if (item.ParentID == item2.ID && InfoList.Contains(item2) == false)
                    {
                        InfoList.Add(item2);
                        InfoListCompany.Add(item2);
                    }
                }

            }
            foreach (BalanceVaryModel item in InfoListCompany)
            {

                foreach (BalanceVaryModel item2 in WebsiteList)
                {
                    if (item.ParentID == item2.ID && InfoList.Contains(item2) == false)
                    {
                        InfoList.Add(item2);

                    }
                }
            }

            DateTime start = DateTime.Parse(starttime);
            DateTime end = DateTime.Parse(endtime);
            switch (Displaystate)
            {
                case "0": break;
                case "1":
                    while (start != end)
                    {
                        foreach (BalanceVaryModel item in InfoList)
                        {
                            if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                            {
                                List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == end.AddDays(-1).ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                                if (R.Count > 0)
                                {
                                    string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                    if (item.RegularMoney == "" || item.RegularMoney == null)
                                    {
                                        afterRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterRegularMoney = item.RegularMoney;
                                    }
                                    if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                    {
                                        afterUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterUnRegularMoney = item.UnRegularMoney;
                                    }
                                    if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                    {
                                        beforeRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeRegularMoney = R[0].RegularMoney;
                                    }
                                    if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                    {
                                        beforeUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeUnRegularMoney = R[0].UnRegularMoney;
                                    }
                                    if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                    {
                                        item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                    }
                                    if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null  && R[0].UnRegularMoney != null )
                                    {
                                        item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                    }
                                    if (item.AmountMoney != "")
                                    {
                                        item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                    }
                                }
                                else
                                {

                                    if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                                    if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                                    if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                                }
                            }
                        }
                        end = end.AddDays(-1);
                    }
                    foreach (BalanceVaryModel item in InfoList)
                    {
                        if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                        {
                            if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                            if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                            if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                        }
                    }
                    break;
                case "2":
                    List<BalanceVaryModel> temp = (from i in InfoList where (i.BalanceTime == end.ToString("yyyy-MM-dd") || i.BalanceTime == start.ToString("yyyy-MM-dd")) select i).ToList<BalanceVaryModel>();
                    InfoList = temp;
                    //while (start != end)
                    //{
                        foreach (BalanceVaryModel item in InfoList)
                        {
                            if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                            {
                                List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == start.ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                                if (R.Count > 0)
                                {
                                    string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                    if (item.RegularMoney == "" || item.RegularMoney == null)
                                    {
                                        afterRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterRegularMoney = item.RegularMoney;
                                    }
                                    if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                    {
                                        afterUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterUnRegularMoney = item.UnRegularMoney;
                                    }
                                    if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                    {
                                        beforeRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeRegularMoney = R[0].RegularMoney;
                                    }
                                    if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                    {
                                        beforeUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeUnRegularMoney = R[0].UnRegularMoney;
                                    }
                                    if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                    {
                                        item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                    }
                                    if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null && R[0].UnRegularMoney != null)
                                    {
                                        item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                    }
                                    if (item.AmountMoney != "")
                                    {
                                        item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                    }
                                }
                            }
                           
                        //}
                        //end = end.AddDays(-1);
                    }
                        foreach (BalanceVaryModel item in InfoList)
                        {
                            if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                            {
                                if(item.RegularMoney !=""){item.RegularMoney ="0";}
                                if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                                if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                            }
                        }
                    break;
            }
            InfoList.Sort();
            if (except0 == "1")
            {
                List<BalanceVaryModel> finallyResult = new List<BalanceVaryModel>();
                foreach (BalanceVaryModel item in InfoList)
                {
                    if (item.RegularMoney == "0" || item.UnRegularMoney == "0")
                    {
                        ;
                    }
                    else
                    {
                        finallyResult.Add(item);
                    }
                }
                InfoList = finallyResult;
            }
            return InfoList;
        }
        [WebMethod]
        public List<BalanceVaryModel> GetBalanceVaryFromDate(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        {

            if (Company == null) { Company = ""; }
            if (Account == null) { Account = ""; }
            if (Insitusation == "0") { Insitusation = "市行"; }
            else { { Insitusation = "县行"; } }
            string strwhere = string.Format(@" where Institution='{0}' and BalanceTime>='{1}' and BalanceTime<='{2}' ",
                                          Insitusation, starttime, endtime);
            string sql = "";
            if (!string.IsNullOrEmpty(WebsiteName))
            {
                WebsiteName = HttpUtility.UrlDecode(WebsiteName);
                sql = string.Format(@"select * from dbo.View_WebsiteEverydayBalance {0} and Name like '%{1}%'
                                         union select * from dbo.View_CompanyEverydayBalance {0} ",
                                            strwhere, WebsiteName);
            }
            else
            {
                sql = string.Format(@"select * from dbo.View_WebsiteEverydayBalance {0} 
                                         union select * from dbo.View_CompanyEverydayBalance {0} ",
                                            strwhere);
            }
            CommonSql.Instance.ConnetionStr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString();
            List<BalanceVaryModel> BVMList = BalanceInfoDao.Instance.ExcecuteBalanceVaryModel(sql, strwhere);// new List<BalanceVaryModel>();

            return BVMList;
        }
    }
}
