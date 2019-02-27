using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload
{
    public partial class MakePano : Form
    {
        public MakePano()
        {
            InitializeComponent();
        }

        //保存选择的图片路径
        string filenamePath;
        /// <summary>
        ///  选择全景图片  生成离线全景文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userButton1_Click(object sender, EventArgs e)
        {
            
            using (OpenFileDialog OpenFD = new OpenFileDialog())     //实例化一个 OpenFileDialog 的对象
            {
                //定义打开的默认文件夹位置
                OpenFD.InitialDirectory = ConstPath.saveFile;
                OpenFD.Filter = "All files(*.*)|*.*|jpeg files(*.jpeg)|*.jpeg";
                OpenFD.FilterIndex = 2;
                OpenFD.ShowDialog();                  //显示打开本地文件的窗体
                OpenFD.RestoreDirectory = true;
                filenamePath = OpenFD.FileName;
            }
            txtProject.Text = filenamePath;
            int index = filenamePath.LastIndexOf(@"\");
            string ImageName = filenamePath.Remove(0, index + 1);
            if (txtProject.Text.Contains(ImageName))
            {
                var conmm = ConstPath.exePath + @"\krpanotools64.exe";
                var arg = @"  makepano  " + filenamePath + "   " + ConstPath.exePath + @"\templates\normal.config";
                using (var pro = new Process())
                {
                    RedirectExcuteProcess(pro, conmm, arg, null);
                }
            }
        }
        /// <summary>
        /// 查看全景 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void userButton2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filenamePath))
            {
                MessageBox.Show("请先选择全景图片");
                return;
            }
            int index = filenamePath.LastIndexOf(@"\"); //查找最后一个“\”的下标
            string ImageName = filenamePath.Remove(0, index+1);//截取 图片name 带后缀名的字符串
            int ImageNameIndex = ImageName.LastIndexOf(".");//查找图片name  “.”的 下标
            ImageName = ImageName.Remove(ImageNameIndex, ImageName.Length - ImageNameIndex);//截取不带 后缀的图片name
            string filepath= filenamePath.Remove(index, filenamePath.Length - index); //截取出图片的 本级路径
            string Imagepath = Path.Combine(filepath+"\\" + ImageName + "\\tour_testingserver.exe"); //合成完整路径
            if (File.Exists(Imagepath))
            {
                using (var pro = new Process())
                {
                    RedirectExcuteProcess(pro, Imagepath, "", null);
                }
            }
            else
            {
                MessageBox.Show("请先选择全景图片");
            }
        }



        private void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output)
        {
            p.StartInfo.FileName = exe; // 命令
            p.StartInfo.Arguments = arg; // 参数

            p.StartInfo.CreateNoWindow = false; // 不创建新窗口
            //p.StartInfo.UseShellExecute = false;    //输出信息重定向
            //p.StartInfo.RedirectStandardInput = true; // 重定向输入
           // p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            //p.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            p.StartInfo.ErrorDialog = false;
         
            p.EnableRaisingEvents = true;                      // 启用Exited事件
            p.Start();                    //启动线程
           // p.BeginErrorReadLine();
            //p.BeginOutputReadLine();
            
            Application.DoEvents();

            //p.WaitForExit();            //等待进程结束
        }
    }
}
