using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows;
using System.Collections.ObjectModel;

namespace BalanceReport.Models
{
    /// <summary>
    /// 余额变动情况
    /// </summary>
    public class BalanceVaryModel : INotifyPropertyChanged, IComparable  
    {
        public string ID { get; set; }
        public string WebsiteID { get; set; }
        public string WebsiteName { get; set; }
        public string DifferWebsite { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// 定期余额
        /// </summary>
        public string RegularMoney { get; set; }
        /// <summary>
        /// 活期余额
        /// </summary>
        public string UnRegularMoney { get; set; }
        public string AmountMoney { get; set; }
        public string WebsiteAddress { get; set; }
        public string WebsiteTel { get; set; }
        public string WebsiteManager { get; set; }
        public string ManagerTelphone { get; set; }
        public string ParentID { get; set; }
        public string BalanceTime { get; set; }
        /// <summary>
        /// 日均余额;
        /// </summary>
        public double AverageBalance { get; set; }
        public string Rate { get; set; }

        private double _marginLeft;
        public double MarginLeft
        {
            get
            {
                return _marginLeft;
            }
            set
            {
                _marginLeft = value;
            }
        }

        private bool _isChecked = false;
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }

        private Visibility _isVisible = Visibility.Visible;
        public Visibility IsVisible
        {
            get
            {
                return _isVisible;
            }
            set
            {
                _isVisible = value;
            }
        }

        private ObservableCollection<BalanceVaryModel> _subordinates;
        public ObservableCollection<BalanceVaryModel> Subordinates
        {
            get
            {
                return _subordinates ?? (_subordinates = new ObservableCollection<BalanceVaryModel>());
            }
            set
            {
                _subordinates = value;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int CompareTo(object obj)
        {
            int flg = 0;
            try
            {
                BalanceVaryModel sObj = (BalanceVaryModel)obj;
                if (DateTime.Parse(this.BalanceTime) > (DateTime.Parse(sObj.BalanceTime)))
                {
                    flg = -1;
                }
                if (DateTime.Parse(this.BalanceTime) == (DateTime.Parse(sObj.BalanceTime)))
                {
                    flg = 0;
                }
                if (DateTime.Parse(this.BalanceTime) < (DateTime.Parse(sObj.BalanceTime)))
                {
                    flg = 1;
                }

            }
            catch (Exception ex)
            {
                throw new Exception("比较异常", ex.InnerException);
            }
            return flg;
        }
    }
    public class CompareClass : IEqualityComparer<BalanceVaryModel>
    {

        public bool Equals(BalanceVaryModel x, BalanceVaryModel y)
        {
            if (x.Name == y.Name)
            {
                return true;
            }
            return false;
        }

        public int GetHashCode(BalanceVaryModel obj)
        {
            throw new NotImplementedException();
        }
    }
}
