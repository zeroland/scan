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
    public partial class AddForm : Form, IStyleOwner
    {
        
        public string hdInhosDia;
        public string hdOutHosDia;
        public string hdInHosDept;
        public string hdOutHosDept;
        public string hdInhosOrg;
        private string frcode = Util.Util.GetAppSetting("rcode");
        DataTable styleDt;

        public AddForm()
        {
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
           
            BindCbInhosType();
            BindCbInhosState();
            BindCbOuthosState();
            BindBillStyle();
        }

     

        //住院类型
        private void BindCbInhosType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("dictcode");
            dt.Columns.Add("dictname");
            dt.Rows.Add(new string[] { "2", "普通住院" });
            dt.Rows.Add(new string[] { "89", "重大疾病" });


            this.cbInhosType.DisplayMember = "dictname";
            this.cbInhosType.ValueMember = "dictcode";


            this.cbInhosType.DataSource = dt;
            
        }

    //绑定样式
        private void BindBillStyle()
        {
            styleDt = new Business.DictProcess().GetStyle(this.frcode).Tables[0];


            this.styleComboBox.DisplayMember = "name";
            this.styleComboBox.ValueMember = "id";


            this.styleComboBox.DataSource = styleDt;
        }


        //入院状态
        private void BindCbInhosState()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("dictcode");
            dt.Columns.Add("dictname");
            dt.Rows.Add(new string[] { "1", "危" });
            dt.Rows.Add(new string[] { "2", "急" });
            dt.Rows.Add(new string[] { "3", "一般" });
            dt.Rows.Add(new string[] { "9", "其他" });


            this.cbInhosStatus.DisplayMember = "dictname";
            this.cbInhosStatus.ValueMember = "dictcode";


            this.cbInhosStatus.DataSource = dt;

        }

        //出院状态
        private void BindCbOuthosState()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("dictcode");
            dt.Columns.Add("dictname");
            dt.Rows.Add(new string[] { "1", "治愈" });
            dt.Rows.Add(new string[] { "3", "未愈" });
            dt.Rows.Add(new string[] { "4", "死亡" });
            dt.Rows.Add(new string[] { "2", "好转" });
            dt.Rows.Add(new string[] { "9", "其他" });

            this.cbOutHospStatus.DisplayMember = "dictname";
            this.cbOutHospStatus.ValueMember = "dictcode";


            this.cbOutHospStatus.DataSource = dt;

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
            //获取form数据
            string fmcard= this.tbMcard.Text.Trim();
            string fname = this.tbName.Text.Trim() ;
            string fidcard = this.tbIdcard.Text.Trim();
            string finhosnum = this.tbInhosNum.Text.Trim();
            string finhosorg = this.hdInhosOrg;
            string finhostype = this.cbInhosType.SelectedValue.ToString();
            string finhosdept = this.hdInHosDept;
            string finhosdeptname = this.tbInhosDept.Text.Trim();
           // DateTime finhosdate = this.dtInhos.Value;
            string finhosdate = this.dtInhos.Value.ToShortDateString();
            string finhosstatus = this.cbInhosStatus.SelectedValue.ToString();
            string finhosdia = this.hdInhosDia;
            string fouthosdia = this.hdOutHosDia;
            string fouthosdept = this.hdOutHosDept;
           // DateTime fouthosdate = this.dtOutHosp.Value;
            string fouthosdate = this.dtOutHosp.Value.ToShortDateString();
            int finhosdays = (Convert.ToDateTime(fouthosdate) - Convert.ToDateTime(finhosdate)).Days + 1;
            string fouthosstatus = this.cbOutHospStatus.SelectedValue.ToString();
            string fjzys = this.tbDoctor.Text.Trim();
            string frcode = Util.Util.GetAppSetting("rcode");
            //"@sdx", "@zyh", "@yljg", "@ylzh", "@name", "@idcard", "@jzlx", "@rysj", "@cysj", "@sjzyts", "@ryks", "@ryksname", "@cyks", "@cyksname", "@jzys", "@ryzt", "@cyzt", "@ryzd", "@cyzd" };
            Hashtable ht = new Hashtable();
            ht.Add("sdx", frcode);
            ht.Add("zyh", finhosnum);
            ht.Add("yljg", finhosorg);
            ht.Add("ylzh", fmcard);
            ht.Add("name", fname);
            ht.Add("idcard", fidcard);
            ht.Add("jzlx", finhostype);
            ht.Add("rysj", finhosdate);
            ht.Add("cysj", fouthosdate);
            ht.Add("sjzyts", finhosdays);
            ht.Add("ryks", finhosdept);
         
            ht.Add("cyks", fouthosdept);
          
            ht.Add("jzys", fjzys);
            ht.Add("ryzt", finhosstatus);
            ht.Add("cyzt", fouthosstatus);
            ht.Add("ryzd", finhosdia);
            ht.Add("cyzd", fouthosdia);

            //保存时添加guid，同时向父窗体guid赋值
            string guid = Guid.NewGuid().ToString();
         

            ht.Add("guid",guid);



            bool result= new Business.MainList().InsertZyjl(ht);
            if (result)
            {
                
                MessageBox.Show(this, "保存成功!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                MainForm form = (MainForm)this.Owner;

                String billStyle = new Business.DictProcess().GetStyleByID(styleComboBox.SelectedValue.ToString()).Tables[0].Rows[0]["code"].ToString();

             
                String[] styles = billStyle.Split(',');
                form.callBack(guid, fname, styles);
                this.DialogResult = DialogResult.OK;
              //  this.Close();
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

       

       // private void QuickEntry_KeyDown(object sender, KeyEventArgs e)
       // {
        //    if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
         //   {
          //      Control ctrl = this.GetNextControl(this.ActiveControl, true);
           //     if (ctrl is TextBox == false && ctrl is ComboBox == false && ctrl is DateTimePicker == false && ctrl is Button == false)
           //     {
           //         ctrl = this.GetNextControl(ctrl, true);
           //     }
           //     ctrl.Focus();
         //   }

      //  }

        private void tbInhosDia_TextChanged_1(object sender, EventArgs e)
        {
           
            this.itemSearch1.SearchType = "Icd";
            this.itemSearch1.SearchText = tbInhosDia.Text.Trim();
            this.itemSearch1.ControlId = "tbInhosDia";
            this.itemSearch1.GetSearchData();

            if (itemSearch1.Visible == true)
            {
                itemSearch1.Visible = false;
            }
            if (itemSearch1.Visible == false &&itemSearch1.Count>0)
            {
                
                itemSearch1.Location = new Point(this.InhospGroupBox.Location.X + this.tbInhosDia.Location.X, this.InhospGroupBox.Location.Y + this.tbInhosDia.Height + this.tbInhosDia.Location.Y);
                itemSearch1.Visible = true;
                //this.itemSearch1.Focus();
            }
            if (String.IsNullOrEmpty(tbInhosDia.Text.Trim()))
            {
                itemSearch1.Visible = false;
            }
         
        }

        private void tbInhosDept_TextChanged(object sender, EventArgs e)
        {
            
            this.itemSearch1.SearchType = "Dept";
            this.itemSearch1.SearchText = tbInhosDept.Text.Trim();
            this.itemSearch1.ControlId = "tbInhosDept";
            this.itemSearch1.GetSearchData();

            if (itemSearch1.Visible == true)
            {
                itemSearch1.Visible = false;
            }
            if (itemSearch1.Visible == false)
            {
               
                itemSearch1.Location = new Point(this.InhospGroupBox.Location.X + this.tbInhosDept.Location.X, this.InhospGroupBox.Location.Y + this.tbInhosDept.Height + this.tbInhosDept.Location.Y);
                itemSearch1.Visible = true;
                //this.itemSearch1.Focus();
            }
            if (String.IsNullOrEmpty(tbInhosDept.Text.Trim()))
            {
                itemSearch1.Visible = false;
            }
        }

        private void tbOutHospDia_TextChanged(object sender, EventArgs e)
        {
            this.itemSearch1.SearchType = "Icd";
            this.itemSearch1.SearchText = tbOutHospDia.Text.Trim();
            this.itemSearch1.ControlId = "tbOutHospDia";
            this.itemSearch1.GetSearchData();

            if (itemSearch1.Visible == true)
            {
                itemSearch1.Visible = false;
            }
            if (itemSearch1.Visible == false)
            {
                
                itemSearch1.Location = new Point(this.InhospGroupBox.Location.X + this.tbOutHospDia.Location.X, this.InhospGroupBox.Location.Y + this.tbOutHospDia.Height + this.tbOutHospDia.Location.Y);
                itemSearch1.Visible = true;
                //this.itemSearch1.Focus();
            }
            if (String.IsNullOrEmpty(tbOutHospDia.Text.Trim()))
            {
                itemSearch1.Visible = false;
            }

        }

        private void tbOutDept_TextChanged(object sender, EventArgs e)
        {
            this.itemSearch1.SearchType = "Dept";
            this.itemSearch1.SearchText = tbOutDept.Text.Trim();
            this.itemSearch1.ControlId = "tbOutDept";
            this.itemSearch1.GetSearchData();

            if (itemSearch1.Visible == true)
            {
                itemSearch1.Visible = false;
            }
            if (itemSearch1.Visible == false)
            {
               
                itemSearch1.Location = new Point(this.InhospGroupBox.Location.X + this.tbOutDept.Location.X, this.InhospGroupBox.Location.Y + this.tbOutDept.Height + this.tbOutDept.Location.Y);
                itemSearch1.Visible = true;
               
                //this.itemSearch1.Focus();
            }

            if (String.IsNullOrEmpty(tbOutDept.Text.Trim()))
            {
                itemSearch1.Visible = false;
            }
        }

        private void tbInhosOrg_TextChanged(object sender, EventArgs e)
        {
            this.itemSearch1.SearchType = "Org";
            this.itemSearch1.SearchText = tbInhosOrg.Text.Trim();
            this.itemSearch1.ControlId = "tbInhosOrg";
            this.itemSearch1.GetSearchData();

            if (itemSearch1.Visible == true)
            {
                itemSearch1.Visible = false;
            }
            if (itemSearch1.Visible == false)
            {

                itemSearch1.Location = new Point(this.InhospGroupBox.Location.X + this.tbInhosOrg.Location.X, this.InhospGroupBox.Location.Y + this.tbInhosOrg.Height + this.tbInhosOrg.Location.Y);
                itemSearch1.Visible = true;
                //this.itemSearch1.Focus();
            }
            if (String.IsNullOrEmpty(tbInhosOrg.Text.Trim()))
            {
                itemSearch1.Visible = false;
            }
        }

        private void tbInhosDept_Leave(object sender, EventArgs e)
        {
            //if (itemSearch1.Visible == true)
            //{
            //    itemSearch1.Visible = false;
            //}
        }

        private void tbInhosDept_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down)&& itemSearch1.Visible==true)
            {
                
                DataGridView ctl = ((DataGridView)this.itemSearch1.Controls["dataGridView1"]);
                int rowCount= ctl.Rows.Count;
                if (e.KeyCode == Keys.Down )
                {
                    int rowindex = ctl.SelectedRows[0].Index;
                    if (!(ctl.SelectedRows[0].Index == rowCount - 1))
                    {
                        ctl.Rows[ctl.SelectedRows[0].Index + 1].Selected = true;
                    }
                    else
                    {
                        ctl.Rows[ctl.SelectedRows[0].Index ].Selected = true;
                    }
                }

                if ( e.KeyCode == Keys.Up)
                {
                    int rowindex = ctl.SelectedRows[0].Index;
                    if (ctl.SelectedRows[0].Index == 0)
                    {
                        ctl.Rows[ctl.SelectedRows[0].Index].Selected = true;
                    }
                    else
                    {
                        ctl.Rows[ctl.SelectedRows[0].Index - 1].Selected = true;
                    }
                   

                }

                this.itemSearch1.ParentFormKeyDownToChild(sender,e);
            }
        }

      

        private bool ValidateControls()
        {
            bool errFlag = true;
            //foreach (Control control in this.InhospGroupBox.Controls)
            //{
            //    switch (control.GetType().Name)
            //    {
            //        case "TextBox":
            //            if (control.Text == "")
            //            {
            //                this.errorProvider1.SetError(control, "不能为空!");
            //                errFlag = false;
            //            }
            //            break;
            //        case "ComboBox":
            //            if (control.Text == ""&&control.Name!="cbName")
            //            {
            //                this.errorProvider1.SetError(control, "不能为空!");
            //                errFlag = false;
            //            }
            //            break;
            //    }
            //}
            //if (errFlag)
            //    this.errorProvider1.Clear();
            //return errFlag;
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

        public void setBillStyle(string styleName, string styleValue,string styleID)
        {
            // styleDt.Rows.Add(new string[] { styleName, styleID });
            BindBillStyle();
            styleComboBox.SelectedValue = styleID;
        }

        private void styleButton_Click(object sender, EventArgs e)
        {
            DialogResult result = new StyleForm().ShowDialog(this);
            if (result == DialogResult.OK)
            {

            }
        }
    }
}
