using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    public class CustomerManagerDAL : BaseDAL<CustomerManagerInfo>
    {
        public CustomerManagerDAL()
        {
            DefaultKey = "CustomerManagerInfo";
        }
      
    }
}
