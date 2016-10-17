using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class AccountLinkManagerInfoDAL : BalanceDAL<AccountLinkManagerInfo>
    {
        public AccountLinkManagerInfoDAL()
        {
            DefaultKey = "AccountLinkManagerInfo";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<AccountLinkManagerInfo> list)
        {
            try
            {
                SqlMap.Delete("DeleteAll" + DefaultKey,null);
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertAccountLink(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
