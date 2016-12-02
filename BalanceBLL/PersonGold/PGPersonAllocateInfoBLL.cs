using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class PGPersonAllocateInfoBLL : BalanceBaseBLL<PGPersonAllocateInfo, PGPersonAllocateInfoDAL>
    {
        ///// <summary>
        ///// 批量插入,在插入前删除重复项
        ///// </summary>
        ///// <param name="list"></param>
        //public void BatchInsert(List<PGPersonInfo> list, List<DateTime> ImportTimeList)
        //{
        //    dal.BatchInsert(list, ImportTimeList);
        //}
        public bool BatchUpdate(List<PGPersonAllocateInfo> list)
        {
            return dal.BatchUpdate(list);
        }
        public List<PGPersonAllocateInfo> SelectLastPGPersonAllocateInfo(PGPersonAllocateInfo info)
        {
            return dal.SelectDataByCustom("SelectLastPGPersonAllocateInfo", info);
        }
    }
}
