using System;
using System.Collections.Generic;
using System.Data;

using System.Text;
using scan.Interface;
using scan.SqlServer;
using System.Collections;
namespace scan.Business
{
    public class DictProcess
    {
        public DataSet GetIcdByStr(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetIcdByStr(str);
        }

        public DataSet GetDeptByStr(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetDeptByStr(str);
        }

        public DataSet GetOrgByStr(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetOrgByStr(str);
        }

        public DataSet GetItemByStr(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemByStr(str);
        }
        public DataSet GetItemByID(string code)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemByID(code);
        }

        public DataSet GetItemAll()
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemAll();
        }

        public DataSet GetStyle(string frcode)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetStyle(frcode);
        }

        public DataSet GetStyleByID(string id)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetStyleByID(id);
        }

        public DataSet MapItemByName(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.MapItemByName(str);
        }

        public void GetCenterData(ScanDataSet ds)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            iDictProcess.GetCenterData(ds);
        }

        public void GetItemDict(ScanDataSet ds)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            iDictProcess.GetItemDict(ds);
        }

        public string InsertStyle(IDictionary iDictionary)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.InsertStyle(iDictionary);
        }

        public bool DelStyle(IDictionary iDictionary)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.DelStyle(iDictionary);
        }

        public DataSet GetItemDictByKeyWord(string str)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemDictByKeyWord(str);
        }

        public DataSet GetItemDictByFRcodeScanName(string scanname,string frcode)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemDictByFRcodeScanName(scanname,frcode);
        }
        public DataSet GetItemDictByFRcodeKeyWord(string str, string frcode)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemDictByFRcodeKeyWord(str, frcode);
        }

        public DataSet GetItemDictByScanName(string scanname)
        {
            IDcitProcess iDictProcess = new SqlServer.DictProcess();
            return iDictProcess.GetItemDictByScanName(scanname);
        }
    }
}
