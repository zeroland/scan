namespace scan
{
    partial class DictViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DictViewForm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgvDict = new System.Windows.Forms.DataGridView();
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
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.forms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FCOMPUTERATIO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.provprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.counprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemtype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feetype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDict)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.tbCondition);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(944, 538);
            this.splitContainer1.SplitterDistance = 42;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(315, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.button1_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(77, 12);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(190, 21);
            this.tbCondition.TabIndex = 1;
            this.tbCondition.TextChanged += new System.EventHandler(this.tbCondition_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "查询条件:";
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
            this.splitContainer2.Panel1.Controls.Add(this.dgvDict);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(944, 492);
            this.splitContainer2.SplitterDistance = 453;
            this.splitContainer2.TabIndex = 0;
            // 
            // dgvDict
            // 
            this.dgvDict.AllowUserToAddRows = false;
            this.dgvDict.AllowUserToDeleteRows = false;
            this.dgvDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDict.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.code,
            this.name,
            this.forms,
            this.FCOMPUTERATIO,
            this.provprice,
            this.cityprice,
            this.counprice,
            this.itemtype,
            this.feetype});
            this.dgvDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDict.Location = new System.Drawing.Point(0, 0);
            this.dgvDict.Name = "dgvDict";
            this.dgvDict.ReadOnly = true;
            this.dgvDict.RowTemplate.Height = 23;
            this.dgvDict.Size = new System.Drawing.Size(944, 453);
            this.dgvDict.TabIndex = 0;
            this.dgvDict.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvDict_RowPostPaint);
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
            this.toolStrip1.Location = new System.Drawing.Point(280, 4);
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
            // code
            // 
            this.code.DataPropertyName = "code";
            this.code.HeaderText = "项目编码";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "项目名称";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // forms
            // 
            this.forms.DataPropertyName = "forms";
            this.forms.HeaderText = "剂型";
            this.forms.Name = "forms";
            this.forms.ReadOnly = true;
            this.forms.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FCOMPUTERATIO
            // 
            this.FCOMPUTERATIO.DataPropertyName = "FCOMPUTERATIO";
            this.FCOMPUTERATIO.HeaderText = "补偿比例";
            this.FCOMPUTERATIO.Name = "FCOMPUTERATIO";
            this.FCOMPUTERATIO.ReadOnly = true;
            this.FCOMPUTERATIO.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // provprice
            // 
            this.provprice.DataPropertyName = "provprice";
            this.provprice.HeaderText = "省级价格";
            this.provprice.Name = "provprice";
            this.provprice.ReadOnly = true;
            this.provprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // cityprice
            // 
            this.cityprice.DataPropertyName = "cityprice";
            this.cityprice.HeaderText = "市级价格";
            this.cityprice.Name = "cityprice";
            this.cityprice.ReadOnly = true;
            this.cityprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // counprice
            // 
            this.counprice.DataPropertyName = "counprice";
            this.counprice.HeaderText = "县级价格";
            this.counprice.Name = "counprice";
            this.counprice.ReadOnly = true;
            this.counprice.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // itemtype
            // 
            this.itemtype.DataPropertyName = "itemtypename";
            this.itemtype.HeaderText = "项目类型";
            this.itemtype.Name = "itemtype";
            this.itemtype.ReadOnly = true;
            this.itemtype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.itemtype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // feetype
            // 
            this.feetype.DataPropertyName = "feetypename";
            this.feetype.HeaderText = "费用归类";
            this.feetype.Name = "feetype";
            this.feetype.ReadOnly = true;
            this.feetype.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.feetype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // DictViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 538);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "DictViewForm";
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvDict)).EndInit();
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
        private System.Windows.Forms.TextBox tbCondition;
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
        private System.Windows.Forms.DataGridView dgvDict;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn forms;
        private System.Windows.Forms.DataGridViewTextBoxColumn FCOMPUTERATIO;
        private System.Windows.Forms.DataGridViewTextBoxColumn provprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn counprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn itemtype;
        private System.Windows.Forms.DataGridViewTextBoxColumn feetype;
    }
}