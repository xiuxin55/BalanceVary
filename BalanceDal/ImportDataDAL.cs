using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;

namespace BalanceDAL
{
    public class ImportDataDAL : BalanceDAL<ImportDataInfo>
    {
        public ImportDataDAL()
        {
            DefaultKey = "ImportDataInfo";
        }
        public void ImportData()
        {
            try
            {
                SqlMap.BeginTransaction();
                ImportZoneData();
                ImportWebsiteData();
                ImportCompanyData();
                ImportAccountData();
                SqlMap.CommitTransaction();
            }
            catch (Exception ex)
            {
                SqlMap.RollBackTransaction();
                throw ex;
            }
            
        }
        /// <summary>
        /// 导入区域 市、县行结果数据
        /// </summary>
        private  void ImportZoneData()
        {

        }
        /// <summary>
        /// 导入网点计算后的数据
        /// </summary>
        private void ImportWebsiteData()
        {

        }
        /// <summary>
        /// 导入公司计算后的数据
        /// </summary>
        private void ImportCompanyData()
        {

        }
        /// <summary>
        /// 导入账户计算后的数据
        /// </summary>
        private void ImportAccountData()
        {

        }

    }
}
