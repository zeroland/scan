namespace scan
{
    partial class InhosList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InhosList));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearchDetail = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvInhosList = new System.Windows.Forms.DataGridView();
            this.SelectCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ylzh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.zyh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rysj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cysj = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cyzdname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.guid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.TotalCounttoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.UpPageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CurrentPagetoolStripTextBox = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TotalPagetoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NextPagetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhosList)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btnSearchDetail);
            this.splitContainer1.Panel1.Controls.Add(this.btnDel);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.tbName);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(807, 520);
            this.splitContainer1.SplitterDistance = 40;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSearchDetail
            // 
            this.btnSearchDetail.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchDetail.Image")));
            this.btnSearchDetail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearchDetail.Location = new System.Drawing.Point(307, 12);
            this.btnSearchDetail.Name = "btnSearchDetail";
            this.btnSearchDetail.Size = new System.Drawing.Size(119, 23);
            this.btnSearchDetail.TabIndex = 102;
            this.btnSearchDetail.Text = "查看费用明细";
            this.btnSearchDetail.UseVisualStyleBackColor = true;
            this.btnSearchDetail.Click += new System.EventHandler(this.btnSearchDetail_Click);
            // 
            // btnDel
            // 
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDel.Location = new System.Drawing.Point(448, 11);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(121, 23);
            this.btnDel.TabIndex = 101;
            this.btnDel.Text = "删除患者信息";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(706, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 99;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(89, 13);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(182, 21);
            this.tbName.TabIndex = 0;
            this.tbName.TabStop = false;
            this.tbName.TextChanged += new System.EventHandler(this.tbCondition_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 10;
            this.label1.Text = "查询关键字:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgvInhosList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(807, 476);
            this.splitContainer2.SplitterDistance = 437;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvInhosList
            // 
            this.dgvInhosList.AllowUserToAddRows = false;
            this.dgvInhosList.AllowUserToDeleteRows = false;
            this.dgvInhosList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInhosList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectCheck,
            this.name,
            this.ylzh,
            this.zyh,
            this.totalprice,
            this.rysj,
            this.cysj,
            this.cyzdname,
            this.id,
            this.guid});
            this.dgvInhosList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInhosList.Location = new System.Drawing.Point(0, 0);
            this.dgvInhosList.MultiSelect = false;
            this.dgvInhosList.Name = "dgvInhosList";
            this.dgvInhosList.ReadOnly = true;
            this.dgvInhosList.RowTemplate.Height = 23;
            this.dgvInhosList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvInhosList.Size = new System.Drawing.Size(807, 437);
            this.dgvInhosList.StandardTab = true;
            this.dgvInhosList.TabIndex = 1;
            this.dgvInhosList.TabStop = false;
            this.dgvInhosList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInhosList_CellContentClick);
            this.dgvInhosList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvInhosList_CellContentDoubleClick);
            this.dgvInhosList.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDict_RowPostPaint);
            this.dgvInhosList.Enter += new System.EventHandler(this.dgvInhosList_Enter);
            this.dgvInhosList.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.dgvInhosList_PreviewKeyDown);
            // 
            // SelectCheck
            // 
            this.SelectCheck.HeaderText = "选择";
            this.SelectCheck.Name = "SelectCheck";
            this.SelectCheck.ReadOnly = true;
            this.SelectCheck.Width = 60;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "姓名";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ylzh
            // 
            this.ylzh.DataPropertyName = "ylzh";
            this.ylzh.HeaderText = "医疗证号";
            this.ylzh.Name = "ylzh";
            this.ylzh.ReadOnly = true;
            this.ylzh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // zyh
            // 
            this.zyh.DataPropertyName = "zyh";
            this.zyh.HeaderText = "住院号";
            this.zyh.Name = "zyh";
            this.zyh.ReadOnly = true;
            this.zyh.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // totalprice
            // 
            this.totalprice.DataPropertyName = "totalprice";
            this.totalprice.HeaderText = "总费用";
            this.totalprice.Name = "totalprice";
            this.totalprice.ReadOnly = true;
            this.totalprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // rysj
            // 
            this.rysj.DataPropertyName = "rysj";
            this.rysj.HeaderText = "入院时间";
            this.rysj.Name = "rysj";
            this.rysj.ReadOnly = true;
            this.rysj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cysj
            // 
            this.cysj.DataPropertyName = "cysj";
            this.cysj.HeaderText = "出院时间";
            this.cysj.Name = "cysj";
            this.cysj.ReadOnly = true;
            this.cysj.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cyzdname
            // 
            this.cyzdname.DataPropertyName = "cyzdname";
            this.cyzdname.HeaderText = "出院诊断";
            this.cyzdname.Name = "cyzdname";
            this.cyzdname.ReadOnly = true;
            this.cyzdname.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.id.Visible = false;
            // 
            // guid
            // 
            this.guid.DataPropertyName = "guid";
            this.guid.HeaderText = "guid";
            this.guid.Name = "guid";
            this.guid.ReadOnly = true;
            this.guid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.guid.Visible = false;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2,
            this.TotalCounttoolStripLabel,
            this.toolStripLabel4});
            this.toolStrip2.Location = new System.Drawing.Point(26, 1);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(91, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel2.Text = "共";
            // 
            // TotalCounttoolStripLabel
            // 
            this.TotalCounttoolStripLabel.Name = "TotalCounttoolStripLabel";
            this.TotalCounttoolStripLabel.Size = new System.Drawing.Size(15, 22);
            this.TotalCounttoolStripLabel.Text = "0";
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel4.Text = "条记录";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator3,
            this.UpPageToolStripButton,
            this.toolStripSeparator1,
            this.CurrentPagetoolStripTextBox,
            this.toolStripLabel1,
            this.TotalPagetoolStripLabel,
            this.toolStripSeparator2,
            this.NextPagetoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(286, 1);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(169, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // UpPageToolStripButton
            // 
            this.UpPageToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.UpPageToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("UpPageToolStripButton.Image")));
            this.UpPageToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.UpPageToolStripButton.Name = "UpPageToolStripButton";
            this.UpPageToolStripButton.Size = new System.Drawing.Size(48, 22);
            this.UpPageToolStripButton.Text = "上一页";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // CurrentPagetoolStripTextBox
            // 
            this.CurrentPagetoolStripTextBox.Enabled = false;
            this.CurrentPagetoolStripTextBox.Name = "CurrentPagetoolStripTextBox";
            this.CurrentPagetoolStripTextBox.Size = new System.Drawing.Size(15, 22);
            this.CurrentPagetoolStripTextBox.Text = "1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel1.Text = "/";
            // 
            // TotalPagetoolStripLabel
            // 
            this.TotalPagetoolStripLabel.Enabled = false;
            this.TotalPagetoolStripLabel.Name = "TotalPagetoolStripLabel";
            this.TotalPagetoolStripLabel.Size = new System.Drawing.Size(15, 22);
            this.TotalPagetoolStripLabel.Text = "1";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // NextPagetoolStripButton
            // 
            this.NextPagetoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.NextPagetoolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("NextPagetoolStripButton.Image")));
            this.NextPagetoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NextPagetoolStripButton.Name = "NextPagetoolStripButton";
            this.NextPagetoolStripButton.Size = new System.Drawing.Size(48, 22);
            this.NextPagetoolStripButton.Text = "下一页";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(240, 4);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            this.toolStripContainer1.TopToolStripPanelVisible = false;
            // 
            // InhosList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 520);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "InhosList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查询";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvInhosList)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton UpPageToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel CurrentPagetoolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel TotalPagetoolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton NextPagetoolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripLabel TotalCounttoolStripLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.DataGridView dgvInhosList;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnSearchDetail;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ylzh;
        private System.Windows.Forms.DataGridViewTextBoxColumn zyh;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn rysj;
        private System.Windows.Forms.DataGridViewTextBoxColumn cysj;
        private System.Windows.Forms.DataGridViewTextBoxColumn cyzdname;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn guid;
    }
}