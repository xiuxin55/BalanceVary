using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.CustomerManagerBalanceService;

namespace WSBalanceClient
{
    public class WSCustomerManagerBalanceService
    {

        private static WSCustomerManagerBalanceService _instance;
        public static WSCustomerManagerBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSCustomerManagerBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public CustomerManagerBalance[] Select(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<CustomerManagerBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
        public CustomerManagerBalance[] CallTimeSpanProc(CustomerManagerBalance info)
        {
            return ServiceInvokeHelper<CustomerManagerBalanceServiceClient>.Invoke<CustomerManagerBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
