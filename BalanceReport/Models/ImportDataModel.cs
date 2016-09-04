using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Models
{
    /// <summary>
    /// 要导入的数据
    /// </summary>
    public class ImportDataModel
    {
        public string  ID { get; set; }
        public string  CustomerNumber { get; set; }
        public string  SubAccountNumber { get; set; }
        public string  AccountType { get; set; }
        public string  AccountName { get; set; }
        public string  WebsiteID { get; set; }
        public string  CurrentBalance { get; set; }
        public string  MoneyType { get; set; }
        public string ImportTime { get; set; }
    }
}
