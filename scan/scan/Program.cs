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
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new MainForm());
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
            //Application.Run(new Test());
            // Application.Run(new DictViewForm());


        }
    }
}

