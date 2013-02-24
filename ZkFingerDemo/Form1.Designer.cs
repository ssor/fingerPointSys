namespace ZkFingerDemo
{
    partial class FingerDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerDemo));
            this.btnEnroll = new System.Windows.Forms.Button();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.EDSensorNum = new System.Windows.Forms.TextBox();
            this.Current = new System.Windows.Forms.Label();
            this.EDSensorIndex = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.EDSensorSN = new System.Windows.Forms.TextBox();
            this.memoHint = new System.Windows.Forms.TextBox();
            this.lblresult = new System.Windows.Forms.Label();
            this.Radio9 = new System.Windows.Forms.RadioButton();
            this.Radio10 = new System.Windows.Forms.RadioButton();
            this.ZKFPEngX1 = new AxZKFPEngXControl.AxZKFPEngX();
            this.btnAutoverify = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.imgNO = new System.Windows.Forms.PictureBox();
            this.imgOK = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ZKFPEngX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOK)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEnroll
            // 
            this.btnEnroll.Location = new System.Drawing.Point(253, 172);
            this.btnEnroll.Name = "btnEnroll";
            this.btnEnroll.Size = new System.Drawing.Size(75, 23);
            this.btnEnroll.TabIndex = 2;
            this.btnEnroll.Text = "开始登记";
            this.btnEnroll.UseVisualStyleBackColor = true;
            this.btnEnroll.Click += new System.EventHandler(this.btnEnroll_Click);
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(342, 172);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(75, 23);
            this.btnVerify.TabIndex = 3;
            this.btnVerify.Text = "识别";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(253, 134);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(100, 23);
            this.btnInit.TabIndex = 4;
            this.btnInit.Text = "连接采集器";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 134);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "断开连接";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(255, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "采集器数量";
            // 
            // EDSensorNum
            // 
            this.EDSensorNum.Location = new System.Drawing.Point(342, 24);
            this.EDSensorNum.Name = "EDSensorNum";
            this.EDSensorNum.Size = new System.Drawing.Size(35, 21);
            this.EDSensorNum.TabIndex = 7;
            // 
            // Current
            // 
            this.Current.AutoSize = true;
            this.Current.Location = new System.Drawing.Point(393, 27);
            this.Current.Name = "Current";
            this.Current.Size = new System.Drawing.Size(65, 12);
            this.Current.TabIndex = 8;
            this.Current.Text = "采集器索引";
            // 
            // EDSensorIndex
            // 
            this.EDSensorIndex.Location = new System.Drawing.Point(461, 24);
            this.EDSensorIndex.Name = "EDSensorIndex";
            this.EDSensorIndex.Size = new System.Drawing.Size(78, 21);
            this.EDSensorIndex.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(256, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "采集器编码";
            // 
            // EDSensorSN
            // 
            this.EDSensorSN.Location = new System.Drawing.Point(342, 59);
            this.EDSensorSN.Name = "EDSensorSN";
            this.EDSensorSN.Size = new System.Drawing.Size(197, 21);
            this.EDSensorSN.TabIndex = 11;
            // 
            // memoHint
            // 
            this.memoHint.Location = new System.Drawing.Point(253, 230);
            this.memoHint.Multiline = true;
            this.memoHint.Name = "memoHint";
            this.memoHint.Size = new System.Drawing.Size(286, 122);
            this.memoHint.TabIndex = 12;
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(12, 331);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(0, 12);
            this.lblresult.TabIndex = 16;
            // 
            // Radio9
            // 
            this.Radio9.AutoSize = true;
            this.Radio9.Location = new System.Drawing.Point(342, 96);
            this.Radio9.Name = "Radio9";
            this.Radio9.Size = new System.Drawing.Size(95, 16);
            this.Radio9.TabIndex = 18;
            this.Radio9.TabStop = true;
            this.Radio9.Text = "ZKFinger 9.0";
            this.Radio9.UseVisualStyleBackColor = true;
            // 
            // Radio10
            // 
            this.Radio10.AutoSize = true;
            this.Radio10.Location = new System.Drawing.Point(445, 96);
            this.Radio10.Name = "Radio10";
            this.Radio10.Size = new System.Drawing.Size(101, 16);
            this.Radio10.TabIndex = 19;
            this.Radio10.TabStop = true;
            this.Radio10.Text = "ZKFinger 10.0";
            this.Radio10.UseVisualStyleBackColor = true;
            // 
            // ZKFPEngX1
            // 
            this.ZKFPEngX1.Enabled = true;
            this.ZKFPEngX1.Location = new System.Drawing.Point(41, 301);
            this.ZKFPEngX1.Name = "ZKFPEngX1";
            this.ZKFPEngX1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ZKFPEngX1.OcxState")));
            this.ZKFPEngX1.Size = new System.Drawing.Size(24, 24);
            this.ZKFPEngX1.TabIndex = 20;
            this.ZKFPEngX1.Visible = false;
            this.ZKFPEngX1.OnCapture += new AxZKFPEngXControl.IZKFPEngXEvents_OnCaptureEventHandler(this.ZKFPEngX1_OnCapture);
            this.ZKFPEngX1.OnImageReceived += new AxZKFPEngXControl.IZKFPEngXEvents_OnImageReceivedEventHandler(this.ZKFPEngX1_OnImageReceived);
            this.ZKFPEngX1.OnFeatureInfo += new AxZKFPEngXControl.IZKFPEngXEvents_OnFeatureInfoEventHandler(this.ZKFPEngX1_OnFeatureInfo);
            this.ZKFPEngX1.OnFingerLeaving += new System.EventHandler(this.ZKFPEngX1_OnFingerLeaving);
            this.ZKFPEngX1.OnEnroll += new AxZKFPEngXControl.IZKFPEngXEvents_OnEnrollEventHandler(this.ZKFPEngX1_OnEnroll);
            this.ZKFPEngX1.OnFingerTouching += new System.EventHandler(this.ZKFPEngX1_OnFingerTouching);
            // 
            // btnAutoverify
            // 
            this.btnAutoverify.Location = new System.Drawing.Point(437, 172);
            this.btnAutoverify.Name = "btnAutoverify";
            this.btnAutoverify.Size = new System.Drawing.Size(102, 23);
            this.btnAutoverify.TabIndex = 21;
            this.btnAutoverify.Text = "自动识别";
            this.btnAutoverify.UseVisualStyleBackColor = true;
            this.btnAutoverify.Click += new System.EventHandler(this.btnAutoverify_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(258, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 22;
            this.label3.Text = "识别引擎版本：";
            // 
            // PictureBox1
            // 
            this.PictureBox1.Location = new System.Drawing.Point(25, 28);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(206, 237);
            this.PictureBox1.TabIndex = 17;
            this.PictureBox1.TabStop = false;
            // 
            // imgNO
            // 
            this.imgNO.BackgroundImage = global::ZkFingerDemo.Properties.Resources._2;
            this.imgNO.Location = new System.Drawing.Point(162, 284);
            this.imgNO.Name = "imgNO";
            this.imgNO.Size = new System.Drawing.Size(48, 41);
            this.imgNO.TabIndex = 15;
            this.imgNO.TabStop = false;
            this.imgNO.Visible = false;
            // 
            // imgOK
            // 
            this.imgOK.BackgroundImage = global::ZkFingerDemo.Properties.Resources._1;
            this.imgOK.Location = new System.Drawing.Point(162, 285);
            this.imgOK.Name = "imgOK";
            this.imgOK.Size = new System.Drawing.Size(44, 40);
            this.imgOK.TabIndex = 14;
            this.imgOK.TabStop = false;
            this.imgOK.Visible = false;
            // 
            // FingerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 361);
            this.Controls.Add(this.Radio9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAutoverify);
            this.Controls.Add(this.ZKFPEngX1);
            this.Controls.Add(this.Radio10);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.imgNO);
            this.Controls.Add(this.imgOK);
            this.Controls.Add(this.memoHint);
            this.Controls.Add(this.EDSensorSN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.EDSensorIndex);
            this.Controls.Add(this.Current);
            this.Controls.Add(this.EDSensorNum);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.btnEnroll);
            this.Name = "FingerDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZkFingerDemo";
            this.Load += new System.EventHandler(this.FingerDemo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ZKFPEngX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEnroll;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EDSensorNum;
        private System.Windows.Forms.Label Current;
        private System.Windows.Forms.TextBox EDSensorIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox EDSensorSN;
        private System.Windows.Forms.TextBox memoHint;
        private System.Windows.Forms.PictureBox imgOK;
        private System.Windows.Forms.PictureBox imgNO;
        private System.Windows.Forms.Label lblresult;
        private System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.RadioButton Radio9;
        private System.Windows.Forms.RadioButton Radio10;
        private AxZKFPEngXControl.AxZKFPEngX ZKFPEngX1;
        private System.Windows.Forms.Button btnAutoverify;
        private System.Windows.Forms.Label label3;

    }
}

