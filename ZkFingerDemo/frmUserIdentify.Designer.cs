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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUserIdentify));
            this.btnStart = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gbNotChecked = new System.Windows.Forms.GroupBox();
            this.gbChecked = new System.Windows.Forms.GroupBox();
            this.dgvNotChecked = new System.Windows.Forms.DataGridView();
            this.dgvChecked = new System.Windows.Forms.DataGridView();
            this.matrixCircularProgressControl1 = new LogisTechBase.MatrixCircularProgressControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbNotChecked.SuspendLayout();
            this.gbChecked.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotChecked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecked)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(91, 428);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(97, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Visible = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblName.Location = new System.Drawing.Point(67, 25);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(56, 16);
            this.lblName.TabIndex = 2;
            this.lblName.Text = "label2";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::ZkFingerDemo.Properties.Resources.business_user_search;
            this.pictureBox1.Location = new System.Drawing.Point(70, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(182, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // gbNotChecked
            // 
            this.gbNotChecked.Controls.Add(this.dgvNotChecked);
            this.gbNotChecked.Location = new System.Drawing.Point(303, 12);
            this.gbNotChecked.Name = "gbNotChecked";
            this.gbNotChecked.Size = new System.Drawing.Size(395, 230);
            this.gbNotChecked.TabIndex = 5;
            this.gbNotChecked.TabStop = false;
            this.gbNotChecked.Text = "未考勤";
            // 
            // gbChecked
            // 
            this.gbChecked.Controls.Add(this.dgvChecked);
            this.gbChecked.Location = new System.Drawing.Point(303, 248);
            this.gbChecked.Name = "gbChecked";
            this.gbChecked.Size = new System.Drawing.Size(395, 240);
            this.gbChecked.TabIndex = 6;
            this.gbChecked.TabStop = false;
            this.gbChecked.Text = "已考勤";
            // 
            // dgvNotChecked
            // 
            this.dgvNotChecked.AllowUserToAddRows = false;
            this.dgvNotChecked.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNotChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNotChecked.Location = new System.Drawing.Point(3, 17);
            this.dgvNotChecked.Name = "dgvNotChecked";
            this.dgvNotChecked.ReadOnly = true;
            this.dgvNotChecked.RowTemplate.Height = 23;
            this.dgvNotChecked.Size = new System.Drawing.Size(389, 210);
            this.dgvNotChecked.TabIndex = 0;
            // 
            // dgvChecked
            // 
            this.dgvChecked.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChecked.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvChecked.Location = new System.Drawing.Point(3, 17);
            this.dgvChecked.Name = "dgvChecked";
            this.dgvChecked.ReadOnly = true;
            this.dgvChecked.RowTemplate.Height = 23;
            this.dgvChecked.Size = new System.Drawing.Size(389, 220);
            this.dgvChecked.TabIndex = 0;
            // 
            // matrixCircularProgressControl1
            // 
            this.matrixCircularProgressControl1.BackColor = System.Drawing.Color.Transparent;
            this.matrixCircularProgressControl1.Interval = 60;
            this.matrixCircularProgressControl1.Location = new System.Drawing.Point(115, 277);
            this.matrixCircularProgressControl1.MinimumSize = new System.Drawing.Size(28, 28);
            this.matrixCircularProgressControl1.Name = "matrixCircularProgressControl1";
            this.matrixCircularProgressControl1.Rotation = LogisTechBase.MatrixCircularProgressControl.Direction.CLOCKWISE;
            this.matrixCircularProgressControl1.Size = new System.Drawing.Size(84, 80);
            this.matrixCircularProgressControl1.StartAngle = 270F;
            this.matrixCircularProgressControl1.TabIndex = 4;
            this.matrixCircularProgressControl1.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            // 
            // frmUserIdentify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 524);
            this.Controls.Add(this.gbChecked);
            this.Controls.Add(this.gbNotChecked);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.matrixCircularProgressControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmUserIdentify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "正在考勤";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbNotChecked.ResumeLayout(false);
            this.gbChecked.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNotChecked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChecked)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LogisTechBase.MatrixCircularProgressControl matrixCircularProgressControl1;
        private System.Windows.Forms.GroupBox gbNotChecked;
        private System.Windows.Forms.GroupBox gbChecked;
        private System.Windows.Forms.DataGridView dgvNotChecked;
        private System.Windows.Forms.DataGridView dgvChecked;
    }
}