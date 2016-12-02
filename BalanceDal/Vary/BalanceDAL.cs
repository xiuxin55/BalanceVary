using SqlMaps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    /// <summary>
    /// 余额变化基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public  class BalanceDAL<T>: BaseDAL<T> where T:new()
    {
        static BalanceDAL()
        {
            SqlMap = BalanceBatis.Batis;
        }
        /// <summary>
        /// 调用存储过程计算任意两个日期数据变化
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public List<T> CallTimeSpanProc(T t)
        {
            IList<T> list = SqlMap.QueryForList<T>("Select" + DefaultKey + "TwoTime", t);
            return list!=null? list.ToList():new List<T>();
        }

        /// <summary>
        /// 自定义查询
        /// </summary>
        /// <param name="selectkey">映射文件中的id</param>
        /// <param name="t">类型</param>
        /// <returns></returns>
        public List<T> SelectDataByCustom(string selectkey,T t)
        {
            IList<T> list = SqlMap.QueryForList<T>(selectkey, t);
            return list != null ? list.ToList() : new List<T>();
        }
    }
}
