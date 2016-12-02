using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BalanceModel;
using BalanceBLL;
using Common;
using IBatisNet.Common.Transaction;

namespace WcfBalanceServiceLibrary
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“WebsiteInfoService”。
    /// <summary>
    /// 人员分配信息服务
    /// </summary>
    public class PGPersonAllocateInfoService : IPGPersonAllocateInfoService
    {
        PGPersonAllocateInfoBLL bll = new PGPersonAllocateInfoBLL();
        public bool Add(PGPersonAllocateInfo info)
        {
            if (info.DataTime ==null)
            {
                return false ;
            }
            using (TransactionScope scope = new TransactionScope())
            {


                PGPersonAllocateInfo temp = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value.AddDays(-1),OrderbyColomnName= "StaffCode" };
                PGPersonAllocateInfo tempcurrentday = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value, OrderbyColomnName = "StaffCode" };
                //删除当天数据
                List<PGPersonAllocateInfo> currentlist = bll.Select(tempcurrentday);
                List<PGPersonAllocateInfo> prelist = bll.Select(temp);
                PGPersonAllocateInfo premodel = prelist != null && prelist.Count > 0 ? prelist[0] : null;
                if (premodel != null && premodel.DataTime != null)
                {


                    if (DateTime.Now.Month == premodel.DataTime.Value.Month)
                    {
                        info.CardMonthGrowth = info.CardDayGrowth + premodel.CardMonthGrowth;
                        info.InsuranceMonthGrowth = info.InsuranceDayGrowth + premodel.InsuranceMonthGrowth;
                        info.CreditCardMonthGrowth = info.CreditCardDayGrowth + premodel.CreditCardMonthGrowth;
                    }
                    else
                    {
                        info.CardMonthGrowth = info.CardDayGrowth;
                        info.InsuranceMonthGrowth = info.InsuranceDayGrowth;
                        info.CreditCardMonthGrowth = info.CreditCardDayGrowth;
                    }
                    if (DateTime.Now.Year == premodel.DataTime.Value.Year)
                    {
                        info.CardYearGrowth = info.CardDayGrowth + premodel.CardYearGrowth;
                        info.InsuranceYearGrowth = info.InsuranceDayGrowth + premodel.InsuranceYearGrowth;
                        info.CreditCardYearGrowth = info.InsuranceYearGrowth + premodel.CreditCardYearGrowth;
                    }
                    else
                    {
                        info.CardYearGrowth = info.CardDayGrowth;
                        info.InsuranceYearGrowth = info.InsuranceDayGrowth;
                        info.CreditCardYearGrowth = info.InsuranceYearGrowth;
                    }
                }
                else
                {
                    info.CardMonthGrowth = info.CardDayGrowth;
                    info.InsuranceMonthGrowth = info.InsuranceDayGrowth;
                    info.CreditCardMonthGrowth = info.CreditCardDayGrowth;
                    info.CardYearGrowth = info.CardDayGrowth;
                    info.InsuranceYearGrowth = info.InsuranceDayGrowth;
                    info.CreditCardYearGrowth = info.InsuranceYearGrowth;
                }

                bool ishasvalue = false;
                if (currentlist!=null&& currentlist.Count>0)
                {
                    ishasvalue = true;
                    info.ID = currentlist[0].ID;
                    info.CreditCardDayGrowth = currentlist[0].CreditCardDayGrowth;
                    info.CreditCardMonthGrowth = currentlist[0].CreditCardMonthGrowth;
                    info.CreditCardYearGrowth = currentlist[0].CreditCardYearGrowth;
                    
                }
                info.DayContributionDegree = (info.CardYearGrowth / (info.DataTime.Value - DateTime.Parse(info.DataTime.Value.Year + "-01-01")).Days) * Convert.ToDecimal(0.6) +
                    info.InsuranceYearGrowth * Convert.ToDecimal(0.2);
                //计算贡献度
                try
                {
                    bool result=ishasvalue ? bll.Update(info) : bll.Add(info);
                    scope.Complete();
                    return result;
                }
                catch (Exception ex)
                {
                    LogHelper.WriteLog(typeof(PGPersonAllocateInfoService), ex);
                    return false;
                }
                
            }
        }
        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <param name="list">分配的数据</param>
        /// <returns>存库结果</returns>
        public bool BatchAdd(List<PGPersonAllocateInfo> list)
        {
            List<PGPersonAllocateInfo> futurelist = new List<PGPersonAllocateInfo>();
            foreach (var info in list)
            {
                if (info.DataTime == null)
                {
                    return false;
                }
                //用于查询前一天的数据
                PGPersonAllocateInfo temp = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value.AddDays(-1), OrderbyColomnName = "StaffCode" };
                //查询当前数据是否已存在
                PGPersonAllocateInfo tempcurrentday = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value, OrderbyColomnName = "StaffCode" };
                //获取当前日期以后的所有数据
                List<PGPersonAllocateInfo> personfuturelist = bll.SelectLastPGPersonAllocateInfo(tempcurrentday);
                List<PGPersonAllocateInfo> currentlist = bll.Select(tempcurrentday);
                List<PGPersonAllocateInfo> prelist = bll.Select(temp);
                PGPersonAllocateInfo premodel = prelist != null && prelist.Count > 0 ? prelist[0] : null;
                if (premodel != null && premodel.DataTime != null)
                {
                    //如果前一天数据存在
                    if (DateTime.Now.Month == premodel.DataTime.Value.Month)
                    {
                        //在同一个月，累加月数据
                        info.CardMonthGrowth = info.CardDayGrowth + premodel.CardMonthGrowth;
                        info.InsuranceMonthGrowth = info.InsuranceDayGrowth + premodel.InsuranceMonthGrowth;
                        info.CreditCardMonthGrowth = info.CreditCardDayGrowth + premodel.CreditCardMonthGrowth;
                    }
                    else
                    {
                        //如果不是同一个月，则月数据为当前日数据
                        info.CardMonthGrowth = info.CardDayGrowth;
                        info.InsuranceMonthGrowth = info.InsuranceDayGrowth;
                        info.CreditCardMonthGrowth = info.CreditCardDayGrowth;
                    }
                    if (DateTime.Now.Year == premodel.DataTime.Value.Year)
                    {
                        //在同一年则累加年数据
                        info.CardYearGrowth = info.CardDayGrowth + premodel.CardYearGrowth;
                        info.InsuranceYearGrowth = info.InsuranceDayGrowth + premodel.InsuranceYearGrowth;
                        info.CreditCardYearGrowth = info.InsuranceYearGrowth + premodel.CreditCardYearGrowth;
                    }
                    else
                    {
                        //如果不是同一年，则年数据为当前日数据
                        info.CardYearGrowth = info.CardDayGrowth;
                        info.InsuranceYearGrowth = info.InsuranceDayGrowth;
                        info.CreditCardYearGrowth = info.InsuranceYearGrowth;
                    }
                }
                else
                {
                    //前一天数据不存在，则所有数据都采用当前当日数据
                    info.CardMonthGrowth = info.CardDayGrowth;
                    info.InsuranceMonthGrowth = info.InsuranceDayGrowth;
                    info.CreditCardMonthGrowth = info.CreditCardDayGrowth;
                    info.CardYearGrowth = info.CardDayGrowth;
                    info.InsuranceYearGrowth = info.InsuranceDayGrowth;
                    info.CreditCardYearGrowth = info.InsuranceYearGrowth;
                }
                decimal carddaydiffence = 0,insurancediffence=0,creditdiffence=0;
                if (currentlist != null && currentlist.Count > 0)
                {
                    //如果当前数据存在则修改当前数据；
                    info.ID = currentlist[0].ID;

                    carddaydiffence = info.CardDayGrowth - currentlist[0].CardDayGrowth;
                    insurancediffence = info.InsuranceDayGrowth - currentlist[0].InsuranceDayGrowth;
                    creditdiffence= info.CreditCardDayGrowth - currentlist[0].CreditCardDayGrowth; ;
                    info.CreditCardDayGrowth = currentlist[0].CreditCardDayGrowth;
                    info.CreditCardMonthGrowth = currentlist[0].CreditCardMonthGrowth;
                    info.CreditCardYearGrowth = currentlist[0].CreditCardYearGrowth;
                    //代表修改
                    info.DataState = 1;

                }

                info.DayContributionDegree = (info.CardYearGrowth / (info.DataTime.Value - DateTime.Parse(info.DataTime.Value.Year + "-01-01")).Days) * Convert.ToDecimal(0.6) +
                    info.InsuranceYearGrowth * Convert.ToDecimal(0.2);
                foreach (var item in personfuturelist)
                {
                    //计算当前日期之后的所有数据；
                    if (item.StaffCode==info.StaffCode)
                    {
                        if (item.DataTime.Value.Year == info.DataTime.Value.Year)
                        {
                            if (item.DataTime.Value.Month == info.DataTime.Value.Month)
                            {
                                item.CardMonthGrowth = item.CardMonthGrowth + carddaydiffence;
                                item.InsuranceMonthGrowth = item.InsuranceMonthGrowth + insurancediffence;
                                item.CreditCardMonthGrowth = item.CreditCardMonthGrowth + creditdiffence;
                            }
                            if (item.DataTime.Value.Year == info.DataTime.Value.Year)
                            {
                                item.CardYearGrowth = item.CardYearGrowth + carddaydiffence;
                                item.InsuranceYearGrowth = item.InsuranceYearGrowth + insurancediffence;
                                item.CreditCardYearGrowth = item.CreditCardYearGrowth + creditdiffence;

                            }
                            item.DayContributionDegree = (item.CardYearGrowth / (item.DataTime.Value - DateTime.Parse(item.DataTime.Value.Year + "-01-01")).Days) * Convert.ToDecimal(0.6) +
                            item.InsuranceYearGrowth * Convert.ToDecimal(0.2);
                            item.DataState = 1;
                            futurelist.Add(item);
                        }
                    }
                }
            }
            try
            {
                //合并未来数据
                list.AddRange(futurelist);
                //批量更新
                bool result = bll.BatchUpdate(list);
                return result;
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGPersonAllocateInfoService), ex);
                return false;
            }
            //}
        }
        public bool Delete(PGPersonAllocateInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGPersonAllocateInfo> Select(PGPersonAllocateInfo info)
        {
            try
            {
                if (info.DataTime != null)
                {
                    info.DataTime = DateTime.Parse(info.DataTime.Value.ToString("yyyy-MM-dd"));

                }
                return bll.Select(info);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(PGPersonAllocateInfoService), ex);
                return null;
                //throw ex;
            }
           
        }

        public bool Update(PGPersonAllocateInfo info)
        {
            return bll.Update(info);
        }
        public int SelectCount(PGPersonAllocateInfo info)
        {
            return bll.SelectCount(info);
        }

        public List<PGPersonAllocateInfo> CallTimeSpanProc(PGPersonAllocateInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
