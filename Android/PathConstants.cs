using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android
{
    class PathConstants
    {
        public static string app_path= System.AppDomain.CurrentDomain.BaseDirectory;

        public static string desktop_path= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public static string adb_path = app_path + "android_adb//adb.exe";

        public static string apktool_path = app_path + "apktool//apktool.bat";

        public static string enjarify_path = app_path + "enjarify//enjarify.bat";

        public static string dex2jar_path = app_path + "dex2jar//d2j-dex2jar.bat";
    }
}
