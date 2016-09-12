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
            EnterToTab();
            Init();
        }

        private void Init()
        {
            //获取业务模式
            string immode = Util.Util.GetAppSetting("immode");
            switch (immode)
            {
                case "1":
                    this.InputRadioButton.Checked = true;
                    break;
                case "2":
                    this.UpdateRadioButton.Checked = true;
                    break;
                default:
                    this.InputRadioButton.Checked = true;
                    break;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            string usercode = this.tbUserCode.Text.Trim();
            string pwd = this.txtPwd.Text.Trim();
            //if (!String.IsNullOrEmpty(pwd))
            //{
            //    if (System.Configuration.ConfigurationManager.AppSettings["password"].ToString().Equals(Util.Util.EncrptMd5(pwd)))
            //    {
            //        this.DialogResult = DialogResult.OK;
            //    }
            //    else
            //    {
            //        MessageBox.Show("密码错误！");
            //    }

            //}
            //else
            //{
            //    MessageBox.Show("密码不能为空!");
            //    return;
            //}
            DataRow drUserInfo;
            if (!String.IsNullOrEmpty(pwd) && !String.IsNullOrEmpty(usercode))
            {
                ScanDataSet scanDataSet = new Business.UserInfo().GetUserByUserInfo(usercode, pwd);
                if (scanDataSet.UserInfo.Rows.Count < 1)
                {
                    MessageBox.Show("用户名或密码错误!");
                    return;
                }

                //校验启用状态
                 drUserInfo = scanDataSet.UserInfo.Rows[0];
                if (!drUserInfo["status"].ToString().Equals("1"))
                {
                    MessageBox.Show("该用户未启用!");
                    return;
                }

            }
            else if (String.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
            else if (String.IsNullOrEmpty(usercode))
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            else
            {
                MessageBox.Show("登录未知错误!");
                return;
            }

            //记录业务模式 计入配置文件中 key: immode value:1,录入;2,修改
            string immode = "";
            if (this.InputRadioButton.Checked)
                immode = "1";
            if (this.UpdateRadioButton.Checked)
                immode = "2";
            Util.Util.WriteAppSetting("immode", immode, false);
         

            //通过用户对应信息 修改配置 
            this.UpdateConfigByUser(drUserInfo);

            this.DialogResult = DialogResult.OK;
        }


        private void UpdateConfigByUser(DataRow dr)
        {
            //更新县区编码
            string frcode = dr["frcode"].ToString();
            Util.Util.WriteAppSetting("rcode", frcode, false);
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
