using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class DepartmentInfoBLL : BalanceBaseBLL<DepartmentInfo, DepartmentInfoDAL>
    {
        public void BatchInsert(List<DepartmentInfo> list)
        {
            dal.BatchInsert(list);
        }
    }
}
