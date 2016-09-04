using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using BalanceReport.Models;

namespace BalanceReport.Dao
{
    public class DisplayBalance
    {
        private static DisplayBalance _instance;

        public static DisplayBalance Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DisplayBalance();
                }
                return _instance;
            }
            
        }
        public ObservableCollection<Models.BalanceVaryModel> GetBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        {


            if (Company == null) { Company = ""; }
            if (Account == null) { Account = ""; }
            List<BalanceVaryModel> BVMList = BalanceInfoDao.Instance.GetBalanceVaryFromDate(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0);
            List<BalanceVaryModel> WebsiteList = (from i in BVMList where i.ParentID == "" || i.ParentID == null select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> CompanyList = (from i in BVMList where i.ParentID != "" && i.Name.Contains(Company) && i.DifferWebsite == "公司" select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> AccountList = (from i in BVMList where i.ParentID != "" && i.Name.Contains(Account) && i.WebsiteID.Contains(Company) && i.DifferWebsite != "公司" && i.DifferWebsite != "网点" select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> InfoList = new List<BalanceVaryModel>();
            List<BalanceVaryModel> InfoListCompany = new List<BalanceVaryModel>();
            #region 查询
            foreach (BalanceVaryModel item in AccountList)
            {
                InfoList.Add(item);
                foreach (BalanceVaryModel item2 in CompanyList)
                {
                    if (item.ParentID == item2.ID && InfoList.Contains(item2) == false)
                    {
                       
                        InfoList.Add(item2);
                        InfoListCompany.Add(item2);
                    }
                }

            }
            foreach (BalanceVaryModel item in InfoListCompany)
            {

                foreach (BalanceVaryModel item2 in WebsiteList)
                {
                    if (item.ParentID == item2.ID && InfoList.Contains(item2) == false)
                    {
                        
                        double vary = 0, regular = 0;
                        if (item2.UnRegularMoney != null && item2.UnRegularMoney != "")
                        {
                            vary = double.Parse(item2.UnRegularMoney);
                        }
                        if (item2.AmountMoney == null || item2.AmountMoney == "")
                        {
                            item2.Rate = "0";
                        }
                        else
                        {
                            double AmountMoney = double.Parse(item2.AmountMoney);
                            item2.Rate = ((vary / AmountMoney) * 100).ToString("0.00") + "%";
                        }
                        InfoList.Add(item2);

                    }
                    if (item.ParentID == item2.ID)
                    {
                        item.WebsiteName = item2.Name;
                    }
                }
            }

            DateTime start = DateTime.Parse(starttime);
            DateTime end = DateTime.Parse(endtime);
            switch (Displaystate)
            {
                case "0": break;
                case "1":
                    while (start != end)
                    {
                        foreach (BalanceVaryModel item in InfoList)
                        {
                            if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                            {
                                List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == end.AddDays(-1).ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                                string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                if (item.RegularMoney == "" || item.RegularMoney == null)
                                {
                                    afterRegularMoney = "0";
                                }
                                else
                                {
                                    afterRegularMoney = item.RegularMoney;
                                }
                                if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                {
                                    afterUnRegularMoney = "0";
                                }
                                else
                                {
                                    afterUnRegularMoney = item.UnRegularMoney;
                                }
                                if (R.Count > 0)
                                {
                                    
                                    if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                    {
                                        beforeRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeRegularMoney = R[0].RegularMoney;
                                    }
                                    if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                    {
                                        beforeUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeUnRegularMoney = R[0].UnRegularMoney;
                                    }
                                    if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                    {
                                        item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                    }
                                    if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null && R[0].UnRegularMoney != null)
                                    {
                                        item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                    }
                                    if (item.AmountMoney != "")
                                    {
                                        item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                    }
                                }
                                else
                                {

                                    //if (item.RegularMoney != "")
                                    //{
                                    //    item.RegularMoney = (0 - double.Parse(item.RegularMoney)).ToString(); ;
                                    //}
                                    //if (item.UnRegularMoney != "")
                                    //{
                                    //    item.UnRegularMoney = (0 - double.Parse(item.UnRegularMoney)).ToString(); ;
                                    //}
                                    //if (item.AmountMoney != "")
                                    //{
                                    //    item.AmountMoney = (0-double.Parse(item.AmountMoney)).ToString(); ;
                                    //}

                                }
                            }
                        }
                        end = end.AddDays(-1);
                    }
                    //foreach (BalanceVaryModel item in InfoList)
                    //{
                    //    if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                    //    {
                    //        if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                    //        if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                    //        if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                    //    }
                    //}
                    break;
                case "2":
                    List<BalanceVaryModel> temp = (from i in InfoList where (i.BalanceTime == end.ToString("yyyy-MM-dd") || i.BalanceTime == start.ToString("yyyy-MM-dd")) select i).ToList<BalanceVaryModel>();
                    InfoList = temp;
                    //while (start != end)
                    //{
                    foreach (BalanceVaryModel item in InfoList)
                    {
                        if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                        {
                            List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == start.ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                            if (R.Count > 0)
                            {
                                string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                if (item.RegularMoney == "" || item.RegularMoney == null)
                                {
                                    afterRegularMoney = "0";
                                }
                                else
                                {
                                    afterRegularMoney = item.RegularMoney;
                                }
                                if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                {
                                    afterUnRegularMoney = "0";
                                }
                                else
                                {
                                    afterUnRegularMoney = item.UnRegularMoney;
                                }
                                if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                {
                                    beforeRegularMoney = "0";
                                }
                                else
                                {
                                    beforeRegularMoney = R[0].RegularMoney;
                                }
                                if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                {
                                    beforeUnRegularMoney = "0";
                                }
                                else
                                {
                                    beforeUnRegularMoney = R[0].UnRegularMoney;
                                }
                                if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                {
                                    item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                }
                                if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null && R[0].UnRegularMoney != null)
                                {
                                    item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                }
                                if (item.AmountMoney != "")
                                {
                                    item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                }
                            }
                        }

                        //}
                        //end = end.AddDays(-1);
                    }
                    List<BalanceVaryModel> temp2 = new List<BalanceVaryModel>();
                    foreach (BalanceVaryModel item in InfoList)
                    {
                        if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                        {
                            if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                            if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                            if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                        }
                        else
                        {
                            temp2.Add(item);
                        }
                    }
                    InfoList = temp2;
                    break;
                case "3":
                    if(InfoList.Count>0)
                    {
                        List<BalanceVaryModel> OneDayList = (from i in InfoList where (i.BalanceTime == InfoList[0].BalanceTime) select i).ToList<BalanceVaryModel>();
                    //InfoList.Distinct<BalanceVaryModel>(new CompareClass()).ToList < BalanceVaryModel>();
                        int span=(end -start).Days;
                        //if (span == 0) { span = 1; }
                        span++;
                        foreach (var item in OneDayList)
                        {
                             List<BalanceVaryModel> R = (from i in InfoList where  i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                           
                             foreach (var item2 in R)
                             {
                                 double RegularMoney = 0, UnRegularMoney=0;
                                 if (item2.RegularMoney != null && item2.RegularMoney != "")
                                 {
                                     RegularMoney = double.Parse(item2.RegularMoney);
                                 }
                                 if (item2.UnRegularMoney  != null && item2.UnRegularMoney != "")
                                 {
                                     UnRegularMoney = double.Parse(item2.UnRegularMoney);
                                 }
                                 item.AverageBalance = item.AverageBalance + RegularMoney + UnRegularMoney;
                             }
                             item.AverageBalance = item.AverageBalance / span;
                             item.BalanceTime = endtime;
                        }
                        InfoList = OneDayList;
                    }
                    break;
            }
            //InfoList.Sort();
            if (except0 == "1")
            {
                List<BalanceVaryModel> finallyResult = new List<BalanceVaryModel>();
                foreach (BalanceVaryModel item in InfoList)
                {
                    if (item.RegularMoney == "0" || item.UnRegularMoney == "0")
                    {
                        ;
                    }
                    else
                    {
                        finallyResult.Add(item);
                    }
                }
                InfoList = finallyResult;
            }
            InfoList.Sort();
            #endregion
            return new ObservableCollection<BalanceVaryModel>(InfoList);
        }
        public ObservableCollection<Models.BalanceVaryModel> GetDepartmentBalanceVary(string starttime, string endtime, string Insitusation, string WebsiteName, string Company, string Account, string Displaystate, string except0)
        {


            if (Company == null) { Company = ""; }
            if (Account == null) { Account = ""; }
            List<BalanceVaryModel> BVMList = BalanceInfoDao.Instance.GetDepartmentBalanceVaryFromDate(starttime, endtime, Insitusation, WebsiteName, Company, Account, Displaystate, except0);
            List<BalanceVaryModel> DepartmenteList = (from i in BVMList where i.ParentID == "" || i.ParentID == null select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> AccountList = (from i in BVMList where i.ParentID != "" && i.Name.Contains(Account) select i).ToList<BalanceVaryModel>();
            List<BalanceVaryModel> InfoList = new List<BalanceVaryModel>();
            #region 查询
            foreach (BalanceVaryModel item in AccountList)
            {

                foreach (BalanceVaryModel item2 in DepartmenteList)
                {
                    if (item.ParentID == item2.Name && InfoList.Contains(item2) == false && item.BalanceTime == item2.BalanceTime)
                    {

                        double vary = 0, regular = 0;
                        if (item2.UnRegularMoney != null && item2.UnRegularMoney != "")
                        {
                            vary = double.Parse(item2.UnRegularMoney);
                        }
                        if (item2.AmountMoney == null || item2.AmountMoney == "")
                        {
                            item2.Rate = "0";
                        }
                        else
                        {
                            double AmountMoney = double.Parse(item2.AmountMoney);
                            item2.Rate = ((vary / AmountMoney) * 100).ToString("0.00") + "%";
                        }
                        item.ParentID = item2.ID;
                        InfoList.Add(item2);
                        InfoList.Add(item);

                    }
                    else if (item.ParentID == item2.Name && !InfoList.Contains(item) && item.BalanceTime == item2.BalanceTime)
                    {
                        item.ParentID = item2.ID;
                        InfoList.Add(item);
                    }
                    if (item.ParentID == item2.ID)
                    {
                        item.WebsiteName = item2.Name;
                    }

                }

            }
            //foreach (BalanceVaryModel item in InfoListCompany)
            //{

            //    foreach (BalanceVaryModel item2 in WebsiteList)
            //    {
            //        if (item.ParentID == item2.ID && InfoList.Contains(item2) == false)
            //        {

            //            double vary = 0, regular = 0;
            //            if (item2.UnRegularMoney != null && item.UnRegularMoney != "")
            //            {
            //                vary = double.Parse(item2.UnRegularMoney);
            //            }
            //            if (item2.AmountMoney == null || item.AmountMoney == "")
            //            {
            //                item2.Rate = "0";
            //            }
            //            else
            //            {
            //                double AmountMoney = double.Parse(item2.AmountMoney);
            //                item2.Rate = ((vary / AmountMoney) * 100).ToString("0.00") + "%";
            //            }
            //            InfoList.Add(item2);

            //        }
            //        if (item.ParentID == item2.ID)
            //        {
            //            item.WebsiteName = item2.Name;
            //        }
            //    }
            //}

            DateTime start = DateTime.Parse(starttime);
            DateTime end = DateTime.Parse(endtime);
            switch (Displaystate)
            {
                case "0": break;
                case "1":
                    while (start != end)
                    {
                        foreach (BalanceVaryModel item in InfoList)
                        {
                            if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                            {
                                List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == end.AddDays(-1).ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                                if (R.Count > 0)
                                {
                                    string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                    if (item.RegularMoney == "" || item.RegularMoney == null)
                                    {
                                        afterRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterRegularMoney = item.RegularMoney;
                                    }
                                    if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                    {
                                        afterUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        afterUnRegularMoney = item.UnRegularMoney;
                                    }
                                    if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                    {
                                        beforeRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeRegularMoney = R[0].RegularMoney;
                                    }
                                    if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                    {
                                        beforeUnRegularMoney = "0";
                                    }
                                    else
                                    {
                                        beforeUnRegularMoney = R[0].UnRegularMoney;
                                    }
                                    if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                    {
                                        item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                    }
                                    if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null && R[0].UnRegularMoney != null)
                                    {
                                        item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                    }
                                    if (item.AmountMoney != "")
                                    {
                                        item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                    }
                                }
                                else
                                {

                                    //if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                                    //if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                                    //if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                                }
                            }
                        }
                        end = end.AddDays(-1);
                    }
                    //foreach (BalanceVaryModel item in InfoList)
                    //{
                    //    if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                    //    {
                    //        if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                    //        if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                    //        if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                    //    }
                    //}
                    break;
                case "2":
                    List<BalanceVaryModel> temp = (from i in InfoList where (i.BalanceTime == end.ToString("yyyy-MM-dd") || i.BalanceTime == start.ToString("yyyy-MM-dd")) select i).ToList<BalanceVaryModel>();
                    InfoList = temp;
                    //while (start != end)
                    //{
                    foreach (BalanceVaryModel item in InfoList)
                    {
                        if (item.BalanceTime == end.ToString("yyyy-MM-dd"))
                        {
                            List<BalanceVaryModel> R = (from i in InfoList where i.BalanceTime == start.ToString("yyyy-MM-dd") && i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();
                            if (R.Count > 0)
                            {
                                string afterRegularMoney, afterUnRegularMoney, beforeRegularMoney, beforeUnRegularMoney;
                                if (item.RegularMoney == "" || item.RegularMoney == null)
                                {
                                    afterRegularMoney = "0";
                                }
                                else
                                {
                                    afterRegularMoney = item.RegularMoney;
                                }
                                if (item.UnRegularMoney == "" || item.UnRegularMoney == null)
                                {
                                    afterUnRegularMoney = "0";
                                }
                                else
                                {
                                    afterUnRegularMoney = item.UnRegularMoney;
                                }
                                if (R[0].RegularMoney == "" || R[0].RegularMoney == null)
                                {
                                    beforeRegularMoney = "0";
                                }
                                else
                                {
                                    beforeRegularMoney = R[0].RegularMoney;
                                }
                                if (R[0].UnRegularMoney == "" || R[0].UnRegularMoney == null)
                                {
                                    beforeUnRegularMoney = "0";
                                }
                                else
                                {
                                    beforeUnRegularMoney = R[0].UnRegularMoney;
                                }
                                if (item.RegularMoney != "" && R[0].RegularMoney != "" && item.RegularMoney != null && R[0].RegularMoney != null)
                                {
                                    item.RegularMoney = (double.Parse(afterRegularMoney) - double.Parse(beforeRegularMoney)).ToString();
                                }
                                if (item.UnRegularMoney != "" && R[0].UnRegularMoney != "" && item.UnRegularMoney != null && R[0].UnRegularMoney != null)
                                {
                                    item.UnRegularMoney = (double.Parse(afterUnRegularMoney) - double.Parse(beforeUnRegularMoney)).ToString();
                                }
                                if (item.AmountMoney != "")
                                {
                                    item.AmountMoney = (double.Parse(item.AmountMoney) - double.Parse(R[0].AmountMoney)).ToString();
                                }
                            }
                        }

                        //}
                        //end = end.AddDays(-1);
                    }
                    List<BalanceVaryModel> temp2 = new List<BalanceVaryModel>();
                    foreach (BalanceVaryModel item in InfoList)
                    {
                        if (item.BalanceTime == start.ToString("yyyy-MM-dd"))
                        {
                            if (item.RegularMoney != "") { item.RegularMoney = "0"; }
                            if (item.UnRegularMoney != "") { item.UnRegularMoney = "0"; }
                            if (item.AmountMoney != "") { item.AmountMoney = "0"; }

                        }
                        else
                        {
                            temp2.Add(item);
                        }
                    }
                    InfoList = temp2;
                    break;
                case "3":
                    if (InfoList.Count > 0)
                    {
                        List<BalanceVaryModel> OneDayList = (from i in InfoList where (i.BalanceTime == InfoList[0].BalanceTime) select i).ToList<BalanceVaryModel>();
                        //InfoList.Distinct<BalanceVaryModel>(new CompareClass()).ToList < BalanceVaryModel>();
                        int span = (end - start).Days;
                        //if (span == 0) { span = 1; }
                        span++;
                        foreach (var item in OneDayList)
                        {
                            List<BalanceVaryModel> R = (from i in InfoList where i.Name == item.Name && i.DifferWebsite == item.DifferWebsite select i).ToList<BalanceVaryModel>();

                            foreach (var item2 in R)
                            {
                                double RegularMoney = 0, UnRegularMoney = 0;
                                if (item2.RegularMoney != null && item2.RegularMoney != "")
                                {
                                    RegularMoney = double.Parse(item2.RegularMoney);
                                }
                                if (item2.UnRegularMoney != null && item2.UnRegularMoney != "")
                                {
                                    UnRegularMoney = double.Parse(item2.UnRegularMoney);
                                }
                                item.AverageBalance = item.AverageBalance + RegularMoney + UnRegularMoney;
                            }
                            item.AverageBalance = item.AverageBalance / span;
                            item.BalanceTime = endtime;
                        }
                        InfoList = OneDayList;
                    }
                    break;
            }
            //InfoList.Sort();
            if (except0 == "1")
            {
                List<BalanceVaryModel> finallyResult = new List<BalanceVaryModel>();
                foreach (BalanceVaryModel item in InfoList)
                {
                    if (item.RegularMoney == "0" || item.UnRegularMoney == "0")
                    {
                        ;
                    }
                    else
                    {
                        finallyResult.Add(item);
                    }
                }
                InfoList = finallyResult;
            }
            InfoList.Sort();
            #endregion
            return new ObservableCollection<BalanceVaryModel>(InfoList);
        } 
    }
}
