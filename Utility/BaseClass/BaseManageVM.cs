using Microsoft.Practices.Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// 管理ViewModel
    /// <para>
    /// 子类操作指南:
    /// 父类定义了默认的 T CurModel当前对象和 List&lt;T&gt; 集合对象 Models
    /// </para>
    /// <para> 定义了两个默认的命令 AddCommand (添加) 和FlushCommand (刷新)</para>
    /// <para> 还有对应的方法 AddExecute 和 FlushCommand 子类实现即可</para>
    /// <para>在LoadCommand();抽象方法中绑定子类的自定义命令集合</para>
    /// </summary>
    /// <typeparam name="T">实体类型</typeparam>
    public abstract class BaseManageVM<T> : BaseVM where T :new()
    {
        public BaseManageVM()
        {
            LoadBaseCommand();
        }

        #region 预制对象

        private T _curModel;

        /// <summary>
        /// 管理端列表当前对象
        /// </summary>
        public T CurrentModel
        {
            get
            {
                if (_curModel == null) _curModel = new T();
                return _curModel;
            }
            set
            {
                _curModel = value;
                RaisePropertyChanged("CurModel");
            }
        }

        private ObservableCollection<T> _models;

        /// <summary>
        /// 当前集合
        /// </summary>
        public ObservableCollection<T> ModelList
        {
            get
            {
                if (_models == null) _models = new ObservableCollection<T>();
                return _models;
            }
            set
            {
                _models = value;
                RaisePropertyChanged("Models");
            }
        }

        #endregion 预制对象

        #region 命令定义

        private DelegateCommand modifyCommand;
        /// <summary>
        /// 修改命令
        /// </summary>
        public DelegateCommand ModifyCommand
        {
            get { return modifyCommand; }
            set { modifyCommand = value; }
        }
        private DelegateCommand deleteCommand;
        /// <summary>
        /// 删除命令
        /// </summary>
        public DelegateCommand DeleteCommand
        {
            get { return deleteCommand; }
            set { deleteCommand = value; }
        }
        private DelegateCommand _addCommand;

        /// <summary>
        /// 添加命令
        /// </summary>
        public DelegateCommand AddCommand
        {
            get { return _addCommand; }
            set
            {
                _addCommand = value;
                RaisePropertyChanged("AddCommand");
            }
        }
        private DelegateCommand destroyAccountCommand;
        /// <summary>
        /// 销户命令
        /// </summary>
        public DelegateCommand DestroyAccountCommand
        {
            get { return destroyAccountCommand; }
            set { destroyAccountCommand = value; }
        }

        private DelegateCommand _flushCommand;

        /// <summary>
        /// 刷新命令
        /// </summary>
        public DelegateCommand FlushCommand
        {
            get { return _flushCommand; }
            set
            {
                _flushCommand = value;
                this.RaisePropertyChanged("FlushCommand");
            }
        }

        #endregion 命令定义

        #region 命令方法

        /// <summary>
        /// 添加
        /// </summary>
        public virtual void AddExecute() {; }

        /// <summary>
        /// 刷新
        /// </summary>
        public virtual void FlushExecute() {; }
        /// <summary>
        /// 修改
        /// </summary>
        public virtual void ModifyExecute() {; }

        /// <summary>
        ///删除
        /// </summary>
        public virtual void DeleteExecute() {; }
        public virtual void DestroyAccountExecute() {; }
        #endregion 命令方法

        #region 加载命令

        /// <summary>
        /// 加载默认命令
        /// </summary>
        private void LoadBaseCommand()
        {
            AddCommand = new DelegateCommand(AddExecute);
            ModifyCommand = new DelegateCommand(ModifyExecute);
            FlushCommand = new DelegateCommand(FlushExecute);
            DeleteCommand = new DelegateCommand(DeleteExecute);
            DestroyAccountCommand = new DelegateCommand(DestroyAccountExecute);
        }

        #endregion 加载命令
    }
}
