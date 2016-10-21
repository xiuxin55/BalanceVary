using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BalanceModel;
using BalanceReportDao.Common;
using BalanceReportDao.Dao;

namespace JqGridDemoWebForm
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string starttime = Request["starttime"];//开始日期
            string endtime = Request["endtime"];//结束日期
            
            string Insitusation = Request["Insitusation"];//机构名称  县和市
         
            string WebsiteName = Request["WebsiteName"];//机构名称  县和市
            string Company= Request["Company"];
            string Account = Request["Account"];

            string Displaystate = Request["Displaystate"];
            string except0 = Request["except0"];
            if (Displaystate == null) { Displaystate = "0"; }
            if (Company == null) { Company = ""; }
            if (Account == null) { Account = ""; }
            if (except0 == null) { except0 = "1"; }
            BalanceSrv bs=new BalanceSrv();
            List<BalanceVaryModel> InfoList = bs.GetBalanceVary(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0);

           
           this.Application["BalanceVaryModel"] = InfoList;
        }
    }
}