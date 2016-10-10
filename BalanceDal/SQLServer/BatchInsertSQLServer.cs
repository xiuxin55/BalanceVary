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
        public bool BatchInsertWebsiteBalance(List<WebsiteBalance> list)
        {
            DataTable result = ConverterTable.WebsiteBalanceListConvertTable(list);
            SQLServer ss = new SQLServer();
            return ss.BatchInsertSQLServer(result);
        }
    }
}
