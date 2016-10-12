using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class CustomerManagerBalanceDAL : BalanceDAL<CustomerManagerBalance>
    {
        public CustomerManagerBalanceDAL()
        {
            DefaultKey = "CustomerManagerBalance";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<CustomerManagerBalance> list, List<DateTime> ImportTimeList)
        {
            try
            {
                SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertCustomerManagerBalance(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
