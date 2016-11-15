using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WSBalanceClient.DepartmentInfoService;

namespace WSBalanceClient
{
    public class WSDepartmentInfoService
    {
       
        private static WSDepartmentInfoService _instance;
        public static WSDepartmentInfoService Instance
        {
            get
            {
                if (_instance ==null)
                {
                    _instance = new WSDepartmentInfoService();
                }
                return _instance;
            }
        }
        public bool Add( DepartmentInfo info)
        {
            return ServiceInvokeHelper<DepartmentInfoServiceClient>.Invoke<bool>(
                client=>client.Add(info)
                );
        }
        public bool Delete(DepartmentInfo info)
        {
            return ServiceInvokeHelper<DepartmentInfoServiceClient>.Invoke<bool>(
               client => client.Delete(info)
               );
        }
        public bool Update(DepartmentInfo info)
        {
            return ServiceInvokeHelper<DepartmentInfoServiceClient>.Invoke<bool>(
               client => client.Update(info)
               );
        }
        public DepartmentInfo[] Select(DepartmentInfo info)
        {
            return ServiceInvokeHelper<DepartmentInfoServiceClient>.Invoke<DepartmentInfo[]>(
             client => client.Select(info)
             );
        }
        //public int SelectCount(DepartmentInfo info)
        //{
        //    return ServiceInvokeHelper<DepartmentInfoServiceClient>.Invoke<int>(
        //      client => client.SelectCount(info)
        //      );
        //}

    }
}
