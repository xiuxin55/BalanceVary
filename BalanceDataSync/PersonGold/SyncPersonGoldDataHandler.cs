using BalanceBLL;
using BalanceModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public partial class SyncDataHandler
    {
        List<PGPersonInfo> ImportPGPersonInfoDataList = new List<PGPersonInfo>();
        List<PGDebitCardInfo> ImportPGDebitCardInfoDataList = new List<PGDebitCardInfo>();
        List<PGInsuranceInfo> ImportPGInsuranceInfoDataList = new List<PGInsuranceInfo>();

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
    }
}