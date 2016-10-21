using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceReportDao.Common
{
    public class CommonData
    {
        private static CommonData _instance;
        /// <summary>
        /// 单例
        /// </summary>
        public static CommonData Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CommonData();
                }
                return CommonData._instance;
            }
        }
        #region 属性
        public string ConnectStr
        {
            get
            {
                return ConfigReader.GetConfigValue(AppDomain.CurrentDomain.BaseDirectory + "Config.xml", "connectstring");
            }
        }
        public string WebUrlStr
        {
            get
            {
                return ConfigReader.GetConfigValue(AppDomain.CurrentDomain.BaseDirectory + "Config.xml", "weburl");
                
            }
        }
        #endregion
    }
}
