namespace scan
{
    partial class NavForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.userPictureBox = new System.Windows.Forms.PictureBox();
            this.configPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Location = new System.Drawing.Point(47, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(426, 370);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "主菜单";
            // 
            // userPictureBox
            // 
            this.userPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("userPictureBox.BackgroundImage")));
            this.userPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.userPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.userPictureBox.Location = new System.Drawing.Point(20, 3);
            this.userPictureBox.Name = "userPictureBox";
            this.userPictureBox.Size = new System.Drawing.Size(126, 121);
            this.userPictureBox.TabIndex = 0;
            this.userPictureBox.TabStop = false;
            this.userPictureBox.Tag = "";
            this.userPictureBox.Click += new System.EventHandler(this.userPictureBox_Click);
            // 
            // configPictureBox
            // 
            this.configPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("configPictureBox.BackgroundImage")));
            this.configPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.configPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.configPictureBox.Location = new System.Drawing.Point(20, 0);
            this.configPictureBox.Name = "configPictureBox";
            this.configPictureBox.Size = new System.Drawing.Size(126, 125);
            this.configPictureBox.TabIndex = 1;
            this.configPictureBox.TabStop = false;
            this.configPictureBox.Click += new System.EventHandler(this.configPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "用户管理";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.userPictureBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(23, 20);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(180, 143);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.configPictureBox);
            this.panel2.Location = new System.Drawing.Point(23, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(180, 150);
            this.panel2.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "配置管理";
            // 
            // NavForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(519, 430);
            this.Controls.Add(this.groupBox1);
            this.Name = "NavForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主菜单";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.userPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.configPictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox configPictureBox;
        private System.Windows.Forms.PictureBox userPictureBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}