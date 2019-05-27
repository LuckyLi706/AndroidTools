using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndroidSmallTools.utils
{
    class CommandUtil
    {
        private static TextBox textBox;
        public static void StartCmdProcess(string cmd,TextBox textbox)
        {
            Process sortProcess = new Process();
            sortProcess.StartInfo.FileName = "cmd.exe";
            //p.StartInfo.Arguments = "cd " + FileUtil.CURRENT_DIR;
            //Console.WriteLine(path);
            sortProcess.StartInfo.Arguments = cmd;
            if (textbox.Text == null || textbox.Text.Equals(""))
            {
                textbox.AppendText(">>>> 开始执行 adb " + cmd + "\n");
            }
            else
            {
                textbox.AppendText("\n");
                textbox.AppendText(">>>> 开始执行 adb " + cmd + "\n");
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
            //sortProcess.StandardInput.WriteLine(cmd.ToString());
            // Use a stream writer to synchronously write the sort input.
            StreamWriter sortStreamWriter = sortProcess.StandardInput;
            sortStreamWriter.AutoFlush = true;
            sortStreamWriter.WriteLine(cmd);
            Console.WriteLine(cmd);
            // Start the asynchronous read of the sort output stream.
            sortProcess.BeginOutputReadLine();
            sortProcess.BeginErrorReadLine();
            sortStreamWriter.Close();

            // Wait for the sort process to write the sorted text lines.
            sortProcess.WaitForExit();
            sortProcess.Close();
        }
        private static int numOutputLines;
        private static String sortOutput;

        private static void SortOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                numOutputLines++;
                // Add the text to the collected output.
                sortOutput = (Environment.NewLine +
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
                sortOutput = (">> " + Environment.NewLine +
                    "[" + numOutputLines.ToString() + "] - " + outLine.Data);
                textBox.AppendText(sortOutput);
            }
            //textBox.AppendText("\n");
        }
    }
}
