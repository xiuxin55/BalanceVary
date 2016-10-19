using BalanceBLL;
using BalanceModel;
using Common.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalanceDataSync
{
    public class SyncDataHandler : ISyncDataHandler
    {

        List<ImportDataInfo> ImportDataList = new List<ImportDataInfo>();
        List<AccountLinkManagerInfo> ImportLinkDataList = new List<AccountLinkManagerInfo>();
        List<UploadFileInfo> UploadFileInfoList = new List<UploadFileInfo>();
        public Action<UploadFileInfo> NotifyFileStateChange = null;
        public SyncDataHandler(List<UploadFileInfo> uploadFileInfoList)
        {
            this.UploadFileInfoList = uploadFileInfoList;
        }
        /// <summary>
        /// 导入日数据
        /// </summary>
        public  void ImportDayData()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.ToLower().Contains("day"));
            foreach (var item in filelist)
            {

                try
                {
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    ImportDataList = ReadExcel.ReadDayData(item.FilePath + item.FileName, item.FileDateTime.Value);
                    if (ImportDataList == null || ImportDataList.Count == 0)
                    {
                        return;
                    }
                    CalculateData();
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }

        }
        public void ImportCustomerLink()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.Contains("CustomerManagerLinkAccount"));
            foreach (var item in filelist)
            {
                try
                {
                    ImportLinkDataList = ReadExcel.ReadCustomerLinkData(item.FilePath + item.FileName);
                    DataDivideStore();
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 导入月数据
        /// </summary>
        public  void ImportMonthData()
        {
            IEnumerable<UploadFileInfo> filelist = UploadFileInfoList.Where(p => p.FileName.ToLower().Contains("month"));
            foreach (var item in filelist)
            {
               
                try
                {
                    if(NotifyFileStateChange!=null)
                    {
                        NotifyFileStateChange(item);
                    }
                    ImportDataList = ReadExcel.ReadMonthData(item.FilePath + item.FileName, item.FileDateTime.Value);
                    if (ImportDataList == null || ImportDataList.Count == 0)
                    {
                        return;
                    }
                    CalculateData();
                    item.FileState = 1;
                }
                catch (Exception ex)
                {

                    item.FileState = 2;
                    item.FileException = ex.Message + ":\n" + ex.StackTrace;
                    if (NotifyFileStateChange != null)
                    {
                        NotifyFileStateChange(item);
                    }
                    throw ex;
                }
            }
        }
        private void CalculateData()
        {
            ABCalculateBalance cz = new CalculateZone(ImportDataList);//计算市行、县行
            ABCalculateBalance cd = new CalculateDepartment(ImportDataList);//计算部门
            ABCalculateBalance cm = new CalculateCustomerManager(ImportDataList);//计算客户经理
            ABCalculateBalance cw = new CalculateWebsite(ImportDataList);//计算网点
            ABCalculateBalance cc = new CalculateCompany(ImportDataList);//计算公司
            ABCalculateBalance ca = new CalculateAccount(ImportDataList);//计算账户
            var cztask=Task.Factory.StartNew(() =>
            {
                cz.Caculate();
            });

            var cdtask = Task.Factory.StartNew(() =>
            {
                cd.Caculate();
            });
            var cmtask = Task.Factory.StartNew(() =>
            {
                cm.Caculate();
            });
            var cwtask = Task.Factory.StartNew(() =>
            {
                cw.Caculate();
            });
            var cctask = Task.Factory.StartNew(() =>
            {
                cc.Caculate();
            });

            var catask = Task.Factory.StartNew(() =>
            {
                ca.Caculate();
            });

            Task.WaitAll(cztask, cdtask, cmtask, cwtask, cctask, catask);
        }

        private void DataDivideStore()
        {
            if (ImportLinkDataList.Count==0)
            {
                return;
            }
            List<DepartmentInfo> DepartmentList = new List<DepartmentInfo>();
            List<CustomerManagerInfo> ManagerList = new List<CustomerManagerInfo>();
            List<AccountLinkManagerInfo> LinkList = new List<AccountLinkManagerInfo>();
            foreach (var item in ImportLinkDataList)
            {
                if (!DepartmentList.Exists(e => e.DepartmentName == item.DepartmentName))
                {
                    DepartmentInfo di = new DepartmentInfo();
                    di.DepartmentName = item.DepartmentName;
                    di.DepartmentID = item.DepartmentID;
                    di.DepartmentManager = item.DepartmentManager;
                    di.ID = Guid.NewGuid().ToString();
                    DepartmentList.Add(di);
                }

                if (!ManagerList.Exists(e => e.ManagerName == item.ManagerName && e.DepartmentName ==e.DepartmentName))
                {
                    CustomerManagerInfo ci = new CustomerManagerInfo();
                    ci.ID = Guid.NewGuid().ToString();
                    ci.ManagerID = item.ManagerID;
                    ci.ManagerName = item.ManagerName;
                    ci.DepartmentName = item.DepartmentName;
                    ci.DepartmentID = item.DepartmentID;
                    ManagerList.Add(ci);
                }

                LinkList.Add(item);
            }
            AccountLinkManagerInfoBLL linkbll = new AccountLinkManagerInfoBLL();
            linkbll.BatchInsert(LinkList);

            DepartmentInfoBLL departmentbll = new DepartmentInfoBLL();
            departmentbll.BatchInsert(DepartmentList);

            CustomerManagerInfoBLL cmanagerbll = new CustomerManagerInfoBLL();
            cmanagerbll.BatchInsert(ManagerList);
            
        }
    }
}
