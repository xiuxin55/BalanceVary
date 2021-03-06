﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport;
using BalanceReport.Salary;
using UserAuthorization;
using UserAuthorization.UserInfoService;
using System.Windows.Controls;
using Encryption4Net;
using Common.Client;
using UserAuthorization.Helper;
using MahApps.Metro.Controls;
using System.Reflection;

namespace MainHome
{
    public class LoginVM : NotificationObject
    {
       
        public LoginVM()
        {
            LoginCommand = new DelegateCommand(LoginExecute);
            UserModel = new UserInfo();
            
        }
        public MetroWindow LoginWin;
        #region 属性
        private PasswordBox _Password;
        /// <summary>
        /// 密码
        /// </summary>
        public PasswordBox Password
        {
            get
            {
                return _Password;
            }

            set
            {
                _Password = value;
            }
        }

        UserInfo _SelectUser;
        public UserInfo UserModel
        {
            get
            {
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("UserModel");
            }
        }
        public Window WinOwner { get; set; }
        #endregion
        #region 命令
        public DelegateCommand LoginCommand { get; set; }

        #endregion
        #region 命令执行方法
        private void LoginExecute()
        {
            //Assembly abll = Assembly.LoadFrom(CommonDataClient.AutoUpdateDLLPath + CommonDataClient.AutoUpdateDLLFile);
            //Window frmAutoUpdate = (Window)abll.CreateInstance("AutoUpdate.AutoUpdateWindow");
            if (UserLoginHelper.Instance.CheckLogin(UserModel.UserName, Password.Password))
            {

                MainWindow win = new MainWindow();
                Application.Current.MainWindow = win;
                win.Show();
                if (LoginWin != null)
                {
                    LoginWin.Hide();
                }
            }
            else
            {
                MessageBox.Show("帐号或密码错误");
            }
        }
       
        #endregion
        #region 内部方法

        #endregion
    }
}
