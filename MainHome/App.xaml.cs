using BalanceReport;
using Common.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Windows;

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
            this.DispatcherUnhandledException += App_DispatcherUnhandledException;
            try
            {
                Assembly abll = Assembly.LoadFrom(CommonDataClient.AutoUpdateDLLPath + CommonDataClient.AutoUpdateDLLFile);
                Window frmAutoUpdate = (Window)abll.CreateInstance("AutoUpdate.AutoUpdateWindow");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Login bw = new Login();
            bw.Show();




        }

        private void App_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            throw e.Exception;
        }
    }
}
