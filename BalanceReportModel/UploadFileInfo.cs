﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 上传文件信息
    /// </summary>
    public class UploadFileInfo : BaseModel
    {
        public string  ID { get; set; }
        public string FileName { get; set; }
        public string FileRealName { get; set; }
        public string FilePath { get; set; }
        
        public string FileType { get; set; }
        public DateTime? FileDateTime { get; set; }
        public DateTime? FileUploadTime { get; set; }
        private  int _FileState { get; set; }
        public int FileState
        {
            get
            {
                return _FileState;
            }
            set
            {
                _FileState = value;
                this.RaisePropertyChanged("FileState");
                if (FileStateChanged!=null)
                {
                    FileStateChanged(this);
                }
            }
        }
        /// <summary>
        /// 文件状态变化触发回调
        /// </summary>
        public event Action<UploadFileInfo> FileStateChanged;

        public string FileException { get; set; }
        public string FileMD5 { get; set; }
        /// <summary>
        /// 当前登录帐号
        /// </summary>
        public string UpLoadPersonCode { get; set; }
        
        /// <summary>
        /// 是否覆盖
        /// </summary>
        public bool IsOverride { get; set; }

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

    }
}
