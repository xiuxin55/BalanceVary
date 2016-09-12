using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    public class WebsiteInfoDAL: BaseDAL<WebsiteInfo>
    {
        public  WebsiteInfoDAL()
        {
            DefaultKey = "WebsiteInfo";
        }
      
    }
}
