using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class AccountAndNameLinkInfoDAL : BalanceDAL<AccountAndNameLinkInfo>
    {
        public AccountAndNameLinkInfoDAL()
        {
            DefaultKey = "AccountAndNameLinkInfo";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<AccountAndNameLinkInfo> list)
        {
            try
            {
                SqlMap.Delete("BatchDelete" + DefaultKey, null);
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertAccountAndNameLinkInfo(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
