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
    public class WebsiteInfoService : IWebsiteInfoService
    {
        WebsiteInfoBLL bll = new WebsiteInfoBLL();
        public bool Add(WebsiteInfo info)
        {
            return bll.Add(info);
        }

        public bool Delete(WebsiteInfo info)
        {
            return bll.Delete(info);
        }

        public List<WebsiteInfo> Select(WebsiteInfo info)
        {
            return bll.Select(info);
        }

        public bool Update(WebsiteInfo info)
        {
            return bll.Update(info);
        }
    }
}
