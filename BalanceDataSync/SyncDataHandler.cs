﻿using Common.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class SyncDataHandler : ISyncDataHandler
    {
        public void ReadData()
        {
            if (Directory.Exists(CommonDataServer.UploadFileServerPath))
            {

            }
        }
        /// <summary>
        /// 导入日数据
        /// </summary>
        public  void ImportDayData()
        {

        }
        /// <summary>
        /// 导入月数据
        /// </summary>
        public  void ImportMonthData()
        {

        }
    }
}
