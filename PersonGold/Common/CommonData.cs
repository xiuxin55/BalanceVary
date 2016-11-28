using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BalanceReport.Models;
namespace BalanceReport.Common
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
        /// <summary>
        /// 0一天 1一个月
        /// </summary>
        public int ExcelContentType { get; set; }
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
        private string _importTime;

        public string ImportTime
        {
            get
            {
                if (_importTime == null)
                {
                    _importTime = DateTime.Now.ToString("yyyy-MM-dd");
                }
                return _importTime;
            }
        
            set { _importTime = value; }
        }
        #endregion
    }
}
