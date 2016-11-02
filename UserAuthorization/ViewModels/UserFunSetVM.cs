
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

using System.Data;

using System.Windows;
using MahApps.Metro.Controls;

using Encryption4Net;
using UserAuthorization.UserFuncInfoService;
using Utility;
using UserAuthorization.FunctionInfoService;
using Microsoft.Practices.Prism.ViewModel;

namespace UserAuthorization
{
    /// <summary>
    ///新建或修改
    /// </summary>
    public class UserFunSetVM : BaseVM
    {
 
        public UserFuncInfoService.UserFuncInfoServiceClient  userFuncClient = new UserFuncInfoServiceClient();
        public FunctionInfoService.FunctionInfoServiceClient funcClient = new FunctionInfoServiceClient();

        #region 构造加载
        public UserFunSetVM()
        {
            LoadCommand();
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public  void LoadCommand()
        {

            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OkExecute);
            AddCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddExecute);
            RemoveCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(RemoveExecute);

        }

        UserInfoService.UserInfo _SelectUser;
        public UserInfoService.UserInfo SelectUser
        {
            get
            {
                if (_SelectUser == null)
                {
                    _SelectUser = new UserInfoService.UserInfo();
                }
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("SelectUser");
            }
        }

        ObservableCollection<FunctionModel> _UnAllocateFunctions;
        public ObservableCollection<FunctionModel> UnAllocateFunctions
        {
            get
            {
                return _UnAllocateFunctions;
            }
            set
            {
                _UnAllocateFunctions = value;
                RaisePropertyChanged("UnAllocateFunctions");
            }
        }

        ObservableCollection<FunctionModel> _AllocatedFunctions;
        public ObservableCollection<FunctionModel> AllocatedFunctions
        {
            get
            {
                return _AllocatedFunctions;
            }
            set
            {
                _AllocatedFunctions = value;
                RaisePropertyChanged("AllocatedFunctions");
            }
        }

        #endregion 构造加载

        #region 变量属性

        public MetroWindow Owner { get; set; }

        #endregion 变量属性

        #region 命令定义

        /// <summary>
        /// 
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }

        public Microsoft.Practices.Prism.Commands.DelegateCommand AddCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand RemoveCommand { get; set; }

        public bool IsAdd = true;
       


        #endregion 命令定义

        #region 命令方法
        private  void OkExecute()
        {
            try
            {
                UserFuncInfo uf = new UserFuncInfo();
                uf.UserId = SelectUser.ID;
                userFuncClient.Delete(uf);
                foreach (var item in AllocatedFunctions)
                {
                    UserFuncInfo temp = new UserFuncInfo();
                    temp.ID = Guid.NewGuid().ToString();
                    temp.UserId = SelectUser.ID;
                    temp.FunId = item.ID;
                    userFuncClient.Add(temp);
                }
                MessageBox.Show("提交成功");
                if (Owner!=null)
                {
                    Owner.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        private void AddExecute()
        {
            List<FunctionModel> tempUnAllocateds = UnAllocateFunctions.ToList();
            foreach (var item in tempUnAllocateds)
            {
                if (UnAllocateFunctions.Contains(item)&&item.IsSelected)
                {
                    UnAllocateFunctions.Remove(item);
                    AllocatedFunctions.Add(item);
                }
            }
        }
        private void RemoveExecute()
        {
            List<FunctionModel> tempAllocateds = AllocatedFunctions.ToList();
            foreach (var item in tempAllocateds)
            {
                if (AllocatedFunctions.Contains(item) && item.IsSelected)
                {
                    UnAllocateFunctions.Add(item);
                    AllocatedFunctions.Remove(item);
                }
            }
        }
        
        #endregion 命令方法

        public override void LoadPageData(int startindex, int endindex)
        {
            throw new NotImplementedException();
        }

        public void LoadData()
        {
            UnAllocateFunctions = new ObservableCollection<FunctionModel>();
            AllocatedFunctions = new ObservableCollection<FunctionModel>();
            FunctionInfo[] allFunctions = funcClient.Select(null);
            UserFuncInfo uf = new UserFuncInfo();
            uf.UserId = SelectUser.ID;
            UserFuncInfo[] allocatedFunctions = userFuncClient.Select(uf);
            foreach (var item in allFunctions)
            {
                bool ishas = false;
                foreach (var item2 in allocatedFunctions)
                {
                    if (item.ID ==item2.FunId  )
                    {
                        FunctionModel fm = new UserAuthorization.FunctionModel();
                        fm.ID = item.ID;
                        fm.Name = item.Name;
                        fm.IsSelected = false;
                        AllocatedFunctions.Add(fm);
                        ishas = true;
                    }
                }
                if (!ishas)
                {
                    FunctionModel fm = new UserAuthorization.FunctionModel();
                    fm.ID = item.ID;
                    fm.Name = item.Name;
                    fm.IsSelected = false;
                    UnAllocateFunctions.Add(fm);
                    ishas = true;
                }
            }
        }
    }

    public class FunctionModel: NotificationObject
    {
        private string _ID;

        public string ID
        {
            get { return _ID; }
            set { _ID = value;
                this.RaisePropertyChanged("ID");
            }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value;
                this.RaisePropertyChanged("Name");
            }
        }
        private bool _IsSelected;

        public bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

    }
}