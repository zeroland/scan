using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;

using System.Text;

using System.Windows.Forms;

namespace scan
{
    public partial class ItemSearch : UserControl
    {
        private string searchText;
        private string searchType;
        private string controlId;
        private int count;
        public ItemSearch()
        {
            InitializeComponent();
            this.InitDataGridView();
        }

        public string SearchText
        {
            get
            {
                return searchText;
            }

            set
            {
                searchText = value;
            }
        }

        public string SearchType
        {
            get
            {
                return searchType;
            }

            set
            {
                searchType = value;
            }
        }

        public string ControlId
        {
            get
            {
                return controlId;
            }

            set
            {
                controlId = value;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }

            set
            {
                count = value;
            }
        }

        /// <summary>
        /// 初始化gridview
        /// </summary>
        private void InitDataGridView()
        {
            this.dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
        }

        public void GetSearchData()
        {
            try
            {
                if (!String.IsNullOrEmpty(SearchText))
                {
                    switch (SearchType)
                    {
                        case "Icd":

                            //初始化 列                 
                            this.dataGridView1.Columns.Clear();
                            DataGridViewTextBoxColumn[] dgvColumns = new DataGridViewTextBoxColumn[] {
                        new DataGridViewTextBoxColumn() {
                        HeaderText="疾病编码",

                        DataPropertyName = "icdcode",
                        Name = "icdcode"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="疾病名称",
                        DataPropertyName = "icdname",
                        Name = "icdname"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="助记码",
                        DataPropertyName = "zjm",
                        Name = "zjm"
                                              }
                    };

                            this.dataGridView1.Columns.AddRange(dgvColumns);


                            this.dataGridView1.DataSource = null;
                            DataTable dt = new Business.DictProcess().GetIcdByStr(SearchText).Tables[0];
                            if (dt.Rows.Count > 0)
                            {
                                this.Count = dt.Rows.Count;
                                this.dataGridView1.DataSource = dt;
                                this.dataGridView1.Rows[0].Selected = true;
                            }



                            break;

                        case "Dept":

                            //初始化 列                 
                            this.dataGridView1.Columns.Clear();
                            DataGridViewTextBoxColumn[] dgvDeptColumns = new DataGridViewTextBoxColumn[] {
                        new DataGridViewTextBoxColumn() {
                        HeaderText="科室编码",

                        DataPropertyName = "code",
                        Name = "code"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="科室名称",
                        DataPropertyName = "name",
                        Name = "name"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="助记码",
                        DataPropertyName = "zjm",
                        Name = "zjm"
                                              }
                    };

                            this.dataGridView1.Columns.AddRange(dgvDeptColumns);

                            this.dataGridView1.DataSource = null;
                            DataTable dtDept = new Business.DictProcess().GetDeptByStr(SearchText).Tables[0];
                            if (dtDept.Rows.Count > 0)
                            {
                                this.Count = dtDept.Rows.Count;
                                this.dataGridView1.DataSource = dtDept;
                                this.dataGridView1.Rows[0].Selected = true;
                            }

                            break;

                        case "Org":

                            //初始化 列                 
                            this.dataGridView1.Columns.Clear();
                            DataGridViewTextBoxColumn[] dgvOrgColumns = new DataGridViewTextBoxColumn[] {
                        new DataGridViewTextBoxColumn() {
                        HeaderText="机构编码",

                        DataPropertyName = "code",
                        Name = "code"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="机构名称",
                        DataPropertyName = "name",
                        Name = "name"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="助记码",
                        DataPropertyName = "zjm",
                        Name = "zjm"
                                              }
                    };

                            this.dataGridView1.Columns.AddRange(dgvOrgColumns);


                            this.dataGridView1.DataSource = null;
                            DataTable dtOrg = new Business.DictProcess().GetOrgByStr(SearchText).Tables[0];
                            if (dtOrg.Rows.Count > 0)
                            {
                                this.Count = dtOrg.Rows.Count;
                                this.dataGridView1.DataSource = dtOrg;
                                this.dataGridView1.Rows[0].Selected = true;
                            }


                            break;

                        case "Item":
                            //初始化 列                 
                            this.dataGridView1.Columns.Clear();
                            DataGridViewTextBoxColumn[] dgvItemColumns = new DataGridViewTextBoxColumn[] {
                        new DataGridViewTextBoxColumn() {
                        HeaderText="项目编码",
                        AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "code",
                        Name = "code"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="项目名称",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "name",
                        Name = "name"
                                              } ,
                         new DataGridViewTextBoxColumn() {
                        HeaderText="剂型",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "forms",
                        Name = "forms"
                                              } ,

                         
                         new DataGridViewTextBoxColumn() {
                        HeaderText="补偿比例",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "FCOMPUTERATIO",
                        Name = "FCOMPUTERATIO"
                                              } ,

                         new DataGridViewTextBoxColumn() {
                        HeaderText="省级价格",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "provprice",
                        Name = "provprice"
                                              } ,
                          new DataGridViewTextBoxColumn() {
                        HeaderText="市级价格",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "cityprice",
                        Name = "cityprice"
                                              } ,
                             new DataGridViewTextBoxColumn() {
                        HeaderText="乡级价格",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "counprice",
                        Name = "counprice"
                                              } ,

                        new DataGridViewTextBoxColumn() {
                        HeaderText="助记码",
                         AutoSizeMode=System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells,
                        DataPropertyName = "zjm",
                        Name = "zjm"
                                              },
                         new DataGridViewTextBoxColumn() {
                        HeaderText="项目类型",
                        DataPropertyName = "itemtype",
                        Name = "itemtype",Visible=false
                                              },
                          new DataGridViewTextBoxColumn() {
                        HeaderText="费用类别",
                        DataPropertyName = "feetype",
                        Name = "feetype",Visible=false
                                              }
                    };

                            this.dataGridView1.Columns.AddRange(dgvItemColumns);


                            this.dataGridView1.DataSource = null;


                            DataSet ds = new Business.DictProcess().GetItemByStr(SearchText);
                            if (ds.Tables.Count > 0)
                            {
                                DataTable dtItem = ds.Tables[0];
                                if (dtItem.Rows.Count > 0)
                                {
                                    this.Count = dtItem.Rows.Count;
                                    this.dataGridView1.DataSource = dtItem;
                                    if (this.dataGridView1.Rows.Count > 0)
                                    {
                                        this.dataGridView1.Rows[0].Selected = true;
                                    }
                                }
                            }


                            break;

                    }
                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("检索中心项目异常:" + ex.ToString());
            }

        }

        public void ParentFormKeyDownToChild(object sender, KeyEventArgs e)
        {

            dataGridView1_KeyDown(sender,e);
        }

        public void ParentFormPreKeyDownToChild(object sender,PreviewKeyDownEventArgs e )
        {
            dataGridView1_PreKeyDown(sender,e);
        }

        public void ParentFormDown()
        {
            // this.dataGridView1.Rows[dataGridView1.CurrentRow.Index+1].Selected = true;
            this.dataGridView1.Focus();


        }

        public void SetParentView()
        {
            try
            {
                int rowIndex = this.dataGridView1.SelectedRows[0].Index;
                if (this.dataGridView1.Rows[rowIndex].Cells["name"].Value != null)
                {
                    string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                    string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();
                    string itemtype = this.dataGridView1.Rows[rowIndex].Cells["itemtype"].Value.ToString();

                    string feetype = this.dataGridView1.Rows[rowIndex].Cells["feetype"].Value.ToString();
                    string forms = this.dataGridView1.Rows[rowIndex].Cells["forms"].Value.ToString();
                    string formsName = "";
                    if (!String.IsNullOrEmpty(forms))
                    {
                        formsName = "(" + forms + ")";
                    }

    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).EndEdit();

                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterCode"].Value = code;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterName"].Value = name + formsName;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["itemtype"].Value = itemtype;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["feetype"].Value = feetype;



                    this.Visible = false;


                    dataGridView1.DataSource = null;

                    //在datagridview点击之后，把中心编码赋值到mainform的变量中，记录单元格赋值之后的值

                    //获取原始值
                    string oldName = ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["oldName"].Value.ToString();
                    string newName = ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();

                    if (this.Parent.FindForm() is MainForm)
                    {
                        MainForm form = (MainForm)(this.Parent.FindForm());
                        form.UpdateItemDictRelation(oldName, newName, code);
                    }


                    if (this.Parent.FindForm() is MainInfoList)
                    {
                        MainInfoList form = (MainInfoList)(this.Parent.FindForm());
                        form.UpdateItemDictRelation(oldName, newName, code);
                    }

                }
            }
            catch(Exception ex)
            {
                throw new ApplicationException("回车赋值中心项目异常:"+ex.ToString());
            }
        }

       

        private void dataGridView1_PreKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            int rowIndex = this.dataGridView1.SelectedRows[0].Index;
            if (e.KeyCode == Keys.Enter && SearchType.Equals("Item"))
            {
                if (this.dataGridView1.Rows[rowIndex].Cells["name"].Value != null)
                {
                    string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                    string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();
                    string itemtype = this.dataGridView1.Rows[rowIndex].Cells["itemtype"].Value.ToString();

                    string feetype = this.dataGridView1.Rows[rowIndex].Cells["feetype"].Value.ToString();
                    string forms = this.dataGridView1.Rows[rowIndex].Cells["forms"].Value.ToString();
                    string formsName = "";
                    if (!String.IsNullOrEmpty(forms))
                    {
                        formsName = "(" + forms + ")";
                    }
                    //controlId作为传入的行索引
                    //DataTable dt = (DataTable)((DataGridView)this.Parent.Controls["ScanDataGridView"]).DataSource;
                    //dt.Rows[int.Parse(controlId)]["centercode"] = code;
                    //dt.Rows[int.Parse(controlId)]["centername"] = name;
                    //((DataGridView)this.Parent.Controls["ScanDataGridView"]).DataSource = dt;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterCode"].Value = code;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterName"].Value = name+ formsName;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["itemtype"].Value = itemtype;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["feetype"].Value = feetype;
                 
                    this.Visible = false;
                    dataGridView1.DataSource = null;
                }

            }


        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int rowIndex= this.dataGridView1.SelectedRows[0].Index;
            if (e.KeyCode == Keys.Enter && SearchType.Equals("Icd") && this.ControlId == "tbInhosDia")
            {
                string code = this.dataGridView1.Rows[rowIndex].Cells["icdcode"].Value.ToString();
                string name = this.dataGridView1.Rows[rowIndex].Cells["icdname"].Value.ToString();

                TextBox tbInhosDia = (TextBox)((GroupBox)Parent.Controls["InhospGroupBox"]).Controls[this.controlId];
                tbInhosDia.Text = name;
                ((AddForm)Parent).hdInhosDia = code;
                this.Visible = false;
                dataGridView1.DataSource = null;

            }
        

            if (e.KeyCode == Keys.Enter && SearchType.Equals("Dept") && this.ControlId == "tbInhosDept")
            {
                string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();


                TextBox tbInhosDept = (TextBox)((GroupBox)Parent.Controls["InhospGroupBox"]).Controls[this.controlId];

                tbInhosDept.Text = name;
                ((AddForm)Parent).hdInHosDept = code;
                this.Visible = false;
                dataGridView1.DataSource = null;
            }

            if (e.KeyCode == Keys.Enter && SearchType.Equals("Icd") && this.ControlId == "tbOutHospDia")
            {
                string code = this.dataGridView1.Rows[rowIndex].Cells["icdcode"].Value.ToString();
                string name = this.dataGridView1.Rows[rowIndex].Cells["icdname"].Value.ToString();


                TextBox tbOutHospDia = (TextBox)((GroupBox)Parent.Controls["InhospGroupBox"]).Controls[this.controlId];
                tbOutHospDia.Text = name;
                ((AddForm)Parent).hdOutHosDia = code;
                this.Visible = false;
                dataGridView1.DataSource = null;
            }

            if (e.KeyCode == Keys.Enter && SearchType.Equals("Dept") && this.ControlId == "tbOutDept")
            {
                string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();


                TextBox tbOutDept = (TextBox)((GroupBox)Parent.Controls["InhospGroupBox"]).Controls[this.controlId];

                tbOutDept.Text = name;
                ((AddForm)Parent).hdOutHosDept = code;
                this.Visible = false;
                dataGridView1.DataSource = null;
            }

            if (e.KeyCode == Keys.Enter && SearchType.Equals("Org") && this.ControlId == "tbInhosOrg")
            {
                //string code = this.dataGridView1.CurrentRow.Cells["code"].Value.ToString();
                //string name = this.dataGridView1.CurrentRow.Cells["name"].Value.ToString();
                string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();


                TextBox tbInhosOrg = (TextBox)((GroupBox)Parent.Controls["InhospGroupBox"]).Controls[this.controlId];

                tbInhosOrg.Text = name;
                ((AddForm)Parent).hdInhosOrg = code;
                this.Visible = false;
                dataGridView1.DataSource = null;
            }

            if (e.KeyCode == Keys.Enter && SearchType.Equals("Item"))
            {
                if (this.dataGridView1.Rows[rowIndex].Cells["name"].Value != null)
                {
                    string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                    string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();
                    string itemtype= this.dataGridView1.Rows[rowIndex].Cells["itemtype"].Value.ToString();

                    string feetype = this.dataGridView1.Rows[rowIndex].Cells["feetype"].Value.ToString();
                    string forms= this.dataGridView1.Rows[rowIndex].Cells["forms"].Value.ToString();
                    string formsName = "";
                    if (!String.IsNullOrEmpty(forms))
                    {
                        formsName = "(" + forms + ")";
                    }
                    //controlId作为传入的行索引
                    //DataTable dt = (DataTable)((DataGridView)this.Parent.Controls["ScanDataGridView"]).DataSource;
                    //dt.Rows[int.Parse(controlId)]["centercode"] = code;
                    //dt.Rows[int.Parse(controlId)]["centername"] = name;
                    //((DataGridView)this.Parent.Controls["ScanDataGridView"]).DataSource = dt;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterCode"].Value = code;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterName"].Value = name + formsName;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["itemtype"].Value = itemtype;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["feetype"].Value = feetype;

                    this.Visible = false;
                    dataGridView1.DataSource = null;
                }

            }
          
            if (sender is TextBox||sender is ComboBox)
            {
                ((TextBox)sender).Focus();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Left && SearchType.Equals("Item"))
                {
                    DataGridView.HitTestInfo hit = this.dataGridView1.HitTest(e.X, e.Y);
                    int rowIndex = hit.RowIndex;

                    string code = this.dataGridView1.Rows[rowIndex].Cells["code"].Value.ToString();
                    string name = this.dataGridView1.Rows[rowIndex].Cells["name"].Value.ToString();
                    string itemtype = this.dataGridView1.Rows[rowIndex].Cells["itemtype"].Value.ToString();

                    string feetype = this.dataGridView1.Rows[rowIndex].Cells["feetype"].Value.ToString();
                    string forms = this.dataGridView1.Rows[rowIndex].Cells["forms"].Value.ToString();
                    string formsName = "";
                    if (!String.IsNullOrEmpty(forms))
                    {
                        formsName = "(" + forms + ")";
                    }

                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).EndEdit();//只有结束编辑才能赋值

                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterCode"].Value = code;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["CenterName"].Value = name + formsName;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["itemtype"].Value = itemtype;
                    ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["feetype"].Value = feetype;
                    this.Visible = false;
                    dataGridView1.DataSource = null;

                    //在datagridview点击之后，把中心编码赋值到mainform的变量中，记录单元格赋值之后的值
                    //获取原始值
                    string oldName = ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["oldName"].Value.ToString();
                    string newName = ((DataGridView)this.Parent.Controls["ScanDataGridView"]).CurrentRow.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();


                    if (this.Parent.FindForm() is MainForm)
                    {
                        MainForm form = (MainForm)(this.Parent.FindForm());
                        form.UpdateItemDictRelation(oldName, newName, code);
                    }


                    if (this.Parent.FindForm() is MainInfoList)
                    {
                        MainInfoList form = (MainInfoList)(this.Parent.FindForm());
                        form.UpdateItemDictRelation(oldName, newName, code);
                    }




                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("点击选择中心项目异常:"+ex.ToString());
            }
        }
    
    }
}
