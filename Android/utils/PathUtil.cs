using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android
{
    class PathUtil
    {
        //当前app路径
        public static string app_path= System.AppDomain.CurrentDomain.BaseDirectory;

        //桌面路径
        public static string desktop_path= Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);

        public static string adb_path = app_path + "adb//adb.exe";

        public static string aapt_path = app_path + "adb//aapt.exe";

        public static string unzip_path = app_path + "adb//unzip.exe";

        public static string dex2jar_path = @app_path + "dex2jar//d2j-dex2jar.bat";

        //public static string projectsrc_path=@app_path+@"../projects/" + apkName + "/ProjectSrc";
    }
}
