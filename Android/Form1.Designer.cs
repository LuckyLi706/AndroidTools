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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_search_path = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_file = new System.Windows.Forms.ComboBox();
            this.tb_pull_path = new System.Windows.Forms.TextBox();
            this.btn_pull = new System.Windows.Forms.Button();
            this.tb_path = new System.Windows.Forms.TextBox();
            this.cb_path = new System.Windows.Forms.CheckBox();
            this.cb_root = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_push = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbox_devices = new System.Windows.Forms.CheckBox();
            this.cb_devices = new System.Windows.Forms.ComboBox();
            this.btn_getdevice = new System.Windows.Forms.Button();
            this.btn_packagename = new System.Windows.Forms.Button();
            this.btn_start_fastboot = new System.Windows.Forms.Button();
            this.tb_packagename = new System.Windows.Forms.TextBox();
            this.btn_restart = new System.Windows.Forms.Button();
            this.btn_topactivity = new System.Windows.Forms.Button();
            this.btn_screen_shot = new System.Windows.Forms.Button();
            this.btn_install_apk = new System.Windows.Forms.Button();
            this.btn_clear_data = new System.Windows.Forms.Button();
            this.btn_unstall_apk = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tb_info = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.其他功能ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cl_screen = new System.Windows.Forms.ToolStripMenuItem();
            this.opencmd = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(471, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(319, 437);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(311, 411);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "ADB命令";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Location = new System.Drawing.Point(6, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 398);
            this.panel2.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btn_search_path);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cb_file);
            this.groupBox3.Controls.Add(this.tb_pull_path);
            this.groupBox3.Controls.Add(this.btn_pull);
            this.groupBox3.Controls.Add(this.tb_path);
            this.groupBox3.Controls.Add(this.cb_path);
            this.groupBox3.Controls.Add(this.cb_root);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btn_push);
            this.groupBox3.Location = new System.Drawing.Point(7, 178);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(283, 184);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "pull和push";
            // 
            // btn_search_path
            // 
            this.btn_search_path.Location = new System.Drawing.Point(89, 101);
            this.btn_search_path.Name = "btn_search_path";
            this.btn_search_path.Size = new System.Drawing.Size(180, 23);
            this.btn_search_path.TabIndex = 10;
            this.btn_search_path.Text = "搜索该手机路径的文件";
            this.btn_search_path.UseVisualStyleBackColor = true;
            this.btn_search_path.Click += new System.EventHandler(this.btn_search_path_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 14);
            this.label3.TabIndex = 9;
            this.label3.Text = "文件：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(4, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 14);
            this.label2.TabIndex = 8;
            this.label2.Text = "手机路径：";
            // 
            // cb_file
            // 
            this.cb_file.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_file.FormattingEnabled = true;
            this.cb_file.Location = new System.Drawing.Point(82, 158);
            this.cb_file.Name = "cb_file";
            this.cb_file.Size = new System.Drawing.Size(195, 20);
            this.cb_file.TabIndex = 7;
            // 
            // tb_pull_path
            // 
            this.tb_pull_path.Location = new System.Drawing.Point(82, 131);
            this.tb_pull_path.Name = "tb_pull_path";
            this.tb_pull_path.Size = new System.Drawing.Size(195, 21);
            this.tb_pull_path.TabIndex = 6;
            // 
            // btn_pull
            // 
            this.btn_pull.Location = new System.Drawing.Point(7, 101);
            this.btn_pull.Name = "btn_pull";
            this.btn_pull.Size = new System.Drawing.Size(75, 23);
            this.btn_pull.TabIndex = 5;
            this.btn_pull.Text = "pull";
            this.btn_pull.UseVisualStyleBackColor = true;
            this.btn_pull.Click += new System.EventHandler(this.btn_pull_Click);
            // 
            // tb_path
            // 
            this.tb_path.Enabled = false;
            this.tb_path.Location = new System.Drawing.Point(90, 72);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(179, 21);
            this.tb_path.TabIndex = 4;
            // 
            // cb_path
            // 
            this.cb_path.AutoSize = true;
            this.cb_path.Location = new System.Drawing.Point(6, 78);
            this.cb_path.Name = "cb_path";
            this.cb_path.Size = new System.Drawing.Size(84, 16);
            this.cb_path.TabIndex = 3;
            this.cb_path.Text = "自定义路径";
            this.cb_path.UseVisualStyleBackColor = true;
            this.cb_path.CheckedChanged += new System.EventHandler(this.cb_path_CheckedChanged);
            // 
            // cb_root
            // 
            this.cb_root.AutoSize = true;
            this.cb_root.Location = new System.Drawing.Point(6, 22);
            this.cb_root.Name = "cb_root";
            this.cb_root.Size = new System.Drawing.Size(192, 16);
            this.cb_root.TabIndex = 2;
            this.cb_root.Text = "开启root（需要手机已经root）";
            this.cb_root.UseVisualStyleBackColor = true;
            this.cb_root.CheckedChanged += new System.EventHandler(this.cb_root_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Red;
            this.label1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(87, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "默认路径：/data/local/tmp";
            // 
            // btn_push
            // 
            this.btn_push.Location = new System.Drawing.Point(6, 44);
            this.btn_push.Name = "btn_push";
            this.btn_push.Size = new System.Drawing.Size(75, 23);
            this.btn_push.TabIndex = 0;
            this.btn_push.Text = "push";
            this.btn_push.UseVisualStyleBackColor = true;
            this.btn_push.Click += new System.EventHandler(this.btn_push_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbox_devices);
            this.groupBox2.Controls.Add(this.cb_devices);
            this.groupBox2.Controls.Add(this.btn_getdevice);
            this.groupBox2.Controls.Add(this.btn_packagename);
            this.groupBox2.Controls.Add(this.btn_start_fastboot);
            this.groupBox2.Controls.Add(this.tb_packagename);
            this.groupBox2.Controls.Add(this.btn_restart);
            this.groupBox2.Controls.Add(this.btn_topactivity);
            this.groupBox2.Controls.Add(this.btn_screen_shot);
            this.groupBox2.Controls.Add(this.btn_install_apk);
            this.groupBox2.Controls.Add(this.btn_clear_data);
            this.groupBox2.Controls.Add(this.btn_unstall_apk);
            this.groupBox2.Location = new System.Drawing.Point(4, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(286, 168);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "基本命令";
            // 
            // cbox_devices
            // 
            this.cbox_devices.AutoSize = true;
            this.cbox_devices.Location = new System.Drawing.Point(212, 19);
            this.cbox_devices.Name = "cbox_devices";
            this.cbox_devices.Size = new System.Drawing.Size(60, 16);
            this.cbox_devices.TabIndex = 15;
            this.cbox_devices.Text = "多设备";
            this.cbox_devices.UseVisualStyleBackColor = true;
            this.cbox_devices.CheckedChanged += new System.EventHandler(this.cbox_devices_CheckedChanged);
            // 
            // cb_devices
            // 
            this.cb_devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_devices.Enabled = false;
            this.cb_devices.FormattingEnabled = true;
            this.cb_devices.Location = new System.Drawing.Point(80, 17);
            this.cb_devices.Name = "cb_devices";
            this.cb_devices.Size = new System.Drawing.Size(121, 20);
            this.cb_devices.TabIndex = 14;
            // 
            // btn_getdevice
            // 
            this.btn_getdevice.Enabled = false;
            this.btn_getdevice.Location = new System.Drawing.Point(2, 15);
            this.btn_getdevice.Name = "btn_getdevice";
            this.btn_getdevice.Size = new System.Drawing.Size(75, 25);
            this.btn_getdevice.TabIndex = 13;
            this.btn_getdevice.Text = "获取设备";
            this.btn_getdevice.UseVisualStyleBackColor = true;
            this.btn_getdevice.Click += new System.EventHandler(this.btn_getdevice_Click);
            // 
            // btn_packagename
            // 
            this.btn_packagename.Location = new System.Drawing.Point(2, 44);
            this.btn_packagename.Name = "btn_packagename";
            this.btn_packagename.Size = new System.Drawing.Size(75, 25);
            this.btn_packagename.TabIndex = 1;
            this.btn_packagename.Text = "获取包名";
            this.btn_packagename.UseVisualStyleBackColor = true;
            this.btn_packagename.Click += new System.EventHandler(this.btn_packagename_Click);
            // 
            // btn_start_fastboot
            // 
            this.btn_start_fastboot.Location = new System.Drawing.Point(85, 132);
            this.btn_start_fastboot.Name = "btn_start_fastboot";
            this.btn_start_fastboot.Size = new System.Drawing.Size(130, 25);
            this.btn_start_fastboot.TabIndex = 12;
            this.btn_start_fastboot.Text = "重启到fastboot模式";
            this.btn_start_fastboot.UseVisualStyleBackColor = true;
            this.btn_start_fastboot.Click += new System.EventHandler(this.btn_start_fastboot_Click);
            // 
            // tb_packagename
            // 
            this.tb_packagename.Location = new System.Drawing.Point(80, 46);
            this.tb_packagename.Name = "tb_packagename";
            this.tb_packagename.Size = new System.Drawing.Size(200, 21);
            this.tb_packagename.TabIndex = 2;
            this.tb_packagename.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_restart
            // 
            this.btn_restart.Location = new System.Drawing.Point(3, 133);
            this.btn_restart.Name = "btn_restart";
            this.btn_restart.Size = new System.Drawing.Size(73, 25);
            this.btn_restart.TabIndex = 11;
            this.btn_restart.Text = "重启手机";
            this.btn_restart.UseVisualStyleBackColor = true;
            this.btn_restart.Click += new System.EventHandler(this.btn_restart_Click);
            // 
            // btn_topactivity
            // 
            this.btn_topactivity.Location = new System.Drawing.Point(3, 74);
            this.btn_topactivity.Name = "btn_topactivity";
            this.btn_topactivity.Size = new System.Drawing.Size(139, 25);
            this.btn_topactivity.TabIndex = 3;
            this.btn_topactivity.Text = "获取顶级activity";
            this.btn_topactivity.UseVisualStyleBackColor = true;
            this.btn_topactivity.Click += new System.EventHandler(this.btn_topactivity_Click);
            // 
            // btn_screen_shot
            // 
            this.btn_screen_shot.Location = new System.Drawing.Point(167, 103);
            this.btn_screen_shot.Name = "btn_screen_shot";
            this.btn_screen_shot.Size = new System.Drawing.Size(105, 25);
            this.btn_screen_shot.TabIndex = 10;
            this.btn_screen_shot.Text = "截屏";
            this.btn_screen_shot.UseVisualStyleBackColor = true;
            this.btn_screen_shot.Click += new System.EventHandler(this.btn_screen_shot_Click);
            // 
            // btn_install_apk
            // 
            this.btn_install_apk.Location = new System.Drawing.Point(148, 74);
            this.btn_install_apk.Name = "btn_install_apk";
            this.btn_install_apk.Size = new System.Drawing.Size(132, 25);
            this.btn_install_apk.TabIndex = 4;
            this.btn_install_apk.Text = "安装apk";
            this.btn_install_apk.UseVisualStyleBackColor = true;
            this.btn_install_apk.Click += new System.EventHandler(this.btn_install_apk_Click);
            // 
            // btn_clear_data
            // 
            this.btn_clear_data.Location = new System.Drawing.Point(85, 103);
            this.btn_clear_data.Name = "btn_clear_data";
            this.btn_clear_data.Size = new System.Drawing.Size(73, 25);
            this.btn_clear_data.TabIndex = 9;
            this.btn_clear_data.Text = "清除数据";
            this.btn_clear_data.UseVisualStyleBackColor = true;
            this.btn_clear_data.Click += new System.EventHandler(this.btn_clear_data_Click);
            // 
            // btn_unstall_apk
            // 
            this.btn_unstall_apk.Location = new System.Drawing.Point(3, 103);
            this.btn_unstall_apk.Name = "btn_unstall_apk";
            this.btn_unstall_apk.Size = new System.Drawing.Size(73, 25);
            this.btn_unstall_apk.TabIndex = 8;
            this.btn_unstall_apk.Text = "卸载apk";
            this.btn_unstall_apk.UseVisualStyleBackColor = true;
            this.btn_unstall_apk.Click += new System.EventHandler(this.btn_unstall_apk_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 411);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "其他命令";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tb_info
            // 
            this.tb_info.BackColor = System.Drawing.SystemColors.InfoText;
            this.tb_info.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_info.ForeColor = System.Drawing.SystemColors.Info;
            this.tb_info.Location = new System.Drawing.Point(2, 34);
            this.tb_info.Multiline = true;
            this.tb_info.Name = "tb_info";
            this.tb_info.ReadOnly = true;
            this.tb_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_info.Size = new System.Drawing.Size(467, 411);
            this.tb_info.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.其他功能ToolStripMenuItem,
            this.help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(789, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 其他功能ToolStripMenuItem
            // 
            this.其他功能ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cl_screen,
            this.opencmd});
            this.其他功能ToolStripMenuItem.Name = "其他功能ToolStripMenuItem";
            this.其他功能ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.其他功能ToolStripMenuItem.Text = "其他功能";
            // 
            // cl_screen
            // 
            this.cl_screen.Name = "cl_screen";
            this.cl_screen.Size = new System.Drawing.Size(125, 22);
            this.cl_screen.Text = "清屏";
            this.cl_screen.Click += new System.EventHandler(this.cl_screen_Click);
            // 
            // opencmd
            // 
            this.opencmd.Name = "opencmd";
            this.opencmd.Size = new System.Drawing.Size(125, 22);
            this.opencmd.Text = "打开cmd";
            this.opencmd.Click += new System.EventHandler(this.opencmd_Click);
            // 
            // help
            // 
            this.help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于ToolStripMenuItem});
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(44, 21);
            this.help.Text = "帮助";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(311, 411);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "smail";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 461);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tb_info);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button btn_install_apk;
        private System.Windows.Forms.Button btn_unstall_apk;
        private System.Windows.Forms.Button btn_clear_data;
        private System.Windows.Forms.Button btn_screen_shot;
        private System.Windows.Forms.Button btn_restart;
        private System.Windows.Forms.Button btn_start_fastboot;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cb_devices;
        private System.Windows.Forms.Button btn_getdevice;
        private System.Windows.Forms.CheckBox cbox_devices;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_push;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 其他功能ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cl_screen;
        private System.Windows.Forms.ToolStripMenuItem opencmd;
        private System.Windows.Forms.ToolStripMenuItem help;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.CheckBox cb_root;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.CheckBox cb_path;
        private System.Windows.Forms.TextBox tb_pull_path;
        private System.Windows.Forms.Button btn_pull;
        private System.Windows.Forms.ComboBox cb_file;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_search_path;
        private System.Windows.Forms.TabPage tabPage3;
    }
}

