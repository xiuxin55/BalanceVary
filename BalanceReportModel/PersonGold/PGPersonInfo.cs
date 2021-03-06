﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BalanceModel
{
    /// <summary>
    /// 个金人员信息
    /// </summary>
    public class PGPersonInfo : PersonGoldBaseModel
    {

      
        /// <summary>
        /// 人员编码
        /// </summary>
        public string  StaffCode { get; set; }
        /// <summary>
        /// 人员姓名
        /// </summary>
        public string StaffName { get; set; }
        /// <summary>
        /// 身份证号
        /// </summary>
        public string  CardID { get; set; }
        /// <summary>
        /// 人员类别
        /// </summary>
        public string StaffType { get; set; }
        /// <summary>
        /// 岗位序列
        /// </summary>
        public string StaffPositionOrder { get; set; }
        /// <summary>
        /// 岗位
        /// </summary>
        public string StaffPosition { get; set; }
     
        /// <summary>
        /// 关联的网点
        /// </summary>
        public WebsiteInfo WebsiteInfoObj { get; set; }
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
