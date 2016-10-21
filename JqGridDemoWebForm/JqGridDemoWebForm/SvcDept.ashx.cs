using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Script.Serialization;
using BalanceModel;
namespace JqGridDemoWebForm
{
    /// <summary>
    /// Summary description for SvcDept
    /// </summary>
    public class SvcDept : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
           
            var nodeid = context.Request["nodeid"];
            var n_level = context.Request["n_level"];
            string  deptID = nodeid != null ? nodeid : new Nullable<Guid>().ToString();
            int level = n_level != null ? int.Parse(n_level) + 1 : 0;
            List<BalanceVaryModel> depts = context.Application["BalanceVaryModel"] as List<BalanceVaryModel>;
            var subDepts = depts.Where<BalanceVaryModel>(x => x.ParentID == deptID.ToString()).ToList<BalanceVaryModel>();

            var data = new
            {
                page = 1,
                total = 20,
                records = subDepts.Count,
                rows = (from dept in subDepts
                        select new
                        {
                            cell = new[] 
                            {
                                dept.ID.ToString(),     
                                            
                                dept.WebsiteID ,
                                dept.Name, 
                                dept.DifferWebsite , 
                                dept.RegularMoney,               
                                dept.UnRegularMoney ,
                                dept.AmountMoney,               
                                
                                dept.WebsiteAddress,               
                                dept.WebsiteTel ,
                                dept.WebsiteManager,               
                                dept.ManagerTelphone ,
                                dept.BalanceTime,
                                dept.ParentID != null ? dept.ParentID.ToString() : "",                                
                                level.ToString(),   //Level
                                deptID != null ? deptID.ToString() : "null",    //ParentID
                                depts.Count<BalanceVaryModel>(x => x.ParentID == dept.ID) == 0 ? "true":"false",  //isLeaf
                                "false", //expanded
                                "false"//loaded
                            }
                        })
            };

            context.Response.ContentType = "application/json";
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            context.Response.Write(serializer.Serialize(data));
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}