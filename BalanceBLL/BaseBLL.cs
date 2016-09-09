using BalanceDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public abstract class BaseBLL<T,S> where T:new()
    {
        private BaseDAL<T, S> dal ;
        public BaseBLL()
        {
            dal = new BaseDAL<T, S>();
        }
        public bool Add(T t)
        {
            return dal.Add(t);
        }
        public bool Update(T t)
        {
            return dal.Update(t);
        }
        public bool Delete(T t)
        {
            return dal.Delete(t);
        }
        public List<T> Select(T t)
        {
            return dal.Select(t).ToList();
        }
    }
}
