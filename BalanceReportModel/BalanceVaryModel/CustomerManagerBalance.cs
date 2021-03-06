﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class CustomerManagerBalance : BalanceBaseModel 
    {
        /// <summary>
        /// 部门ID
        /// </summary>
        public string DepartmentID { get; set; }
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName { get; set; }
        /// <summary>
        /// 客户经理ID
        /// </summary>
        public string ManagerID { get; set; }
        /// <summary>
        /// 客户经理名称
        /// </summary>
        public string ManagerName { get; set; }

    }
}
