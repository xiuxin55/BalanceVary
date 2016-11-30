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


                PGPersonAllocateInfo temp = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value.AddDays(-1) };
                PGPersonAllocateInfo tempcurrentday = new PGPersonAllocateInfo() { StaffCode = info.StaffCode, StaffName = info.StaffName, DataTime = info.DataTime.Value };
                //删除当天数据
                List<PGPersonAllocateInfo> currentlist = bll.Select(tempcurrentday);
                List<PGPersonAllocateInfo> prelist = bll.Select(temp);
                PGPersonAllocateInfo premodel = prelist != null && prelist.Count > 0 ? prelist[0] : new PGPersonAllocateInfo();
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
                bool ishasvalue = false;
                if (currentlist!=null&& currentlist.Count>0)
                {
                    ishasvalue = true;
                    info.CreditCardDayGrowth = currentlist[0].CreditCardDayGrowth;
                    info.CreditCardMonthGrowth = currentlist[0].CreditCardMonthGrowth;
                    info.CreditCardYearGrowth = currentlist[0].CreditCardYearGrowth;
                    
                }
                //计算贡献度
                return ishasvalue?bll.Update(info):bll.Add(info);
            }
        }

        public bool Delete(PGPersonAllocateInfo info)
        {
            return bll.Delete(info);
        }

        public List<PGPersonAllocateInfo> Select(PGPersonAllocateInfo info)
        {
            try
            {
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
            //if (info.SalaryTime != null)
            //{
            //    info.SalaryTime = DateTime.Parse(info.SalaryTime.Value.ToString("yyyy-MM") + "-01");

            //}
            return bll.SelectCount(info);
        }

        public List<PGPersonAllocateInfo> CallTimeSpanProc(PGPersonAllocateInfo t)
        {
            return bll.CallTimeSpanProc(t);
        }
    }
}
