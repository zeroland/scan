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
    public partial class UserManager : Form
    {
        private ScanDataSet scanDataSet;
        public UserManager()
        {
            InitializeComponent();
            this.Init();
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

        /**
        
         if (dt.Rows.Count > 0)
            {
                this.treeView1.Nodes.Clear();
                TreeNode root = new TreeNode();
                root.Text = "外诊录入信息";
                root.Tag = "外诊录入信息-guid";
                for (int i = 0; i < dt.Rows.Count; i++)*/
        //        {
        //            TreeNode tmp = new TreeNode();
        //            tmp.Text = dt.Rows[i]["name"].ToString()+"("+ dt.Rows[i]["ylzh"].ToString()+")";
        //            tmp.Tag = dt.Rows[i]["id"].ToString();

        //            root.Nodes.Add(tmp);
        //        }
        //        this.treeView1.Nodes.Add(root);
        //        root.Expand();


        //    }
        //}

        //private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        //{
        //    if (this.treeView1.SelectedNode != null&&this.treeView1.Nodes[0].IsExpanded&&this.treeView1.SelectedNode!=this.treeView1.Nodes[0])
        //    {

        //        this.GetDetailById(this.treeView1.SelectedNode.Tag.ToString());
        //    }
        //}

    }
}
