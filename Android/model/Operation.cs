using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Android.model
{
    /**
     * 
     * 所有模拟操作的对象
     * 
     **/
    public class Operation
    {

        private int x1_1;

        private int x1_2;

        private int y1_1;

        private int y1_2;

        private int x2_1;

        private int x2_2;

        private int y2_1;

        private int y2_2;

        private String command;

        private String type;

        private int time;  //暂停时间

        public int X1_1 { get => x1_1; set => x1_1 = value; }
        public int X1_2 { get => x1_2; set => x1_2 = value; }
        public int Y1_1 { get => y1_1; set => y1_1 = value; }
        public int Y1_2 { get => y1_2; set => y1_2 = value; }
        public int X2_1 { get => x2_1; set => x2_1 = value; }
        public int X2_2 { get => x2_2; set => x2_2 = value; }
        public int Y2_1 { get => y2_1; set => y2_1 = value; }
        public int Y2_2 { get => y2_2; set => y2_2 = value; }
        public string Command { get => command; set => command = value; }
        public String Type { get => type; set => type = value; }
        public int Time { get => time; set => time = value; }
    }
}
