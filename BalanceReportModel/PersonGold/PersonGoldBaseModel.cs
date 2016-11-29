using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class PersonGoldBaseModel : BaseModel
    {
        public string ID { get; set; }
        /// <summary>
        /// 新网点编号（这里区分新旧网点）
        /// </summary>
        public string NewWebsiteID { get; set; }
        /// <summary>
        /// 旧网点编号（这里区分新旧网点）
        /// </summary>
        public string WebsiteID { get; set; }
        /// <summary>
        /// 数据时间
        /// </summary>
        public DateTime? DataTime { get; set; }
    }
}
