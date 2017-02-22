using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using grproLib;

namespace scan
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
            test();
        }

        private void test()
        {
            //2147483647  Int32.MaxValue();
           // Decimal.MaxValue();
          // Math.Round()
        } 



        private void upload()
        {

            //获取数据记录再拼包
            //根据guid获取记录,guid由登记主信息之后，传过来的

            DataSet dsZyjl = new Business.MainList().GetZyjlByGuid("4a4b9c7a-ca0a-474f-a010-bbedc4e5bcd1");
            if (dsZyjl.Tables[0].Rows.Count < 1)
            {
                MessageBox.Show("请先登记再上传！");
                return;
            }


            DataRow dr = dsZyjl.Tables[0].Rows[0];


            string result = new Business.MainList().UploadZyjl(dr);

            /*
            <?xml version="1.0" encoding="UTF-8"?><businessdata><functioncode>200222</functioncode><state>0</state><result/><remark1/><remark2/><remark3/><remark4/><remark5/></businessdata>
            */
            this.TopMost = false;
            if (!String.IsNullOrEmpty(result))
            {
                try
                {
                    XmlDocument xdResult = new XmlDocument();
                    xdResult.LoadXml(result);
                    XmlElement rootResult = xdResult.DocumentElement;
                    string state = rootResult.SelectSingleNode("state").InnerText;


                    if (state.Equals("0"))
                    {
                        bool result1 = new Business.MainList().UpdateUploadZyjlById(dr["id"].ToString());
                        bool result2 = new Business.MainList().UpdateUploadFymxByPId(dr["id"].ToString());
                        if (result1 && result2)
                        {
                            MessageBox.Show("上传成功!", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }
                        else
                        {
                            MessageBox.Show("上传成功!更新上传标识异常！", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }

                    }
                    else
                    {
                        MessageBox.Show("上传失败!==>" + rootResult.SelectSingleNode("result").InnerText, "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            else
            {
                MessageBox.Show("上传失败!==>上传返回结果为空！", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }






        }

        bool DataOperateFinished = false;
        LoadForm loadForm;
        Thread MyProgressWait;
        private void ProgressBarWait()
        {
            loadForm = new LoadForm();
            loadForm.MdiParent = this.MdiParent;
            loadForm.ShowDialog();
            if (loadForm.DialogResult == DialogResult.OK)
            {
                loadForm.Dispose();
                loadForm.Close();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyProgressWait = new Thread(ProgressBarWait);
            MyProgressWait.Start();

            Thread.Sleep(5000);

            loadForm.DialogResult = DialogResult.OK;
           
            DataOperateFinished = true;
            // System.IO.FileInfo fileinfo = new System.IO.FileInfo(Application.StartupPath + "\\" + "log4net.config");

            //log4net.Config.XmlConfigurator.Configure(fileinfo);
            //log4net.ILog log = log4net.LogManager.GetLogger("FileLogger_waizhen");
            //log.Info("abc"+System.DateTime.Now.ToShortDateString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = ".";
            decimal sss = 0;          

            bool su = Decimal.TryParse(a, out sss);


        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Util.ExportExcel export = new Util.ExportExcel();
            //export.DataToExcel(null,"aaaa");
         
            DataTable dt = new DataTable();
            dt.Columns.Add("姓名", typeof(String));
            dt.Columns.Add("性别", typeof(String));
            DataRow dr = dt.NewRow();
            dr["姓名"] = "王一";
            dr["性别"] = "男";

            DataRow dr1 = dt.NewRow();
            dr1["姓名"] = "王二";
            dr1["性别"] = "女";

            dt.Rows.Add(dr);
            dt.Rows.Add(dr1);
            dt.TableName = "测试NPOI";
            // Util.Util.WriteExcel(dt, "d://test.xls");

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = "wangtest" + ".xls";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
            Util.Util.WriteExcel(dt, saveFileDialog.FileName);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds= new Business.MainList().CombineFeeDetail("2");
                

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
                saveFileDialog.FilterIndex = 0;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.CreatePrompt = false;
                saveFileDialog.FileName = "wang-123" + ".xls";
                if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;
                Util.Util.WriteExcel(ds.Tables[0], saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }



      

    }
}
