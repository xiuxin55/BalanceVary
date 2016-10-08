using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class ZoneBalanceBLL : BalanceBaseBLL<ZoneBalance, ZoneBalanceDAL>
    {
        /// <summary>
        /// 批量插入,在插入前删除重复项
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<ZoneBalance> list)
        {
            dal.BatchInsert(list);
        }
    }
}
