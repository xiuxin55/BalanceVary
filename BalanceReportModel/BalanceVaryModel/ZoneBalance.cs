using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class ZoneBalance:BalanceBaseModel 
    {
        /// <summary>
        /// 网点类型县行还是市行
        /// </summary>
        public string ZoneType { get; set; }
    }
}
