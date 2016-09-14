using SqlMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public  class BalanceDAL<T>: BaseDAL<T> where T:new()
    {
        static BalanceDAL()
        {
            SqlMap = BalanceBatis.Batis;
        }
    }
}
