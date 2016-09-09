namespace scan
{
    partial class UserManager
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.OrgGroupBox = new System.Windows.Forms.GroupBox();
            this.OrgTreeView = new System.Windows.Forms.TreeView();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.OrgGroupBox.SuspendLayout();
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
            this.splitContainer1.Size = new System.Drawing.Size(645, 387);
            this.splitContainer1.SplitterDistance = 215;
            this.splitContainer1.TabIndex = 0;
            // 
            // OrgGroupBox
            // 
            this.OrgGroupBox.Controls.Add(this.OrgTreeView);
            this.OrgGroupBox.Location = new System.Drawing.Point(3, 3);
            this.OrgGroupBox.Name = "OrgGroupBox";
            this.OrgGroupBox.Size = new System.Drawing.Size(209, 384);
            this.OrgGroupBox.TabIndex = 0;
            this.OrgGroupBox.TabStop = false;
            this.OrgGroupBox.Text = "机构信息";
            // 
            // OrgTreeView
            // 
            this.OrgTreeView.Location = new System.Drawing.Point(6, 18);
            this.OrgTreeView.Name = "OrgTreeView";
            this.OrgTreeView.Size = new System.Drawing.Size(197, 363);
            this.OrgTreeView.TabIndex = 0;
            this.OrgTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.OrgTreeView_AfterExpand);
            this.OrgTreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OrgTreeView_AfterSelect);
            // 
            // UserManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 387);
            this.Controls.Add(this.splitContainer1);
            this.Name = "UserManager";
            this.Text = "用户管理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.OrgGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox OrgGroupBox;
        private System.Windows.Forms.TreeView OrgTreeView;
    }
}