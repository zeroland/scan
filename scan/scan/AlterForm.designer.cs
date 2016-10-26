namespace scan
{
    partial class AlterForm
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
            this.components = new System.ComponentModel.Container();
            this.InhospGroupBox = new System.Windows.Forms.GroupBox();
            this.tbInhosNum = new System.Windows.Forms.TextBox();
            this.lbInhosnum = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbMcard = new System.Windows.Forms.TextBox();
            this.lbMcard = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.InhospGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InhospGroupBox
            // 
            this.InhospGroupBox.Controls.Add(this.tbInhosNum);
            this.InhospGroupBox.Controls.Add(this.lbInhosnum);
            this.InhospGroupBox.Controls.Add(this.tbName);
            this.InhospGroupBox.Controls.Add(this.lbName);
            this.InhospGroupBox.Controls.Add(this.tbMcard);
            this.InhospGroupBox.Controls.Add(this.lbMcard);
            this.InhospGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InhospGroupBox.Name = "InhospGroupBox";
            this.InhospGroupBox.Size = new System.Drawing.Size(685, 58);
            this.InhospGroupBox.TabIndex = 0;
            this.InhospGroupBox.TabStop = false;
            this.InhospGroupBox.Text = "住院信息";
            // 
            // tbInhosNum
            // 
            this.tbInhosNum.Location = new System.Drawing.Point(529, 16);
            this.tbInhosNum.Name = "tbInhosNum";
            this.tbInhosNum.Size = new System.Drawing.Size(145, 21);
            this.tbInhosNum.TabIndex = 4;
            // 
            // lbInhosnum
            // 
            this.lbInhosnum.AutoSize = true;
            this.lbInhosnum.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbInhosnum.Location = new System.Drawing.Point(472, 20);
            this.lbInhosnum.Name = "lbInhosnum";
            this.lbInhosnum.Size = new System.Drawing.Size(59, 12);
            this.lbInhosnum.TabIndex = 5;
            this.lbInhosnum.Text = "住 院 号:";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(262, 19);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(171, 21);
            this.tbName.TabIndex = 2;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbName.Location = new System.Drawing.Point(203, 24);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(59, 12);
            this.lbName.TabIndex = 2;
            this.lbName.Text = "患者姓名:";
            // 
            // tbMcard
            // 
            this.tbMcard.Location = new System.Drawing.Point(72, 18);
            this.tbMcard.Name = "tbMcard";
            this.tbMcard.Size = new System.Drawing.Size(100, 21);
            this.tbMcard.TabIndex = 1;
            // 
            // lbMcard
            // 
            this.lbMcard.AutoSize = true;
            this.lbMcard.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lbMcard.Location = new System.Drawing.Point(9, 22);
            this.lbMcard.Name = "lbMcard";
            this.lbMcard.Size = new System.Drawing.Size(59, 12);
            this.lbMcard.TabIndex = 0;
            this.lbMcard.Text = "医疗证号:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(228, 97);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.TabStop = false;
            this.btnSave.Text = "保    存 ";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(391, 97);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取    消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightCoral;
            this.label2.Location = new System.Drawing.Point(48, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "注：蓝色字体为必填项";
            // 
            // AlterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 145);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.InhospGroupBox);
            this.Name = "AlterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "外诊信息修改";
            this.Load += new System.EventHandler(this.QuickEntry_Load);
            this.InhospGroupBox.ResumeLayout(false);
            this.InhospGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox InhospGroupBox;
        private System.Windows.Forms.TextBox tbMcard;
        private System.Windows.Forms.Label lbMcard;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.Label lbInhosnum;
        private System.Windows.Forms.TextBox tbInhosNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Label label2;
    }
}