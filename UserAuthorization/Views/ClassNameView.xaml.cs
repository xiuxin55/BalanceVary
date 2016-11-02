
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserAuthorization
{
    /// <summary>
    /// ClassNameView.xaml 的交互逻辑
    /// </summary>
    public partial class ClassNameView : MetroWindow
    {
        public ClassNameView()
        {
            InitializeComponent();
            VM = new ClassNameViewVM();
            this.DataContext = VM;

        }
        public ClassNameViewVM VM { get; set; }
        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(VM.SelectedClassName))
            {
                MessageBox.Show("请选择一个类");
                return;
            }
            this.DialogResult = true;
        }

    }

    public class ClassNameViewVM: INotifyPropertyChanged
    {
        private ObservableCollection<string> _ClassNameList;
        public ObservableCollection<string> ClassNameList
        {
            get { return _ClassNameList; }
            set
            {
                _ClassNameList = value;
                this.RaisePropertyChanged("ClassNameList");
            }
        }

        private string _SelectedClassName;
        public string SelectedClassName
        {
            get { return _SelectedClassName; }
            set
            {
                _SelectedClassName = value;
                this.RaisePropertyChanged("SelectedClassName");
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
