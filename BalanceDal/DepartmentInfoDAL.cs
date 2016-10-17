using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class DepartmentInfoDAL : BalanceDAL<DepartmentInfo>
    {
        public DepartmentInfoDAL()
        {
            DefaultKey = "DepartmentInfo";
        }
        public void BatchInsert(List<DepartmentInfo> list)
        {
            try
            {
                SqlMap.BeginTransaction();
                SqlMap.Delete("DeleteAll" + DefaultKey, null);
                foreach (var item in list)
                {
                    Add(item);
                }
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
