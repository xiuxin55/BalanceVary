using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AuthorizationModel
{
    public class AutoUpdateModel:BaseModel
    {
        private string _FileName;

        public string FileName
        {
            get { return _FileName; }
            set { _FileName = value;
                this.RaisePropertyChanged("FileName");
            }
        }
        private string _Version;

        public string Version
        {
            get { return _Version; }
            set
            {
                _Version = value;
                this.RaisePropertyChanged("Version");
            }
        }
        private string _State;

        public string State
        {
            get { return _State; }
            set
            {
                _State = value;
                this.RaisePropertyChanged("State");
            }
        }
       
    }
}
