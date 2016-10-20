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
        /// <summary>
        /// 异步调用
        /// </summary>
        /// <param name="doWork">需要执行的方法</param>
        /// <param name="complete">回调函数</param>
        /// <param name="param">回调方法的引用参数</param>
        /// <param name="dispatcher">ui调度</param>
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
        /// <summary>
        /// 调用多任务带参数和返回值
        /// </summary>
        /// <param name="doWork">执行方法</param>
        /// <param name="complete">完成后调用</param>
        /// <param name="param">参数</param>
        /// <param name="dispatcher">使用线程调度执行回调函数</param>
        public static void TaskWithParamReturn(Func<object, object> doWork, Action<object> complete, object param,Dispatcher dispatcher = null)
        {
            Task<object> doworkTask = Task.Factory.StartNew<object>(doWork, param);
            doworkTask.ContinueWith(t =>
            {
                if (dispatcher!=null)
                {
                    dispatcher.Invoke(complete, t.Result);
                }
                else
                {
                    complete(t.Result);
                }
            } 
            );
        }
    }
}
