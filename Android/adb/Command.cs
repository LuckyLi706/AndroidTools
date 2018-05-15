﻿using System;
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
        public static void getDevices(TextBox tb_info,ComboBox cb_devices) {
            string value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "devices");
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

        private static string showInfo(string info)
        {
            return ">>>> " + info;
        }

        public static void getPackageName(int validate_Device, TextBox tb_info, ComboBox cb_devices,TextBox tb_packagename) {
            string value = "";
            if (validate_Device == 1)
            {
                value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "shell dumpsys activity");
            }
            if (validate_Device == 2)
            {
                value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "-s " + cb_devices.Text + " shell dumpsys activity");
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
                    int a = values[i].IndexOf("u0");
                    int b = values[i].IndexOf('/');
                    string packageName = values[i].Substring(a + 3, b - a - 3);
                    tb_packagename.Text = packageName;
                }
                if (values[i].Contains("error"))
                {
                    tb_info.Text = showInfo(values[i]) + "\r\n";
                    return;
                }
            }
        }

        public static void getTopActivity(int validate_Device,TextBox tb_info,ComboBox cb_devices) {
            string value = "";
            if (validate_Device == 1)
            {
                value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "shell dumpsys activity");
            }
            if (validate_Device == 2)
            {
                value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "-s " + cb_devices.Text + " shell dumpsys activity");
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
                    return;
                }
                if (values[i].Contains("error"))
                {
                    tb_info.Text = showInfo(values[i]) + "\r\n";
                    return;
                }
            }
        }

        public static void install_Apk(int validate_Device,TextBox tb_info,ComboBox cb_devices) {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
            else if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                MessageBox.Show("什么也没选择");
                return;
            }
            if (validate_Device == 1)
            {
                CommandThread command = new CommandThread(tb_info, Path.adb_path, "install " + path);
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                CommandThread command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text + " install " + path);
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void unstallApk(int validate_Device,TextBox tb_packagename,TextBox tb_info,ComboBox cb_devices) {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else
            {
                if (validate_Device == 1)
                {
                    CommandThread command = new CommandThread(tb_info, Path.adb_path, "uninstall " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 2)
                {
                    CommandThread command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text + " uninstall " + tb_packagename.Text);
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

        public static void clearData(int validate_Device, TextBox tb_packagename, TextBox tb_info, ComboBox cb_devices) {
            if (tb_packagename.Text == null || tb_packagename.Text.Equals(""))
            {
                MessageBox.Show("请获取包名或手动输入包名");
            }
            else
            {
                if (validate_Device == 1)
                {
                    CommandThread command = new CommandThread(tb_info, Path.adb_path, "shell pm clear " + tb_packagename.Text);
                    Thread thread = new Thread(command.startTask);
                    thread.Start();
                }
                if (validate_Device == 2)
                {
                    CommandThread command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text + "shell pm clear " + tb_packagename.Text);
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

        public static void shotScreen(int validate_Device, TextBox tb_packagename, TextBox tb_info, ComboBox cb_devices) {
            if (validate_Device == 1)
            {
                string value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "shell /system/bin/screencap -p /sdcard/screenshot.png");
                tb_info.AppendText(showInfo(value) + "\r\n");
                tb_info.AppendText("\r\n");
                string value1 = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "pull /sdcard/screenshot.png " + Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                tb_info.AppendText(showInfo(value1) + "\r\n");
            }
            if (validate_Device == 2)
            {
                string value = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "-s " + cb_devices.Text+"shell /system/bin/screencap -p /sdcard/screenshot.png");
                tb_info.AppendText(showInfo(value) + "\r\n");
                tb_info.AppendText("\r\n");
                string value1 = CommandImpl.getPhoneInfo(tb_info, Path.adb_path, "-s " + cb_devices.Text+"pull /sdcard/screenshot.png " + Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory));
                tb_info.AppendText(showInfo(value1) + "\r\n"); 
            }
            if (validate_Device == 3)
            {
                MessageBox.Show("请获取设备名");
                return;
            }
        }

        public static void push(int validate_Device, TextBox tb_info, ComboBox cb_devices,String phone_path="") {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Path.desktop_path;            // 这里是初始的路径名
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
                CommandThread command=null;
                if (phone_path.Equals(""))
                {
                    command = new CommandThread(tb_info, Path.adb_path, "push " + path + " data/local/tmp");
                }
                else {
                    command = new CommandThread(tb_info, Path.adb_path, "push " + path +" "+phone_path);
                }
                Thread thread = new Thread(command.startTask);
                thread.Start();
            }
            if (validate_Device == 2)
            {
                CommandThread command = null;
                if (phone_path.Equals(""))
                {
                    command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text + "push " + path + " data/local/tmp");
                }
                else
                {
                    command = new CommandThread(tb_info, Path.adb_path, "-s " + cb_devices.Text + "push " + path + " " + phone_path);
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

        public static void root() {
            CommandImpl.getPhoneInfo(null,Path.adb_path,"root");
        }
    }
}
