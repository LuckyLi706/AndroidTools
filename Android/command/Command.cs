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
            if (validate_Device == 1)
            {
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "shell /system/bin/screencap -p /sdcard/screenshot.png");
                showInfo(tb_info, value);
                string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "pull /sdcard/screenshot.png " + repairSpace(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)));
                showInfo(tb_info, value1);
            }
            if (validate_Device == 2)
            {
                string value = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " shell /system/bin/screencap -p /sdcard/screenshot.png");
                showInfo(tb_info, value);
                string value1 = CommandImpl.getSyncInfo(tb_info, PathUtil.adb_path, "-s " + cb_devices.Text + " pull /sdcard/screenshot.png " + repairSpace(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)));
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
                    command = "tcpip " + ip;
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
                        String command = "tcpip " + ip;
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
                        String command = "tcpip " + ip;
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
                MessageBox.Show(cb_devices.Text);
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
