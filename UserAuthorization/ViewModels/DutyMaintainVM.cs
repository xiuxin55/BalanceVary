using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using FinancialRegulation.Page.Fund;
using FinancialRegulation.ViewModel;
using System.Data;
using FundsRegulatoryClient;
using System.Windows;


namespace UserAuthorization
{
    /// <summary>
    ///职责管理
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class DutyMaintainVM : BaseManageVM<DutyModel>
    {


        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            AddCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddExecute);
            ModifyCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(ModifyExecute);
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            DeleteCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(DeleteExecute);
            AuthorizeCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AuthorizeExecute);
            NewFlushCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LoadData);
            DutyMaintainList = new ObservableCollection<DutyModel>();
        }
        private List<DutyModel> CacheDutyList = new List<DutyModel>();
        ObservableCollection<DutyModel> _DutyMaintainList;
        public ObservableCollection<DutyModel> DutyMaintainList
        {
            get
            {
                return _DutyMaintainList;
            }
            set
            {
                _DutyMaintainList = value;
                RaisePropertyChanged("DutyMaintainList");
            }

        }
        DutyModel _SelectDuty;
        public DutyModel SelectDuty
        {
            get
            {
                return _SelectDuty;
            }
            set
            {
                _SelectDuty = value;
                RaisePropertyChanged("SelectDuty");
            }
        }
        public override void LoadData()
        {
            DutyMaintainList.Clear();
            DutyMaintainList = new ObservableCollection<DutyModel>(GetData());


        }
        private List<DutyModel> GetData()
        {
            DataSet dsAllDuty = DutyManageClient.Current.GetAllDuty();
            return DataSetToModel.DutyToModel(dsAllDuty,0);
        }
        #endregion 构造加载

        #region 变量属性

        private string _condition;

        /// <summary>
        /// 查询条件
        /// </summary>
        public string Condition
        {
            get { return _condition; }
            set
            {
                _condition = value;
                RaisePropertyChanged("Condition");
            }
        }

        #endregion 变量属性

        #region 命令定义

   
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _authorizeCommand;//授权命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand newFlushCommand;//新的刷新命令

        public Microsoft.Practices.Prism.Commands.DelegateCommand NewFlushCommand
        {
            get { return newFlushCommand; }
            set { newFlushCommand = value; this.RaisePropertyChanged("NewFlushCommand"); }
        }
        

        /// <summary>
        /// 授权命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand AuthorizeCommand
        {
            get { return _authorizeCommand; }
            set { _authorizeCommand = value; }
        }

       
        /// <summary>
        /// 查询筛选
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand SearchCommand
        {
            get
            {
                return _searchCommand;
            }
            set
            {
                _searchCommand = value;
            }
        }

        #endregion 命令定义

        #region 命令方法
        public override void AddExecute()
        {
            DutyInfo di = new DutyInfo();
            di.ShowDialog();
            LoadData();
        }
        public override void ModifyExecute()
        {
            DutyInfo di = new DutyInfo();
            di.VM.SelectDuty = SelectDuty;
            di.ShowDialog();
            
        }
        public override void DeleteExecute()
        {
            if(SelectDuty!=null)
            {
                if (System.Windows.Forms.MessageBox.Show("是否删除编号为 " + SelectDuty.DutyCode + " 职责的信息", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    if (DutyManageClient.Current.DeleteDutyByID(SelectDuty.DutyId) == "1")
                    {
                        MessageBox.Show("删除成功！");
                        DutyMaintainList.Remove(SelectDuty);
                    }
                }
            }
        }
        private void SearchExecute()
        {
            DutyMaintainList.Clear();
            if(Condition ==null)
            {
                DutyMaintainList = new ObservableCollection<DutyModel>(GetData());
                return;
            }
            CacheDutyList = GetData();
            foreach (var item in CacheDutyList)
            {
                if(item.DutyCode.Contains(Condition) || item.DutyName.Contains(Condition) || item.DutyDescribe.Contains(Condition))
                {
                    DutyMaintainList.Add(item.Clone());
                }
            }
        }
        private void AuthorizeExecute()
        {
            if (SelectDuty != null && SelectDuty.DutyId != null)
            {
                FunSetForm fsf = new FunSetForm(SelectDuty.DutyId);
                fsf.ShowDialog();
            }
        }
        #endregion 命令方法

        
    }

   
}