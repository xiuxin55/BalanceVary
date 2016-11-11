using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Server
{
    /// <summary>
    /// 服务端常量
    /// </summary>
    public class CommonDataServer
    {
        /// <summary>
        /// 默认上传文件存储路径
        /// </summary>
        public  static string UploadFileServerPath = AppDomain.CurrentDomain.BaseDirectory + "UpLoadFile\\";
        public static string CityZoneCode = "市行";
        public static string CountyZoneCode = "县行";
        public static int AccountTypeRegular = 0;//0定期
        public static int AccountTypeUnRegular = 1;//1活期
        public static string AutoUpdatePath = System.AppDomain.CurrentDomain.BaseDirectory + @"\AutoUpdate\";//自动更新文件所放的位置
        public static string AutoUpdateConfigFile = "UpdateFileList.xml";
        public static string TemplateFilePath = System.AppDomain.CurrentDomain.BaseDirectory + @"\TemplateFile\";//自动更新文件所放的位置
    }
}
