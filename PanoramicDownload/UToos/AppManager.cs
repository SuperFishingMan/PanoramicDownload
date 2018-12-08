using HslCommunication.BasicFramework;
using Microsoft.Win32;
using PanoramicDownload.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload.UToos
{
    public class AppManager
    {

        public string AuthorizeEncrypted(string origin)
        {
            // 此处使用了组件支持的DES对称加密技术
            return SoftSecurity.MD5Encrypt(origin, "19951005");
        }
        private Dictionary<string, string> pairs = new Dictionary<string, string>();
        public string GetRegCode(string origin="")
        {
            HttpClient httpClient = new HttpClient();
            return httpClient.Post("http://47.98.156.83/panoramicAppLogin/reg_app.php", pairs);
        }

        public bool Check_RegCode()
        {
            pairs.Clear();
            SoftAuthorize soft = new SoftAuthorize();
            string machinecode = soft.GetMachineCodeString();
            pairs.Add("action", "show_regcode");
            pairs.Add("machine_code", machinecode);
            GetRegCode();
            if (AuthorizeEncrypted(machinecode).Equals(GetRegCode().Trim().Split('|')[0].ToString().Trim()))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public void AppActivate(SoftAuthorize softAuthorize)
        {       
            if (Check_RegCode())
            {
                // 显示注册窗口
                using (HslCommunication.BasicFramework.FormAuthorize form =
                    new HslCommunication.BasicFramework.FormAuthorize(
                        softAuthorize,
                        "请联系QQ1228267639获取激活码",
                        AuthorizeEncrypted))
                {
                    if (form.ShowDialog() != DialogResult.OK)
                    {
                        // 授权失败，退出
                        //Mesbox("授权失败!  ");
                    }
                    else
                    {
                        pairs.Clear();
                        pairs.Add("action", "submit_regcode");
                        pairs.Add("machine_code", softAuthorize.GetMachineCodeString());
                        pairs.Add("reg_code", AuthorizeEncrypted(softAuthorize.GetMachineCodeString()));
                        GetRegCode();
                        MessageBox.Show("授权成功! 到期时间： "+ GetRegCode().Trim().Split('|')[1].ToString().Trim(), "提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("授权成功! 到期时间： " + GetRegCode().Trim().Split('|')[1].ToString().Trim(), "提示");
            }

            //// 检测激活码是否正确，没有文件，或激活码错误都算作激活失败
            //if (!softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
            //{
            //    // 显示注册窗口
            //    using (HslCommunication.BasicFramework.FormAuthorize form =
            //        new HslCommunication.BasicFramework.FormAuthorize(
            //            softAuthorize,
            //            "请联系QQ1228267639获取激活码",
            //            AuthorizeEncrypted))
            //    {
            //        if (form.ShowDialog() != DialogResult.OK)
            //        {
            //            // 授权失败，退出
            //            //Mesbox("授权失败!  ");
            //        }
            //        else
            //        {
            //            MessageBox.Show("授权成功!  ", "提示");
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("授权成功!  ", "提示");
            //}
        }


        public string OpenText()
        {
            using (OpenFileDialog OpenFD = new OpenFileDialog())     //实例化一个 OpenFileDialog 的对象
            {
                //定义打开的默认文件夹位置
                OpenFD.InitialDirectory = Application.StartupPath;
                OpenFD.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt";
                OpenFD.FilterIndex = 2;
                OpenFD.ShowDialog();                  //显示打开本地文件的窗体
                OpenFD.RestoreDirectory = true;
                return OpenFD.FileName;       //把 路径名称 赋给 fileName
            }
        }
    }
}
