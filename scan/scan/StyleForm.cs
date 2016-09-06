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
    public partial class StyleForm : Form
    {
        DataTable styleDt=null;
        string frcode = Util.Util.GetAppSetting("rcode");
        public StyleForm()
        {
            InitializeComponent();
          
        }

        private void StyleForm_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("value");
            dt.Columns.Add("name");
            dt.Rows.Add(new string[] { "", "请选择" });
            dt.Rows.Add(new string[] { "Code", "项目代码" });
            dt.Rows.Add(new string[] { "Name", "项目名称" });
            dt.Rows.Add(new string[] { "Spec", "规格" });
            dt.Rows.Add(new string[] { "Quantum", "数量" });
            dt.Rows.Add(new string[] { "Unit", "单位" });
            dt.Rows.Add(new string[] { "Price", "单价" });
            dt.Rows.Add(new string[] { "TotalPrice", "金额" });
            dt.Rows.Add(new string[] { "Rate", "其他" });
            for (int i = 1; i <= 9; i++)
            {
                ComboBox comboBox = (ComboBox)styleGroupBox.Controls["comboBox" + i];
                comboBox.DisplayMember = "name";
                comboBox.ValueMember = "value";
                comboBox.DataSource = dt.Copy();
            }

        }

         public void setBillStyle(string styleName, string styleValue)
        {
            styleDt.Rows.Add(new string[] { styleValue, styleName });
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            String billStyle = "";
            String billStyleName = "";
            int endIndex = 0;

            for (int i = 9; i >= 1; i--)
            {
                ComboBox comboBox = (ComboBox)styleGroupBox.Controls["comboBox" + i];
                string comdata = comboBox.SelectedValue.ToString();
                if (!String.IsNullOrEmpty(comdata))
                {
                    endIndex = i;
                    break;
                }

            }
            for (int j = 1; j <= endIndex; j++)
            {
                ComboBox comboBox = (ComboBox)styleGroupBox.Controls["comboBox" + j];
                string comdata = comboBox.SelectedValue.ToString();
                billStyle += comdata + ",";
                billStyleName += comboBox.Text+",";
            }
            if (billStyle.Length >= 2)
            {
                billStyle = billStyle.Substring(0, billStyle.Length - 1);
            }


            string newStyleID = "";
           
                Hashtable data = new Hashtable();
                data["code"] = billStyle;
                data["name"] = billStyleName;
                data["frcode"] = this.frcode;
                newStyleID=new Business.DictProcess().InsertStyle(data);
            

            IStyleOwner owner = (IStyleOwner)this.Owner;

            owner.setBillStyle(billStyleName, billStyle, newStyleID);

            this.Close();
        }
    }
}
