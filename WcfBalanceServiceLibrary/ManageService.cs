using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    public class ManageService
    {
        private static ManageService _instance;
        private static object lockobj=new object();
        public static ManageService Instance
        {
            get
            {
                lock (lockobj)
                {
                    if (_instance == null)
                    {
                        _instance = new ManageService();
                    }
                }
                return _instance;
            }
        }

        private Dictionary<string, ServiceHost> ServiceHostManager = new Dictionary<string, ServiceHost>();

        public bool StartService(string classname,Type t)
        {
            ServiceHost host = new ServiceHost(t);
            host.Open();
            ServiceHostManager[classname] = host;
            return true;
        }

        public void CloseService(string classname)
        {
            ServiceHost host;
            if(ServiceHostManager.TryGetValue(classname,out host))
            {
                host.Close();
            }
        }
    }
}
