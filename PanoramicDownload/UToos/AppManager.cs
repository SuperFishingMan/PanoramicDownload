using AutoUpdateHelper;
using HslCommunication.BasicFramework;
using PanoramicDownload.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CsharpHttpHelper;
using CsharpHttpHelper.Enum;
using System.Threading;
using System.Diagnostics;
using SendMailHelp;

namespace PanoramicDownload.UToos
{
    public class AppManager
    {
        private string GetData;
        private HttpResult result;
        private HttpItem item;
        private HttpHelper http;
        private string machinecode;
        /// <summary>
        /// 软件激活 广告 联系方式
        /// </summary>
        public string ADW_RegCode = "永久使用请联系QQ1228267639";
        /// <summary>
        /// 是否打开广告
        /// </summary>
        public bool IsOpenADW = true;
        /// <summary>
        /// 此处使用了组件支持的DES对称加密技术
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public string AuthorizeEncrypted(string origin)
        {
            return SoftSecurity.MD5Encrypt(origin, "19951005");
        }
        public SoftAuthorize soft = new SoftAuthorize();
        /// <summary>
        /// 获取软件版本号
        /// </summary>
        /// <returns></returns>
        public string GetAppVersion()
        {
            LocalConf conf = new LocalConf();
            return "猪猪全景图下载器  v" + conf.Version;
        }
        /// <summary>
        /// 检测机器是否注册激活
        /// </summary>
        /// <returns></returns>
        public bool Check_RegCode()
        {
            try
            {
                //创建Httphelper对象
                http = new HttpHelper();
                machinecode = soft.GetMachineCodeString();
                //创建Httphelper参数对象
                item = new HttpItem()
                {
                    URL = "http://47.98.156.83/panoramicAppLogin/reg_app.php?action=show_regcode&machine_code=" + machinecode,//URL     必需项    
                    Method = "post",//URL     可选项 默认为Get   
                    ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                    PostDataType = PostDataType.String
                };
                ////请求的返回值对象
                result = http.GetHtml(item);
                byte[] json_byte = Encoding.ASCII.GetBytes(result.Html);
                GetData = Encoding.UTF8.GetString(json_byte).Replace('?', ' ');
                if (AuthorizeEncrypted(machinecode).Equals(GetData.Split('|')[0].ToString().Trim()))
                {
                    //InitMail init = new InitMail();
                    //init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "已激活", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[1].ToString().Trim(),"付费用户", "猪猪全景"));
                    return false;//激活
                }
                else
                {
                    return true;//没有激活
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("网络连接失败! ", "提示");
                return true;
            }

        }

        /// <summary>
        /// 检测测试用户是否注册。
        /// </summary>
        /// <returns></returns>
        public bool IstempApp()
        {
            //创建Httphelper对象
            http = new HttpHelper();
            //创建Httphelper参数对象
            item = new HttpItem()
            {
                URL = "http://47.98.156.83/panoramicAppLogin/tempuser.php?action=show_regcode&machine_code=" + soft.GetMachineCodeString(),//URL     必需项    
                Method = "post",//URL     可选项 默认为Get   
                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                PostDataType = PostDataType.String
            };
            ////请求的返回值对象
            result = http.GetHtml(item);
            GetData = result.Html.Trim();
            InitMail init = new InitMail();
            if (GetData.Split('|')[0].ToString().Trim().Equals(""))
            {
                
                init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "限时激活【免费】", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[0].ToString().Trim(), "免费用户", "猪猪全景"));

                //Main.appisReg = true;
                return false;
            }
            if (GetData.Split('|')[0].ToString().Trim().Equals("到期了"))//测试使用完毕
            {

                init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "限时激活【免费】", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[0].ToString().Trim(), "免费用户", "猪猪全景"));

                MessageBox.Show("         免费使用已到期！！！" + "\n\n    " + ADW_RegCode);
                Main.appisReg = true;
                return true;
            }
            if (GetData.Split('|')[2].ToString().Trim().Equals("测试"))//测试中 提示
            {

                init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "限时激活【免费】", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[0].ToString().Trim(), "免费用户", "猪猪全景"));

                MessageBox.Show("免费使用到期时间：" + GetData.Split('|')[0].ToString().Trim() + "\n\n" + ADW_RegCode);
                Main.appisReg = false;
                return true;
            }

            init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "限时激活【免费】", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[0].ToString().Trim(), "免费用户", "猪猪全景"));

            MessageBox.Show("免费使用已到期：" + GetData.Split('|')[0].ToString().Trim() + "\n\n" + ADW_RegCode);
            Main.appisReg = true;
            return true;
        }
        /// <summary>
        /// 新增测试用户.
        /// </summary>
        public void insertSqlTempUser()
        {
            //创建Httphelper对象
            http = new HttpHelper();
            //创建Httphelper参数对象
            item = new HttpItem()
            {
                URL = "http://47.98.156.83/panoramicAppLogin/tempuser.php?action=submit_regcode&downloadcount=0&machine_code=" + soft.GetMachineCodeString(),//URL     必需项    
                Method = "post",//URL     可选项 默认为Get   
                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                PostDataType = PostDataType.String
            };
            ////请求的返回值对象
            result = http.GetHtml(item);
            GetData = result.Html.Trim();
            InitMail init = new InitMail();
            init.SendMail("ip登陆", init.ReplaceText("猪猪云全景", InitMail.HttpGET(@"http://47.98.156.83/sha1.php"), DateTime.Now.ToString("yyyy-MM-dd HH: mm:ss"), InitMail.HttpGET("http://whois.pconline.com.cn/ip.jsp?ip=" + InitMail.HttpGET(@"http://47.98.156.83/sha1.php")), "限时激活【免费】", AuthorizeEncrypted(soft.GetMachineCodeString()), soft.GetMachineCodeString(), GetData.Split('|')[0].ToString().Trim(), "免费用户", "猪猪全景"));

            MessageBox.Show("限时免费使用"+ "\n\n" + "到期时间 :" + GetData.Split('|')[0].ToString().Trim() + "\n\n" + ADW_RegCode);
        }
        /// <summary>
        /// 新增永久激活用户
        /// </summary>
        /// <param name="softAuthorize"></param>
        public void AppActivate(SoftAuthorize softAuthorize)
        {
            if (Check_RegCode())
            {
                // 显示注册窗口
                if (!IsOpenADW)
                {
                    ADW_RegCode = "";
                }
                using (FormAuthorize form =
                    new FormAuthorize(
                        softAuthorize,
                        ADW_RegCode,
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
                            //创建Httphelper对象
                            http = new HttpHelper();
                            //创建Httphelper参数对象
                            item = new HttpItem()
                            {
                                URL = "http://47.98.156.83/panoramicAppLogin/reg_app.php?action=submit_regcode&machine_code=" + softAuthorize.GetMachineCodeString()+ "&reg_code=" + AuthorizeEncrypted(softAuthorize.GetMachineCodeString()),//URL     必需项    
                                Method = "post",//URL     可选项 默认为Get   
                                ContentType = "application/x-www-form-urlencoded",//返回类型    可选项有默认值
                                PostDataType = PostDataType.String
                            };
                            ////请求的返回值对象
                            result = http.GetHtml(item);
                            GetData = result.Html.Trim();
                            if (GetData.Equals("400") || GetData.Equals("激活失败"))
                            {
                                return;
                            }
                            else
                            {
                                Main.appisReg = false;
                                MessageBox.Show("授权成功! 重新打开应用", "提示");
                                ReLoign();
                            }
                        }
                        catch (Exception ex)
                        {
                            Main.appisReg = true;
                            MessageBox.Show("网络连接失败! ", "提示");
                        }

                    }
                }
            }
            else
            {
                Main.appisReg = false;
            }
        }
        /// <summary>
        /// 重新打开应用
        /// </summary>
        public static void ReLoign()
        {
            Application.ExitThread();
            Thread thtmp = new Thread(new ParameterizedThreadStart(Run));
            object appName = Application.ExecutablePath;
            Thread.Sleep(1);
            thtmp.Start(appName);
        }
        private static void Run(Object appName)
        {
            Process ps = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = appName.ToString()
                }
            };
            ps.Start();
        }
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        /// <summary>
        /// DateTime时间格式转换为Unix时间戳格式
        /// </summary>
        /// <param name=”time”></param>
        /// <returns></returns>
        private int ConvertDateTimeInt(System.DateTime time)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(time - startTime).TotalSeconds;
        }
    }
}