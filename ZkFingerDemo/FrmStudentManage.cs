using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CsharpSQLite;
using ZkFingerDemo;

namespace CheckBase
{
    public partial class FrmStudentManage : Form
    {
        string current_user_id;
        public FrmStudentManage()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(FrmRfidCheck_StudentManage_FormClosed);
        }
        public void set_fp_string(string tmp)
        {
            string insert_fp = string.Format("replace into person_finger_print(xh,print) values('{0}','{1}');", current_user_id, tmp);
            int r = CsharpSQLiteHelper.ExecuteNonQuery(insert_fp, null);
            if (r > 0)
            {
                this.ShowPerson();
                MessageBox.Show("指纹登记成功！", "提示");
            }


        }
        void FrmRfidCheck_StudentManage_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
        Boolean bRefreshParentForm = false;

        private void ShowPerson()
        {
            string select_all = "select p.xh \"学号\", p.xm \"姓名\","
                + " case(f.print) when '' then '未登记' else '已登记' end \"登记状态\" "
                + ", pe.nj \"年级\", pe.bj \"班级\", pe.tel \"电话\", pe.email \"邮箱\" "
                + " from person_info_min as p,person_finger_print as f ,person_expand_info as pe"
                + " where p.xh=f.xh  and p.xh=pe.xh  order  by p.xh;";
            DataTable dt = CsharpSQLiteHelper.ExecuteTable(select_all, null);
            dataGridView1.DataSource = dt;

            int iNumberofStudents = dt.Rows.Count;
            this.groupBox2.Text = "学生列表 共有学生" + iNumberofStudents.ToString() + "名";

            this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            int headerW = this.dataGridView1.RowHeadersWidth;
            int columnsW = 0;
            DataGridViewColumnCollection columns = this.dataGridView1.Columns;
            for (int i = 0; i < columns.Count; i++)
            {
                columnsW += columns[i].Width;
            }
            if (columnsW + headerW < this.dataGridView1.Width)
            {
                int leftTotalWidht = this.dataGridView1.Width - columnsW - headerW;
                int eachColumnAddedWidth = leftTotalWidht / columns.Count;
                for (int i = 0; i < columns.Count; i++)
                {
                    columns[i].Width += eachColumnAddedWidth;
                }
            }


        }

        private void FrmRfidCheck_StudentManage_Load(object sender, EventArgs e)
        {
            ShowPerson();
            SetLabelContent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string strID = txtId.Text;
            if (strID.Length < 0)
            {
                MessageBox.Show("请输入学号！");
                return;
            }
            //if (strID.Length < 0 || strID.Length > 6 || !Regex.IsMatch(strID, "[0-9]{6}"))
            //{
            //    MessageBox.Show("学号应为六位数字！");
            //    return;
            //}

            Func<string, bool> check_id_exists = id =>
            {
                string select_id = "select xh from person_info_min where xh={0}";
                DataTable dt = CsharpSQLiteHelper.ExecuteTable(select_id, new object[] { id });
                return dt.Rows.Count > 0 ? true : false;
            };
            if (check_id_exists(strID))
            {
                MessageBox.Show
                    ("已存在学号为" + strID + "的学生!");
                return;
            }
            else
            {
                string name = txtName.Text;
                string nj = txtnj.Text;
                string bj = txtbj.Text;
                string tel = txtTel.Text;
                string email = txtMail.Text;
                string insert_person = string.Format("insert into person_info_min values('{0}','{1}');", strID, name)
                    + string.Format("insert into person_expand_info(xh,nj,bj,tel,email) values('{0}','{1}','{2}','{3}','{4}');",
                    strID, nj, bj, tel, email)
                + string.Format("insert into person_finger_print values('{0}','');", strID);
                int r = CsharpSQLiteHelper.ExecuteNonQuery(insert_person, null);
                if (r > 0)
                {
                    MessageBox.Show("学号为" + txtId.Text +
                        "的学生新增完成!");
                }
            }
            ShowPerson();
            SetLabelContent();

            //if (writeData)
            //{
            //    rfidCheck_CheckOn.PersonAdd(new Person(txtId.Text,
            //                                            txtName.Text,
            //                                            txtTel.Text,
            //                                            txtMail.Text,
            //                                            txtbj.Text,
            //                                            txtnj.Text,
            //                                            null));

            //    MessageBox.Show("学号为" + txtId.Text +
            //        "的学生新增完成!");

            //    this.bRefreshParentForm = true;
            //}
            //dataGridView1.DataSource = myDataSet.Tables["student"];

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DataSet myDataSet = new DataSet();
            bool bUpdated = false;
            //bUpdated = rfidCheck_CheckOn.PersonUpdate(new Person(txtId.Text,
            //                                                     txtName.Text,
            //                                                     txtTel.Text,
            //                                                     txtMail.Text,
            //                                                     txtbj.Text,
            //                                                     txtnj.Text,
            //                                                     null));
            this.bRefreshParentForm = true;
            if (bUpdated)
            {
                ShowPerson();
                SetLabelContent();
                MessageBox.Show("学号" + txtId.Text +
                "已经修改完成!!");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string message = "确定要删除学号为【" + txtId.Text + "】的学生记录吗？";
            string caption = "删除确认";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            // Displays the MessageBox.
            result = MessageBox.Show(message, caption, buttons);

            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                string strID = txtId.Text;
                this.bRefreshParentForm = true;

                string delete_person = string.Format("delete from person_info_min where xh='{0}';"
                    + "delete from person_finger_print where xh='{0}';"
                    + "delete from person_expand_info where xh='{0}';", strID);
                int r = CsharpSQLiteHelper.ExecuteNonQuery(delete_person, null);
                //bDeleted = rfidCheck_CheckOn.PersonDelete(new Person(txtId.Text,
                //                                                    txtName.Text,
                //                                                    txtTel.Text,
                //                                                    txtMail.Text,
                //                                                    txtbj.Text,
                //                                                    txtnj.Text,
                //                                                    null));
                if (r > 0)
                {
                    ShowPerson();
                    SetLabelContent();
                    MessageBox.Show("学号" + txtId.Text +
                    "已经删除!!");
                }
                else
                {
                    MessageBox.Show("数据删除时出现异常！", "异常提示");
                }
            }


        }
        void SetLabelContent()
        {
            DataTable tb = (DataTable)dataGridView1.DataSource;
            if (tb != null && tb.Rows.Count > 0)
            {
                txtId.Text = tb.Rows[0]["学号"].ToString();
                txtName.Text = tb.Rows[0]["姓名"].ToString();
                txtRegisterState.Text = tb.Rows[0]["登记状态"].ToString();
                txtTel.Text = tb.Rows[0]["电话"].ToString();
                txtMail.Text = tb.Rows[0]["邮箱"].ToString();
                txtnj.Text = tb.Rows[0]["年级"].ToString();
                txtbj.Text = tb.Rows[0]["班级"].ToString();
                //txtTel.Text = tb.Rows[0][4].ToString();
                //txtMail.Text = tb.Rows[0][5].ToString();
            }
            else
            {
                txtId.Text = null;
                txtName.Text = null;
                txtTel.Text = null;
                txtMail.Text = null;
                txtnj.Text = null;
                txtbj.Text = null;
                txtRegisterState.Text = null;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                //txtId.Text=
                txtId.Text = dataGridView1.Rows[e.RowIndex].Cells["学号"].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells["姓名"].Value.ToString();
                txtRegisterState.Text = dataGridView1.Rows[e.RowIndex].Cells["登记状态"].Value.ToString();
                txtnj.Text = dataGridView1.Rows[e.RowIndex].Cells["年级"].Value.ToString();
                txtbj.Text = dataGridView1.Rows[e.RowIndex].Cells["班级"].Value.ToString();
                txtTel.Text = dataGridView1.Rows[e.RowIndex].Cells["电话"].Value.ToString();
                txtMail.Text = dataGridView1.Rows[e.RowIndex].Cells["邮箱"].Value.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.current_user_id = txtId.Text;
            Program.frmInput = new ZkFingerDemo.frmInputFingerPrint();
            Program.frmInput.currentUserName = this.txtName.Text;

            Program.frmInput.ShowDialog();
        }




    }
}
