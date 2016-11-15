using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.AccountBalanceService;

namespace WSBalanceClient
{
    public class WSAccountBalanceService
    {

        private static WSAccountBalanceService _instance;
        public static WSAccountBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSAccountBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public AccountBalance[] Select(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<AccountBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }

        public AccountBalance[] SelectByDepartment(DepartmentBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<AccountBalance[]>(
           client => client.SelectByDepartment(info)
           );
        }
        public int SelectByDepartmentCount(DepartmentBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<int>(
            client => client.SelectByDepartmentCount(info)
            );
        }
        public AccountBalance[] CallTimeSpanProc(AccountBalance info)
        {
            return ServiceInvokeHelper<AccountBalanceServiceClient>.Invoke<AccountBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
