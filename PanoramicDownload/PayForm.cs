using CsharpHttpHelper;
using HslCommunication.BasicFramework;
using System;
using System.Drawing;
using System.Net;

using System.Windows.Forms;

namespace PanoramicDownload
{
    public partial class PayForm : Form
    {
        public PayForm()
        {

            this.StartPosition = FormStartPosition.CenterParent;
            InitializeComponent();
            this.toolTip1.SetToolTip(ZFB_Button, "支付宝支付");
            this.toolTip1.SetToolTip(WX_Button, "微信支付");
            this.toolTip1.SetToolTip(QQ_Button, "QQ支付");
            LoadWebImage();
        }
        private Image ZFB_Image;
        private Image WX_Image;
        private Image QQ_Image;
        private HttpHelper http;
        private HttpItem item;
        public void LoadWebImage()
        {
            try
            {
                http = new HttpHelper();
                //创建Httphelper参数对象
                item = new HttpItem()
                {
                    URL = "http://47.98.156.83/Web/images/zhifubao.jpg",//URL     必需项    
                    Method = "get",//URL     可选项 默认为Get   
                    ContentType = "Image",//返回类型    可选项有默认值
                };
                ZFB_Image = http.GetImage(item);
                item = new HttpItem()
                {
                    URL = "http://47.98.156.83/Web/images/weixin.jpg",//URL     必需项    
                    Method = "get",//URL     可选项 默认为Get   
                    ContentType = "Image",//返回类型    可选项有默认值
                };
                WX_Image = http.GetImage(item);
                item = new HttpItem()
                {
                    URL = "http://47.98.156.83/Web/images/qqzhifu.jpg",//URL     必需项    
                    Method = "get",//URL     可选项 默认为Get   
                    ContentType = "Image",//返回类型    可选项有默认值
                };
                QQ_Image = http.GetImage(item);
            }
            catch (Exception ex)
            {
                SoftBasic.ShowExceptionMessage("错误原因：请检查网络连接！！！  \n", ex);
            }

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {
            if (e.AssociatedControl == ZFB_Button)
            {
                e.ToolTipSize = new Size(ZFB_Image.Width, ZFB_Image.Height);
            }
            else if (e.AssociatedControl == WX_Button)
            {
                e.ToolTipSize = new Size(WX_Image.Width, WX_Image.Height);
            }
            else if (e.AssociatedControl == QQ_Button)
            {
                e.ToolTipSize = new Size(QQ_Image.Width, QQ_Image.Height);
            }
        }

        /// <summary>
        /// 悬浮支付图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolTip1_Draw(object sender,
            DrawToolTipEventArgs e)
        {
            if (e.AssociatedControl == ZFB_Button)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, ZFB_Image.Width, ZFB_Image.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(ZFB_Image, 0, 0, ZFB_Image.Width, ZFB_Image.Height);
            }
            else if (e.AssociatedControl == WX_Button)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, WX_Image.Width, WX_Image.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(WX_Image, 0, 0, WX_Image.Width, WX_Image.Height);
            }
            else if (e.AssociatedControl == QQ_Button)
            {
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                Rectangle rc = new Rectangle(0, 0, QQ_Image.Width, QQ_Image.Height);
                e.Graphics.FillRectangle(SystemBrushes.ActiveCaption, e.Bounds);
                e.DrawBorder();
                e.Graphics.DrawImage(QQ_Image, 0, 0, QQ_Image.Width, QQ_Image.Height);
            }
        }
    }
}
