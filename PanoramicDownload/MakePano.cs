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

        private void txtProject_TextChanged(object sender, EventArgs e)
        {

        }

        private void userButton1_Click(object sender, EventArgs e)
        {
            string filename;
            using (OpenFileDialog OpenFD = new OpenFileDialog())     //实例化一个 OpenFileDialog 的对象
            {
                //定义打开的默认文件夹位置
                OpenFD.InitialDirectory = ConstPath.saveFile;
                OpenFD.Filter = "All files(*.*)|*.*|jpeg files(*.jpeg)|*.jpeg";
                OpenFD.FilterIndex = 2;
                OpenFD.ShowDialog();                  //显示打开本地文件的窗体
                OpenFD.RestoreDirectory = true;
                filename = OpenFD.FileName;
            }
            txtProject.Text = filename;
            if (txtProject.Text.Contains("sphere.jpeg"))
            {
                var conmm = ConstPath.exePath + @"\krpanotools64.exe";
                var arg = @"  makepano  " + ConstPath.saveFile + "sphere.jpeg   " + ConstPath.exePath + @"\templates\normal.config";
                using (var pro = new Process())
                {
                    RedirectExcuteProcess(pro, conmm, arg, null);
                }
            }

        }

        private void userButton2_Click(object sender, EventArgs e)
        {
            if(File.Exists(ConstPath.saveFile+ @"sphere\tour_testingserver.exe"))
            {
                using (var pro = new Process())
                {
                    RedirectExcuteProcess(pro, ConstPath.saveFile + @"sphere\tour_testingserver.exe", "", null);
                }
            }
            else
            {
                MessageBox.Show("请先选择全景图片");
            }
        }

        private void userVerticalProgress1_Load(object sender, EventArgs e)
        {

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
