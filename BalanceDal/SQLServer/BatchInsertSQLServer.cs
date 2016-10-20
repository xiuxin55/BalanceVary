using BalanceModel;
using SqlMaps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    /// <summary>
    /// 批量插入
    /// </summary>
    public class BatchInsertSQLServer
    {
        /// <summary>
        /// 批量插入公司数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertCompanyBalance(List<CompanyBalance> list)
        {
            DataTable result = ConverterTable.CompanyBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量公司数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertCompanyBalanceAccount(List<CompanyBalance> list)
        {
            DataTable result = ConverterTable.CompanyBalanceListConvertTableAccount(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入账户号、账户名称数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertAccountAndNameLinkInfo(List<AccountAndNameLinkInfo> list)
        {
            DataTable result = ConverterTable.AccountAndNameLinkInfoListConvertTableAccount(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入网点变化数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertWebsiteBalance(List<WebsiteBalance> list)
        {
            DataTable result = ConverterTable.WebsiteBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入每个账户变化数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertAccountBalance(List<AccountBalance> list)
        {
            DataTable result = ConverterTable.AccountBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入每个部门变化数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertDepartmentBalance(List<DepartmentBalance> list)
        {
            DataTable result = ConverterTable.DepartmentBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入每个客户经理变化数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertCustomerManagerBalance(List<CustomerManagerBalance> list)
        {
            DataTable result = ConverterTable.CustomerManagerBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        /// <summary>
        /// 批量插入客户经理关联数据
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BatchInsertAccountLink(List<AccountLinkManagerInfo> list)
        {
            DataTable result = ConverterTable.AccountLinkListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
    }
}
