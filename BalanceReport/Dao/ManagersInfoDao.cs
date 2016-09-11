using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceReport.Common;
using System.Data;
using System.Collections.ObjectModel;

namespace BalanceReport.Dao
{
    public class ManagersInfoDao
    {
        private static ManagersInfoDao _instance;

        public static ManagersInfoDao Instance
        {
            get {
                if (_instance == null)
                {
                    _instance = new ManagersInfoDao();
                }
                return ManagersInfoDao._instance;
            }
           
        }
        
        /// <summary>
        /// 所有网点
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<ManagersInfoModel> GetManagers()
        {
            string sql = @"select * from ManagersInfo ";
            ObservableCollection<ManagersInfoModel> list = new ObservableCollection<ManagersInfoModel>();
             if (CommonSql.Instance.ConnectDatabase())
             {
                DataTable dt= CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    ManagersInfoModel um = new ManagersInfoModel();
                    um.ID =item["ID"].ToString();
                    um.ManagerID = item["ManagerID"].ToString();
                    um.ManagerName = item["ManagerName"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.ManagerEmail = item["ManagerEmail"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
               
     
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
        public ObservableCollection<ManagersInfoModel> GetManagersFromObject(ManagersInfoModel model)
        {

            string sql = @"select  m.ID ,ManagerID,ManagerName,w.WebsiteID,w.WebsiteName,m.ManagerTelphone,ManagerEmail,WebsiteAddress,WebsiteTel,WebsiteManager,w.ManagerTelphone  as WebsiteManagerTelphone,Institution from ManagersInfo 
                           m left join WebsiteInfo w on m.WebsiteID=w.WebsiteID where 1=1";
            if (!string.IsNullOrEmpty(model.ManagerID))
            {
                sql = sql + " and ManagerID like '%" + model.ManagerID + "%'";
            }

            if (!string.IsNullOrEmpty(model.ManagerName))
            {
                sql = sql + " and ManagerName like '%" + model.ManagerName + "%'";
            }
            ObservableCollection<ManagersInfoModel> list = new ObservableCollection<ManagersInfoModel>();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectAll(sql);
                foreach (DataRow item in dt.Rows)
                {
                    ManagersInfoModel um = new ManagersInfoModel();
                    um.ID = item["ID"].ToString();
                    um.ManagerID = item["ManagerID"].ToString();
                    um.ManagerName = item["ManagerName"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.ManagerEmail = item["ManagerEmail"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    um.WebsiteTel = item["WebsiteTel"].ToString();
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
        public ManagersInfoModel SelectObject(string id)
        {
            string sql = string.Format(@"select * from ManagersInfo where ID='{0}'  ", id);
            ManagersInfoModel um = new ManagersInfoModel();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectObject(sql);
                foreach (DataRow item in dt.Rows)
                {

                    um.ID = item["ID"].ToString();
                    um.ManagerID = item["ManagerID"].ToString();
                    um.ManagerName = item["ManagerName"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.ManagerEmail = item["ManagerEmail"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    break;
                   
                }
                CommonSql.Instance.CloseDatabase();

            }
            return um;
        }
        /// <summary>
        /// 根据网点号查询信息
        /// </summary>
        /// <param name="ManagersID">网点号</param>
        /// <returns></returns>
        public ManagersInfoModel SelectObjectManagersID(string ManagersID)
        {
            string sql = string.Format(@"select * from ManagersInfo where ManagerID='{0}'  ", ManagersID);
            ManagersInfoModel um = new ManagersInfoModel();
            if (CommonSql.Instance.ConnectDatabase())
            {
                DataTable dt = CommonSql.Instance.SelectObject(sql);
                foreach (DataRow item in dt.Rows)
                {

                    um.ID = item["ID"].ToString();
                    um.ManagerID = item["ManagerID"].ToString();
                    um.ManagerName = item["ManagerName"].ToString();
                    um.WebsiteID = item["WebsiteID"].ToString();
                    um.WebsiteName = item["WebsiteName"].ToString();
                    um.ManagerEmail = item["ManagerEmail"].ToString();
                    um.ManagerTelphone = item["ManagerTelphone"].ToString();
                    break;

                }
                CommonSql.Instance.CloseDatabase();

            }
            return um;
        }
        public bool Update(ManagersInfoModel um)
        {
            string sql = string.Format(@"update ManagersInfo set ManagerID='{0}',ManagerName='{1}',WebsiteID='{2}',WebsiteName='{3}',ManagerTelphone='{4}' ,ManagerEmail ='{5}' where ID='{6}'"
                , um.ManagerID, um.ManagerName, um.WebsiteID, um.WebsiteName, um.ManagerTelphone, um.ManagerEmail, um.ID);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Update(sql)) { CommonSql.Instance.CloseDatabase();return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
                
            }
            return false;
        }
        public bool Delete(ManagersInfoModel um)
        {
            string sql = string.Format(@"delete from ManagersInfo where  ID='{0}'", um.ID);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
               
            }
            return false;
        }
        public bool Add(ManagersInfoModel um)
        {
            string sql = string.Format(@"insert into  ManagersInfo(ID,ManagerID,ManagerName,WebsiteID,WebsiteName,ManagerTelphone ,ManagerEmail) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", um.ID, um.ManagerID, um.ManagerName, um.WebsiteID, um.WebsiteName, um.ManagerTelphone, um.ManagerEmail);
            if (CommonSql.Instance.ConnectDatabase())
            {
                if (CommonSql.Instance.Delete(sql)) { CommonSql.Instance.CloseDatabase(); return true; }
                else { CommonSql.Instance.CloseDatabase(); return false; }
            }
            return false;
        }
    }
}
