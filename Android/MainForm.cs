using Android.adb;
using Android.dialog;
using Android.model;
using Android.utils;
using AndroidSmallTools.utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Android
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();

            String path=FileUtil.readFile(FileUtil.ADB_FOLDER_PATH + "/path.txt");
            if (!path.Equals("")) {
                path = path.Replace("\r\n", "").Replace("\r\n","");
                PathUtil.adb_path = path;
            }

            this.panel2.MouseWheel += new MouseEventHandler(MainForm_MouseWheel);   //鼠标滚动效果
            this.panel2.Focus();    //聚焦
            this.Text = "安卓小工具"+Constans.APP_VERSION;
            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;
            //解压tools文件夹
            if (!Directory.Exists(PathUtil.app_path + "tools") && File.Exists(PathUtil.app_path + "tools.zip"))
            {
                System.IO.Compression.ZipFile.ExtractToDirectory(PathUtil.app_path + "tools.zip", PathUtil.app_path + "tools");
                File.Delete(PathUtil.app_path + "tools.zip");
            }
            //解析加固的信息
            FileStream fs = new FileStream("config/jiagu_config", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                list.Add(s);
            }
            cb_emul.SelectedIndex = 0;
            cb_getinfo.SelectedIndex = 0;
            cb_getInfo2.SelectedIndex = 0;

        }

        
        private List<String> list=new List<String>();
        //第一个选项卡adb命令

        //获取所有设备名
        private void btn_getdevice_Click(object sender, EventArgs e)
        {
           Command.getDevices(tb_info, cb_devices);
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
            Command.install_Apk(isDevices(), tb_info, cb_devices);
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
            if (cb_path.Checked)
            {
                if (tb_path.Text == null || tb_path.Text.Equals(""))
                {
                    MessageBox.Show("请输入路径");
                    return;
                }
                else
                {
                    Command.push(isDevices(), tb_info, cb_devices, tb_path.Text);
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
            else
            {
                if ((cb_file.Text == null || cb_file.Text.Equals("")))
                {
                    MessageBox.Show("先搜索该手机文件路径的所有文件");
                }
                else
                {
                    string filePath = tb_pull_path.Text;
                    string file;
                    if (filePath.Equals("/"))
                    {
                        file = filePath + cb_file.Text.ToString();
                    }
                    else {
                        file = filePath + "/"+ cb_file.Text.ToString();
                    }
                    Command.pull(isDevices(), tb_info, cb_devices, file.Trim());
                }
            }
        }

        private String currentPath;

        private void cb_file_SelectedIndexChanged(object sender, EventArgs e)
        {
            //currentPath = tb_pull_path.Text.ToString();
            //if (currentPath != null && currentPath.Equals("/"))
            //{
            //    tb_pull_path.Text = currentPath + cb_file.Text;
            //}
            //else
            //{
            //    tb_pull_path.Text = currentPath + "/" + cb_file.Text;
            //}
        }

        //用于给pull文件时搜索路径下的文件
        private void btn_search_path_Click(object sender, EventArgs e)
        {
            if (tb_pull_path.Text == null || tb_pull_path.Text.Equals(""))
            {
                MessageBox.Show("请输入手机路径");
            }
            else
            {
                //currentPath = tb_pull_path.Text;
                Command.getAllFile(isDevices(), tb_pull_path.Text, cb_file, tb_info, cb_devices);
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
            CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "reboot");
            Thread thread = new Thread(command.startTask);
            thread.Start();
        }

        //重启到fastboot模式
        private void btn_start_fastboot_Click(object sender, EventArgs e)
        {
            CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "reboot bootloader");
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
            else if (tabControl1.SelectedTab.Name == "tabPage2")
            {
                tb_info.Text = "";
            }
            else if (tabControl1.SelectedTab.Name == "tabPage1")
            {
                tb_info.Text = "";
                this.panel2.Focus();
            }
        }

        ///**
        // *    第二个选项卡的事件
        // */
        //private void a_decompile_Click(object sender, EventArgs e)
        //{
        //    tb_info.Text = "";
        //    String apkPath = chooseFile();
        //    if (apkPath.Equals(""))
        //    {
        //        return;
        //    }
        //    string apkName = Path.GetFileNameWithoutExtension(apkPath);
        //    String apktoolPath = @"tools\apktool.jar";
        //    CommandThread command = new CommandThread("java -jar " + apktoolPath + " d " + apkPath + " -f -o " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName, tb_info);
        //    Thread thread = new Thread(command.startTask);
        //    thread.Start();
        //    //tb_info.Text = info;
        //}

        //private void a_backcompile_Click(object sender, EventArgs e)
        //{
        //    tb_info.Text = "";
        //    String apkFolderPath = chooseFolder();
        //    if (apkFolderPath.Equals(""))
        //    {
        //        return;
        //    }
        //    string apkName = Path.GetFileNameWithoutExtension(apkFolderPath);
        //    String apktoolPath = @"tools\apktool.jar";
        //    CommandThread command = new CommandThread("java -jar " + apktoolPath + " b " + apkFolderPath + " -o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + ".unsigned.apk", tb_info);
        //    Thread thread = new Thread(command.startTask);
        //    thread.Start();
        //}

        //private void s_decompile_Click(object sender, EventArgs e)
        //{
        //    tb_info.Text = "";
        //    String apkPath = chooseFile();
        //    if (apkPath.Equals(""))
        //    {
        //        return;
        //    }
        //    string apkName = Path.GetFileNameWithoutExtension(apkPath);
        //    String apktoolPath = @"tools\ShakaApktool.jar";
        //    CommandThread command = new CommandThread("java -jar " + apktoolPath + " d " + apkPath + " -f -o " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName, tb_info);
        //    Thread thread = new Thread(command.startTask);
        //    thread.Start();
        //    //tb_info.Text = info;
        //}


        //private void s_backcompile_Click(object sender, EventArgs e)
        //{
        //    tb_info.Text = "";
        //    String apkFolderPath = chooseFolder();
        //    if (apkFolderPath.Equals(""))
        //    {
        //        return;
        //    }
        //    string apkName = Path.GetFileNameWithoutExtension(apkFolderPath);
        //    String apktoolPath = @"tools\ShakaApktool.jar";
        //    Console.WriteLine("java -jar " + apktoolPath + " b " + apkFolderPath + " -o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + ".unsigned.apk");
        //    CommandThread command = new CommandThread("java -jar " + apktoolPath + " b " + apkFolderPath + " --o " + apkFolderPath.Substring(0, apkFolderPath.Length - apkName.Length) + "\\" + apkName + "_unsigned.apk", tb_info);
        //    Thread thread = new Thread(command.startTask);
        //    thread.Start();
        //}

        //private void sign_apk_Click(object sender, EventArgs e)
        //{
        //    tb_info.Text = "";
        //    String apkPath = chooseFile();
        //    if (apkPath.Equals(""))
        //    {
        //        return;
        //    }
        //    string apkName = Path.GetFileNameWithoutExtension(apkPath);
        //    String signPath = @"tools\apksigner.jar";
        //    String jksPath = @"tools\lijie.jks";
        //    CommandThread command = new CommandThread("java -jar " + signPath + " sign --ks " + jksPath + " --ks-key-alias key0 --ks-pass pass:lj940706 --key-pass pass:lj940706" + " --in " + apkPath + " --out " + apkPath.Substring(0, apkPath.Length - apkName.Length - 4) + "\\" + apkName + "_signed.apk", tb_info);
        //    Thread thread = new Thread(command.startTask);
        //    thread.Start();
        //}

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
            tb_info.Text = "";
        }

        //菜单栏的打开系统的dos命令
        private void opencmd_Click(object sender, EventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = PathUtil.desktop_path;
            p.Start();
        }

        //连接
        private void btn_connect_Click(object sender, EventArgs e)
        {
            String ipport = "";
            int index = cb_emul.SelectedIndex;
            ipport = tb_ipport.Text;
            switch (index)
            {
                case 0:
                    Command.wirelessConnect(isDevices(), tb_info, index, cb_devices, ipport);
                    return;

                case 1:
                    ipport = "127.0.0.1:21503";
                    break;
                case 2:
                    ipport = "127.0.0.1:7555";
                    break;
                case 3:
                    ipport = "127.0.0.1:5555";
                    break;
                case 4:
                    ipport = "127.0.0.1:6555";
                    break;
                case 5:
                    ipport = "127.0.0.1:5555";
                    break;
                case 6:
                    ipport = "127.0.0.1:5555";
                    break;
                case 7:
                    ipport = "127.0.0.1:62001";
                    break;
                case 8:
                    ipport = "127.0.0.1:26944";
                    break;
                case 9:
                    ipport = "127.0.0.1:62001";
                    break;
            }

            if (cb_ipport.Checked)
            {
                if (tb_ipport.Equals(""))
                {
                    MessageBox.Show("ip和port不能为空");
                    return;
                }
                
            }
            Command.connect(tb_info, ipport);
        }

        private void cb_ipport_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_ipport.Checked)
            {

                tb_ipport.Enabled = true;

            }
            else
            {
                tb_ipport.Enabled = false;
            }
        }

        private void btn_getinfo_Click(object sender, EventArgs e)
        {
            int index = cb_getinfo.SelectedIndex;
            Command.getInfo(isDevices(), tb_info, index, cb_devices);
        }

        private void btn_getinfo2_Click(object sender, EventArgs e)
        {
            int index = cb_getInfo2.SelectedIndex;
            Command.getInfo2(isDevices(), tb_info, index, cb_devices);
        }

        //获取apk信息
        private void btn_search_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Apk文件(*.apk)|*.apk|所有文件(*.*)|*.*";
            if (dlg.ShowDialog(this) == DialogResult.OK)
            {
                // DecodeApk(dlg.FileName);
                tb_file.Text = System.IO.Path.GetFullPath(dlg.FileName);
                DecodeApk(dlg.FileName);
            }
        }

        private void DecodeApk(string apkPath)
        {
            if (!File.Exists(apkPath))
                return;

            String value = CommandImpl.getSyncInfo(tb_info, PathUtil.aapt_path, " d badging " + apkPath);
            FileUtil.writeFile("1.txt",value);
            value = FileUtil.readFile("1.txt");
            String[] line = value.Replace("\'", "").Split('\n');
            for (int i = 0; i < line.Length; i++)
            {
                //package: name='me.weishu.exp' versionCode='341' versionName='鏄嗕粦闀溌?.4.1' platformBuildVersionName='鏄嗕粦闀溌?.4.1' compileSdkVersion='28' compileSdkVersionCodename='9'
                //如果想不存在乱码，先重定向到txt里面去。
                if (line[i].StartsWith("package"))
                {
                    String[] apkInfo = line[i].Substring(8).Split(' ');
                    tb_package.Text = apkInfo[1].Substring(5);
                    tb_appVersion.Text = apkInfo[2].Split('=')[1];
                    continue;
                }
                else if (line[i].StartsWith("application-label:"))
                {
                    
                    tb_appName.Text = line[i].Split(':')[1];
                    //tb_appName.Text = line[i].Split(':')[1];
                    continue;
                }
                else if (line[i].StartsWith("launchable-activity"))
                {
                    tb_startAct.Text = line[i].Substring(20).Split(' ')[1].Split('=')[1];
                    continue;
                }
            }
        }

        private void Btn_dex_Click(object sender, EventArgs e)
        {
            if (tb_file.Text.Equals(""))
            {
                MessageBox.Show("请先选择apk");
                return;
            }
            String apkName=Path.GetFileNameWithoutExtension(tb_file.Text);
            DirectoryInfo directoryDecode = new DirectoryInfo("projects/" + apkName + "/ProjectSrc");
            if (!directoryDecode.Exists)
            {
                MessageBox.Show("请先使用AndroidKiller反编译该apk");
                return;
            }
            DirectoryInfo directoryInfo = new DirectoryInfo("projects/" + apkName + "/ProjectSrc/dex");
            if (directoryInfo.Exists)
            {
                FileUtil.deleteDirectory(@"projects/" + apkName + "/ProjectSrc/dex");
            }
            if (!directoryInfo.Exists) {
                directoryInfo.Create();
            }
            string path =  Path.GetFullPath(".")+"/projects/" + apkName + "/ProjectSrc";
           // MessageBox.Show();
            String value = CommandImpl.getSyncInfo(tb_info, PathUtil.unzip_path, " -j " + tb_file.Text + " *.dex -d projects/"+apkName+"/ProjectSrc/dex");
            directoryInfo = new DirectoryInfo(PathUtil.app_path+"../projects/" + apkName + "/ProjectSrc/dex");
            FileInfo[] fileInfos =directoryInfo.GetFiles();
            for (int i=1;i<fileInfos.Length;i++) {
                // CommandImpl.getSyncInfo(tb_info, PathUtil.dex2jar_path, fileInfos[i].FullName);
                
                CommandThread command = new CommandThread(tb_info, PathUtil.dex2jar_path, @fileInfos[i].FullName,path);
                command.startTask();
                if (!Directory.Exists(path + "/smali_classes" + (i + 1))) {
                    Directory.CreateDirectory(path + "/smali_classes" + (i + 1));
                }
                CommandThread commandCopy = new CommandThread(tb_info, PathUtil.unzip_path, "../classes"+(i+1)+"-dex"+(i+1)+ "jar.jar", path+"/smali_classes" + (i + 1));
                Thread thread = new Thread(commandCopy.startTask);
                thread.Start();
                //command.startTask();
            }
        }

        private void btn_jiagu_Click(object sender, EventArgs e)
        {
            if (tb_file.Text.Equals("")) {
                MessageBox.Show("请先选择apk");
                return;
            }
            String value = CommandImpl.getSyncInfo(tb_info, PathUtil.unzip_path, " -j " + tb_file.Text + " lib/armeabi-v7a/*.so -d so");
            if (value.Contains("filename not matched:"))
            {
                value = CommandImpl.getSyncInfo(tb_info, PathUtil.unzip_path, " -j " + tb_file.Text + " lib/armeabi/*.so -d so");
                if (value.Contains("filename not matched:"))
                {
                    tb_jiagu.Text = "无加固信息";
                    return;
                }
                else {
                    //MessageBox.Show(value);
                    List<String> list_info = new List<string>();
                    String[] info = value.Split('\n');
                    for (int i = 1; i < info.Length-1; i++) {
                        list_info.Add(info[i].Split('/')[1]);
                    }
                    
                    getjiaguInfo(list_info);
                }
            }
            else {
                //MessageBox.Show(value);
                List<String> list_info = new List<string>();
                String[] info = value.Split('\n');
                for (int i = 1; i < info.Length; i++)
                {
                    if (!info[i].Equals(""))
                    {
                        //MessageBox.Show(info[i].Split('/')[1]);
                        list_info.Add(info[i].Split('/')[1]);
                    }
                    else {
                        list_info.Add("");
                    }
                }
                getjiaguInfo(list_info);
            }
            
        }


        private void getjiaguInfo(List<String> list_info)
        {
           
            for (int i = 0; i < list_info.Count; i++)
            {
                if (list_info[i].Equals("")) {
                    continue;
                }
                String name = list_info[i].Substring(0, 7);
                //MessageBox.Show(name);
                for (int j = 0; j < list.Count; j++)
                {
                    //MessageBox.Show(list[j]);
                    if (list[j].Contains(name))
                    {
                        tb_jiagu.Text=list[j];
                        FileUtil.deleteDirectory("so");
                        return;
                    }
                }
            }
            FileUtil.deleteDirectory("so");
            tb_jiagu.Text = "无加固信息";
        }


        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog aboutDialog = new AboutDialog();
            aboutDialog.ShowDialog();
        }


        private void adb_path_Click(object sender, EventArgs e)
        {
            PathDialog pathDialog = new PathDialog();
            pathDialog.ShowDialog();
        }


        void MainForm_MouseWheel(object sender, MouseEventArgs e)

        {
            //获取光标位置
            Point mousePoint = new Point(e.X, e.Y);
            //换算成相对本窗体的位置
            mousePoint.Offset(this.Location.X, this.Location.Y);
            //判断是否在panel内
            if (this.panel2.RectangleToScreen(panel2.DisplayRectangle).Contains(mousePoint))
            {
                //滚动
                panel2.AutoScrollPosition = new Point(0, panel2.VerticalScroll.Value - e.Delta);
            }
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            this.panel2.Focus();
        }
       

        private void btn_time_Click(object sender, EventArgs e)
        {
            if (cb_time_point.Items.Count > 0)
            {
                Command.getOneCrashReport(isDevices(), cb_time_point.SelectedItem.ToString(), tb_info, cb_devices);
            }
            else {
                MessageBox.Show("请先获取所有crash报告时间点");
            }

        }

        private void btn_collect_crash_Click(object sender, EventArgs e)
        {
            Command.getAllTimeCrash(isDevices(), cb_time_point, tb_info, cb_devices);
        }

        private void btn_collect_anr_Click(object sender, EventArgs e)
        {
            Command.getOneAnrReport(isDevices(), tb_info, cb_devices);
        }


        /**
         * 
         *   模拟操作
         * 
         */

        private List<Operation> operationList = new List<Operation>();   //存储所有模拟操作
        private List<String> userList = new List<string>();

        //获取设备
        private void btn_simulator_get_devices_Click(object sender, EventArgs e)
        {
            Command.getDevices(tb_info, cb_simulator_devices);
        }

        //开始任务
        private void btn_simulator_start_Click(object sender, EventArgs e)
        {
            if (btn_simulator_start.Text.Equals("开始"))
            {
                btn_simulator_start.Text = "停止";
                if (cb_simulator_more_devices.Checked && cb_simulator_more_operations.Checked)
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        Command.startSimulator(userList[i], operationList, -1);
                    }
                }
                else if (cb_simulator_more_devices.Checked)
                {
                    for (int i = 0; i < userList.Count; i++)
                    {
                        Command.startSimulator(userList[i], operationList, cb_simulator_run_operation.SelectedIndex);
                    }
                }
                else if (cb_simulator_more_operations.Checked)
                {
                    Command.startSimulator(cb_simulator_run_devices.SelectedItem.ToString(), operationList, -1);
                }
                else {
                    Command.startSimulator(cb_simulator_run_devices.SelectedItem.ToString(), operationList, cb_simulator_run_operation.SelectedIndex);
                }
            }
            else {
                btn_simulator_start.Text = "开始";
                Command.closeSimulator();
            }
        }

        //添加设备
        private void btn_simulator_add_device_Click(object sender, EventArgs e)
        {
            if (!cb_simulator_devices.SelectedItem.ToString().Equals(""))
            {
                if (userList.Contains(cb_simulator_devices.Text)) {
                    MessageBox.Show("请勿添加重复设备！");
                }
                userList.Add(cb_simulator_devices.Text);
                cb_simulator_run_devices.Items.Add(cb_simulator_devices.Text);
                cb_simulator_run_devices.SelectedIndex = 0;
            }
            else {
                MessageBox.Show("当前无设备，请先获取设备");
            }
        }

        //添加操作
        private void btn_simulator_add_operation_Click(object sender, EventArgs e)
        {
            if (cb_simulator_all_operation.SelectedItem.ToString().Equals(""))
            {
                MessageBox.Show("请先选择操作");
            }
            OperationDialog operationData = new OperationDialog(operationList,cb_simulator_all_operation.SelectedItem.ToString());
            operationData.ShowDialog();

            cb_simulator_run_operation.Items.Clear();
            for (int i = 0; i < operationList.Count; i++) {
                cb_simulator_run_operation.Items.Add(operationList[i].Type);
            }
            if (cb_simulator_run_operation.Items.Count > 0) {
                cb_simulator_run_operation.SelectedIndex = 0;
            }
        }

        private void btn_sign_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件";
            dialog.Filter = "所有文件(*.apk)|*.apk";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string file = dialog.FileName;
                Command.signed_Apk(file,tb_info);
            }
        }
    }

    //private void apkDecoder_InfoParsed(ApkDecoder apkDecoder)
    //{
    //    this.Invoke(new Action<ApkDecoder>(SafeInfoParsed), apkDecoder);
    //}

    //private void apkDecoder_AaptNotFound()
    //{
    //    this.Invoke(new MethodInvoker(ShowAaptNotFoundInfo));
    //}

    //private void ShowAaptNotFoundInfo()
    //{
    //    MessageBox.Show(this, "解析apk文件所需要的组件aapt.exe遗失，请下载此程序完整组件然后再试。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    //}

    //private void SafeInfoParsed(ApkDecoder apkDecoder)
    //{
    //    tb_appName.Text = apkDecoder.AppName;
    //    //txtVersion.Text = apkDecoder.AppVersion;
    //    //txtVersionCode.Text = apkDecoder.AppVersionCode;
    //    tb_package.Text = apkDecoder.PkgName;
    //    //txtIconPath.Text = apkDecoder.IconPath;
    //    //txtMinSdk.Text = apkDecoder.MinSdk;
    //    //txtMinVersion.Text = apkDecoder.MinVersion;
    //    //txtScreenSize.Text = apkDecoder.ScreenSupport;
    //    //txtScreenSolution.Text = apkDecoder.ScreenSolutions;
    //    //txtPermission.Text = apkDecoder.Permissions;
    //    //txtFeature.Text = apkDecoder.Features;
    //    //imgIcon.Image = (apkDecoder.AppIcon != null) ? apkDecoder.AppIcon : this.Icon.ToBitmap();

    //    //txtApkPath.Text = apkDecoder.ApkPath;
    //    //txtApkSize.Text = apkDecoder.ApkSize;

    //    //this.btnPlayStore.Enabled = !string.IsNullOrEmpty(txtPackage.Text);
    //}
    //}
}
