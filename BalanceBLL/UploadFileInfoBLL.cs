using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class UploadFileInfoBLL : BalanceBaseBLL<UploadFileInfo, UploadFileInfoDAL>
    {
        public void BatchUpdate(List<UploadFileInfo> list)
        {
            dal.BatchUpdate(list);
        }
    }
}
