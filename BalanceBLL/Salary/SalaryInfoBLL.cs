﻿using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class SalaryInfoBLL : BalanceBaseBLL<SalaryInfo, SalaryInfoDAL>
    {
        /// <summary>
        /// 批量插入,在插入前删除重复项
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<SalaryInfo> list, List<DateTime> ImportTimeList)
        {
            dal.BatchInsert(list, ImportTimeList);
        }
    }
}
