using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CustomControls
{
    /// <summary>
    /// UCPage.xaml 的交互逻辑
    /// </summary>
    public partial class UCPage : UserControl, INotifyPropertyChanged
    {
        public UCPage()
        {
            InitializeComponent();
        }
        #region 依赖属性
        public int PageSize
        {
            get { return (int)GetValue(PageSizeProperty); }
            set { SetValue(PageSizeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageSize.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageSizeProperty =
            DependencyProperty.Register("PageSize", typeof(int), typeof(UCPage), new UIPropertyMetadata(20));



        //public int Total
        //{
        //    get { return (int)GetValue(TotalProperty); }
        //    set { SetValue(TotalProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty TotalProperty =
        //    DependencyProperty.Register("Total", typeof(int), typeof(UCPage), new UIPropertyMetadata(0));

        public int TotalItem
        {
            get { return (int)GetValue(TotalItemProperty); }
            set { SetValue(TotalItemProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Total.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TotalItemProperty =
            DependencyProperty.Register("TotalItem", typeof(int), typeof(UCPage), new UIPropertyMetadata(0, new PropertyChangedCallback(TotalItemChangedCallback)));

        private static void TotalItemChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            UCPage uc = sender as UCPage;
            int newvalue = e.NewValue != null ? (int)e.NewValue : 0;
            uc.PageCount = newvalue % uc.PageSize == 0 ? newvalue / uc.PageSize : newvalue / uc.PageSize + 1;
        }
        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(UCPage), new UIPropertyMetadata(1));

        //public int PageItems
        //{
        //    get { return (int)GetValue(PageItemsProperty); }
        //    set { SetValue(PageItemsProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PageItemsProperty =
        //    DependencyProperty.Register("PageItems", typeof(int), typeof(UCPage), new UIPropertyMetadata(0,new PropertyChangedCallback(PageItemsChangedCallback)));

        //private  static void PageItemsChangedCallback(DependencyObject sender,DependencyPropertyChangedEventArgs e)
        //{
        //    UCPage uc = sender as UCPage;
        //    int newvalue=e.NewValue!=null? (int)e.NewValue:0;
        //    uc.PageCount = newvalue % uc.PageSize == 0 ? newvalue / uc.PageSize : newvalue / uc.PageSize + 1;
        //}
        #region 依赖属性-命令
        public ICommand NextPageCommand
        {
            get { return (ICommand)GetValue(NextPageCommandProperty); }
            set { SetValue(NextPageCommandProperty, value); }
        }

        public static readonly DependencyProperty NextPageCommandProperty =
            DependencyProperty.Register("NextPageCommand", typeof(ICommand), typeof(UCPage), new PropertyMetadata(null));
        public static readonly DependencyProperty NextPageCommandParameterProperty =
          DependencyProperty.Register("NextPageCommandParameter",
                                      typeof(object),
                                      typeof(UCPage),
                                      new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets the command parameter which is passed to the close button command.
        /// </summary>
        public object NextPageCommandParameter
        {
            get { return GetValue(NextPageCommandParameterProperty); }
            set { SetValue(NextPageCommandParameterProperty, value); }
        }


        public ICommand PrePageCommand
        {
            get { return (ICommand)GetValue(PrePageCommandProperty); }
            set { SetValue(PrePageCommandProperty, value); }
        }

        public static readonly DependencyProperty PrePageCommandProperty =
            DependencyProperty.Register("PrePageCommand", typeof(ICommand), typeof(UCPage), new PropertyMetadata(null));
        public static readonly DependencyProperty PrePageCommandParameterProperty =
          DependencyProperty.Register("PrePageCommandParameter",
                                      typeof(object),
                                      typeof(UCPage),
                                      new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets the command parameter which is passed to the close button command.
        /// </summary>
        public object PrePageCommandParameter
        {
            get { return GetValue(PrePageCommandParameterProperty); }
            set { SetValue(PrePageCommandParameterProperty, value); }
        }


        public ICommand FirstPageCommand
        {
            get { return (ICommand)GetValue(FirstPageCommandProperty); }
            set { SetValue(FirstPageCommandProperty, value); }
        }

        public static readonly DependencyProperty FirstPageCommandProperty =
            DependencyProperty.Register("FirstPageCommand", typeof(ICommand), typeof(UCPage), new PropertyMetadata(null));
        public static readonly DependencyProperty FirstPageCommandParameterProperty =
          DependencyProperty.Register("FirstPageCommandParameter",
                                      typeof(object),
                                      typeof(UCPage),
                                      new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets the command parameter which is passed to the close button command.
        /// </summary>
        public object FirstPageCommandParameter
        {
            get { return GetValue(FirstPageCommandParameterProperty); }
            set { SetValue(FirstPageCommandParameterProperty, value); }
        }

        public ICommand LastPageCommand
        {
            get { return (ICommand)GetValue(LastPageCommandProperty); }
            set { SetValue(LastPageCommandProperty, value); }
        }

        public static readonly DependencyProperty LastPageCommandProperty =
            DependencyProperty.Register("LastPageCommand", typeof(ICommand), typeof(UCPage), new PropertyMetadata(null));
        public static readonly DependencyProperty LastPageCommandParameterProperty =
          DependencyProperty.Register("LastPageCommandParameter",
                                      typeof(object),
                                      typeof(UCPage),
                                      new PropertyMetadata(null));

        /// <summary>
        /// Gets/sets the command parameter which is passed to the close button command.
        /// </summary>
        public object LastPageCommandParameter
        {
            get { return GetValue(LastPageCommandParameterProperty); }
            set { SetValue(LastPageCommandParameterProperty, value); }
        } 
        #endregion
        #endregion
        #region 属性
        //private int _currentPage;
        ///// <summary>
        ///// 总页数
        ///// </summary>
        //public int CurrentPage
        //{
        //    get { return _currentPage; }
        //    set
        //    {
        //        if (_currentPage != value)
        //        {
        //            _currentPage = value;
        //            RaisePropertyChanged("CurrentPage");
        //        }
        //    }
        //}

        private int _pageCount;
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                if (_pageCount != value)
                {
                    _pageCount = value;
                    RaisePropertyChanged("PageCount");
                }
            }
        }

        //private int _pageItems;
        ///// <summary>
        ///// 总条数
        ///// </summary>
        //public int PageItems
        //{
        //    get { return _pageItems; }
        //    set
        //    {
        //        if (_pageItems != value)
        //        {
        //            _pageItems = value;
        //            RaisePropertyChanged("PageItems");
        //        }
        //    }
        //}
        #endregion
        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion

        private void btnPrePage_Click(object sender, RoutedEventArgs e)
        {
            if(PageIndex>1)
            {
                PageIndex--;
                if(PrePageCommand!=null)
                {
                    PrePageCommand.Execute(PrePageCommandParameter);
                }
            }
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex > 1)
            {
                PageIndex=1;
                if (FirstPageCommand != null)
                {
                    FirstPageCommand.Execute(FirstPageCommandParameter);
                }
            }
        }

        private void btnNestPage_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex < PageCount)
            {
                PageIndex ++;
                if (NextPageCommand != null)
                {
                    NextPageCommand.Execute(NextPageCommandParameter);
                }
            }
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            if (PageIndex < PageCount)
            {
                PageIndex = PageCount;
                if (LastPageCommand != null)
                {
                    LastPageCommand.Execute(LastPageCommandParameter);
                }
            }
        }
    }
}
