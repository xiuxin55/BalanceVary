using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApp
{
    public class ServiceModel
    {
        public string  Name { get; set; }
        public string IsStart { get; set; }
        public bool IsSelected { get; set; }
        public string  Describe { get; set; }
        public string StartTime { get; set; }
        public string StopTime { get; set; }

        public string AssemblyName { get; set; }
        public string ClassName { get; set; }
    }
}
