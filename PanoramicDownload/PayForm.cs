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
        private Image zhifubaoImage;
        private Image weixinImage;
        private Image qqzhifuImage;
        public void LoadWebImage()
        {
            try
            {
                zhifubaoImage = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/zhifubao.jpg").GetResponse().GetResponseStream());
                weixinImage = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/weixin.jpg").GetResponse().GetResponseStream());
                qqzhifuImage = Image.FromStream(WebRequest.Create("http://47.98.156.83/Web/images/qqzhifu.jpg").GetResponse().GetResponseStream());
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
                e.ToolTipSize = new Size(zhifubaoImage.Width, zhifubaoImage.Height);
            }
            else if (e.AssociatedControl == userButton2)
            {
                e.ToolTipSize = new Size(weixinImage.Width, weixinImage.Height);
            }
            else if (e.AssociatedControl == userButton3)
            {
                e.ToolTipSize = new Size(qqzhifuImage.Width, qqzhifuImage.Height);
            }
        }

        // Handles drawing the ToolTip.
        private void toolTip1_Draw(System.Object sender,
            System.Windows.Forms.DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl == userButton1)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, zhifubaoImage.Width, zhifubaoImage.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(zhifubaoImage, 0, 0, zhifubaoImage.Width, zhifubaoImage.Height);
            }
            else if (e.AssociatedControl == userButton2)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, weixinImage.Width, weixinImage.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(weixinImage, 0, 0, weixinImage.Width, weixinImage.Height);
            }
            else if (e.AssociatedControl == userButton3)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, qqzhifuImage.Width, qqzhifuImage.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(qqzhifuImage, 0, 0, qqzhifuImage.Width, qqzhifuImage.Height);
            }
        }

    }
}
