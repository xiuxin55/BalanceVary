using System;
using System.Collections.Generic;
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

namespace BalanceReport.Views
{
    /// <summary>
    /// MyCalendar.xaml 的交互逻辑
    /// </summary>
    public partial class MyCalendar : UserControl
    {
        public MyCalendar()
        {
            InitializeComponent();
            Dictionary<int, TextBlock> week = new Dictionary<int, TextBlock>();
            week.Add(0, this.a);
            week.Add(1, this.b);
            week.Add(2, this.c);
            week.Add(3, this.d);
            week.Add(4, this.e);
            week.Add(5, this.f);
            week.Add(6, this.g);
            Calender.Add(0, week);

            Dictionary<int, TextBlock> week1 = new Dictionary<int, TextBlock>();
            week1.Add(0, this.h);
            week1.Add(1, this.i);
            week1.Add(2, this.j);
            week1.Add(3, this.k);
            week1.Add(4, this.l);
            week1.Add(5, this.m);
            week1.Add(6, this.n);
            Calender.Add(1, week1);

            Dictionary<int, TextBlock> week2 = new Dictionary<int, TextBlock>();
            week2.Add(0, this.o);
            week2.Add(1, this.p);
            week2.Add(2, this.q);
            week2.Add(3, this.r);
            week2.Add(4, this.s);
            week2.Add(5, this.t);
            week2.Add(6, this.u);
            Calender.Add(2, week2);

            Dictionary<int, TextBlock> week3 = new Dictionary<int, TextBlock>();
            week3.Add(0, this.v);
            week3.Add(1, this.w);
            week3.Add(2, this.x);
            week3.Add(3, this.y);
            week3.Add(4, this.z);
            week3.Add(5, this.aa);
            week3.Add(6, this.bb);
            Calender.Add(3, week3);

            Dictionary<int, TextBlock> week4 = new Dictionary<int, TextBlock>();
            week4.Add(0, this.cc);
            week4.Add(1, this.dd);
            week4.Add(2, this.ee);
            week4.Add(3, this.ff);
            week4.Add(4, this.gg);
            week4.Add(5, this.hh);
            week4.Add(6, this.ii);
            Calender.Add(4, week4);

            Dictionary<int, TextBlock> week5 = new Dictionary<int, TextBlock>();
            week5.Add(0, this.jj);
            week5.Add(1, this.kk);
            week5.Add(2, this.ll);
            week5.Add(3, this.mm);
            week5.Add(4, this.nn);
            week5.Add(5, this.oo);
            week5.Add(6, this.pp);
            Calender.Add(5, week5);

            DateTime firstime = DateTime.Parse("2010-01-01");
            DateTime recordtime = firstime;
            while (recordtime.Year <= DateTime.Now.Year)
            {
                this.year.Items.Add(recordtime.Year.ToString());
                recordtime = recordtime.AddYears(1);
            }
            ComboBoxItem cbi = new ComboBoxItem();
            cbi.Content = DateTime.Now.Year.ToString();
            this.year.SelectedItem = cbi;
            this.year.Text = DateTime.Now.Year.ToString();
            ComboBoxItem cbi2 = new ComboBoxItem();
            cbi2.Content = DateTime.Now.Month.ToString();
            this.month.SelectedItem = cbi2;
            this.month.Text = DateTime.Now.Month.ToString();
        }
        Dictionary<int, Dictionary<int, TextBlock>> Calender = new Dictionary<int, Dictionary<int, TextBlock>>();
        private void comboBox2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.year.SelectedItem != null && this.month.SelectedItem != null)
            {
                //ComboBoxItem cbiyear = (ComboBoxItem)this.year.SelectedItem;
                ComboBoxItem cbimonth = (ComboBoxItem)this.month.SelectedItem;
                if (cbimonth.Content != null)
                {
                    string selecttime = this.year.SelectedItem.ToString() + "-" + cbimonth.Content.ToString();
                    DateTime dtime = DateTime.Parse(selecttime);
                    int days = (dtime.AddMonths(1) - dtime).Days;

                    int j = 0;
                    List<string> already = new List<string>();// BalanceReport.Dao.BalanceInfoDao.Instance.GetAlreadyImportTime(dtime.ToString("yyyy-MM"));
                    foreach (KeyValuePair<int, Dictionary<int, TextBlock>> item in Calender)
                    {
                        foreach (KeyValuePair<int, TextBlock> item2 in item.Value)
                        {
                            item2.Value.Text = "";
                            item2.Value.Foreground = Brushes.Red;
                        }
                    }
                    for (int i = 0; i < days; i++)
                    {

                        string item = selecttime + "-" + (i + 1).ToString();
                        DateTime n = DateTime.Parse(item);

                        switch (n.DayOfWeek)
                        {
                            case DayOfWeek.Monday: Calender[j][0].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][0].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Tuesday: Calender[j][1].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][1].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Wednesday: Calender[j][2].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][2].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Thursday: Calender[j][3].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][3].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Friday: Calender[j][4].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][4].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Saturday: Calender[j][5].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][5].Foreground = Brushes.Green; } break;
                            case DayOfWeek.Sunday: Calender[j][6].Text = (i + 1).ToString(); if (already.Contains(n.ToString("yyyy-MM-dd"))) { Calender[j][6].Foreground = Brushes.Green; } j++; break;
                        }

                    }

                }
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            comboBox2_SelectionChanged(null, null);
        }
    }
}
