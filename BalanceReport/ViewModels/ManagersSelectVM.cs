using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.ViewModel;
using Microsoft.Practices.Prism.Commands;
using System.Windows;
using BalanceReport.Views;
namespace BalanceReport.ViewModels
{
    public class ManagersSelectVM:NotificationObject
    {
        //public ManagersSelectVM()
        //{
        //    AddManagersCommand = new DelegateCommand(AddManagersExecute);
        //    UpdateManagersCommand = new DelegateCommand(UpdateManagersExecute);
        //    DeleteManagersCommand = new DelegateCommand(DeleteManagersExecute);
        //    SearchManagersCommand = new DelegateCommand(SearchManagersExecute);
        //    OkManagersCommand = new DelegateCommand(OkManagersExecute);
        //    SearchManagersExecute();
        //}
        //#region 属性
        //public BalanceReport.Views.ManagersSelect ManagersSelectUI { get; set; }
        // private ManagersInfoModel _selectedManagersInfoModel;
        ///// <summary>
        /////被选中的行 
        ///// </summary>
        //public ManagersInfoModel SelectedManagersInfoModel
        //{
        //    get { return _selectedManagersInfoModel; }
        //    set { _selectedManagersInfoModel = value;
        //    this.RaisePropertyChanged("SelectedManagersInfoModel");
        //    }
        //}


        //private ManagersInfoModel _searchManagersInfoModel;
        ///// <summary>
        ///// 查询
        ///// </summary>
        //public ManagersInfoModel SearchManagersInfoModel
        //{
        //    get { return _searchManagersInfoModel; }
        //    set
        //    {
        //        _searchManagersInfoModel = value;
        //        this.RaisePropertyChanged("SearchManagersInfoModel");
        //    }
        //}
        //private ObservableCollection<ManagersInfoModel> _ManagersInfoList;
        ///// <summary>
        ///// 网点集合
        ///// </summary>
        //public ObservableCollection<ManagersInfoModel> ManagersInfoList
        //{
        //    get { return _ManagersInfoList; }
        //    set { _ManagersInfoList = value;
        //    this.RaisePropertyChanged("ManagersInfoList");
        //    }
        //}
       
        //#endregion
        //#region 命令
        //public DelegateCommand AddManagersCommand{get;set;}
        //public DelegateCommand UpdateManagersCommand { get; set; }
        //public DelegateCommand DeleteManagersCommand { get; set; }
        //public DelegateCommand SearchManagersCommand { get; set; }
        //public DelegateCommand OkManagersCommand { get; set; }
        
        //#endregion
        //#region 命令执行方法
        //private void AddManagersExecute()
        //{
        //    ManagersAdd waui=new ManagersAdd(true,null);
        //    waui.ShowDialog();
        //    SearchManagersExecute();
        //}
        //private void UpdateManagersExecute()
        //{
        //    if (SelectedManagersInfoModel != null)
        //    {
        //        ManagersAdd waui = new ManagersAdd(false,SelectedManagersInfoModel);
        //        waui.ShowDialog();
        //        SearchManagersExecute();
        //    }
        //}
        //private void DeleteManagersExecute()
        //{
        //    if (SelectedManagersInfoModel != null && SelectedManagersInfoModel.ID != null)
        //    {
        //        if (ManagersInfoDao.Instance.Delete(SelectedManagersInfoModel))
        //        {
        //            MessageBox.Show("删除成功");
        //            SearchManagersExecute(); 
        //        }
        //    }
        //}
        //private void SearchManagersExecute()
        //{
        //    if (SearchManagersInfoModel == null)
        //    {
        //        SearchManagersInfoModel = new ManagersInfoModel();
        //    }
        //    ManagersInfoList = ManagersInfoDao.Instance.GetManagersFromObject(SearchManagersInfoModel);
        //}
        ////public ManagersInfoModel ReturnManagersInfoModel { get; set; }
        //private void OkManagersExecute()
        //{
            
        //    if (SelectedManagersInfoModel !=null && ManagersSelectUI != null)
        //    {
        //        ManagersSelectUI.DialogResult = true; ;
        //    }
        //}

        //#endregion
        //#region 内部方法
        
        //#endregion
    }
}
