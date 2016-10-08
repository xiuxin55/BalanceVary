using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class CompanyBalance:BalanceBaseModel 
    {
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 网点编号
        /// </summary>
        public string WebsiteID { get; set; }
        /// 网点类型县行还是市行
        /// </summary>
        public string ZoneType { get; set; }
    }
}
