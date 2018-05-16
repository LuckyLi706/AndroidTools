using Android.adb;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            if (File.Exists(Path.app_path + "android_adb.zip")) {
               System.IO.Compression.ZipFile.ExtractToDirectory(Path.app_path+"android_adb.zip", Path.app_path+"android_adb");
               File.Delete(Path.app_path+"android_adb.zip");
            }
        }

        //第一个选项卡adb命令

        //获取所有设备名
        private void btn_getdevice_Click(object sender, EventArgs e)
        {
            Command.getDevices(tb_info,cb_devices);
        }

        //获取包名
        private void btn_packagename_Click(object sender, EventArgs e)
        {
            Command.getPackageName(isDevices(), tb_info, cb_devices, tb_packagename);
        }

        //获取顶级Activity
        private void btn_topactivity_Click(object sender, EventArgs e)
        {
            Command.getTopActivity(isDevices(), tb_info, cb_devices);
        }

        //安装应用
        private void btn_install_apk_Click(object sender, EventArgs e)
        {
            Command.install_Apk(isDevices(),tb_info,cb_devices);
        }

        //卸载应用
        private void btn_unstall_apk_Click(object sender, EventArgs e)
        {
            Command.unstallApk(isDevices(), tb_packagename, tb_info, cb_devices);
        }

        //清除数据
        private void btn_clear_data_Click(object sender, EventArgs e)
        {
            Command.clearData(isDevices(), tb_packagename, tb_info, cb_devices);
        }

        //截屏
        private void btn_screen_shot_Click(object sender, EventArgs e)
        {
            Command.shotScreen(isDevices(), tb_packagename, tb_info, cb_devices);
        }

        //push信息
        private void btn_push_Click(object sender, EventArgs e)
        {
            if (cb_path.Checked) {
                if (tb_path.Text == null || tb_path.Text.Equals(""))
                {
                    MessageBox.Show("请输入路径");
                    return;
                }
                else {
                    Command.push(isDevices(), tb_info, cb_devices,tb_path.Text);
                    return;
                }
            }
            Command.push(isDevices(), tb_info, cb_devices);
        }

        //pull信息
        private void btn_pull_Click(object sender, EventArgs e)
        {
            if (tb_pull_path.Text == null || tb_pull_path.Text.Equals(""))
            {
                MessageBox.Show("请输入手机路径");
            }
            else {
                if ((cb_file.Text == null || cb_file.Text.Equals("")))
                {
                    MessageBox.Show("请选择文件");
                    Command.getAllFile(isDevices(), tb_pull_path.Text, cb_file, tb_info);
                }
                else {
                    Command.pull(isDevices(), tb_info, cb_devices, tb_pull_path.Text + '/' + cb_file.Text+" ");
                }

            }
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

        //选中多设备时，要先获取设备
        private void cbox_devices_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_devices.Checked)
            {
                btn_getdevice.Enabled = true;
                cb_devices.Enabled = true;
            }
            else
            {
                btn_getdevice.Enabled = false;
                cb_devices.Enabled = false;
                cb_devices.Items.Clear();
            }
        }

        //判断当前当前是多个设备还是单一设备
        private int isDevices()
        {
            if (!cbox_devices.Checked)
            {
                return 1;
            }
            else if ((cbox_devices.Checked && !cb_devices.Text.Equals("")))
            {
                return 2;
            }
            return 3;
        }

        //第三个反编译选项卡
        //apktool来反编译apk
        

        

        //选项卡切换事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                string value=File.ReadAllText(Path.app_path + "introduce.txt");
                //tb_info_3.Text = value;
            }
        }

        //清屏功能
        private void cl_screen_Click(object sender, EventArgs e)
        {
            tb_info.Text="";
        }

        private void opencmd_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = Path.desktop_path;
            p.Start();


        }

        private void cb_root_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_root.Checked) {
                Command.root();
            }
        }

        private void cb_path_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_path.Checked)
            {
                tb_path.Enabled = true;
            }
            else {
                tb_path.Enabled = false;
            }
        }

        private void tb_pull_path_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
