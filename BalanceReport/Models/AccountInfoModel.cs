using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Models
{
    /// <summary>
    /// 账户信息
    /// </summary>
    public class AccountInfoModel
    {
        public string ID { get; set; }
        public string AccountID { get; set; }
        
        public string AccountName { get; set; }
       
        public string AccountType { get; set; }
        public string WebsiteID { get; set; }
        public string ManagerID { get; set; }
        /// <summary>
        /// 是否已关联
        /// </summary>
        public string CorrelationState { get; set; }
        public string SubAccountNumber { get; set; }
        public ManagersInfoModel ManagersInfoObj { get; set; }
        public WebsiteInfoModel WebsiteInfoObj { get; set; }
    }

}
