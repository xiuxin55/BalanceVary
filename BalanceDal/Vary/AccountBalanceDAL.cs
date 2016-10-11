using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class AccountBalanceDAL : BalanceDAL<AccountBalance>
    {
        public AccountBalanceDAL()
        {
            DefaultKey = "AccountBalance";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<AccountBalance> list, List<DateTime> ImportTimeList)
        {
            try
            {
                SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertAccountBalance(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
