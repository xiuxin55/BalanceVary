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
        /// <summary>
        /// 本页最后一条索引
        /// </summary>
        public int EndIndex{ get; set; }

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
