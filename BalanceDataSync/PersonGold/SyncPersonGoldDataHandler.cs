using BalanceBLL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceDataSync
{
    public partial class SyncDataHandler
    {
        List<PGPersonInfo> ImportPGPersonInfoDataList = new List<PGPersonInfo>();
        List<PGDebitCardInfo> ImportPGDebitCardInfoDataList = new List<PGDebitCardInfo>();
        List<PGInsuranceInfo> ImportPGInsuranceInfoDataList = new List<PGInsuranceInfo>();
        List<PGCreditCardInfo> ImportPGCreditCardInfoDataList = new List<PGCreditCardInfo>();
 
        public void ImportPGPersonInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("PGPersonInfo"));
            foreach (var item in filelist)
            {
                try
                {

                    DateTime time ;
                    if (item.FileDateTime==null)
                    {
                        time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM") + "-01");
                    }
                    else
                    {
                        time = DateTime.Parse(item.FileDateTime.Value.ToString("yyyy-MM") + "-01");
                    }
                    ImportPGPersonInfoDataList = ReadPersonExcel.ReadPGPersonInfoData(item.FilePath + item.FileName);
                    if (ImportPGPersonInfoDataList.Count == 0)
                    {
                        return;
                    }
                    PGPersonInfoBLL bll = new PGPersonInfoBLL();
                    bll.Delete(null);
                    foreach (var model in ImportPGPersonInfoDataList)
                    {
                        bll.Add(model);
                    }
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }

        #region 储蓄卡导入处理
        public void ImportPGDebitCardInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("PGDebitCardInfo"));
            foreach (var item in filelist)
            {
                try
                {

                    DateTime time;
                    if (item.FileDateTime == null)
                    {
                        time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        time = DateTime.Parse(item.FileDateTime.Value.ToString("yyyy-MM-dd"));
                    }
                    ImportPGDebitCardInfoDataList = ReadPersonExcel.ReadPGDebitCardInfoData(item.FilePath + item.FileName);
                    if (ImportPGDebitCardInfoDataList.Count == 0)
                    {
                        item.FileState = 2;
                        item.FileException = "未获取到数据";
                        return;
                    }
                    CalculateDebitCardInfo(time);
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
        private void CalculateDebitCardInfo(DateTime importtime)
        {
            PGDebitCardInfoBLL bll = new PGDebitCardInfoBLL();
            //前一天的储蓄卡数据
            List<PGDebitCardInfo> PrePGDebitCardInfoDataList = bll.Select(new PGDebitCardInfo() { DataTime = importtime.AddDays(-1) });
            bll.Delete(new PGDebitCardInfo() { DataTime = importtime });
            foreach (var model in ImportPGDebitCardInfoDataList)
            {
                PGDebitCardInfo predata = null;
                if (string.IsNullOrWhiteSpace(model.NewWebsiteID))
                {
                    if (!string.IsNullOrWhiteSpace(model.WebsiteID))
                    {
                        predata = PrePGDebitCardInfoDataList.FirstOrDefault(e => e.WebsiteID == model.WebsiteID);
                    }

                }
                else
                {
                    predata = PrePGDebitCardInfoDataList.FirstOrDefault(e => e.NewWebsiteID == model.NewWebsiteID);
                }


                if (predata != null && (!string.IsNullOrWhiteSpace(predata.WebsiteID) || !string.IsNullOrWhiteSpace(predata.NewWebsiteID)))
                {
                    model.DifferenceValue = model.CurrentDayBalance - predata.CurrentDayBalance ?? 0;
                }
                else
                {
                    model.DifferenceValue = 0;
                }
                model.DataTime = importtime;
                bll.Add(model);
            }
        }
        #endregion

        #region 保险导入处理
        public void ImportPGInsuranceInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("PGInsuranceInfo"));
            foreach (var item in filelist)
            {
                try
                {

                    DateTime time;
                    if (item.FileDateTime == null)
                    {
                        time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        time = DateTime.Parse(item.FileDateTime.Value.ToString("yyyy-MM-dd"));
                    }
                    ImportPGInsuranceInfoDataList = ReadPersonExcel.ReadPGInsuranceInfoData(item.FilePath + item.FileName);
                    if (ImportPGInsuranceInfoDataList.Count == 0)
                    {
                        item.FileState = 2;
                        item.FileException = "未获取到数据";
                        return;
                    }
                    CalculateInsuranceInfo(time);
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
        private void CalculateInsuranceInfo(DateTime importtime)
        {
            PGInsuranceInfoBLL bll = new PGInsuranceInfoBLL();
            //前一天的保险数据
            //List<PGInsuranceInfo> PreDataList = bll.Select(new PGInsuranceInfo() { DataTime = importtime.AddDays(-1) });
            //bll.Delete(new PGInsuranceInfo() { DataTime = importtime });
            foreach (var model in ImportPGInsuranceInfoDataList)
            {
                //PGInsuranceInfo predata = null;
                //if (string.IsNullOrWhiteSpace(model.NewWebsiteID))
                //{
                //    if (!string.IsNullOrWhiteSpace(model.WebsiteID))
                //    {
                //        predata = PreDataList.FirstOrDefault(e => e.WebsiteID == model.WebsiteID);
                //    }

                //}
                //else
                //{
                //    predata = PreDataList.FirstOrDefault(e => e.NewWebsiteID == model.NewWebsiteID);
                //}


                //if (predata != null && (!string.IsNullOrWhiteSpace(predata.WebsiteID) || !string.IsNullOrWhiteSpace(predata.NewWebsiteID)))
                //{
                //    model.DifferenceValue = model.CurrentDayBalance - predata.CurrentDayBalance ?? 0;
                //    model.WholeBalance = model.CurrentDayBalance + predata.CurrentDayBalance ?? 0;
                //}
                //else
                //{
                //    model.DifferenceValue = 0;
                //}
                model.DataTime = importtime;
                bll.Add(model);
            }
        }
        #endregion


        #region 信用卡导入处理
        public void ImportPGCreditCardInfo()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("PGCreditCardInfo"));
            foreach (var item in filelist)
            {
                try
                {

                    DateTime time;
                    if (item.FileDateTime == null)
                    {
                        time = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd"));
                    }
                    else
                    {
                        time = DateTime.Parse(item.FileDateTime.Value.ToString("yyyy-MM-dd"));
                    }
                    ImportPGCreditCardInfoDataList = ReadPersonExcel.ReadPGCreditCardInfoData(item.FilePath + item.FileName);
                    if (ImportPGCreditCardInfoDataList.Count == 0)
                    {
                        item.FileState = 2;
                        item.FileException = "未获取到数据";
                        return;
                    }
                    CalculateCreditCardInfo();
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
        private void CalculateCreditCardInfo()
        {
            //PGCreditCardInfoBLL bll = new PGCreditCardInfoBLL();

            ////List<PGInsuranceInfo> PreDataList = bll.Select(new PGInsuranceInfo() { DataTime = importtime.AddDays(-1) });
            ////bll.Delete(new PGInsuranceInfo() { DataTime = importtime });
            //List<PGPersonAllocateInfo> allocateList = new List<PGPersonAllocateInfo>();
            ////需要更新的数据
            //List<PGPersonAllocateInfo> UpdateAllocateList = allocateList.ToList();
            //DateTime mintime = ImportPGCreditCardInfoDataList.Min(e => e.DataTime.Value);
            //DateTime maxtime = ImportPGCreditCardInfoDataList.Max(e => e.DataTime.Value);
            //ImportPGCreditCardInfoDataList.Sort(
            //    (x,y) =>
            //    {
            //        if (x.DataTime >= y.DataTime)
            //        {
            //            return 1;
            //        }
            //        else
            //        {
            //            return -1;
            //        }
            //    }
            //    );
            //Dictionary<string, List<PGPersonAllocateInfo>> AllocatedDic = new Dictionary<string, List<PGPersonAllocateInfo>>();
            //foreach (var item in allocateList)
            //{
            //    if(AllocatedDic.Keys.Contains(item.StaffCode))
            //    {
            //        AllocatedDic[item.StaffCode].Add(item);
            //    }
            //    else
            //    {
            //        AllocatedDic[item.StaffCode] = new List<PGPersonAllocateInfo>();
            //        AllocatedDic[item.StaffCode].Add(item);
            //    }
            //}
            //foreach (var model in ImportPGCreditCardInfoDataList)
            //{
            //    if (string.IsNullOrWhiteSpace(model.StaffCode))
            //    {
            //        UpdateAllocateList.Add(ConvertToPGPersonAllocateInfo(model));
            //    }
            //    else
            //    {
            //        List<PGPersonAllocateInfo> dicvalue;
            //        if(AllocatedDic.TryGetValue(model.StaffCode,out dicvalue))
            //        {
            //            PGPersonAllocateInfo pre = dicvalue.Find(e => e.DataTime.Value == model.DataTime.Value.AddDays(-1));
            //            PGPersonAllocateInfo curtemp = dicvalue.Find(e => e.DataTime.Value == model.DataTime.Value);
            //            var cur = curtemp ?? ConvertToPGPersonAllocateInfo(model);
            //            cur.CreditCardDayGrowth = model.CreditCardCount;
            //            if (pre!=null)
            //            {
            //                if (pre.DataTime.Value.Month==cur.DataTime.Value.Year)
            //                {
            //                    cur.CreditCardYearGrowth += model.CreditCardCount;
            //                    if (pre.DataTime.Value.Month ==cur.DataTime.Value.Month)
            //                    {
            //                        cur.CreditCardMonthGrowth += model.CreditCardCount;
            //                    }
            //                    else
            //                    {
            //                        cur.CreditCardMonthGrowth = model.CreditCardCount;
            //                    }
            //                }
            //                else
            //                {
            //                    cur.CreditCardMonthGrowth = model.CreditCardCount;
            //                    cur.CreditCardYearGrowth = model.CreditCardCount;
            //                }
            //                if (curtemp == null)
            //                {
            //                    UpdateAllocateList.Add(cur);
            //                }
            //            }
            //            else
            //            {
            //                if (curtemp==null)
            //                {
            //                    UpdateAllocateList.Add(cur);
            //                }
            //            }
            //        }
            //        else
            //        {
            //            UpdateAllocateList.Add(ConvertToPGPersonAllocateInfo(model));
            //        }
            //    }
            //}
        }
        private PGPersonAllocateInfo ConvertToPGPersonAllocateInfo(PGCreditCardInfo info)
        {
            PGPersonAllocateInfo newpersonallocate = new PGPersonAllocateInfo();
            newpersonallocate.ID = Guid.NewGuid().ToString();
            newpersonallocate.StaffCode = info.StaffCode;
            newpersonallocate.StaffName = info.StaffName;
            newpersonallocate.NewWebsiteID = info.NewWebsiteID;
            newpersonallocate.WebsiteID = info.WebsiteID;
            newpersonallocate.CreditCardDayGrowth = info.CreditCardCount;
            newpersonallocate.CreditCardMonthGrowth = info.CreditCardCount;
            newpersonallocate.CreditCardYearGrowth = info.CreditCardCount;
            newpersonallocate.DataTime = info.DataTime;

            return newpersonallocate;
        }
        #endregion

    }
}