using SqlMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public  class BalanceDAL<T>: BaseDAL<T> where T:new()
    {
        static BalanceDAL()
        {
            SqlMap = BalanceBatis.Batis;
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<T> list)
        {
            try
            {
                SqlMap.BeginTransaction();
                SqlMap.Delete("BatchDelete" + DefaultKey, list.ToArray());
                for (int i = 0; i < list.Count; i = i + 100)
                {
                    List<T> temp = new List<T>();
                    temp = list.GetRange(i, list.Count - i >= 100 ? 100 : list.Count - i);
                    SqlMap.Insert("BatchInsert" + DefaultKey, temp.ToArray());
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
