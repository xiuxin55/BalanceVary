using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace AuthorizationModel
{
   
    public class DownFileResult
    {
        public string Filename { get; set; }
        public long FileSize { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public byte[] SendBytes { get; set; }
    }
}
