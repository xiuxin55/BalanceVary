using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class CustomerManagerInfoDAL : BalanceDAL<CustomerManagerInfo>
    {
        public CustomerManagerInfoDAL()
        {
            DefaultKey = "CustomerManagerInfo";
        }
      
    }
}
