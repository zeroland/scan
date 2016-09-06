﻿using System;
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
            string oldPwd=this.tbOldPwd.Text.Trim();
            string newPwd=this.tbNewPwd.Text.Trim();
            if(String.IsNullOrEmpty(oldPwd)||String.IsNullOrEmpty(newPwd))
            {
              MessageBox.Show("密码不能为空！");
                return;
            }

            if (Util.Util.EncrptMd5(oldPwd).Equals(System.Configuration.ConfigurationManager.AppSettings["password"].ToString()))
            {

                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                configuration.AppSettings.Settings["password"].Value = Util.Util.EncrptMd5(newPwd);
                configuration.Save();

                
                this.DialogResult = DialogResult.OK;
                MessageBox.Show("密码修改成功!");
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
