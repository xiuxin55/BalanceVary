using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.CompanyBalanceService;

namespace WSBalanceClient
{
    public class WSCompanyBalanceService
    {

        private static WSCompanyBalanceService _instance;
        public static WSCompanyBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSCompanyBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public CompanyBalance[] Select(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<CompanyBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }

        public CompanyBalance[] CallTimeSpanProc(CompanyBalance info)
        {
            return ServiceInvokeHelper<CompanyBalanceServiceClient>.Invoke<CompanyBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
