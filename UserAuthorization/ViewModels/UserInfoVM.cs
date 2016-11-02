
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;

using System.Data;

using System.Windows;
using MahApps.Metro.Controls;

using Encryption4Net;
using UserAuthorization.UserInfoService;
using Utility;

namespace UserAuthorization
{
    /// <summary>
    ///新建或修改
    /// </summary>
    public class UserInfoVM : BaseVM
    {
 
        public UserInfoServiceClient UserManageClient = new UserInfoServiceClient();
        Encryption ep = new Encryption();
        #region 构造加载
        public UserInfoVM()
        {
            LoadCommand();
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public  void LoadCommand()
        {

            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OkExecute);
           
        }

        UserInfo _SelectUser;
        public UserInfo SelectUser
        {
            get
            {
                if (_SelectUser == null)
                {
                    _SelectUser = new UserInfo();
                }
                return _SelectUser;
            }
            set
            {
                _SelectUser = value;
                RaisePropertyChanged("SelectUser");
            }
        }

        int _SelectedSexIndex;
        public int SelectedSexIndex
        {
            get
            {
                return _SelectedSexIndex;
            }
            set
            {
                _SelectedSexIndex = value;
                RaisePropertyChanged("SelectedSexIndex");
            }
        }
        
        #endregion 构造加载

        #region 变量属性

        public MetroWindow Owner { get; set; }


        private PasswordBox onePassword;
        /// <summary>
        /// 重复的密码
        /// </summary>
        public PasswordBox OnePassword
        {
            get
            {
                return onePassword;
            }

            set
            {
                onePassword = value;
            }
        }

        private PasswordBox repeatePassword;
        /// <summary>
        /// 重复的密码
        /// </summary>
        public PasswordBox RepeatePassword
        {
            get
            {
                return repeatePassword;
            }

            set
            {
                repeatePassword = value;
            }
        }

       
        #endregion 变量属性

        #region 命令定义


        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }
        /// <summary>
        /// 职责分配命令
        /// </summary>
        public Microsoft.Practices.Prism.Commands.DelegateCommand DutyAllocateCommand { get; set; }

        public bool IsAdd = true;
       


        #endregion 命令定义

        #region 命令方法
        public void OkExecute()
        {
            SelectUser.UserPwd = OnePassword.Password;
          
            if (string.IsNullOrWhiteSpace(SelectUser.UserName))
            {
                MessageBox.Show("登录名不能为空");
                return;
            }
           
            try
            {
                if (!IsAdd)
                {
                    if (SelectUser.UserPwd != RepeatePassword.Password)
                    {
                        MessageBox.Show("两次密码不一致");
                        return;
                    }
                    SelectUser.UserPwd = ep.EnCode(SelectUser.UserPwd);
                    if (UserManageClient.Update(SelectUser))
                    {
                        MessageBox.Show("用户信息修改成功！");
                    }
                }
                else
                {
                    UserInfo temp = new UserInfoService.UserInfo();
                    temp.UserName = SelectUser.UserName;
                    UserInfo[] users = UserManageClient.Select(temp);
                    if (users != null && users.Length > 0)
                    {
                        MessageBox.Show("登录名已存在，重新填写");
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(SelectUser.UserPwd))
                    {
                        MessageBox.Show("登录密码不能为空");
                        return;
                    }
                    if (SelectUser.UserPwd != RepeatePassword.Password)
                    {
                        MessageBox.Show("两次密码不一致");
                        return;
                    }
                    SelectUser.UserPwd = ep.EnCode(SelectUser.UserPwd);
                    SelectUser.State = 0;
                    SelectUser.Linktel = SelectUser.Linktel ?? "";
                    SelectUser.Email = SelectUser.Email ?? "";
                    SelectUser.Describe = SelectUser.Describe ?? "";
                    if (UserManageClient.Add(SelectUser))
                    {
                        MessageBox.Show("用户信息提交成功！");
                    }
                }
                if (this.Owner !=null )
                {
                    this.Owner.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }
        #endregion 命令方法
      
        public override void LoadPageData(int startindex, int endindex)
        {
            throw new NotImplementedException();
        }
    }
}