using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Common
{
    public class LogHelper
    {
        static LogHelper()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            System.IO.Stream stream = assembly.GetManifestResourceStream("Common.log4net_config.xml");
            log4net.Config.XmlConfigurator.Configure(stream);
        }
        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t">所在类</param>
        /// <param name="ex">错误对象</param>
        #region static void WriteLog(Type t, Exception ex)

        public static void WriteLog(Type t, Exception ex)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error("Error", ex);
        }

        #endregion

        /// <summary>
        /// 输出日志到Log4Net
        /// </summary>
        /// <param name="t">所在类</param>
        /// <param name="msg">错误信息</param>
        #region static void WriteLog(Type t, string msg)

        public static void WriteLog(Type t, string msg)
        {
            log4net.ILog log = log4net.LogManager.GetLogger(t);
            log.Error(msg);
        }
        #endregion
    }
}
