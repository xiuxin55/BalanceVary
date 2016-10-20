﻿using System;
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
    }
}
