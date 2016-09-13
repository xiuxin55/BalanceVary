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
            CurrentPage = 1;
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
            uc.Items = newvalue;
        }
        #region 依赖属性-命令
        public ICommand PageChangedCommand
        {
            get { return (ICommand)GetValue(PageChangedCommandProperty); }
            set { SetValue(PageChangedCommandProperty, value); }
        }

        public static readonly DependencyProperty PageChangedCommandProperty =
            DependencyProperty.Register("PageChangedCommand", typeof(ICommand), typeof(UCPage), new PropertyMetadata(null));

        public static readonly DependencyProperty PageChangedCommandParameterProperty =
          DependencyProperty.Register("PageChangedCommandParameter",
                                      typeof(object),
                                      typeof(UCPage),
                                      new PropertyMetadata(null));

        /// <summary>
        /// 跳转命令参数
        /// </summary>
        public object PageChangedCommandParameter
        {
            get { return GetValue(PageChangedCommandParameterProperty); }
            set { SetValue(PageChangedCommandParameterProperty, value); }
        }


        #endregion
        #endregion
        #region 属性
        private int _Items;
        /// <summary>
        /// 总条数
        /// </summary>
        public int Items
        {
            get { return _Items; }
            set
            {
                if (_Items != value)
                {
                    _Items = value;
                    RaisePropertyChanged("Items");
                }
            }
        }

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

        private int _currentPage;
        /// <summary>
        /// 总条数
        /// </summary>
        public int CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    RaisePropertyChanged("CurrentPage");
                }
            }
        }
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
            if(CurrentPage >1)
            {
                CurrentPage--;
                if(PageChangedCommand != null)
                {
                    PageChangedCommand.Execute(PageChangedCommandParameter ?? CurrentPage);
                }
            }
        }

        private void btnFirstPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage = 1;
                if (PageChangedCommand != null)
                {
                    PageChangedCommand.Execute(PageChangedCommandParameter ?? CurrentPage);
                }
            }
        }

        private void btnNestPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < PageCount)
            {
                CurrentPage++;
                if (PageChangedCommand != null)
                {
                    PageChangedCommand.Execute(PageChangedCommandParameter ?? CurrentPage);
                }
            }
        }

        private void btnLastPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < PageCount)
            {
                CurrentPage = PageCount;
                if (PageChangedCommand != null)
                {
                    PageChangedCommand.Execute(PageChangedCommandParameter ?? CurrentPage);
                }
            }
        }

        private void btnJumpPage_Click(object sender, RoutedEventArgs e)
        {
            if (CurrentPage < PageCount)
            {
                if (PageChangedCommand != null)
                {
                    PageChangedCommand.Execute(PageChangedCommandParameter ?? CurrentPage);
                }
            }
        }
    }
}
