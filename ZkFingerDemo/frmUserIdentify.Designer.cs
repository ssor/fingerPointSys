namespace ZkFingerDemo
{
    partial class frmUserIdentify
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.matrixCircularProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(150, 321);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(109, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_search;
            this.pictureBox1.Location = new System.Drawing.Point(107, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // matrixCircularProgressControl1
            // 
            this.matrixCircularProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.matrixCircularProgressControl1.Interval = 60;
            this.matrixCircularProgressControl1.Location = new System.Drawing.Point(163, 256);
            this.matrixCircularProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.matrixCircularProgressControl1.Name = "matrixCircularProgressControl1";
            this.matrixCircularProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.matrixCircularProgressControl1.Size = new System.Drawing.Size(71, 67);
            this.matrixCircularProgressControl1.StartAngle = 270F;
            this.matrixCircularProgressControl1.TabIndex = 4;
            this.matrixCircularProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            // 
            // frmUserIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 356);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.matrixCircularProgressControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmUserIdentify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹识别";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LogisTechBase.MatrixCircularProgressControl matrixCircularProgressControl1;
    }
}