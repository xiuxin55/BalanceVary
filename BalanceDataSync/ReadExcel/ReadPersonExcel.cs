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
                            if(!string.IsNullOrWhiteSpace(str))
                            {
                                WebsiteInfo oldwb =websites.FirstOrDefault(e => e.WebsiteID == str);
                                WebsiteInfo newwb = websites.FirstOrDefault(e => e.NewWebsiteID == str);
                                if (!string.IsNullOrWhiteSpace(oldwb.WebsiteID))
                                {
                                    model.WebsiteID = str;
                                    model.NewWebsiteID = oldwb.NewWebsiteID;
                                }
                                else if(!string.IsNullOrWhiteSpace(newwb.WebsiteID))
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

    }



}
