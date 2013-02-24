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
    public partial class frmUserIdentify : Form
    {
        Dictionary<int, string> index_user_list = new Dictionary<int, string>();
        int index = 0;
        public frmUserIdentify()
        {
            InitializeComponent();

            this.lblName.Text = "输入你的指纹，让我看看你是谁？";
            this.FormClosing += (o, e) =>
            {
                //Program.g_ZKFP.CancelCapture();
            };
        }
        public void change_control_state(int state, object o)
        {
            switch (state)
            {
                case 0://获取指纹成功
                    //btnStart.Visible = true;
                    this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_accept;
                    this.lblName.Text = "欢迎你，" + (string)index_user_list[(int)o];
                    break;
                case 1://获取指纹失败
                    //btnStart.Visible = true;
                    this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_delete;
                    this.lblName.Text = "你是谁？";
                    break;
            }
        }
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (Program.g_zkfp_handle != -1)
            {
                Program.g_ZKFP.FreeFPCacheDB(Program.g_zkfp_handle);
                Program.g_zkfp_handle = -1;
            }
            Program.g_zkfp_handle = Program.g_ZKFP.CreateFPCacheDB();
            //加入保存的指纹模板
            List<object> keys = nsConfigDB.ConfigDB.getKeys();
            index = 0;
            foreach (object key in keys)
            {
                string tmp = (string)nsConfigDB.ConfigDB.getConfig((string)key);
                index++;
                Program.g_ZKFP.AddRegTemplateStrToFPCacheDB(Program.g_zkfp_handle, index, tmp);
                index_user_list.Add(index, (string)key);
            }
            //开始1：N识别

            Program.g_ZKFP.SetAutoIdentifyPara(true, Program.g_zkfp_handle, 8);
            this.matrixCircularProgressControl1.Start();
            this.btnStart.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
