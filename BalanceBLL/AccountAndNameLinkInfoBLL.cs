using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class AccountAndNameLinkInfoBLL : BalanceBaseBLL<AccountAndNameLinkInfo, AccountAndNameLinkInfoDAL>
    {
        public void BatchInsert(List<AccountAndNameLinkInfo> list)
        {
            dal.BatchInsert(list);
        }
    }
}
