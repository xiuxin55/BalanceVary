using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.PGPersonAllocateInfoService;

namespace WSBalanceClient
{
    public class WSPGPersonAllocateInfoService
    {
       
        private static WSPGPersonAllocateInfoService _instance;
        public static WSPGPersonAllocateInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSPGPersonAllocateInfoService();
                }
                return _instance;
            }
        }
        public bool Add( PGPersonAllocateInfo info)
        {
            return ServiceInvokeHelper<PGPersonAllocateInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(PGPersonAllocateInfo info)
        {
            return ServiceInvokeHelper<PGPersonAllocateInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(PGPersonAllocateInfo info)
        {
            return ServiceInvokeHelper<PGPersonAllocateInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public PGPersonAllocateInfo[] Select(PGPersonAllocateInfo info)
        {
            return ServiceInvokeHelper<PGPersonAllocateInfoServiceClient>.Invoke<PGPersonAllocateInfo[]>(
             client => client.Select(info)
             );
        }

        public int SelectCount(PGPersonAllocateInfo info)
        {
            return ServiceInvokeHelper<PGPersonAllocateInfoServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
    }
}
