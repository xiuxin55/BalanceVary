using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common.Client
{
    /// <summary>
    /// 客户端常量
    /// </summary>
    public class CommonDataClient
    {
        public static string AutoUpdatePath = System.AppDomain.CurrentDomain.BaseDirectory ;//自动更新文件所放的位置
        public static string AutoUpdateDLLPath = System.AppDomain.CurrentDomain.BaseDirectory + @"\AutoUpdate\";//自动更新文件所放的位置
        public static string AutoUpdateDLLFile = "AutoUpdate.dll";
        public static string AutoUpdateConfigFile = "UpdateFileList.xml";
    }
}
