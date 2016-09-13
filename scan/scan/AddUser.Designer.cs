namespace scan
{
    partial class AddUser
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.forbidRadioButton = new System.Windows.Forms.RadioButton();
            this.startRadioButton = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.tbUserPassWord = new System.Windows.Forms.TextBox();
            this.tbUserCode = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbUserName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOrg = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbSite = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbSite);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.forbidRadioButton);
            this.groupBox1.Controls.Add(this.startRadioButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tbUserPassWord);
            this.groupBox1.Controls.Add(this.tbUserCode);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbUserName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tbOrg);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(427, 256);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "用户信息";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 186);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 12;
            this.btnClear.TabStop = false;
            this.btnClear.Text = "重 置";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(95, 186);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保 存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // forbidRadioButton
            // 
            this.forbidRadioButton.AutoSize = true;
            this.forbidRadioButton.Location = new System.Drawing.Point(133, 136);
            this.forbidRadioButton.Name = "forbidRadioButton";
            this.forbidRadioButton.Size = new System.Drawing.Size(47, 16);
            this.forbidRadioButton.TabIndex = 10;
            this.forbidRadioButton.Text = "禁用";
            this.forbidRadioButton.UseVisualStyleBackColor = true;
            // 
            // startRadioButton
            // 
            this.startRadioButton.AutoSize = true;
            this.startRadioButton.Checked = true;
            this.startRadioButton.Location = new System.Drawing.Point(80, 136);
            this.startRadioButton.Name = "startRadioButton";
            this.startRadioButton.Size = new System.Drawing.Size(47, 16);
            this.startRadioButton.TabIndex = 9;
            this.startRadioButton.TabStop = true;
            this.startRadioButton.Text = "启用";
            this.startRadioButton.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "状态：";
            // 
            // tbUserPassWord
            // 
            this.tbUserPassWord.Location = new System.Drawing.Point(288, 86);
            this.tbUserPassWord.Name = "tbUserPassWord";
            this.tbUserPassWord.PasswordChar = '*';
            this.tbUserPassWord.Size = new System.Drawing.Size(100, 21);
            this.tbUserPassWord.TabIndex = 7;
            this.tbUserPassWord.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbUserPassWord_KeyPress);
            // 
            // tbUserCode
            // 
            this.tbUserCode.Location = new System.Drawing.Point(80, 86);
            this.tbUserCode.Name = "tbUserCode";
            this.tbUserCode.Size = new System.Drawing.Size(100, 21);
            this.tbUserCode.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(217, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "密    码：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "用户账号：";
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(288, 36);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.Size = new System.Drawing.Size(100, 21);
            this.tbUserName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "用户姓名：";
            // 
            // tbOrg
            // 
            this.tbOrg.Location = new System.Drawing.Point(80, 37);
            this.tbOrg.Name = "tbOrg";
            this.tbOrg.ReadOnly = true;
            this.tbOrg.Size = new System.Drawing.Size(100, 21);
            this.tbOrg.TabIndex = 99;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "所属机构：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(219, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 100;
            this.label6.Text = "站   点：";
            // 
            // tbSite
            // 
            this.tbSite.Location = new System.Drawing.Point(288, 132);
            this.tbSite.Name = "tbSite";
            this.tbSite.Size = new System.Drawing.Size(100, 21);
            this.tbSite.TabIndex = 101;
            // 
            // AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 283);
            this.Controls.Add(this.groupBox1);
            this.Name = "AddUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户信息";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddUser_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.RadioButton forbidRadioButton;
        private System.Windows.Forms.RadioButton startRadioButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbUserPassWord;
        private System.Windows.Forms.TextBox tbUserCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbOrg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSite;
        private System.Windows.Forms.Label label6;
    }
}