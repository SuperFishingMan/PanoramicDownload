using System.Windows.Forms;

namespace PanoramicDownload
{
    partial class PayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PayForm));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ZFB_Button = new HslCommunication.Controls.UserButton();
            this.WX_Button = new HslCommunication.Controls.UserButton();
            this.QQ_Button = new HslCommunication.Controls.UserButton();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.InitialDelay = 5;
            this.toolTip1.OwnerDraw = true;
            this.toolTip1.ReshowDelay = 1;
            this.toolTip1.Draw += new System.Windows.Forms.DrawToolTipEventHandler(this.toolTip1_Draw);
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // ZFB_Button
            // 
            this.ZFB_Button.BackColor = System.Drawing.Color.Transparent;
            this.ZFB_Button.CustomerInformation = "";
            this.ZFB_Button.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ZFB_Button.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.ZFB_Button.Location = new System.Drawing.Point(64, 37);
            this.ZFB_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ZFB_Button.Name = "ZFB_Button";
            this.ZFB_Button.Size = new System.Drawing.Size(78, 25);
            this.ZFB_Button.TabIndex = 0;
            this.ZFB_Button.UIText = "支付宝";
            // 
            // WX_Button
            // 
            this.WX_Button.BackColor = System.Drawing.Color.Transparent;
            this.WX_Button.CustomerInformation = "";
            this.WX_Button.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.WX_Button.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.WX_Button.Location = new System.Drawing.Point(64, 82);
            this.WX_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.WX_Button.Name = "WX_Button";
            this.WX_Button.Size = new System.Drawing.Size(78, 25);
            this.WX_Button.TabIndex = 1;
            this.WX_Button.UIText = "微信";
            // 
            // QQ_Button
            // 
            this.QQ_Button.BackColor = System.Drawing.Color.Transparent;
            this.QQ_Button.CustomerInformation = "";
            this.QQ_Button.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.QQ_Button.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.QQ_Button.Location = new System.Drawing.Point(64, 127);
            this.QQ_Button.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QQ_Button.Name = "QQ_Button";
            this.QQ_Button.Size = new System.Drawing.Size(78, 25);
            this.QQ_Button.TabIndex = 2;
            this.QQ_Button.UIText = "QQ";
            // 
            // PayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(208, 203);
            this.Controls.Add(this.QQ_Button);
            this.Controls.Add(this.WX_Button);
            this.Controls.Add(this.ZFB_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "PayForm";
            this.Text = "付款码";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolTip toolTip1;
        private HslCommunication.Controls.UserButton ZFB_Button;
        private HslCommunication.Controls.UserButton WX_Button;
        private HslCommunication.Controls.UserButton QQ_Button;
    }
}