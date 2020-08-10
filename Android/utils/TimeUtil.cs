using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.utils
{
    public class TimeUtil
    {

        /* 获取 utc 1970-1-1到现在的秒数 */
        public static long getCurrentSeconds()
        {
            return (System.DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
        }
        /* 获取 utc 1970-1-1到现在的毫秒数 */
        public static long getCurrentMilliSeconds()
        {
            return (System.DateTime.UtcNow.ToUniversalTime().Ticks - 621355968000000000) / 10000;
        }

        public static String getCurrentStr() {         
            return DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fff"); //2019-12-24 02:57:37.149
        }

    }
}
