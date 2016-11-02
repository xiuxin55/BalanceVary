using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 要导入的数据
    /// </summary>
    public class ImportDataInfo : BaseModel
    {
        public string  ID { get; set; }
        public string  CustomerNumber { get; set; }
        public string AccountID { get; set; }
        public string  SubAccountNumber { get; set; }
        /// <summary>
        /// 账户类型 0定期1活期
        /// </summary>
        public int  AccountType { get; set; }
        public string  AccountName { get; set; }
        public string  WebsiteID { get; set; }
        public decimal  CurrentBalance { get; set; }
        public string  MoneyType { get; set; }
        /// <summary>
        /// 账户导入数据库时间
        /// </summary>
        public DateTime ImportTime { get; set; }
        /// <summary>
        /// 账户余额时间
        /// </summary>
        public DateTime DataTime { get; set; }
    }
}
