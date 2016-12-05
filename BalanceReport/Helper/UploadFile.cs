using WSBalanceClient.ServiceFile;
using Common;
using Common.Client;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using UserAuthorization.UserInfoService;

namespace BalanceReport
{
    //public class UploadFile
    //{
    //    //public static void Upload(string filepath, FileType importtype,DateTime datetime)
    //    //{
    //    //    string path = filepath;
    //    //    System.IO.FileInfo fileInfoIO = new System.IO.FileInfo(path);
            
    //    //    // 要上传的文件地址
    //    //    FileStream fs = null;
    //    //    // 实例化服务客户的
    //    //    ServiceFileClient client = null;
    //    //    try
    //    //    {
    //    //        string md5 = HashHelper.ComputeMD5(fileInfoIO.FullName);
    //    //        fs = File.OpenRead(fileInfoIO.FullName);
    //    //        client = new ServiceFileClient();
    //    //        int maxSiz = 1024 * 100;
    //    //        // 根据文件名获取服务器上的文件
    //    //        UploadFileInfo search = new UploadFileInfo();
    //    //        search.FileMD5 = md5;
    //    //        search.FileType = importtype.ToString();
                
    //    //        UploadFileInfo searchfile = client.GetFileInfo(search);
               
    //    //        if (searchfile != null)
    //    //        {
    //    //            MessageBoxResult mbr=  MessageBox.Show("文件已上传是否覆盖？", "提示", MessageBoxButton.OKCancel);
    //    //            if (mbr== MessageBoxResult.Cancel)
    //    //            {
    //    //                return;
    //    //            }
    //    //            searchfile.IsOverride = true;
    //    //        }
    //    //        else
    //    //        {
    //    //            searchfile = search;
    //    //            searchfile.ID = Guid.NewGuid().ToString();
    //    //        }
    //    //        CustomFileInfo file= new CustomFileInfo();
    //    //        file.OffSet = 0;
    //    //        file.Name = searchfile.ID + "." + importtype.ToString();
    //    //        file.FileRealName = fileInfoIO.Name;
    //    //        file.Length = fs.Length;
    //    //        while (file.Length != file.OffSet)
    //    //        {
    //    //            file.SendByte = new byte[file.Length - file.OffSet <= maxSiz ? file.Length - file.OffSet : maxSiz]; //设置传递的数据的大小

    //    //            fs.Position = file.OffSet; //设置本地文件数据的读取位置
    //    //            fs.Read(file.SendByte, 0, file.SendByte.Length);//把数据写入到file.Data中
    //    //            file = client.UpLoadFileInfo(file); //上传
    //    //            int percent = (int)(((double)file.OffSet / (double)((long)file.Length)) * 100);
    //    //        }
    //    //        searchfile.FileName = file.Name;
    //    //        searchfile.FileDateTime = datetime;
    //    //        searchfile.FileRealName = file.FileRealName;
    //    //        UserInfo CurrentUser = (UserInfo)AuthorizationContraint.CurrentUser;
    //    //        if (CurrentUser != null)
    //    //        {
    //    //            searchfile.UpLoadPersonCode = CurrentUser.UserName;
    //    //        }
    //    //        client.StoreUpLoadResult(searchfile);
    //    //        MessageBox.Show("上传成功");
                
    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        MessageBox.Show(ex.Message+":"+ex.StackTrace);
    //    //    }
    //    //    finally
    //    //    {
    //    //        if (fs!=null)
    //    //        {
    //    //            fs.Close();
    //    //            fs.Dispose();
    //    //            client.Close();
    //    //        }
    //    //    }

    //    //}
    //    //public static void Upload(string filepath, FileType importtype)
    //    //{
    //    //    string path = filepath;
    //    //    System.IO.FileInfo fileInfoIO = new System.IO.FileInfo(path);
    //    //    string md5 = HashHelper.ComputeMD5(fileInfoIO.FullName);
    //    //    // 要上传的文件地址
    //    //    FileStream fs = File.OpenRead(fileInfoIO.FullName);
    //    //    // 实例化服务客户的
    //    //    ServiceFileClient client = new ServiceFileClient();
    //    //    try
    //    //    {
    //    //        int maxSiz = 1024 * 100;
    //    //        // 根据文件名获取服务器上的文件
    //    //        UploadFileInfo search = new UploadFileInfo();
    //    //        search.FileMD5 = md5;
    //    //        search.FileType = importtype.ToString();

    //    //        UploadFileInfo searchfile = client.GetFileInfo(search);

    //    //        if (searchfile != null)
    //    //        {
    //    //            MessageBoxResult mbr = MessageBox.Show("文件已上传是否覆盖？", "提示", MessageBoxButton.OKCancel);
    //    //            if (mbr == MessageBoxResult.Cancel)
    //    //            {
    //    //                return;
    //    //            }
    //    //            searchfile.IsOverride = true;
    //    //        }
    //    //        else
    //    //        {
    //    //            searchfile = search;
    //    //            searchfile.ID = Guid.NewGuid().ToString();
    //    //        }
    //    //        CustomFileInfo file = new CustomFileInfo();
    //    //        file.OffSet = 0;
    //    //        file.Name = searchfile.ID + "." + importtype.ToString();
    //    //        file.FileRealName = fileInfoIO.Name;
    //    //        file.Length = fs.Length;
    //    //        while (file.Length != file.OffSet)
    //    //        {
    //    //            file.SendByte = new byte[file.Length - file.OffSet <= maxSiz ? file.Length - file.OffSet : maxSiz]; //设置传递的数据的大小

    //    //            fs.Position = file.OffSet; //设置本地文件数据的读取位置
    //    //            fs.Read(file.SendByte, 0, file.SendByte.Length);//把数据写入到file.Data中
    //    //            file = client.UpLoadFileInfo(file); //上传
    //    //            int percent = (int)(((double)file.OffSet / (double)((long)file.Length)) * 100);
    //    //        }
    //    //        searchfile.FileName = file.Name;
    //    //        searchfile.FileDateTime = DateTime.Now ;
    //    //        searchfile.FileRealName = file.FileRealName;
    //    //        client.StoreUpLoadResult(searchfile);
    //    //        MessageBox.Show("上传成功");

    //    //    }
    //    //    catch (Exception ex)
    //    //    {
    //    //        MessageBox.Show(ex.Message);
    //    //    }
    //    //    finally
    //    //    {
    //    //        fs.Close();
    //    //        fs.Dispose();
    //    //        client.Close();
    //    //        client.Abort();
    //    //    }

    //    //}
    //    #region 内部方法
    //    #endregion
    //}
}
