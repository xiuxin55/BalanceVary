using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.AccountAndNameLinkInfoService;

namespace WSBalanceClient
{
    public class WSAccountAndNameLinkInfoService
    {
       
        private static WSAccountAndNameLinkInfoService _instance;
        public static WSAccountAndNameLinkInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSAccountAndNameLinkInfoService();
                }
                return _instance;
            }
        }
        public bool Add(AccountAndNameLinkInfo info)
        {
            return ServiceInvokeHelper<AccountAndNameLinkInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(AccountAndNameLinkInfo info)
        {
            return ServiceInvokeHelper<AccountAndNameLinkInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(AccountAndNameLinkInfo info)
        {
            return ServiceInvokeHelper<AccountAndNameLinkInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public AccountAndNameLinkInfo[] Select(AccountAndNameLinkInfo info)
        {
            return ServiceInvokeHelper<AccountAndNameLinkInfoServiceClient>.Invoke<AccountAndNameLinkInfo[]>(
             client => client.Select(info)
             );
        }
        public int SelectCount(AccountAndNameLinkInfo info)
        {
            return ServiceInvokeHelper<AccountAndNameLinkInfoServiceClient>.Invoke<int>(
              client => client.SelectCount(info)
              );
        }

    }
}
