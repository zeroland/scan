using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            //EnterToTab();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

           
            string pwd = this.txtPwd.Text.Trim();
            if (!String.IsNullOrEmpty(pwd))
            {
                if (System.Configuration.ConfigurationManager.AppSettings["password"].ToString().Equals(Util.Util.EncrptMd5(pwd)))
                {
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("密码错误！");
                }
                
            }
            else
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
        }

        private void btnUpdatePwd_Click(object sender, EventArgs e)
        {
            UpdatePwd updatePwd = new UpdatePwd();
            if (updatePwd.ShowDialog() == DialogResult.OK)
            {
                updatePwd.Close();
            }
        }

        private void EnterToTab()
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(LoginForm_KeyPress);
        }

        private void LoginForm_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtPwd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnLogin_Click(null,null);
            }
        }
    }
}
