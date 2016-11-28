using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace PersonGold.Tools
{
    public class ListSortDecorator : Control
    {
        // Using a DependencyProperty as the backing store for SortDirection.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SortDirectionProperty =
            DependencyProperty.Register("SortDirection", typeof(ListSortDirection), typeof(ListSortDecorator));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="adorner"></param>
        static ListSortDecorator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ListSortDecorator), new FrameworkPropertyMetadata(typeof(ListSortDecorator)));
        }

        public ListSortDirection SortDirection
        {
            get { return (ListSortDirection)GetValue(SortDirectionProperty); }
            set { SetValue(SortDirectionProperty, value); }
        }
    }
}
