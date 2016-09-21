using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class InhosList : Form
    {
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        SolidBrush solidBrush;

        public string pid = "";//住院主记录ID 传到费用信息修改窗口  

        public InhosList()
        {
            InitializeComponent();
            solidBrush = new SolidBrush(this.dgvInhosList.RowHeadersDefaultCellStyle.ForeColor);
            loadDataByStr();          
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadDataByStr();

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
            dgvInhosList.AutoGenerateColumns = false;
            dgvInhosList.DataSource = dtTemp;

           

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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "上一页")
            {
                pageCurrent--;
                if (pageCurrent <= 0)
                {
                    this.UpPageToolStripButton.Enabled = false;
                    this.NextPagetoolStripButton.Enabled = true;
                    return;
                }
                else
                {
                    this.UpPageToolStripButton.Enabled = true;
                    this.NextPagetoolStripButton.Enabled = true;
                    nCurrent = pageSize * (pageCurrent - 1);
                }
                LoadData();
            }
            if (e.ClickedItem.Text == "下一页")
            {
                pageCurrent++;
                if (pageCurrent > pageCount)
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
                LoadData();
            }
        }

        private void dgvDict_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvInhosList.DefaultCellStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);


        }

        private void tbCondition_TextChanged(object sender, EventArgs e)
        {
            
             this.button1_Click(null,null);
                       
            
        }



        private void loadDataByStr()
        {
            string sdx = Util.Util.GetAppSetting("rcode");
            Hashtable ht = new Hashtable();

            if (!String.IsNullOrEmpty(this.tbName.Text.Trim()))
            {

                ht.Add("condition", this.tbName.Text.Trim());
            }
            

            DataTable dt = new Business.MainList().GetMainInfoList(sdx, ht).Tables[0];
            if (dt.Rows.Count > 0)
            {
                dtInfo = dt;
                InitDataSet();
                
            }
        }

        private void dgvInhosList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //获取行信息
            if (e.RowIndex < this.dgvInhosList.Rows.Count)
            {                
                 DataGridViewRow row= this.dgvInhosList.Rows[e.RowIndex];
                 this.pid = row.Cells[this.dgvInhosList.Columns["id"].Index].Value.ToString();

                //主信息id 传入到修改窗口 
                Form detailForm = new ModifyInfo(this.pid);
               
                detailForm.ShowDialog(this);


            }
        }

       

      

        private void dgvInhosList_Enter(object sender, EventArgs e)
        {
            //if (this.dgvInhosList.SelectedRows.Count > 0)
            //{
            //    int index= this.dgvInhosList.SelectedRows[0].Index;
            //    DataGridViewRow row = this.dgvInhosList.Rows[index];
            //    this.pid = row.Cells[this.dgvInhosList.Columns["id"].Index].Value.ToString();

            //    //主信息id 传入到修改窗口 
            //    Form detailForm = new ModifyInfo(this.pid);

            //    detailForm.ShowDialog(this);


            //}

        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{

           
        //    if (keyData == Keys.Enter)
        //    {
        //        // System.Windows.Forms.SendKeys.Send("{TAB}");
        //        if (this.dgvInhosList.SelectedRows.Count > 0)
        //        {
        //            int index = this.dgvInhosList.SelectedRows[0].Index;
        //            DataGridViewRow row = this.dgvInhosList.Rows[index];
        //            this.pid = row.Cells[this.dgvInhosList.Columns["id"].Index].Value.ToString();

        //            //主信息id 传入到修改窗口 
        //            Form detailForm = new ModifyInfo(this.pid);

        //            detailForm.ShowDialog(this);
        //            return true;
        //        }
        //    }
        //    //继续原来base.ProcessCmdKey中的处理　
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        private void btnClear_Click(object sender, EventArgs e)
        {
            
            this.tbName.Clear();
        }

        private void dgvInhosList_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
           
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            //判断选中几行
            try
            {
                int count = 0;
                for (int i = 0; i < this.dgvInhosList.Rows.Count; i++)
                {

                    if (this.dgvInhosList.Rows[i].Cells[this.dgvInhosList.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                    {
                        count++;

                        string zyID = this.dgvInhosList.Rows[i].Cells[this.dgvInhosList.Columns["id"].Index].Value.ToString();
                        bool result = new Business.MainList().DeleteZyjlById(zyID);
                        if (result)
                        {
                            MessageBox.Show("删除成功!");
                            loadDataByStr();
                            return;
                        }
                        else
                        {
                            MessageBox.Show("删除失败!");
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dgvInhosList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < this.dgvInhosList.Rows.Count)
            {
                if (this.dgvInhosList.CurrentCell.ColumnIndex == this.dgvInhosList.Columns["SelectCheck"].Index)
                {
                    if (this.dgvInhosList.CurrentCell.EditedFormattedValue.ToString() == "True")
                    {
                        this.dgvInhosList.CurrentCell.Value = false;
                    }
                    else
                    {
                        this.dgvInhosList.CurrentCell.Value = true;
                    }
                }
            }
        }


        private void btnSearchDetail_Click(object sender, EventArgs e)
        {
            //判断选中几行
            try
            {
                int count = 0;
                for (int i = 0; i < this.dgvInhosList.Rows.Count; i++)
                {

                    if (this.dgvInhosList.Rows[i].Cells[this.dgvInhosList.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                    {
                        count++;
                        if (count > 1)
                        {
                            MessageBox.Show("请选择一行要查询的记录！");
                            return;
                        }
                 
                        this.pid = this.dgvInhosList.Rows[i].Cells[this.dgvInhosList.Columns["id"].Index].Value.ToString();

                        //主信息id 传入到修改窗口 
                        Form detailForm = new ModifyInfo(this.pid);

                        detailForm.ShowDialog(this);

                         return;
                      
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("请选择要查询的记录！");
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

}
