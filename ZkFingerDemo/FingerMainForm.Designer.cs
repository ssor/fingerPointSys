namespace ZkFingerDemo
{
    partial class FingerMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FingerMainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.sensorConnectionState = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.连接指纹仪CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.断开指纹仪DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出XToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.用户识别IToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于AToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本历史VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ZKFPEngX1 = new AxZKFPEngXControl.AxZKFPEngX();
            this.指纹登记RToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.版本说明VToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZKFPEngX1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "设备状态：";
            // 
            // sensorConnectionState
            // 
            this.sensorConnectionState.AutoSize = true;
            this.sensorConnectionState.Location = new System.Drawing.Point(68, 409);
            this.sensorConnectionState.Name = "sensorConnectionState";
            this.sensorConnectionState.Size = new System.Drawing.Size(41, 12);
            this.sensorConnectionState.TabIndex = 1;
            this.sensorConnectionState.Text = "未连接";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件FToolStripMenuItem,
            this.操作ToolStripMenuItem,
            this.关于AToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(726, 25);
            this.menuStrip1.TabIndex = 25;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件FToolStripMenuItem
            // 
            this.文件FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.连接指纹仪CToolStripMenuItem,
            this.断开指纹仪DToolStripMenuItem,
            this.退出XToolStripMenuItem});
            this.文件FToolStripMenuItem.Name = "文件FToolStripMenuItem";
            this.文件FToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
            this.文件FToolStripMenuItem.Text = "设备(&E)";
            // 
            // 连接指纹仪CToolStripMenuItem
            // 
            this.连接指纹仪CToolStripMenuItem.Name = "连接指纹仪CToolStripMenuItem";
            this.连接指纹仪CToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.连接指纹仪CToolStripMenuItem.Text = "连接指纹仪(&C)";
            this.连接指纹仪CToolStripMenuItem.Click += new System.EventHandler(this.连接指纹仪CToolStripMenuItem_Click);
            // 
            // 断开指纹仪DToolStripMenuItem
            // 
            this.断开指纹仪DToolStripMenuItem.Name = "断开指纹仪DToolStripMenuItem";
            this.断开指纹仪DToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.断开指纹仪DToolStripMenuItem.Text = "断开指纹仪(&D)";
            this.断开指纹仪DToolStripMenuItem.Click += new System.EventHandler(this.断开指纹仪DToolStripMenuItem_Click);
            // 
            // 退出XToolStripMenuItem
            // 
            this.退出XToolStripMenuItem.Name = "退出XToolStripMenuItem";
            this.退出XToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.退出XToolStripMenuItem.Text = "退出(&X)";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.指纹登记RToolStripMenuItem,
            this.用户识别IToolStripMenuItem});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.操作ToolStripMenuItem.Text = "操作(&C)";
            // 
            // 用户识别IToolStripMenuItem
            // 
            this.用户识别IToolStripMenuItem.Name = "用户识别IToolStripMenuItem";
            this.用户识别IToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.用户识别IToolStripMenuItem.Text = "用户识别(&I)";
            this.用户识别IToolStripMenuItem.Click += new System.EventHandler(this.用户识别IToolStripMenuItem_Click);
            // 
            // 关于AToolStripMenuItem1
            // 
            this.关于AToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.版本说明VToolStripMenuItem});
            this.关于AToolStripMenuItem1.Name = "关于AToolStripMenuItem1";
            this.关于AToolStripMenuItem1.Size = new System.Drawing.Size(60, 21);
            this.关于AToolStripMenuItem1.Text = "关于(&A)";
            // 
            // 关于AToolStripMenuItem
            // 
            this.关于AToolStripMenuItem.Name = "关于AToolStripMenuItem";
            this.关于AToolStripMenuItem.Size = new System.Drawing.Size(60, 21);
            this.关于AToolStripMenuItem.Text = "关于(&A)";
            // 
            // 版本历史VToolStripMenuItem
            // 
            this.版本历史VToolStripMenuItem.Name = "版本历史VToolStripMenuItem";
            this.版本历史VToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.版本历史VToolStripMenuItem.Text = "版本历史(&V)";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem2.Text = "登记指纹(&R)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
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
            // 
            // 指纹登记RToolStripMenuItem
            // 
            this.指纹登记RToolStripMenuItem.Name = "指纹登记RToolStripMenuItem";
            this.指纹登记RToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.指纹登记RToolStripMenuItem.Text = "指纹登记(&R)";
            this.指纹登记RToolStripMenuItem.Click += new System.EventHandler(this.指纹登记RToolStripMenuItem_Click);
            // 
            // 版本说明VToolStripMenuItem
            // 
            this.版本说明VToolStripMenuItem.Name = "版本说明VToolStripMenuItem";
            this.版本说明VToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.版本说明VToolStripMenuItem.Text = "版本说明(&V)";
            // 
            // FingerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 434);
            this.Controls.Add(this.sensorConnectionState);
            this.Controls.Add(this.ZKFPEngX1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FingerMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "指纹识别";
            this.Load += new System.EventHandler(this.FingerMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ZKFPEngX1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AxZKFPEngXControl.AxZKFPEngX ZKFPEngX1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label sensorConnectionState;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出XToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本历史VToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 断开指纹仪DToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 连接指纹仪CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem 用户识别IToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于AToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 指纹登记RToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 版本说明VToolStripMenuItem;
    }
}