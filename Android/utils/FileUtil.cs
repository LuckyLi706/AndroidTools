using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AndroidSmallTools.utils
{
    class FileUtil
    {
        public static String DESKTOP_DIR = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static String CURRENT_DIR = Application.StartupPath;
    }
}
