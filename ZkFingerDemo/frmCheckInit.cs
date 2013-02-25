using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ZkFingerDemo;

namespace CheckBase
{
    public partial class frmCheckInit : Form
    {
        public frmCheckInit()
        {
            InitializeComponent();
        }

        private void frmCheckInit_Load(object sender, EventArgs e)
        {
            this.lblCheckGuid.Text = string.Format("{0}{1}", "prefix", DateTime.Now.ToString("yyyyMMddHHmmss"));
            this.dtpStart.Value = DateTime.Now;
            this.txtInfo.Text = string.Empty;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmCheckInitctl.insert_record(this.lblCheckGuid.Text, this.txtInfo.Text, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));


            Program.frmIdentify = new frmUserIdentify();
            Program.frmIdentify.unique_check_id = this.lblCheckGuid.Text;
            //Program.frmIdentify.unique_check_id = "prefix20130224222727";

            this.Close();

            Program.frmIdentify.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHistoryRecord_Click(object sender, EventArgs e)
        {
            HistoryCheckRecord history = new HistoryCheckRecord();
            history.checkInit = this;
            history.ShowDialog();
        }
        public void set_check_record_info(string id, string info, string create_time)
        {
            this.lblCheckGuid.Text = id;
            this.dtpStart.Value = DateTime.Parse(create_time);
            this.txtInfo.Text = info;
        }
    }
}
