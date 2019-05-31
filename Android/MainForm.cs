using Android.adb;
using AndroidSmallTools.utils;
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
    public partial class MainForm : Form
    {
        
        public MainForm()
        {
            InitializeComponent();
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //解压adb工具
            if (!Directory.Exists(PathConstants.app_path + "android_adb")&&File.Exists(PathConstants.app_path + "android_adb.zip")) {
               System.IO.Compression.ZipFile.ExtractToDirectory(PathConstants.app_path+"android_adb.zip", PathConstants.app_path+"android_adb");
               //File.Delete(PathConstants.app_path+"android_adb.zip");
            }
            if (!Directory.Exists(PathConstants.app_path + "tools")&&File.Exists(PathConstants.app_path + "tools.zip"))
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(PathConstants.app_path + "tools.zip", PathConstants.app_path + "tools");
                //File.Delete(PathConstants.app_path + "tools.zip");
            }

            cb_emul.SelectedIndex = 0;
            cb_getinfo.SelectedIndex = 0;
            cb_getInfo2.SelectedIndex = 0;
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

        //push文件
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

        //pull文件
        private void btn_pull_Click(object sender, EventArgs e)
        {
            if (tb_pull_path.Text == null || tb_pull_path.Text.Equals(""))
            {
                MessageBox.Show("请输入手机路径");
            }
            else {
                if ((cb_file.Text == null || cb_file.Text.Equals("")))
                {
                    MessageBox.Show("先搜索该手机文件路径的所有文件");
                 }
                else {
                    Command.pull(isDevices(), tb_info, cb_devices, tb_pull_path.Text + '/' + cb_file.Text);
                }
            }
        }

        //用于给pull文件时搜索路径下的文件
        private void btn_search_path_Click(object sender, EventArgs e)
        {
            if (tb_pull_path.Text == null || tb_pull_path.Text.Equals(""))
            {
                MessageBox.Show("请输入手机路径");
            }
            else {
                Command.getAllFile(isDevices(), tb_pull_path.Text, cb_file, tb_info,cb_devices);
            }
        }

        //adb命令选项是否选中
        private void cb_root_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_root.Checked)
            {
                Command.root(tb_info);
            }
        }

        //push时自定义路径的选项是否选中
        private void cb_path_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_path.Checked)
            {
                tb_path.Enabled = true;
            }
            else
            {
                tb_path.Enabled = false;
            }
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

        //判断是否多设备选项是否选中
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

        //重启手机
        private void btn_restart_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info, PathConstants.adb_path, "reboot");
            Thread thread = new Thread(command.startTask);
            thread.Start();
         }

        //重启到fastboot模式
        private void btn_start_fastboot_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info, PathConstants.adb_path, "reboot bootloader");
            Thread thread = new Thread(command.startTask);
            thread.Start();
        }
        
        //选项卡切换事件
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == "tabPage3")
            {
                tb_info.Text = "";
            }
            else if (tabControl1.SelectedTab.Name == "tabPage2") {
                tb_info.Text = "";
            }
            else if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                tb_info.Text = "";
            }
        }

        /**
         *    第二个选项卡的事件
         */
        private void a_decompile_Click(object sender, EventArgs e)
        {
            tb_info.Text = "";
            String apkPath = chooseFile();
            if (apkPath.Equals(""))
            {
                return;
            }
            string apkName = Path.GetFileNameWithoutExtension(apkPath);
            String apktoolPath = @"tools\apktool_2.3.4.jar";
            CommandThread command = new CommandThread("java -jar " + apktoolPath + " d " + apkPath + " -f -o " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName, tb_info);
            Thread thread = new Thread(command.startTask);
            thread.Start();
            //tb_info.Text = info;
        }

        private void a_backcompile_Click(object sender, EventArgs e)
        {
            tb_info.Text = "";
            String apkFolderPath = chooseFolder();
            if (apkFolderPath.Equals("")) {
                return;
            }
            string apkName = Path.GetFileNameWithoutExtension(apkFolderPath);
            String apktoolPath = @"tools\apktool_2.3.4.jar";
            CommandThread command = new CommandThread("java -jar " + apktoolPath + " b " + apkFolderPath + " -o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + ".unsigned.apk", tb_info);
            //String info = CommandUtil.StartCmdProcess("java -jar " + apktoolPath + " b " + apkFolderPath + " -o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + "_unsigned.apk");
            Thread thread = new Thread(command.startTask);
            thread.Start();
        }

        private void s_decompile_Click(object sender, EventArgs e)
        {
            tb_info.Text = "";
            String apkPath = chooseFile();
            if (apkPath.Equals(""))
            {
                return;
            }
            string apkName = Path.GetFileNameWithoutExtension(apkPath);
            String apktoolPath = @"tools\ShakaApktool_3.0.0-20170503-release.jar";
            CommandUtil.StartCmdProcess("java -jar " + apktoolPath + " d " + apkPath + " -f -o " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName, tb_info);
            //tb_info.Text = info;
        }


        private void s_backcompile_Click(object sender, EventArgs e)
        {
            tb_info.Text = "";
            String apkFolderPath = chooseFolder();
            if (apkFolderPath.Equals(""))
            {
                return;
            }
            string apkName = Path.GetFileNameWithoutExtension(apkFolderPath);
            String apktoolPath = @"tools\ShakaApktool_3.0.0-20170503-release.jar";
            Console.WriteLine("java -jar " + apktoolPath + " b " + apkFolderPath + " -o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + ".unsigned.apk");
            CommandUtil.StartCmdProcess("java -jar " + apktoolPath + " b " + apkFolderPath + " --o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + "_unsigned.apk", tb_info);
        }

        private void sign_apk_Click(object sender, EventArgs e)
        {
            tb_info.Text = "";
            String apkPath = chooseFile();
            if (apkPath.Equals(""))
            {
                return;
            }
            string apkName = Path.GetFileNameWithoutExtension(apkPath);
            String signPath = @"tools\apksigner.jar";
            String jksPath = @"lijie.jks";
            CommandUtil.StartCmdProcess("java -jar " + signPath + " sign --ks " + jksPath + " --ks-key-alias key0 --ks-pass pass:lj940706 --key-pass pass:lj940706" + " --in " + apkPath + " --out " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName + "_signed.apk", tb_info);
            //tb_info.Text = info;
        }

        private String chooseFile()
        {
            OpenFileDialog filename = new OpenFileDialog(); //定义打开文件
            filename.InitialDirectory = FileUtil.DESKTOP_DIR; //初始路径,这里设置的是程序的起始位置，可自由设置
            filename.Filter = "All files(*.*)|*.*|apk file(*.apk)|*.apk";//设置打开类型,设置个*.*和*.txt就行了
            filename.FilterIndex = 2;                  //文件类型的显示顺序（上一行.txt设为第二位）
            filename.RestoreDirectory = true; //对话框记忆之前打开的目录
            if (filename.ShowDialog() == DialogResult.OK)
            {
                return filename.FileName.ToString();//获得完整路径在tb_info中显示
            }
            else
            {
                return "";
            }
        }


        private String chooseFolder()
        {
            FolderBrowserDialog folder = new FolderBrowserDialog();

            folder.Description = "选择所有文件存放目录";
            if (folder.ShowDialog() == DialogResult.OK)
            {
                string sPath = folder.SelectedPath;
                return sPath;
            }
            else
            {
                return "";
            }
        }

        //菜单栏的清屏功能
        private void cl_screen_Click(object sender, EventArgs e)
        {
            tb_info.Text="";
        }

        //菜单栏的打开系统的dos命令
        private void opencmd_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = PathConstants.desktop_path;
            p.Start();
        }

        //连接
        private void btn_connect_Click(object sender, EventArgs e)
        {
            String ipport = "";
            int index=cb_emul.SelectedIndex;
            if (cb_ipport.Checked) {
                if (tb_ipport.Equals(""))
                {
                    MessageBox.Show("ip和port不能为空");
                }
                else {
                    Command.connect(tb_info, tb_ipport.Text+":5555");
                }
            }
            switch (index) {
                case 0:
                    ipport = "127.0.0.1:21503";
                    break;
                case 1:
                    ipport = "127.0.0.1:7555";
                    break;
                case 2:
                    ipport = "127.0.0.1:5555";
                    break;
                case 3:
                    ipport = "127.0.0.1:6555";
                    break;
                case 4:
                    ipport = "127.0.0.1:5555";
                    break;
                case 5:
                    ipport = "127.0.0.1:5555";
                    break;
                case 6:
                    ipport = "127.0.0.1:62001";
                    break;
                case 7:
                    ipport = "127.0.0.1:26944";
                    break;
                case 8:
                    ipport = "127.0.0.1:62001";
                    break;


            }
            Command.connect(tb_info, ipport);
        }

        private void cb_ipport_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ipport.Checked)
            {
                
                    tb_ipport.Enabled = true;
                
            }
            else {
                tb_ipport.Enabled = false;
            }
        }

        private void btn_getinfo_Click(object sender, EventArgs e)
        {
            int index = cb_getinfo.SelectedIndex;
            Command.getInfo(isDevices(),tb_info, index,cb_devices);
        }

        private void btn_getinfo2_Click(object sender, EventArgs e)
        {
            int index = cb_getInfo2.SelectedIndex;
            Command.getInfo2(isDevices(),tb_info, index,cb_devices);
        }
    }
}
