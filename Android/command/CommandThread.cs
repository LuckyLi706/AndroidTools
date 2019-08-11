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
        private string ws;

        public CommandThread(TextBox tb,string path,string command) {
            this.tb = tb;
            this.command = command;
            this.path = path;
        }

        public CommandThread(TextBox tb, string path, string command,string workspace)
        {
            this.tb = tb;
            this.command = command;
            this.path = path;
            ws = workspace;
        }

        public CommandThread(string command, TextBox tb)
        {
            this.tb = tb;
            this.command = command;
        }

        public void startTask() {
            
            CommandImpl.getAsynInfo(tb, path, command,ws);
        }
    }
}
