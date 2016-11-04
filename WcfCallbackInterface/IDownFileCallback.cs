using AuthorizationModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfCallbackInterface
{
    /// <summary>
    /// 下载文件回调接口
    /// </summary>
    public interface IDownFileCallback
    {
        [OperationContract]
        void DownLoadFileNoftiy(DownFileResult result);
    }
}
