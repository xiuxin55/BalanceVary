using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class DepartmentBalanceDAL : BalanceDAL<DepartmentBalance>
    {
        public DepartmentBalanceDAL()
        {
            DefaultKey = "DepartmentBalance";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<DepartmentBalance> list, List<DateTime> ImportTimeList)
        {
            try
            {
                SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertDepartmentBalance(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
