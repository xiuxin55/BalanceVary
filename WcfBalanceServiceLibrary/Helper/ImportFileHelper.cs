using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WcfBalanceServiceLibrary.Helper
{
    public class ImportFileHelper
    {
        public static  void ImportFileTrigger(UploadFileInfo uploadfileinfo)
        {
            if (CommonEvent.FileUploadedCalculateEvent != null)
            {
                CommonEvent.FileUploadedCalculateEvent(uploadfileinfo);
            }
            if (CommonEvent.FileUploadedCalculateDayEvent != null)
            {
                CommonEvent.FileUploadedCalculateDayEvent(uploadfileinfo);
            }
            if (CommonEvent.FileUploadedCustomerLinkEvent != null)
            {
                CommonEvent.FileUploadedCustomerLinkEvent(uploadfileinfo);
            }
            if (CommonEvent.FileUploadedAccountAndNameLinkEvent != null)
            {
                CommonEvent.FileUploadedAccountAndNameLinkEvent(uploadfileinfo);
            }

            if (CommonEvent.FileUploadedSalaryEvent != null)
            {
                //薪资数据导入触发
                CommonEvent.FileUploadedSalaryEvent(uploadfileinfo);
            }
            if (CommonEvent.PersonInfoDataEvent != null)
            {
                //个金人员信息数据导入触发
                CommonEvent.PersonInfoDataEvent(uploadfileinfo);
            }
            if (CommonEvent.PGDebitCardInfoDataEvent != null)
            {
                //个金储蓄卡信息数据导入触发
                CommonEvent.PGDebitCardInfoDataEvent(uploadfileinfo);
            }
            if (CommonEvent.PGInsuranceInfoDataEvent != null)
            {
                //个金保险信息数据导入触发
                CommonEvent.PGInsuranceInfoDataEvent(uploadfileinfo);
            }
            if (CommonEvent.PGCreditCardInfoInfoDataEvent != null)
            {
                //个金基础数据信息数据导入触发
                CommonEvent.PGCreditCardInfoInfoDataEvent(uploadfileinfo);
            }

           

            if (CommonEvent.PGCardBaseDataEvent != null)
            {
                //个金储蓄基础数据导入触发
                CommonEvent.PGCardBaseDataEvent(uploadfileinfo);
            }
            if (CommonEvent.PGInsuranceBaseDataEvent != null)
            {
                //个金保险基础数据导入触发
                CommonEvent.PGInsuranceBaseDataEvent(uploadfileinfo);
            }

        }
    }
}
