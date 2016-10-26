using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;

using System.Windows.Forms;
using scan.Interface;

namespace scan
{
    public partial class AlterForm : Form
    {
        
        public string hdInhosDia;
        public string hdOutHosDia;
        public string hdInHosDept;
        public string hdOutHosDept;
        public string hdInhosOrg;
        private string frcode = Util.Util.GetAppSetting("rcode");
        DataTable styleDt;
        private string pid;
        DataTable dtZyInfo;

        public AlterForm()
        {
            InitializeComponent();
        }

        public AlterForm(string pid)
        {
            this.pid = pid;
            InitializeComponent();
        }




        private void QuickEntry_Load(object sender, EventArgs e)
        {
            //初始化窗体控件基值
            InitControls();
            EnterToTab();
        }


        private void InitControls()
        {

            InitInfo();
         
        }


        private void InitInfo()
        {
            if (!String.IsNullOrEmpty(this.pid))
            {
                DataSet ds= new Business.MainList().GetZyjlById(Int32.Parse(this.pid));
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    dtZyInfo = ds.Tables[0];
                    DataRow dr = dtZyInfo.Rows[0];
                    this.tbMcard.Text = dr["ylzh"].ToString();
                    this.tbName.Text = dr["name"].ToString();
                    this.tbInhosNum.Text = dr["zyh"].ToString();


                }
                else
                {
                    MessageBox.Show("未查询到要修改的住院信息！");
                    return;
                }
            }
        }
     

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

			if (!ValidateControls())
            {
                MessageBox.Show("输入不能为空，请核查!");
                return;
            }           

            DataRow dr= dtZyInfo.Rows[0];
            dr["ylzh"] = this.tbMcard.Text.Trim();
            dr["name"] = this.tbName.Text.Trim();
            dr["zyh"] = this.tbInhosNum.Text.Trim();



            bool result = new Business.ItemProcess().UpdateZyjl(dtZyInfo);
            if (result)
            {
                
                MessageBox.Show(this, "修改成功!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ((InhosList)this.Owner).loadDataByStr();
                this.DialogResult = DialogResult.OK;
              

            }
            else
            {
                MessageBox.Show(this, "保存失败!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Error);                
            }

            
            
        }

        

        private void EnterToTab()
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(QuickEntry_KeyPress);
        }

        private void QuickEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                Control ctrl = this.GetNextControl(this.ActiveControl, true);
                if (ctrl is TextBox == false && ctrl is ComboBox == false && ctrl is DateTimePicker == false && ctrl is Button == false)
                {
                    ctrl = this.GetNextControl(ctrl, true);
                }
                ctrl.Focus();
            }
        }

      
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        private bool ValidateControls()
        {
            bool errFlag = true;
    
            if (String.IsNullOrEmpty(this.tbMcard.Text.Trim()))
            {
                this.errorProvider1.SetError(tbMcard, "不能为空!");
                errFlag = false;
            }
            if (String.IsNullOrEmpty(this.tbInhosNum.Text.Trim()))
            {
                this.errorProvider1.SetError(tbInhosNum, "不能为空!");
                errFlag = false;
            }
            if (String.IsNullOrEmpty(this.tbName.Text.Trim()))
            {
                this.errorProvider1.SetError(tbName, "不能为空!");
                errFlag = false;
            }

            return errFlag;
        }
        

     
    }
}
