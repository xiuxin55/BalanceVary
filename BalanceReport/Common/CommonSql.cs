using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Collections;
using System.Windows;
using System.Threading;

namespace BalanceReport.Common
{
    /// <summary>
    /// 数据常量
    /// </summary>
    public class CommonSql
    {
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        private string ConnetionStr = @"SERVER=localhost;DATABASE=BalanceReport;PWD=123;UID=sa;";
        private static CommonSql _instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static CommonSql Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonSql();
                    _instance.ConnetionStr =  CommonData.Instance.ConnectStr;
                }
                return CommonSql._instance;
            }
        }

        private SqlConnection sql;
        public bool  ConnectDatabase()
        {
            try
            {
            
                sql = new SqlConnection(ConnetionStr);
                sql.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SqlTransaction(List<string> cmdtxts)
        {
            SqlTransaction tran=sql.BeginTransaction();
            try
            {
                
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.Transaction = tran;
                foreach (string  item in cmdtxts)
                {
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                }
                tran.Commit();
               return  true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }
        public bool SqlTransactionProcessBar(List<string> cmdtxts)
        {
            SqlTransaction tran = sql.BeginTransaction();
            try
            {
                double jinDu = 0;
                App.Current.Dispatcher.Invoke(new Action(delegate()
                {
                    BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;

                    MW.pro.progressBar.Maximum = cmdtxts.Count;

                    MW.pro.title.Text = "正在执行数据库SQL语句";
                    MW.pro.progressBar.Value = 0;
                    MW.pro.Visibility = Visibility.Visible;
                    MW.pro.progressBar.InvalidateProperty(System.Windows.Controls.ProgressBar.ValueProperty);
                }));

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.Transaction = tran;
                foreach (string item in cmdtxts)
                {
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    }));
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }

        public bool SqlTransactionProcessBar(List<DataTable> listtable, List<string> cmdtxts)
         {
             try
             {
                 App.Current.Dispatcher.Invoke(new Action(delegate()
                 {
                     BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;

                     MW.pro.progressBar.Maximum = listtable.Count +cmdtxts.Count;

                     MW.pro.title.Text = "正在执行数据库SQL语句";
                     MW.pro.progressBar.Value = 0;
                     MW.pro.Visibility = Visibility.Visible;
                     MW.pro.progressBar.InvalidateProperty(System.Windows.Controls.ProgressBar.ValueProperty);
                 }));
                 foreach (var item in listtable)
                 {


                     using (SqlBulkCopy bulk = new SqlBulkCopy(sql))
                     {
                         bulk.BatchSize = item.Rows.Count;
                         bulk.DestinationTableName = item.TableName;
                         bulk.WriteToServer(item);
                     }
                     App.Current.Dispatcher.Invoke(new Action(delegate()
                     {
                         BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                         MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                         double jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                         MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                     }));
                 }
                 //LastSqlTransactionProcessBar(cmdtxts);
                 return LastSqlTransactionProcessBar(cmdtxts);
             }
             catch(Exception e)
             {
                 MessageBox.Show(e.Message);
                 return false;
             }
             
         }
        private  bool LastSqlTransactionProcessBar(List<string> cmdtxts)
        {
            SqlTransaction tran = sql.BeginTransaction();
            try
            {
              
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = sql;
                cmd.Transaction = tran;
                foreach (string item in cmdtxts)
                {
                    cmd.CommandText = item;
                    cmd.ExecuteNonQuery();
                    App.Current.Dispatcher.Invoke(new Action(delegate()
                    {
                        BalanceWindow MW = (BalanceWindow)App.Current.MainWindow;
                        MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                        double jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                        MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    }));
                }
                tran.Commit();
                return true;
            }
            catch (Exception)
            {
                tran.Rollback();
                return false;
            }
        }
        public bool Add(string cmdtext)
        {
            if (sql == null) { return false; }
            SqlCommand sqlcmd = new SqlCommand(cmdtext, sql);
            int result= sqlcmd.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Update(string cmdtext)
        {
            if (sql == null) { return false; }
            SqlCommand sqlcmd = new SqlCommand(cmdtext, sql);
            int result = sqlcmd.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }

        public bool Delete(string cmdtext)
        {
            if (sql == null) { return false; }
            SqlCommand sqlcmd = new SqlCommand(cmdtext, sql);
            int result = sqlcmd.ExecuteNonQuery();
            if (result > 0)
                return true;
            else
                return false;
        }
        public DataTable SelectAll(string cmdtext)
        {
            //SqlCommand sqlcmd = new SqlCommand(cmdtext, sql);
            if (sql == null) { return null; }
            SqlDataAdapter adpater = new SqlDataAdapter(cmdtext, sql);
            DataSet ds = new DataSet();
            adpater.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
                return null ;
        }

        public DataTable SelectObject(string cmdtext)
        {
            //SqlCommand sqlcmd = new SqlCommand(cmdtext, sql);
            if (sql == null) { return null; }
            SqlDataAdapter adpater = new SqlDataAdapter(cmdtext, sql);
            DataSet ds = new DataSet();
            adpater.Fill(ds);
            if (ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            else
                return null;
        }
        public bool CloseDatabase()
        {
            try
            {
                if (sql != null)
                {
                    sql.Close();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
