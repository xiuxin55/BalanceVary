
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public abstract class BaseBLL<T,S> where T:new() where S:BaseDAL<T>,new()
    {
        protected  S dal ;
        public BaseBLL()
        {
            dal =new S();
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

       public int SelectCount(T t)
        {
            return dal.SelectCount(t);
        }
    }
}
