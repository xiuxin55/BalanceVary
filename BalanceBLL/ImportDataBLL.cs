﻿using BalanceDAL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceBLL
{
    public class ImportDataBLL : BalanceBaseBLL<ImportDataInfo, ImportDataDAL>
    {
        public void ImportData()
        {
            dal.ImportData();
        }
    }
}
