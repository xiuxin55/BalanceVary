using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.ObjectModel;
using BalanceReportModel.Models;
using BalanceReportDao.Common;

namespace BalanceReportDao.Dao
{
    public class WebsiteInfoDao
    {
        private static WebsiteInfoDao _instance;

        public static WebsiteInfoDao Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new WebsiteInfoDao();
                }
                return WebsiteInfoDao._instance; }
           
        }
        
        /// <summary>
        /// 所有网点
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<WebsiteInfoModel> GetWebsite()
        {
            string sql = @"select * from WebsiteInfo ";
            ObservableCollection<WebsiteInfoModel> list = new ObservableCollection<WebsiteInfoModel>();
             if (CommonSql.Instance.ConnectDatabase())
             {
                DataTable dt= CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    WebsiteInfoModel um = new WebsiteInfoModel();
                    um.ID =item["ID"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteManager = item["WebsiteManager"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.Institution = item["Institution"].ToString();
     
                    list.Add(um);
                }
                CommonSql.Instance.CloseDatabase();

             }
             return list;
        }
        /// <summary>
        /// model 查询
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<WebsiteInfoModel> GetWebsiteFromObject(WebsiteInfoModel model)
        {
            
            string sql = @"select * from WebsiteInfo where 1=1";
            if (!string.IsNullOrEmpty(model.WebsiteID))
            {
                sql = sql + " and WebsiteID ='" + model.WebsiteID + "'";
            }

            if (!string.IsNullOrEmpty(model.WebsiteName))
            {
                sql = sql + " and WebsiteName ='" + model.WebsiteName + "'";
            }
            ObservableCollection<WebsiteInfoModel> list = new ObservableCollection<WebsiteInfoModel>();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    WebsiteInfoModel um = new WebsiteInfoModel();
                    um.ID = item["ID"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteManager = item["WebsiteManager"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.Institution = item["Institution"].ToString();

                    list.Add(um);
                }
                CommonSql.Instance.CloseDatabase();

            }
            return list;
        }
        /// <summary>
        /// 根据id查询
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public WebsiteInfoModel SelectObject(string id)
        {
            string sql = string.Format(@"select * from WebsiteInfo where ID='{0}'  ", id);
            WebsiteInfoModel um = new WebsiteInfoModel();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectObject(sql);
                foreach (DataRow item in dt.Rows)
                {

                    um.ID = item["ID"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteManager = item["WebsiteManager"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.Institution = item["Institution"].ToString();
                    break;
                   
                }
                CommonSql.Instance.CloseDatabase();

            }
            return um;
        }
        /// <summary>
        /// 根据网点号查询信息
        /// </summary>
        /// <param name="WebsiteID">网点号</param>
        /// <returns></returns>
        public WebsiteInfoModel SelectObjectWebsiteID(string WebsiteID)
        {
            string sql = string.Format(@"select * from WebsiteInfo where WebsiteID='{0}'  ", WebsiteID);
            WebsiteInfoModel um = new WebsiteInfoModel();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectObject(sql);
                foreach (DataRow item in dt.Rows)
                {

                    um.ID = item["ID"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.WebsiteAddress = item["WebsiteAddress"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
                    um.WebsiteManager = item["WebsiteManager"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.Institution = item["Institution"].ToString();
                    break;

                }
                CommonSql.Instance.CloseDatabase();

            }
            return um;
        }
        public bool Update(WebsiteInfoModel um)
        {
            string sql = string.Format(@"update WebsiteInfo set WebsiteID='{0}',WebsiteAddress='{1}',WebsiteTel='{2}',WebsiteManager='{3}',ManagerTelphone='{4}' ,Institution ='{5}',WebsiteName='{6}'  where ID='{7}'"
                , um.WebsiteID, um.WebsiteAddress,um.WebsiteTel,um .WebsiteManager,um.ManagerTelphone,um.Institution,um.WebsiteName , um.ID);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Update(sql)) { CommonSql.Instance.CloseDatabase();return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
                
            }
            return false;
        }
        public bool Delete(WebsiteInfoModel um)
        {
            string sql = string.Format(@"delete from WebsiteInfo where  ID='{0}'", um.ID);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
               
            }
            return false;
        }
        public bool Add(WebsiteInfoModel um)
        {
            string sql = string.Format(@"insert into  WebsiteInfo(ID,WebsiteID,WebsiteAddress,WebsiteTel,WebsiteManager,ManagerTelphone ,Institution,WebsiteName) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}')", um.ID, um.WebsiteID, um.WebsiteAddress, um.WebsiteTel, um.WebsiteManager, um.ManagerTelphone, um.Institution, um.WebsiteName);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
            }
            return false;
        }
    }
}
