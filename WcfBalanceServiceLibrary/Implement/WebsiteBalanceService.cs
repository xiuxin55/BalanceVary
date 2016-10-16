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
    /// 网点管理服务
    /// </summary>
    public class WebsiteBalanceService : IWebsiteBalanceService
    {
        WebsiteBalanceBLL bll = new WebsiteBalanceBLL();
        public bool Add(WebsiteBalance info)
        {
            return bll.Add(info);
        }

        public bool Delete(WebsiteBalance info)
        {
            return bll.Delete(info);
        }

        public List<WebsiteBalance> Select(WebsiteBalance info)
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

        public bool Update(WebsiteBalance info)
        {
            return bll.Update(info);
        }
        public int SelectCount(WebsiteBalance info)
        {
            return bll.SelectCount(info);
        }

        public List<WebsiteBalance> CallTimeSpanProc(WebsiteBalance t)
        {
            try
            {
                return bll.CallTimeSpanProc(t);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
            
        }
    }
}
