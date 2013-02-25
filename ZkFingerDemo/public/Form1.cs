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
    public partial class FingerDemo : Form
    {
        private int FMatchType, fpcHandle;
        private bool FAutoIdentify;
        public FingerDemo()
        {
            InitializeComponent();
        }

        private void ShowHintInfo(String s)
        {
            if (s != "")
            {
                memoHint.AppendText(s + Environment.NewLine);
            }
        }

        //指纹图像比对结果提示
        private void ShowHintImage(int iType)
        {
            if(iType == 0)
            {
                imgNO.Visible = false;
                imgOK.Visible = false;
            }
            else if(iType == 1) 
            {
                imgNO.Visible = false;
                imgOK.Visible = true;
            }
            else if(iType==2)
            {
                imgNO.Visible = true;
                imgOK.Visible = false;
            }
        }

        //获取指纹图像并在窗口中实时显示
        private void ZKFPEngX1_OnImageReceived(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEvent e)
        {
            ShowHintImage(0);
            Graphics g = PictureBox1.CreateGraphics();
            Bitmap bmp = new Bitmap(PictureBox1.Width, PictureBox1.Height);
            g = Graphics.FromImage(bmp);
            int dc = g.GetHdc().ToInt32();
            ZKFPEngX1.PrintImageAt(dc, 0, 0, bmp.Width, bmp.Height);
            g.Dispose();
            PictureBox1.Image = bmp;
        }

        //将指纹登记特征模版保存到指纹识别高速缓冲空间，并显示指纹登记结果
        private void ZKFPEngX1_OnEnroll(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEvent e)
        {
            if (e.actionResult)
            {
                MessageBox.Show("Fingerprint register success！ ", "提示! ", MessageBoxButtons.YesNo);
                //e.aTemplate = ZKFPEngX1.GetTemplate();
                //ZKFPEngX1.AddRegTemplateToFPCacheDB(fpcHandle, 1, e.aTemplate);
                ZKFPEngX1.AddRegTemplateStrToFPCacheDBEx(fpcHandle, 1, ZKFPEngX1.GetTemplateAsStringEx("9"), ZKFPEngX1.GetTemplateAsStringEx("10"));
                ShowHintInfo("Fingerprint register success！");
            }
            else
            {
                ShowHintInfo("Fingerprint register failed");
                MessageBox.Show("Fingerprint register failed ", "提示! ", MessageBoxButtons.YesNo);
            }

        }

        //初始化连接  并显示相关信息到界面
        private void btnInit_Click(object sender, EventArgs e)
        {           
            long nR = ZKFPEngX1.InitEngine();
            if (nR == 0)
            {
                btnInit.Enabled = false;
                FMatchType = 2;
                ShowHintInfo("Sensor connected");
                if (Radio9.Checked)
                {
                    ZKFPEngX1.FPEngineVersion = "9";
                }
                else
                {
                    ZKFPEngX1.FPEngineVersion = "10";
                }
                //创建指纹识别高速缓冲空间 并返回其句柄
                fpcHandle = ZKFPEngX1.CreateFPCacheDB();
                EDSensorNum.Text = Convert.ToString(ZKFPEngX1.SensorCount);
                EDSensorIndex.Text = Convert.ToString(ZKFPEngX1.SensorIndex);
                EDSensorSN.Text = ZKFPEngX1.SensorSN;
                ZKFPEngX1.EnrollCount = 3;
                button1.Enabled = true;
            }
            else
            {
                ShowHintInfo( "Failed to connecte sensor");
            }
        }

        //断开
        private void button1_Click(object sender, EventArgs e)
        {
            ZKFPEngX1.EndEngine();
            btnInit.Enabled = true;
            button1.Enabled = false;
        }

        //开始登记指纹
        private void btnEnroll_Click(object sender, EventArgs e)
        {
            ZKFPEngX1.CancelEnroll();
            ZKFPEngX1.EnrollCount = 3;
            ZKFPEngX1.BeginEnroll();
            ShowHintInfo( "Begin Register");
        }

        //取得指纹初始特征，0:好的指纹特征  1:特征点不够
        private void ZKFPEngX1_OnFeatureInfo(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEvent e)
        {
            String strTemp = "Fingerprint quality";
            if (e.aQuality != 0)
            {
                strTemp = strTemp + " not good";
            }
            else
            {
                strTemp = strTemp + " good";
            }
            if (ZKFPEngX1.EnrollIndex != 1)
            {
                if (ZKFPEngX1.IsRegister)
                {
                    if (ZKFPEngX1.EnrollIndex - 1 > 0)
                    {
                        strTemp = strTemp + '\n'+ " Register status: still press finger " + Convert.ToString(ZKFPEngX1.EnrollIndex-1) + " times!";
                    }
                }
            }
            ShowHintInfo(strTemp);
        }


        //比对指纹
        private void btnVerify_Click(object sender, EventArgs e)
        {
              if(ZKFPEngX1.IsRegister)
              {
                  ZKFPEngX1.CancelEnroll();
              }
              FAutoIdentify = false;
              ZKFPEngX1.SetAutoIdentifyPara(FAutoIdentify, fpcHandle, 8);
              ShowHintInfo("begin verification(1:N)");
              FMatchType = 2;
        }

        //指纹比对事件  (该例中只有1：N比对，即同指纹识别高速缓冲空间德指纹信息进行比对)
        private void ZKFPEngX1_OnCapture(object sender, AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEvent e)
        {
            int ID,i;
            int Score = new int();
            int ProcessNum = new int();
            ShowHintInfo("Acquired fingerprint template:");
            if (FMatchType == 1)//1:1比对(一般用法为把登记好的指纹保存到数据库，1:1比对时，先从数据库获取到相应编号的指纹模板，再同现在比对时获取的指纹进行比对)
            {
                //下面该段代码未实现        sRegTemp为从数据库获取的指纹模板， sVerTemplate为该时刻比对时的指纹
                //ZKFPEngX1.VerFingerFromStr(sRegTemp, sVerTemplate, False, ref regChange) 
                
            }
            if (FMatchType == 2)//1:N比对
            {
                if (!FAutoIdentify)
                {
                    if (Radio9.Checked)
                    {
                        ZKFPEngX1.FPEngineVersion = "9";
                        ID = ZKFPEngX1.IdentificationFromStrInFPCacheDB(fpcHandle, ZKFPEngX1.GetTemplateAsStringEx("9"), ref Score, ref ProcessNum);
                    }
                    else
                    {
                        ZKFPEngX1.FPEngineVersion = "10";
                        ID = ZKFPEngX1.IdentificationFromStrInFPCacheDB(fpcHandle, ZKFPEngX1.GetTemplateAsStringEx("10"), ref Score, ref ProcessNum);
                    }
                    if (ID == -1)
                    {
                        ShowHintInfo("Identification Failed! Score = " + Convert.ToString(Score));
                        ShowHintImage(2);
                    }
                    else
                    {
                        String strTemp = "Identification success!\n" + " Score =" + Convert.ToString(Score);
                        ShowHintInfo(strTemp);
                        ShowHintImage(1);
                    }
                    if (ID > 0)
                    {
                        lblresult.Text = "Verify success";
                    }
                    else
                    {
                        lblresult.Text = "Sorry,Verify failed!";
                    }

                }
                else
                {
                    ID = 0;
                    Score = 0;
                    //e.aTemplate为object类型数据，将其分离并转化为整型
                    Array _ObjectArray = (Array)e.aTemplate;
                    int _ObjectCount = _ObjectArray.GetLength(0);
                    for (i = 0; i<2; i++)
                    {
                        if (i == 0)
                        {
                            ID = Convert.ToInt32(_ObjectArray.GetValue(i));

                        }
                        else
                        {
                            Score = Convert.ToInt32(_ObjectArray.GetValue(i));
                        }
                    }
                    if (ID == -1)
                    {
                         lblresult.Text = "Fingerprint Auto Identify Failed!";
                         ShowHintInfo("Fingerprint Auto Identify Failed!");
                         ShowHintImage(2);
                     }
                     else
                     {
                         lblresult.Text = "Fingerprint Auto identification success!";
                         ShowHintInfo("Fingerprint Auto identification success! Score =" + Convert.ToString(Score));
                         ShowHintImage(1);
                      }

                }
                
            }
        }

        private void ZKFPEngX1_OnFingerTouching(object sender, EventArgs e)
        {
            ShowHintInfo("Touching");

        }

        private void ZKFPEngX1_OnFingerLeaving(object sender, EventArgs e)
        {
            ShowHintInfo("Leaving");
        }

        //窗口初始化
        private void FingerDemo_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            EDSensorNum.Enabled = false;
            EDSensorIndex.Enabled = false;
            EDSensorSN.Enabled = false;
            Radio9.Checked = true;
            FAutoIdentify = false;
        }

        private void btnAutoverify_Click(object sender, EventArgs e)
        {
            FAutoIdentify = true;
            ZKFPEngX1.SetAutoIdentifyPara(FAutoIdentify, fpcHandle, 8);
            FMatchType = 2;
        }







    }
}
