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
using BalanceReport.Dao;
using System.Web;
using System.Reflection;
using System.Collections.ObjectModel;
using BalanceReport.Models;
using System.Threading;
using BalanceReport.ViewModels;


namespace BalanceReport.Views
{
    /// <summary>
    /// ReportUserControl.xaml 的交互逻辑
    /// </summary>
    public partial class ReportUserControl : UserControl
    {
        private ReportUserControlVM VM;
        public ReportUserControl()
        {
            InitializeComponent();
           
            this.starttime.Text = DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd");
            this.endtime.Text = DateTime.Now.ToString("yyyy-MM-dd");
            this.Displaystate.SelectedIndex = 0;
            except0 = "1";
            VM =new ReportUserControlVM();
            this.DataContext = VM;
        }
        private Thread LoadTreeGrid;
        /// <summary>
        /// 市行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Checked(object sender, RoutedEventArgs e)
        {
            Jigou = "市行";
            this.LoadUserControl.Visibility = Visibility.Visible;
            this.TreeGrid.Visibility = Visibility.Collapsed;
            this.TreeGridAverage.Visibility = Visibility.Collapsed;
            string start=this.starttime.SelectedDate.Value.ToString("yyyy-MM-dd") ;
            string end= this.endtime.SelectedDate.Value.ToString("yyyy-MM-dd");
            string url = Common.CommonData.Instance.WebUrlStr.Trim();
            

            //this.Rate.Text = BalanceInfoDao.Instance.GetBalanceFromObject(start, end, "市行");
            recordurl = url + "?starttime=" + start + " &endtime=" + end + "&Insitusation=0" + "&Displaystate=" + DisplaystateIndex + "&except0=" + except0;
        
            starttimei=start;
            endtimei=end;
            Insitusationi="0";
            WebsiteNamei=null;
            Companyi=null;
            Accounti=null ;
            Displaystatei = DisplaystateIndex.ToString();
            if (LoadTreeGrid == null || LoadTreeGrid.IsAlive==false)
            {
                LoadTreeGrid = new Thread(new ThreadStart(CityBank));
                LoadTreeGrid.Start();
            }
            else
            {
                MessageBox.Show("请等待加载完毕，再操作");
            }
             //ProduceTree();
        }
        /// <summary>
        /// 县行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Checked(object sender, RoutedEventArgs e)
        {
            Jigou = "县行";

            this.LoadUserControl.Visibility = Visibility.Visible;
            this.TreeGrid.Visibility = Visibility.Collapsed;
            this.TreeGridAverage.Visibility = Visibility.Collapsed;
            string url = Common.CommonData.Instance.WebUrlStr.Trim();
            string start = this.starttime.SelectedDate.Value.ToString("yyyy-MM-dd");
            string end = this.endtime.SelectedDate.Value.ToString("yyyy-MM-dd");
           
            recordurl = url + "?starttime=" + start + "&endtime=" + end + "&Insitusation=1" + "&Displaystate=" + DisplaystateIndex + "&except0=" + except0 ;
     
            starttimei = start;
            endtimei = end;
            Insitusationi = "1";
            WebsiteNamei = null;
            Companyi = null;
            Accounti = null;
            Displaystatei = DisplaystateIndex.ToString();
            if (LoadTreeGrid == null || LoadTreeGrid.IsAlive == false)
            {
                LoadTreeGrid = new Thread(new ThreadStart(TwonBank));
                LoadTreeGrid.Start();
            }
            else
            {
                MessageBox.Show("请等待加载完毕，再操作");
            }
        }

        private void CityBank()
        {
            string rate = BalanceInfoDao.Instance.GetBalanceFromObject(starttimei, endtimei, "市行");
            
            VM.GetWebsiteByType(Jigou);
            this.Dispatcher.Invoke(new Action(delegate(){this.Rate.Text=rate;}));
            ProduceTree();
        }
        private void TwonBank()
        {
            string rate = BalanceInfoDao.Instance.GetBalanceFromObject(starttimei, endtimei, "县行");
            VM.GetWebsiteByType(Jigou);
            this.Dispatcher.Invoke(new Action(delegate() { this.Rate.Text = rate; }));
            ProduceTree();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            button1_Checked(null, null);
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            button2_Checked(null, null);
        }
        string Jigou = "";
        private void SearchWebsite_Click(object sender, RoutedEventArgs e)
        {
            if (Jigou == "") { MessageBox.Show("未选择机构（市行，县行）"); return; }
            if (Jigou == "市行")
            {
                this.LoadUserControl.Visibility = Visibility.Visible;
                this.TreeGrid.Visibility = Visibility.Collapsed;
                this.TreeGridAverage.Visibility = Visibility.Collapsed;
                string start = this.starttime.SelectedDate.Value.ToString("yyyy-MM-dd");
                string end = this.endtime.SelectedDate.Value.ToString("yyyy-MM-dd");
                string url = Common.CommonData.Instance.WebUrlStr.Trim();
                
                //HttpUtility.UrlEncode(nv[i], System.Text.Encoding.GetEncoding("GB2312")
               // byte[] temp =Encoding.Default.GetBytes();
                string result = this.txt_websitename.Text;// Encoding.GetEncoding("gb2312").GetString(temp);
                //this.Rate.Text = BalanceInfoDao.Instance.GetBalanceFromObject(start, end, "市行");
                recordurl = url + "?starttime=" + start + " &endtime=" + end + "&Insitusation=0&WebsiteName=" + result + "&Company=" + HttpUtility.UrlEncode(this.txt_companyname.Text) + "&Account=" + HttpUtility.UrlEncode(this.txt_accountname.Text) + "&Displaystate=" + DisplaystateIndex + "&except0=" + except0;
    

                starttimei = start;
                endtimei = end;
                Insitusationi = "0";
                WebsiteNamei = result;
                Companyi = this.txt_companyname.Text;
                Accounti = this.txt_accountname.Text;
                Displaystatei = DisplaystateIndex.ToString();
                if (LoadTreeGrid == null || LoadTreeGrid.IsAlive == false)
                {
                    LoadTreeGrid = new Thread(new ThreadStart(CityBank));
                    LoadTreeGrid.Start();
                }
                else
                {
                    MessageBox.Show("请等待加载完毕，再操作");
                }
            }
            else
            {
                this.LoadUserControl.Visibility = Visibility.Visible;
                this.TreeGrid.Visibility = Visibility.Collapsed;
                this.TreeGridAverage.Visibility = Visibility.Collapsed;
                string url = Common.CommonData.Instance.WebUrlStr.Trim();
                string start = this.starttime.SelectedDate.Value.ToString("yyyy-MM-dd");
                string end = this.endtime.SelectedDate.Value.ToString("yyyy-MM-dd");
                //this.Rate.Text = BalanceInfoDao.Instance.GetBalanceFromObject(start, end, "县行");
               // byte[] temp = Encoding.Default.GetBytes(this.txt_websitename.Text);
                string result = this.txt_websitename.Text;
                recordurl = url + "?starttime=" + start + " &endtime=" + end + "&Insitusation=1&WebsiteName=" + result + "&Company=" + HttpUtility.UrlEncode(this.txt_companyname.Text) + "&Account=" + HttpUtility.UrlEncode(this.txt_accountname.Text) + "&Displaystate=" + DisplaystateIndex + "&except0=" + except0;
         

                starttimei = start;
                endtimei = end;
                Insitusationi = "1";
                WebsiteNamei = result;
                Companyi = this.txt_companyname.Text;
                Accounti = this.txt_accountname.Text;
                Displaystatei = DisplaystateIndex.ToString();
                if (LoadTreeGrid == null || LoadTreeGrid.IsAlive == false)
                {
                    LoadTreeGrid = new Thread(new ThreadStart(TwonBank));
                    LoadTreeGrid.Start();
                }
                else
                {
                    MessageBox.Show("请等待加载完毕，再操作");
                }
            }
        }
        private string recordurl = "";
        private void WebBrowser_SizeChanged(object sender, EventArgs e)
        {
          
        }
        string starttimei, endtimei, Insitusationi, WebsiteNamei, Companyi, Accounti, Displaystatei, except0;
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //if (starttimei == null || endtimei == null || Insitusationi == null)
            //{
            //    return;
            //}
            //List<BalanceSrv.BalanceVaryModel> list = BalanceInfoDao.Instance.GetBalanceVary(starttimei, endtimei, Insitusationi, WebsiteNamei, Companyi, Accounti, Displaystatei, except0);
            //if (list.Count == 0)
            //{
            //    System.Windows.Forms.MessageBox.Show("导出内容不能为空");
            //    return;
            //}
            //System.Windows.Forms.SaveFileDialog fbd = new System.Windows.Forms.SaveFileDialog();
            //fbd.Filter = "excel(*.xls)|*.xls";
            //if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    BalanceInfoDao.Instance.ExportBalanceVary(list, fbd.FileName );
            //    System.Windows.Forms.MessageBox.Show("导出成功");
            //}
            if (this.Displaystate.SelectedIndex != 1)
            {
                MessageBox.Show("请选择日期内每日变动（相较前一天）查询，再导出"); return;
            }
            if (this.LoadUserControl.Visibility == Visibility.Collapsed)
            {
                if (selectresult == null)
                {
                    MessageBox.Show("数据不能为空");
                }
                else
                {
                    System.Windows.Forms.SaveFileDialog fbd = new System.Windows.Forms.SaveFileDialog();
                    fbd.Filter = "excel(*.xls)|*.xls";
                    if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        List<BalanceVaryModel> temp = (from i in selectresult where i.DifferWebsite != "公司" && i.DifferWebsite != "网点" select i).ToList<BalanceVaryModel>();
                        foreach (var item in temp)
                        {
                            List<BalanceVaryModel> accounts=(from i in selectresult where i.ID ==item.ParentID select i).ToList<BalanceVaryModel>();
                            if (accounts != null && accounts.Count != 0)
                            {
                                item.WebsiteName = accounts[0].WebsiteName;
                            }
                        }
                        BalanceInfoDao.Instance.ExportBalanceVary(temp, fbd.FileName);
                        System.Windows.Forms.MessageBox.Show("导出成功");
                    }
                }
            }
            else
            {
                MessageBox.Show("请等待数据加载完，再导出");
            }
        }
        int DisplaystateIndex=0;
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.Displaystate.SelectedItem != null)
            {
                //ComboBoxItem cbiyear = (ComboBoxItem)this.year.SelectedItem;
                ComboBoxItem cbimonth = (ComboBoxItem)this.Displaystate.SelectedItem;
                if (cbimonth.Content != null)
                {
                    if (this.Displaystate.SelectedIndex == 3)
                    {
                        this.TreeGridAverage.ItemsSource = null;
                        this.TreeGrid.Visibility = Visibility.Collapsed;
                        this.TreeGridAverage.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        this.TreeGrid.ItemsSource = null;
                        this.TreeGridAverage.Visibility = Visibility.Collapsed;
                        this.TreeGrid.Visibility = Visibility.Visible;
                       
                    }
                    DisplaystateIndex = this.Displaystate.SelectedIndex;
                }
            }
        }

        private void checkBox1_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.checkBox1.IsChecked)
            {
                except0 = "1";
            }
            else
            {
                except0 = "0";
            }
        }
        #region 加载TreeGrid
        private ObservableCollection<BalanceVaryModel> VaryBalance;
        private ObservableCollection<BalanceVaryModel> DataSource;
        #endregion
         private  void ProduceTree()
        {
            if (DisplaystateIndex != 3)
            {
                BuildDataSource();
                DataSource = new ObservableCollection<BalanceVaryModel>();
                foreach (var p in VaryBalance)
                {
                    p.PropertyChanged += p_PropertyChanged;
                    DataSource.Add(p);
                }
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    TreeGrid.ItemsSource = DataSource;
                    this.LoadUserControl.Visibility = Visibility.Collapsed;
                    this.TreeGrid.Visibility = Visibility.Visible;
                }));
            }
            else
            {
                 BuildDataSource();
                DataSource = new ObservableCollection<BalanceVaryModel>();
                foreach (var p in VaryBalance)
                {
                    p.PropertyChanged += p_PropertyChanged;
                    DataSource.Add(p);
                }
                this.Dispatcher.Invoke(new Action(delegate()
                {
                    this.TreeGridAverage.ItemsSource = DataSource;
                    this.LoadUserControl.Visibility = Visibility.Collapsed;
                    this.TreeGridAverage.Visibility = Visibility.Visible;
                }));
            }
            
        }

        void p_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var selectedObj = sender as BalanceVaryModel;
            if (selectedObj == null)
                return;
            if (selectedObj.IsChecked)
            {
                int next = DataSource.IndexOf(selectedObj) + 1;
                for (int i = 0; i < selectedObj.Subordinates.Count; i++)
                {
                    var p = selectedObj.Subordinates[i];
                    if (DataSource.FirstOrDefault(t => t.ID  == p.ID) != null)
                        return;
                    p.PropertyChanged += p_PropertyChanged;
                    p.IsChecked = false;
                    DataSource.Insert(next++, p);
                }
            }
            else if (!selectedObj.IsChecked)
            {
                for (int i = 0; i < selectedObj.Subordinates.Count; i++)
                {
                    var p = selectedObj.Subordinates[i];
                    RemoveNode(p);
                }
            }
        }

        private void RemoveNode(BalanceVaryModel person)
        {
            for (int i = 0; i < person.Subordinates.Count; i++)
            {
                var p = person.Subordinates[i];
                RemoveNode(p);
            }
            for (int i = 0; i < DataSource.Count; i++)
            {
                var p = DataSource[i];
                if (p.ID == person.ID)
                    DataSource.Remove(p);
            }
        }
        private ObservableCollection<BalanceVaryModel> selectresult;
        private void BuildDataSource()
        {
            VaryBalance = new ObservableCollection<BalanceVaryModel>();
            selectresult = DisplayBalance.Instance.GetBalanceVary(starttimei, endtimei, Insitusationi, WebsiteNamei, Companyi, Accounti, Displaystatei, except0);
            
            VaryBalance = GetTreeNodes(selectresult);
            
        }
        private ObservableCollection<BalanceVaryModel> GetTreeNodes(ObservableCollection<BalanceVaryModel> mlist)
        {
            ObservableCollection<BalanceVaryModel> TreeNodes = new ObservableCollection<BalanceVaryModel>();
            foreach (BalanceVaryModel item in mlist.Where(i=>i.ParentID=="" ||i.ParentID==null))
            {
          
                item.Subordinates=GetChildrenNodes(mlist,item.ID,10);
                if (item.Subordinates.Count == 0)
                {
                    item.IsVisible = Visibility.Collapsed;
                }
                TreeNodes.Add(item);
            }
            return TreeNodes;
        }
        private ObservableCollection<BalanceVaryModel> GetChildrenNodes(ObservableCollection<BalanceVaryModel> mlist, string id,double marinleft)
        {
            ObservableCollection<BalanceVaryModel> t = new ObservableCollection<BalanceVaryModel>();
            foreach (var item in mlist.Where(i=>i.ParentID!="" && i.ParentID!=null && i.ParentID ==id))
            {
                item.MarginLeft=marinleft ;
                item.Subordinates = GetChildrenNodes(mlist, item.ID, marinleft+20);
                if (item.Subordinates.Count == 0)
                {
                    item.IsVisible = Visibility.Collapsed;
                }
                t.Add(item);
            }
            return t;
        }
    }
}
