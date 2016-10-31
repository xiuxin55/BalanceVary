
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAuthorization
{
    public class DataSetToModel
    {
        public static List<DutyModel> DutyToModel(DataSet dsAllDuty,int tableindex)
        {
            List<DutyModel> temp = new List<DutyModel>();
            if (dsAllDuty != null)
            {
                DataTable dt = dsAllDuty.Tables[tableindex];
                foreach (DataRow item in dt.Rows)
                {
                    DutyModel dm = new DutyModel();
                    dm.DutyId = item["DutyId"].ToString();
                    dm.DutyCode = item["DutyCode"].ToString();
                    dm.DutyName = item["DutyName"].ToString();
                    dm.DutyDescribe = item["Describe"].ToString();
                    temp.Add(dm);

                }
            }
            return temp;
        }

        public static List<DutyModel> UserDutyToModel(DataSet dsAllDuty, int tableindex)
        {
            List<DutyModel> temp = new List<DutyModel>();
            if (dsAllDuty != null)
            {
                DataTable dt = dsAllDuty.Tables[tableindex];
                foreach (DataRow item in dt.Rows)
                {
                    DutyModel dm = new DutyModel();
                    dm.DutyId = item["DutyId"].ToString();
                    dm.DutyCode = item["DutyCode"].ToString();
                    dm.DutyName = item["DutyName"].ToString();
                    dm.UserDutyID = item["UserDutyID"].ToString();
                    temp.Add(dm);

                }
            }
            return temp;
        }
        public static List<DutyModel> UserDutyToModel3(DataSet dsAllDuty, int tableindex)
        {
            List<DutyModel> temp = new List<DutyModel>();
            if (dsAllDuty != null)
            {
                DataTable dt = dsAllDuty.Tables[tableindex];
                foreach (DataRow item in dt.Rows)
                {
                    DutyModel dm = new DutyModel();
                    dm.DutyId = item["DutyId"].ToString();
                    dm.DutyCode = item["DutyCode"].ToString();
                    dm.DutyName = item["DutyName"].ToString();
                    temp.Add(dm);

                }
            }
            return temp;
        }

        public static List<FundsRegulatoryClient.UserManageSrv.UserInfo> UserInfoToModel(DataSet dsAllUser, int tableindex)
        {
            List<FundsRegulatoryClient.UserManageSrv.UserInfo> temp = new List<FundsRegulatoryClient.UserManageSrv.UserInfo>();
            if (dsAllUser != null)
            {
                DataTable dt = dsAllUser.Tables[tableindex];
                foreach (DataRow item in dt.Rows)
                {
                    FundsRegulatoryClient.UserManageSrv.UserInfo ui = new FundsRegulatoryClient.UserManageSrv.UserInfo();
                    ui.UserId = item["UserId"].ToString();
                    ui.UserCode = item["UserCode"].ToString();
                    ui.UserName = item["UserName"].ToString();
                    ui.Ssq = item["SSQ"].ToString();
                    ui.UnitID = item["SSQName"].ToString();
                    ui.Sex = item["Sex"].ToString();
                    ui.LinkTel = item["LinkTel"].ToString();
                    ui.Email = item["Email"].ToString();
                    ui.State = item["UserState"].ToString();
                    ui.Describe = item["Describe"].ToString();
                    temp.Add(ui);

                }
            }
            return temp;
        }

        public static FundsRegulatoryClient.UserManageSrv.UserInfo UserInfoToSingleModel(DataSet dsAllUser)
        {
            if (dsAllUser != null)
            {
                DataTable dt = dsAllUser.Tables[0];
                foreach (DataRow item in dt.Rows)
                {
                    FundsRegulatoryClient.UserManageSrv.UserInfo ui = new FundsRegulatoryClient.UserManageSrv.UserInfo();
                    ui.UserId = item["UserId"].ToString();
                    ui.UserCode = item["UserCode"].ToString();
                    ui.UserName = item["UserName"].ToString();
                    ui.Ssq = item["SSQName"].ToString();
                    ui.Sex = item["Sex"].ToString();
                    ui.LinkTel = item["LinkTel"].ToString();
                    ui.Email = item["Email"].ToString();
                    ui.State = item["UserState"].ToString();
                    ui.Describe = item["Describe"].ToString();
                    return ui;
                }
            }
            return null;
        }
    }
}
