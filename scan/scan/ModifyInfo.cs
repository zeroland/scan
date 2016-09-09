using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace scan
{
    public partial class ModifyInfo : Form
    {
        string frcode = "";
        public string beginName = "", endName = "";
        private Hashtable dictHT = new Hashtable();
        private string pid = "";
        //正在加载框采用子线程处理
        LoadForm loadForm;
        Thread MyProgressWait;

        public ModifyInfo(string pid)
        {
            InitializeComponent();

            this.pid = pid;
            Init();
        }

        private void Init()
        {
            BindFeeTpe();
            BindItemType();
            loadData();
            this.frcode = Util.Util.GetAppSetting("rcode");
            this.initDictCode();
        }

        private void loadData()
        {
            

                if (!String.IsNullOrEmpty(pid))
                {
                    DataSet dsZyjl= new Business.MainList().GetZyjlById(Int32.Parse(pid));
                    if (dsZyjl.Tables.Count > 0 && dsZyjl.Tables[0].Rows.Count > 0)
                    {
                        DataRow dr = dsZyjl.Tables[0].Rows[0];
                        string name = dr["name"].ToString();
                        string ylzh = dr["ylzh"].ToString();
                        string zyh = dr["zyh"].ToString();
                        this.TipToolStripStatusLabel.Text += "姓名:"+name+"    医疗证号:"+ylzh+"     住院号:"+zyh;

                        //加载费用明细
                        this.BindData(pid);
                    }
                    else
                    {
                        MessageBox.Show("获取住院记录失败!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("获取住院记录主键为空!");
                    return;
                }

                //string sdx = Util.Util.GetAppSetting("rcode");

                //DataTable dt = new Business.MainList().GetMainInfoList(sdx, null).Tables[0];
                //if (dt.Rows.Count > 0)
                //{



                //}
           
                        
        }



        private void BindData(string pid)
        {
            this.GetDetailById(pid);

        }


      
   

        private void GetDetailById(string id)
        {
            this.ScanDataGridView.AutoGenerateColumns = false;
            this.ScanDataGridView.DataSource = null;
            Hashtable ht = new Hashtable();
            ht.Add("id", id);
            DataTable dt= new Business.ItemProcess().GetDetailById(ht).Tables[0];
            this.labelCount.Text = "总条数：0";
            this.labelTotalPrice.Text = "总金额：0";
            if(dt.Rows.Count>0)
            {               
                this.ScanDataGridView.DataSource = dt;
            }
        }

        private void ScanDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            

            if (e.RowIndex < this.ScanDataGridView.Rows.Count&&this.ScanDataGridView.Rows.Count>1)
            {
                DataGridViewRow dr = this.ScanDataGridView.Rows[e.RowIndex];

               
                string centerName = dr.Cells["CenterName"].Value == null ? "" : ScanDataGridView.Rows[e.RowIndex].Cells["CenterName"].Value.ToString();

                if (e.ColumnIndex == 0)
                {
                    e.Value = e.RowIndex + 1;
                }


                if (String.IsNullOrEmpty(centerName))
                {
                    if (dr.Cells["CenterName"].ColumnIndex == e.ColumnIndex)
                    {
                        dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                    }
                }

                if (dr.Cells["Quantum"].Value==null|| dr.Cells["Quantum"].Value.ToString() == "0")
                {
                    dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                }
                if (dr.Cells["Price"].Value == null || dr.Cells["Price"].Value.ToString() == "0")
                {
                    dr.Cells["Price"].Style.BackColor = Color.LightCoral;
                }
                if (dr.Cells["TotalPrice"].Value == null || dr.Cells["TotalPrice"].Value.ToString() == "0")
                {
                    dr.Cells["TotalPrice"].Style.BackColor = Color.LightCoral;
                }



                //扫描出的单位含有支、瓶、盒 且中心编码不为空  且项目类型不为 药品的
                string unit = "";
                
                {
                    unit = dr.Cells["unit"].ToString();
                    string itemtype = dr.Cells["itemtype"].Value==null?"": dr.Cells["itemtype"].Value.ToString();
                    string hisname = dr.Cells["nameDataGridViewTextBoxColumn"].Value==null?"": dr.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                    if (!String.IsNullOrEmpty(unit) && !String.IsNullOrEmpty(centerName) && !String.IsNullOrEmpty(hisname))
                    {

                        if ((unit.IndexOf("支") != -1 || unit.IndexOf("瓶") != -1 || unit.IndexOf("盒") != -1 || unit.IndexOf("片") != -1) && itemtype.Equals("1"))
                        {
                            dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                        }
                        if ((unit.IndexOf("次") != -1) && itemtype.Equals("0"))
                        {
                            dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                        }
                    }

                    if (String.IsNullOrEmpty(unit) && !String.IsNullOrEmpty(centerName) && !String.IsNullOrEmpty(hisname))
                    {

                        if ((hisname.IndexOf("支") != -1 || hisname.IndexOf("瓶") != -1 || hisname.IndexOf("盒") != -1 || hisname.IndexOf("片") != -1) && itemtype.Equals("1"))
                        {
                            dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                        }


                    }

                    if ((hisname.IndexOf("测定") != -1 || hisname.IndexOf("检查") != -1 || hisname.IndexOf("化学") != -1 || hisname.IndexOf("一次性") != -1) && itemtype.Equals("0"))
                    {
                        dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                    }
                }
                





                //原始值与处理之后的值不一样
                string nowQuantum = dr.Cells["Quantum"].Value == null ? "0" : dr.Cells["Quantum"].Value.ToString();
             
                string nowPrice = dr.Cells["price"].Value == null ? "0" : dr.Cells["price"].Value.ToString();
             
                string nowTotalPrice = dr.Cells["totalPrice"].Value == null ? "0" : dr.Cells["totalPrice"].Value.ToString();

                //值不为数值处理
                double d_quantum = 0;
                double d_price = 0;
                double d_totalprice = 0;
                if (!Double.TryParse(nowQuantum, out d_quantum))
                {
                    dr.Cells["Quantum"].Value = 0;
                    dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                }

                if (!Double.TryParse(nowPrice, out d_price))
                {
                    dr.Cells["price"].Value = 0;
                    dr.Cells["price"].Style.BackColor = Color.LightCoral;
                }

                if (!Double.TryParse(nowTotalPrice, out d_totalprice))
                {
                    dr.Cells["totalPrice"].Value = 0;
                    dr.Cells["totalPrice"].Style.BackColor = Color.LightCoral;
                }


                //校验三个值关系
                if (Math.Round(d_quantum * d_price, 2) != d_totalprice)
                {
                    dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                    dr.Cells["price"].Style.BackColor = Color.LightCoral;
                    dr.Cells["totalPrice"].Style.BackColor = Color.LightCoral;
                }

                this.ScaleTotal(this.ScanDataGridView);
            }
        }

        private void BindItemType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
          
            dt.Rows.Add(new string[] { "0", "药品" });

            dt.Rows.Add(new string[] { "1", "诊疗" });
            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)this.ScanDataGridView.Columns["ItemType"];

            column.DisplayMember = "name";
            column.ValueMember = "code";
            column.DataSource = dt;


        }

        private void BindFeeTpe()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
            dt.Rows.Add(new string[] { "01", "药费" });
            dt.Rows.Add(new string[] { "0101", "西药费" });
            dt.Rows.Add(new string[] { "0102", "中草药费" });
            dt.Rows.Add(new string[] { "0103", "中成药费" });
            dt.Rows.Add(new string[] { "02", "治疗费" });
            dt.Rows.Add(new string[] { "0201", "一般治疗费" });
            dt.Rows.Add(new string[] { "0202", "中医治疗费" });
            dt.Rows.Add(new string[] { "0203", "特殊治疗费" });
            dt.Rows.Add(new string[] { "03", "手术费" });
            dt.Rows.Add(new string[] { "04", "材料费" });
            dt.Rows.Add(new string[] { "05", "检查费" });
            dt.Rows.Add(new string[] { "06", "化验费" });
            dt.Rows.Add(new string[] { "07", "床位费" });
            dt.Rows.Add(new string[] { "08", "护理费" });
            dt.Rows.Add(new string[] { "09", "其他费" });


            DataGridViewComboBoxColumn column = (DataGridViewComboBoxColumn)this.ScanDataGridView.Columns["FeeType"];

            column.DisplayMember = "name";
            column.ValueMember = "code";
            column.DataSource = dt;

        }

        private void initDictCode()
        {


            this.dictHT["请选择"] = "";
            this.dictHT["自费材料"] = "499000002";
            this.dictHT["其他可报一次性材料"] = "499000001";
            this.dictHT["其他可报诊疗费"] = "999000002";
            this.dictHT["其他不可报诊疗费"] = "999000001";
            this.dictHT["可报销甲类西药"] = "W9999999999000a";
            this.dictHT["可报销乙类西药"] = "W9999999999000b";
            this.dictHT["可报销甲类中成药"] = "C9999999999000a";
            this.dictHT["可报销乙类中成药"] = "C9999999999000b";
            this.dictHT["可报销中药饮片"] = "P9999999999000y";
            this.dictHT["不可报西药"] = "W9999999999000z";
            this.dictHT["不可报中成药"] = "C9999999999000z";
            this.dictHT["不可报销中药饮片"] = "P9999999999000z";

            ArrayList arrList = new ArrayList(this.dictHT.Keys);
            foreach (string key in arrList)
            {
                this.DictToolStripComboBox.Items.Add(key);
            }
            this.DictToolStripComboBox.SelectedItem = "请选择";

        }


        private DataGridViewTextBoxEditingControl EditingControl = null;
        private void ScanDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl && this.ScanDataGridView.Columns[this.ScanDataGridView.CurrentCell.ColumnIndex].Name == "CenterName")
            {

                EditingControl = (DataGridViewTextBoxEditingControl)e.Control;

                EditingControl.TextChanged -= new EventHandler(EditingControl_Event);
                EditingControl.TextChanged += new EventHandler(EditingControl_Event);
                //先-= 防止出现多次注册 
                EditingControl.PreviewKeyDown -= new PreviewKeyDownEventHandler(EditingControl_PreKeyDown);
                EditingControl.PreviewKeyDown += new PreviewKeyDownEventHandler(EditingControl_PreKeyDown);

            }

        }

        private void EditingControl_Event(object sender, EventArgs e)
        {


            if (this.ScanDataGridView.CurrentCell.ColumnIndex == this.ScanDataGridView.Columns["centername"].Index && !String.IsNullOrEmpty(((TextBox)sender).Text))
            {

                this.itemSearch1.SearchType = "Item";
                this.itemSearch1.SearchText = ((TextBox)sender).Text;
                this.itemSearch1.ControlId = this.ScanDataGridView.CurrentRow.Index.ToString();//传入行索引
                this.itemSearch1.GetSearchData();

                if (itemSearch1.Visible == false)
                {
                    int columnIndex = ScanDataGridView.CurrentCell.ColumnIndex;
                    int rowIndex = ScanDataGridView.CurrentCell.RowIndex;
                    int dgvX = ScanDataGridView.Location.X;
                    int dgvY = ScanDataGridView.Location.Y;

                    int cellX = ScanDataGridView.GetCellDisplayRectangle(columnIndex-1, rowIndex, false).X;
                    int cellY = ScanDataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Y;
                    int cellHeight = ScanDataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Height;

                    //行在下方，弹出框在上方显示
                    if (this.ScanDataGridView.Height - cellY < itemSearch1.Height)
                    {
                        itemSearch1.Location = new System.Drawing.Point(dgvX + cellX, dgvY + cellY - this.itemSearch1.Height);
                    }
                    else
                    {
                        itemSearch1.Location = new System.Drawing.Point(dgvX + cellX, dgvY + cellY + cellHeight);
                    }
                 
                    itemSearch1.Visible = true;
                  
                }


            }

            if (this.ScanDataGridView.CurrentCell.ColumnIndex == this.ScanDataGridView.Columns["centername"].Index && String.IsNullOrEmpty(((TextBox)sender).Text.Trim()) && itemSearch1.Visible)
            {
                itemSearch1.Visible = false;
            }

        }

        private void EditingControl_PreKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            try
            {
                if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && itemSearch1.Visible == true)
                {

                    DataGridView ctl = ((DataGridView)this.itemSearch1.Controls["dataGridView1"]);
                    int rowCount = ctl.Rows.Count;
                    if (e.KeyCode == Keys.Down)
                    {
                        int rowindex = ctl.SelectedRows[0].Index;
                        if (!(rowindex == rowCount - 1))
                        {
                            ctl.Rows[rowindex + 1].Selected = true;
                        }
                        else
                        {
                            ctl.Rows[rowindex].Selected = true;

                        }
                        ctl.FirstDisplayedScrollingRowIndex = rowindex;
                    }

                    if (e.KeyCode == Keys.Up)
                    {
                        int rowindex = ctl.SelectedRows[0].Index;
                        if (rowindex == 0)
                        {
                            ctl.Rows[rowindex].Selected = true;
                        }
                        else
                        {
                            ctl.Rows[rowindex - 1].Selected = true;
                        }

                        ctl.FirstDisplayedScrollingRowIndex = rowindex;
                    }

                    //this.itemSearch1.ParentFormPreKeyDownToChild(sender, e);
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.itemSearch1.SetParentView();
                    }
                }

            }
            catch (Exception ex)
            {

                showError(ex.ToString());
            }


        }

        /// <summary>
        /// 重写父类处理按键事件  datagridview
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Down || keyData == Keys.Up)　　//监听回车事件　
            {
                if (this.ScanDataGridView.CurrentCell.OwningColumn.Name == "CenterName" && this.ScanDataGridView.IsCurrentCellInEditMode)　　//如果当前单元格处于编辑模式　
                {

                    return true;

                }

            }
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return true;
            }
            //继续原来base.ProcessCmdKey中的处理　
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void ScanDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "CenterName")
            {
                this.clearGridView();

            }
        }

        private void clearGridView()
        {
            if (this.itemSearch1.Visible == true)
            {
                this.itemSearch1.Visible = false;
             
            }
        }

        private void ScanDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            int count = this.ScanDataGridView.Rows.Count;
            Double totalPrice = 0;
            //单价 数量单元格发生变化  更新总金额
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "price" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "Quantum" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalprice")
            {
                try
                {
                    double price = Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["price"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["price"].Value.ToString());
                    double quantum = Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["Quantum"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["Quantum"].Value.ToString());

                    double totalprice = Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["totalprice"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["totalprice"].Value.ToString());


                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "price")
                    {
                        if (price != 0 && price.ToString().IndexOf("无穷") == -1)
                        { 
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["totalprice"].Value = Math.Round(price * quantum, 2);
                        }
                    }

                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "Quantum")
                    {
                        if (price != 0 && price.ToString().IndexOf("无穷") == -1)
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["totalprice"].Value = Math.Round(price * quantum, 2);
                        }
                        else
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["price"].Value = Math.Round(totalPrice / quantum, 4);
                        }


                    }

                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalprice")
                    {
                        if (price == 0 || price.ToString().IndexOf("无穷") > -1)
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["price"].Value = Math.Round(totalPrice / quantum, 4);
                        }



                    }

                }
                catch (Exception ex)
                {

                    showError("计算总金额:" + ex.ToString());
                }
            }

            if(this.ScanDataGridView.Columns[e.ColumnIndex].Name == "price" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "Quantum" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalprice")
            { 
           
                this.ScaleTotal(this.ScanDataGridView);

            }

        }

        private void ScaleTotal(DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {
                
               
           
                int count = dgv.Rows.Count  ;
                //启用添加行  会带有空行 需要 -1 
                if (dgv.AllowUserToAddRows)
                {
                    count = count - 1;
                }
                    Double totalPrice = 0;
                for (int r = 0; r < dgv.Rows.Count; r++)
                {
                 
                    double tmpprice = 0;
                    string tmptotalvalue = dgv.Rows[r].Cells["totalprice"].Value == null ? "0" : dgv.Rows[r].Cells["totalprice"].Value.ToString();
                    if (Double.TryParse(tmptotalvalue, out tmpprice))
                    {
                        try
                        {
                            totalPrice += tmpprice;
                        }
                        catch (Exception ex)
                        {
                            showError(ex.Message);
                        }
                    }
                }
                this.updatePanel(count.ToString(), totalPrice.ToString());
            }


        }


        private void updatePanel(string count, string totalPrice)
        {
            this.labelCount.Text ="总条数："+ count;
            this.labelTotalPrice.Text ="总金额："+ totalPrice;
            this.splitContainer3.Panel2.Update();
        }

        /// <summary>
        /// 获取单元格（名称）编辑之前的数据 用于存储项目字典
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "nameDataGridViewTextBoxColumn")
            //{
            //    //赋值给原始值
            //    this.ScanDataGridView.CurrentRow.Cells["oldName"].Value = this.ScanDataGridView.CurrentCell.Value.ToString();
            //}
        }

        /// <summary>
        /// 获取单元格（名称）编辑之后的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "nameDataGridViewTextBoxColumn")
            {
                this.endName = this.ScanDataGridView.CurrentCell.Value == null ? "" : this.ScanDataGridView.CurrentCell.Value.ToString();
                this.beginName = this.ScanDataGridView.CurrentRow.Cells["oldName"].Value == null ? "" : this.ScanDataGridView.CurrentRow.Cells["oldName"].Value.ToString();


                //编辑项目名称之后  再次获取对照关系 
                Hashtable htFirst = getItemDictRowByScanName(this.endName);
                if (htFirst.Count > 0)
                {
                    //  ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];
                    DataRow centerRow = (DataRow)htFirst["row"];
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value = centerRow["Code"].ToString();
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterName"].Value = centerRow["Name"].ToString();
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["ItemType"].Value = centerRow["ItemType"].ToString();
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["FeeType"].Value = centerRow["FeeType"].ToString();

                    //if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                    //{
                    //    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, centerRow.Code, frcode);

                    //}

                }
                else
                {
                    Hashtable ht = getItemDictRowByKeyWord(this.endName);
                    if (ht.Count > 0)
                    {
                       // ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)ht["row"];
                       DataRow centerRow= (DataRow)ht["row"];
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value = centerRow["Code"].ToString();
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterName"].Value = centerRow["Name"].ToString();
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["ItemType"].Value = centerRow["ItemType"].ToString();
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["FeeType"].Value = centerRow["FeeType"].ToString();
                        //if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                        //{
                        //    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, centerRow.Code, frcode);

                    }

                }




                string newCentercode = this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value == null ? "" : this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value.ToString();
                if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName) && String.IsNullOrEmpty(newCentercode))//没有取到对照关系也保存一份，
                {
                    if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                    {
                        new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, "", frcode);
                    }

                }


                //中心编码不为空  更新对照关系
                if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName) && !String.IsNullOrEmpty(newCentercode))
                {
                    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, newCentercode, frcode);

                }




            }

            //删除中心名称 清空中心编码 
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "CenterName")
            {
                if (this.ScanDataGridView.CurrentCell.Value == DBNull.Value)
                {
                    this.ScanDataGridView.CurrentRow.Cells["centercode"].Value = null;
                }
            }
        }

        public void UpdateItemDictRelation(string oldName, string newName, string centercode)
        {

            new Business.ItemProcess().UpdateItemDictRelation(oldName, newName, centercode,this.frcode);

        }


        /// <summary>
        /// 通过scanname showname 获取,加载数据的时候，两个值相等
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Hashtable getItemDictRowByScanName(string data)
        {
            Hashtable ht = new Hashtable();
          
            int count = 0;
            string centercode = "";
            string firstCenterCode = "";
            string showname = "";
            DataTable dtItemDict = null;
            //改成存储过程
            DataSet ds = new Business.ItemProcess().GetItemDict(this.frcode, data);
            if (ds.Tables.Count > 0)
            {
                dtItemDict = ds.Tables[0];
                if (dtItemDict.Rows.Count > 0)
                {
                    DataRow dr = dtItemDict.Rows[0];
                    centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
                    showname = dr["showname"] == null ? "" : dr["showname"].ToString();
                    if (!String.IsNullOrEmpty(centercode))
                    {
                        if (String.IsNullOrEmpty(firstCenterCode))
                        {
                            firstCenterCode = centercode;
                        }

                    }
                }
            }



            if (!String.IsNullOrEmpty(firstCenterCode))
            {
               
                 DataSet dsDict= new Business.DictProcess().GetItemByID(firstCenterCode);
                if (dsDict.Tables.Count > 0)
                {
                    DataTable dtDict = dsDict.Tables[0];
                    if (dtDict.Rows.Count > 0)
                    {
                       // ScanDataSet.CenterDataRow centerDataRow = (ScanDataSet.CenterDataRow)dtDict.Rows[0];
                       DataRow centerDataRow = dtDict.Rows[0];

                        ht.Add("row", centerDataRow);
                       
                    
                        return ht;
                    }
                }
                
            }

            return ht;
        }


        private Hashtable getItemDictRowByKeyWord(string data)
        {
            Hashtable ht = new Hashtable();
          
            string centercode = "";
            string firstCenterCode = "";
       

            DataTable dtItemDict = new Business.DictProcess().GetItemDictByKeyWord(data).Tables[0];
            if (dtItemDict.Rows.Count > 0)
            {
                for (int i = 0; i < dtItemDict.Rows.Count; i++)
                {
                    DataRow dr = dtItemDict.Rows[i];
                    if (data.IndexOf(dr["keyword"].ToString()) > -1)
                    {
                        centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
                        if (!String.IsNullOrEmpty(centercode))
                        {
                            if (String.IsNullOrEmpty(firstCenterCode))
                            {
                                firstCenterCode = centercode;
                            }

                           

                        }
                    }
                }
            }

            if (!String.IsNullOrEmpty(firstCenterCode))
            {

                DataSet dsDict = new Business.DictProcess().GetItemByID(firstCenterCode);
                if (dsDict.Tables.Count > 0)
                {
                    DataTable dtDict = dsDict.Tables[0];
                    if (dtDict.Rows.Count > 0)
                    {
                        //  ScanDataSet.CenterDataRow centerDataRow = (ScanDataSet.CenterDataRow)dtDict.Rows[0];
                        DataRow centerDataRow = dtDict.Rows[0];
                        ht.Add("row", centerDataRow);


                        return ht;
                    }
                }

            }

            return ht;
        }


        //一键对照
        private void MapDictForNull()
        {

            if (this.ScanDataGridView.Rows.Count > 1)
            {
                for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
                {
                    string centercode = this.ScanDataGridView.Rows[i].Cells["centercode"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["centercode"].Value.ToString();

                    if (String.IsNullOrEmpty(centercode))
                    {
                        string name = this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                        Hashtable htFirst = getItemDictRowByScanName(name);
                        if (htFirst.Count > 0)
                        {
                            //ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];
                            DataRow centerRow = (DataRow)htFirst["row"];
                            centercode = centerRow["Code"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["centercode"].Value = centerRow["Code"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["centername"].Value = centerRow["Name"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["FeeType"].Value = centerRow["FeeType"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["ItemType"].Value = centerRow["ItemType"].ToString();

                          
                        }

                        if (String.IsNullOrEmpty(centercode))
                        {
                            //取关键字like
                            Hashtable ht = getItemDictRowByKeyWord(name);
                            if (ht.Count > 0)
                            {
                                //ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];

                                //this.ScanDataGridView.Rows[i].Cells["centercode"].Value = centerRow.Code;
                                //this.ScanDataGridView.Rows[i].Cells["centername"].Value = centerRow.Name;
                                //this.ScanDataGridView.Rows[i].Cells["FeeType"].Value = centerRow.FeeType;
                                //this.ScanDataGridView.Rows[i].Cells["ItemType"].Value = centerRow.ItemType;
                                DataRow centerRow = (DataRow)ht["row"];
                                centercode = centerRow["Code"].ToString();
                                this.ScanDataGridView.Rows[i].Cells["centercode"].Value = centerRow["Code"].ToString();
                                this.ScanDataGridView.Rows[i].Cells["centername"].Value = centerRow["Name"].ToString();
                                this.ScanDataGridView.Rows[i].Cells["FeeType"].Value = centerRow["FeeType"].ToString();
                                this.ScanDataGridView.Rows[i].Cells["ItemType"].Value = centerRow["ItemType"].ToString();
                            }

                        }


                    }
                }
            }
        }



        private void showError(String errorMessage)
        {
            this.messageToolStripStatusLabel.Text = errorMessage;

        }

        private void ScanDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }


        /// <summary>
        /// 保存方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            
                ////开启子线程弹出正在处理form 初始化之后之后关闭加载框
                //MyProgressWait = new Thread(ProgressBarWait);
                //MyProgressWait.Start();


                this.clearGridView();
                this.save(this.pid);

                //this.loadForm.DialogResult = DialogResult.OK;
           
           
        }

        private void save(string id)
        {
            if (this.ScanDataGridView.Rows.Count > 1)
            {
                try
                {
                    DataTable dt = (DataTable)this.ScanDataGridView.DataSource;
                    //循环处理数据
                    bool result = true;
                    int rowcount = dt.Rows.Count;
                    //获取保存在dataset中的数据
                    if (dt.Rows.Count > 1)
                    {
                        //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
                        this.ScanDataGridView.EndEdit();

                        ((IEditableObject)this.ScanDataGridView.CurrentRow.DataBoundItem).EndEdit();
                        this.ScanDataGridView.CurrentCell = null;
                        Application.DoEvents();

                        for (int i = 0; i < dt.Rows.Count; i++)
                        {

                            dt.Rows[i]["pid"] = id;
                            dt.Rows[i]["paydate"] = System.DateTime.Now.ToShortDateString();
                            string code = dt.Rows[i]["code"] == null ? i.ToString() : dt.Rows[i]["code"].ToString();
                            if (String.IsNullOrEmpty(code))
                            {
                                dt.Rows[i]["code"] = i.ToString();
                            }

                            string detailGUID = dt.Rows[i]["DetailGUID"] == null ? Guid.NewGuid().ToString() : dt.Rows[i]["DetailGUID"].ToString();
                            if (String.IsNullOrEmpty(detailGUID))
                            {
                                dt.Rows[i]["DetailGUID"] = Guid.NewGuid().ToString();
                            }
                            string centercode = dt.Rows[i]["centercode"] == null ? i.ToString() : dt.Rows[i]["centercode"].ToString();
                            string itemname = dt.Rows[i]["name"] == null ? "" : dt.Rows[i]["name"].ToString();
                            if (String.IsNullOrEmpty(centercode))
                            {
                                MessageBox.Show("中心编码不能为空!项目名称:【" + itemname + "】");
                                return;
                            }



                            string centername = "";
                            DataTable dtname = new Business.DictProcess().GetItemByID(centercode).Tables[0];
                            if (dtname.Rows.Count > 0)
                            {
                                centername = dtname.Rows[0]["name"].ToString();
                            }

                            dt.Rows[i]["centername"] = centername;
                        }



                        result= new Business.ItemProcess().SaveAndUpdateDetail(dt);



                        if (result)
                        {
                            //this.loadForm.DialogResult = DialogResult.OK;
                            MessageBox.Show("保存成功");
                            return;
                        }
                        else
                        {
                            MessageBox.Show("保存失败!");
                            return;
                        }

                    }
                }
                catch (Exception ex)
                {
                    showError(ex.ToString());
                }
            }
        }

        
     

       private void upload()
        {
            
                DataSet dsZyjl = new Business.MainList().GetZyjlById(Int32.Parse(this.pid));
                if (dsZyjl.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("请先登记再上传！");
                    return;
                }


                DataRow dr = dsZyjl.Tables[0].Rows[0];

                string result = "";
                try
                {
                    result = new Business.MainList().UploadZyjl(dr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("上传失败!==>" + ex.ToString(), "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    return;
                }

                /*
                <?xml version="1.0" encoding="UTF-8"?><businessdata><functioncode>200222</functioncode><state>0</state><result/><remark1/><remark2/><remark3/><remark4/><remark5/></businessdata>
                */
                //this.TopMost = false;
                if (!String.IsNullOrEmpty(result))
                {
                    XmlDocument xdResult = new XmlDocument();
                    xdResult.LoadXml(result);
                    XmlElement rootResult = xdResult.DocumentElement;
                    string state = rootResult.SelectSingleNode("state").InnerText;


                    if (state.Equals("0"))
                    {
                        bool result1 = new Business.MainList().UpdateUploadZyjlById(dr["id"].ToString());
                        bool result2 = new Business.MainList().UpdateUploadFymxByPId(dr["id"].ToString());
                        if (result1 && result2)
                        {
                            MessageBox.Show("上传成功!", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }
                        else
                        {
                            MessageBox.Show("上传成功!更新上传标识异常！", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }

                    }
                    else
                    {
                        MessageBox.Show("上传失败!==>" + rootResult.SelectSingleNode("result").InnerText, "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    }
                }
                else
                {
                    MessageBox.Show("上传失败!==>上传返回结果为空！", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                }

            
        }


        /// <summary>
        /// 上传方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpload_Click(object sender, EventArgs e)
        {
            ////开启子线程弹出正在处理form 初始化之后之后关闭加载框
            //MyProgressWait = new Thread(ProgressBarWait);
            //MyProgressWait.Start();


            this.clearGridView();
            this.upload();

         //   this.loadForm.DialogResult = DialogResult.OK;

        }

  


        /// <summary>
        /// 继续扫描方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void button1_Click(object sender, EventArgs e)
        //{

        //    if (this.treeView1.SelectedNode != this.treeView1.Nodes[0] && this.treeView1.SelectedNode != null && this.treeView1.Nodes[0].IsExpanded)
        //    {
        //        string id = this.treeView1.SelectedNode.Tag.ToString();
        //        DataSet dsZyjl = new Business.MainList().GetZyjlById(Int32.Parse(id));
        //        if (dsZyjl.Tables[0].Rows.Count < 1)
        //        {
        //            MessageBox.Show("未查到该患者的住院记录！");
        //            return;
        //        }
        //        string inhosGuid = dsZyjl.Tables[0].Rows[0]["GUID"].ToString();
        //        string pname = dsZyjl.Tables[0].Rows[0]["name"].ToString();
        //        //赋值给mainform 
        //        MainForm mainForm = null;
        //        if (this.Owner is MainForm)
        //        {
        //            mainForm = ((MainForm)this.Owner);
                   
        //        }
        //        else
        //        {
        //            mainForm = new MainForm();
        //        }

        //        mainForm.Show();
        //        mainForm.DialogResult = DialogResult.OK;

        //        mainForm.callBack(inhosGuid, pname, null);
        //        this.Close();

        //    }
        //    else
        //    {
        //        MessageBox.Show("请先选择要扫描的患者信息!");
        //        return;
        //    }
        //}

       

        private void SelectToolStripButton_Click(object sender, EventArgs e)
        {
         
            //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
            this.ScanDataGridView.EndEdit();


            this.ScanDataGridView.CurrentCell = null;
            Application.DoEvents();

            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {

                this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = true;
            }
        }

        private void DeSelectToolStripButton_Click(object sender, EventArgs e)
        {
          
            //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
            this.ScanDataGridView.EndEdit();

            this.ScanDataGridView.CurrentCell = null;
            Application.DoEvents();

            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {

                this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = false;
            }
        }

        private void MapAllToolStripButton_Click(object sender, EventArgs e)
        {
            //判断选中几行
            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {

                if (this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                {
                    //获取comboxvalue
                    if (this.DictToolStripComboBox.SelectedItem.ToString() != "请选择")
                    {
                     
                        string centercodet = this.dictHT[this.DictToolStripComboBox.SelectedItem.ToString()].ToString();


                      
                            
                        string endName = this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                        string beginName = this.ScanDataGridView.Rows[i].Cells["oldName"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["oldName"].Value.ToString();


                        DataSet ds = new Business.DictProcess().GetItemByID(centercodet);

                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            DataRow dr = ds.Tables[0].Rows[0];

                            this.ScanDataGridView.Rows[i].Cells["centercode"].Value = dr["code"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["centername"].Value = dr["name"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["itemtype"].Value = dr["itemtype"].ToString();
                            this.ScanDataGridView.Rows[i].Cells["feetype"].Value = dr["feetype"].ToString();

                            //批量对照之后 更新对照关系
                            if (!String.IsNullOrEmpty(beginName.Trim()) && !String.IsNullOrEmpty(endName.Trim()))
                            {
                                new Business.ItemProcess().UpdateItemDictRelation(beginName, endName, dr["code"].ToString(), frcode);
                            }

                            //对照之后 更新当前行非选中   
                            this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = false;

                        }




                    }
                    else
                    {
                        MessageBox.Show("请选择要对照的中心项目!");
                        return;
                    }
                }

            }


        }

       

        private void ModifyInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.clear();
        }


        private void clear()
        {
            this.TipToolStripStatusLabel.Text = "当前患者：";
            this.ScanDataGridView.DataSource = null;
        }

        private void deleteFyToolStripButton_Click(object sender, EventArgs e)
        {
            //判断选中几行
            try
            {
                int count = 0;
                for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
                {

                    if (this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                    {
                        count++;

                        string detailID = this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["id"].Index].Value.ToString();
                        bool result = new Business.MainList().DelDetailByID(detailID);
                        if (result)
                        {
                            MessageBox.Show("删除成功!");

                            //加载费用明细
                            this.BindData(this.pid);

                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除失败!");
                            return;
                        }
                    }

                }
                if (count.Equals(0))
                {
                    MessageBox.Show("没有选中要删除的记录!");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void ProgressBarWait()
        {
            loadForm = new LoadForm();
            loadForm.MdiParent = this.MdiParent;
            loadForm.ShowDialog();
            if (loadForm.DialogResult == DialogResult.OK)
            {
                loadForm.Dispose();
                loadForm.Close();
            }

        }


    }
}
