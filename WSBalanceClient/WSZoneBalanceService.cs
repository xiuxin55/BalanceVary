using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.ZoneBalanceService;

namespace WSBalanceClient
{
    public class WSZoneBalanceService
    {

        private static WSZoneBalanceService _instance;
        public static WSZoneBalanceService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSZoneBalanceService();
                }
                return _instance;
            }
        }
        public bool Add(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<bool>(
                client => client.Add(info)
                );
        }
        public bool Delete(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<bool>(
              client => client.Update(info)
              );
           
        }
        public ZoneBalance[] Select(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<ZoneBalance[]>(
            client => client.Select(info)
            );
        }
        public int SelectCount(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }

        public ZoneBalance[] CallTimeSpanProc(ZoneBalance info)
        {
            return ServiceInvokeHelper<ZoneBalanceServiceClient>.Invoke<ZoneBalance[]>(
         client => client.CallTimeSpanProc(info)
         );
        }
    }
}
