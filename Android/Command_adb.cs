using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android
{
    class Command_adb
    {
        //获取手机的信息
        public static string getPhoneInfo(string path,string command,string workpath="1") {

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
            string value = p.StandardOutput.ReadToEnd()+p.StandardError.ReadToEnd();
            return value;
        }
    }
}
