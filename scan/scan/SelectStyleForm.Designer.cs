namespace scan
{
    partial class SelectStyleForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CloseButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.styleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.delButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.styleButton);
            this.groupBox1.Controls.Add(this.styleComboBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(430, 157);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "单据格式";
            // 
            // CloseButton
            // 
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(249, 184);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(83, 23);
            this.CloseButton.TabIndex = 23;
            this.CloseButton.Text = "取 消";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(111, 184);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(84, 23);
            this.okButton.TabIndex = 22;
            this.okButton.Text = "确 定";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Items.AddRange(new object[] {
            "代码，名称，规格"});
            this.styleComboBox.Location = new System.Drawing.Point(16, 61);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(394, 20);
            this.styleComboBox.TabIndex = 30;
            // 
            // styleButton
            // 
            this.styleButton.Location = new System.Drawing.Point(16, 104);
            this.styleButton.Name = "styleButton";
            this.styleButton.Size = new System.Drawing.Size(112, 23);
            this.styleButton.TabIndex = 32;
            this.styleButton.Text = "自定义格式..";
            this.styleButton.UseVisualStyleBackColor = true;
            this.styleButton.Click += new System.EventHandler(this.styleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(329, 12);
            this.label1.TabIndex = 33;
            this.label1.Text = "请在下列选择框中选择单据格式，如果没有请单击自定义格式";
            // 
            // delButton
            // 
            this.delButton.Location = new System.Drawing.Point(148, 104);
            this.delButton.Name = "delButton";
            this.delButton.Size = new System.Drawing.Size(112, 23);
            this.delButton.TabIndex = 34;
            this.delButton.Text = "删除当前格式";
            this.delButton.UseVisualStyleBackColor = true;
            this.delButton.Click += new System.EventHandler(this.delButton_Click);
            // 
            // SelectStyleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 230);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectStyleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "选择单据格式";
            this.Load += new System.EventHandler(this.SelectStyleForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button styleButton;
        private System.Windows.Forms.Button delButton;

    }
}