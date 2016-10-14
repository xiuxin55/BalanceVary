using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    public class BaseModel: INotifyPropertyChanged
    {
   
        public int RowNumber { get; set; }
        /// <summary>
        /// 本页第一条索引
        /// </summary>
        public int StartIndex { get; set; }

        private int _EndIndex=int.MaxValue;
        /// <summary>
        /// 本页最后一条索引
        /// </summary>
        public int EndIndex
        {
            get
            {
                return _EndIndex;
            }
            set
            {
                _EndIndex = value;
            }
        }
        private string _OrderbyColomnName= "BalanceTime";
        public string OrderbyColomnName
        {
            get
            {
                return _OrderbyColomnName;
            }
            set
            {
                _OrderbyColomnName = value;
            }
        }

        private string _SubOrderbyColomnName = "BalanceTime";
        /// <summary>
        /// 子排序列
        /// </summary>
        public string SubOrderbyColomnName
        {
            get
            {
                return _SubOrderbyColomnName;
            }
            set
            {
                _SubOrderbyColomnName = value;
            }
        } 
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyname)
        {
            if(PropertyChanged!=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
