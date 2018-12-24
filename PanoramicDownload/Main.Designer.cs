namespace PanoramicDownload
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.UrlStateBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.userButton1 = new HslCommunication.Controls.UserButton();
            this.userButton6 = new HslCommunication.Controls.UserButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.userButton5 = new HslCommunication.Controls.UserButton();
            this.userButton4 = new HslCommunication.Controls.UserButton();
            this.userButton3 = new HslCommunication.Controls.UserButton();
            this.userButton2 = new HslCommunication.Controls.UserButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.InputUrlTextBox = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.listView1 = new System.Windows.Forms.ProgressListview(this.components);
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UrlStateBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 5000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.toolTip1.InitialDelay = 500;
            this.toolTip1.ReshowDelay = 100;
            this.toolTip1.Tag = "";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.Location = new System.Drawing.Point(243, 59);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(195, 24);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Email:yzj520mei@162.cim";
            this.toolTip1.SetToolTip(this.linkLabel1, "我的邮箱");
            this.linkLabel1.UseCompatibleTextRendering = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.Location = new System.Drawing.Point(119, 59);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(113, 24);
            this.linkLabel2.TabIndex = 7;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "QQ:1228267639";
            this.toolTip1.SetToolTip(this.linkLabel2, "我的QQ");
            this.linkLabel2.UseCompatibleTextRendering = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PanoramicDownload.Properties.Resources.问好;
            this.pictureBox2.Location = new System.Drawing.Point(116, 2);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(18, 19);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox2, "请输入本软件支持平台的全景链接  先观看使用说明在进行操作");
            // 
            // UrlStateBox
            // 
            this.UrlStateBox.Image = global::PanoramicDownload.Properties.Resources.yes;
            this.UrlStateBox.Location = new System.Drawing.Point(500, 9);
            this.UrlStateBox.Name = "UrlStateBox";
            this.UrlStateBox.Size = new System.Drawing.Size(48, 51);
            this.UrlStateBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.UrlStateBox.TabIndex = 6;
            this.UrlStateBox.TabStop = false;
            this.toolTip1.SetToolTip(this.UrlStateBox, "使用笑脸判断链接是否为可下载的全景图链接");
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(75, 80);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "你瞅啥？？");
            this.pictureBox1.Click += new System.EventHandler(this.IconInteraction_OnCilck);
            // 
            // userButton1
            // 
            this.userButton1.BackColor = System.Drawing.Color.Transparent;
            this.userButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.userButton1.CustomerInformation = "";
            this.userButton1.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.userButton1.Location = new System.Drawing.Point(533, 45);
            this.userButton1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.userButton1.Name = "userButton1";
            this.userButton1.OriginalColor = System.Drawing.SystemColors.InactiveCaption;
            this.userButton1.Size = new System.Drawing.Size(74, 38);
            this.userButton1.TabIndex = 6;
            this.toolTip1.SetToolTip(this.userButton1, "激活软件联系 qq:1228267639");
            this.userButton1.UIText = "激活软件";
            this.userButton1.Click += new System.EventHandler(this.userButton1_Click);
            // 
            // userButton6
            // 
            this.userButton6.BackColor = System.Drawing.Color.Transparent;
            this.userButton6.Cursor = System.Windows.Forms.Cursors.Default;
            this.userButton6.CustomerInformation = "";
            this.userButton6.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton6.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.userButton6.Location = new System.Drawing.Point(455, 45);
            this.userButton6.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.userButton6.Name = "userButton6";
            this.userButton6.OriginalColor = System.Drawing.SystemColors.InactiveCaption;
            this.userButton6.Size = new System.Drawing.Size(74, 38);
            this.userButton6.TabIndex = 20;
            this.toolTip1.SetToolTip(this.userButton6, "激活软件联系 qq:1228267639");
            this.userButton6.UIText = "付款码";
            this.userButton6.Click += new System.EventHandler(this.userButton6_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.userButton6);
            this.panel1.Controls.Add(this.userButton5);
            this.panel1.Controls.Add(this.userButton4);
            this.panel1.Controls.Add(this.userButton3);
            this.panel1.Controls.Add(this.userButton2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.listView1);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.linkLabel2);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.userButton1);
            this.panel1.Location = new System.Drawing.Point(2, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 670);
            this.panel1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Font = new System.Drawing.Font("楷体", 11F);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(0, 652);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(511, 15);
            this.label3.TabIndex = 17;
            this.label3.Text = "目前支持平台：720云 建e网 汽车之家 酷家乐 详情咨询 QQ1228267639";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("楷体", 8F);
            this.label1.Location = new System.Drawing.Point(21, 413);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 11);
            this.label1.TabIndex = 8;
            this.label1.Text = ".........";
            // 
            // userButton5
            // 
            this.userButton5.BackColor = System.Drawing.Color.Transparent;
            this.userButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userButton5.CustomerInformation = "";
            this.userButton5.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton5.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.userButton5.Location = new System.Drawing.Point(468, 428);
            this.userButton5.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.userButton5.Name = "userButton5";
            this.userButton5.Size = new System.Drawing.Size(124, 39);
            this.userButton5.TabIndex = 19;
            this.userButton5.UIText = "打开图片目录";
            this.userButton5.Click += new System.EventHandler(this.userButton5_Click);
            // 
            // userButton4
            // 
            this.userButton4.BackColor = System.Drawing.Color.Transparent;
            this.userButton4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userButton4.CustomerInformation = "";
            this.userButton4.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton4.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.userButton4.Location = new System.Drawing.Point(188, 428);
            this.userButton4.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.userButton4.Name = "userButton4";
            this.userButton4.Size = new System.Drawing.Size(124, 39);
            this.userButton4.TabIndex = 18;
            this.userButton4.UIText = "设置下载目录";
            this.userButton4.Click += new System.EventHandler(this.userButton4_Click);
            // 
            // userButton3
            // 
            this.userButton3.BackColor = System.Drawing.Color.Transparent;
            this.userButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userButton3.CustomerInformation = "";
            this.userButton3.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton3.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.userButton3.Location = new System.Drawing.Point(88, 428);
            this.userButton3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton3.Name = "userButton3";
            this.userButton3.Size = new System.Drawing.Size(60, 39);
            this.userButton3.TabIndex = 17;
            this.userButton3.UIText = "合成";
            this.userButton3.Click += new System.EventHandler(this.userButton3_Click_1);
            // 
            // userButton2
            // 
            this.userButton2.BackColor = System.Drawing.Color.Transparent;
            this.userButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.userButton2.CustomerInformation = "";
            this.userButton2.EnableColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.userButton2.Font = new System.Drawing.Font("微软雅黑", 12.75F);
            this.userButton2.Location = new System.Drawing.Point(22, 428);
            this.userButton2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.userButton2.Name = "userButton2";
            this.userButton2.Size = new System.Drawing.Size(60, 39);
            this.userButton2.TabIndex = 16;
            this.userButton2.UIText = "下载";
            this.userButton2.Click += new System.EventHandler(this.userButton2_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 481);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(570, 70);
            this.textBox1.TabIndex = 15;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.linkLabel3);
            this.panel3.Controls.Add(this.pictureBox2);
            this.panel3.Controls.Add(this.UrlStateBox);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.InputUrlTextBox);
            this.panel3.Location = new System.Drawing.Point(22, 105);
            this.panel3.Margin = new System.Windows.Forms.Padding(2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(570, 70);
            this.panel3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "全景图下载链接";
            // 
            // InputUrlTextBox
            // 
            this.InputUrlTextBox.Location = new System.Drawing.Point(6, 26);
            this.InputUrlTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.InputUrlTextBox.Name = "InputUrlTextBox";
            this.InputUrlTextBox.Size = new System.Drawing.Size(470, 21);
            this.InputUrlTextBox.TabIndex = 3;
            this.InputUrlTextBox.TextChanged += new System.EventHandler(this.InputUrlTextBox_TextChanged_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(139, 6);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(53, 12);
            this.linkLabel3.TabIndex = 21;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "使用说明";
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Font = new System.Drawing.Font("楷体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listView1.Location = new System.Drawing.Point(22, 189);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.OwnerDraw = true;
            this.listView1.ProgressColumnIndex = -1;
            this.listView1.Size = new System.Drawing.Size(570, 223);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图片名称";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "合成进度";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "合成完成";
            this.columnHeader3.Width = 200;
            // 
            // Main
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 670);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "全景图下载器";
            this.toolTip1.SetToolTip(this, "你知道的太多了");
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UrlStateBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }




        #endregion
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InputUrlTextBox;
        private System.Windows.Forms.ProgressListview listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PictureBox UrlStateBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
        private HslCommunication.Controls.UserButton userButton1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private HslCommunication.Controls.UserButton userButton2;
        private HslCommunication.Controls.UserButton userButton3;
        private HslCommunication.Controls.UserButton userButton4;
        private HslCommunication.Controls.UserButton userButton5;
        private HslCommunication.Controls.UserButton userButton6;
        private System.Windows.Forms.LinkLabel linkLabel3;
    }
}

