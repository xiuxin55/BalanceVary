using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class CustomerManagerInfoBLL : BalanceBaseBLL<CustomerManagerInfo, CustomerManagerInfoDAL>
    {
        public void BatchInsert(List<CustomerManagerInfo> list)
        {
            dal.BatchInsert(list);
        }
    }
}
