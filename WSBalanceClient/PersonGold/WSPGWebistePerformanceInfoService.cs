using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.PGWebistePerformanceInfoService;

namespace WSBalanceClient
{
    public class WSPGWebistePerformanceInfoService
    {
       
        private static WSPGWebistePerformanceInfoService _instance;
        public static WSPGWebistePerformanceInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSPGWebistePerformanceInfoService();
                }
                return _instance;
            }
        }
        //public bool Add( PGWebistePerformanceInfo info)
        //{
        //    return ServiceInvokeHelper<PGWebistePerformanceInfoServiceClient>.Invoke<bool>(
        //        client=>client.Add(info)
        //        );
        //}
        //public bool Delete(PGWebistePerformanceInfo info)
        //{
        //    return ServiceInvokeHelper<PGWebistePerformanceInfoServiceClient>.Invoke<bool>(
        //       client => client.Delete(info)
        //       );
        //}
        //public bool Update(PGWebistePerformanceInfo info)
        //{
        //    return ServiceInvokeHelper<PGWebistePerformanceInfoServiceClient>.Invoke<bool>(
        //       client => client.Update(info)
        //       );
        //}
        public PGWebistePerformanceInfo[] Select(PGWebistePerformanceInfo info)
        {
            return ServiceInvokeHelper<PGWebistePerformanceInfoServiceClient>.Invoke<PGWebistePerformanceInfo[]>(
             client => client.Select(info)
             );
        }

        public int SelectCount(PGWebistePerformanceInfo info)
        {
            return ServiceInvokeHelper<PGWebistePerformanceInfoServiceClient>.Invoke<int>(
             client => client.SelectCount(info)
             );
        }
    }
}
