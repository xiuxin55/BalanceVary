using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.SystemSetInfoService;

namespace WSBalanceClient
{
    public class WSSystemSetInfoService
    {
       
        private static WSSystemSetInfoService _instance;
        public static WSSystemSetInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSSystemSetInfoService();
                }
                return _instance;
            }
        }
        public bool Add( SystemSetInfo info)
        {
            return ServiceInvokeHelper<SystemSetInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(SystemSetInfo info)
        {
            return ServiceInvokeHelper<SystemSetInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(SystemSetInfo info)
        {
            return ServiceInvokeHelper<SystemSetInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public SystemSetInfo[] Select(SystemSetInfo info)
        {
            return ServiceInvokeHelper<SystemSetInfoServiceClient>.Invoke<SystemSetInfo[]>(
             client => client.Select(info)
             );
        }
        public int SelectCount(SystemSetInfo info)
        {
            return ServiceInvokeHelper<SystemSetInfoServiceClient>.Invoke<int>(
              client => client.SelectCount(info)
              );
        }

    }
}
