using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.PGPersonInfoService;

namespace WSBalanceClient
{
    public class WSPGPersonInfoService
    {
       
        private static WSPGPersonInfoService _instance;
        public static WSPGPersonInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSPGPersonInfoService();
                }
                return _instance;
            }
        }
        public bool Add( PGPersonInfo info)
        {
            return ServiceInvokeHelper<PGPersonInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(PGPersonInfo info)
        {
            return ServiceInvokeHelper<PGPersonInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(PGPersonInfo info)
        {
            return ServiceInvokeHelper<PGPersonInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public PGPersonInfo[] Select(PGPersonInfo info)
        {
            return ServiceInvokeHelper<PGPersonInfoServiceClient>.Invoke<PGPersonInfo[]>(
             client => client.Select(info)
             );
        }

        public int SelectCount(PGPersonInfo info)
        {
            return ServiceInvokeHelper<PGPersonInfoServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
    }
}
