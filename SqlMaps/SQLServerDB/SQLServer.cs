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
        /// 批量更新数据(仅供人员业绩分配使用)
        /// </summary>
        /// <param name="dt">数据表</param>
        /// <returns></returns>
        public bool BatchUpdateSQLServer(DataTable dt,string selectsql,string tablename)
        {
            if (OpenSQLServer())
            {
                SqlDataAdapter da = new SqlDataAdapter(selectsql, Connection);
                SqlCommandBuilder cmdBuilder = new SqlCommandBuilder(da);
                SqlCommand updatecmd = new SqlCommand(string.Format(@"UPDATE {0} SET  
                    [CardDayGrowth] = @CardDayGrowth
                   ,[CardMonthGrowth] = @CardMonthGrowth
                   ,[CardYearGrowth] = @CardYearGrowth
                   ,[InsuranceDayGrowth] = @InsuranceDayGrowth
                   ,[InsuranceMonthGrowth] = @InsuranceMonthGrowth
                   ,[InsuranceYearGrowth] = @InsuranceYearGrowth
                   ,[CreditCardDayGrowth] = @CreditCardDayGrowth
                   ,[CreditCardMonthGrowth] = @CreditCardMonthGrowth
                   ,[CreditCardYearGrowth] = @CreditCardYearGrowth
                   ,[DayContributionDegree] = @DayContributionDegree
                   ,[MonthContributionDegree] = @MonthContributionDegree
                   ,[YearContributionDegree] = @YearContributionDegree
                    where ID=@ID",tablename));
                //不修改源DataTable   
                updatecmd.UpdatedRowSource = UpdateRowSource.None;
                da.UpdateCommand = updatecmd;
                da.UpdateCommand.Parameters.Add("@CardDayGrowth", SqlDbType.Decimal,18, "CardDayGrowth");
                da.UpdateCommand.Parameters.Add("@CardMonthGrowth", SqlDbType.Decimal, 18, "CardMonthGrowth");
                da.UpdateCommand.Parameters.Add("@CardYearGrowth", SqlDbType.Decimal,18, "CardYearGrowth");
                da.UpdateCommand.Parameters.Add("@InsuranceDayGrowth", SqlDbType.Decimal, 18, "InsuranceDayGrowth");
                da.UpdateCommand.Parameters.Add("@InsuranceMonthGrowth", SqlDbType.Decimal, 18, "InsuranceMonthGrowth");
                da.UpdateCommand.Parameters.Add("@InsuranceYearGrowth", SqlDbType.Decimal, 18, "InsuranceYearGrowth");
                da.UpdateCommand.Parameters.Add("@CreditCardDayGrowth", SqlDbType.Decimal, 18, "CreditCardDayGrowth");
                da.UpdateCommand.Parameters.Add("@CreditCardMonthGrowth", SqlDbType.Decimal, 18, "CreditCardMonthGrowth");
                da.UpdateCommand.Parameters.Add("@CreditCardYearGrowth", SqlDbType.Decimal, 18, "CreditCardYearGrowth");
                da.UpdateCommand.Parameters.Add("@DayContributionDegree", SqlDbType.Decimal, 18, "DayContributionDegree");
                da.UpdateCommand.Parameters.Add("@MonthContributionDegree", SqlDbType.Decimal, 18, "MonthContributionDegree");
                da.UpdateCommand.Parameters.Add("@YearContributionDegree", SqlDbType.Decimal, 18, "YearContributionDegree");
                da.UpdateCommand.Parameters.Add("@ID", SqlDbType.VarChar, 50, "ID");
                //建立sql数据集 并且更新数据库
                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                da.Update(ds, tablename);
                ds.AcceptChanges();
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
