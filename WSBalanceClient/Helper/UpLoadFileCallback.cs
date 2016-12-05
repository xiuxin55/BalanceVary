using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using WSBalanceClient.ServiceFile;

namespace WSBalanceClient.Helper
{
    /// <summary>
    /// 上传文件回调
    /// </summary>
    public class UpLoadFileCallback : IServiceFileCallback
    {
        public void ShowFileHandleState(string message)
        {
            //MessageBox.Show(message);
        }
    }
}
