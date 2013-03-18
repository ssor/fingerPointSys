using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace ZkFingerDemo
{

    static class Program
    {
        public static AxZKFPEngXControl.AxZKFPEngX g_ZKFP;//= new AxZKFPEngXControl.AxZKFPEngX();
        public static int g_zkfp_handle = -1;
        public static frmInputFingerPrint frmInput;
        public static SpeechSynthesizer _synth = new SpeechSynthesizer();
        public static frmUserIdentify frmIdentify;
        public static Dictionary<string, INotified> notifiedTargetList = new Dictionary<string, INotified>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //_synth.SelectVoice("Microsoft Lili");
            //_synth.Rate = -2;
            FingerMainForm mainForm = new FingerMainForm();
            notifiedTargetList.Add("mainForm", mainForm);
            g_ZKFP = new AxZKFPEngXControl.AxZKFPEngX();
            initialAxZKFP();
            test_device_connection();
            Application.Run(mainForm);
            //Application.Run(new FingerDemo());
            //_synth.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Adult, 1, new System.Globalization.CultureInfo("zh-CHS"));
        }
        public static void NotifyTheTarget(Notifier n)
        {
            INotified inf = notifiedTargetList[n.target];
            if (inf != null)
            {
                inf.notified(n);
            }
        }

        #region 指纹控件

        public static void initialAxZKFP()
        {
            g_ZKFP.OnFeatureInfo += new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(ZKFPEngX1_OnFeatureInfo);
            g_ZKFP.OnFingerLeaving += (sender, e) =>
            {
                //this.ShowHintInfo("手指已离开有效采集区域");
            };
            g_ZKFP.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(ZKFPEngX1_OnEnroll);
            g_ZKFP.OnFingerTouching += (sender, e) =>
            {
                //this.ShowHintInfo("手指处于有效采集区域");
            };
            g_ZKFP.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(ZKFPEngX1_OnCapture);

        }
        public static void test_device_connection()
        {
            //连接指纹采集器
            long nR = g_ZKFP.InitEngine();
            if (nR == 0)
            {
                g_ZKFP.FPEngineVersion = "9";
                g_ZKFP.EnrollCount = 3;
                NotifyTheTarget(new Notifier("mainForm", "device_connected", "已连接"));
                //this.sensorConnectionState.Text = "已连接";
                //this.连接指纹仪CToolStripMenuItem.Enabled = false;
                //this.断开指纹仪DToolStripMenuItem.Enabled = true;
            }
            else
            {
                switch (nR)
                {
                    case 1:
                        NotifyTheTarget(new Notifier("mainForm", "device_connect_error", "指纹识别驱动程序加载失败"));
                        //this.sensorConnectionState.Text = "指纹识别驱动程序加载失败";
                        break;
                    case 2:
                        NotifyTheTarget(new Notifier("mainForm", "device_connect_error", "没有连接指纹识别仪"));
                        //this.sensorConnectionState.Text = "没有连接指纹识别仪";
                        break;
                    case 3:
                        NotifyTheTarget(new Notifier("mainForm", "device_connect_error", "指定指纹仪不存在"));
                        //this.sensorConnectionState.Text = "指定指纹仪不存在";
                        break;
                }
            }
        }
        //取得指纹初始特征，0:好的指纹特征  1:特征点不够
        static void ZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String strTemp = "指纹采集质量";
            if (e.aQuality != 0)
            {
                Program.frmInput.change_control_state(frmInputFingerPrintState.get_bad_print, null);
                strTemp = strTemp + "较差";
            }
            else
            {
                Program.frmInput.change_control_state(frmInputFingerPrintState.get_good_print, null);
                strTemp = strTemp + "良好";
            }
            if (g_ZKFP.IsRegister && g_ZKFP.EnrollIndex > 1)
            {
                //ShowHintInfo("正在进行第" + (4 - g_ZKFP.EnrollIndex).ToString() + "次登记，尚需" + (g_ZKFP.EnrollIndex - 1).ToString() + "次");
            }
            //ShowHintInfo(strTemp);
        }
        //将指纹登记特征模版保存到指纹识别高速缓冲空间，并显示指纹登记结果
        static void ZKFPEngX1_OnEnroll(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {
                string tmp9 = g_ZKFP.GetTemplateAsStringEx("9");
                Program.play_voice("指纹登记成功！");
                Program.frmInput.change_control_state(frmInputFingerPrintState.register_print_success, null);
                //ShowHintInfo("指纹登记成功！");

                //frmStudentM.set_fp_string(tmp9);
            }
            else
            {
                //ShowHintInfo("指纹登记失败");
                Program.frmInput.change_control_state(frmInputFingerPrintState.register_print_failed, null);
            }

        }
        static void ZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            int ID = 0, i;
            int Score = 0;
            //e.aTemplate为object类型数据，将其分离并转化为整型
            Array _ObjectArray = (Array)e.aTemplate;
            ID = Convert.ToInt32(_ObjectArray.GetValue(0));
            Score = Convert.ToInt32(_ObjectArray.GetValue(1));
            if (ID == -1)
            {
                Program.frmIdentify.change_control_state(1, null);
                //lblresult.Text = "Fingerprint Auto Identify Failed!";
            }
            else
            {
                //lblresult.Text = "Fingerprint Auto identification success!";
                Program.frmIdentify.change_control_state(0, ID);
            }
        }
        #endregion

        //播放声音
        public static void play_voice(string str)
        {
            _synth.SpeakAsyncCancelAll();
            //_synth.Speak(str);
            _synth.SpeakAsync(str);
        }
    }
}
