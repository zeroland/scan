using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using grproLib;
namespace scan.Util
{
    public class ReportShow
    {
        public GridppReport Report;
        DataTable dbTable;
        public ReportShow(string reportName, DataSet ds)
        {
            Report = new GridppReport();
            if (reportName == "" || reportName == null) return;
            if (ds == null) return;
            dbTable = ds.Tables[0];
            

            Report.LoadFromFile(Application.StartupPath + @"\ReportModel\" + reportName);
            
            Report.FetchRecord += new _IGridppReportEvents_FetchRecordEventHandler(ReportFetchRecord);
        }

        public ReportShow(string reportName)
        {
            Report = new GridppReport();           

            Report.LoadFromFile(Application.StartupPath + @"\ReportModel\" + reportName);
          
        }

        public void SetParameter(string name, string value)
        {
            Report.ParameterByName(name).Value = value;
        }



        public void Show()
        {
            Report.PrintPreview(true);
        }

        private void ReportFetchRecord()
        {
            Utility.FillRecordToReport(Report, dbTable);
        }
    }
}
