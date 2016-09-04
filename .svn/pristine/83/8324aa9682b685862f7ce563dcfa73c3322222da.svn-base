using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReport.Models
{
    public class ReportModel
    {
        public string InsituationID { get; set; }
        public string InsituationName { get; set; }
        public string InsituationAddress { get; set; }
        public List<WebsiteInfoModel> WebsiteInfoList { get; set; }
    }
    public class WebsiteInfoModelEXtend
    {
        public WebsiteInfoModel Website { get; set; }
        public List<AccountInfoModelExtend> AccountInfoList { get; set; }
    }
    public class AccountInfoModelExtend
    {
        public AccountInfoModel AccountInfo { get; set; }
        List<BalanceInfoModel> BalanceInfoList { get; set; }
    }
}
