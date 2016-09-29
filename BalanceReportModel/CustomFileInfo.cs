using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalanceModel
{
    /// <summary>
    /// 自定义文件属性类
    /// </summary>
    public class CustomFileInfo
    {
        /// <summary>
        /// 文件名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Length { get; set; }

        /// <summary>
        /// 文件偏移量
        /// </summary>
        public long OffSet { get; set; }

        /// <summary>
        /// 发送的字节
        /// </summary>
        public byte[] SendByte { get; set; }
        /// <summary>
        /// 导入类型
        /// </summary>
        public string ImportType { get; set; }
    }
}
