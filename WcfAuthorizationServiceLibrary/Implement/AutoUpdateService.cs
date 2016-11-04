using AuthorizationBLL;
using AuthorizationModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“UserInfoService”。
    /// <summary>
    /// 用户管理服务
    /// </summary>
    public class AutoUpdateService : IAutoUpdateService
    {
        AutoUpdateBLL bll = new AutoUpdateBLL();

        public List<AutoUpdateModel> CheckAutoUpdate(List<AutoUpdateModel> list, out bool IsHasUpdate)
        {
           return bll.CheckAutoUpdate(list,out IsHasUpdate);
        }

        public DownFileResult DownLoadFile(AutoUpdateModel filedata)
        {
            try
            {
                return bll.DownLoadFile(filedata);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(AutoUpdateService), ex);
                return null;
            }
            
        }

    }
}
