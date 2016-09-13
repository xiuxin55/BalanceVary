using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    public class CustomerManagerInfoDAL : BaseDAL<CustomerManagerInfo>
    {
        public CustomerManagerInfoDAL()
        {
            DefaultKey = "CustomerManagerInfo";
        }
      
    }
}
