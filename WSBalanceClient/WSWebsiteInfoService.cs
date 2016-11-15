using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.WebsiteInfoService;

namespace WSBalanceClient
{
    public class WSWebsiteInfoService
    {
       
        private static WSWebsiteInfoService _instance;
        public static WSWebsiteInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSWebsiteInfoService();
                }
                return _instance;
            }
        }
        public bool Add( WebsiteInfo info)
        {
            return ServiceInvokeHelper<WebsiteInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(WebsiteInfo info)
        {
            return ServiceInvokeHelper<WebsiteInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(WebsiteInfo info)
        {
            return ServiceInvokeHelper<WebsiteInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public WebsiteInfo[] Select(WebsiteInfo info)
        {
            return ServiceInvokeHelper<WebsiteInfoServiceClient>.Invoke<WebsiteInfo[]>(
             client => client.Select(info)
             );
        }
       

    }
}
