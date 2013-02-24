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

            this.Shown += new EventHandler(frmInputFingerPrint_Shown);
            this.FormClosing += new FormClosingEventHandler(frmInputFingerPrint_FormClosing);
        }

        void frmInputFingerPrint_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.g_ZKFP.CancelEnroll();
        }

        void frmInputFingerPrint_Shown(object sender, EventArgs e)
        {
            this.restart_register();
        }
        public void change_control_state(frmInputFingerPrintState state, object o)
        {
            switch (state)
            {
                case frmInputFingerPrintState.register_print_success://登记指纹成功
                    btnStart.Visible = true;
                    btnCancel.Visible = false;
                    this.pictureBox3.Image = global::ZkFingerDemo.Properties.Resources.指纹3;
                    //this.matrixCircularProgressControl1.Stop();
                    //this.lblState.Text = "指纹登记成功";
                    //this.txtName.ReadOnly = false;
                    this.Close();
                    break;
                case frmInputFingerPrintState.register_print_failed://登记指纹失败
                    btnStart.Visible = true;
                    btnCancel.Visible = false;
                    this.lblState.Text = "指纹登记失败";


                    DialogResult result;
                    string message = "指纹登记失败，要重新登记吗？";
                    string caption = "登记失败";
                    MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                    // Displays the MessageBox.
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == DialogResult.Yes)
                    {
                        this.restart_register();
                    }
                    else
                    {
                        this.Close();
                    }
                    
                    //this.reset_control_state();
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
                    this.reset_control_state();
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
            //Program.g_ZKFP.CancelEnroll();
            //btnStart.Visible = true;
            //btnCancel.Visible = false;

            //this.matrixCircularProgressControl1.Stop();
            //this.reset_control_state();

            this.Close();
        }
        void restart_register()
        {
            passed_print_count = 0;
            reset_control_state();
            this.matrixCircularProgressControl1.Start();
            Program.g_ZKFP.CancelEnroll();
            Program.g_ZKFP.EnrollCount = 3;
            Program.g_ZKFP.BeginEnroll();
            this.lblInfo.Text = "采集" + currentUserName + "的指纹中...";
        }
        void reset_control_state()
        {
            this.txtName.ReadOnly = false;
            this.pbState.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox2.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;
            this.pictureBox3.Image = global::ZkFingerDemo.Properties.Resources.指纹空白;

            btnStart.Visible = false;
            btnCancel.Visible = true;
        }

        private void frmInputFingerPrint_Load(object sender, EventArgs e)
        {

        }
    }
}
