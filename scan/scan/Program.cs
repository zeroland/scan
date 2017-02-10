using System;
using System.Collections.Generic;

using System.Windows.Forms;

namespace scan
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new Test());
            //string result = Util.Util.GetEncryptedValue("Server=192.168.0.109;Database=waizhen;User ID=sa;Password=xyh56850000");

           // string old = Util.Util.GetDecryptedValue(result);

            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                //如果是管理员账号 登陆导航窗口
                if (loginForm.frcode.Equals("000000"))
                {
                    Application.Run(new NavForm());
                    return;
                }


                //第一次修改配置文件之后  需要刷新相应节点
                //读取本地配置文件判断登录录入模式还是修改模式
                string immode = Util.Util.GetAppSetting("immode");
                switch (immode)
                {
                    case "1":
                        Application.Run(new MainForm());
                        break;
                    case "2":
                        Application.Run(new InhosList());
                        break;
                    default:
                        Application.Run(new MainForm());
                        break;
                }

            }
            else
            {
                Application.Exit();
            }

            // string result= Util.Util.GetEncryptedValue("Server=125.46.57.165;Database=waizhen;User ID=waizhen;Password=xyh!@#xyh");

            // string old = Util.Util.GetDecryptedValue(result);


            ////string urlOld= "http://125.46.57.77:80/xyhnccmp2/HospitalServicePort";
            ////string urlNew = Util.Util.GetEncryptedValue(urlOld);//MUQZcdr/xFgcR12sWd7dtNZu9zaDGJd9Eesyr0ov4xpD7uwxljPtZxbjPm8N61cyjNZoAy0/Kvo=
            ////string urlDecrpte= Util.Util.GetDecryptedValue(urlNew);


            //string oldSN = "SWTD-1111-0005-8019-7947-1872";
            //string newSN = Util.Util.GetEncryptedValue(oldSN);
            //string decryptSN = Util.Util.GetDecryptedValue(newSN);


            // Application.Run(new MainInfoList());
            // Application.Run(new Test());
            // Application.Run(new InhosList());
            // Application.Run(new UserManager());
            // Application.Run(new ConfigManager());


        }
    }
}

