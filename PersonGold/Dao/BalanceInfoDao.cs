using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceReport.Common;
using System.Data;
using System.Collections.ObjectModel;

namespace BalanceReport.Dao
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

         /// <summary>
        /// 查询活期比
        /// </summary>
        /// <returns></returns>
        public List<string> GetAlreadyImportTime(string time)
        {
            string sql = string.Format(@"select distinct BalanceTime
                           from dbo.BalanceInfo where  BalanceTime like '{0}%'", time);
            List<string> list = new List<string>();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    list.Add(item["BalanceTime"].ToString());
                }
                CommonSql.Instance.CloseDatabase();

            }
            return list;
        }
        //public List<BalanceSrv.BalanceVaryModel> GetBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        //{
        //    BalanceSrv.BalanceSrv BalanceSrvClient = new BalanceSrv.BalanceSrv();
        //    BalanceSrvClient.Url = Common.CommonData.Instance.WebUrlStr.Trim() + BalanceSrvClient.Url.Substring(BalanceSrvClient.Url.LastIndexOf('/'));

        //    List<BalanceSrv.BalanceVaryModel> InfoList = BalanceSrvClient.GetBalanceVary(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0).ToList<BalanceSrv.BalanceVaryModel>();
        //    List<BalanceSrv.BalanceVaryModel> temp = (from i in InfoList where i.DifferWebsite != "公司" && i.DifferWebsite != "网点" select i).ToList<BalanceSrv.BalanceVaryModel>();

        //    return temp;
        //}

        //public List<BalanceSrv.BalanceVaryModel> GetCompanyBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        //{
        //    BalanceSrv.BalanceSrv BalanceSrvClient = new BalanceSrv.BalanceSrv();
        //    BalanceSrvClient.Url = Common.CommonData.Instance.WebUrlStr.Trim() + BalanceSrvClient.Url.Substring(BalanceSrvClient.Url.LastIndexOf('/'));

        //    List<BalanceSrv.BalanceVaryModel> InfoList = BalanceSrvClient.GetBalanceVary(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0).ToList<BalanceSrv.BalanceVaryModel>();
        //    List<BalanceSrv.BalanceVaryModel> temp = (from i in InfoList where i.DifferWebsite == "公司"  select i).ToList<BalanceSrv.BalanceVaryModel>();

        //    return temp;
        //}
        //public List<BalanceSrv.BalanceVaryModel> GetWebsiteBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        //{
        //    BalanceSrv.BalanceSrv BalanceSrvClient = new BalanceSrv.BalanceSrv();
        //    BalanceSrvClient.Url = Common.CommonData.Instance.WebUrlStr.Trim() + BalanceSrvClient.Url.Substring(BalanceSrvClient.Url.LastIndexOf('/'));

        //    List<BalanceSrv.BalanceVaryModel> InfoList = BalanceSrvClient.GetBalanceVary(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0).ToList<BalanceSrv.BalanceVaryModel>();
        //    List<BalanceSrv.BalanceVaryModel> temp = (from i in InfoList where  i.DifferWebsite == "网点" select i).ToList<BalanceSrv.BalanceVaryModel>();

        //    return temp;
        //}

        //public ObservableCollection<BalanceVaryModel> GetBalanceVaryModelConverter(List<BalanceSrv.BalanceVaryModel> InfoList)
        //{

        //    List<BalanceVaryModel> temp = new List<BalanceVaryModel>();
        //    foreach (BalanceSrv.BalanceVaryModel item in InfoList)
        //    {
        //        BalanceVaryModel newmodel = new BalanceVaryModel();
        //        newmodel.ID = item.ID;
        //        newmodel.Name = item.Name;
        //        newmodel.DifferWebsite = item.DifferWebsite;
        //        newmodel.RegularMoney = item.RegularMoney;
        //        newmodel.UnRegularMoney = item.UnRegularMoney;
        //        newmodel.AmountMoney = item.AmountMoney;
        //        newmodel.WebsiteID = item.WebsiteID;
        //        newmodel.WebsiteAddress = item.WebsiteAddress;
        //        newmodel.WebsiteManager = item.WebsiteManager;
        //        newmodel.WebsiteTel = item.WebsiteTel;
        //        newmodel.BalanceTime = item.BalanceTime;
        //        newmodel.ParentID = item.ParentID;
        //        temp.Add(newmodel);
        //    }
        //    temp.Sort();
        //    return new ObservableCollection<BalanceVaryModel>(temp);
        //}
        public List<BalanceVaryModel> GetBalanceVaryFromDate(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        {
              
            

            List<BalanceVaryModel> InfoList = new List<BalanceVaryModel>();
                InfoList =GetBalanceVarysql(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0);
            return InfoList;
        }
        private List<BalanceVaryModel> GetBalanceVarysql(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
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
            List<BalanceVaryModel> BVMList = new List<BalanceVaryModel>();
            BVMList = ExcecuteBalanceVaryModel(sql, strwhere);// new List<BalanceVaryModel>();

            return BVMList;
        }
        private  List<BalanceVaryModel> ExcecuteBalanceVaryModel(string sql, string strwhere)
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
        public void ExportBalanceVary(List<BalanceVaryModel> list, string filename)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("网点名");
            dt.Columns.Add("客户账号");
            dt.Columns.Add("子账号");
            dt.Columns.Add("账户名称");
            dt.Columns.Add("活期变动");
            dt.Columns.Add("定期变动");
            dt.Columns.Add("日期");
            foreach (BalanceVaryModel item in list)
            {
            
                DataRow dr = dt.NewRow();
                dr[0] = item.WebsiteName ;
                dr[1] = item.Name;
                dr[2] = item.DifferWebsite;
                dr[3] = item.WebsiteID;
                dr[4] = item.UnRegularMoney;
                dr[5] = item.RegularMoney;
                dr[6] = item.BalanceTime;
                dt.Rows.Add(dr);
            }
            NPOIHelper.Instance.Export(dt, "余额变动情况表", filename);
        }
        /// <summary>
        /// 根据部门查询
        /// </summary>
        /// <param name="starttime"></param>
        /// <param name="endtime"></param>
        /// <param name="Insitusation"></param>
        /// <param name="WebsiteName">部门名称</param>
        /// <param name="Company"></param>
        /// <param name="Account"></param>
        /// <param name="Displaystate"></param>
        /// <param name="except0"></param>
        /// <returns></returns>
        public List<BalanceVaryModel> GetDepartmentBalanceVaryFromDate(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        {



            List<BalanceVaryModel> InfoList = new List<BalanceVaryModel>();
            string strwhere2, strwhere1 = string.Format(@" where  BalanceTime>='{0}' and BalanceTime<='{1}'  ", starttime, endtime);
            strwhere2 = strwhere1;
            if (!string.IsNullOrEmpty(WebsiteName))
            {

                strwhere2 = strwhere1 + string.Format(@" and Name like '%{0}%'  ", WebsiteName);
            }

            InfoList = ExcecuteBalanceDepartmentVaryModel(strwhere1, strwhere2);
            return InfoList;
        }
        /// <summary>
        /// 根据部门删选
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="strwhere"></param>
        /// <returns></returns>
        private List<BalanceVaryModel> ExcecuteBalanceDepartmentVaryModel(string strwhere1, string strwhere2)
        {
            List<BalanceVaryModel> list = new List<BalanceVaryModel>();

            string sql = string.Format(@"select * from dbo.View_DepartmentAccountBalance   {0} 
                                        union all select * from dbo.View_DepartmentBalance  {1} ", strwhere1, strwhere2);
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
                CommonSql.Instance.CloseDatabase();
            }
            return list;
        }
    }
}
