using AuthorizationBLL;
using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfAuthorizationServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“FunctionInfoService”。
    /// <summary>
    /// 功能管理服务
    /// </summary>
    public class FunctionInfoService : IFunctionInfoService
    {
        FunctionInfoBLL bll = new FunctionInfoBLL();
        public bool Add(FunctionInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(FunctionInfo info)
        {
            return bll.Delete(info);
        }

        public List<FunctionInfo> Select(FunctionInfo info)
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

        public bool Update(FunctionInfo info)
        {
            return bll.Update(info);
        }
    }
}
