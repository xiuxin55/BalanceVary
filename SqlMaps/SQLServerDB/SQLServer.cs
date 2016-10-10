using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMaps
{
    public  class SQLServer
    {
        private SqlConnection Connection = null;
        private bool OpenSQLServer()
        {
            if (string.IsNullOrWhiteSpace(CommonData.DBConnetionString))
            {
                return false;
            }
    
            Connection = new SqlConnection(CommonData.DBConnetionString);
            if (Connection!=null)
            {
                Connection.Open();
                return true;
            }
            return false;
        }

        public bool  ExecuteSqlNoReturn(params string[]  Sqls)
        {
            if (OpenSQLServer())
            {
                SqlCommand cmd = new SqlCommand();
                SqlTransaction transaction = Connection.BeginTransaction(); //开始事务
                cmd.Connection = Connection;
                cmd.Transaction = transaction;
                try
                {
                    foreach (var item in Sqls)
                    {
                        cmd.CommandText = item;
                    }
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                CloseSQLServer();
            }
            return true;
        }

        public bool BatchInsertSQLServer(DataTable dt)
        {
            if (OpenSQLServer())
            {
                using (SqlBulkCopy bulk = new SqlBulkCopy(Connection))
                {
                    bulk.BatchSize = dt.Rows.Count;
                    bulk.DestinationTableName = dt.TableName;
                    bulk.WriteToServer(dt);
                }
                CloseSQLServer();
            }
            return true;
        }

        
        private void CloseSQLServer()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }
    }
}
