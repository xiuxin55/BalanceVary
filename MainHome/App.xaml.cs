using BalanceReport;
using Common;
using Common.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Xml;

namespace MainHome
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            
           // this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            
            //try
            //{
            //    if (e.Args.Length == 0)
            //    {


            //        AutoUpdate update = new AutoUpdate();
            //        if (update.CheckAutoUpdate())
            //        {
            //            Process.Start(CommonDataClient.AutoUpdatePath + CommonDataClient.AutoUpdateExeFile);
            //            Environment.Exit(0);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    LogHelper.WriteLog(typeof(Window), ex);
            //    //throw ex;
            //}
            Login bw = new Login();
            bw.Show();
           




        }
      
        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            throw e.Exception;
        }
    }
}
