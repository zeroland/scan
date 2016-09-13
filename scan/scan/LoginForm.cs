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
        public string frcode;
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
                this.frcode = drUserInfo["frcode"].ToString();

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
          
            string frcode = dr["frcode"].ToString();
            //管理员账号 不更新 ； 同步更新站点数 sdk等信息
            if (!frcode.Equals("410000"))
            {
                //更新县区编码
                Util.Util.WriteAppSetting("rcode", frcode, false);

                //更新站点号
                string site = dr["site"].ToString();
                Util.Util.WriteAppSetting("site", site, false);

                //获取农合办配置信息  更新sdk信息 
                string forgid= dr["forgid"].ToString();
                ScanDataSet scanDataSet= new Business.ConfigInfo().GetConfigInfoByStr(" and forgid='"+forgid+"' and site="+site);
                DataRow  configInfoRow;
                if (scanDataSet.ConfigInfo.Rows.Count > 0)
                {
                    configInfoRow = scanDataSet.ConfigInfo.Rows[0];

                    string sdkPath = configInfoRow["sdkpath"] == null ? "" : configInfoRow["sdkpath"].ToString();
                    string sdkSN= configInfoRow["sdkSN"] == null ? "" : configInfoRow["sdkSN"].ToString();
                    string username= configInfoRow["username"] == null ? "" : configInfoRow["username"].ToString();
                    string password = configInfoRow["password"] == null ? "" : configInfoRow["password"].ToString();
                    string server= configInfoRow["server"] == null ? "" : configInfoRow["server"].ToString();
                    string dbName= configInfoRow["dbname"] == null ? "" : configInfoRow["dbname"].ToString();
                    string dbType= configInfoRow["dbtype"] == null ? "" : configInfoRow["dbtype"].ToString();

                    Util.Util.WriteAppSetting("sdkPath", sdkPath, false);
                    Util.Util.WriteAppSetting("sn", sdkSN,true);


                    if (!String.IsNullOrEmpty(server) && !String.IsNullOrEmpty(username) && !String.IsNullOrEmpty(password)&&!String.IsNullOrEmpty(dbName)&&dbType.Equals("1"))
                    {
                        //拼接连接字符串 Server=125.46.57.165;Database=waizhen;User ID=waizhen;Password=xyh!@#xyh
                        string str = @"Server = "+ server + "; Database = "+ dbName + "; User ID = "+ username + "; Password = "+ password ;
                        //加密存储配置
                        Util.Util.WriteConSetting("ConStr",str,true);
                    }
                    
                }
                else
                {
                    MessageBox.Show("获取配置信息失败!");
                    this.DialogResult = DialogResult.Cancel;
                    return;

                }

                

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
