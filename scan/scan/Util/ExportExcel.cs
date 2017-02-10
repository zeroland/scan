using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace scan.Util
{
    class ExportExcel
    {

        /// <summary>
        /// 导出再打开提示格式问题,用第三方组件测试
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="fileName"></param>
        public void DataToExcel(DataSet ds,string fileName)
        {
            DataSet ds1 = new DataSet();
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

            ds1.Tables.Add(dt);
            ds = ds1;


            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.CreatePrompt = false;
            saveFileDialog.FileName = fileName + ".xls";

            if (saveFileDialog.ShowDialog() == DialogResult.Cancel) return;

            Stream myStream = saveFileDialog.OpenFile();
            StreamWriter sw = new StreamWriter(myStream, System.Text.Encoding.GetEncoding(-0));
            string strHeaderText = "";
            try
            {
                //写标题
                for (int i = 0; i < ds.Tables[0].Columns.Count; i++)
                {
                    if (i > 0)
                    {
                        strHeaderText += "\t";
                    }
                    strHeaderText += ds.Tables[0].Columns[i].ToString();
                }
                sw.WriteLine(strHeaderText);
                //写内容
                string strItemValue = "";
                for (int j = 0; j < ds.Tables[0].Rows.Count; j++)
                {
                    strItemValue = "";
                    for (int k = 0; k < ds.Tables[0].Columns.Count; k++)
                    {
                        if (k > 0)
                        {
                            strItemValue += "\t";
                        }
                        strItemValue += ds.Tables[0].Rows[j][k].ToString();
                    }
                    sw.WriteLine(strItemValue); //把dgv的每一行的信息写为sw的每一行
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "软件提示");
                throw ex;
            }
            finally
            {
                sw.Close();
                myStream.Close();
            }
        }
    }
}
    

