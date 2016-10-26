namespace scan
{
    partial class AddForm
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
            this.styleButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.styleComboBox = new System.Windows.Forms.ComboBox();
            this.tbIdcard = new System.Windows.Forms.TextBox();
            this.lbIdCard = new System.Windows.Forms.Label();
            this.cbOutHospStatus = new System.Windows.Forms.ComboBox();
            this.tbDoctor = new System.Windows.Forms.TextBox();
            this.lbDoctor = new System.Windows.Forms.Label();
            this.lbOutHospDept = new System.Windows.Forms.Label();
            this.tbInhosDia = new System.Windows.Forms.TextBox();
            this.lbInhosDia = new System.Windows.Forms.Label();
            this.tbOutHospDia = new System.Windows.Forms.TextBox();
            this.cbInhosStatus = new System.Windows.Forms.ComboBox();
            this.dtOutHosp = new System.Windows.Forms.DateTimePicker();
            this.lbOutHospDia = new System.Windows.Forms.Label();
            this.lbOutHospDate = new System.Windows.Forms.Label();
            this.lbInhosStatus = new System.Windows.Forms.Label();
            this.tbOutDept = new System.Windows.Forms.TextBox();
            this.dtInhos = new System.Windows.Forms.DateTimePicker();
            this.lbOutDept = new System.Windows.Forms.Label();
            this.lbInhosDate = new System.Windows.Forms.Label();
            this.tbInhosDept = new System.Windows.Forms.TextBox();
            this.lbInhosDept = new System.Windows.Forms.Label();
            this.cbInhosType = new System.Windows.Forms.ComboBox();
            this.lbInhosType = new System.Windows.Forms.Label();
            this.tbInhosOrg = new System.Windows.Forms.TextBox();
            this.lbInhosOrg = new System.Windows.Forms.Label();
            this.tbInhosNum = new System.Windows.Forms.TextBox();
            this.lbInhosnum = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbMcard = new System.Windows.Forms.TextBox();
            this.lbMcard = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.itemSearch1 = new scan.ItemSearch();
            this.label2 = new System.Windows.Forms.Label();
            this.InhospGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // InhospGroupBox
            // 
            this.InhospGroupBox.Controls.Add(this.styleButton);
            this.InhospGroupBox.Controls.Add(this.label1);
            this.InhospGroupBox.Controls.Add(this.styleComboBox);
            this.InhospGroupBox.Controls.Add(this.tbInhosNum);
            this.InhospGroupBox.Controls.Add(this.lbInhosnum);
            this.InhospGroupBox.Controls.Add(this.tbName);
            this.InhospGroupBox.Controls.Add(this.lbName);
            this.InhospGroupBox.Controls.Add(this.tbMcard);
            this.InhospGroupBox.Controls.Add(this.lbMcard);
            this.InhospGroupBox.Location = new System.Drawing.Point(12, 12);
            this.InhospGroupBox.Name = "InhospGroupBox";
            this.InhospGroupBox.Size = new System.Drawing.Size(686, 105);
            this.InhospGroupBox.TabIndex = 0;
            this.InhospGroupBox.TabStop = false;
            this.InhospGroupBox.Text = "住院信息";
            // 
            // styleButton
            // 
            this.styleButton.Location = new System.Drawing.Point(555, 56);
            this.styleButton.Name = "styleButton";
            this.styleButton.Size = new System.Drawing.Size(112, 23);
            this.styleButton.TabIndex = 33;
            this.styleButton.Text = "自定义样式..";
            this.styleButton.UseVisualStyleBackColor = true;
            this.styleButton.Click += new System.EventHandler(this.styleButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label1.Location = new System.Drawing.Point(6, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "单据样式:";
            // 
            // styleComboBox
            // 
            this.styleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.styleComboBox.FormattingEnabled = true;
            this.styleComboBox.Items.AddRange(new object[] {
            "代码，名称，规格"});
            this.styleComboBox.Location = new System.Drawing.Point(70, 58);
            this.styleComboBox.Name = "styleComboBox";
            this.styleComboBox.Size = new System.Drawing.Size(479, 20);
            this.styleComboBox.TabIndex = 32;
            // 
            // tbIdcard
            // 
            this.tbIdcard.Location = new System.Drawing.Point(82, 319);
            this.tbIdcard.Name = "tbIdcard";
            this.tbIdcard.Size = new System.Drawing.Size(102, 21);
            this.tbIdcard.TabIndex = 5;
            this.tbIdcard.Visible = false;
            // 
            // lbIdCard
            // 
            this.lbIdCard.AutoSize = true;
            this.lbIdCard.Location = new System.Drawing.Point(18, 325);
            this.lbIdCard.Name = "lbIdCard";
            this.lbIdCard.Size = new System.Drawing.Size(59, 12);
            this.lbIdCard.TabIndex = 28;
            this.lbIdCard.Text = "身份证号:";
            this.lbIdCard.Visible = false;
            // 
            // cbOutHospStatus
            // 
            this.cbOutHospStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutHospStatus.FormattingEnabled = true;
            this.cbOutHospStatus.Location = new System.Drawing.Point(535, 449);
            this.cbOutHospStatus.Name = "cbOutHospStatus";
            this.cbOutHospStatus.Size = new System.Drawing.Size(149, 20);
            this.cbOutHospStatus.TabIndex = 16;
            this.cbOutHospStatus.Visible = false;
            // 
            // tbDoctor
            // 
            this.tbDoctor.Location = new System.Drawing.Point(272, 451);
            this.tbDoctor.Name = "tbDoctor";
            this.tbDoctor.Size = new System.Drawing.Size(171, 21);
            this.tbDoctor.TabIndex = 15;
            this.tbDoctor.Visible = false;
            // 
            // lbDoctor
            // 
            this.lbDoctor.AutoSize = true;
            this.lbDoctor.Location = new System.Drawing.Point(215, 454);
            this.lbDoctor.Name = "lbDoctor";
            this.lbDoctor.Size = new System.Drawing.Size(59, 12);
            this.lbDoctor.TabIndex = 11;
            this.lbDoctor.Text = "经治医师:";
            this.lbDoctor.Visible = false;
            // 
            // lbOutHospDept
            // 
            this.lbOutHospDept.AutoSize = true;
            this.lbOutHospDept.Location = new System.Drawing.Point(482, 452);
            this.lbOutHospDept.Name = "lbOutHospDept";
            this.lbOutHospDept.Size = new System.Drawing.Size(59, 12);
            this.lbOutHospDept.TabIndex = 23;
            this.lbOutHospDept.Text = "出院状态:";
            this.lbOutHospDept.Visible = false;
            // 
            // tbInhosDia
            // 
            this.tbInhosDia.Location = new System.Drawing.Point(84, 418);
            this.tbInhosDia.Name = "tbInhosDia";
            this.tbInhosDia.Size = new System.Drawing.Size(100, 21);
            this.tbInhosDia.TabIndex = 11;
            this.tbInhosDia.Visible = false;
            this.tbInhosDia.TextChanged += new System.EventHandler(this.tbInhosDia_TextChanged_1);
            this.tbInhosDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInhosDept_KeyDown);
            this.tbInhosDia.Leave += new System.EventHandler(this.tbInhosDept_Leave);
            // 
            // lbInhosDia
            // 
            this.lbInhosDia.AutoSize = true;
            this.lbInhosDia.Location = new System.Drawing.Point(19, 421);
            this.lbInhosDia.Name = "lbInhosDia";
            this.lbInhosDia.Size = new System.Drawing.Size(59, 12);
            this.lbInhosDia.TabIndex = 19;
            this.lbInhosDia.Text = "入院诊断:";
            this.lbInhosDia.Visible = false;
            // 
            // tbOutHospDia
            // 
            this.tbOutHospDia.Location = new System.Drawing.Point(272, 416);
            this.tbOutHospDia.Name = "tbOutHospDia";
            this.tbOutHospDia.Size = new System.Drawing.Size(171, 21);
            this.tbOutHospDia.TabIndex = 12;
            this.tbOutHospDia.Visible = false;
            this.tbOutHospDia.TextChanged += new System.EventHandler(this.tbOutHospDia_TextChanged);
            this.tbOutHospDia.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInhosDept_KeyDown);
            this.tbOutHospDia.Leave += new System.EventHandler(this.tbInhosDept_Leave);
            // 
            // cbInhosStatus
            // 
            this.cbInhosStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInhosStatus.FormattingEnabled = true;
            this.cbInhosStatus.Location = new System.Drawing.Point(535, 366);
            this.cbInhosStatus.Name = "cbInhosStatus";
            this.cbInhosStatus.Size = new System.Drawing.Size(149, 20);
            this.cbInhosStatus.TabIndex = 10;
            this.cbInhosStatus.Visible = false;
            // 
            // dtOutHosp
            // 
            this.dtOutHosp.CustomFormat = "yyyy-mm-dd";
            this.dtOutHosp.Location = new System.Drawing.Point(84, 450);
            this.dtOutHosp.Name = "dtOutHosp";
            this.dtOutHosp.Size = new System.Drawing.Size(100, 21);
            this.dtOutHosp.TabIndex = 14;
            this.dtOutHosp.Visible = false;
            // 
            // lbOutHospDia
            // 
            this.lbOutHospDia.AutoSize = true;
            this.lbOutHospDia.Location = new System.Drawing.Point(215, 419);
            this.lbOutHospDia.Name = "lbOutHospDia";
            this.lbOutHospDia.Size = new System.Drawing.Size(59, 12);
            this.lbOutHospDia.TabIndex = 25;
            this.lbOutHospDia.Text = "出院诊断:";
            this.lbOutHospDia.Visible = false;
            // 
            // lbOutHospDate
            // 
            this.lbOutHospDate.AutoSize = true;
            this.lbOutHospDate.Location = new System.Drawing.Point(19, 456);
            this.lbOutHospDate.Name = "lbOutHospDate";
            this.lbOutHospDate.Size = new System.Drawing.Size(59, 12);
            this.lbOutHospDate.TabIndex = 21;
            this.lbOutHospDate.Text = "出院时间:";
            this.lbOutHospDate.Visible = false;
            // 
            // lbInhosStatus
            // 
            this.lbInhosStatus.AutoSize = true;
            this.lbInhosStatus.Location = new System.Drawing.Point(482, 369);
            this.lbInhosStatus.Name = "lbInhosStatus";
            this.lbInhosStatus.Size = new System.Drawing.Size(59, 12);
            this.lbInhosStatus.TabIndex = 17;
            this.lbInhosStatus.Text = "入院状态:";
            this.lbInhosStatus.Visible = false;
            // 
            // tbOutDept
            // 
            this.tbOutDept.Location = new System.Drawing.Point(535, 411);
            this.tbOutDept.Name = "tbOutDept";
            this.tbOutDept.Size = new System.Drawing.Size(149, 21);
            this.tbOutDept.TabIndex = 13;
            this.tbOutDept.Visible = false;
            this.tbOutDept.TextChanged += new System.EventHandler(this.tbOutDept_TextChanged);
            this.tbOutDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInhosDept_KeyDown);
            this.tbOutDept.Leave += new System.EventHandler(this.tbInhosDept_Leave);
            // 
            // dtInhos
            // 
            this.dtInhos.CustomFormat = "yyyy-mm-dd";
            this.dtInhos.Location = new System.Drawing.Point(272, 371);
            this.dtInhos.Name = "dtInhos";
            this.dtInhos.Size = new System.Drawing.Size(171, 21);
            this.dtInhos.TabIndex = 9;
            this.dtInhos.Visible = false;
            // 
            // lbOutDept
            // 
            this.lbOutDept.AutoSize = true;
            this.lbOutDept.Location = new System.Drawing.Point(482, 414);
            this.lbOutDept.Name = "lbOutDept";
            this.lbOutDept.Size = new System.Drawing.Size(59, 12);
            this.lbOutDept.TabIndex = 19;
            this.lbOutDept.Text = "出院科室:";
            this.lbOutDept.Visible = false;
            // 
            // lbInhosDate
            // 
            this.lbInhosDate.AutoSize = true;
            this.lbInhosDate.Location = new System.Drawing.Point(215, 374);
            this.lbInhosDate.Name = "lbInhosDate";
            this.lbInhosDate.Size = new System.Drawing.Size(59, 12);
            this.lbInhosDate.TabIndex = 15;
            this.lbInhosDate.Text = "入院时间:";
            this.lbInhosDate.Visible = false;
            // 
            // tbInhosDept
            // 
            this.tbInhosDept.Location = new System.Drawing.Point(84, 373);
            this.tbInhosDept.Name = "tbInhosDept";
            this.tbInhosDept.Size = new System.Drawing.Size(100, 21);
            this.tbInhosDept.TabIndex = 8;
            this.tbInhosDept.Visible = false;
            this.tbInhosDept.TextChanged += new System.EventHandler(this.tbInhosDept_TextChanged);
            this.tbInhosDept.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInhosDept_KeyDown);
            this.tbInhosDept.Leave += new System.EventHandler(this.tbInhosDept_Leave);
            // 
            // lbInhosDept
            // 
            this.lbInhosDept.AutoSize = true;
            this.lbInhosDept.Location = new System.Drawing.Point(16, 376);
            this.lbInhosDept.Name = "lbInhosDept";
            this.lbInhosDept.Size = new System.Drawing.Size(59, 12);
            this.lbInhosDept.TabIndex = 13;
            this.lbInhosDept.Text = "入院科室:";
            this.lbInhosDept.Visible = false;
            // 
            // cbInhosType
            // 
            this.cbInhosType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInhosType.FormattingEnabled = true;
            this.cbInhosType.Location = new System.Drawing.Point(539, 318);
            this.cbInhosType.Name = "cbInhosType";
            this.cbInhosType.Size = new System.Drawing.Size(145, 20);
            this.cbInhosType.TabIndex = 7;
            this.cbInhosType.Visible = false;
            // 
            // lbInhosType
            // 
            this.lbInhosType.AutoSize = true;
            this.lbInhosType.Location = new System.Drawing.Point(482, 318);
            this.lbInhosType.Name = "lbInhosType";
            this.lbInhosType.Size = new System.Drawing.Size(59, 12);
            this.lbInhosType.TabIndex = 9;
            this.lbInhosType.Text = "住院类型:";
            this.lbInhosType.Visible = false;
            // 
            // tbInhosOrg
            // 
            this.tbInhosOrg.Location = new System.Drawing.Point(272, 321);
            this.tbInhosOrg.Name = "tbInhosOrg";
            this.tbInhosOrg.Size = new System.Drawing.Size(171, 21);
            this.tbInhosOrg.TabIndex = 6;
            this.tbInhosOrg.Visible = false;
            this.tbInhosOrg.TextChanged += new System.EventHandler(this.tbInhosOrg_TextChanged);
            this.tbInhosOrg.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInhosDept_KeyDown);
            this.tbInhosOrg.Leave += new System.EventHandler(this.tbInhosDept_Leave);
            // 
            // lbInhosOrg
            // 
            this.lbInhosOrg.AutoSize = true;
            this.lbInhosOrg.Location = new System.Drawing.Point(215, 324);
            this.lbInhosOrg.Name = "lbInhosOrg";
            this.lbInhosOrg.Size = new System.Drawing.Size(59, 12);
            this.lbInhosOrg.TabIndex = 7;
            this.lbInhosOrg.Text = "就诊机构:";
            this.lbInhosOrg.Visible = false;
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
            this.btnSave.Location = new System.Drawing.Point(241, 152);
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
            this.btnCancel.Location = new System.Drawing.Point(404, 152);
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
            // itemSearch1
            // 
            this.itemSearch1.AutoScroll = true;
            this.itemSearch1.ControlId = null;
            this.itemSearch1.Count = 0;
            this.itemSearch1.Location = new System.Drawing.Point(773, 136);
            this.itemSearch1.Name = "itemSearch1";
            this.itemSearch1.SearchText = null;
            this.itemSearch1.SearchType = null;
            this.itemSearch1.Size = new System.Drawing.Size(300, 166);
            this.itemSearch1.TabIndex = 18;
            this.itemSearch1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.LightCoral;
            this.label2.Location = new System.Drawing.Point(61, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 12);
            this.label2.TabIndex = 19;
            this.label2.Text = "注：蓝色字体为必填项";
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 196);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.itemSearch1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tbIdcard);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbIdCard);
            this.Controls.Add(this.InhospGroupBox);
            this.Controls.Add(this.cbOutHospStatus);
            this.Controls.Add(this.lbInhosDate);
            this.Controls.Add(this.tbDoctor);
            this.Controls.Add(this.lbInhosOrg);
            this.Controls.Add(this.lbDoctor);
            this.Controls.Add(this.tbInhosOrg);
            this.Controls.Add(this.lbOutHospDept);
            this.Controls.Add(this.lbInhosType);
            this.Controls.Add(this.tbInhosDia);
            this.Controls.Add(this.cbInhosType);
            this.Controls.Add(this.lbInhosDia);
            this.Controls.Add(this.lbInhosDept);
            this.Controls.Add(this.tbOutHospDia);
            this.Controls.Add(this.tbInhosDept);
            this.Controls.Add(this.cbInhosStatus);
            this.Controls.Add(this.lbOutDept);
            this.Controls.Add(this.dtOutHosp);
            this.Controls.Add(this.dtInhos);
            this.Controls.Add(this.lbOutHospDia);
            this.Controls.Add(this.tbOutDept);
            this.Controls.Add(this.lbOutHospDate);
            this.Controls.Add(this.lbInhosStatus);
            this.Name = "AddForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "外诊登记";
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
        private System.Windows.Forms.Label lbInhosOrg;
        private System.Windows.Forms.TextBox tbInhosOrg;
        private System.Windows.Forms.ComboBox cbInhosType;
        private System.Windows.Forms.Label lbInhosType;
        private System.Windows.Forms.Label lbDoctor;
        private System.Windows.Forms.TextBox tbDoctor;
        private System.Windows.Forms.TextBox tbInhosDept;
        private System.Windows.Forms.Label lbInhosDept;
        private System.Windows.Forms.DateTimePicker dtInhos;
        private System.Windows.Forms.Label lbInhosDate;
        private System.Windows.Forms.Label lbInhosStatus;
        private System.Windows.Forms.ComboBox cbInhosStatus;
        private System.Windows.Forms.TextBox tbInhosDia;
        private System.Windows.Forms.Label lbInhosDia;
        private System.Windows.Forms.ComboBox cbOutHospStatus;
        private System.Windows.Forms.Label lbOutHospDept;
        private System.Windows.Forms.DateTimePicker dtOutHosp;
        private System.Windows.Forms.Label lbOutHospDate;
        private System.Windows.Forms.TextBox tbOutDept;
        private System.Windows.Forms.Label lbOutDept;
        private System.Windows.Forms.TextBox tbOutHospDia;
        private System.Windows.Forms.Label lbOutHospDia;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox tbIdcard;
        private System.Windows.Forms.Label lbIdCard;
        private ItemSearch itemSearch1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button styleButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox styleComboBox;
        private System.Windows.Forms.Label label2;
    }
}