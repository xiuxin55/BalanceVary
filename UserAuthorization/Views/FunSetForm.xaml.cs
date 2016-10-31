
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserAuthorization
{
    /// <summary>
    /// FunSetForm.xaml 的交互逻辑
    /// </summary>
    public partial class FunSetForm : MetroWindow
    {
        public FunSetForm()
        {
            InitializeComponent();
        }
        public FunSetForm(string dutyid) : this()
        {
            this.dutyid = dutyid;
        }

        private string dutyid;

        public string Dutyid
        {
            get { return dutyid; }
            set { dutyid = value; }
        }

        private DataSet ds;

        private void FunSetForm_Load(object sender, RoutedEventArgs e)
        {
            
           
        }

        private void initTree(TreeView tree, DataTable fun)
        {
            
        }

        private void treeNotSet_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
        }

        private void treeSet_AfterCheck(object sender, TreeViewEventArgs e)
        {
           
        }
        private void SetNodeChecked(TreeNode tn, bool Checked)
        {
           
        }

        private void btnAddAll_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnDeleteAll_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
          
        }

        private void CopyNodes(TreeView sur, TreeView obj)
        {

        }

        private void deleteNotChecked(TreeNode tn)
        {
           
        }

        private void deleteChecked(TreeNode tn)
        {
           
        }

        private void nodesMarge(TreeNodeCollection sur, TreeNodeCollection obj)
        {
            
        }

        private void getfunID(TreeNodeCollection tnc, ref List<string> idlist)
        {
           
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}
