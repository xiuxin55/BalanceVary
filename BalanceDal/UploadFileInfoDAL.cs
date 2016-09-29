using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class UploadFileInfoDAL : BalanceDAL<UploadFileInfo>
    {
        public UploadFileInfoDAL()
        {
            DefaultKey = "UploadFileInfo";
        }
      
    }
}
