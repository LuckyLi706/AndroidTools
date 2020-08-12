using Android.model;
using Android.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Android.dialog
{
    public partial class OperationData : Form
    {
        private List<Operation> operationList;
        private String operateType;
        public OperationData()
        {
            InitializeComponent();
        }

        public OperationData(List<Operation> operationList,String operateType) {
            this.operationList = operationList;
            this.operateType = operateType;

            InitializeComponent();

            this.Text = operateType;

            if (operateType.Equals(Constans.BACK))
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
            else if (operateType.Equals(Constans.CLICK)) {
                panel2.Visible = false;
            }
            else if (operateType.Equals(Constans.INPUT))
            {
                panel1.Visible = false;
                panel2.Visible = false;
            }
            else if (operateType.Equals(Constans.SLIDE))
            {

            }
        }

        private void btn_dialog_operation_confirm_Click(object sender, EventArgs e)
        {
            Operation operation = new Operation();
            if (operateType.Equals(Constans.BACK))
            {
                if (tb_dialog_operation_delay.Equals(""))
                {
                    MessageBox.Show("请输入延迟时间");
                }
                else {
                    operation.Time = int.Parse(tb_dialog_operation_delay.Text);
                    operation.Type = operateType;
                    operationList.Add(operation);
                }
            }
            else if (operateType.Equals(Constans.CLICK))
            {
                if (tb_dialog_operation_delay.Equals(""))
                {
                    MessageBox.Show("请输入延迟时间");
                }
                else
                {
                    if (tb_dialog_operation_delay.Equals("")|| tb_dialog_operation_x1_1.Equals("")|| tb_dialog_operation_x1_2.Equals("")|| tb_dialog_operation_y1_1.Equals("")|| tb_dialog_operation_y1_2.Equals(""))
                    {
                        MessageBox.Show("任何一项都不能为空");
                    }
                    else
                    {
                        operation.X1_1 = int.Parse(tb_dialog_operation_x1_1.Text);
                        operation.X1_2 = int.Parse(tb_dialog_operation_x1_2.Text);
                        operation.Y1_1 = int.Parse(tb_dialog_operation_y1_1.Text);
                        operation.Y1_2 = int.Parse(tb_dialog_operation_y1_2.Text);
                        operation.Time = int.Parse(tb_dialog_operation_delay.Text);
                        operation.Type = operateType;
                        operationList.Add(operation);
                    }
                }
            }
            else if (operateType.Equals(Constans.INPUT))
            {

            }
            else if (operateType.Equals(Constans.SLIDE))
            {
                if (tb_dialog_operation_delay.Equals("") || tb_dialog_operation_x1_1.Equals("") || tb_dialog_operation_x1_2.Equals("") || tb_dialog_operation_y1_1.Equals("") || tb_dialog_operation_y1_2.Equals("") || tb_dialog_operation_x2_1.Equals("") || tb_dialog_operation_x2_2.Equals("") || tb_dialog_operation_y2_1.Equals("") || tb_dialog_operation_y2_2.Equals(""))
                {
                    MessageBox.Show("任何一项都不能为空");
                }
                else
                {
                    operation.X1_1 = int.Parse(tb_dialog_operation_x1_1.Text);
                    operation.X1_2 = int.Parse(tb_dialog_operation_x1_2.Text);
                    operation.Y1_1 = int.Parse(tb_dialog_operation_y1_1.Text);
                    operation.Y1_2 = int.Parse(tb_dialog_operation_y1_2.Text);
                    operation.X2_1 = int.Parse(tb_dialog_operation_x2_1.Text);
                    operation.X2_2 = int.Parse(tb_dialog_operation_x2_2.Text);
                    operation.Y2_1 = int.Parse(tb_dialog_operation_y2_1.Text);
                    operation.Y2_2 = int.Parse(tb_dialog_operation_y2_2.Text);
                    operation.Time = int.Parse(tb_dialog_operation_delay.Text);
                    operation.Type = operateType;
                    operationList.Add(operation);
                }
            }
            Close();
        }

        private void btn_dialog_operation_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
