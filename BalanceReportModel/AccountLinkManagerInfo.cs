using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceModel
{
    /// <summary>
    /// 客户经理与账户关联信息
    /// </summary>
    public partial class AccountLinkManagerInfo : BaseModel
    {
        public string ID { get; set; }
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string AccountID { get; set; }
        public string SubAccountNumber { get; set; }

    }
    public partial class AccountLinkManagerInfo
    {
        public string DepartmentManager { get; set; }
        public string DepartmentTel { get; set; }

        public string CustomerManagerTel { get; set; }
    }
}
