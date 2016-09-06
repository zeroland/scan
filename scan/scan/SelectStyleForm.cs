using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using scan.Interface;
using System.Collections;

namespace scan
{
    public partial class SelectStyleForm : Form, IStyleOwner
    {
        DataTable styleDt;
        string frcode = Util.Util.GetAppSetting("rcode");
        public SelectStyleForm()
        {
            InitializeComponent();
        }

        private void SelectStyleForm_Load(object sender, EventArgs e)
        {
              //住院类型

            this.loadStyle();



        }

        private void loadStyle()
        {
            styleDt = new Business.DictProcess().GetStyle(frcode).Tables[0];


            this.styleComboBox.DisplayMember = "name";
            this.styleComboBox.ValueMember = "id";


            this.styleComboBox.DataSource = styleDt;
        }


        public void setBillStyle(string styleName, string styleValue,string styleID)
        {
            // styleDt.Rows.Add(new string[] { styleName, styleID });
            this.loadStyle();
            styleComboBox.SelectedValue = styleID;
            
        }

        private void styleButton_Click(object sender, EventArgs e)
        {
            DialogResult result = new StyleForm().ShowDialog(this);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            MainForm form = (MainForm)this.Owner;

            String billStyle = new Business.DictProcess().GetStyleByID(styleComboBox.SelectedValue.ToString()).Tables[0].Rows[0]["code"].ToString();
                        
            String[] styles = billStyle.Split(',');
            form.setBillStyle(styles);
            this.Close();
        }

        private void delButton_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult=MessageBox.Show("确定是否要删除？", "删除提醒", MessageBoxButtons.YesNo);
           if (dialogResult == DialogResult.Yes)
           {
               String id = styleComboBox.SelectedValue.ToString();

                Business.DictProcess dictProcess = new Business.DictProcess();
                //公共不能删除
                DataTable dtStyle= dictProcess.GetStyleByID(id).Tables[0];
                string strFrcode = "";
                if (dtStyle.Rows.Count > 0)
                {
                    strFrcode= dtStyle.Rows[0]["frcode"].ToString();
                    if (!strFrcode.Equals(Util.Util.GetAppSetting("rcode")))
                    {
                        MessageBox.Show("不能删除公共格式!","删除提醒");
                        return;
                    }
                }

               Hashtable data = new Hashtable();
               data["id"] = id;
               bool result= dictProcess.DelStyle(data);
               if (result)
               {                   
                   MessageBox.Show("删除成功！", "删除提醒");
                   this.loadStyle();
               }
           }
        }

    }
}
