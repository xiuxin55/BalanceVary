using BalanceModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BalanceDAL
{
    public class ConverterTable
    {
        //public static  DataTable ListConvertTable<T>(List<T> list)
        //{
        //    Type t = typeof(T);
        //    Type basemodel = typeof(BaseModel);
        //    DataTable dtBalance = new DataTable();
        //    dtBalance.TableName =t.Name+"Vary";
        //    PropertyInfo[] properties= t.GetProperties();
        //    List<string> strs = new List<string>();
        //    foreach (var item in properties)
        //    {
        //        if (basemodel.GetProperty(item.Name) == null)
        //        {
        //            dtBalance.Columns.Add(item.Name);
        //        }
        //        else
        //        {
        //            strs.Add(item.Name);
        //        }
        //    }
        //    foreach (var item in list)
        //    {
        //        DataRow dr = dtBalance.NewRow();
        //        Type type=item.GetType();
        //        foreach (var property in properties)
        //        {
        //            if (!strs.Contains(property.Name))
        //            {
        //                object obj = property.GetValue(item, null);
        //                dr[property.Name] = obj == null?"":obj.ToString().Trim();
        //            }
        //        }
        //        dtBalance.Rows.Add(dr);
        //    }
        //    return dtBalance;
        //}

        public static DataTable CompanyBalanceListConvertTable(List<CompanyBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "CompanyBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("CompanyName");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("ZoneType");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["CompanyName"] = item.CompanyName;
                dr["WebsiteID"] = item.WebsiteID;
                dr["ZoneType"] = item.ZoneType;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }

        public static DataTable WebsiteBalanceListConvertTable(List<WebsiteBalance> list)
        {
            DataTable dtBalance = new DataTable();
            dtBalance.TableName = "WebsiteBalanceVary";
            dtBalance.Columns.Add("ID");
            dtBalance.Columns.Add("WebsiteID");
            dtBalance.Columns.Add("RegularMoney");
            dtBalance.Columns.Add("UnRegularMoney");
            dtBalance.Columns.Add("AmountMoney");
            dtBalance.Columns.Add("RegularMoneyVary");
            dtBalance.Columns.Add("UnRegularMoneyVary");
            dtBalance.Columns.Add("AmountMoneyVary");
            dtBalance.Columns.Add("Rate");
            dtBalance.Columns.Add("BalanceTime");
            dtBalance.Columns.Add("ZoneType");
            foreach (var item in list)
            {
                DataRow dr = dtBalance.NewRow();
                dr["ID"] = item.ID;
                dr["WebsiteID"] = item.WebsiteID;
                dr["ZoneType"] = item.ZoneType;
                dr["RegularMoney"] = item.RegularMoney;
                dr["UnRegularMoney"] = item.UnRegularMoney;
                dr["AmountMoney"] = item.AmountMoney;
                dr["RegularMoneyVary"] = item.RegularMoneyVary;
                dr["UnRegularMoneyVary"] = item.UnRegularMoneyVary;
                dr["AmountMoneyVary"] = item.AmountMoneyVary;
                dr["Rate"] = item.Rate;
                dr["BalanceTime"] = item.BalanceTime;
                dtBalance.Rows.Add(dr);
            }
            return dtBalance;
        }
    }
}
