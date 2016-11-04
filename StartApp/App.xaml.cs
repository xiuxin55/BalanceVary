using MainHome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;

namespace StartApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                 string path = System.AppDomain.CurrentDomain.BaseDirectory + @"\AutoUpdate\AutoUpdate.dll";
                 Assembly abll = Assembly.LoadFrom(path);
                 Window frmAutoUpdate = (Window)abll.CreateInstance("AutoUpdate.AutoUpdateWindow");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            Process p = Process.Start(System.AppDomain.CurrentDomain.BaseDirectory+ "MainHome.exe");
            
        }
    }
}
