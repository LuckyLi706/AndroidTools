using AndroidSmallTools.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android
{
    class CommandThread
    {
        private string path;
        private string command;
        private TextBox tb;

        public CommandThread(TextBox tb,string path,string command) {
            this.tb = tb;
            this.command = command;
            this.path = path;
        }

        public CommandThread(string command, TextBox tb)
        {
            this.tb = tb;
            this.command = command;
        }

        public void startTask() {
            if (path == null || path.Equals(""))
            {
                CommandUtil.StartCmdProcess(command, tb);
            }
            else
            {
                CommandImpl.getInfoByCommand(tb, path, command);
            }
        }
    }
}
