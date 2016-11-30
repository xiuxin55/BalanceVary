using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace BalanceDataSync
{
    public class ReadPersonExcel
    {
        #region 人员信息
        public static List<PGPersonInfo> ReadPGPersonInfoData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return PGPersonInfoData(fi.FullName);
            }
            return null;
        }

        public static List<PGPersonInfo> PGPersonInfoData(string filename)
        {
            try
            {
                List<PGPersonInfo> list = new List<PGPersonInfo>();
                List<DataTable> tables = NPOIHelper.Instance.ImportPersonInfo(filename);
                List<WebsiteInfo> websites = new BalanceBLL.WebsiteInfoBLL().Select(null);
                foreach (var dt in tables)
                {
                    List<string> accountids = new List<string>();
                    for (int j = 1; j < dt.Rows.Count; j++)
                    {
                        DataRow item = dt.Rows[j];
                        if (string.IsNullOrWhiteSpace(item[0].ToString()))
                        {
                            continue;
                        }
                        if (!accountids.Contains(item["人员编码"].ToString().Trim()))
                        {

                            accountids.Add(item["人员编码"].ToString().Trim());
                            PGPersonInfo model = new PGPersonInfo();
                            model.ID = Guid.NewGuid().ToString();
                            string str = item["部门编码"].ToString().Trim();
                            if (!string.IsNullOrWhiteSpace(str))
                            {
                                WebsiteInfo oldwb = websites.FirstOrDefault(e => e.WebsiteID == str);
                                WebsiteInfo newwb = websites.FirstOrDefault(e => e.NewWebsiteID == str);
                                if (oldwb != null && !string.IsNullOrWhiteSpace(oldwb.WebsiteID))
                                {
                                    model.WebsiteID = str;
                                    model.NewWebsiteID = oldwb.NewWebsiteID;
                                }
                                else if (newwb != null && !string.IsNullOrWhiteSpace(newwb.WebsiteID))
                                {
                                    model.NewWebsiteID = str;
                                    model.WebsiteID = oldwb.WebsiteID;
                                }
                                else
                                {
                                    model.WebsiteID = model.NewWebsiteID = str;
                                }
                            }
                            else
                            {
                                model.WebsiteID = model.NewWebsiteID = null;
                            }

                            model.StaffCode = item["人员编码"].ToString().Trim();
                            model.StaffName = item["姓名"].ToString().Trim();
                            model.CardID = item["身份证号"].ToString().Trim();
                            model.StaffType = item["人员类别"].ToString().Trim();
                            model.StaffPositionOrder = item["岗位序列"].ToString().Trim();
                            model.StaffPosition = item["岗位"].ToString().Trim();
                            list.Add(model);
                        }
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
        #region 储蓄卡信息
        public static List<PGDebitCardInfo> ReadPGDebitCardInfoData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return PGDebitCardInfoData(fi.FullName);
            }
            return null;
        }
        public static List<PGDebitCardInfo> PGDebitCardInfoData(string filename)
        {
            try
            {
                List<PGDebitCardInfo> list = new List<PGDebitCardInfo>();
                List<DataTable> tables = NPOIHelper.Instance.ImportPersonInfo(filename, 0, 3);
                List<WebsiteInfo> websites = new BalanceBLL.WebsiteInfoBLL().Select(null);
                foreach (var dt in tables)
                {
                    // List<string> accountids = new List<string>();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataRow item = dt.Rows[j];
                        if (string.IsNullOrWhiteSpace(item[0].ToString()) && string.IsNullOrWhiteSpace(item[1].ToString()))
                        {
                            continue;
                        }
                        //if (!accountids.Contains(item["人员编码"].ToString().Trim()))
                        //{

                        //  accountids.Add(item["人员编码"].ToString().Trim());
                        PGDebitCardInfo model = new PGDebitCardInfo();
                        model.ID = Guid.NewGuid().ToString();
                        string str = item[0].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(str))  
                        {
                            string name = item[0].ToString();
                            WebsiteInfo wb = websites.FirstOrDefault(e => e.WebsiteName.Replace("连云港市", "").Contains(name) || name.Contains(e.WebsiteName.Replace("连云港市", "")));
                            if (wb!=null&&!string.IsNullOrWhiteSpace(wb.WebsiteID))
                            {
                                model.WebsiteID = wb.WebsiteID;
                                model.NewWebsiteID = wb.NewWebsiteID;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        decimal money;
                        decimal.TryParse(item[1].ToString().Trim(), out money);
                        model.CurrentDayBalance = money;
                        model.DifferenceValue = 0;
                        bool ishas=false ;
                        foreach (var temp in list)
                        {
                            if ((model.WebsiteID !=null&&temp.WebsiteID==model.WebsiteID)||(model.NewWebsiteID!=null&&temp.NewWebsiteID==model.NewWebsiteID))
                            {
                                if (money>0)
                                {
                                    temp.CurrentDayBalance = money;
                                    temp.DifferenceValue = 0;
                                }
                                ishas = true;
                            }
                        }
                        if (!ishas)
                        {
                            list.Add(model);
                        }
                      
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public static List<PGDebitCardInfo> PGDebitCardInfoData(string filename)
        //{
        //    try
        //    {
        //        List<PGDebitCardInfo> list = new List<PGDebitCardInfo>();
        //        List<DataTable> tables = NPOIHelper.Instance.ImportPersonInfo(filename,0,3);
        //        List<WebsiteInfo> websites = new BalanceBLL.WebsiteInfoBLL().Select(null);
        //        foreach (var dt in tables)
        //        {
        //            // List<string> accountids = new List<string>();
        //            for (int j = 0; j < dt.Rows.Count; j++)
        //            {
        //                DataRow item = dt.Rows[j];
        //                if (string.IsNullOrWhiteSpace(item[0].ToString())&& string.IsNullOrWhiteSpace(item[1].ToString()))
        //                {
        //                    continue;
        //                }
        //                //if (!accountids.Contains(item["人员编码"].ToString().Trim()))
        //                //{

        //                //  accountids.Add(item["人员编码"].ToString().Trim());
        //                PGDebitCardInfo model = new PGDebitCardInfo();
        //                model.ID = Guid.NewGuid().ToString();
        //                string str = item[0].ToString().Trim();
        //                if (!string.IsNullOrWhiteSpace(str))
        //                {
        //                    WebsiteInfo oldwb = websites.FirstOrDefault(e => e.WebsiteID == str);
        //                    WebsiteInfo newwb = websites.FirstOrDefault(e => e.NewWebsiteID == str);
        //                    if (oldwb != null && !string.IsNullOrWhiteSpace(oldwb.WebsiteID))
        //                    {
        //                        model.WebsiteID = str;
        //                        model.NewWebsiteID = oldwb.NewWebsiteID;
        //                    }
        //                    else if (newwb != null && !string.IsNullOrWhiteSpace(newwb.WebsiteID))
        //                    {
        //                        model.NewWebsiteID = str;
        //                        model.WebsiteID = newwb.WebsiteID;
        //                    }
        //                    else
        //                    {
        //                        continue;
        //                    }
        //                }
        //                else if (!string.IsNullOrWhiteSpace(item[1].ToString()))
        //                {
        //                    string name = item[1].ToString();
        //                    WebsiteInfo wb = websites.FirstOrDefault(e => e.WebsiteName.Replace("连云港市","").Contains(name)|| name.Contains(e.WebsiteName.Replace("连云港市", "")));
        //                    if (!string.IsNullOrWhiteSpace(wb.WebsiteID))
        //                    {
        //                        model.WebsiteID = wb.WebsiteID;
        //                        model.NewWebsiteID = wb.NewWebsiteID;
        //                    }
        //                }
        //                else
        //                {
        //                    model.WebsiteID = model.NewWebsiteID = null;
        //                }
        //                decimal money;
        //                decimal.TryParse(item[2].ToString().Trim(), out money);
        //                model.CurrentDayBalance = money;
        //                model.DifferenceValue = 0;
        //                list.Add(model);
        //                //}
        //            }
        //        }
        //        return list;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}
        #endregion
        #region 保险信息
        public static List<PGInsuranceInfo> ReadPGInsuranceInfoData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return PGInsuranceInfoData(fi.FullName);
            }
            return null;
        }

        public static List<PGInsuranceInfo> PGInsuranceInfoData(string filename)
        {
            try
            {
                List<PGInsuranceInfo> list = new List<PGInsuranceInfo>();
                List<DataTable> tables = NPOIHelper.Instance.ImportPersonInfo(filename);
                List<WebsiteInfo> websites = new BalanceBLL.WebsiteInfoBLL().Select(null);
                foreach (var dt in tables)
                {
                    // List<string> accountids = new List<string>();
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataRow item = dt.Rows[j];
                        if (string.IsNullOrWhiteSpace(item[0].ToString()) && string.IsNullOrWhiteSpace(item[1].ToString()))
                        {
                            continue;
                        }
                        //if (!accountids.Contains(item["人员编码"].ToString().Trim()))
                        //{

                        //  accountids.Add(item["人员编码"].ToString().Trim());
                        PGInsuranceInfo model = new PGInsuranceInfo();
                        model.ID = Guid.NewGuid().ToString();
                        string str = item[0].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            WebsiteInfo oldwb = websites.FirstOrDefault(e => e.WebsiteID == str);
                            WebsiteInfo newwb = websites.FirstOrDefault(e => e.NewWebsiteID == str);
                            if (oldwb != null && !string.IsNullOrWhiteSpace(oldwb.WebsiteID))
                            {
                                model.WebsiteID = str;
                                model.NewWebsiteID = oldwb.NewWebsiteID;
                            }
                            else if (newwb != null && !string.IsNullOrWhiteSpace(newwb.WebsiteID))
                            {
                                model.NewWebsiteID = str;
                                model.WebsiteID = newwb.WebsiteID;
                            }
                            else
                            {
                                continue;
                                //model.WebsiteID = model.NewWebsiteID = str;
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(item[1].ToString()))
                        {
                            string name = item[1].ToString();
                            WebsiteInfo wb = websites.FirstOrDefault(e => e.WebsiteName.Replace("连云港市", "").Contains(name) || name.Contains(e.WebsiteName.Replace("连云港市", "")));
                            if (!string.IsNullOrWhiteSpace(wb.WebsiteID))
                            {
                                model.WebsiteID = wb.WebsiteID;
                                model.NewWebsiteID = wb.NewWebsiteID;
                            }
                        }
                        else
                        {
                            model.WebsiteID = model.NewWebsiteID = null;
                        }
                        decimal currrentmoney,wholemoney;

                        decimal.TryParse(item[dt.Columns.Count-2].ToString().Trim(), out currrentmoney);
                        decimal.TryParse(item[dt.Columns.Count - 1].ToString().Trim(), out wholemoney);
                        model.CurrentDayBalance = wholemoney;
                        model.DifferenceValue = currrentmoney;
                        model.WholeBalance = wholemoney;
                        list.Add(model);
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        
        #region 信用卡信息
        public static List<PGCreditCardInfo> ReadPGCreditCardInfoData(string filename)
        {
            if (File.Exists(filename))
            {
                FileInfo fi = new FileInfo(filename);
                return PGCreditCardInfoData(fi.FullName);
            }
            return null;
        }

        public static List<PGCreditCardInfo> PGCreditCardInfoData(string filename)
        {
            try
            {
                List<PGCreditCardInfo> list = new List<PGCreditCardInfo>();
                List<DataTable> tables = NPOIHelper.Instance.ImportPersonInfo(filename);
                List<WebsiteInfo> websites = new BalanceBLL.WebsiteInfoBLL().Select(null);

                foreach (var dt in tables)
                {
                    List<string> distinctstrs = new List<string>();
                    string newrecordwebisite = "", oldrecordwebisite = "";
                    
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {
                        DataRow item = dt.Rows[j];
                        if (string.IsNullOrWhiteSpace(item[2].ToString()))
                        {
                            continue;
                        }
                        PGCreditCardInfo model = new PGCreditCardInfo();
                        model.ID = Guid.NewGuid().ToString();
                        string str = item[0].ToString().Trim();
                        if (!string.IsNullOrWhiteSpace(str))
                        {
                            WebsiteInfo oldwb = websites.FirstOrDefault(e => e.WebsiteID == str);
                            WebsiteInfo newwb = websites.FirstOrDefault(e => e.NewWebsiteID == str);
                            if (oldwb != null && !string.IsNullOrWhiteSpace(oldwb.WebsiteID))
                            {
                                model.WebsiteID = str;
                                model.NewWebsiteID = oldwb.NewWebsiteID;
                                oldrecordwebisite = str;
                            }
                            else if (newwb != null && !string.IsNullOrWhiteSpace(newwb.WebsiteID))
                            {
                                model.NewWebsiteID = str;
                                model.WebsiteID = newwb.WebsiteID;
                                newrecordwebisite = str;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        else if (!string.IsNullOrWhiteSpace(item[1].ToString()))
                        {
                            string name = item[1].ToString();
                            WebsiteInfo wb = websites.FirstOrDefault(e => e.WebsiteName.Replace("连云港市", "").Contains(name) || name.Contains(e.WebsiteName.Replace("连云港市", "")));
                            if (!string.IsNullOrWhiteSpace(wb.WebsiteID))
                            {
                                model.WebsiteID = wb.WebsiteID;
                                model.NewWebsiteID = wb.NewWebsiteID;
                            }
                        }
                        else
                        {
                            continue;
                        }
                        model.StaffName = item[2].ToString().Trim();
                        DateTime approvaltime;
                        if(!DateTime.TryParseExact(item[9].ToString(), "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture,System.Globalization.DateTimeStyles.None,out approvaltime) && item[10].ToString().Trim()!="批准")//审批日期
                        {
                            continue;
                        }
                        model.DataTime = approvaltime;
                        PGCreditCardInfo tempmodel = list.Find(e => (e.NewWebsiteID == model.NewWebsiteID || e.WebsiteID == model.WebsiteID) && e.StaffName == model.StaffName&&e.DataTime ==model.DataTime);
                        if (tempmodel !=null&& tempmodel.CreditCardCount>0)
                        {
                            tempmodel.CreditCardCount += 1;
                        }
                        else
                        {
                            model.CreditCardCount = 1;
                            list.Add(model);
                        }
                        
                        //}
                    }
                }
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }



}
