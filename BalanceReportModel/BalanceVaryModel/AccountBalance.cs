using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public partial class AccountBalance : BalanceBaseModel 
    {
        /// <summary>
        /// 帐号
        /// </summary>
        public string AccountID { get; set; }
        /// <summary>
        /// 子帐号
        /// </summary>
        public string SubAccountNumber { get; set; }
        /// <summary>
        /// 账户类型 0定期1活期
        /// </summary>
        public int AccountType { get; set; }
        /// <summary>
        /// 帐号名
        /// </summary>
        public string AccountName { get; set; }
        /// <summary>
        /// 网点id
        /// </summary>
        public string WebsiteID { get; set; }

      
    }
    //public partial class AccountBalance
    //{
    //    /// <summary>
    //    /// 部门ID
    //    /// </summary>
    //    public string DepartmentID { get; set; }
    //    /// <summary>
    //    /// 部门名称
    //    /// </summary>
    //    public string DepartmentName { get; set; }
    //    /// <summary>
    //    /// 客户经理ID
    //    /// </summary>
    //    public string ManagerID { get; set; }
    //    /// <summary>
    //    /// 客户经理名称
    //    /// </summary>
    //    public string ManagerName { get; set; }
    //}
}
