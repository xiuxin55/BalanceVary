using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
namespace Utility
{
   
    public class MutiTaskThreadPool
    {
        static MutiTaskThreadPool()
        {
            ThreadPool.SetMaxThreads(30, 15);
        }
        private  Action<object> _dowork = null;
        public Action<object> DoWork
        {
            get { return _dowork; }
            set { _dowork = value; }
        }

        //private Action<object> _doworkcomplete = null;
        //public Action<object> DoWorkComplete
        //{
        //    get { return _doworkcomplete; }
        //    set { _doworkcomplete = value; }
        //}
        private object _doworkParam;

        public object DoworkParam
        {
            get { return _doworkParam; }
            set { _doworkParam = value; }
        }

        public void StartThread()
        {
            if (_dowork !=null)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(_dowork), DoworkParam);
            }
        }
    }
}
