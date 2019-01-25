using HslCommunication.BasicFramework;
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
        public string GetRegCode(string origin = "")
        {            
            HttpClient httpClient = new HttpClient();
            return httpClient.Post("http://47.98.156.83/panoramicAppLogin/reg_app.php", pairs);
        }
        SoftAuthorize soft = new SoftAuthorize();

        /// <summary>
        /// 检测机器是否注册激活
        /// </summary>
        /// <returns></returns>
        public bool Check_RegCode()
        {
            try
            {
                pairs.Clear();
             
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
            catch (Exception ex)
            {
                MessageBox.Show("网络连接失败! ", "提示");
                return true;
            }

        }
        private static Dictionary<string, string> pairs1 = new Dictionary<string, string>();
        /// <summary>
        /// 检测测试用户是否注册。
        /// </summary>
        /// <returns></returns>
        public bool IstempApp()
        {
            HttpClient http = new HttpClient();
            pairs1.Clear();
            pairs1.Add("action", "show_regcode");
           // pairs1.Add("downloadcount", "0");
            pairs1.Add("machine_code", soft.GetMachineCodeString());
            if (http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim().Equals(""))
            {
                //Main.appisReg = true;
                return false;
            }
            if (http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim().Equals("到期了"))
            {
                MessageBox.Show("测试使用到期：" + http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim());
                Main.appisReg = true;
                return true;
            }
            if (http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[2].ToString().Trim().Equals("测试"))
            {
                MessageBox.Show("测试使用到期：" + http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim());
                Main.appisReg = false;
                return true;
            }
            MessageBox.Show("测试使用到期："+http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim());
            Main.appisReg = true;
            return true;
        }

        /// <summary>
        /// 新增测试用户.
        /// </summary>
        public void insertSqlTempUser()
        {
            HttpClient http = new HttpClient();
            pairs1.Clear();
            pairs1.Add("action", "submit_regcode");
            pairs1.Add("downloadcount", "0");
            pairs1.Add("machine_code", soft.GetMachineCodeString());
            MessageBox.Show("注册时间:"+http.Post("http://47.98.156.83/panoramicAppLogin/tempuser.php", pairs1).Trim().Split('|')[0].ToString().Trim());
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
                        try
                        {
                            pairs.Clear();
                            pairs.Add("action", "submit_regcode");
                            pairs.Add("machine_code", softAuthorize.GetMachineCodeString());
                            pairs.Add("reg_code", AuthorizeEncrypted(softAuthorize.GetMachineCodeString()));
                            if (GetRegCode().Equals("400"))
                            {
                                return;
                            }
                            Main.appisReg = false;
                            MessageBox.Show("授权成功! ", "提示");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("网络连接失败! ", "提示");
                        }

                    }
                }
            }
            else
            {
                Main.appisReg = false;
                MessageBox.Show("授权成功! 到期时间： " + GetRegCode().Trim().Split('|')[1].ToString().Trim(), "提示");
            }
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