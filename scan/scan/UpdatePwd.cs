using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class UpdatePwd : Form
    {
        public UpdatePwd()
        {
            InitializeComponent();
            EnterToTab();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string oldUserCode = this.tbOldUserCode.Text.Trim();
            string oldPwd=this.tbOldPwd.Text.Trim();
            string newPwd=this.tbNewPwd.Text.Trim();
            //if(String.IsNullOrEmpty(oldPwd)||String.IsNullOrEmpty(newPwd))
            //{
            //  MessageBox.Show("密码不能为空！");
            //    return;
            //}

            //if (Util.Util.EncrptMd5(oldPwd).Equals(System.Configuration.ConfigurationManager.AppSettings["password"].ToString()))
            //{

            //    System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
            //    configuration.AppSettings.Settings["password"].Value = Util.Util.EncrptMd5(newPwd);
            //    configuration.Save();


            //    this.DialogResult = DialogResult.OK;
            //    MessageBox.Show("密码修改成功!");
            //}

            try
            {
                ScanDataSet scanDataSet = new Business.UserInfo().GetUserByUserInfo(oldUserCode, oldPwd);
                if (scanDataSet.UserInfo.Rows.Count < 1)
                {
                    MessageBox.Show("用户名或密码错误!");
                    return;
                }

                //获取用户信息通过 则更新密码
                if (!String.IsNullOrEmpty(newPwd))
                {

                    DataTable dt = scanDataSet.UserInfo;
                    dt.Rows[0]["password"] = newPwd;
                    bool result = new Business.UserInfo().UpdateUser(dt);
                    if (result)
                    {
                        MessageBox.Show("密码修改成功!");
                        //关闭窗口
                        this.Close();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("新密码不能为空!");
                    return;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void EnterToTab()
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(UpdatePwd_KeyPress);
        }

        private void UpdatePwd_KeyPress(object sender, KeyPressEventArgs e)
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

    }
}
