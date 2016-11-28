using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class PGPersonInfoDAL : BalanceDAL<PGPersonInfo>
    {
        public PGPersonInfoDAL()
        {
            DefaultKey = "PGPersonInfo";
        }
        ///// <summary>
        ///// 批量插入数据
        ///// </summary>
        ///// <param name="list"></param>
        //public void BatchInsert(List<PGPersonInfo> list, List<DateTime> ImportTimeList)
        //{
        //    try
        //    {
        //        SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
        //        BatchInsertSQLServer bs = new BatchInsertSQLServer();
        //        bs.BatchInsertSalaryInfo(list);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
