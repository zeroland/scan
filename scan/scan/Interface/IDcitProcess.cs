using System;
using System.Collections.Generic;
using System.Data;

using System.Text;
using System.Collections;


namespace scan.Interface
{
    public interface IDcitProcess
    {
        DataSet GetIcdByStr(string str);
        DataSet GetDeptByStr(string str);

        DataSet GetOrgByStr(string str);

        DataSet GetItemByStr(string str);
        DataSet GetItemByID(string code);

        DataSet MapItemByName(string str);

        DataSet GetItemAll();

        DataSet GetStyle(string frcode);
        DataSet GetStyleByID(string id);
        void GetCenterData(ScanDataSet ds);

        void GetItemDict(ScanDataSet ds);

        string InsertStyle(IDictionary iDictionary);

        bool DelStyle(IDictionary iDictionary);

        DataSet GetItemDictByFRcodeKeyWord(string str,string frcode);

        DataSet GetItemDictByFRcodeScanName(string scanname,string frcode);
        DataSet GetItemDictByKeyWord(string str);

        DataSet GetItemDictByScanName(string scanname);
    }
}
