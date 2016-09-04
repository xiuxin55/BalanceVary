﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReportModel.Models
{
    /// <summary>
    /// 网点信息
    /// </summary>
    public class WebsiteInfoModel
    {
        public string  ID { get; set; }
        public string  WebsiteID { get; set; }
        public string WebsiteName { get; set; }
        public string  WebsiteAddress { get; set; }
        public string  WebsiteTel { get; set; }
        public string  WebsiteManager { get; set; }
        public string  ManagerTelphone { get; set; }
        public string  Institution { get; set; }

    }
}
