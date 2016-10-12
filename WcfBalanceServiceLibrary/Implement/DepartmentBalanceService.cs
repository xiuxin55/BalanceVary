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
    /// 部门余额服务
    /// </summary>
    public class DepartmentBalanceService : IDepartmentBalanceService
    {
        DepartmentBalanceBLL bll = new DepartmentBalanceBLL();
        public bool Add(DepartmentBalance info)
        {
            return bll.Add(info);
        }

        public bool Delete(DepartmentBalance info)
        {
            return bll.Delete(info);
        }

        public List<DepartmentBalance> Select(DepartmentBalance info)
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

        public bool Update(DepartmentBalance info)
        {
            return bll.Update(info);
        }
        public int SelectCount(DepartmentBalance info)
        {
            return bll.SelectCount(info);
        }
    }
}
