namespace Android.dialog
{
    partial class PathDialog
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
            this.tb_path = new System.Windows.Forms.TextBox();
            this.btn_path_choose = new System.Windows.Forms.Button();
            this.btn_path_confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_path
            // 
            this.tb_path.Enabled = false;
            this.tb_path.Location = new System.Drawing.Point(12, 35);
            this.tb_path.Name = "tb_path";
            this.tb_path.Size = new System.Drawing.Size(301, 21);
            this.tb_path.TabIndex = 0;
            // 
            // btn_path_choose
            // 
            this.btn_path_choose.Location = new System.Drawing.Point(81, 77);
            this.btn_path_choose.Name = "btn_path_choose";
            this.btn_path_choose.Size = new System.Drawing.Size(48, 23);
            this.btn_path_choose.TabIndex = 1;
            this.btn_path_choose.Text = "选择";
            this.btn_path_choose.UseVisualStyleBackColor = true;
            this.btn_path_choose.Click += new System.EventHandler(this.btn_path_choose_Click);
            // 
            // btn_path_confirm
            // 
            this.btn_path_confirm.Location = new System.Drawing.Point(200, 77);
            this.btn_path_confirm.Name = "btn_path_confirm";
            this.btn_path_confirm.Size = new System.Drawing.Size(49, 23);
            this.btn_path_confirm.TabIndex = 2;
            this.btn_path_confirm.Text = "确定";
            this.btn_path_confirm.UseVisualStyleBackColor = true;
            this.btn_path_confirm.Click += new System.EventHandler(this.btn_path_confirm_Click);
            // 
            // PathDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 112);
            this.ControlBox = false;
            this.Controls.Add(this.btn_path_confirm);
            this.Controls.Add(this.btn_path_choose);
            this.Controls.Add(this.tb_path);
            this.Name = "PathDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "路径设置";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_path;
        private System.Windows.Forms.Button btn_path_choose;
        private System.Windows.Forms.Button btn_path_confirm;
    }
}