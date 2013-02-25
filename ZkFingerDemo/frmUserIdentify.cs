using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsharpSQLite;

namespace ZkFingerDemo
{
    public partial class frmUserIdentify : Form
    {
        public string unique_check_id;
        Dictionary<int, string> index_user_list = new Dictionary<int, string>();
        int index = 0;
        DataTable person_list;
        public frmUserIdentify()
        {
            InitializeComponent();

            this.lblName.Text = "请录入你的指纹";
            this.FormClosing += (o, e) =>
            {
                //Program.g_ZKFP.CancelCapture();
            };

            this.Shown += new EventHandler(frmUserIdentify_Shown);
        }

        void frmUserIdentify_Shown(object sender, EventArgs e)
        {
            if (Program.g_zkfp_handle != -1)
            {
                Program.g_ZKFP.FreeFPCacheDB(Program.g_zkfp_handle);
                Program.g_zkfp_handle = -1;
            }
            Program.g_zkfp_handle = Program.g_ZKFP.CreateFPCacheDB();
            //加入保存的指纹模板
            index = 0;

            //List<object> keys = nsConfigDB.ConfigDB.getKeys();
            //foreach (object key in keys)
            //{
            //    string tmp = (string)nsConfigDB.ConfigDB.getConfig((string)key);
            //    index++;
            //    Program.g_ZKFP.AddRegTemplateStrToFPCacheDB(Program.g_zkfp_handle, index, tmp);
            //    index_user_list.Add(index, (string)key);
            //}

            string select_all = "select p.xh, p.xm,"
                + " f.print "
                + ", pe.nj \"年级\", pe.bj \"班级\", pe.tel \"电话\", pe.email \"邮箱\" "
                + " from person_info_min as p,person_finger_print as f ,person_expand_info as pe"
                + " where p.xh=f.xh  and p.xh=pe.xh  order  by p.xh;";
            this.person_list = CsharpSQLiteHelper.ExecuteTable(select_all, null);
            foreach (DataRow dr in this.person_list.Rows)
            {
                string id = dr["xh"].ToString();

                string tmp = dr["print"].ToString();
                index++;
                Program.g_ZKFP.AddRegTemplateStrToFPCacheDB(Program.g_zkfp_handle, index, tmp);
                index_user_list.Add(index, id);
            }
            this.refresh_check_list();

            //开始1：N识别

            Program.g_ZKFP.SetAutoIdentifyPara(true, Program.g_zkfp_handle, 8);
            this.matrixCircularProgressControl1.Start();
        }
        void refresh_check_list()
        { 
            // 初始化待考勤人员列表
            string select_not_checked = "select p.xh \"学号\", p.xm \"姓名\" "
                + "from person_info_min as p  where p.xh not in(select xh from CheckRecords where record_id = '{0}');";
            DataTable dt_not_checked = CsharpSQLiteHelper.ExecuteTable(select_not_checked, new object[] { this.unique_check_id });
            this.dgvNotChecked.DataSource = dt_not_checked;
            this.gbNotChecked.Text = string.Format("待考勤共{0}人", dt_not_checked.Rows.Count.ToString());
            //初始化已考勤人员
            string select_checked = "select p.xh \"学号\", p.xm \"姓名\" "
                + "from person_info_min as p  where p.xh in(select xh from CheckRecords where record_id = '{0}');";
            DataTable dt_checked = CsharpSQLiteHelper.ExecuteTable(select_checked, new object[] { this.unique_check_id });
            this.dgvChecked.DataSource = dt_checked;
            this.gbChecked.Text = string.Format("已考勤共{0}人", dt_checked.Rows.Count.ToString());        
        }
        public void change_control_state(int state, object o)
        {
            switch (state)
            {
                case 0://获取指纹成功
                    //btnStart.Visible = true;
                    this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_accept;
                    string xh = (string)index_user_list[(int)o];
                    string insert_check_record = string.Format("replace into CheckRecords(record_id,checkDate,xh) values('{0}','{1}','{2}');",
                       this.unique_check_id, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), xh);
                    CsharpSQLiteHelper.ExecuteNonQuery(insert_check_record, null);
                    this.refresh_check_list();
                    DataRow[] rows = this.person_list.Select(string.Format("xh='{0}'", xh));
                    if (rows.Length > 0)
                    {
                        string user_name = rows[0]["xm"].ToString();
                        string str = "欢迎你，" + user_name;
                        this.lblName.Text = str;
                        Program.play_voice(str);
                    }
                    break;
                case 1://获取指纹失败
                    //btnStart.Visible = true;
                    this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_delete;
                    string str_who_are_you = "你是谁？";
                    this.lblName.Text = str_who_are_you;
                    Program.play_voice("请扫描你的指纹");
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
