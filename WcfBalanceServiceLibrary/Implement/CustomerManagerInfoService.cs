using BalanceBLL;
using BalanceModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“CustomerManagerInfoService”。
    /// <summary>
    /// 客户经理管理服务
    /// </summary>
    public class CustomerManagerInfoService : ICustomerManagerInfoService
    {
        CustomerManagerInfoBLL bll = new CustomerManagerInfoBLL();
        public bool Add(CustomerManagerInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(CustomerManagerInfo info)
        {
            return bll.Delete(info);
        }

        public List<CustomerManagerInfo> Select(CustomerManagerInfo info)
        {
            try
            {
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CustomerManagerInfo), ex);
                return new List<CustomerManagerInfo>();
            }
           
        }
        public int SelectCount(CustomerManagerInfo info)
        {
            try
            {
                return bll.SelectCount(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(CustomerManagerInfoService), ex);
                return 0;
            }

        }
        public bool Update(CustomerManagerInfo info)
        {
            return bll.Update(info);
        }
    }
}
