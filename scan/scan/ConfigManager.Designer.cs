namespace scan
{
    partial class ConfigManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigManager));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OrgGroupBox = new System.Windows.Forms.GroupBox();
            this.OrgTreeView = new System.Windows.Forms.TreeView();
            this.UserGroupBox = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.tbCondition = new System.Windows.Forms.TextBox();
            this.btnUpdateStatus = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.dgvConfigInfo = new System.Windows.Forms.DataGridView();
            this.SelectCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.usercode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.username = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orgname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fremark1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.UpPageToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CurrentPagetoolStripTextBox = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.TotalPagetoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.NextPagetoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.TotalCounttoolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.OrgGroupBox.SuspendLayout();
            this.UserGroupBox.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigInfo)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.OrgGroupBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.UserGroupBox);
            this.splitContainer1.Size = new System.Drawing.Size(791, 520);
            this.splitContainer1.SplitterDistance = 209;
            this.splitContainer1.TabIndex = 0;
            // 
            // OrgGroupBox
            // 
            this.OrgGroupBox.Controls.Add(this.OrgTreeView);
            this.OrgGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrgGroupBox.Location = new System.Drawing.Point(0, 0);
            this.OrgGroupBox.Name = "OrgGroupBox";
            this.OrgGroupBox.Size = new System.Drawing.Size(209, 520);
            this.OrgGroupBox.TabIndex = 0;
            this.OrgGroupBox.TabStop = false;
            this.OrgGroupBox.Text = "机构信息";
            // 
            // OrgTreeView
            // 
            this.OrgTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OrgTreeView.Location = new System.Drawing.Point(3, 17);
            this.OrgTreeView.Name = "OrgTreeView";
            this.OrgTreeView.Size = new System.Drawing.Size(203, 500);
            this.OrgTreeView.TabIndex = 0;
            this.OrgTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.OrgTreeView_AfterExpand);
            this.OrgTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrgTreeView_AfterSelect);
            // 
            // UserGroupBox
            // 
            this.UserGroupBox.Controls.Add(this.splitContainer2);
            this.UserGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserGroupBox.Location = new System.Drawing.Point(0, 0);
            this.UserGroupBox.Name = "UserGroupBox";
            this.UserGroupBox.Size = new System.Drawing.Size(578, 520);
            this.UserGroupBox.TabIndex = 0;
            this.UserGroupBox.TabStop = false;
            this.UserGroupBox.Text = "用户管理";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 17);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer3);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip2);
            this.splitContainer2.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer2.Size = new System.Drawing.Size(572, 500);
            this.splitContainer2.SplitterDistance = 457;
            this.splitContainer2.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.label1);
            this.splitContainer3.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer3.Panel1.Controls.Add(this.tbCondition);
            this.splitContainer3.Panel1.Controls.Add(this.btnUpdateStatus);
            this.splitContainer3.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer3.Panel1.Controls.Add(this.btnAddUser);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgvConfigInfo);
            this.splitContainer3.Size = new System.Drawing.Size(572, 457);
            this.splitContainer3.SplitterDistance = 49;
            this.splitContainer3.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(298, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "查询条件：";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(475, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Visible = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tbCondition
            // 
            this.tbCondition.Location = new System.Drawing.Point(369, 17);
            this.tbCondition.Name = "tbCondition";
            this.tbCondition.Size = new System.Drawing.Size(100, 21);
            this.tbCondition.TabIndex = 3;
            this.tbCondition.Visible = false;
            this.tbCondition.TextChanged += new System.EventHandler(this.tbCondition_TextChanged);
            // 
            // btnUpdateStatus
            // 
            this.btnUpdateStatus.Location = new System.Drawing.Point(203, 15);
            this.btnUpdateStatus.Name = "btnUpdateStatus";
            this.btnUpdateStatus.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateStatus.TabIndex = 2;
            this.btnUpdateStatus.Text = "启用/禁用";
            this.btnUpdateStatus.UseVisualStyleBackColor = true;
            this.btnUpdateStatus.Click += new System.EventHandler(this.btnUpdateStatus_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(108, 15);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 1;
            this.btnUpdate.Text = "修改配置";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.Location = new System.Drawing.Point(13, 15);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(75, 23);
            this.btnAddUser.TabIndex = 0;
            this.btnAddUser.Text = "新增配置";
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // dgvConfigInfo
            // 
            this.dgvConfigInfo.AllowUserToAddRows = false;
            this.dgvConfigInfo.AllowUserToDeleteRows = false;
            this.dgvConfigInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SelectCheck,
            this.usercode,
            this.username,
            this.orgname,
            this.statusname,
            this.id,
            this.status,
            this.fremark1});
            this.dgvConfigInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfigInfo.Location = new System.Drawing.Point(0, 0);
            this.dgvConfigInfo.Name = "dgvConfigInfo";
            this.dgvConfigInfo.ReadOnly = true;
            this.dgvConfigInfo.RowTemplate.Height = 23;
            this.dgvConfigInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfigInfo.Size = new System.Drawing.Size(572, 404);
            this.dgvConfigInfo.TabIndex = 0;
            this.dgvConfigInfo.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUserInfo_CellContentClick);
            this.dgvConfigInfo.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgvUserInfo_RowPostPaint);
            // 
            // SelectCheck
            // 
            this.SelectCheck.HeaderText = "选择";
            this.SelectCheck.Name = "SelectCheck";
            this.SelectCheck.ReadOnly = true;
            this.SelectCheck.Width = 60;
            // 
            // usercode
            // 
            this.usercode.DataPropertyName = "usercode";
            this.usercode.HeaderText = "用户账号";
            this.usercode.Name = "usercode";
            this.usercode.ReadOnly = true;
            // 
            // username
            // 
            this.username.DataPropertyName = "username";
            this.username.HeaderText = "用户名";
            this.username.Name = "username";
            this.username.ReadOnly = true;
            // 
            // orgname
            // 
            this.orgname.DataPropertyName = "orgname";
            this.orgname.HeaderText = "所属机构";
            this.orgname.Name = "orgname";
            this.orgname.ReadOnly = true;
            // 
            // statusname
            // 
            this.statusname.DataPropertyName = "statusname";
            this.statusname.HeaderText = "启用状态";
            this.statusname.Name = "statusname";
            this.statusname.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // status
            // 
            this.status.DataPropertyName = "status";
            this.status.HeaderText = "status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Visible = false;
            // 
            // fremark1
            // 
            this.fremark1.DataPropertyName = "fremark1";
            this.fremark1.HeaderText = "备注";
            this.fremark1.Name = "fremark1";
            this.fremark1.ReadOnly = true;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpPageToolStripButton,
            this.toolStripSeparator1,
            this.CurrentPagetoolStripTextBox,
            this.toolStripLabel3,
            this.TotalPagetoolStripLabel,
            this.toolStripSeparator2,
            this.NextPagetoolStripButton});
            this.toolStrip2.Location = new System.Drawing.Point(217, 7);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(163, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
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
            this.CurrentPagetoolStripTextBox.Name = "CurrentPagetoolStripTextBox";
            this.CurrentPagetoolStripTextBox.Size = new System.Drawing.Size(15, 22);
            this.CurrentPagetoolStripTextBox.Text = "1";
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(13, 22);
            this.toolStripLabel3.Text = "/";
            // 
            // TotalPagetoolStripLabel
            // 
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
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.TotalCounttoolStripLabel,
            this.toolStripLabel2});
            this.toolStrip1.Location = new System.Drawing.Point(13, 7);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(91, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(20, 22);
            this.toolStripLabel1.Text = "共";
            // 
            // TotalCounttoolStripLabel
            // 
            this.TotalCounttoolStripLabel.Name = "TotalCounttoolStripLabel";
            this.TotalCounttoolStripLabel.Size = new System.Drawing.Size(15, 22);
            this.TotalCounttoolStripLabel.Text = "0";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(44, 22);
            this.toolStripLabel2.Text = "条记录";
            // 
            // ConfigManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 520);
            this.Controls.Add(this.splitContainer1);
            this.Name = "ConfigManager";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户管理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.OrgGroupBox.ResumeLayout(false);
            this.UserGroupBox.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigInfo)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox OrgGroupBox;
        private System.Windows.Forms.TreeView OrgTreeView;
        private System.Windows.Forms.GroupBox UserGroupBox;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripLabel TotalCounttoolStripLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton UpPageToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel CurrentPagetoolStripTextBox;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripLabel TotalPagetoolStripLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton NextPagetoolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnUpdateStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox tbCondition;
        private System.Windows.Forms.DataGridView dgvConfigInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SelectCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn usercode;
        private System.Windows.Forms.DataGridViewTextBoxColumn username;
        private System.Windows.Forms.DataGridViewTextBoxColumn orgname;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusname;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewTextBoxColumn fremark1;
    }
}