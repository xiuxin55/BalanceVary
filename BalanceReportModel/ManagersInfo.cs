using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class ManagersInfo : BaseModel
    {
        public string ID { get; set; }
        public string WebsiteID { get; set; }
        public string WebsiteName { get; set; }
        public string WebsiteTel{ get; set; }
        public string ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerTelphone { get; set; }
        public string ManagerEmail { get; set; }
        public string Institution { get; set; }
    }
}
