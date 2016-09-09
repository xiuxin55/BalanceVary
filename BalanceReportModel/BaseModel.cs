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
        public int StartIndex
        {
            get
            {
                return (PageNumber - 1) * PageCount;
            }
        }
        /// <summary>
        /// 本页最后一条索引
        /// </summary>
        public int EndIndex
        {
            get
            {
                return PageNumber* PageCount;
            }
        }
        /// <summary>
        /// 查看的第几页的数据
        /// </summary>
        public int PageNumber { get; set; }
        /// <summary>
        /// 一页显示的行数
        /// </summary>
        public int PageCount { get; set; }
    }
}
