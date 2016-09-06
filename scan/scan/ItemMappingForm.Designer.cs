namespace scan
{
    partial class ItemMappingForm
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
            this.DetailGridView = new System.Windows.Forms.DataGridView();
            this.checkbox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.paydate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.centername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.查询 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btnfc = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnMap = new System.Windows.Forms.Button();
            this.itemSearch1 = new scan.ItemSearch();
            this.button7 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DetailGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // DetailGridView
            // 
            this.DetailGridView.AllowUserToAddRows = false;
            this.DetailGridView.AllowUserToOrderColumns = true;
            this.DetailGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.checkbox,
            this.paydate,
            this.code,
            this.name,
            this.price,
            this.qua,
            this.totalprice,
            this.centername});
            this.DetailGridView.Location = new System.Drawing.Point(12, 27);
            this.DetailGridView.MultiSelect = false;
            this.DetailGridView.Name = "DetailGridView";
            this.DetailGridView.RowHeadersVisible = false;
            this.DetailGridView.RowTemplate.Height = 23;
            this.DetailGridView.Size = new System.Drawing.Size(643, 319);
            this.DetailGridView.TabIndex = 0;
            this.DetailGridView.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DetailGridView_EditingControlShowing);
            // 
            // checkbox
            // 
            this.checkbox.FalseValue = "0";
            this.checkbox.HeaderText = "";
            this.checkbox.Name = "checkbox";
            this.checkbox.ToolTipText = "选中行";
            this.checkbox.TrueValue = "1";
            this.checkbox.Width = 50;
            // 
            // paydate
            // 
            this.paydate.DataPropertyName = "paydate";
            this.paydate.HeaderText = "收费日期";
            this.paydate.Name = "paydate";
            // 
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "项目编码";
            this.code.Name = "code";
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "项目名称";
            this.name.Name = "name";
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "单价";
            this.price.Name = "price";
            this.price.Width = 60;
            // 
            // qua
            // 
            this.qua.DataPropertyName = "qua";
            this.qua.HeaderText = "数量";
            this.qua.Name = "qua";
            this.qua.Width = 60;
            // 
            // totalprice
            // 
            this.totalprice.DataPropertyName = "totalprice";
            this.totalprice.HeaderText = "金额";
            this.totalprice.Name = "totalprice";
            this.totalprice.Width = 60;
            // 
            // centername
            // 
            this.centername.DataPropertyName = "centername";
            this.centername.HeaderText = "中心名称";
            this.centername.Name = "centername";
            // 
            // 查询
            // 
            this.查询.Location = new System.Drawing.Point(12, 377);
            this.查询.Name = "查询";
            this.查询.Size = new System.Drawing.Size(75, 23);
            this.查询.TabIndex = 1;
            this.查询.Text = "查询";
            this.查询.UseVisualStyleBackColor = true;
            this.查询.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(206, 377);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "添加行";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(287, 377);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "选中多行";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnfc
            // 
            this.btnfc.Location = new System.Drawing.Point(406, 377);
            this.btnfc.Name = "btnfc";
            this.btnfc.Size = new System.Drawing.Size(75, 23);
            this.btnfc.TabIndex = 4;
            this.btnfc.Text = "盘古分词";
            this.btnfc.UseVisualStyleBackColor = true;
            this.btnfc.Click += new System.EventHandler(this.btnfc_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(43, 424);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(180, 21);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(249, 422);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "查询分词结果";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(499, 377);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "标准分词";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(580, 377);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 8;
            this.button5.Text = "二元分词";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(43, 451);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(180, 21);
            this.textBox2.TabIndex = 9;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(239, 449);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(139, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "test分词";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(107, 377);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnMap
            // 
            this.btnMap.Location = new System.Drawing.Point(406, 422);
            this.btnMap.Name = "btnMap";
            this.btnMap.Size = new System.Drawing.Size(75, 23);
            this.btnMap.TabIndex = 12;
            this.btnMap.Text = "智能匹配";
            this.btnMap.UseVisualStyleBackColor = true;
            this.btnMap.Click += new System.EventHandler(this.btnMap_Click);
            // 
            // itemSearch1
            // 
            this.itemSearch1.ControlId = null;
            this.itemSearch1.Count = 0;
            this.itemSearch1.Location = new System.Drawing.Point(487, 424);
            this.itemSearch1.Name = "itemSearch1";
            this.itemSearch1.SearchText = null;
            this.itemSearch1.SearchType = null;
            this.itemSearch1.Size = new System.Drawing.Size(269, 205);
            this.itemSearch1.TabIndex = 13;
            this.itemSearch1.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(206, 478);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(139, 23);
            this.button7.TabIndex = 14;
            this.button7.Text = "test合计";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // ItemMappingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 521);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.itemSearch1);
            this.Controls.Add(this.btnMap);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnfc);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.查询);
            this.Controls.Add(this.DetailGridView);
            this.Name = "ItemMappingForm";
            this.Text = "ItemMappingForm";
            ((System.ComponentModel.ISupportInitialize)(this.DetailGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DetailGridView;
        private System.Windows.Forms.Button 查询;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btnfc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnMap;
        private ItemSearch itemSearch1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn checkbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn paydate;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn qua;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn centername;
        private System.Windows.Forms.Button button7;
    }
}