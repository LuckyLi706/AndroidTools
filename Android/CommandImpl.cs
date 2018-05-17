using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/**
 *可同步或异步读取 StandardOutput 流。Read、ReadLine 和 ReadToEnd 
 *等方法对进程的输出流执行同步读取操作。这些同步读取操作只有在关联的 
 *Process 写入其 StandardOutput 流或关闭该流后才能完成。
 *  
 *相反，BeginOutputReadLine 在 StandardOutput 流上开始异步读取操作。
 *此方法会为流输出启用一个指定的事件处理程序并立即返回到调用方，
 *这样当流输出被定向到该事件处理程序时，调用方还可以执行其他操作。
 *
 * https://msdn.microsoft.com/zh-cn/library/system.diagnostics.process.beginoutputreadline(VS.80).aspx
 * 
 **/
namespace Android
{
    class CommandImpl
    {
        //获取手机的信息
        public static string getPhoneInfo(TextBox textbox,string path,string command,string workpath="1") {

            Process p = new Process();
            p.StartInfo.FileName = path;
            p.StartInfo.Arguments = command;
            if (textbox.Text == null||textbox.Text.Equals(""))
            {
                textbox.AppendText(">>>> 开始执行 adb " + command + "\n");
            }
            else
            {
                textbox.AppendText("\n");
                textbox.AppendText(">>>> 开始执行 adb " + command + "\n");
            }
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

            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            // textbox.Text = ">>>> apktool " + command + " 命令开始" + "\r\n";
            string line = null;
            while (!p.StandardOutput.EndOfStream||!p.StandardError.EndOfStream)
            {

                line = p.StandardOutput.ReadLine()+p.StandardError.ReadLine();
                Console.WriteLine(line);
            }
            //string value = p.StandardOutput.ReadToEnd() + p.StandardError.ReadToEnd();
            return "";
        }


        private static string sortOutput = null;
        private static TextBox textBox;
        private static int numOutputLines = 0;
        public static void getInfoByCommand(TextBox textbox, string path, string command, string workpath = "")
        {
            // Initialize the process and its StartInfo properties.
            // The sort command is a console application that
            // reads and sorts text input.

            //Process sortProcess;
            Process sortProcess = new Process();
            sortProcess.StartInfo.FileName = path;
            Console.WriteLine(path);
            sortProcess.StartInfo.Arguments = command;
            sortProcess.StartInfo.WorkingDirectory = Path.desktop_path;
            if (textbox.Text == null || textbox.Text.Equals(""))
            {
                textbox.AppendText(">>>> 开始执行 adb " + command + "\n");
            }
            else
            {
                textbox.AppendText("\n");
                textbox.AppendText(">>>> 开始执行 adb " + command + "\n");
            }
            // Set UseShellExecute to false for redirection.
            sortProcess.StartInfo.UseShellExecute = false;
            sortProcess.StartInfo.CreateNoWindow = true;
            // Redirect the standard output of the sort command.  
            // This stream is read asynchronously using an event handler.
            sortProcess.StartInfo.RedirectStandardOutput = true;
            textBox = textbox;
           // sortOutput = new StringBuilder("");

            // Set our event handler to asynchronously read the sort output.
            sortProcess.OutputDataReceived += new DataReceivedEventHandler(SortOutputHandler);
            sortProcess.ErrorDataReceived += new DataReceivedEventHandler(SortErrortHandler);

            // Redirect standard input as well.  This stream
            // is used synchronously.
            sortProcess.StartInfo.RedirectStandardInput = true;
            sortProcess.StartInfo.RedirectStandardError = true;
            // Start the process.
            sortProcess.Start();

            // Use a stream writer to synchronously write the sort input.
            StreamWriter sortStreamWriter = sortProcess.StandardInput;

            // Start the asynchronous read of the sort output stream.
            sortProcess.BeginOutputReadLine();
            sortProcess.BeginErrorReadLine();
            sortStreamWriter.Close();

            // Wait for the sort process to write the sorted text lines.
            sortProcess.WaitForExit();
            sortProcess.Close();
        }

        //y
        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                // Add the text to the collected output.
                sortOutput=(Environment.NewLine +
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
                textBox.AppendText(sortOutput);
              //  getPhoneInfo(null, "cmd.exe", "exit");
            }
            //textBox.AppendText("\n");
        }

        //异步接受错误信息
        private static void SortErrortHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                // Add the text to the collected output.
                sortOutput = (">> "+Environment.NewLine +
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
                textBox.AppendText(sortOutput);
            }
            //textBox.AppendText("\n");
        }
    }
}
