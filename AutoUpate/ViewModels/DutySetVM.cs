using AvalonDock;
using System;
using System.Linq;
using System.Collections.Generic;
using FundsRegulatoryClient.JG_DepositSrv;
using System.Collections.ObjectModel;

using FinancialRegulation.Page.Fund;
using FinancialRegulation.ViewModel;
using System.Data;
using FundsRegulatoryClient;
using System.Windows;
using MahApps.Metro.Controls;
using FundsRegulatoryClient.UserDutyManagerSrv;


namespace UserAuthorization
{
    /// <summary>
    ///新建或修改职责
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("DEEF5BD6-8EB4-41E8-8849-48347844D170")]
    public class DutySetVM : BaseManageVM<DutyModel>
    {


        #region 构造加载

        /// <summary>
        /// 加载命令
        /// </summary>
        public override void LoadCommand()
        {
            AddCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand<object>(AddExecute);
            AddAllCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(AddAllExecute);
            RemoveCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand<object>(RemoveExecute);
            RemoveAllCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(RemoveAllExecute);

        }
        public  void InitialData()
        {
            DataSet dsUserDuty = UserDutyManagerClient.Current.GetUserDutyByID(UserID);
            AllocateDutyList = new ObservableCollection<DutyModel>(DataSetToModel.UserDutyToModel(dsUserDuty, 0));
            UnAllocateDutyList = new ObservableCollection<DutyModel>(DataSetToModel.UserDutyToModel3(dsUserDuty, 1));
        }
        DutyModel _SelectDuty;
        public DutyModel SelectDuty
        {
            get
            {
                if (_SelectDuty==null)
                {
                    _SelectDuty = new DutyModel();
                }
                return _SelectDuty;
            }
            set
            {
                _SelectDuty = value;
                RaisePropertyChanged("SelectDuty");
            }
        }
        DutyModel _UnSelectDuty;
        public DutyModel UnSelectDuty
        {
            get
            {
                if (_SelectDuty == null)
                {
                    _SelectDuty = new DutyModel();
                }
                return _SelectDuty;
            }
            set
            {
                _SelectDuty = value;
                RaisePropertyChanged("UnSelectDuty");
            }
        }

        ObservableCollection<DutyModel> _UnAllocateDutyList;
        public ObservableCollection<DutyModel> UnAllocateDutyList
        {
            get
            {
                if (_UnAllocateDutyList == null)
                    _UnAllocateDutyList = new ObservableCollection<DutyModel>();
                return _UnAllocateDutyList;
            }
            set
            {
                _UnAllocateDutyList = value;
                RaisePropertyChanged("UnAllocateDutyList");
            }

        }

        ObservableCollection<DutyModel> _AllocateDutyList;
        public ObservableCollection<DutyModel> AllocateDutyList
        {
            get
            {
                if (_AllocateDutyList == null)
                    _AllocateDutyList = new ObservableCollection<DutyModel>();
                return _AllocateDutyList;
            }
            set
            {
                _AllocateDutyList = value;
                RaisePropertyChanged("AllocateDutyList");
            }
        }


        #endregion 构造加载

        #region 变量属性
        public MetroWindow Owner { get; set; }
        private string userID;
        public string UserID
        {
            get { return userID; }
            set { userID = value; }
        }
        #endregion 变量属性

        #region 命令定义
        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }

        public new  Microsoft.Practices.Prism.Commands.DelegateCommand<object> AddCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand AddAllCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand<object> RemoveCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand RemoveAllCommand { get; set; }

        #endregion 命令定义

        #region 命令方法
        private  void AddExecute(object obj)
        {

            System.Collections.IList SelectedItems = obj as System.Collections.IList;
            if (SelectedItems!= null)
            {
                List<UserDuty> lsUserDuty = new List<UserDuty>();
                foreach (var item in SelectedItems)
                {
                    DutyModel dm = (DutyModel)item;
                    UserDuty ud = new UserDuty();
                    ud.UserID = UserID;
                    ud.DutyID = dm.DutyId;
                    lsUserDuty.Add(ud);
                }

                FundsRegulatoryClient.UserDutyManagerSrv.UserDuty[] userdutys = lsUserDuty.ToArray();
                if (UserDutyManagerClient.Current.LicendToUser(userdutys) == "1")
                {
                    InitialData();
                }
            }
        }

        private void AddAllExecute()
        {
            List<UserDuty> lsUserDuty = new List<UserDuty>();
            foreach (var item in UnAllocateDutyList)
            {
                UserDuty ud = new UserDuty();
                ud.UserID = UserID;
                ud.DutyID = item.DutyId;
                lsUserDuty.Add(ud);
            }
            FundsRegulatoryClient.UserDutyManagerSrv.UserDuty[] userdutys = lsUserDuty.ToArray();
            if (UserDutyManagerClient.Current.LicendToUser(userdutys) == "1")
            {
                InitialData();
            }
        }
        private void RemoveExecute(object obj)
        {
            System.Collections.IList SelectedItems = obj as System.Collections.IList;
            if (SelectedItems != null)
            {
                List<string> lsUserDuty = new List<string>();
                foreach (var item in SelectedItems)
                {
                    DutyModel dm = (DutyModel)item;
                    lsUserDuty.Add(dm.UserDutyID);
                }
                if (UserDutyManagerClient.Current.RemoveDuty(lsUserDuty.ToArray()) == "1")
                {
                    InitialData();
                }
            }
        }

        private void RemoveAllExecute()
        {
            List<string> lsUserDuty = new List<string>();
            foreach (var item in AllocateDutyList)
            {
                lsUserDuty.Add(item.UserDutyID);
            }
            if (UserDutyManagerClient.Current.RemoveDuty(lsUserDuty.ToArray()) == "1")
            {
                InitialData();
            }
        }
       
        #endregion 命令方法


    }
}