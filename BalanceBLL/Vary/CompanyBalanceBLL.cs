﻿using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class CompanyBalanceBLL : BalanceBaseBLL<CompanyBalance, CompanyBalanceDAL>
    {
        /// <summary>
        /// 批量插入,在插入前删除重复项
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<CompanyBalance> list,List<DateTime> ImportTimeList)
        {
            dal.BatchInsert(list,ImportTimeList);
        }
        /// <summary>
        /// 批量插入,在插入前删除重复项(accountid 为主键)
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsertAccountID(List<CompanyBalance> list, List<DateTime> ImportTimeList)
        {
            dal.BatchInsertAccountID(list, ImportTimeList);
        }
    }
}
