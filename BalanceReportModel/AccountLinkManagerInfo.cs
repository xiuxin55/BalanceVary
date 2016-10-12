using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    /// <summary>
    /// 客户经理与账户关联信息
    /// </summary>
    public class AccountLinkManagerInfo : BaseModel
    {
        public string  ID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string AccountID { get; set; }
        public string SubAccountNumber { get; set; }
    }
}
