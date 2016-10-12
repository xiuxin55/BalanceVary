using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class DepartmentBalance : BalanceBaseModel 
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
 
    }
}
