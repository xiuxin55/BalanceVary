using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class PGCreditCardInfoDAL : BalanceDAL<PGCreditCardInfo>
    {
        public PGCreditCardInfoDAL()
        {
            DefaultKey = "PGCreditCardInfo";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<PGCreditCardInfo> list, List<DateTime> ImportTimeList)
        {
            try
            {
                //SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
                //BatchInsertSQLServer bs = new BatchInsertSQLServer();
                //bs.BatchInsertPGDebitCardInfo(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
