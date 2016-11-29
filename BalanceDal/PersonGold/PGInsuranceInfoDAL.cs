using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class PGInsuranceInfoDAL : BalanceDAL<PGInsuranceInfo>
    {
        public PGInsuranceInfoDAL()
        {
            DefaultKey = "PGInsuranceInfo";
        }
        ///// <summary>
        ///// 批量插入数据
        ///// </summary>
        ///// <param name="list"></param>
        //public void BatchInsert(List<PGDebitCardInfo> list, List<DateTime> ImportTimeList)
        //{
        //    try
        //    {
        //        SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
        //        BatchInsertSQLServer bs = new BatchInsertSQLServer();
        //        bs.BatchInsertPGDebitCardInfo(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
