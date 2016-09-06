using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class DictViewForm : Form
    {
        int pageSize = 0;     //每页显示行数
        int nMax = 0;         //总记录数
        int pageCount = 0;    //页数＝总记录数/每页显示行数
        int pageCurrent = 0;   //当前页号
        int nCurrent = 0;      //当前记录行
        DataTable dtInfo = new DataTable();
        SolidBrush solidBrush;
        public DictViewForm()
        {
            InitializeComponent();
            solidBrush = new SolidBrush(this.dgvDict.RowHeadersDefaultCellStyle.ForeColor);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = this.tbCondition.Text.Trim();
            if (!String.IsNullOrEmpty(str))
            {
                DataSet ds = new Business.DictProcess().GetItemByStr(str);
                if (ds.Tables.Count > 0)
                {
                    dtInfo = ds.Tables[0];
                    if (dtInfo.Rows.Count > 0)
                    {
                        InitDataSet();
                    }
                }
            }
           
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
            dgvDict.AutoGenerateColumns = false;
            dgvDict.DataSource = dtTemp;

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
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), this.dgvDict.DefaultCellStyle.Font, solidBrush, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);


        }

        private void tbCondition_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(this.tbCondition.Text.Trim()))
            {
                this.button1_Click(null,null);
            }
            else
            {
                this.dgvDict.DataSource = null;
            }
        }


        

      
    }

}
