using BalanceReport.ServiceFile;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace BalanceReport
{
    public class UploadFile
    {
        public static void Upload(string filepath,FileType importtype)
        {
            string path = filepath;
            System.IO.FileInfo fileInfoIO = new System.IO.FileInfo(path);
            // 要上传的文件地址
            FileStream fs = File.OpenRead(fileInfoIO.FullName);
            // 实例化服务客户的
            ServiceFileClient client = new ServiceFileClient();
            try
            {
                int maxSiz = 1024 * 100;
                // 根据文件名获取服务器上的文件
                CustomFileInfo file = client.GetFileInfo(fileInfoIO.Name);
                if (file == null)
                {
                    file = new CustomFileInfo();
                    file.OffSet = 0;
                }
                file.Name = fileInfoIO.Name;
                file.Length = fs.Length;
                file.ImportType = importtype;
                if (file.Length == file.OffSet) //如果文件的长度等于文件的偏移量，说明文件已经上传完成
                {
                    MessageBox.Show("该文件已存在");
                    return;
                    
                }
                else
                {
                    while (file.Length != file.OffSet)
                    {
                        file.SendByte = new byte[file.Length - file.OffSet <= maxSiz ? file.Length - file.OffSet : maxSiz]; //设置传递的数据的大小

                        fs.Position = file.OffSet; //设置本地文件数据的读取位置
                        fs.Read(file.SendByte, 0, file.SendByte.Length);//把数据写入到file.Data中
                        file = client.UpLoadFileInfo(file); //上传
                        //int percent = (int)((double)file.OffSet / (double)((long)file.Length)) * 100;
                        int percent = (int)(((double)file.OffSet / (double)((long)file.Length)) * 100);
                        //(sender as BackgroundWorker).ReportProgress(percent);
                    }
                    MessageBox.Show("上传成功");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                fs.Close();
                fs.Dispose();
                client.Close();
                client.Abort();
            }

        }
    }
}
