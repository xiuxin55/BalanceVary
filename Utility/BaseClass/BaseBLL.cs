
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// 业务调用逻辑层
    /// </summary>
    /// <typeparam name="T">DAL类型</typeparam>
    /// <typeparam name="S">实体类</typeparam>
    public abstract class BaseBLL<T,S> where T:new() where S:BaseDAL<T>,new()
    {
        protected  S dal ;
        public BaseBLL()
        {
            dal =new S();
        }
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Add(T t)
        {
            return dal.Add(t);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Update(T t)
        {
            return dal.Update(t);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public bool Delete(T t)
        {
            return dal.Delete(t);
        }
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> Select(T t)
        {
            return dal.Select(t).ToList();
        }
        /// <summary>
        /// 查询数量用于分页
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
       public int SelectCount(T t)
        {
            return dal.SelectCount(t);
        }
    }
}
