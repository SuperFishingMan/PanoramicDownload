using HslCommunication.BasicFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PanoramicDownload
{
    public partial class PayForm : Form
    {
        public PayForm()
        {
        
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            InitializeComponent();
            this.toolTip1.SetToolTip(userButton1, "支付宝支付");
            this.toolTip1.SetToolTip(userButton2, "微信支付");
            this.toolTip1.SetToolTip(userButton3, "QQ支付");
            LoadWebImage();
        }
        private Image image1;
        private Image image2;
        private Image image3;
        public void LoadWebImage()
        {
            try
            {
                image1 = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/zhifubao.jpg").GetResponse().GetResponseStream());
                image2 = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/weixin.jpg").GetResponse().GetResponseStream());
                image3 = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/qqzhifu.jpg").GetResponse().GetResponseStream());
            }
            catch(Exception ex)
            {
                SoftBasic.ShowExceptionMessage("错误原因：请检查网络连接！！！  \n",ex);
            }
       
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == userButton1)
            {
                e.ToolTipSize = new Size(image1.Width, image1.Height);
            }
            else if (e.AssociatedControl == userButton2)
            {
                e.ToolTipSize = new Size(image2.Width, image2.Height);
            }
            else if (e.AssociatedControl == userButton3)
            {
                e.ToolTipSize = new Size(image3.Width, image3.Height);
            }
        }

        // Handles drawing the ToolTip.
        private void toolTip1_Draw(System.Object sender,
            System.Windows.Forms.DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl == userButton1)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, image1.Width, image1.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(image1, 0, 0, image1.Width, image1.Height);
            }
            else if (e.AssociatedControl == userButton2)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, image2.Width, image2.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(image2, 0, 0, image2.Width, image2.Height);
            }
            else if (e.AssociatedControl == userButton3)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, image3.Width, image3.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(image3, 0, 0, image3.Width, image3.Height);
            }
        }
    }
}
