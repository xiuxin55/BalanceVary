using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlMaps
{
    public class CommonData
    {
        /// <summary>
        /// ibatis config位置
        /// </summary>
        public  const string  BalanceSqlConfig= @"Configure.sqlmap.config";
        private static string _DBConnetionString;
        /// <summary>
        /// 根据ibatis配置文件解析，数据库连接字符串，用于直连数据库
        /// </summary>
        public static string  DBConnetionString
        {
            get
            {
                return _DBConnetionString;
            }
            set
            {
                if(!string.IsNullOrWhiteSpace(value))
                {
                    // con.ConnectionString = "server=505-03;database=ttt;user=sa;pwd=123";
                    //data source=localhost;database=BalanceReport;user id=sa;password=123;connection reset=false;connection lifetime=5; min pool size=1; max pool size=50
                    string server = value.Split(';')[0].Split('=')[1];
                    string database = value.Split(';')[1].Split('=')[1];
                    string user = value.Split(';')[2].Split('=')[1];
                    string pwd = value.Split(';')[3].Split('=')[1];
                    _DBConnetionString = string.Format("server={0};database={1};user={2};pwd={3}", server, database, user, pwd);
                }
                else
                {
                    _DBConnetionString = "";
                }
            } 
        }
    }
}
