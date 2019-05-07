using HslCommunication;
using HslCommunication.BasicFramework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PanoramicDownload
{
    /// <summary>
    /// 文件管理类
    /// </summary>
    public  class FileManager
    {

        /// <summary>
        /// 删除子目录下的文件
        /// </summary>
        /// <param name="srcPath"></param>
        public static void DelectDir(string srcPath)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //返回目录中所有文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)            //判断是否文件夹
                    {
                        DirectoryInfo subdir = new DirectoryInfo(i.FullName);
                        subdir.Delete(true);          //删除子目录和文件
                        
                    }
                    else
                    {
                        File.Delete(i.FullName);      //删除指定文件                 
                    }
                }
            }
            catch (Exception ex)
            {
                SoftBasic.ShowExceptionMessage(ex);
            }
        }


        /// <summary>
        /// 打开文件路径
        /// </summary>
        /// <param name="folderPath"></param>
        public  static void OpenFolder(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
                try
                {
                    Process.Start("explorer.exe", folderPath);
                }
                catch (Exception ex)
                {
                    SoftBasic.ShowExceptionMessage(ex);
                }
            }
            else
            {
                try
                {
                    Process.Start("explorer.exe", folderPath);
                }
                catch (Exception ex)
                {
                    SoftBasic.ShowExceptionMessage(ex);
                }
            }
        }
    }
}