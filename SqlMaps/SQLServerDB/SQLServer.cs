using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SqlMaps
{
    /// <summary>
    /// 直连数据库类
    /// </summary>
    public  class SQLServer
    {
        private SqlConnection Connection = null;
        /// <summary>
        /// 打开数据库连接
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 无返回执行sql语句
        /// </summary>
        /// <param name="Sqls">sql语句</param>
        /// <returns></returns>
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
        /// <summary>
        /// 批量插入数据
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
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

        /// <summary>
        /// 关闭数据库连接
        /// </summary>
        private void CloseSQLServer()
        {
            if (Connection != null)
            {
                Connection.Close();
            }
        }
    }
}
