using BalanceModel;
using SqlMaps;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    public class BatchInsertSQLServer
    {
        public bool BatchInsertCompanyBalance(List<CompanyBalance> list)
        {
            DataTable result = ConverterTable.CompanyBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        public bool BatchInsertCompanyBalanceAccount(List<CompanyBalance> list)
        {
            DataTable result = ConverterTable.CompanyBalanceListConvertTableAccount(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }

        public bool BatchInsertWebsiteBalance(List<WebsiteBalance> list)
        {
            DataTable result = ConverterTable.WebsiteBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }

        public bool BatchInsertAccountBalance(List<AccountBalance> list)
        {
            DataTable result = ConverterTable.AccountBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        public bool BatchInsertDepartmentBalance(List<DepartmentBalance> list)
        {
            DataTable result = ConverterTable.DepartmentBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
        public bool BatchInsertCustomerManagerBalance(List<CustomerManagerBalance> list)
        {
            DataTable result = ConverterTable.CustomerManagerBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }

        public bool BatchInsertAccountLink(List<AccountLinkManagerInfo> list)
        {
            DataTable result = ConverterTable.AccountLinkListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
    }
}
