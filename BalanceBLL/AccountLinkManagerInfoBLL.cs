using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class AccountLinkManagerInfoBLL : BalanceBaseBLL<AccountLinkManagerInfo, AccountLinkManagerInfoDAL>
    {
        /// <summary>
        /// 批量插入,在插入前删除重复项
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<AccountLinkManagerInfo> list)
        {
            dal.BatchInsert(list);
        }
    }
}
