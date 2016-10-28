using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Utility
{
    /// <summary>
    /// 后台线程封装对象
    /// </summary>
    public class MutiBackgroundWorker:IDisposable 
    {
        /// <summary>
        /// 所有BackgroundWorker集合
        /// </summary>
        public static List<BackgroundWorker> BackgroundWorkerList = new List<BackgroundWorker>();
        private BackgroundWorker _backgroundWorker;
        public DoWorkEventHandler DoWork { get; set; }
        public object  DoWorkParam { get; set; }
        public ProgressChangedEventHandler ProgressChanged { get; set; }
        public RunWorkerCompletedEventHandler WorkerCompleted { get; set; }
        
        public MutiBackgroundWorker()
        {
            _backgroundWorker = new BackgroundWorker();
           
        }

        public void RunAsynWorker()
        {
            _backgroundWorker.DoWork += DoWork;
            if (ProgressChanged!=null)
            {
                _backgroundWorker.ProgressChanged += ProgressChanged;
            }
            if (WorkerCompleted != null)
            {
                _backgroundWorker.RunWorkerCompleted += WorkerCompleted;
            }
            else
            {
                _backgroundWorker.RunWorkerCompleted += DefaultRunWorkerCompleted;
            }
            MutiBackgroundWorker.BackgroundWorkerList.Add(_backgroundWorker);
            _backgroundWorker.RunWorkerAsync(DoWorkParam);
        }
        /// <summary>
        /// 默认完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DefaultRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (MutiBackgroundWorker.BackgroundWorkerList.Contains(_backgroundWorker))
            {
                MutiBackgroundWorker.BackgroundWorkerList.Remove(_backgroundWorker);
            }
        }

        public void CancelAsynWorker()
        {
            if (_backgroundWorker.IsBusy)
            {
                _backgroundWorker.CancelAsync();
            }
        }

        public void Dispose()
        {
            if (MutiBackgroundWorker.BackgroundWorkerList.Contains(_backgroundWorker))
            {
                MutiBackgroundWorker.BackgroundWorkerList.Remove(_backgroundWorker);
            }
            _backgroundWorker.Dispose();
        }
    }
}
