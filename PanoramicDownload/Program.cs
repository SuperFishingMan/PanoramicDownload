using AutoUpdateHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                if (AutoUpdate.CheckAndUpdate())
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("网络异常~~~赶紧检查一下吧……");
                Environment.Exit(Environment.ExitCode);
            }
             
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
          
        }
    }
}
