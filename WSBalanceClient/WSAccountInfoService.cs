using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.AccountInfoService;

namespace WSBalanceClient
{
    public class WSAccountInfoService
    {
       
        private static WSAccountInfoService _instance;
        public static WSAccountInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSAccountInfoService();
                }
                return _instance;
            }
        }
        public bool Add( AccountInfo info)
        {
            return ServiceInvokeHelper<AccountInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(AccountInfo info)
        {
            return ServiceInvokeHelper<AccountInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(AccountInfo info)
        {
            return ServiceInvokeHelper<AccountInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public AccountInfo[] Select(AccountInfo info)
        {
            return ServiceInvokeHelper<AccountInfoServiceClient>.Invoke<AccountInfo[]>(
             client => client.Select(info)
             );
        }
        public int SelectCount(AccountInfo info)
        {
            return ServiceInvokeHelper<AccountInfoServiceClient>.Invoke<int>(
              client => client.SelectCount(info)
              );
        }

    }
}
