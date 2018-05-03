using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android
{
    class Command
    {
        //获取手机的信息
        public static string getPhoneInfo(TextBox textbox,string path,string command,string workpath="1") {

            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = command;
            if (!workpath.Equals("1")) {
                p.StartInfo.WorkingDirectory = Path.desktop_path;
            }
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            textbox.Text = ">>>> adb " + command+" 命令开始" + "\r\n";
            string value = p.StandardOutput.ReadToEnd()+p.StandardError.ReadToEnd();
            return value;
        }


        public static string getApkTool(TextBox textbox, string path, string command, string workpath = "1")
        {

            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = command;
            p.StartInfo.WorkingDirectory = Path.desktop_path;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            textbox.Text = ">>>> apktool " + command + " 命令开始" + "\r\n";
            string value = p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd();
            return value;
        }
    }
}
