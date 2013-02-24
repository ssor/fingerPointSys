using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZkFingerDemo
{
    public partial class frmInputFingerPrint : Form
    {
        int passed_print_count = 0;
        public string currentUserName;
        public frmInputFingerPrint()
        {
            InitializeComponent();
            this.lblState.Text = string.Empty;
        }
        public void change_control_state(frmInputFingerPrintState state, object o)
        {
            switch (state)
            {
                case frmInputFingerPrintState.register_print_success://登记指纹成功
                    btnStart.Visible = true;
                    btnCancel.Visible = false;
                    this.pictureBox3.Image = global::ZkFingerDemo.Properties.Resources.指纹3;
                    this.matrixCircularProgressControl1.Stop();
                    this.lblState.Text = "指纹登记成功";
                    this.txtName.ReadOnly = false;
                    break;
                case frmInputFingerPrintState.register_print_failed://登记指纹失败
                    btnStart.Visible = true;
                    btnCancel.Visible = false;
                    this.lblState.Text = "指纹登记失败";
                    this.reset_picbox_state();
                    break;
                case frmInputFingerPrintState.get_good_print://获取合格指纹
                    this.pbState.Image = global::ZkFingerDemo.Properties.Resources.指纹对号;
                    switch (passed_print_count)
                    {
                        case 0:
                            this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.指纹1;
                            break;
                        case 1:
                            this.pictureBox2.Image = global::ZkFingerDemo.Properties.Resources.指纹2;
                            break;
                    }
                    passed_print_count++;
                    break;
                case frmInputFingerPrintState.get_bad_print://获取不合格指纹
                    this.pbState.Image = global::ZkFingerDemo.Properties.Resources.指纹叉号;
                    break;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.txtName.Text == string.Empty)
            {
                MessageBox.Show("请先输入姓名！", "提示");
            }
            else
            {
                if (nsConfigDB.ConfigDB.isConfigExists(txtName.Text))
                {

                }
                else
                {
                    this.reset_picbox_state();
                    this.currentUserName = this.txtName.Text;
                    this.txtName.ReadOnly = true;
                    this.matrixCircularProgressControl1.Start();

                    Program.g_ZKFP.CancelEnroll();
                    Program.g_ZKFP.EnrollCount = 3;
                    Program.g_ZKFP.BeginEnroll();

                    btnStart.Visible = false;
                    btnCancel.Visible = true;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Program.g_ZKFP.CancelEnroll();
            btnStart.Visible = true;
            btnCancel.Visible = false;

            this.matrixCircularProgressControl1.Stop();
            this.reset_picbox_state();
        }
        void reset_picbox_state()
        {
            passed_print_count = 0;
            this.txtName.ReadOnly = false;
            this.pbState.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox2.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox3.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
        }

        private void frmInputFingerPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
