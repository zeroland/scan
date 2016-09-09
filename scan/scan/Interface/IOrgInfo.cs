using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace scan.Interface
{
    interface IOrgInfo
    {
        ScanDataSet GetOrgByStr(string str);
    }
}
