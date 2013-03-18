using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using CheckBase;

namespace ZkFingerDemo
{
    public partial class FingerMainForm : Form, INotified
    {
        public FingerMainForm()
        {
            InitializeComponent();
            //Program.g_ZKFP = this.ZKFPEngX1;

            //this.Shown += new EventHandler(FingerMainForm_Shown);
            //this.ZKFPEngX1.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.ZKFPEngX1_OnCapture);
            //this.ZKFPEngX1.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(this.ZKFPEngX1_OnImageReceived);
            //this.ZKFPEngX1.OnFeatureInfo += new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(this.ZKFPEngX1_OnFeatureInfo);
            //this.ZKFPEngX1.OnFingerLeaving += (sender, e) => { this.ShowHintInfo("手指已离开有效采集区域"); };
            //this.ZKFPEngX1.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(this.ZKFPEngX1_OnEnroll);
            //this.ZKFPEngX1.OnFingerTouching += (sender, e) => { this.ShowHintInfo("手指处于有效采集区域"); };
            //this.ZKFPEngX1.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(ZKFPEngX1_OnCapture);

        }

        //void ZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        //{
        //    int ID = 0, i;
        //    int Score = 0;
        //    //e.aTemplate为object类型数据，将其分离并转化为整型
        //    Array _ObjectArray = (Array)e.aTemplate;
        //    ID = Convert.ToInt32(_ObjectArray.GetValue(0));
        //    Score = Convert.ToInt32(_ObjectArray.GetValue(1));
        //    if (ID == -1)
        //    {
        //        Program.frmIdentify.change_control_state(1, null);
        //        //lblresult.Text = "Fingerprint Auto Identify Failed!";
        //    }
        //    else
        //    {
        //        //lblresult.Text = "Fingerprint Auto identification success!";
        //        Program.frmIdentify.change_control_state(0, ID);
        //    }
        //}
        //取得指纹初始特征，0:好的指纹特征  1:特征点不够
        //private void ZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        //{
        //    String strTemp = "指纹采集质量";
        //    if (e.aQuality != 0)
        //    {
        //        Program.frmInput.change_control_state(frmInputFingerPrintState.get_bad_print, null);
        //        strTemp = strTemp + "较差";
        //    }
        //    else
        //    {
        //        Program.frmInput.change_control_state(frmInputFingerPrintState.get_good_print, null);
        //        strTemp = strTemp + "良好";
        //    }
        //    if (ZKFPEngX1.IsRegister && ZKFPEngX1.EnrollIndex > 1)
        //    {
        //        ShowHintInfo("正在进行第" + (4 - ZKFPEngX1.EnrollIndex).ToString() + "次登记，尚需" + (ZKFPEngX1.EnrollIndex - 1).ToString() + "次");
        //    }
        //    //if (ZKFPEngX1.EnrollIndex != 1)
        //    //{
        //    //    if (ZKFPEngX1.IsRegister)
        //    //    {
        //    //        if (ZKFPEngX1.EnrollIndex - 1 > 0)
        //    //        {
        //    //            strTemp = strTemp + '\n' + " Register status: still press finger " + Convert.ToString(ZKFPEngX1.EnrollIndex - 1) + " times!";
        //    //        }
        //    //    }
        //    //}
        //    ShowHintInfo(strTemp);
        //}
        //将指纹登记特征模版保存到指纹识别高速缓冲空间，并显示指纹登记结果
        //private void ZKFPEngX1_OnEnroll(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent e)
        //{
        //    if (e.actionResult)
        //    {
        //        //object bits = ZKFPEngX1.GetTemplate();
        //        //string encodetmp = ZKFPEngX1.EncodeTemplate1(bits);
        //        //string tmp9 = ZKFPEngX1.GetTemplateAsStringEx("9");
        //        //string tmp10 = ZKFPEngX1.GetTemplateAsStringEx("10");
        //        //MessageBox.Show("指纹登记成功！", "提示! ", MessageBoxButtons.YesNo);
        //        //e.aTemplate = ZKFPEngX1.GetTemplate();
        //        //ZKFPEngX1.AddRegTemplateToFPCacheDB(fpcHandle, 1, e.aTemplate);
        //        //ZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, 1, ZKFPEngX1.GetTemplateAsStringEx("9"), ZKFPEngX1.GetTemplateAsStringEx("10"));
        //        string tmp9 = ZKFPEngX1.GetTemplateAsStringEx("9");
        //        //nsConfigDB.ConfigDB.saveConfig(frmInput.currentUserName, tmp9);
        //        Program.play_voice("指纹登记成功！");
        //        Program.frmInput.change_control_state(frmInputFingerPrintState.register_print_success, null);
        //        ShowHintInfo("指纹登记成功！");

        //        frmStudentM.set_fp_string(tmp9);
        //    }
        //    else
        //    {
        //        ShowHintInfo("指纹登记失败");
        //        Program.frmInput.change_control_state(frmInputFingerPrintState.register_print_failed, null);
        //        //MessageBox.Show("指纹登记失败", "提示! ", MessageBoxButtons.YesNo);
        //    }

        //}
        private void ShowHintInfo(String s)
        {
            if (s != "")
            {
                Debug.WriteLine(s);
            }
        }


        private void FingerMainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            ZKFPEngX1.EndEngine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.frmInput = new frmInputFingerPrint();
            Program.frmInput.ShowDialog();
            //ZKFPEngX1.CancelEnroll();
            //ZKFPEngX1.EnrollCount = 3;
            //ZKFPEngX1.BeginEnroll();
            //ShowHintInfo("开始登记指纹");
        }

        private void btnCancelRegisterPrint_Click(object sender, EventArgs e)
        {
            ZKFPEngX1.CancelEnroll();
            ShowHintInfo("取消登记指纹");
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Program.frmIdentify = new frmUserIdentify();
            Program.frmIdentify.ShowDialog();
        }

        private void 断开指纹仪DToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ZKFPEngX1.EndEngine();
            this.连接指纹仪CToolStripMenuItem.Enabled = true;
            this.断开指纹仪DToolStripMenuItem.Enabled = false;
            this.sensorConnectionState.Text = "未连接";
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.frmInput = new frmInputFingerPrint();
            Program.frmInput.ShowDialog();
        }

        private void 用户识别IToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.frmIdentify = new frmUserIdentify();
            Program.frmIdentify.ShowDialog();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {

        }

        private void 连接指纹仪CToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FingerMainForm_Shown(null, null);
        }

        private void 指纹登记RToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.frmInput = new frmInputFingerPrint();
            Program.frmInput.ShowDialog();
        }
        FrmStudentManage frmStudentM;
        private void 学生管理MToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudentM = new FrmStudentManage();
            frmStudentM.ShowDialog();
        }

        private void 开始考勤SToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmIdentify = new frmUserIdentify();
            //frmIdentify.ShowDialog();

            frmCheckInit frm = new frmCheckInit();
            frm.ShowDialog();
        }
        void FingerMainForm_Shown(object sender, EventArgs e)
        {
            //连接指纹采集器
            long nR = ZKFPEngX1.InitEngine();
            if (nR == 0)
            {
                //FMatchType = 2;
                ZKFPEngX1.FPEngineVersion = "9";
                //创建指纹识别高速缓冲空间 并返回其句柄
                //fpcHandle = ZKFPEngX1.CreateFPCacheDB();
                //Program.g_zkfp_handle = fpcHandle;// 与公共引用连接
                ZKFPEngX1.EnrollCount = 3;
                this.sensorConnectionState.Text = "已连接";
                this.连接指纹仪CToolStripMenuItem.Enabled = false;
                this.断开指纹仪DToolStripMenuItem.Enabled = true;
            }
            else
            {
                switch (nR)
                {
                    case 1:
                        this.sensorConnectionState.Text = "指纹识别驱动程序加载失败";
                        break;
                    case 2:
                        this.sensorConnectionState.Text = "没有连接指纹识别仪";
                        break;
                    case 3:
                        this.sensorConnectionState.Text = "指定指纹仪不存在";
                        break;
                }
            }
        }
        #region INotified 成员

        public void notified(Notifier n)
        {
            switch (n.command)
            {
                case "device_connected":
                    this.sensorConnectionState.Text = "已连接";
                    this.连接指纹仪CToolStripMenuItem.Enabled = false;
                    this.断开指纹仪DToolStripMenuItem.Enabled = true;
                    break;
                case "device_connect_error":
                    this.sensorConnectionState.Text = (string)n.para;

                    break;
            }
        }

        #endregion
    }
}
