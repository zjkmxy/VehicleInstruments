namespace mainProject
{
    partial class main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
			this.rawPanel = new System.Windows.Forms.Panel();
			this.rawPictureDisplay = new System.Windows.Forms.PictureBox();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.菜单ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.打开ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.保存ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.处理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.数字式仪表盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.指针式仪表盘ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.rawPanel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.rawPictureDisplay)).BeginInit();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// rawPanel
			// 
			this.rawPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rawPanel.Controls.Add(this.rawPictureDisplay);
			this.rawPanel.Location = new System.Drawing.Point(0, 28);
			this.rawPanel.Name = "rawPanel";
			this.rawPanel.Size = new System.Drawing.Size(617, 407);
			this.rawPanel.TabIndex = 0;
			// 
			// rawPictureDisplay
			// 
			this.rawPictureDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.rawPictureDisplay.Location = new System.Drawing.Point(0, 0);
			this.rawPictureDisplay.Name = "rawPictureDisplay";
			this.rawPictureDisplay.Size = new System.Drawing.Size(617, 407);
			this.rawPictureDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.rawPictureDisplay.TabIndex = 0;
			this.rawPictureDisplay.TabStop = false;
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.菜单ToolStripMenuItem,
            this.处理ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(617, 25);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 菜单ToolStripMenuItem
			// 
			this.菜单ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.打开ToolStripMenuItem,
            this.保存ToolStripMenuItem,
            this.退出ToolStripMenuItem});
			this.菜单ToolStripMenuItem.Name = "菜单ToolStripMenuItem";
			this.菜单ToolStripMenuItem.Size = new System.Drawing.Size(58, 21);
			this.菜单ToolStripMenuItem.Text = "文件(&F)";
			// 
			// 打开ToolStripMenuItem
			// 
			this.打开ToolStripMenuItem.Name = "打开ToolStripMenuItem";
			this.打开ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.打开ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.打开ToolStripMenuItem.Text = "打开";
			this.打开ToolStripMenuItem.Click += new System.EventHandler(this.打开ToolStripMenuItem_Click);
			// 
			// 保存ToolStripMenuItem
			// 
			this.保存ToolStripMenuItem.Name = "保存ToolStripMenuItem";
			this.保存ToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.保存ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.保存ToolStripMenuItem.Text = "保存";
			this.保存ToolStripMenuItem.Click += new System.EventHandler(this.保存ToolStripMenuItem_Click);
			// 
			// 处理ToolStripMenuItem
			// 
			this.处理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数字式仪表盘ToolStripMenuItem,
            this.指针式仪表盘ToolStripMenuItem});
			this.处理ToolStripMenuItem.Name = "处理ToolStripMenuItem";
			this.处理ToolStripMenuItem.Size = new System.Drawing.Size(59, 21);
			this.处理ToolStripMenuItem.Text = "处理(&P)";
			// 
			// 数字式仪表盘ToolStripMenuItem
			// 
			this.数字式仪表盘ToolStripMenuItem.Name = "数字式仪表盘ToolStripMenuItem";
			this.数字式仪表盘ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.数字式仪表盘ToolStripMenuItem.Text = "数字式仪表盘(&N)";
			this.数字式仪表盘ToolStripMenuItem.Click += new System.EventHandler(this.数字式仪表盘ToolStripMenuItem_Click);
			// 
			// 指针式仪表盘ToolStripMenuItem
			// 
			this.指针式仪表盘ToolStripMenuItem.Name = "指针式仪表盘ToolStripMenuItem";
			this.指针式仪表盘ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.指针式仪表盘ToolStripMenuItem.Text = "指针式仪表盘(&H)";
			this.指针式仪表盘ToolStripMenuItem.Click += new System.EventHandler(this.指针式仪表盘ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(617, 435);
			this.Controls.Add(this.rawPanel);
			this.Controls.Add(this.menuStrip1);
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "main";
			this.Text = "汽车仪表识别系统";
			this.rawPanel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.rawPictureDisplay)).EndInit();
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel rawPanel;
        private System.Windows.Forms.PictureBox rawPictureDisplay;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 菜单ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 打开ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 保存ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 处理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数字式仪表盘ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指针式仪表盘ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
    }
}

