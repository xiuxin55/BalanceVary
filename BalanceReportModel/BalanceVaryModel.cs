using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReportModel
{
    /// <summary>
    /// 余额变动情况
    /// </summary>
    public class BalanceVaryModel : IComparable  
    {
        public string ID { get; set; }
        public string WebsiteID { get; set; }
        public string DifferWebsite { get; set; }
        public string Name { get; set; }
        public string RegularMoney { get; set; }
        public string UnRegularMoney { get; set; }
        public string AmountMoney { get; set; }
        public string WebsiteAddress { get; set; }
        public string WebsiteTel { get; set; }
        public string WebsiteManager { get; set; }
        public string ManagerTelphone { get; set; }
        public string ParentID { get; set; }
        public string BalanceTime { get; set; }


        public  int CompareTo(object obj)
        {
            int flg = 0;
            try
            {
                BalanceVaryModel sObj = (BalanceVaryModel)obj;
                if(DateTime.Parse( this.BalanceTime)> (DateTime.Parse( sObj.BalanceTime)))
                {
                    flg=-1;
                }
                if(DateTime.Parse( this.BalanceTime)== (DateTime.Parse( sObj.BalanceTime)))
                {
                    flg=0;
                }
                if(DateTime.Parse( this.BalanceTime)< (DateTime.Parse( sObj.BalanceTime)))
                {
                    flg=1;
                }
               
            }
            catch (Exception ex)
            {
                throw new Exception("比较异常", ex.InnerException);
            }
            return flg;  
        }
    }
}
