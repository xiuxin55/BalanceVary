using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceModel
{
    public class AccountAndNameLinkInfo : BaseModel 
    {
        public string ID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
 
    }
}
