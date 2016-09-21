using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class AddUser : Form
    {
        
        ScanDataSet.UserInfoDataTable userTable;
        DataRow userRow;
        ScanDataSet.UserInfoRow userInfoRow;
        
        public AddUser()
        {
            InitializeComponent();
            EnterToTab();
            
        }



        public void Init()
        {
            this.GetOwnOrg();
        }

        private void GetOwnOrg()
        {
            UserManager userManager = (UserManager)this.Owner;
            //获取所属机构
            ScanDataSet scanDataSet = new Business.OrgInfo().GetOrgByStr(" and orgid='" + userManager.orgID + "'");
            if (scanDataSet.BaseOrgInfo.Rows.Count > 0)
            {
                this.tbOrg.Text = scanDataSet.BaseOrgInfo.Rows[0]["orgname"].ToString();
            }
            else
            {
                MessageBox.Show("获取所属机构失败！");
                return;
            }

            //如果是修改加载主信息
            this.LoadUserInfo();
        }


        private void EnterToTab()
        {
            this.KeyPreview = true;
            this.KeyPress += new KeyPressEventHandler(AddUser_KeyPress);
        }


        private void AddUser_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter || e.KeyChar == (char)Keys.Tab)
            {
                Control ctrl = this.GetNextControl(this.ActiveControl, true);
                if (ctrl is TextBox == false && ctrl is ComboBox == false && ctrl is DateTimePicker == false && ctrl is Button == false&&ctrl is RadioButton==false)
                {
                    ctrl = this.GetNextControl(ctrl, true);
                }
                ctrl.Focus();
            }
        }


        private void LoadUserInfo()
        {
            //如果是修改加载user信息  用户账号不允许修改
            if (this.Owner is UserManager)
            {
                UserManager userManager = (UserManager)this.Owner;
                if (userManager.flag.Equals("2"))
                {
                    ScanDataSet scandataset = new Business.UserInfo().GetUserByID(userManager.userID);
                    if (scandataset.UserInfo.Rows.Count > 0)
                    {
                        this.tbUserCode.ReadOnly = true;


                        userTable = scandataset.UserInfo;
                        userRow = scandataset.UserInfo.Rows[0];

                        this.tbUserCode.Text= userRow["usercode"].ToString();
                        this.tbUserName.Text = userRow["username"].ToString();
                        this.tbUserPassWord.Text= userRow["password"].ToString();
                        this.tbSite.Text= userRow["site"].ToString();
                        string status = userRow["status"].ToString();
                        switch (status)
                        {
                            case "1":
                                this.startRadioButton.Checked = true;
                                break;
                            case "0":
                                this.forbidRadioButton.Checked = true;
                                break;
                            default:
                                this.startRadioButton.Checked = true;
                                break;
                        }
                      
                      
                    }
                    else
                    {
                        MessageBox.Show("获取用户信息错误!");
                        return;
                    }
                }
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //校验数据
                CheckContent();
                bool result;
                UserManager userManager;
                //判断是新增 or 修改
                if (this.Owner is UserManager)
                {
                    userManager = (UserManager)this.Owner;
                    if (userManager.flag.Equals("1"))
                    {
                        userTable = new ScanDataSet.UserInfoDataTable();
                        userInfoRow = userTable.NewUserInfoRow();
                        userInfoRow.usercode = this.tbUserCode.Text.Trim();

                        userInfoRow.username = this.tbUserName.Text.Trim();
                        userInfoRow.password = this.tbUserPassWord.Text.Trim();
                        userInfoRow.forgid = ((UserManager)this.Owner).orgID;
                        userInfoRow.frcode = ((UserManager)this.Owner).frcode;
                        userInfoRow.site = this.tbSite.Text.Trim();
                        string status = "";
                        if (this.startRadioButton.Checked)
                            status = "1";

                        if (this.forbidRadioButton.Checked)
                            status = "0";
                        userInfoRow.status = status;

                        userTable.AddUserInfoRow(userInfoRow);
                        result = new Business.UserInfo().AddUser(userTable);


                    }
                    else if (userManager.flag.Equals("2"))
                    {
                        ScanDataSet scandataset = new Business.UserInfo().GetUserByID(userManager.userID);
                        if (scandataset.UserInfo.Rows.Count > 0)
                        {
                            userTable = scandataset.UserInfo;
                            userRow = scandataset.UserInfo.Rows[0];

                            userRow["usercode"] = this.tbUserCode.Text.Trim();
                            userRow["username"] = this.tbUserName.Text.Trim();
                            userRow["password"] = this.tbUserPassWord.Text.Trim();
                            userRow["forgid"] = ((UserManager)this.Owner).orgID;
                            userRow["frcode"] = Util.Util.GetAppSetting("rcode").ToString();
                            userRow["site"] = this.tbSite.Text.Trim();
                            string status = "";
                            if (this.startRadioButton.Checked)
                                status = "1";

                            if (this.forbidRadioButton.Checked)
                                status = "0";
                            userRow["status"] = status;

                            if (!String.IsNullOrEmpty(((UserManager)this.Owner).userID))
                            {
                                userRow["id"] = ((UserManager)this.Owner).userID;
                            }
                            result = new Business.UserInfo().AddUser(userTable);
                        }
                        else
                        {
                            MessageBox.Show("获取用户信息错误!");
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("获取业务标记错误!");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("获取父窗口错误!");
                    return;
                }



                if (result)
                {
                    MessageBox.Show("保存成功!");
                    userManager.searchData();
                    this.Close();
                    return;
                }
                else
                {
                    MessageBox.Show("保存失败!");

                    return;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void CheckContent()
        {
            if (String.IsNullOrEmpty(this.tbUserCode.Text.Trim()))
            {
                MessageBox.Show("用户账号不能为空!");
                return;
            }
            if (String.IsNullOrEmpty(this.tbUserName.Text.Trim()))
            {
                MessageBox.Show("用户名不能为空!");
                return;
            }
            if (String.IsNullOrEmpty(this.tbUserPassWord.Text.Trim()))
            {
                MessageBox.Show("密码不能为空!");
                return;
            }
        }

        private void tbUserPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnSave_Click(null,null);
            }
        }




      
    }
}
