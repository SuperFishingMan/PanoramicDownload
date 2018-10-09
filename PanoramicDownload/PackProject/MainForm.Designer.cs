namespace PackProject
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtProject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnChoose1 = new System.Windows.Forms.Button();
            this.btnChoose2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtZip = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnPack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProject
            // 
            this.txtProject.Location = new System.Drawing.Point(120, 56);
            this.txtProject.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProject.Name = "txtProject";
            this.txtProject.Size = new System.Drawing.Size(256, 25);
            this.txtProject.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 62);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "项目路径";
            // 
            // btnChoose1
            // 
            this.btnChoose1.Location = new System.Drawing.Point(380, 55);
            this.btnChoose1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoose1.Name = "btnChoose1";
            this.btnChoose1.Size = new System.Drawing.Size(100, 29);
            this.btnChoose1.TabIndex = 2;
            this.btnChoose1.Text = "选择 ..";
            this.btnChoose1.UseVisualStyleBackColor = true;
            this.btnChoose1.Click += new System.EventHandler(this.btnChoose1_Click);
            // 
            // btnChoose2
            // 
            this.btnChoose2.Location = new System.Drawing.Point(380, 132);
            this.btnChoose2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChoose2.Name = "btnChoose2";
            this.btnChoose2.Size = new System.Drawing.Size(100, 29);
            this.btnChoose2.TabIndex = 5;
            this.btnChoose2.Text = "选择 ..";
            this.btnChoose2.UseVisualStyleBackColor = true;
            this.btnChoose2.Click += new System.EventHandler(this.btnChoose2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 140);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "存储路径";
            // 
            // txtZip
            // 
            this.txtZip.Location = new System.Drawing.Point(120, 134);
            this.txtZip.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtZip.Name = "txtZip";
            this.txtZip.Size = new System.Drawing.Size(256, 25);
            this.txtZip.TabIndex = 3;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(120, 211);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(256, 25);
            this.txtVersion.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 218);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "版本号";
            // 
            // btnPack
            // 
            this.btnPack.Location = new System.Drawing.Point(380, 211);
            this.btnPack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPack.Name = "btnPack";
            this.btnPack.Size = new System.Drawing.Size(100, 29);
            this.btnPack.TabIndex = 8;
            this.btnPack.Text = "打包";
            this.btnPack.UseVisualStyleBackColor = true;
            this.btnPack.Click += new System.EventHandler(this.btnPack_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 318);
            this.Controls.Add(this.btnPack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.btnChoose2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtZip);
            this.Controls.Add(this.btnChoose1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "项目打包";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnChoose1;
        private System.Windows.Forms.Button btnChoose2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtZip;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnPack;
    }
}

