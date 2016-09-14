using BalanceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceBLL
{
    public  class BalanceBaseBLL<T,S>: BaseBLL<T, S> where T:new() where S:BalanceDAL<T>,new()
    {
        public BalanceBaseBLL()
        {
            dal = new S();
        }
    }
}
