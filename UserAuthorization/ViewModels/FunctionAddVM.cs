using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Data;
using System.Windows;
using MahApps.Metro.Controls;
using Encryption4Net;
using UserAuthorization.FunctionInfoService;
using Utility;
using Microsoft.Win32;
using System.Reflection;
using UserAuthorization;

namespace FunctionAuthorization
{
    /// <summary>
    ///新建或修改
    /// </summary>
    public class FunctionAddVM : BaseVM
    {
 
        public FunctionInfoServiceClient Client = new FunctionInfoServiceClient();
      
        #region 构造加载
        public FunctionAddVM()
        {
            LoadCommand();
        }
        /// <summary>
        /// 加载命令
        /// </summary>
        public  void LoadCommand()
        {

            OKCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OkExecute);
            BrowseCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(BrowseExecute);
        }

        FunctionInfo _SelectFunction;
        public FunctionInfo SelectFunction
        {
            get
            {
                if (_SelectFunction == null)
                {
                    _SelectFunction = new FunctionInfo();
                }
                return _SelectFunction;
            }
            set
            {
                _SelectFunction = value;
                RaisePropertyChanged("SelectFunction");
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
        #endregion 变量属性

        #region 命令定义


        public Microsoft.Practices.Prism.Commands.DelegateCommand OKCommand { get; set; }
        public Microsoft.Practices.Prism.Commands.DelegateCommand BrowseCommand { get; set; }
        
        public bool IsAdd = true;
        #endregion 命令定义

        #region 命令方法
        private  void OkExecute()
        {
            if (string.IsNullOrWhiteSpace(SelectFunction.AssemblyName))
            {
                MessageBox.Show("请先选择程序集");
                return;
            }
            if (string.IsNullOrWhiteSpace(SelectFunction.Name ))
            {
                MessageBox.Show("名字不能为空");
                return;
            }
            if (string.IsNullOrWhiteSpace(SelectFunction.ClassName))
            {
                MessageBox.Show("类名不能为空");
                return;
            }
            try
            {
                if (!IsAdd)
                {
                    if (Client.Update(SelectFunction))
                    {
                        MessageBox.Show("修改成功！");
                    }
                }
                else
                {
       
                    if (Client.Add(SelectFunction))
                    {
                        MessageBox.Show("提交成功！");
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
        private void BrowseExecute()
        {
            OpenFileDialog op = new OpenFileDialog();
            if ((bool)op.ShowDialog())
            {
                if (!string.IsNullOrEmpty(op.SafeFileName))
                {
                    Assembly abll = Assembly.LoadFile(op.FileName);
                    if (abll !=null)
                    {
                        SelectFunction.AssemblyName = abll.FullName;
                        Type[] types = abll.GetTypes();
                        ObservableCollection<string> classNameList = new ObservableCollection<string>();
                        foreach (var item in types)
                        {
                            if (item.IsSubclassOf( typeof(Window))|| item.IsSubclassOf(typeof(Control)) )
                            {
                                classNameList.Add(item.FullName);
                            }
                           
                        }
                        ClassNameView view = new ClassNameView();
                        view.VM.ClassNameList = classNameList;
                        bool? winResult = view.ShowDialog();
                        if (winResult!=null&& winResult.Value)
                        {
                            SelectFunction.ClassName = view.VM.SelectedClassName;
                        }
                    }
                    else
                    {
                        MessageBox.Show("请选择正确的程序集！");
                    }
                   
                }
                
            }
        }
        #endregion 命令方法

        public override void LoadPageData(int startindex, int endindex)
        {
            throw new NotImplementedException();
        }
    }
}