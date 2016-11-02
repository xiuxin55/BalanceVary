
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using Encryption4Net;
using UserAuthorization.FunctionInfoService;
using Utility;
using UserAuthorization;

namespace FunctionAuthorization
{
    /// <summary>
    ///用户管理
    /// </summary>
    public class FunctionMaintenanceVM:BaseManageVM<FunctionInfo>
    {
        FunctionInfoServiceClient FunctionManageClient ;
        #region 构造加载
        public FunctionMaintenanceVM()
        {
            try
            {
                FunctionManageClient = new FunctionInfoServiceClient();
                LoadCommand();
                LoadData();
            }
            catch (Exception ex)
            {

                throw ex;
            }
           
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public  void LoadCommand()
        {
            SearchCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(SearchExecute);
            AuthorizeCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AuthorizeExecute);
            NewFlushCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LoadData);
            LockCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(LockExecute);
            FunctionMaintainList = new ObservableCollection<FunctionInfo>();
        }
        private List<FunctionInfo> CacheFunctionList = new List<FunctionInfo>();
        ObservableCollection<FunctionInfo> _FunctionMaintainList;
        public ObservableCollection<FunctionInfo> FunctionMaintainList
        {
            get
            {
                return _FunctionMaintainList;
            }
            set
            {
                _FunctionMaintainList = value;
                RaisePropertyChanged("FunctionMaintainList");
            }

        }
        FunctionInfo _SelectFunction;
        public FunctionInfo SelectFunction
        {
            get
            {
                return _SelectFunction;
            }
            set
            {
                _SelectFunction = value;
                RaisePropertyChanged("SelectFunction");
            }
        }
        public  void LoadData()
        {
            FunctionMaintainList = new ObservableCollection<FunctionInfo>(FunctionManageClient.Select(null));
        }
        
        #endregion 构造加载

        #region 变量属性


        #endregion 变量属性

        #region 命令定义

   
        private Microsoft.Practices.Prism.Commands.DelegateCommand _searchCommand;
        private Microsoft.Practices.Prism.Commands.DelegateCommand _authorizeCommand;//授权命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand newFlushCommand;//新的刷新命令
        private Microsoft.Practices.Prism.Commands.DelegateCommand _LockCommand;//锁定解锁命令
        public Microsoft.Practices.Prism.Commands.DelegateCommand LockCommand
        {
            get { return _LockCommand; }
            set { _LockCommand = value; this.RaisePropertyChanged("LockCommand"); }
        }


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
            FunctionAdd di = new FunctionAdd();
            di.VM.SelectFunction = new FunctionInfo();
            di.VM.SelectFunction.ID = Guid.NewGuid().ToString();
            di.VM.IsAdd = true;
            di.ShowDialog();
            LoadData();
        }
        public override void ModifyExecute()
        {
            FunctionAdd di = new FunctionAdd();
            di.VM.SelectFunction = SelectFunction;
            di.VM.IsAdd = false;
            di.ShowDialog();
            LoadData();

        }
        public override void DeleteExecute()
        {
            if (SelectFunction != null)
            {
                if (System.Windows.Forms.MessageBox.Show("是否删除 " + SelectFunction.Name + " 的功能", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    FunctionInfo temp = new FunctionInfo();
                    temp.ID = SelectFunction.ID;
                    if (FunctionManageClient.Delete(temp))
                    {
                        MessageBox.Show("删除成功！");
                        FunctionMaintainList.Remove(SelectFunction);
                    }
                }
            }
        }
        private void SearchExecute()
        {
            //FunctionMaintainList.Clear();
            //if(Condition ==null)
            //{
            //    FunctionMaintainList = new ObservableCollection<FunctionInfo>(FunctionManageClient.Select(null));
            //    return;
            //}
            //FunctionInfo temp = new FunctionInfo();
            //temp.FunctionName = Condition;
            //FunctionMaintainList = new ObservableCollection<FunctionInfo>(FunctionManageClient.Select(temp));
   
        }
        private void AuthorizeExecute()
        {
            //if (SelectFunction != null && SelectFunction.ID != null)
            //{
            //    FunctionFunSet fsf = new FunctionFunSet();
            //    fsf.VM.SelectFunction = SelectFunction;
            //    fsf.ShowDialog();

            //}
        }
        /// <summary>
        /// 锁定解锁
        /// </summary>
        private void LockExecute()
        {
           
        }

        public override void LoadPageData(int startindex, int endindex)
        {
            throw new NotImplementedException();
        }
        #endregion 命令方法


    }

   
}