using BalanceModel;
using SqlMaps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    /// <summary>
    /// 批量更新
    /// </summary>
    public partial class BatchUpdateSQLServer
    {
        /// <summary>
        /// 批量更新人员业绩分配数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchUpdatePGPersonAllocateInfo(List<PGPersonAllocateInfo> list,string selectsql,string tablename)
        {
            DataTable result = ConverterTable.PersonAllocateListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchUpdateSQLServer(result, selectsql, tablename);
        }

    }

   
}
