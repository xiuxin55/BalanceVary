using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class ReportModel : BaseModel
    {
        public string InsituationID { get; set; }
        public string InsituationName { get; set; }
        public string InsituationAddress { get; set; }
        public List<WebsiteInfo> WebsiteInfoList { get; set; }
    }
    public class WebsiteInfoModelEXtend
    {
        public WebsiteInfo Website { get; set; }
        public List<AccountInfoModelExtend> AccountInfoList { get; set; }
    }
    public class AccountInfoModelExtend
    {
        public AccountInfo AccountInfo { get; set; }
        List<BalanceInfo> BalanceInfoList { get; set; }
    }
}
