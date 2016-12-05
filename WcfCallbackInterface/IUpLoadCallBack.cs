using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WcfCallbackInterface
{
    /// <summary>
    /// 上传文件回调
    /// </summary>
    public interface  IUpLoadCallBack
    {
        [OperationContract(IsOneWay = true)]
        void ShowFileHandleState(string message);
    }
}
