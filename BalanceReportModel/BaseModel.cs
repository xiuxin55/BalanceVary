using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class BaseModel
    {
        public int RowNumber { get; set; }
        /// <summary>
        /// 本页第一条索引
        /// </summary>
        public int StartIndex { get; set; }
        /// <summary>
        /// 本页最后一条索引
        /// </summary>
        public int EndIndex{ get; set; }
        
    }
}
