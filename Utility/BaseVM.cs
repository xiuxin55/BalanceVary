using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    public abstract class BaseVM : NotificationObject
    {
        public BaseVM()
        {
            PageChangedCommand = new DelegateCommand<object>(PageChangedCommandExecute);
            CurrentPage = 1;
            PageSize = 20;
        }
        private int _pageSize;
        public int PageSize
        {
            get
            {
                
                return _pageSize;
            }
            set
            {
                _pageSize = value;
                RaisePropertyChanged("PageSize");
            }
        }
        private int _Total;
        public int Total
        {
            get
            {

                return _Total;
            }
            set
            {
                _Total = value;
                RaisePropertyChanged("Total");
            }
        }

        protected int CurrentPage { get; set; } 
        public DelegateCommand<object> PageChangedCommand { get; set; }
        public virtual void PageChangedCommandExecute(object obj)
        {
            if (obj is int)
            {
                CurrentPage = (int)obj;
                LoadPageData((CurrentPage - 1) * PageSize + 1, CurrentPage * PageSize);
            }
        }


        public abstract void LoadPageData(int startindex, int endindex);
    }
}
