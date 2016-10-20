using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// VM基类
    /// </summary>
    public abstract class BaseVM : NotificationObject
    {
        public BaseVM()
        {
            PageChangedCommand = new DelegateCommand<object>(PageChangedCommandExecute);
            CurrentPage = 1;
            PageSize = 20;
        }
        private int _pageSize;
        /// <summary>
        /// 每页的条数
        /// </summary>
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
        /// <summary>
        /// 结果总条数
        /// </summary>
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
        /// <summary>
        /// 当前页数
        /// </summary>
        protected int CurrentPage { get; set; } 
        /// <summary>
        /// 分页命令
        /// </summary>
        public DelegateCommand<object> PageChangedCommand { get; set; }
        /// <summary>
        /// 分页命令执行函数
        /// </summary>
        /// <param name="obj"></param>
        public virtual void PageChangedCommandExecute(object obj)
        {
            if (obj is int)
            {
                CurrentPage = (int)obj;
                LoadPageData((CurrentPage - 1) * PageSize + 1, CurrentPage * PageSize);
            }
        }

        /// <summary>
        /// 分页操作执行方法
        /// </summary>
        /// <param name="startindex">开始索引</param>
        /// <param name="endindex">结束索引</param>
        public abstract void LoadPageData(int startindex, int endindex);
    }
}
