﻿using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDAL
{
    public class AccountInfoDAL : BaseDAL<AccountInfo>
    {
        public AccountInfoDAL()
        {
            DefaultKey = "AccountInfo";
        }
      
    }
}