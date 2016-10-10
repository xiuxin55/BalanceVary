using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class WebsiteBalanceDAL : BalanceDAL<WebsiteBalance>
    {
        public WebsiteBalanceDAL()
        {
            DefaultKey = "WebsiteBalance";
        }
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="list"></param>
        public void BatchInsert(List<WebsiteBalance> list, List<DateTime> ImportTimeList)
        {
            try
            {
                SqlMap.Delete("BatchDelete" + DefaultKey, ImportTimeList.ToArray());
                BatchInsertSQLServer bs = new BatchInsertSQLServer();
                bs.BatchInsertWebsiteBalance(list);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
