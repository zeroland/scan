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
    public partial class AddConfigInfo : Form
    {
        ScanDataSet.ConfigInfoDataTable configTable;
        DataRow configRow;
        ScanDataSet.ConfigInfoRow configInfoRow;
        public AddConfigInfo()
        {
            InitializeComponent();
            EnterToTab();
            this.InitDbType();
        }

        public void Init()
        {
            this.GetOwnOrg();
        }

        private void GetOwnOrg()
        {
            ConfigManager configManager = (ConfigManager)this.Owner;
            //获取所属机构
            ScanDataSet scanDataSet = new Business.OrgInfo().GetOrgByStr(" and orgid='" + configManager.orgID + "'");
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

        private void InitDbType()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
            dt.Rows.Add(new string[] { "1", "SqlServer" });
            dt.Rows.Add(new string[] { "2", "Oracle" });

            this.cbDBType.DisplayMember= "name";
            this.cbDBType.ValueMember= "code";
            this.cbDBType.DataSource = dt;
            
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
                if (ctrl is TextBox == false && ctrl is ComboBox == false && ctrl is DateTimePicker == false && ctrl is Button == false && ctrl is RadioButton == false)
                {
                    ctrl = this.GetNextControl(ctrl, true);
                }
                ctrl.Focus();
            }
        }


        private void LoadUserInfo()
        {
            //如果是修改加载user信息  用户账号不允许修改
            if (this.Owner is ConfigManager)
            {
                ConfigManager configManager = (ConfigManager)this.Owner;
                if (configManager.flag.Equals("2"))
                {
                    ScanDataSet scandataset = new Business.ConfigInfo().GetConfigInfoByID(configManager.configID);
                    if (scandataset.ConfigInfo.Rows.Count > 0)
                    {
                        configTable = scandataset.ConfigInfo;
                        configRow = scandataset.ConfigInfo.Rows[0];

                        this.tbsite.Text = configRow["site"].ToString();
                        this.tbSDKPath.Text = configRow["sdkpath"].ToString();
                        this.tbSDKSN.Text = configRow["sdksn"].ToString();
                        this.cbDBType.SelectedValue = configRow["dbtype"].ToString();
                        this.tbServer.Text = configRow["server"].ToString();
                        this.tbUserName.Text = configRow["username"].ToString();
                        this.tbPassWord.Text = configRow["password"].ToString();

                        string status = configRow["status"].ToString();
                        switch (status)
                        {
                            case "1":
                                this.StartRadioButton.Checked = true;
                                break;
                            case "0":
                                this.ForbidRadioButton.Checked = true;
                                break;
                            default:
                                this.StartRadioButton.Checked = true;
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


        private void CheckContent()
        {
            if (String.IsNullOrEmpty(this.tbsite.Text.Trim()))
            {
                MessageBox.Show("站点数不能为空!");
                return;
            }
           
        }

   

        private void btnSave_Click(object sender, EventArgs e)
        {
          
            try
            {
                //校验数据
                CheckContent();
                bool result;
                ConfigManager configManager;

                //判断是新增 or 修改
                if (this.Owner is ConfigManager)
                {
                    configManager = (ConfigManager)this.Owner;
                    if (configManager.flag.Equals("1"))
                    {
                        configTable = new ScanDataSet.ConfigInfoDataTable();
                        configInfoRow = configTable.NewConfigInfoRow();


                        configInfoRow.Site = this.tbsite.Text.Trim();

                        configInfoRow.SdkPath = this.tbSDKPath.Text.Trim();
                        configInfoRow.SdkSn = this.tbSDKSN.Text.Trim();
                        configInfoRow.Forgid = ((ConfigManager)this.Owner).orgID;
                        configInfoRow.Frcode = ((ConfigManager)this.Owner).frcode;
                        configInfoRow.DbType = this.cbDBType.SelectedValue.ToString();
                        configInfoRow.Server = this.tbServer.Text.Trim();
                        configInfoRow.UserName = this.tbUserName.Text.Trim();
                        configInfoRow.PassWord = this.tbPassWord.Text.Trim();
                        configInfoRow.DbName = this.tbDBName.Text.Trim();
                        string status = "";
                        if (this.StartRadioButton.Checked)
                            status = "1";

                        if (this.ForbidRadioButton.Checked)
                            status = "0";
                        configInfoRow.Status = status;

                        configTable.AddConfigInfoRow(configInfoRow);

                        result = new Business.ConfigInfo().AddConfig(configTable);


                    }
                    else if (configManager.flag.Equals("2"))
                    {
                        ScanDataSet scandataset = new Business.ConfigInfo().GetConfigInfoByID(configManager.configID);
                        if (scandataset.ConfigInfo.Rows.Count > 0)
                        {
                            configTable = scandataset.ConfigInfo;
                            configRow = scandataset.ConfigInfo.Rows[0];

                            configRow["site"] = this.tbsite.Text.Trim();
                            configRow["sdkpath"] = this.tbSDKPath.Text.Trim();
                            configRow["sdksn"] = this.tbSDKSN.Text.Trim();
                            configRow["dbtype"] = this.cbDBType.SelectedValue.ToString();
                            configRow["server"] = this.tbServer.Text.Trim();
                            configRow["username"] = this.tbUserName.Text.Trim();
                            configRow["password"] = this.tbPassWord.Text.Trim();
                            configRow["dbname"] = this.tbDBName.Text.Trim();
                            string status = "";
                            if (this.StartRadioButton.Checked)
                                status = "1";

                            if (this.ForbidRadioButton.Checked)
                                status = "0";
                            configRow["status"] = status;

                            if (!String.IsNullOrEmpty(((ConfigManager)this.Owner).configID))
                            {
                                configRow["id"] = ((ConfigManager)this.Owner).configID;
                            }
                            result = new Business.ConfigInfo().AddConfig(configTable);
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
                    configManager.SearchData();
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

        private void tbPassWord_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                this.btnSave_Click(null, null);
            }
        }
    }
}
