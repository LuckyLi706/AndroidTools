namespace Android
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_start_fastboot = new System.Windows.Forms.Button();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_screen_shot = new System.Windows.Forms.Button();
            this.btn_clear_data = new System.Windows.Forms.Button();
            this.btn_unstall_apk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_apk_path = new System.Windows.Forms.TextBox();
            this.tb_apk_name = new System.Windows.Forms.TextBox();
            this.btn_install_apk = new System.Windows.Forms.Button();
            this.btn_topactivity = new System.Windows.Forms.Button();
            this.btn_packagename = new System.Windows.Forms.Button();
            this.tb_packagename = new System.Windows.Forms.TextBox();
            this.tb_info = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_apk_name_3 = new System.Windows.Forms.TextBox();
            this.btn_apktool = new System.Windows.Forms.Button();
            this.tb_info_3 = new System.Windows.Forms.TextBox();
            this.btn_enjarify = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(13, 13);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(734, 436);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.tb_info);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(726, 410);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ADB命令";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btn_start_fastboot);
            this.panel2.Controls.Add(this.btn_restart);
            this.panel2.Controls.Add(this.btn_screen_shot);
            this.panel2.Controls.Add(this.btn_clear_data);
            this.panel2.Controls.Add(this.btn_unstall_apk);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.tb_apk_path);
            this.panel2.Controls.Add(this.tb_apk_name);
            this.panel2.Controls.Add(this.btn_install_apk);
            this.panel2.Controls.Add(this.btn_topactivity);
            this.panel2.Controls.Add(this.btn_packagename);
            this.panel2.Controls.Add(this.tb_packagename);
            this.panel2.Location = new System.Drawing.Point(456, 6);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(264, 398);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(4, 181);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(257, 214);
            this.panel3.TabIndex = 13;
            // 
            // btn_start_fastboot
            // 
            this.btn_start_fastboot.Location = new System.Drawing.Point(86, 150);
            this.btn_start_fastboot.Name = "btn_start_fastboot";
            this.btn_start_fastboot.Size = new System.Drawing.Size(132, 23);
            this.btn_start_fastboot.TabIndex = 12;
            this.btn_start_fastboot.Text = "重启到fastboot模式";
            this.btn_start_fastboot.UseVisualStyleBackColor = true;
            this.btn_start_fastboot.Click += new System.EventHandler(this.btn_start_fastboot_Click);
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(4, 151);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(75, 23);
            this.btn_restart.TabIndex = 11;
            this.btn_restart.Text = "重启手机";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_screen_shot
            // 
            this.btn_screen_shot.Location = new System.Drawing.Point(168, 121);
            this.btn_screen_shot.Name = "btn_screen_shot";
            this.btn_screen_shot.Size = new System.Drawing.Size(75, 23);
            this.btn_screen_shot.TabIndex = 10;
            this.btn_screen_shot.Text = "截屏";
            this.btn_screen_shot.UseVisualStyleBackColor = true;
            this.btn_screen_shot.Click += new System.EventHandler(this.btn_screen_shot_Click);
            // 
            // btn_clear_data
            // 
            this.btn_clear_data.Location = new System.Drawing.Point(86, 121);
            this.btn_clear_data.Name = "btn_clear_data";
            this.btn_clear_data.Size = new System.Drawing.Size(75, 23);
            this.btn_clear_data.TabIndex = 9;
            this.btn_clear_data.Text = "清除数据";
            this.btn_clear_data.UseVisualStyleBackColor = true;
            this.btn_clear_data.Click += new System.EventHandler(this.btn_clear_data_Click);
            // 
            // btn_unstall_apk
            // 
            this.btn_unstall_apk.Location = new System.Drawing.Point(4, 121);
            this.btn_unstall_apk.Name = "btn_unstall_apk";
            this.btn_unstall_apk.Size = new System.Drawing.Size(75, 23);
            this.btn_unstall_apk.TabIndex = 8;
            this.btn_unstall_apk.Text = "卸载apk";
            this.btn_unstall_apk.UseVisualStyleBackColor = true;
            this.btn_unstall_apk.Click += new System.EventHandler(this.btn_unstall_apk_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.label1.Location = new System.Drawing.Point(217, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = ".apk";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tb_apk_path
            // 
            this.tb_apk_path.Location = new System.Drawing.Point(4, 93);
            this.tb_apk_path.Name = "tb_apk_path";
            this.tb_apk_path.Size = new System.Drawing.Size(257, 21);
            this.tb_apk_path.TabIndex = 6;
            this.tb_apk_path.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_apk_name
            // 
            this.tb_apk_name.Location = new System.Drawing.Point(81, 63);
            this.tb_apk_name.Name = "tb_apk_name";
            this.tb_apk_name.Size = new System.Drawing.Size(137, 21);
            this.tb_apk_name.TabIndex = 5;
            this.tb_apk_name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_install_apk
            // 
            this.btn_install_apk.Location = new System.Drawing.Point(4, 63);
            this.btn_install_apk.Name = "btn_install_apk";
            this.btn_install_apk.Size = new System.Drawing.Size(75, 23);
            this.btn_install_apk.TabIndex = 4;
            this.btn_install_apk.Text = "安装apk";
            this.btn_install_apk.UseVisualStyleBackColor = true;
            this.btn_install_apk.Click += new System.EventHandler(this.btn_install_apk_Click);
            // 
            // btn_topactivity
            // 
            this.btn_topactivity.Location = new System.Drawing.Point(4, 33);
            this.btn_topactivity.Name = "btn_topactivity";
            this.btn_topactivity.Size = new System.Drawing.Size(139, 23);
            this.btn_topactivity.TabIndex = 3;
            this.btn_topactivity.Text = "获取顶级activity";
            this.btn_topactivity.UseVisualStyleBackColor = true;
            this.btn_topactivity.Click += new System.EventHandler(this.btn_topactivity_Click);
            // 
            // btn_packagename
            // 
            this.btn_packagename.Location = new System.Drawing.Point(3, 3);
            this.btn_packagename.Name = "btn_packagename";
            this.btn_packagename.Size = new System.Drawing.Size(75, 23);
            this.btn_packagename.TabIndex = 1;
            this.btn_packagename.Text = "获取包名";
            this.btn_packagename.UseVisualStyleBackColor = true;
            this.btn_packagename.Click += new System.EventHandler(this.btn_packagename_Click);
            // 
            // tb_packagename
            // 
            this.tb_packagename.Location = new System.Drawing.Point(81, 5);
            this.tb_packagename.Name = "tb_packagename";
            this.tb_packagename.Size = new System.Drawing.Size(180, 21);
            this.tb_packagename.TabIndex = 2;
            this.tb_packagename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_info
            // 
            this.tb_info.BackColor = System.Drawing.SystemColors.InfoText;
            this.tb_info.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_info.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_info.Location = new System.Drawing.Point(7, 6);
            this.tb_info.Multiline = true;
            this.tb_info.Name = "tb_info";
            this.tb_info.ReadOnly = true;
            this.tb_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_info.Size = new System.Drawing.Size(442, 398);
            this.tb_info.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(726, 410);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他命令";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btn_enjarify);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.tb_apk_name_3);
            this.tabPage3.Controls.Add(this.btn_apktool);
            this.tabPage3.Controls.Add(this.tb_info_3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(726, 410);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "反编译";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(673, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = ".apk";
            // 
            // tb_apk_name_3
            // 
            this.tb_apk_name_3.Location = new System.Drawing.Point(575, 5);
            this.tb_apk_name_3.Name = "tb_apk_name_3";
            this.tb_apk_name_3.Size = new System.Drawing.Size(100, 21);
            this.tb_apk_name_3.TabIndex = 2;
            // 
            // btn_apktool
            // 
            this.btn_apktool.Location = new System.Drawing.Point(493, 5);
            this.btn_apktool.Name = "btn_apktool";
            this.btn_apktool.Size = new System.Drawing.Size(75, 23);
            this.btn_apktool.TabIndex = 1;
            this.btn_apktool.Text = "apktool";
            this.btn_apktool.UseVisualStyleBackColor = true;
            this.btn_apktool.Click += new System.EventHandler(this.btn_apktool_Click);
            // 
            // tb_info_3
            // 
            this.tb_info_3.BackColor = System.Drawing.SystemColors.InfoText;
            this.tb_info_3.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_info_3.ForeColor = System.Drawing.SystemColors.Window;
            this.tb_info_3.Location = new System.Drawing.Point(0, 4);
            this.tb_info_3.Multiline = true;
            this.tb_info_3.Name = "tb_info_3";
            this.tb_info_3.ReadOnly = true;
            this.tb_info_3.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_info_3.Size = new System.Drawing.Size(487, 403);
            this.tb_info_3.TabIndex = 0;
            // 
            // btn_enjarify
            // 
            this.btn_enjarify.Location = new System.Drawing.Point(494, 35);
            this.btn_enjarify.Name = "btn_enjarify";
            this.btn_enjarify.Size = new System.Drawing.Size(229, 23);
            this.btn_enjarify.TabIndex = 4;
            this.btn_enjarify.Text = "enjarify(需要python3)";
            this.btn_enjarify.UseVisualStyleBackColor = true;
            this.btn_enjarify.Click += new System.EventHandler(this.btn_enjarify_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 461);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_packagename;
        private System.Windows.Forms.TextBox tb_packagename;
        private System.Windows.Forms.TextBox tb_info;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btn_topactivity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_apk_path;
        private System.Windows.Forms.TextBox tb_apk_name;
        private System.Windows.Forms.Button btn_install_apk;
        private System.Windows.Forms.Button btn_unstall_apk;
        private System.Windows.Forms.Button btn_clear_data;
        private System.Windows.Forms.Button btn_screen_shot;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_start_fastboot;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_apk_name_3;
        private System.Windows.Forms.Button btn_apktool;
        private System.Windows.Forms.TextBox tb_info_3;
        private System.Windows.Forms.Button btn_enjarify;
    }
}

