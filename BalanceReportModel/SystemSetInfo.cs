using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceModel
{
    /// <summary>
    /// 账户信息
    /// </summary>
    public class SystemSetInfo: BaseModel
    {
        public string ID { get; set; }
        public string SetName { get; set; }
        
        public string SetContent { get; set; }
       
    }

}
