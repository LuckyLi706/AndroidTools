using AndroidSmallTools.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android.dialog
{
    public partial class PathDialog : Form
    {
        public PathDialog()
        {
            InitializeComponent();
            tb_path.Text = PathUtil.adb_path;
        }

        private void btn_path_choose_Click(object sender, EventArgs e)
        {
            OpenFileDialog filename = new OpenFileDialog(); //定义打开文件
            filename.InitialDirectory = AndroidSmallTools.utils.FileUtil.DESKTOP_DIR; //初始路径,这里设置的是程序的起始位置，可自由设置
            filename.Filter = "All files(*.*)|*.*|apk file(*.exe)|*.exe";//设置打开类型,设置个*.*和*.txt就行了
            filename.FilterIndex = 2;                  //文件类型的显示顺序（上一行.txt设为第二位）
            filename.RestoreDirectory = true; //对话框记忆之前打开的目录
            if (filename.ShowDialog() == DialogResult.OK)
            {
                String path = System.IO.Path.GetFullPath(filename.FileName);
                tb_path.Text= path;
            }
        }

        private void btn_path_confirm_Click(object sender, EventArgs e)
        {
            FileUtil.writeFile(FileUtil.CURRENT_DIR+"/path.txt", tb_path.Text);
            PathUtil.adb_path = tb_path.Text;
            Close();
        }
    }
}
