namespace mainProject
{
    partial class inPut
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
			this.label0 = new System.Windows.Forms.Label();
			this.smallInput = new System.Windows.Forms.TextBox();
			this.largeInput = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.confirmButton = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label0
			// 
			this.label0.AutoSize = true;
			this.label0.Location = new System.Drawing.Point(43, 19);
			this.label0.Name = "label0";
			this.label0.Size = new System.Drawing.Size(209, 12);
			this.label0.TabIndex = 0;
			this.label0.Text = "请在下方输入仪表盘的最小最大刻度值";
			// 
			// smallInput
			// 
			this.smallInput.Location = new System.Drawing.Point(152, 54);
			this.smallInput.Name = "smallInput";
			this.smallInput.Size = new System.Drawing.Size(100, 21);
			this.smallInput.TabIndex = 1;
			// 
			// largeInput
			// 
			this.largeInput.Location = new System.Drawing.Point(152, 101);
			this.largeInput.Name = "largeInput";
			this.largeInput.Size = new System.Drawing.Size(100, 21);
			this.largeInput.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(43, 63);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(77, 12);
			this.label1.TabIndex = 3;
			this.label1.Text = "最小刻度值：";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(43, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(77, 12);
			this.label2.TabIndex = 4;
			this.label2.Text = "最大刻度值：";
			// 
			// confirmButton
			// 
			this.confirmButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.confirmButton.Location = new System.Drawing.Point(57, 153);
			this.confirmButton.Name = "confirmButton";
			this.confirmButton.Size = new System.Drawing.Size(75, 23);
			this.confirmButton.TabIndex = 5;
			this.confirmButton.Text = "确定";
			this.confirmButton.UseVisualStyleBackColor = true;
			this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
			// 
			// buttonCancel
			// 
			this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(161, 153);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 23);
			this.buttonCancel.TabIndex = 6;
			this.buttonCancel.Text = "取消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			// 
			// inPut
			// 
			this.AcceptButton = this.confirmButton;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.buttonCancel;
			this.ClientSize = new System.Drawing.Size(284, 188);
			this.Controls.Add(this.buttonCancel);
			this.Controls.Add(this.confirmButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.largeInput);
			this.Controls.Add(this.smallInput);
			this.Controls.Add(this.label0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "inPut";
			this.Text = "参数输入";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label0;
        private System.Windows.Forms.TextBox smallInput;
        private System.Windows.Forms.TextBox largeInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button confirmButton;
		private System.Windows.Forms.Button buttonCancel;
    }
}