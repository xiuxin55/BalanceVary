using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.SalaryInfoService;

namespace WSBalanceClient
{
    public class WSSalaryInfoService
    {
       
        private static WSSalaryInfoService _instance;
        public static WSSalaryInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSSalaryInfoService();
                }
                return _instance;
            }
        }
        public bool Add( SalaryInfo info)
        {
            return ServiceInvokeHelper<SalaryInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(SalaryInfo info)
        {
            return ServiceInvokeHelper<SalaryInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(SalaryInfo info)
        {
            return ServiceInvokeHelper<SalaryInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public SalaryInfo[] Select(SalaryInfo info)
        {
            return ServiceInvokeHelper<SalaryInfoServiceClient>.Invoke<SalaryInfo[]>(
             client => client.Select(info)
             );
        }
        public int SelectCount(SalaryInfo info)
        {
            return ServiceInvokeHelper<SalaryInfoServiceClient>.Invoke<int>(
              client => client.SelectCount(info)
              );
        }

    }
}
