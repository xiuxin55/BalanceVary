﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Models
{
    /// <summary>
    /// 余额表
    /// </summary>
    public class BalanceInfoModel
    {
        public string ID { get; set; }
        public string AccountNumber { get; set; }
        public string SubAccountNumber { get; set; }
        public string Balance { get; set; }
        public string BalanceState { get; set; }
        public string BalanceTime { get; set; }
        public string MoneyType { get; set; }        
        
    }
}
