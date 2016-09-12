using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class ConfigManager : Form
    {
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        private ScanDataSet scanDataSet;
        SolidBrush solidBrush;
        public string flag;//1,新增;2,修改
        public string userID;
        public string orgID;
        public ConfigManager()
        {
            InitializeComponent();
            this.Init();
            this.InitBrush();

        }

      


        private void InitBrush()
        {
            solidBrush = new SolidBrush(this.dgvConfigInfo.RowHeadersDefaultCellStyle.ForeColor);
        }

        private void Init()
        {
            //加载所有机构信息
            scanDataSet= new Business.OrgInfo().GetOrgByStr("");

            //创建根节点
            if (scanDataSet.BaseOrgInfo.Rows.Count > 0)
            {
                //获取河南省为根节点
                DataRow[] drArrayRoot =scanDataSet.BaseOrgInfo.Select("orgid=1");
                DataRow rootRow;
                if (drArrayRoot.Length > 0)
                {
                    rootRow = drArrayRoot[0];
                }
                else
                {
                    MessageBox.Show("获取根节点错误");
                    return;
                }

                this.OrgTreeView.Nodes.Clear();
                TreeNode root = new TreeNode();
                root.Text = rootRow["orgname"].ToString();
                root.Collapse(true);
                root.Tag = rootRow;
                this.OrgTreeView.Nodes.Add(root);
                root.Expand();

                
            }
        }

        private void OrgTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            //获取当前选择的节点
           // MessageBox.Show(e.Node.Text);
        }


        private void GetChildNodes(TreeView orgTreeView)
        {
            //获取当前选择的节点
            MessageBox.Show(orgTreeView.SelectedNode.Text);
        }

        private void OrgTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            
            DataRow nodeRow = (DataRow)e.Node.Tag;
            DataRow[] dr= scanDataSet.BaseOrgInfo.Select("parentorgid='" + nodeRow["orgid"]+"'","orgcode desc");
            //如果没有子节点  且当前机构是行政单位 获取对应用户信息
            if (nodeRow["orgtype"].ToString().Equals("2"))
            {
                this.btnSearch_Click(null,null);
            }


            if (dr.Length > 0)
            {
                TreeNode tmpNode;
                for (int i = 0; i < dr.Length; i++)
                {
                    tmpNode = new TreeNode();
                    tmpNode.Text = dr[i]["orgname"].ToString();
                    tmpNode.Tag = dr[i];
                    e.Node.Nodes.Add(tmpNode);
                }
                e.Node.Expand();
            }
        }

        private void dgvUserInfo_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvConfigInfo.DefaultCellStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            this.flag = "1";
            //获取所选机构
            bool result= GetOwnOrg();
            if (!result) return;

            //初始化AddUser 
            AddUser addUser = new AddUser();
            addUser.Owner = this;
            addUser.Init();

            addUser.ShowDialog(this);

        }


        //获取所选机构
        private bool GetOwnOrg()
        {
            if (this.OrgTreeView.SelectedNode != null)
            {
                DataRow dr= (DataRow)this.OrgTreeView.SelectedNode.Tag;
                if (dr["orgtype"].ToString() == "2")
                {
                    this.orgID = dr["orgid"].ToString();
                }
                else
                {
                    MessageBox.Show("请选择行政单位！");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("请选择所属机构！");
                return false;
            }
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //获取所选机构
            GetOwnOrg();

            //获取查询条件
            string str = "and forgid='" + this.orgID + "'";
            if (!String.IsNullOrEmpty(this.tbCondition.Text.Trim()))
            {
                str += " and (username like '%" + this.tbCondition.Text.Trim() + "%' or usercode like '%" + this.tbCondition.Text.Trim() + "%' )";
            }
            ScanDataSet scanDataSet= new Business.UserInfo().GetUserByStr(str);
            if (scanDataSet.UserInfo.Rows.Count > 0)
            {
                dtInfo = scanDataSet.UserInfo;
                InitDataSet();
            }
            
        }

        private void tbCondition_TextChanged(object sender, EventArgs e)
        {
            this.btnSearch_Click(null,null);
        }

        private void InitDataSet()
        {
            pageSize = 20;      //设置页面行数
            nMax = dtInfo.Rows.Count;
            pageCount = (nMax / pageSize);    //计算出总页数
            if ((nMax % pageSize) > 0) pageCount++;
            pageCurrent = 1;    //当前页数从1开始
            nCurrent = 0;       //当前记录数从0开始
            LoadData();
        }

        private void LoadData()
        {
            int nStartPos = 0;   //当前页面开始记录行
            int nEndPos = 0;     //当前页面结束记录行
            DataTable dtTemp = dtInfo.Clone();   //克隆DataTable结构框架

            if (pageCurrent == pageCount)
            {
                nEndPos = nMax;
            }
            else
            {
                nEndPos = pageSize * pageCurrent;
            }

            nStartPos = nCurrent;
            TotalCounttoolStripLabel.Text = nMax.ToString();
            TotalPagetoolStripLabel.Text = pageCount.ToString();
            CurrentPagetoolStripTextBox.Text = Convert.ToString(pageCurrent);


            //从元数据源复制记录行
            for (int i = nStartPos; i < nEndPos; i++)
            {
                dtTemp.ImportRow(dtInfo.Rows[i]);
                nCurrent++;
            }
            //bdsInfo.DataSource = dtTemp;
            //bdnInfo.BindingSource = bdsInfo;
            //dgvInfo.DataSource = bdsInfo;
            this.dgvConfigInfo.AutoGenerateColumns = false;
            this.dgvConfigInfo.DataSource = dtTemp;



            if (pageCurrent <= 1)
            {
                this.UpPageToolStripButton.Enabled = false;
                this.NextPagetoolStripButton.Enabled = true;
                return;
            }
            else if (pageCurrent >= pageCount)
            {

                this.UpPageToolStripButton.Enabled = true;
                this.NextPagetoolStripButton.Enabled = false;
                return;
            }
            else
            {
                this.UpPageToolStripButton.Enabled = true;
                this.NextPagetoolStripButton.Enabled = true;
                nCurrent = pageSize * (pageCurrent - 1);
            }


        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //判断选中几行 只修改第一行
            try
            {
                this.flag = "2";
                int count = 0;
                for (int i = 0; i < this.dgvConfigInfo.Rows.Count; i++)
                {

                    if (this.dgvConfigInfo.Rows[i].Cells[this.dgvConfigInfo.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                    {
                        count++;
                        this.userID = this.dgvConfigInfo.Rows[i].Cells["id"].Value.ToString();

                        AddUser addUser = new AddUser();
                        addUser.Owner = this;
                        addUser.Init();
                        addUser.ShowDialog(this);
                        return;

                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("请选择要修改的行！");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            //判断选中几行 
            try
            {
                int count = 0;
                bool result=false;
                for (int i = 0; i < this.dgvConfigInfo.Rows.Count; i++)
                {

                    if (this.dgvConfigInfo.Rows[i].Cells[this.dgvConfigInfo.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                    {
                        count++;
                        this.userID = this.dgvConfigInfo.Rows[i].Cells["id"].Value.ToString();
                        string status= this.dgvConfigInfo.Rows[i].Cells["status"].Value.ToString();
                        ScanDataSet scanDataSet= new Business.UserInfo().GetUserByID(this.userID);
                        if (scanDataSet.UserInfo.Rows.Count > 0)
                        {
                            ScanDataSet.UserInfoDataTable dt = scanDataSet.UserInfo;
                            dt.Rows[0]["status"] = status == "1" ? "0" : "1";
                            result= new Business.UserInfo().AddUser(dt);
                        }

                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("请选择要修改的行！");
                    return;
                }
                if (result)
                {
                    MessageBox.Show("更新成功!");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvUserInfo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < this.dgvConfigInfo.Rows.Count)
            {
                if (this.dgvConfigInfo.CurrentCell.ColumnIndex == this.dgvConfigInfo.Columns["SelectCheck"].Index)
                {
                    if (this.dgvConfigInfo.CurrentCell.EditedFormattedValue.ToString() == "True")
                    {
                        this.dgvConfigInfo.CurrentCell.Value = false;
                    }
                    else
                    {
                        this.dgvConfigInfo.CurrentCell.Value = true;
                    }
                }
            }
        }
    }
}
