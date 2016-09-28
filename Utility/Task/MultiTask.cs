using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Utility
{
    public class MultiTask
    {
        public static  void TaskDispatcherWithUI(Action doWork,Action<object> complete,object param, Dispatcher dispatcher)
        {
            IAsyncResult ir = doWork.BeginInvoke(new AsyncCallback(
                obj=>
                {
                    IAsyncResult ar = obj as IAsyncResult;
                    if (ar == null) return;
                    Action ac = ar.AsyncState as Action;
                    ac.EndInvoke(ar);
                    dispatcher.Invoke(complete, param);
                }
                ), doWork);
        }
    }
}
