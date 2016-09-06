using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using System.Text;


namespace scan.Interface
{
    public interface IMainList
    {
        DataSet GetInhosList();
        bool InsertZyjl(IDictionary iDictionary);

        DataSet GetZyjlById(int id);

        DataSet GetZyjlByGuid(string guid);

        bool InsertFymx(IDictionary iDictionary);

        DataSet GetMainInfoList(string sdx,Hashtable ht);

        bool UpdateUploadZyjlById(string id);
        bool DeleteZyjlById(string id);
        bool UpdateUploadFymxByPId(string id);

    }
}
