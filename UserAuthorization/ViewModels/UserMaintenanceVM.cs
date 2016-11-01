
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using Encryption4Net;
using UserAuthorization.UserInfoService;
using Utility;

namespace UserAuthorization
{
    /// <summary>
    ///用户管理
    /// </summary>
    public class UserMaintenanceVM:BaseManageVM<UserInfo>
    {
        UserInfoServiceClient UserManageClient ;
        #region 构造加载
        public UserMaintenanceVM()
        {
            try
            {
                UserManageClient = new UserInfoServiceClient();
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
            UserMaintainList = new ObservableCollection<UserInfo>();
        }
        private List<UserInfo> CacheUserList = new List<UserInfo>();
        ObservableCollection<UserInfo> _UserMaintainList;
        public ObservableCollection<UserInfo> UserMaintainList
        {
            get
            {
                return _UserMaintainList;
            }
            set
            {
                _UserMaintainList = value;
                RaisePropertyChanged("UserMaintainList");
            }

        }
        UserInfo _SelectUser;
        public UserInfo SelectUser
        {
            get
            {
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("SelectUser");
            }
        }
        public  void LoadData()
        {
      
            UserMaintainList = new ObservableCollection<UserInfo>(UserManageClient.Select(null));
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
            UserInfoAdd di = new UserInfoAdd();
            di.VM.SelectUser = new UserInfo();
            di.VM.SelectUser.ID  = Guid.NewGuid().ToString();
            di.VM.IsAdd = true;
            di.ShowDialog();
            LoadData();
        }
        public override void ModifyExecute()
        {
            UserInfoAdd di = new UserInfoAdd();
            di.VM.SelectUser = SelectUser;
            //di.VM.LoadOwnDutyList();
            di.VM.IsAdd = false;
            di.ShowDialog();
            LoadData();
            
        }
        public override void DeleteExecute()
        {
            if(SelectUser!=null)
            {
                if (System.Windows.Forms.MessageBox.Show("是否删除用户名为 " + SelectUser.UserName + " 的用户信息", "系统提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    UserInfo temp = new UserInfo();
                    temp.ID = SelectUser.ID;
                    if (UserManageClient.Delete(temp))
                    {
                        MessageBox.Show("删除成功！");
                        UserMaintainList.Remove(SelectUser);
                    }
                }
            }
        }
        private void SearchExecute()
        {
            UserMaintainList.Clear();
            if(Condition ==null)
            {
                UserMaintainList = new ObservableCollection<UserInfo>(UserManageClient.Select(null));
                return;
            }
            UserInfo temp = new UserInfo();
            temp.UserName = Condition;
            UserMaintainList = new ObservableCollection<UserInfo>(UserManageClient.Select(temp));
   
        }
        private void AuthorizeExecute()
        {
            //if (SelectUser != null && SelectUser.UserId != null)
            //{
            //    FunSetForm fsf = new FunSetForm(SelectUser.UserId);
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