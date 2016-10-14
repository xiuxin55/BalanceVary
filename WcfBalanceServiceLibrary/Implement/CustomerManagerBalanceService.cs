using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BalanceModel;
using BalanceBLL;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WebsiteInfoService”。
    /// <summary>
    /// 客户经理余额服务
    /// </summary>
    public class CustomerManagerBalanceService : ICustomerManagerBalanceService
    {
        CustomerManagerBalanceBLL bll = new CustomerManagerBalanceBLL();
        public bool Add(CustomerManagerBalance info)
        {
            return bll.Add(info);
        }

        public bool Delete(CustomerManagerBalance info)
        {
            return bll.Delete(info);
        }

        public List<CustomerManagerBalance> Select(CustomerManagerBalance info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }

        public bool Update(CustomerManagerBalance info)
        {
            return bll.Update(info);
        }
        public int SelectCount(CustomerManagerBalance info)
        {
            return bll.SelectCount(info);
        }

        public List<CustomerManagerBalance> CallTimeSpanProc(CustomerManagerBalance t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
