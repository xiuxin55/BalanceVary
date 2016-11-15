using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.WebsiteBalanceService;

namespace WSBalanceClient
{
    public class WSWebsiteBalanceService
    {

        private static WSWebsiteBalanceService _instance;
        public static WSWebsiteBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSWebsiteBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public WebsiteBalance[] Select(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<WebsiteBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }

        public WebsiteBalance[] CallTimeSpanProc(WebsiteBalance info)
        {
            return ServiceInvokeHelper<WebsiteBalanceServiceClient>.Invoke<WebsiteBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
