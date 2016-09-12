using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace scan.Interface
{
    interface IConfigInfo
    {
        bool AddConfig(DataTable dt);
        bool DelConfigInfo(string id);
        ScanDataSet GetConfigInfoByID(string id);
        ScanDataSet GetConfigInfoByStr(string str);
    }
}
