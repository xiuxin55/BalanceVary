using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class ZoneBalanceDAL : BalanceDAL<ZoneBalance>
    {
        public ZoneBalanceDAL()
        {
            DefaultKey = "ZoneBalance";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<ZoneBalance> list)
        {
            try
            {
                SqlMap.BeginTransaction();
                SqlMap.Delete("BatchDelete" + DefaultKey, list.ToArray());
                SqlMap.Insert("BatchInsert" + DefaultKey, list.ToArray());
                SqlMap.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlMap.RollBackTransaction();
                throw ex;
            }
        }
    }
}
