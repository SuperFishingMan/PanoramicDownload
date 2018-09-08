using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          

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
                return  OpenFD.FileName;       //把 路径名称 赋给 fileName
            }
        }

        public  string Matchs(string str)
        {

            string txt = str;
            string re1 = "([a-z])"; // Any Single Word Character (Not Whitespace) 1
            string re2 = "(.)"; // Any Single Character 1
            string re3 = "([a-z])"; // Any Single Word Character (Not Whitespace) 2
            string re4 = "(\\d)";   // Any Single Digit 1
            string re5 = "(\\/)";   // Any Single Character 2
            string re6 = "(\\d+)";  // Integer Number 1
            string re7 = "(\\/)";   // Any Single Character 3
            string re8 = "([a-z])"; // Any Single Word Character (Not Whitespace) 3
            string re9 = "(\\d+)";  // Integer Number 2
            string re10 = "(.)";    // Any Single Character 4
            string re11 = "([a-z])";    // Any Single Word Character (Not Whitespace) 4
            string re12 = "(.)";    // Any Single Character 5
            string re13 = "(\\d+)"; // Integer Number 3
            string re14 = "(.)";    // Any Single Character 6
            string re15 = "(\\d+)"; // Integer Number 4
            string re16 = "(\\.)";  // Any Single Character 7
            string re17 = "((?:[a-z][a-z]+))";  // Word 1

            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7 + re8 + re9 + re10 + re11 + re12 + re13 + re14 + re15 + re16 + re17, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            if (m.Success)
            {
                String w1 = m.Groups[1].ToString();
                String c1 = m.Groups[2].ToString();
                String w2 = m.Groups[3].ToString();
                String d1 = m.Groups[4].ToString();
                String c2 = m.Groups[5].ToString();
                String int1 = m.Groups[6].ToString();
                String c3 = m.Groups[7].ToString();
                String w3 = m.Groups[8].ToString();
                String int2 = m.Groups[9].ToString();
                String c4 = m.Groups[10].ToString();
                String w4 = m.Groups[11].ToString();
                String c5 = m.Groups[12].ToString();
                String int3 = m.Groups[13].ToString();
                String c6 = m.Groups[14].ToString();
                String int4 = m.Groups[15].ToString();
                String c7 = m.Groups[16].ToString();
                String word1 = m.Groups[17].ToString();
                //MessageBox.Show(w1.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + d1.ToString() + "" + "" + c2.ToString() + "" + "" + int1.ToString() + "" + "" + c3.ToString() + "" + "" + w3.ToString() + "" + "" + int2.ToString() + "" + "" + c4.ToString() + "" + "" + w4.ToString() + "" + "" + c5.ToString() + "" + "" + int3.ToString() + "" + "" + c6.ToString() + "" + "" + int4.ToString() + "" + "" + c7.ToString() + "" + "" + word1.ToString() + "" + "\n");
                return w1.ToString() + "" + "" + c1.ToString() + "" + "" + w2.ToString() + "" + "" + d1.ToString() + "" + "" + c2.ToString() + "" + "" + int1.ToString() + "" + "" + c3.ToString() + "" + "" + w3.ToString() + "" + "" + int2.ToString() + "" + "" + c4.ToString() + "" + "" + w4.ToString() + "" + "" + c5.ToString() + "" + "" + int3.ToString() + "" + "" + c6.ToString() + "" + "" + int4.ToString() + "" + "" + c7.ToString() + "" + "" + word1.ToString() + "" + "\n";
               
            }
            return "";

        }
        //https://ssl-panoimg53.720static.com/resource/prod/600id9861r9/20b2dcs8u4r/12710576/imgs/b/l2/1/l2_b_1_4.jpg
        private void LoadButton_Click(object sender, EventArgs e)
        {
            string fileName =" ";
            //using (OpenFileDialog OpenFD = new OpenFileDialog())     //实例化一个 OpenFileDialog 的对象
            //{

            //    //定义打开的默认文件夹位置
            //    OpenFD.InitialDirectory = Application.StartupPath;
            //    OpenFD.Filter = "All files(*.*)|*.*|txt files(*.txt)|*.txt";
            //    OpenFD.FilterIndex = 2;
            //    OpenFD.ShowDialog();                  //显示打开本地文件的窗体
            //    OpenFD.RestoreDirectory = true;
            //    fileName = OpenFD.FileName;       //把 路径名称 赋给 fileName
            //}
            string url = "http://image.xfh8866.cn/1007/works/a9705fcb5d2ccb41/";
            List<string> Down = new List<string>();
            fullfile(fileName, url, "4", 13, DirectionType.d, Down);

            //string l = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\l.JPG";
            //string f = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\f.JPG";
            //string r = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\r.JPG";
            //string b = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\b.JPG";
            //string u = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\u.JPG";
            //string d = @"C:\Users\易眸\Desktop\LoadFile\Demo\bin\Debug\下载文件\d.JPG";


            //var command = " -l=" + l + " -f=" + f + " -r=" + r + " -b=" + b + " -u=" + u + " -d=" + d + "";


            //using (var p = new Process())
            //{
            //    string read = "";
            //    RedirectExcuteProcess(p, @"C:\Users\易眸\Desktop\123\kcube2sphere.exe", command, (s, g) => test("", g.Data),read);

            //}
        }
        private void test(string a, string b)
        {
            int outint = 0;
            if (b == null)
            {
                return;
            }
            if (b.Contains("%"))
            {
                string str = b.Replace("%", "");
                if (int.TryParse(str, out outint))
                {
                    //value = outint;
                }
            }
        }
        private  void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output,string read)
        {
            p.StartInfo.FileName = exe;
            p.StartInfo.Arguments = arg;

            p.StartInfo.UseShellExecute = false;    //输出信息重定向
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;       

            p.OutputDataReceived += output;
            p.ErrorDataReceived += output;

             p.Start();                    //启动线程
                                           //p.BeginOutputReadLine();
                                           //p.BeginErrorReadLine();
            //while (!p.StandardOutput.EndOfStream)
            //{
            //    read += p.StandardOutput.ReadLine() + Environment.NewLine;
            //}
            //Task<string> dd;
            // dd =  p.StandardOutput.ReadLineAsync();
           // SetText(dd.Result);
            //p.OutputDataReceived += (sender, e) =>
            //{
            //    SetText(e.Data +"\n");
            //   // textBox1.Text = e.Data;
            //};
            //p.ErrorDataReceived += (sender, e) =>
            //{
            //    MessageBox.Show(e.Data + "\n");
            //};
            
           
          //  p.WaitForExit();            //等待进程结束
            p.Close();
        }
        private delegate void SetTextCallback(string text);


        public void fullfile(string confi, string Url, string index, int forint, DirectionType mode, List<string> sw)
        {
            for (int i = 1; i <= forint; i++)
            {
                for (int x = 1; x <= forint; x++)
                {
                    string get = GetWebStatusCode(Url + mode + "/" + "l" + index + "/" + i + "/l" + index + "_" + mode + "_" + i + "_" + x + ".jpg", 1000);
                    if (get.Equals("200"))
                    {
                        string url = "";
                        var command = " -j 5  " + Url + mode + "/l" + index + "/" + i + "/l" + index + "_" + mode + "_" + i + "_" + x + ".jpg";
                        using (var p = new Process())
                        {
                            RedirectExcuteProcess(p, @"D:\test\aria2c.exe", command, (s, e) => ShowInfo(url, e.Data));
                        
                        }
                    }
                }
            }
        }
        private  void RedirectExcuteProcess(Process p, string exe, string arg, DataReceivedEventHandler output)
        {
            p.StartInfo.FileName = exe;
            p.StartInfo.Arguments = arg;

            p.StartInfo.UseShellExecute = false;    //输出信息重定向
            p.StartInfo.ErrorDialog = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardOutput = true;


            p.OutputDataReceived += output;
            p.ErrorDataReceived += output;

            
            p.Start();                    //启动线程
            Application.DoEvents();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            //p.WaitForExit();            //等待进程结束
        }


        public void getimg(string filepath, string imgName, string tpye, int index)
        {

            ListViewItem lvi = new ListViewItem();
            //progressBar1
             
            ProgressBar dd = new ProgressBar();
       
            //dd.Maximum = 169;
            this.listView1.BeginUpdate();
            lvi.Text = imgName + ".jpg";
            int idd = 0;
            lvi.SubItems.Add(idd.ToString());
            lvi.SubItems.Add("");          

            this.listView1.Items.Add(lvi);

            this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
            int contwidth = 0;
            for (int x = 1; x <= index; x++)
            {
                int i = Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + 1 + "_" + x + ".jpg").Width;
                contwidth += i;
            }

            Image bmp = new Bitmap(contwidth, contwidth, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics g = Graphics.FromImage(bmp);           
            int high = 0;
            for (int i = 1; i <= index; i++)
            {
                int width = 0;
                for (int d = 1; d <= index; d++)
                {
                    Application.DoEvents();
                    g.DrawImage(Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + i + "_" + d + ".jpg"), width, high, Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + i + "_" + d + ".jpg").Width, Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + i + "_" + d + ".jpg").Height);
                    width += Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + i + "_" + d + ".jpg").Width;
                    idd++;

                    this.listView1.BeginUpdate();           
                    //lvi.SubItems[2].Text = idd.ToString();
                    dd.Parent = listView1;
                    dd.SetBounds(lvi.SubItems[1].Bounds.X, lvi.SubItems[1].Bounds.Y, lvi.SubItems[1].Bounds.Width, lvi.SubItems[1].Bounds.Height);


                    dd.Value = (int)(idd / 1.69);
                    
                    this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                }
                high += Image.FromFile(filepath + "l" + imgName + "_" + tpye + "_" + i + "_" + i + ".jpg").Height;
            }

            g.Flush();
            g.Dispose();
            bmp.Save(AppDomain.CurrentDomain.BaseDirectory + "下载文件/" + tpye + ".JPG", ImageFormat.Jpeg);

            //ImagePath.Add(tpye, AppDomain.CurrentDomain.BaseDirectory + "下载文件\\" + tpye + ".JPG");

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
                    //this.listView1.BeginUpdate();
                  //  ListViewItem lvi = new ListViewItem();
                   // lvi.Text = "";
               
                    var rbraces1 = m.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
                    if (rbraces1 == "OK")
                    {
                        rbraces1 = "100";
                       /// lvi.SubItems.Add(rbraces1);
                    }
                   // lvi.SubItems.Add(rbraces1);
                    //this.listView1.Items.Add(lvi);
                    //this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
                }
            }
        }
        private void ShowInfo(string url, string a)
        {
            if (a == null) return;

            Thread_proc(a);
            
            //const string re1 = ".*?"; // Non-greedy match on filler
            //const string re2 = "(\\(.*\\))"; // Round Braces 1

            //var r = new Regex(re1 + re2, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            //var m = r.Match(a);
            //if (m.Success)
            //{
            //    var rbraces1 = m.Groups[1].ToString().Replace("(", "").Replace(")", "").Replace("%", "").Replace("s", "0");
            //    if (rbraces1 == "OK")
            //    {
            //        rbraces1 = "100";
            //    }
            //    //Thread_proc(DateTime.Now.ToString().Replace("/", "-") + "    " + url + "    下载进度:" + rbraces1 + "%");
            //    //Console.WriteLine(DateTime.Now.ToString().Replace("/", "-") + "    " + url + "    下载进度:" + rbraces1 + "%");
            //}
                

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = OpenText();
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {         
            Process.Start("mailto:yzj520mei@126.com,test2@sample.com");          
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("chrome.exe", "http://wpa.qq.com/msgrd?v=3&uin=1228267639&site=qq&menu=yes");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            //string str = Matchs(textBox5.Text);
            // MessageBox.Show(GetWebStatusCode(textBox5.Text, 100));
            //listView1.ResetText();

         
            //for (int i = 0; i < 10; i++)   //添加10行数据
            //{
            //    ListViewItem lvi = new ListViewItem();

            //    lvi.ImageIndex = i;     //通过与imageList绑定，显示imageList中第i项图标

            //    lvi.Text = "subitem" + i;

            //    lvi.SubItems.Add("第2列,第" + i + "行");

            //    lvi.SubItems.Add("第3列,第" + i + "行");

            //    this.listView1.Items.Add(lvi);
            //}

            //this.listView1.EndUpdate();  //结束数据处理，UI界面一次性绘制。
        }

        public static string GetWebStatusCode(string url, int timeout)
        {
            HttpWebRequest req = null;
            try
            {
                req = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                req.Method = "HEAD";  //这是关键        
                req.Timeout = timeout;
                HttpWebResponse res = (HttpWebResponse)req.GetResponse();
                return Convert.ToInt32(res.StatusCode).ToString();
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

        private void button3_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"下载文件\";
            getimg(path, "4", "d", 13);//2304//4608//3072
        }
    }
}
