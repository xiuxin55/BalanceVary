using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BalanceReport.Common
{
    public class CommonLog
    {
        private static CommonLog _instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static CommonLog Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonLog();
                }
                return CommonLog._instance;
            }
        }
        public void WriteLog(List<string> logs,string filename)
        {
            filename=AppDomain.CurrentDomain.BaseDirectory+filename ;
            if (File.Exists(filename))
            {
                File.AppendAllLines(filename, logs);
                return;
            }
            else
            {
                //File.Create(filename);
                File.AppendAllLines(filename, logs);
                return;
            }
        }
    }
}
