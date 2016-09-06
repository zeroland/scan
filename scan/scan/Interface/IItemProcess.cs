using System;
using System.Collections.Generic;
using System.Data;

using System.Text;


namespace scan.Interface
{
    public interface IItemProcess
    {
        DataSet GetDetailById(System.Collections.IDictionary iDictionary);

        DataSet GetShowNameByScanName(string scanname);
        DataSet GetShowNameByFRcodeScanName(string scanname,string frcode);
        bool UpdateDetailInfo(DataTable dt);
        bool SaveAndUpdateDetail(DataTable dt);
        void UpdateItemDictRelation(string scanname, string showname, string centercode, string frcode);
        DataSet GetItemDict(string frcode, string str);
    }
}
