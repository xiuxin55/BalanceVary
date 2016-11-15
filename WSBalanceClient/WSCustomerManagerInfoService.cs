using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.CustomerManagerInfoService;

namespace WSBalanceClient
{
    public class WSCustomerManagerInfoService
    {

        private static WSCustomerManagerInfoService _instance;
        public static WSCustomerManagerInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSCustomerManagerInfoService();
                }
                return _instance;
            }
        }
        public bool Add(CustomerManagerInfo info)
        {
            return ServiceInvokeHelper<CustomerManagerInfoServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(CustomerManagerInfo info)
        {
            return ServiceInvokeHelper<CustomerManagerInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(CustomerManagerInfo info)
        {
            return ServiceInvokeHelper<CustomerManagerInfoServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public CustomerManagerInfo[] Select(CustomerManagerInfo info)
        {
            return ServiceInvokeHelper<CustomerManagerInfoServiceClient>.Invoke<CustomerManagerInfo[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(CustomerManagerInfo info)
        {
            return ServiceInvokeHelper<CustomerManagerInfoServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
 
    }
}
