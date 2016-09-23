using Microsoft.Practices.Prism.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp
{
    /// <summary>
    /// 服务实体类
    /// </summary>
    public class ServiceModel: NotificationObject
    {
        private  string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                this.RaisePropertyChanged("Name");
            }
        }
        private string _IsStart;
        public string IsStart
        {
            get
            {
                return _IsStart;
            }
            set
            {
                _IsStart = value;
                this.RaisePropertyChanged("IsStart");
            }
        }
        private bool _IsSelected;
        public bool IsSelected
        {
            get
            {
                return _IsSelected;
            }
            set
            {
                _IsSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }
        public string  Describe { get; set; }
        private string _StartTime;
        public string StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                _StartTime = value;
                this.RaisePropertyChanged("StartTime");
            }
        }
        private string _StopTime;
        public string StopTime
        {
            get
            {
                return _StopTime;
            }
            set
            {
                _StopTime = value;
                this.RaisePropertyChanged("StopTime");
            }
        }
        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
    }
}
