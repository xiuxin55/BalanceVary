using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 部门信息
    /// </summary>
    public class DepartmentInfo : BaseModel
    {
        public string  ID { get; set; }
        /// <summary>
        /// 部门id
        /// </summary>
        public string DepartmentID { get; set; }
        public string DepartmentName { get; set; }
        public string DepartmentManager { get; set; }
        public string ManagerTelphone { get; set; }
    }
}
