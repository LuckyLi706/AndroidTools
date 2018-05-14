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
            string value = Command.getPhoneInfo(tb_info, Path.adb_path, "devices");
            string[] values = value.Split('\n');
            cb_devices.Items.Clear();
            for (int i = 1; i < values.Length; i++)
            {
                if (values[i].Contains("device"))
                {
                    value = values[i].Replace("device", "").Replace(" ", "").Trim();
                    cb_devices.Items.Add(value);
                }
            }
            cb_devices.SelectedIndex = 0;
        }

        //获取包名
        private void btn_packagename_Click(object sender, EventArgs e)
        {
            int validate_Device = isDevices();
            string value = "";
            if (validate_Device == 1)
            {
                value = Command.getPhoneInfo(tb_info, Path.adb_path, "shell dumpsys activity");
            }
            if (validate_Device == 2) {
                value = Command.getPhoneInfo(tb_info, Path.adb_path, "-s "+cb_devices.Text+" shell dumpsys activity");
            }
            if (validate_Device == 3) {
                MessageBox.Show("请获取设备名");
                return;
            }
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
            int validate_Device = isDevices();
            string value = "";
            if (validate_Device == 1)
            {
                value = Command.getPhoneInfo(tb_info, Path.adb_path, "shell dumpsys activity");

            }
            if (validate_Device == 2)
            {
                value = Command.getPhoneInfo(tb_info, Path.adb_path, "-s " + cb_devices.Text + " shell dumpsys activity");
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
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
            openFileDialog1.InitialDirectory = Path.desktop_path;            // 这里是初始的路径名
            openFileDialog1.Filter = "apk|*.apk|所有文件|*.*";  //设置打开文件的类型
            openFileDialog1.RestoreDirectory = true;              //设置是否还原当前目录
            openFileDialog1.FilterIndex = 0;                      //设置打开文件类型的索引
            string path = "";                                     //用于保存打开文件的路径
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                if (!path.Substring(path.Length - 3).Equals("apk"))
                {
                    MessageBox.Show("请选择apk文件");
                    return;
                }
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel) {
                MessageBox.Show("什么也没选择");
                return;
            }
            int validate_Device = isDevices();
            if (validate_Device == 1)
            {
                CommandThread command = new CommandThread(tb_info, Path.adb_path, "install " + path);
                Thread thread = new Thread(command.startTask);
                thread.Start();

            }
            if (validate_Device == 2)
            {
                CommandThread command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text+" install " + path);
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
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

        private void btn_dex2jar_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info_3, Path.dex2jar_path, tb_dex2jar.Text+".jar");
            Thread thread = new Thread(command.startTask);
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

        private void cbox_devices_CheckedChanged(object sender, EventArgs e)
        {
            if (cbox_devices.Checked)
            {
                btn_getdevice.Enabled = true;
                cb_devices.Enabled = true;
            }
            else {
                btn_getdevice.Enabled = false;
                cb_devices.Enabled = false;
                cb_devices.Items.Clear();
            }
        }

        private int isDevices() {
            if (!cbox_devices.Checked) {
                return 1;
            }
            else if ((cbox_devices.Checked && !cb_devices.Text.Equals(""))) {
                 return 2;
            }
            return 3;
        }
    }
}
