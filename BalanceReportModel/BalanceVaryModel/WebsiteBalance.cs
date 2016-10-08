using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class WebsiteBalance:BalanceBaseModel 
    {
        /// <summary>
        /// 网点编号
        /// </summary>
        public string WebsiteID { get; set; }
        /// 网点类型县行还是市行
        /// </summary>
        public string ZoneType { get; set; }
    }
}
