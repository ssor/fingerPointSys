using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CsharpSQLite;
using CheckBase;

namespace ZkFingerDemo
{
    public partial class HistoryCheckRecord : Form
    {
        public frmCheckInit checkInit;
        public HistoryCheckRecord()
        {
            InitializeComponent();

            this.Shown += new EventHandler(HistoryCheckRecord_Shown);
            this.dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }
        string id;
        string info;
        string create_time;
        void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                id = dataGridView1.Rows[e.RowIndex].Cells["编号"].Value.ToString();
                info = dataGridView1.Rows[e.RowIndex].Cells["备注"].Value.ToString();
                create_time = dataGridView1.Rows[e.RowIndex].Cells["创建时间"].Value.ToString();
            }
        }

        void HistoryCheckRecord_Shown(object sender, EventArgs e)
        {
            string select = "SELECT record_id \"编号\",info \"备注\",create_time \"创建时间\" FROM check_record_info order by create_time desc;";
            DataTable dt = CsharpSQLiteHelper.ExecuteTable(select, null);
            this.dataGridView1.DataSource = dt;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                if (this.checkInit != null)
                {
                    checkInit.set_check_record_info(id, info, create_time);
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择一项历史记录", "提示");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
