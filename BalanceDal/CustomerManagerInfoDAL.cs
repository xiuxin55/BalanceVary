using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class CustomerManagerInfoDAL : BalanceDAL<CustomerManagerInfo>
    {
        public CustomerManagerInfoDAL()
        {
            DefaultKey = "CustomerManagerInfo";
        }
        public void BatchInsert(List<CustomerManagerInfo> list)
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
