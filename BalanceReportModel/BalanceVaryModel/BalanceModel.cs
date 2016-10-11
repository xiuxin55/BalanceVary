using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class BalanceBaseModel: BaseModel
    {
        public string ID { get; set; }
        /// <summary>
        /// 定期余额
        /// </summary>
        public decimal RegularMoney { get; set; }
        /// <summary>
        /// 活期余额
        /// </summary>
        public decimal UnRegularMoney { get; set; }
        /// <summary>
        /// 总余额
        /// </summary>
        public decimal AmountMoney { get; set; }
        /// <summary>
        /// 定期余额变动
        /// </summary>
        public decimal RegularMoneyVary { get; set; }
        /// <summary>
        /// 活期余额变动
        /// </summary>
        public decimal UnRegularMoneyVary { get; set; }
        /// <summary>
        /// 总余额变动
        /// </summary>
        public decimal AmountMoneyVary { get; set; }
        /// <summary>
        /// 活期比
        /// </summary>
        public string Rate { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public DateTime? BalanceTime { get; set; }
    }
}
