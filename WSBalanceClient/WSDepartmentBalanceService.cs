using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.DepartmentBalanceService;

namespace WSBalanceClient
{
    public class WSDepartmentBalanceService
    {

        private static WSDepartmentBalanceService _instance;
        public static WSDepartmentBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSDepartmentBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public DepartmentBalance[] Select(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<DepartmentBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
        public DepartmentBalance[] CallTimeSpanProc(DepartmentBalance info)
        {
            return ServiceInvokeHelper<DepartmentBalanceServiceClient>.Invoke<DepartmentBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
