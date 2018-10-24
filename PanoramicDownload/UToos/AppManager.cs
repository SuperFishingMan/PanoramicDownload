using HslCommunication.BasicFramework;
using Microsoft.Win32;
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
        public void AppActivate(SoftAuthorize softAuthorize)
        {
            // 检测激活码是否正确，没有文件，或激活码错误都算作激活失败
            if (!softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
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
                        MessageBox.Show("授权成功!  ", "提示");
                    }
                }
            }
            else
            {
                MessageBox.Show("授权成功!  ", "提示");
            }
        }

        private void ActivationTime(SoftAuthorize softAuthorize)
        {
            if (!softAuthorize.IsAuthorizeSuccess(AuthorizeEncrypted))
            {
                try                                                //可能有异常，放在try块中
                {
                    RegistryKey rsg = null;                    //声明变量
                    rsg = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft", true); //true表可修改
                    if (rsg.GetValue("HoanReg") != null)  //如果值不为空
                    {
                        MessageBox.Show(rsg.GetValue("HoanReg").ToString(), "提示");
                                                                               //读取值
                    }
                    else
                    {
                        MessageBox.Show("该键不存在！", "提示");
                    }
                    rsg.Close();                            //关闭
                }
                catch (Exception ex)                        //捕获异常
                {
                    SoftBasic.ShowExceptionMessage(ex);             //显示异常信息
                }
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
