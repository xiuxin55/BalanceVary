using Common;
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
        public static  void TaskDispatcherWithUI(Action doWork,Action<object> complete,object param, Dispatcher dispatcher=null)
        {
            IAsyncResult ir = doWork.BeginInvoke(new AsyncCallback(
                obj=>
                {
                    try
                    {
                        IAsyncResult ar = obj as IAsyncResult;
                        if (ar == null) return;
                        Action ac = ar.AsyncState as Action;
                        ac.EndInvoke(ar);
                        if (complete != null)
                        {
                            dispatcher.Invoke(complete, param);
                        }
                        else
                        {
                            complete(param);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogHelper.WriteLog(typeof(MultiTask), ex);
       
                    }
                    
                }
                ), doWork);
        }
    }
}
