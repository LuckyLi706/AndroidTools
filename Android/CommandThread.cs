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

        public void startTask() {
            Command.getInfoByCommand(tb,path,command);
        }
    }
}
