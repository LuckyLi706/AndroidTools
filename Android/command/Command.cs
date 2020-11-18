using Android.model;
using Android.utils;
using AndroidSmallTools.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android.adb
{
    class Command
    {
        //展示信息·
        private static void showInfo(TextBox textbox, String info)
        {
            textbox.AppendText(Environment.NewLine);
            textbox.AppendText(info);
        }

        public static void getDevices(TextBox tb_info, ComboBox cb_devices)
        {
            string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "devices");
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
            if (cb_devices.Items.Count > 0)
            {
                cb_devices.SelectedIndex = 0;
            }
        }

        public static void getPackageName(int validate_Device, TextBox tb_info, ComboBox cb_devices, TextBox tb_packagename)
        {
            string value = "";
            if (validate_Device == 1)
            {
                value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell dumpsys activity");
            }
            if (validate_Device == 2)
            {
                value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell dumpsys activity");
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
            string[] values = value.Split('\n');
            for (int i = 0; i < values.Length; i++)
            {
                //处理9.0版本手机顶级activity信息过滤改为mResumedActivity
                if (values[i].Contains("mFocusedActivity") || values[i].Contains("mResumedActivity"))
                {
                    int a = values[i].IndexOf("u0");
                    int b = values[i].IndexOf('/');
                    string packageName = values[i].Substring(a + 3, b - a - 3);
                    tb_packagename.Text = packageName;
                }
                if (values[i].Contains("error:"))
                {
                    showInfo(tb_info, values[i]);
                    return;
                }
            }
        }

        public static void getTopActivity(int validate_Device, TextBox tb_info, ComboBox cb_devices)
        {
            string value = "";
            if (validate_Device == 1)
            {
                value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell dumpsys activity");
            }
            if (validate_Device == 2)
            {
                value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell dumpsys activity");
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
            string[] values = value.Split('\n');
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i].Contains("mFocusedActivity") || values[i].Contains("mResumedActivity"))
                {
                    showInfo(tb_info, values[i].TrimStart());
                    return;
                }
                if (values[i].Contains("error:"))
                {
                    showInfo(tb_info, values[i]);
                    return;
                }
            }
        }

        public static void install_Apk(int validate_Device, TextBox tb_info, ComboBox cb_devices)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = PathUtil.desktop_path;            // 这里是初始的路径名
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
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("什么也没选择");
                return;
            }
            if (validate_Device == 1)
            {
                CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "install " +repairSpace(path));
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " install " + repairSpace(path));
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void unstallApk(int validate_Device, TextBox tb_packagename, TextBox tb_info, ComboBox cb_devices)
        {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else
            {
                if (validate_Device == 1)
                {
                    CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "uninstall " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 2)
                {
                    CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " uninstall " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 3)
                {
                    MessageBox.Show("请获取设备名");
                    return;
                }
            }
        }

        public static void clearData(int validate_Device, TextBox tb_packagename, TextBox tb_info, ComboBox cb_devices)
        {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else
            {
                if (validate_Device == 1)
                {
                    CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "shell pm clear " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 2)
                {
                    CommandThread command = new CommandThread(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell pm clear " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 3)
                {
                    MessageBox.Show("请获取设备名");
                    return;
                }
            }
        }

        public static void shotScreen(int validate_Device, TextBox tb_packagename, TextBox tb_info, ComboBox cb_devices)
        {
            String screenshotName =TimeUtil.getCurrentMilliSeconds()+"";
            if (validate_Device == 1)
            {
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell /system/bin/screencap -p /sdcard/"+ screenshotName+".png");
                showInfo(tb_info, value);
                string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "pull /sdcard/" + screenshotName + ".png " + repairSpace(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)));
                showInfo(tb_info, value1);
            }
            if (validate_Device == 2)
            {
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell /system/bin/screencap -p /sdcard/" + screenshotName + ".png");
                showInfo(tb_info, value);
                string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " pull /sdcard/" + screenshotName + ".png " + repairSpace(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)));
                showInfo(tb_info, value1);
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void connect(TextBox tb_info, String ipport)
        {
            string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "connect " + ipport);
            showInfo(tb_info,value);
        }

        public static void wirelessConnect(int validate_Device, TextBox tb_info, int index, ComboBox cb_devices, String ipport) {
            if (validate_Device == 2)
            {
                if (ipport.Equals(""))
                {
                    String command = "";
                    command = "shell ifconfig | grep 192.168";
                    string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);

                    String[] ips = value.Split(':');
                    String ip = ips[1].Split(' ')[0];
                    command = "tcpip " + 5555;
                    value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                    showInfo(tb_info, value);
                    command = "connect " + ip + ":5555";
                    value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                    showInfo(tb_info, value);
                }
                else {
                    String[] ip_port = ipport.Split(':');
                    if (ip_port.Length == 2)
                    {
                        String ip = ip_port[0];
                        String port = ip_port[1];
                        String command = "tcpip " + port;
                        String value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                        showInfo(tb_info, value);
                        command = "connect " + ip + ":"+port;
                        value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                        showInfo(tb_info, value);
                    }
                    else {
                        MessageBox.Show("请输入格式为ip:port");
                    }
                }
            }
            else if (validate_Device == 1)
            {
                if (ipport.Equals(""))
                {
                    String command = "";
                    command = "shell ifconfig | grep 192.168";
                    string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, command);

                    String[] ips = value.Split(':');
                    String ip = ips[1].Split(' ')[0];
                    command = "tcpip " + ip;
                    value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, command);
                    showInfo(tb_info, value);
                    command = "connect " + ip + ":5555";
                    value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, command);
                    showInfo(tb_info, value);
                }

                else
                {
                    String[] ip_port = ipport.Split(':');
                    if (ip_port.Length == 2)
                    {
                        String ip = ip_port[0];
                        String port = ip_port[1];
                        String command = "tcpip " + port;
                        String value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, command);
                        showInfo(tb_info, value);
                        command = "connect " + ip + ":" + port;
                        value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path,command);
                        showInfo(tb_info, value);
                    }
                    else
                    {
                        MessageBox.Show("请输入格式为ip:port");
                    }
                }
            }
        }

        //获取其他信息
        public static void getInfo(int validate_Device, TextBox tb_info, int index, ComboBox cb_devices)
        {
            if (validate_Device == 1)
            {
                String command = "";
                if (index == 0)
                {
                    command = "shell cat /proc/meminfo";
                }
                else if (index == 1)
                {
                    command = "shell cat /proc/cpuinfo";
                }
                else if (index == 2)
                {
                    command = "shell dumpsys gfxinfo";
                }
                else if (index == 3)
                {
                    command = "shell dumpsys display";
                }
                else if (index == 4)
                {
                    command = "shell dumpsys battery";
                }
                else if (index == 5)
                {
                    command = "shell dumpsys alarm";
                }
                else if (index == 6)
                {
                    command = "shell dumpsys location";
                }
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, cb_devices.Text + " " + command);
                showInfo(tb_info, value);
            }
            else if (validate_Device == 2)
            {
                String command = "";
                if (index == 0)
                {
                    command = "shell cat /proc/meminfo";
                }
                else if (index == 1)
                {
                    command = "shell cat /proc/cpuinfo";
                }
                else if (index == 2)
                {
                    command = "shell dumpsys gfxinfo";
                }
                else if (index == 3)
                {
                    command = "shell dumpsys display";
                }
                else if (index == 4)
                {
                    command = "shell dumpsys battery";
                }
                else if (index == 5)
                {
                    command = "shell dumpsys alarm";
                }
                else if (index == 6)
                {
                    command = "shell dumpsys location";
                }
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                showInfo(tb_info, value);
            }

        }

        //获取其他信息
        public static void getInfo2(int validate_Device, TextBox tb_info, int index, ComboBox cb_devices)
        {
            if (validate_Device == 2)
            {
                String command = "";
                if (index == 0)
                {
                    command = "shell netcfg ";
                }
                else if (index == 1)
                {
                    command = "shell cat /sys/class/net/wlan0/address ";
                }
                else if (index == 2)
                {
                    string[] commands = { "shell dumpsys iphonesubinfo", "shell getprop gsm.baseband.imei", "service call iphonesubinfo 1" };
                    for (int i = 0; i < commands.Length; i++)
                    {
                        string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + commands[i]);
                        showInfo(tb_info, value1);
                    }
                    return;
                }
                else if (index == 3)
                {
                    command = "shell cat /system/build.prop";
                }
                else if (index == 4)
                {
                    command = "shell settings get secure android_id";
                }
                else if (index == 5)
                {
                    command = "shell settings get secure bluetooth_address";
                }

                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " " + command);
                showInfo(tb_info, value);
            }
            else if (validate_Device == 1)
            {
                String command = "";
                if (index == 0)
                {
                    command = "shell netcfg ";
                }
                else if (index == 1)
                {
                    command = "shell cat /sys/class/net/wlan0/address ";
                }
                else if (index == 2)
                {
                    string[] commands = { "shell dumpsys iphonesubinfo", "shell getprop gsm.baseband.imei", "service call iphonesubinfo 1" };
                    for (int i = 0; i < commands.Length; i++)
                    {
                        string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, commands[i]);
                        showInfo(tb_info, value1);
                    }
                    return;
                }
                else if (index == 3)
                {
                    command = "shell cat /system/build.prop";
                }
                else if (index == 4)
                {
                    command = "shell settings get secure android_id";
                }
                else if (index == 5)
                {
                    command = "shell settings get secure bluetooth_address";
                }

                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, command);
                showInfo(tb_info, value);
            }
        }

        public static void push(int validate_Device, TextBox tb_info, ComboBox cb_devices, String phone_path = "")
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = PathUtil.desktop_path;            // 这里是初始的路径名
            openFileDialog1.Filter = "所有文件|*.*";  //设置打开文件的类型
            openFileDialog1.RestoreDirectory = true;              //设置是否还原当前目录
            openFileDialog1.FilterIndex = 0;                      //设置打开文件类型的索引
            string path = "";                                     //用于保存打开文件的路径
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                path = openFileDialog1.FileName;
            }
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("什么也没选择");
                return;
            }
            if (validate_Device == 1)
            {
                CommandThread command = null;
                if (phone_path.Equals(""))
                {
                    command = new CommandThread(tb_info, PathUtil.adb_path, "push " + repairSpace(path) + " data/local/tmp");
                }
                else
                {
                    command = new CommandThread(tb_info, PathUtil.adb_path, "push " + repairSpace(path) + " " + phone_path);
                }
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                CommandThread command = null;
                if (phone_path.Equals(""))
                {
                    command = new CommandThread(tb_info, PathUtil.adb_path, "-s " + repairSpace(cb_devices.Text) + " push " + path + " data/local/tmp");
                }
                else
                {
                    command = new CommandThread(tb_info, PathUtil.adb_path, "-s " + repairSpace(cb_devices.Text) + " push " + path + " " + phone_path);
                }
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void pull(int validate_Device, TextBox tb_info, ComboBox cb_devices, String file_path = "")
        {

            if (validate_Device == 1)
            {
                //String sdkVersion = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell getprop ro.build.version.sdk");
                //if (Int16.Parse(sdkVersion) <= 23)
                //{
                //    MessageBox.Show("6.0及其以下版本不支持");
                //    return;
                //}
                CommandThread command = null;
                command = new CommandThread(tb_info, PathUtil.adb_path, ("pull " + file_path.Substring(0, file_path.Length) + " " + repairSpace(PathUtil.desktop_path)));
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                //String sdkVersion = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell getprop ro.build.version.sdk");
                //if (Int16.Parse(sdkVersion) <= 23)
                //{
                //    MessageBox.Show("6.0及其以下版本不支持");
                //    return;
                //}
                CommandThread command = null;
                
                command = new CommandThread(tb_info, PathUtil.adb_path, ("-s " + cb_devices.Text + " pull " + file_path.Substring(0, file_path.Length) + " " + repairSpace(PathUtil.desktop_path)));
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void getAllFile(int validate_Device, String path, ComboBox cb_file, TextBox tb_info, ComboBox cb_devices)
        {
            //adb shell getprop ro.build.version.sdk
            if (validate_Device == 1)
            {
                
                String files = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell ls " + path);
                if (files.Contains("error:"))
                {
                    tb_info.AppendText(files);
                }
                else
                {
                    if (files.Contains("No such"))
                    {
                        tb_info.AppendText(files);
                    }
                    
                    else
                    {
                        //String sdkVersion = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell getprop ro.build.version.sdk");
                        //if (Int16.Parse(sdkVersion) <= 23)
                        //{
                        //    MessageBox.Show("6.0及其以下版本不支持");
                        //    return;
                        //}
                        string[] values = files.Split('\n');
                        cb_file.Items.Clear();
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i].Contains("Permission denied"))
                            {
                                continue;
                            }
                            cb_file.Items.Add(values[i]);
                        }
                        if (cb_file.Items.Count > 0)
                        {
                            cb_file.SelectedIndex = 0;
                        }
                    }
                }

            }
            if (validate_Device == 2)
            {
                String files = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell ls " + path);
                if (files.Contains("error"))
                {
                    tb_info.AppendText(files);
                }
                else
                {
                    if (files.Contains("No such"))
                    {
                        tb_info.AppendText(files);
                    }
                    else
                    {
                        //String sdkVersion = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell getprop ro.build.version.sdk");
                        //if (Int16.Parse(sdkVersion) <= 23)
                        //{
                        //    MessageBox.Show("6.0及其以下版本不支持");
                        //    return;
                        //}
                        string[] values = files.Split('\n');
                        cb_file.Items.Clear();
                        for (int i = 0; i < values.Length; i++)
                        {
                            if (values[i].Contains("Permission denied"))
                            {
                                continue;
                            }
                            cb_file.Items.Add(values[i]);
                        }
                        if (cb_file.Items.Count > 0)
                        {
                            cb_file.SelectedIndex = 0;
                        }
                    }
                }
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }


        public static void getAllTimeCrash(int validate_Device, ComboBox cb_file, TextBox tb_info, ComboBox cb_devices) {
            String values="";
            if (validate_Device == 1)
            {
                values= CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, " shell dumpsys dropbox | grep crash");
            }
            if (validate_Device == 2)
            {
                values=CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell dumpsys dropbox | grep crash");
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
            cb_file.Items.Clear();
            if (!values.Equals("")) {
                String[] times = values.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = times.Length-1; i >= 0; i--) {
                    cb_file.Items.Add(times[i].Split('d')[0].Trim());
                }

                if (cb_file.Items.Count > 0) {
                    cb_file.SelectedIndex = 0;
                }
            }
        }

        //adb shell dumpsys dropbox 2019-02-09 21:27:33 --print
        public static void getOneCrashReport(int validate_Device, String cb_file, TextBox tb_info, ComboBox cb_devices) {
            if (validate_Device == 1)
            {
                CommandImpl.getAsynInfo(tb_info, "", PathUtil.adb_path + " shell dumpsys dropbox " + cb_file + " --print >> "+TimeUtil.getCurrentSeconds() + ".txt", FileUtil.DESKTOP_DIR); ;
            }
            if (validate_Device == 2)
            {
                CommandImpl.getAsynInfo(tb_info, "", PathUtil.adb_path+ " -s " + cb_devices.Text + " shell dumpsys dropbox " + cb_file + " --print >>"+ TimeUtil.getCurrentSeconds() + ".txt",FileUtil.DESKTOP_DIR);
               // CommandImpl.getAsynInfo(tb_info, "", value + " >> error.txt", FileUtil.DESKTOP_DIR);
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void getOneAnrReport(int validate_Device, TextBox tb_info, ComboBox cb_devices)
        {
            if (validate_Device == 1)
            {
                CommandThread command = null;
                command = new CommandThread(tb_info, "",PathUtil.adb_path+ " bugreport", FileUtil.DESKTOP_DIR);
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                CommandThread command = null;
                command = new CommandThread(tb_info, PathUtil.adb_path, " -s " + cb_devices.Text + " bugreport", FileUtil.DESKTOP_DIR);
                Thread thread = new Thread(command.startTask);
                thread.Start();
                //CommandImpl.getAsynInfo(tb_info, "", PathUtil.adb_path + " -s " + cb_devices.Text + " bugreport", FileUtil.DESKTOP_DIR);
                // CommandImpl.getAsynInfo(tb_info, "", value + " >> error.txt", FileUtil.DESKTOP_DIR);
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        private static bool isRun=false;

        public static void startSimulator(String user,List<Operation> operationList,int command) {
            isRun = true;
            OperationThread operationThread = new OperationThread(user, operationList, command);
            Thread thread = new Thread(operationThread.startTask);
            thread.Start();
        }

        public static void closeSimulator() {
            isRun = false;
        }


        class OperationThread {

            private List<Operation> operationList;
            private int command;
            private String user;

            public OperationThread(String user,List<Operation> operationList, int command) {

                this.user = user;
                this.operationList = operationList;
                this.command = command;
            }


            public void startTask() {

                while (isRun) {
                    if (command == -1)
                    {
                        for (int i = 0; i < operationList.Count; i++) {
                            runOperationCommand(user, operationList, i);
                        }
                    }
                    else {
                        runOperationCommand(user,operationList,command);
                    }
                }
            }

            private Random ra = new Random();

            private void runOperationCommand(String user, List<Operation> operationList, int command)
            {
                Operation operation = operationList[command];
                if (operation.Type.Equals(Constans.BACK))
                {
                    CommandImpl.getSyncInfo(null, PathUtil.adb_path, "-s " + user + " shell input keyevent 4"); //后退
                    int time = operation.Time;
                    Thread.Sleep(time*1000);
                }
                else if (operation.Type.Equals(Constans.CLICK))   //adb shell input tap x y
                {
                    int x_1 = operation.X1_1;
                    int x_2 = operation.X1_2;
                    int y_1 = operation.Y1_1;
                    int y_2 = operation.Y1_2;
                    int time = operation.Time;
                    int x = ra.Next(x_1, x_2 + 1);
                    int y = ra.Next(y_1, y_2 + 1);
                    CommandImpl.getSyncInfo(null, PathUtil.adb_path, "-s " + user + " shell input tap " + x + " " + y);
                    Thread.Sleep(time*1000);
                }
                else if (operation.Type.Equals(Constans.INPUT))
                {

                }
                else if (operation.Type.Equals(Constans.SLIDE)) //adb shell input swipe 250 250 300 300 从屏幕(250, 250), 到屏幕(300, 300)
                {
                    int x1_1 = operation.X1_1;
                    int x1_2 = operation.X1_2;
                    int y1_1 = operation.Y1_1;
                    int y1_2 = operation.Y1_2;

                    int x2_1 = operation.X2_1;
                    int x2_2 = operation.X2_2;
                    int y2_1 = operation.Y2_1;
                    int y2_2 = operation.Y2_2;

                    int time = operation.Time;
                    int x1 = ra.Next(x1_1, x1_2 + 1);
                    int y1 = ra.Next(y1_1, y1_2 + 1);

                    int x2 = ra.Next(x2_1, x2_2 + 1);
                    int y2 = ra.Next(y2_1, y2_2 + 1);
                    CommandImpl.getSyncInfo(null, PathUtil.adb_path, "-s " + user + " shell input swipe " + x1 + " " + y1 + " "+ x2 + " " + y2);
                    Thread.Sleep(time*1000);
                }
            }
        }

        public static void root(TextBox tb_info)
        {
            CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "root");
        }

        /**
         *    处理路径中带有空格的问题
         *
         */
        private static string repairSpace(string path) {
            return "\"" + path + "\"";
        }
    }
}
