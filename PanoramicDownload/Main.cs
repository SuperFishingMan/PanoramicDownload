using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using PanoramicDownload.Core;
using HslCommunication.BasicFramework;
using System.Text;
using Microsoft.Win32;
using PanoramicDownload.UToos;
using System.Data.SqlClient;
using System.Data;
using System.Threading.Tasks;
using SendMailHelp;


namespace PanoramicDownload
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景.  
            SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲  
            this.DoubleBuffered = true;
            CheckForIllegalCrossThreadCalls = false;
            UiInit();
        }

        /// <summary>
        /// 解密函数
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>

        #region 变量
        /// <summary>
        /// 720云
        /// </summary>
        private string InputUrlYun = "";
        /// <summary>
        /// 酷家乐
        /// </summary>
        private string InputUrlKJZ = "";
        /// <summary>
        /// 网展
        /// </summary>
        private string InputUrlWZ = "";
        /// <summary>
        /// E建网
        /// </summary>
        private string InputUrlYJ = "";
        /// <summary>
        /// 鱼模网
        /// </summary>
        private string InputUrlYMW = "";
        /// <summary>
        /// 全景客
        /// </summary>
        private string InputUrlQJK = "";
        /// <summary>
        /// 键入的链接
        /// </summary>
        private string InputUrl;
        /// <summary>
        /// 图片质量级别
        /// </summary>
        public int ImageQualityIndex;
        /// <summary>
        /// 全景图6分面 单张 横排最高数
        /// </summary>
        public int ImageRowCount;
        /// <summary>
        /// 将要下载的类型
        /// </summary>
        private DownLoadType downLoadType = DownLoadType.empty;

        List<ProgressBar> listProg = new List<ProgressBar>();
        /// <summary>
        /// 储存下载链接的文本
        /// </summary>
        private FileInfo configFile;

        /// <summary>
        /// 软件是否激活  True 是没有激活  False 是激活了
        /// </summary>
        public static bool appisReg = false;
        /// <summary>
        /// 存储单张图片 质量关键字
        /// </summary>
        private List<string> newKeystrList = new List<string>();

        private List<string> strMatc = new List<string>();

        public Dictionary<string, string> ImagePath = new Dictionary<string, string>();
        #endregion
        StreamWriter sw51;
        private RegExManager regExManager;
        private AppManager appManager;
        private SoftAuthorize softAuthorize = null;
        /// <summary>
        /// Ui事件及状态的初始化
        /// </summary>
        private void UiInit()
        {
            UseExplain_Link.Links.Add(0, 4, ConstPath.exePath + "\\建e网演示.jpg");
            ImageSavePath_Label.Text = "图片路径:" + ConstPath.saveFile;
            softAuthorize = new SoftAuthorize();
            appManager = new AppManager();
            Text = appManager.GetAppVersion();
            //同步版本UI

            //设置状态
            UrlStateBox.Image = Properties.Resources.笑脸;
         
            //如果没有激活
            if (appManager.Check_RegCode())
            {
                //第一次使用测试用户
                if (!appManager.IstempApp())
                {
                    appManager.insertSqlTempUser();
                }
                else
                {
                    //appisReg = true;
                }
                Pay_Button.Show();
                Activate_Button.Show();
            }
            else
            {
                Activate_Button.Hide();
                Pay_Button.Hide();
            }

            regExManager = new RegExManager();
            //添加链接检测事件
            InputUrl_TextBox.TextChanged += InputUrl_TextBox_TextChanged;
            //跑马灯定时器
            if (appManager.IsOpenADW)
            {
                timer_Tick.Tick += Timer1_Tick;
            }
            else
            {
                ADW_label.Hide();
                Mail_Link.Hide();
                QQ_Link.Hide();
            }

            ReadStdOutput += new DelReadStdOutput(ReadStdOutputAction);
            ReadErrOutput += new DelReadErrOutput(ReadErrOutputAction);

        }


        /// <summary>
        /// 跑马灯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            ADW_label.Left += 1;
            if (ADW_label.Left == this.Width)
            {
                ADW_label.Left = -ADW_label.Width;
            }
        }

        /// <summary>
        /// 检查Url是否是可下载的全景图
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputUrl_TextBox_TextChanged(object sender, EventArgs e)
        {
            if (appisReg)
            {
                Mesbox("请激活软件");
                return;
            }
            InputUrl = InputUrl_TextBox.Text.Trim();
            //判断url是否为可访问 
            if (string.IsNullOrEmpty(InputUrl_TextBox.Text.Trim()) || !isPing(InputUrl, "https://720yun.com/"))
            {
                //Mesbox(GetWebStatusCode(InputUrl, 10000), "错误提示");
                //this.Activate();  //
                UrlStateBox.Image = Properties.Resources.失败_表情;
                return;
            }
            //获得url中的关键字符     b/l1/01/l1_b_01_01.jpg
            InputUrlKJZ = regExManager.MatchKJL(InputUrl);

            if (InputUrlKJZ.Equals(""))
            {
                InputUrlYun = regExManager.MatchYun(InputUrl); //后几位
            }
            if (InputUrlYun.Equals("") && InputUrlKJZ.Equals(""))
            {
                InputUrlYJ = regExManager.MatchYJ(InputUrl);
            }
            if (InputUrlYun.Equals("") && InputUrlKJZ.Equals("") && InputUrlYJ.Equals(""))
            {
                InputUrlWZ = regExManager.MatchWZ(InputUrl);
            }
            if (InputUrlYun.Equals("") && InputUrlKJZ.Equals("") && InputUrlWZ.Equals("") && InputUrlYJ.Equals(""))
            {
                InputUrlYMW = regExManager.MatchYMW(InputUrl);
            }
            if (InputUrlYun.Equals("") && InputUrlKJZ.Equals("") && InputUrlWZ.Equals("") && InputUrlYJ.Equals("") && InputUrlYMW.Equals(""))
            {
                InputUrlQJK = regExManager.MatchQJK(InputUrl);
            }
            //判断url是否为可下载的全景图片
            if (InputUrlYun.Equals("") && InputUrlKJZ.Equals("") && InputUrlWZ.Equals("") && InputUrlYJ.Equals("") && InputUrlYMW.Equals("") && InputUrlQJK.Equals(""))
            {
                Mesbox("请输入支持的全景图下载地址");
                downLoadType = DownLoadType.empty;
                UrlStateBox.Image = Properties.Resources.失败_表情;
                return;
            }


            if (!InputUrlYun.Equals(""))
            {
                downLoadType = DownLoadType.lx_x_xx_xx;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
            if (!InputUrlKJZ.Equals(""))
            {
                downLoadType = DownLoadType.ssssxssss;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
            if (!InputUrlWZ.Equals(""))
            {
                downLoadType = DownLoadType.lxlxxlxlx_x_x;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
            if (!InputUrlYJ.Equals(""))
            {
                downLoadType = DownLoadType.lxlxx_x_x_x;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
            if (!InputUrlYMW.Equals(""))
            {
                downLoadType = DownLoadType.xxxx_x;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
            if (!InputUrlQJK.Equals(""))
            {
                downLoadType = DownLoadType.lx_x_0x_0x;
                UrlStateBox.Image = Properties.Resources.yes;
                return;
            }
        }

        public void StartDownLoadImage()
        {
            configFile = new FileInfo(ConstPath.exePath + "/config.txt");
            StreamWriter sw5 = configFile.CreateText();

            //DownloadCount++;
            switch (downLoadType)
            {
                //720yun
                #region 720yun
                case DownLoadType.lx_x_xx_xx:
                    PlatformYun platfromYun = new PlatformYun();
                    StringBuilder newUrl = new StringBuilder(200);
                    newUrl.Append(InputUrl.Substring(0, InputUrl.Length - InputUrlYun.Length + 1));
                    newKeystrList.Clear();
                    newKeystrList = regExManager.GetRegex(InputUrlYun);
                    StringBuilder newkey1 = new StringBuilder(200);
                    int maxtpye = 0;
                    int maxIndex = 0;
                    List<string> newKeystr1 = new List<string>();
                    #region 大像素
                    //if (newKeystrList[2].Length.Equals(3) || newKeystrList[2].Length.Equals(2) || newKeystrList[2].Length.Equals(1))
                    //{
                    //    for (int j = 1; j < 20; j++)
                    //    {
                    //        newkey1.Clear();
                    //        newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + j).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1."));
                    //        if (isPing(newUrl + "" + newkey1))
                    //        {
                    //            maxtpye = j;
                    //        }
                    //        else
                    //        {
                    //            break;
                    //        }
                    //    }

                    //    ImageQualityIndex = maxtpye;
                    //    newkey1.Clear();
                    //    newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + maxtpye).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1."));

                    //    newKeystr1 = regExManager.GetRegex(newkey1 + "");
                    //    for (int i = 1; i < 400; i++)
                    //    {
                    //        string value1 = "";
                    //        if (i >= 10)
                    //        {
                    //            value1 = newkey1.ToString().Replace("/" + newKeystr1[1] + "/", "/" + i + "/").Replace("_" + newKeystr1[2] + "_", "_" + i + "_");
                    //            if (isPing(newUrl + value1))
                    //            {
                    //                maxIndex = i;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }
                    //        else
                    //        {
                    //            value1 = newkey1.ToString().Replace("/" + newKeystr1[1] + "/", "/" + i + "/").Replace("_" + newKeystr1[2] + "_", "_" + i + "_");
                    //            if (isPing(newUrl + value1))
                    //            {
                    //                maxIndex = i;
                    //            }
                    //            else
                    //            {
                    //                break;
                    //            }
                    //        }

                    //    }
                    //    ImageRowCount = maxIndex;
                    //    Thread trYun = new Thread(() =>
                    //    {
                    //        platfromYun.WriteDownLoad(DirectionType.b, maxIndex, newUrl, maxtpye, sw5);

                    //        platfromYun.WriteDownLoad(DirectionType.d, maxIndex, newUrl, maxtpye, sw5);

                    //        platfromYun.WriteDownLoad(DirectionType.f, maxIndex, newUrl, maxtpye, sw5);

                    //        platfromYun.WriteDownLoad(DirectionType.r, maxIndex, newUrl, maxtpye, sw5);

                    //        platfromYun.WriteDownLoad(DirectionType.u, maxIndex, newUrl, maxtpye, sw5);

                    //        platfromYun.WriteDownLoad(DirectionType.l, maxIndex, newUrl, maxtpye, sw5);

                    //        sw5.Close();
                    //        sw5.Dispose();
                    //    });
                    //    trYun.Start();
                    //    trYun.Join();
                    //    if (CheckLineCount(maxIndex))
                    //    {
                    //        Mesbox("配置文件加载失败，点击下载按钮");
                    //        // return;
                    //    }
                    //    Mesbox("配置文件已生成=====正在下载请等待");
                    //    var command = "-s 1 -x 1 -j 500  -i " + ConstPath.exePath + "/config.txt  -d" + ConstPath.exePath + "/下载文件";


                    //    Thread dd = new Thread(() =>
                    //    {
                    //        using (var p = new Process())
                    //        {
                    //            RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", command, (s, e) => ShowInfo("", e.Data));
                    //            p.Close();
                    //        }
                    //    });
                    //    dd.Start();                    

                    //    return;
                    //}
                    #endregion
                    if (newKeystrList[2].Length.Equals(2))
                    {
                        for (int j = 1; j < 4; j++)
                        {
                            newkey1.Clear();
                            newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + j).Replace("/" + newKeystrList[1], "/01").Replace("_" + newKeystrList[2] + "_", "_01_").Replace("_" + newKeystrList[3] + ".", "_01."));
                            if (isPing(newUrl + "" + newkey1, ""))
                            {
                                maxtpye = j;
                            }
                            else
                            {
                                break;
                            }
                        }
                        ImageQualityIndex = maxtpye;
                        newkey1.Clear();
                        newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + maxtpye).Replace("/" + newKeystrList[1], "/01").Replace("_" + newKeystrList[2] + "_", "_01_").Replace("_" + newKeystrList[3] + ".", "_01."));

                        newKeystr1 = regExManager.GetRegex(newkey1 + "");
                        for (int i = 1; i < 20; i++)
                        {
                            string value1 = "";
                            if (i >= 10)
                            {
                                value1 = newkey1.ToString().Replace("/" + newKeystr1[1] + "/", "/" + i + "/").Replace("_" + newKeystr1[2] + "_", "_" + i + "_");
                                if (isPing(newUrl + value1, "https://720yun.com/"))
                                {
                                    maxIndex = i;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                value1 = newkey1.ToString().Replace("/" + newKeystr1[1] + "/", "/0" + i + "/").Replace("_" + newKeystr1[2] + "_", "_0" + i + "_");
                                if (isPing(newUrl + value1, "https://720yun.com/"))
                                {
                                    maxIndex = i;
                                }
                                else
                                {
                                    break;
                                }
                            }

                        }
                        ImageRowCount = maxIndex;
                        Thread trYun = new Thread(() =>
                        {
                            platfromYun.WriteDownLoad(DirectionType.b, maxIndex, newUrl, maxtpye, sw5);

                            platfromYun.WriteDownLoad(DirectionType.d, maxIndex, newUrl, maxtpye, sw5);

                            platfromYun.WriteDownLoad(DirectionType.f, maxIndex, newUrl, maxtpye, sw5);

                            platfromYun.WriteDownLoad(DirectionType.r, maxIndex, newUrl, maxtpye, sw5);

                            platfromYun.WriteDownLoad(DirectionType.u, maxIndex, newUrl, maxtpye, sw5);

                            platfromYun.WriteDownLoad(DirectionType.l, maxIndex, newUrl, maxtpye, sw5);

                            sw5.Close();
                            sw5.Dispose();
                        });
                        trYun.Start();
                        trYun.Join();
                        if (CheckLineCount(maxIndex))
                        {
                            Mesbox("配置文件加载失败，点击下载按钮");
                            // return;
                        }
                        Mesbox("配置文件已生成=====正在下载请等待");
                        this.Activate();
                        //if (!Directory.Exists(ConstPath.saveFile+"720yun"+ DownloadCount))
                        //{
                        //    Directory.CreateDirectory(ConstPath.saveFile + "720yun" + DownloadCount);
                        //}

                        var command = "-s 1 --referer=https://720yun.com -x 1 -j 50  -i " + ConstPath.exePath + "/config.txt  -d" + ConstPath.saveFile;


                        Thread dd = new Thread(() =>
                        {
                            using (var p = new Process())
                            {
                                RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", command, (s, e) => ShowInfo("", e.Data));
                                //p.Close();
                            }
                        });
                        dd.Start();

                        return;
                    }

                    for (int j = 1; j < 20; j++)
                    {
                        newkey1.Clear();
                        newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + j).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1."));
                        if (isPing(newUrl + "" + newkey1, "https://720yun.com/"))
                        {
                            maxtpye = j;
                        }
                        else
                        {
                            break;
                        }
                        Application.DoEvents();
                    }
                    ImageQualityIndex = maxtpye;
                    //MessageBox.Show(maxtpye.ToString());
                    newkey1.Clear();
                    newkey1.Append(InputUrlYun.Replace(newKeystrList[0], "l" + maxtpye).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1."));
                    newKeystr1 = regExManager.GetRegex(newkey1 + "");
                    for (int i = 1; i < 180; i++)
                    {
                        string value1 = newkey1.ToString().Replace("/" + newKeystr1[1] + "/", "/" + i + "/").Replace("_" + newKeystr1[2] + "_", "_" + i + "_");
                        if (isPing(newUrl + "" + value1, "https://720yun.com/"))
                        {
                            maxIndex = i;
                        }
                        else
                        {
                            break;
                        }
                        Application.DoEvents();
                    }
                    Thread trd = new Thread(() =>
                    {
                        platfromYun.WriteDownLoad_(DirectionType.b, maxIndex, newUrl, maxtpye, sw5);
                        platfromYun.WriteDownLoad_(DirectionType.d, maxIndex, newUrl, maxtpye, sw5);
                        platfromYun.WriteDownLoad_(DirectionType.f, maxIndex, newUrl, maxtpye, sw5);
                        platfromYun.WriteDownLoad_(DirectionType.r, maxIndex, newUrl, maxtpye, sw5);
                        platfromYun.WriteDownLoad_(DirectionType.u, maxIndex, newUrl, maxtpye, sw5);
                        platfromYun.WriteDownLoad_(DirectionType.l, maxIndex, newUrl, maxtpye, sw5);

                        sw5.Close();
                        sw5.Dispose();
                    });
                    trd.Start();
                    trd.Join();

                    if (CheckLineCount(maxIndex))
                    {
                        Mesbox("请重新点击下载按钮");
                        return;
                    }
                    string referer = "https://720yun.com/";
                    if (InputUrl.Contains("720static"))
                    {
                        referer = "https://720yun.com/";
                    }
                    else
                    {
                        referer = "";
                    }
                    var command1 = " -i " + ConstPath.exePath + "\\config.txt  --referer="+ referer + "  --save-session=" + ConstPath.exePath + "\\out.txt" + " -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", command1, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }
                    //MessageBox.Show(maxIndex.ToString());
                    ImageRowCount = maxIndex;
                    Mesbox("配置文件已生成=====正在下载请等待");
                    this.Activate();
                    return;
                #endregion
                #region 酷家乐
                case DownLoadType.ssssxssss:
                    PlatfommKJL platfromKJL = new PlatfommKJL();

                    Thread trKJL = new Thread(() =>
                    {
                        int index = InputUrl.IndexOf(".jpg", 1, InputUrl.Length - 1);
                        StringBuilder newstr = new StringBuilder(InputUrl.Remove(index + 4, InputUrl.Length - index - 4));

                        platfromKJL.WriteDownLoad(DirectionType.l, 0, newstr, 0, sw5);
                        platfromKJL.WriteDownLoad(DirectionType.f, 0, newstr, 0, sw5);
                        platfromKJL.WriteDownLoad(DirectionType.r, 0, newstr, 0, sw5);
                        platfromKJL.WriteDownLoad(DirectionType.b, 0, newstr, 0, sw5);
                        platfromKJL.WriteDownLoad(DirectionType.u, 0, newstr, 0, sw5);
                        platfromKJL.WriteDownLoad(DirectionType.d, 0, newstr, 0, sw5);
                        sw5.Close();
                        sw5.Dispose();
                    });
                    trKJL.Start();
                    trKJL.Join();

                    if (CheckLineCount(1))
                    {
                        Mesbox("请重新点击下载按钮");
                        return;
                    }
                    var command2 = "-s 1 -x 1 -j 50  -i " + ConstPath.exePath + "\\config.txt  --check-certificate=false --save-session=" + ConstPath.exePath + "\\out.txt" + " -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "\\aria2c.exe", command2, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }
                    Thread.Sleep(8000);
                    string[] sDirectories = Directory.GetFiles(ConstPath.saveFile);

                    for (int i = 0; i < sDirectories.Length; i++)
                    {
                        string sDirectoryName = Path.GetFileName(sDirectories[i]);
                        string newstrDir = sDirectoryName.Remove(0, sDirectoryName.Length - 1);
                        string sNewDirectoryName = newstrDir + ".jpg";
                        string sNewDirectory = Path.Combine(ConstPath.saveFile, sNewDirectoryName);
                        // Directory.Move(sDirectories[i], sNewDirectory);
                        File.Move(sDirectories[i], sNewDirectory);
                        strMatc.Add(sNewDirectory);
                    }
                    return;
                #endregion
                #region 网展
                case DownLoadType.lxlxxlxlx_x_x:
                    PlatformWZ platfromWZ = new PlatformWZ();


                    StringBuilder newUrlWZ = new StringBuilder(200);
                    newUrlWZ.Clear();
                    newUrlWZ.Append(InputUrl.Substring(0, InputUrl.Length - InputUrlWZ.Length));
                    newKeystrList.Clear();
                    newKeystrList = regExManager.GetRegexWZ(InputUrlWZ);
                    string newkey11 = "";
                    int maxtpyeWZ = 1;
                    int maxIndexWZ = 1;
                    List<string> newKeystr11 = new List<string>();
                    for (int j = 1; j < 20; j++)//"u/n3/5/u_5_2.jpg";
                    {
                        newkey11 = InputUrlWZ.Replace(newKeystrList[0], "n" + j).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1.");
                        if (isPing(newUrlWZ + newkey11, "https://www.expoon.com/"))
                        {
                            maxtpyeWZ = j;
                        }
                        else
                        {
                            break;
                        }
                    }

                    ImageQualityIndex = maxtpyeWZ;
                    //MessageBox.Show(maxtpye.ToString());
                    newkey11 = InputUrlWZ.Replace(newKeystrList[0], "n" + maxtpyeWZ).Replace("/" + newKeystrList[1], "/1").Replace("_" + newKeystrList[2] + "_", "_1_").Replace("_" + newKeystrList[3] + ".", "_1.");

                    newKeystr11 = regExManager.GetRegexWZ(newkey11);
                    for (int i = 1; i < 20; i++)
                    {
                        StringBuilder value1 = new StringBuilder(200);
                        if (i >= 10)
                        {
                            value1.Clear();
                            value1.Append(newkey11.Replace("/" + newKeystr11[1], "/" + i).Replace("_" + newKeystr11[2] + "_", "_" + i + "_"));
                            if (isPing(newUrlWZ + "" + value1, "https://www.expoon.com/"))
                            {
                                maxIndexWZ = i;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            value1.Clear();
                            value1.Append(newkey11.Replace("/" + newKeystr11[1], "/" + i).Replace("_" + newKeystr11[2] + "_", "_" + i + "_"));
                            if (isPing(newUrlWZ + "" + value1, "https://www.expoon.com/"))
                            {
                                maxIndexWZ = i;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    ImageRowCount = maxIndexWZ;

                    Thread tr = new Thread(() =>
                    {
                        platfromWZ.WriteDownLoad(DirectionType.b, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);
                        platfromWZ.WriteDownLoad(DirectionType.d, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);
                        platfromWZ.WriteDownLoad(DirectionType.f, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);
                        platfromWZ.WriteDownLoad(DirectionType.r, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);
                        platfromWZ.WriteDownLoad(DirectionType.u, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);
                        platfromWZ.WriteDownLoad(DirectionType.l, maxIndexWZ, newUrlWZ, maxtpyeWZ, sw5);

                        sw5.Close();
                        sw5.Dispose();
                    });
                    tr.Start();
                    tr.Join();
                    if (CheckLineCount(maxIndexWZ))
                    {
                        Mesbox("请重新点击下载按钮");
                        return;
                    }
                    var command12 = "-s 1 -x 1 -j 50  -i " + ConstPath.exePath + "/config.txt  -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", command12, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }

                    Mesbox("配置文件已生成=====正在下载请等待");

                    return;
                #endregion
                #region 建e网
                case DownLoadType.lxlxx_x_x_x:
                    PlatformJE platformJE = new PlatformJE();

                    StringBuilder newUrlYJ = new StringBuilder(200);
                    int maxtpyeJY = 1;
                    int maxIndexJY = 1;
                    string newkeyYJ = "";
                    newUrlYJ.Clear();
                    newUrlYJ.Append(InputUrl.Substring(0, InputUrl.Length - InputUrlYJ.Length));
                    newKeystrList.Clear();
                    newKeystrList = regExManager.GetRegexYJ(InputUrlYJ);
                    List<string> newKeystrYJ = new List<string>();
                    for (int j = 1; j < 20; j++)//"u/n3/5/u_5_2.jpg";
                    {
                        newkeyYJ = InputUrlYJ.Replace(newKeystrList[0], "l" + j).Replace("_" + newKeystrList[1] + "_", "_1_").Replace("_" + newKeystrList[2] + ".", "_1.");
                        if (isPing(newUrlYJ + newkeyYJ, "https://vr.justeasy.cn"))
                        {
                            maxtpyeJY = j;
                        }
                        else
                        {
                            break;
                        }
                    }
                    ImageQualityIndex = maxtpyeJY;
                    newkeyYJ = InputUrlYJ.Replace(newKeystrList[0], "l" + ImageQualityIndex).Replace("_" + newKeystrList[1] + "_", "_1_").Replace("_" + newKeystrList[2] + ".", "_1.");
                    newKeystrYJ = regExManager.GetRegexYJ(newkeyYJ);

                    for (int i = 1; i < 20; i++)
                    {
                        StringBuilder value1 = new StringBuilder(200);
                        if (i >= 10)
                        {
                            value1.Clear();
                            value1.Append(newkeyYJ.Replace("_" + newKeystrYJ[1] + "_", "_" + i + "_").Replace("_" + newKeystrYJ[2] + ".", "_" + i + "."));
                            if (isPing(newUrlYJ + "" + value1, "https://vr.justeasy.cn"))
                            {
                                maxIndexJY = i;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            value1.Clear();
                            value1.Append(newkeyYJ.Replace("_" + newKeystrYJ[1], "_" + i).Replace("_" + newKeystrYJ[2] + ".", "_" + i + "."));
                            if (isPing(newUrlYJ + "" + value1, "https://vr.justeasy.cn"))
                            {
                                maxIndexJY = i;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                    ImageRowCount = maxIndexJY;

                    Thread trJE = new Thread(() =>
                    {
                        platformJE.WriteDownLoad(DirectionType.b, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);
                        platformJE.WriteDownLoad(DirectionType.d, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);
                        platformJE.WriteDownLoad(DirectionType.f, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);
                        platformJE.WriteDownLoad(DirectionType.r, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);
                        platformJE.WriteDownLoad(DirectionType.u, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);
                        platformJE.WriteDownLoad(DirectionType.l, maxIndexJY, newUrlYJ, maxtpyeJY, sw5);

                        sw5.Close();
                        sw5.Dispose();
                    });
                    trJE.Start();
                    trJE.Join();

                    if (CheckLineCount(maxIndexJY))
                    {
                        Mesbox("请重新点击下载按钮");
                        return;
                    }

                    Mesbox("配置文件已生成=====正在下载请等待");
                    this.Activate();
                    var commandYJ = "-s 1 -x 1 -j 50  -i " + ConstPath.exePath + "/config.txt  -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", commandYJ, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }
                    return;
                #endregion
                #region 鱼模网
                case DownLoadType.xxxx_x:

                    PlatformYMW platformYMW = new PlatformYMW();

                    Thread threadYMW = new Thread(() =>
                    {
                        int index = InputUrl.IndexOf(InputUrlYMW, 1, InputUrl.Length - 1);
                        //StringBuilder newstr = new StringBuilder(InputUrl);
                        StringBuilder UrlHeadYMW = new StringBuilder(InputUrl.Remove(index + 5, 6));
                        //Mesbox(newstr.ToString());
                        platformYMW.WriteDownLoad(DirectionType.l, 0, UrlHeadYMW, 0, sw5);
                        platformYMW.WriteDownLoad(DirectionType.f, 0, UrlHeadYMW, 0, sw5);
                        platformYMW.WriteDownLoad(DirectionType.r, 0, UrlHeadYMW, 0, sw5);
                        platformYMW.WriteDownLoad(DirectionType.b, 0, UrlHeadYMW, 0, sw5);
                        platformYMW.WriteDownLoad(DirectionType.u, 0, UrlHeadYMW, 0, sw5);
                        platformYMW.WriteDownLoad(DirectionType.d, 0, UrlHeadYMW, 0, sw5);
                        sw5.Close();
                        sw5.Dispose();
                    });
                    threadYMW.Start();
                    var commandYMW = "-s 1 -x 1 -j 50  -i " + ConstPath.exePath + "/config.txt   --save-session=" + ConstPath.exePath + "/out.txt" + " -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", commandYMW, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }
                    return;
                #endregion
                #region 全景客
                case DownLoadType.lx_x_0x_0x:
                    PlatformQJK platfromQJK = new PlatformQJK();
                    StringBuilder tempstr = new StringBuilder(200);
                    int index1 = InputUrl.IndexOf(InputUrlQJK, 1, InputUrl.Length - 1);
                    StringBuilder UrlHeadQJK = new StringBuilder(InputUrl.Remove(index1, InputUrlQJK.Length));
                    int maxindex_QJK = 0;
                    int maxtype_QJK = 0;
                    List<string> liststr = new List<string>();
                    liststr = regExManager.GetRegexQJK(InputUrlQJK);

                    for (int j = 1; j < 15; j++)
                    {
                        tempstr.Clear();
                        tempstr.Append(InputUrlQJK.Replace(liststr[0], "" + j).Replace("_" + liststr[1] + "_", "_1_").Replace("_" + liststr[2] + ".", "_1."));

                        if (isPing(UrlHeadQJK + "" + tempstr, ""))
                        {
                            maxtype_QJK = j;

                        }
                        else
                        {
                            break;
                        }
                    }
                    for (int j = 1; j < 15; j++)
                    {
                        tempstr.Clear();
                        tempstr.Append(InputUrlQJK.Replace(liststr[0],""+ maxtype_QJK).Replace("_" + liststr[1] + "_", "_"+j+"_").Replace("_" + liststr[2] + ".", "_1."));
                        if (isPing(UrlHeadQJK + "" + tempstr, ""))
                        {
                            maxindex_QJK = j;

                        }
                        else
                        {
                            break;
                        }
                    }
                    Mesbox((maxindex_QJK *maxindex_QJK*6).ToString());
                    Thread threadQJK = new Thread(() =>
                     {

                         platfromQJK.WriteDownLoad(DirectionType.l, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         platfromQJK.WriteDownLoad(DirectionType.f, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         platfromQJK.WriteDownLoad(DirectionType.r, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         platfromQJK.WriteDownLoad(DirectionType.b, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         platfromQJK.WriteDownLoad(DirectionType.u, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         platfromQJK.WriteDownLoad(DirectionType.d, maxindex_QJK, UrlHeadQJK, maxtype_QJK, sw5);
                         sw5.Close();
                         sw5.Dispose();
                     });
                    threadQJK.Start();
                    var commandQJK = "-s 1 -x 1 -j 20  -i " + ConstPath.exePath + "/config.txt   --save-session=" + ConstPath.exePath + "/out.txt" + " -d" + ConstPath.saveFile;
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/aria2c.exe", commandQJK, (s, e) => ShowInfo("", e.Data));
                        p.Close();
                    }
                    ImageRowCount = maxindex_QJK;
                    return;
                #endregion
                default:
                    Mesbox("未知错误------->" + downLoadType);
                    break;
            }
        }

        public bool CheckLineCount(int maxindex)
        {
            FileStream fs = new FileStream(ConstPath.exePath + "/config.txt", FileMode.Open, FileAccess.ReadWrite); //new FileInfo(ConstPath.exePath + "/config.txt").
            StreamReader sr = new StreamReader(fs);
            int lines = 0;
            while (sr.ReadLine() != null)
            {
                lines++;
            }
            fs.Close();
            fs.Dispose();
            sr.Close();
            sr.Dispose();
            Mesbox("碎片图一共[" + lines.ToString() + "]张");
            this.Activate();
            if (lines != (maxindex * maxindex * 6))
            {
                Mesbox("参数丢失——————请重新下载");
                return true;
            }
            return false;
        }

        private void ShowInfo(string url, string a)
        {
            if (a == null) return;

            Thread_proc(a);
        }
        public delegate void DelReadStdOutput(string result);
        public delegate void DelReadErrOutput(string result);

        public event DelReadStdOutput ReadStdOutput;
        public event DelReadErrOutput ReadErrOutput;

        /// <summary>
        /// 重定向
        /// </summary>
        /// <param name="p"></param>
        /// <param name="exe"></param>
        /// <param name="arg"></param>
        /// <param name="output"></param>
        private void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output)
        {
            p.StartInfo.FileName = exe; // 命令
            p.StartInfo.Arguments = arg; // 参数

            p.StartInfo.CreateNoWindow = true; // 不创建新窗口
            p.StartInfo.UseShellExecute = false;    //输出信息重定向
            p.StartInfo.RedirectStandardInput = true; // 重定向输入
            p.StartInfo.RedirectStandardOutput = true; // 重定向标准输出
            p.StartInfo.RedirectStandardError = true;  // 重定向错误输出
            p.StartInfo.ErrorDialog = false;

            p.OutputDataReceived += new DataReceivedEventHandler(p_OutputDataReceived);
            p.ErrorDataReceived += new DataReceivedEventHandler(p_ErrorDataReceived);

            p.EnableRaisingEvents = true;                      // 启用Exited事件
            p.Exited += new EventHandler(CmdProcess_Exited);

            p.Start();                    //启动线程
            p.BeginErrorReadLine();
            p.BeginOutputReadLine();
            Application.DoEvents();

            //p.WaitForExit();            //等待进程结束
        }
        private void p_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                this.Invoke(ReadErrOutput, new object[] { e.Data });
            }
        }
        private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                // 4. 异步调用，需要invoke
                this.Invoke(ReadStdOutput, new object[] { e.Data });
            }
        }
        private void ReadStdOutputAction(string result)
        {
            const string ree1 = ".*?"; // Non-greedy match on filler
            const string ree2 = "(\\(.*\\))"; // Round Braces 1

            //var rr = new Regex(ree1 + ree2, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            byte[] buffer = Encoding.GetEncoding("GB2312").GetBytes(result);
            //var mm = rr.Match(Encoding.UTF8.GetString(buffer) + "\r\n");
            //var rbraces1 = mm.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
            //if (rbraces1 == "OK")
            //{
            //    rbraces1 = "100";
            //}

            //Log_texBox.Text = DateTime.Now.ToString().Replace("/", "-") + "    下载进度:" + rbraces1 + "%";

            Log_texBox.Text = result;

            //Mesbox(result + "\r\n");
        }
        private void ReadErrOutputAction(string result)
        {
            Mesbox(result + "\r\n");
        }
        private void CmdProcess_Exited(object sender, EventArgs e)
        {
            Mesbox("执行完毕" + e.ToString());
            // 执行结束后触发
        }

        delegate void d(string args);
        private delegate void UpdateInfo(string str);
        void Thread_proc(string args)
        {
            if (this.InvokeRequired)
            {
                d dd = new d(Thread_proc);
                this.Invoke(dd, new object[] { args });
            }
            else
            {
                if (args == null)
                {
                    return;
                }
                const string re1 = ".*?"; // Non-greedy match on filler
                const string re2 = "(\\(.*\\))"; // Round Braces 1

                var r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
                var m = r.Match(args);
                if (m.Success)
                {
                    var rbraces1 = m.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
                    if (rbraces1 == "OK")
                    {
                        rbraces1 = "100";
                    }
                }
            }
        }


        /// <summary>
        /// 打开激活界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void Activate_Button_Click(object sender, EventArgs e)
        {
            appManager.AppActivate(softAuthorize);
        }

        #region 一般级
        /// <summary>
        /// 提示框封装
        /// </summary>
        /// <param name="content"></param>
        public void Mesbox(string content)
        {
            MessageBox.Show(content, "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            this.TopMost = true;//使窗口 最上层
        }
        public void Mesbox(string content, string Title)
        {
            MessageBox.Show(content, Title, MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
        }
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (appManager.IsOpenADW)
            //{
            //    try
            //    {
            //        Process.Start(ConstPath.mailUrl);
            //    }
            //    catch (Exception ex)
            //    {
            //        SoftBasic.ShowExceptionMessage(ex);
            //    }
            //}
        }

        /// <summary>
        /// 联系qq
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (appManager.IsOpenADW)
            //{
            //    try
            //    {
            //        Process.Start("chrome.exe", ConstPath.qqUrl);
            //    }
            //    catch (Exception ex)
            //    {
            //        SoftBasic.ShowExceptionMessage(ex);
            //    }
            //}
        }

        /// <summary>
        /// 图标点击 互动
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void IconInteraction_OnCilck(object sender, EventArgs e)
        {
            if (toolTip1.GetToolTip(pictureBox1).Equals("你瞅啥？？"))
            {
                this.toolTip1.SetToolTip(pictureBox1, "瞅你咋的！！");
            }
            else
            {
                this.toolTip1.SetToolTip(pictureBox1, "你瞅啥？？");
            }
        }
        #endregion

        #region  网络类
        /// <summary>
        /// 判断链接 200
        /// </summary>
        /// <param name="url"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public string GetWebStatusCode(string url, int timeout, string referer)
        {
            HttpWebRequest req = null;
            //处理HttpWebRequest访问https有安全证书的问题（ 请求被中止: 未能创建 SSL/TLS 安全通道。）
            ServicePointManager.ServerCertificateValidationCallback += (s, cert, chain, sslPolicyErrors) => true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            try
            {
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                // req.CookieContainer = new CookieContainer();
                req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.110 Safari/537.36";
                if (url.Contains("720static"))
                {
                    req.Referer = "https://720yun.com";
                }
                else
                {
                    req.Referer = ""; //"https://720yun.com";
                }
                //rq.Accept = "*/*";
                req.Method = "GET";  //这是关键        
                req.Timeout = timeout;

                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                if (res.ContentType.Equals("image/jpeg") || res.ContentType.Equals("application/octet-stream") && res.StatusCode.Equals("200"))
                {
                    return Convert.ToInt32(res.StatusCode).ToString();
                }
                return "0";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
            finally
            {
                if (req != null)
                {
                    req.Abort();
                    req = null;
                }
            }
        }

        /// <summary>
        /// 如果是图片 并且返回的是200
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool isPing(string url, string referer)
        {
            if (GetWebStatusCode(url, 10000, referer).Equals("200"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion



        /// <summary>
        /// 下载全景图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownLoadImage_Button_Click(object sender, EventArgs e)
        {
            if (appisReg)
            {

                Mesbox("请激活软件");
                //this.TopMost = true;
                return;
            }
            if (ConstPath.saveFile.Contains(@"C:\"))
            {
                Mesbox("不要设置下载目录为C盘");
                return;
            }
            if (Directory.Exists(ConstPath.saveFile))
            {
                Task task = new Task(() =>
                {
                    FileManager.DelectDir(ConstPath.saveFile);
                });
                task.Start();
                task.Wait();
                if (listView1.Items.Count != 0)
                {
                    listView1.Items.Clear();
                }
            }
            if (string.IsNullOrEmpty(InputUrl))
            {
                UrlStateBox.Image = Properties.Resources.失败_表情;
                Mesbox("请输入链接");
                InputUrl_TextBox.Focus();
                return;
            }
            StartDownLoadImage();
        }


        /// <summary>
        /// 合成图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakeImage_Button_Click_1(object sender, EventArgs e)
        {
            if (appisReg)
            {
                Mesbox("请激活软件");
                return;
            }
            switch (downLoadType)
            {
                #region 网展
                case DownLoadType.lxlxxlxlx_x_x:
                    try
                    {
                        string[] strings = File.ReadAllLines(ConstPath.exePath + "/config.txt");
                        string pathWZ = ConstPath.saveFile;
                        if (strings.Length != 0)
                        {
                            PlatformWZ platformWz = new PlatformWZ();
                            platformWz.listview = listView1;
                            platformWz.ImageRowCount = ImageRowCount;
                            platformWz.ImagePath = ImagePath;
                            platformWz.urlKeysList = newKeystrList;


                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "d", ImageRowCount, null, 0);
                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "f", ImageRowCount, null, 1);
                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "b", ImageRowCount, null, 2);
                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "u", ImageRowCount, null, 3);
                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "l", ImageRowCount, null, 4);
                            platformWz.MatchingImage(pathWZ, ImageQualityIndex.ToString(), "r", ImageRowCount, null, 5);

                        }
                        var command = "-l=" + ImagePath["l"] + " -f=" + ImagePath["f"] + " -r=" + ImagePath["r"] + " -b=" + ImagePath["b"] + " -u=" + ImagePath["u"] + " -d=" + ImagePath["d"] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                        using (var p = new Process())
                        {
                            ListViewItem lvi1 = new ListViewItem();
                            listView1.Items.Add(lvi1);
                            lvi1.SubItems.AddRange(new string[] { "0", "0", "0" });
                            lvi1.Text = "全景大图.jpeg";
                            RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", command, null);
                            Thread.Sleep(500);
                            Thread.Sleep(500);
                            if (Log_texBox.Text.Equals("%"))
                            {
                                listView1.SetProgress(6, int.Parse(Log_texBox.Text.Replace("%", "")));
                            }
                            listView1.SetProgress(6, 100);
                            lvi1.SubItems[2].Text = "完成☺";
                            Thread.Sleep(500);
                            //this.listView1.EndUpdate();
                            p.Close();
                        }
                        ImagePath.Clear();
                    }
                    catch (Exception ex)
                    {
                        SoftBasic.ShowExceptionMessage(ex);
                    }
                    break;
                #endregion
                #region 720yun
                case DownLoadType.lx_x_xx_xx:
                    try
                    {
                        string[] strings = File.ReadAllLines(ConstPath.exePath + "/config.txt");

                        string path = ConstPath.saveFile;
                        if (strings.Length != 0)
                        {
                            PlatformYun platformYun = new PlatformYun();
                            platformYun.listview = listView1;
                            platformYun.ImageRowCount = ImageRowCount;
                            platformYun.ImagePath = ImagePath;
                            platformYun.urlKeysList = newKeystrList;
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "d", ImageRowCount, null, 0);
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "f", ImageRowCount, null, 1);
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "b", ImageRowCount, null, 2);
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "u", ImageRowCount, null, 3);
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "l", ImageRowCount, null, 4);
                            platformYun.MatchingImage(path, ImageQualityIndex.ToString(), "r", ImageRowCount, null, 5);
                        }
                        var command = "-l=" + ImagePath["l"] + " -f=" + ImagePath["f"] + " -r=" + ImagePath["r"] + " -b=" + ImagePath["b"] + " -u=" + ImagePath["u"] + " -d=" + ImagePath["d"] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                        using (var p = new Process())
                        {
                            ListViewItem lvi1 = new ListViewItem();
                            listView1.Items.Add(lvi1);
                            lvi1.SubItems.AddRange(new string[] { "0", "0", "0" });
                            lvi1.Text = "全景大图.jpeg";
                            RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", command, null);
                            Thread.Sleep(500);
                            Thread.Sleep(500);
                            if (Log_texBox.Text.Equals("%"))
                            {
                                listView1.SetProgress(6, int.Parse(Log_texBox.Text.Replace("%", "")));
                            }
                            listView1.SetProgress(6, 100);
                            lvi1.SubItems[2].Text = "完成☺";
                            Thread.Sleep(500);
                            //this.listView1.EndUpdate();
                            p.Close();
                        }
                        ImagePath.Clear();
                    }
                    catch (Exception ex)
                    {
                        SoftBasic.ShowExceptionMessage(ex);
                    }

                    //Mesbox("合成完毕");
                    break;
                #endregion
                #region 酷家乐
                case DownLoadType.ssssxssss:
                    var command1 = "-b=" + strMatc[0] + " -d=" + strMatc[1] + " -f=" + strMatc[2] + " -l=" + strMatc[3] + " -r=" + strMatc[4] + " -u=" + strMatc[5] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", command1, null);
                        p.Close();
                    }
                    strMatc.Clear();
                    return;
                #endregion
                #region 鱼模网
                case DownLoadType.xxxx_x:
                    string[] sDirectoriesYMW = Directory.GetFiles(ConstPath.saveFile);
                    for (int i = 0; i < sDirectoriesYMW.Length; i++)
                    {
                        string sDirectoryName = Path.GetFileName(sDirectoriesYMW[i]);
                        // string newstrDir = sDirectoryName.Remove(0, sDirectoryName.Length - 1);
                        //string sNewDirectoryName = newstrDir + ".jpg";
                        string sNewDirectory = Path.Combine(ConstPath.saveFile, sDirectoryName);
                        // Directory.Move(sDirectories[i], sNewDirectory);
                        // File.Move(sDirectoriesYMW[i], sNewDirectory);
                        strMatc.Add(sNewDirectory);
                    }
                    var command2 = "-b=" + strMatc[0] + " -d=" + strMatc[1] + " -f=" + strMatc[2] + " -l=" + strMatc[3] + " -r=" + strMatc[4] + " -u=" + strMatc[5] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                    using (var p = new Process())
                    {
                        RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", command2, null);
                        p.Close();
                    }
                    strMatc.Clear();
                    return;
                #endregion
                #region 建e网
                case DownLoadType.lxlxx_x_x_x:
                    string[] stringsYJ = File.ReadAllLines(ConstPath.exePath + "/config.txt");
                    string pathYJ = ConstPath.saveFile;
                    if (stringsYJ.Length != 0)
                    { 
                        PlatformJE platformJE = new PlatformJE();
                        platformJE.listview = listView1;
                        platformJE.ImageRowCount = ImageRowCount;
                        platformJE.ImagePath = ImagePath;
                        platformJE.urlKeysList = newKeystrList;

                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "d", ImageRowCount, null, 0);
                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "f", ImageRowCount, null, 1);
                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "b", ImageRowCount, null, 2);
                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "u", ImageRowCount, null, 3);
                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "l", ImageRowCount, null, 4);
                        platformJE.MatchingImage(pathYJ, ImageQualityIndex.ToString(), "r", ImageRowCount, null, 5);

                        //getimg(pathYJ, ImageQualityIndex.ToString(), "d", ImageRowCount, null, 0);//2304//4608//3072
                        //getimg(pathYJ, ImageQualityIndex.ToString(), "f", ImageRowCount, null, 1);//2304//4608//3072
                        //getimg(pathYJ, ImageQualityIndex.ToString(), "b", ImageRowCount, null, 2);//2304//4608//3072
                        //getimg(pathYJ, ImageQualityIndex.ToString(), "u", ImageRowCount, null, 3);//2304//4608//3072
                        //getimg(pathYJ, ImageQualityIndex.ToString(), "l", ImageRowCount, null, 4);//2304//4608//3072
                        //getimg(pathYJ, ImageQualityIndex.ToString(), "r", ImageRowCount, null, 5);//2304//4608//3072
                    }
                    var commandYJ = "-l=" + ImagePath["l"] + " -f=" + ImagePath["f"] + " -r=" + ImagePath["r"] + " -b=" + ImagePath["b"] + " -u=" + ImagePath["u"] + " -d=" + ImagePath["d"] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                    using (var p = new Process())
                    {
                        ListViewItem lvi1 = new ListViewItem();
                        listView1.Items.Add(lvi1);
                        lvi1.SubItems.AddRange(new string[] { "0", "0", "0" });
                        lvi1.Text = "全景大图.jpeg";

                        Thread.Sleep(500);
                        Thread.Sleep(500);
                        if (Log_texBox.Text.Equals("%"))
                        {
                            listView1.SetProgress(6, int.Parse(Log_texBox.Text.Replace("%", "")));
                        }
                        RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", commandYJ, null);
                        //dd.Value = 100;
                        listView1.SetProgress(6, 100);
                        lvi1.SubItems[2].Text = "完成☺";
                        p.Close();
                    }
                    ImagePath.Clear();
                    return;
                #endregion
                #region 全景客
                case DownLoadType.lx_x_0x_0x:
                    try
                    {
                        string[] strings = File.ReadAllLines(ConstPath.exePath + "/config.txt");

                        string path = ConstPath.saveFile;
                        if (strings.Length != 0)
                        {
                            PlatformQJK platformQJK = new PlatformQJK();
                            platformQJK.listview = listView1;
                            platformQJK.ImageRowCount = ImageRowCount;
                            platformQJK.ImagePath = ImagePath;
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "d", ImageRowCount, null, 0);
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "f", ImageRowCount, null, 1);
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "b", ImageRowCount, null, 2);
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "u", ImageRowCount, null, 3);
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "l", ImageRowCount, null, 4);
                            platformQJK.MatchingImage(path, ImageRowCount.ToString(), "r", ImageRowCount, null, 5);
                        }
                        var commandQJK = "-l=" + ImagePath["l"] + " -f=" + ImagePath["f"] + " -r=" + ImagePath["r"] + " -b=" + ImagePath["b"] + " -u=" + ImagePath["u"] + " -d=" + ImagePath["d"] + " -o=" + ConstPath.saveFile + "sphere.jpeg";
                        using (var p = new Process())
                        {
                            ListViewItem lvi1 = new ListViewItem();
                            listView1.Items.Add(lvi1);
                            lvi1.SubItems.AddRange(new string[] { "0", "0", "0" });
                            lvi1.Text = "全景大图.jpeg";
                            RedirectExcuteProcess(p, ConstPath.exePath + "/kcube2sphere.exe", commandQJK, null);
                            Thread.Sleep(500);
                            Thread.Sleep(500);
                            if (Log_texBox.Text.Equals("%"))
                            {
                                listView1.SetProgress(6, int.Parse(Log_texBox.Text.Replace("%", "")));
                            }
                            listView1.SetProgress(6, 100);
                            lvi1.SubItems[2].Text = "完成☺";
                            Thread.Sleep(500);
                            //this.listView1.EndUpdate();
                            p.Close();
                        }
                        ImagePath.Clear();
                    }
                    catch (Exception ex)
                    {

                    }
                    break;
#endregion
                default:
                    Mesbox("请下载图片后在合成");
                    this.Activate();
                    return;
            }
        }

        /// <summary>
        /// 打开图片目录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenImagePath_Button_Click(object sender, EventArgs e)
        {
            if (appisReg)
            {
                Mesbox("请激活软件");
                return;
            }
            FileManager.OpenFolder(ConstPath.saveFile);
        }

        /// <summary>
        /// 选择图片的保存路径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetImageSavePath_Button_Click(object sender, EventArgs e)
        {
            if (appisReg)
            {
                Mesbox("请激活软件");
                return;
            }
            FolderBrowserDialog Savepath = new FolderBrowserDialog();
            Savepath.SelectedPath = ConstPath.saveFile;
            //if (string.IsNullOrEmpty(Savepath.SelectedPath))
            //{
            //    ImageSavePath_Label.Text = "图片路径:" + ConstPath.saveFile;
            //    return;
            //}
            if (Savepath.ShowDialog() == DialogResult.OK)
            {
                //记录选中的目录
                ConstPath.saveFile = Savepath.SelectedPath + "\\";
                ImageSavePath_Label.Text = "图片路径:" + ConstPath.saveFile;
                MessageBox.Show("下载目录不要随意设置。每次下载会清空你设置的目录" + "\n\n" + " 确认设置下载路径为以下路径吗？" + "\n\n" + ConstPath.saveFile, "重要提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            Savepath.Dispose();
        }

        /// <summary>
        /// 打开支付窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pay_Button_Click(object sender, EventArgs e)
        {
            PayForm pay_Form = new PayForm();
            pay_Form.ShowDialog(this);
        }


        /// <summary>
        /// 软件使用说明
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UseExplain_Link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //if (File.Exists(e.Link.LinkData.ToString()))
            //{
            //    try
            //    {
            //        Process.Start("explorer.exe", e.Link.LinkData.ToString());
            //    }
            //    catch (Exception ex)
            //    {
            //        SoftBasic.ShowExceptionMessage(ex);
            //    }
            //}
            UseForm useForm = new UseForm();
            useForm.ShowDialog(this);
        }


        /// <summary>
        /// 打开查看全景界面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MakePano_Button_Click(object sender, EventArgs e)
        {
            MakePano makePano = new MakePano();
            //makePano.TopMost = true;
            makePano.StartPosition = FormStartPosition.CenterParent;
            makePano.ShowDialog(this);
        }

        /// <summary>
        /// Quit事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("你确定要退出？", "系统提示", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}