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
    /// 部门管理服务
    /// </summary>
    public class DepartmentInfoService : IDepartmentInfoService
    {
        DepartmentInfoBLL bll = new DepartmentInfoBLL();
        public bool Add(DepartmentInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(DepartmentInfo info)
        {
            return bll.Delete(info);
        }

        public List<DepartmentInfo> Select(DepartmentInfo info)
        {
            return bll.Select(info);
        }

        public bool Update(DepartmentInfo info)
        {
            return bll.Update(info);
        }
    }
}
