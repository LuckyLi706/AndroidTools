using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            tb_apk_path.Text = Path.desktop_path;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(Path.app_path + "android_adb.zip")) {
               System.IO.Compression.ZipFile.ExtractToDirectory(Path.app_path+"android_adb.zip", Path.app_path+"android_adb");
               File.Delete(Path.app_path+"android_adb.zip");
            }
        }

        //第一个选项卡adb命令
        //获取包名
        private void btn_packagename_Click(object sender, EventArgs e)
        {
            string value = Command.getPhoneInfo(tb_info,Path.adb_path, "shell dumpsys activity");
            string[] values = value.Split('\n');
            for (int i = 0; i < values.Length; i++) {
                if (values[i].Contains("mFocusedActivity")) {
                    int a = values[i].IndexOf("u0");
                    int b = values[i].IndexOf('/');
                    string packageName = values[i].Substring(a+3,b-a-3);
                    tb_packagename.Text = packageName;
                }
                if (values[i].Contains("error"))
                {
                    tb_info.Text = showInfo(values[i])+ "\r\n";
                    return;
                }
            }
        }

        //获取顶级Activity
        private void btn_topactivity_Click(object sender, EventArgs e)
        {
            string value = Command.getPhoneInfo(tb_info,Path.adb_path, "shell dumpsys activity");
            string[] values = value.Split('\n');
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains("mFocusedActivity"))
                {
                    tb_info.Text = showInfo(values[i].TrimStart()) + "\r\n";
                    return ;
                }
                if (values[i].Contains("error")) {
                    tb_info.Text = showInfo(values[i]) + "\r\n";
                    return;
                }
            }
        }

        //安装应用
        private void btn_install_apk_Click(object sender, EventArgs e)
        {

            if (tb_apk_name.Text == null || tb_apk_name.Text.Equals(""))
            {
                MessageBox.Show("请输入apk名字");
                return;
            }
            if (tb_apk_path.Text == null || tb_apk_path.Text.Equals(""))
            {
                MessageBox.Show("apk路径不能为空");
                return;
            }
            else {
                tb_apk_path.Text = Path.desktop_path;
                string value = Command.getPhoneInfo(tb_info, Path.adb_path, "install "+tb_apk_name.Text+".apk",Path.desktop_path);
                tb_info.AppendText(showInfo("安装路径:"+Path.desktop_path) + "\r\n");
                tb_info.AppendText("\r\n");
                tb_info.AppendText(showInfo(value) + "\r\n");
            }
        }

        //卸载应用
        private void btn_unstall_apk_Click(object sender, EventArgs e)
        {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else {
                string value = Command.getPhoneInfo(tb_info, Path.adb_path, "uninstall " + tb_packagename.Text);
                tb_info.AppendText(showInfo(value) + "\r\n");
            }
        }

        //清除数据
        private void btn_clear_data_Click(object sender, EventArgs e)
        {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else
            {
                string value = Command.getPhoneInfo(tb_info, Path.adb_path, "shell pm clear " + tb_packagename.Text);
                tb_info.AppendText(showInfo(value) + "\r\n");
            }
        }

        //截屏
        private void btn_screen_shot_Click(object sender, EventArgs e)
        {
            string value = Command.getPhoneInfo(tb_info, Path.adb_path, "shell /system/bin/screencap -p /sdcard/screenshot.png");
            tb_info.AppendText(showInfo(value) + "\r\n");
            tb_info.AppendText("\r\n");
            string value1 = Command.getPhoneInfo(tb_info, Path.adb_path, "pull /sdcard/screenshot.png "+ Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
            tb_info.AppendText(showInfo(value1) + "\r\n");
        }

        //重启手机
        private void btn_restart_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info, Path.adb_path, "reboot");
            Thread thread = new Thread(command.startTask);
            thread.Start();
         }

        //重启到fastboot模式
        private void btn_start_fastboot_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info, Path.adb_path, "reboot bootloader");
            Thread thread = new Thread(command.startTask);
            thread.Start();
        }

        private string showInfo(string info) {
            return ">>>> " + info;
        }


        //第三个反编译选项卡
        //apktool来反编译apk
        private void btn_apktool_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(startThread));
            thread.Start();
            //MessageBox.Show(value);
        }

        public void startThread() {
            //Command.getInfoByCommand(tb_info_3, Path.apktool_path, " d " + tb_apk_name_3.Text + ".apk -o" + Path.app_path + "/work/"+tb_apk_name_3.Text);
            Command.getInfoByCommand(tb_info_3, Path.enjarify_path, "1.apk");
        }

        private void btn_enjarify_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(new ThreadStart(startThread));
            thread.Start();
        }
        //选项卡切换事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                string value=File.ReadAllText(Path.app_path + "introduce.txt");
                tb_info_3.Text = value;
            }
        }

        
    }
}
