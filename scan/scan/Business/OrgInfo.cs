using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using scan.Interface;
namespace scan.Business
{
    class OrgInfo
    {
        IOrgInfo iOrgInfo;
        public OrgInfo()
        {
            iOrgInfo = new SqlServer.OrgInfo();
        }
          
        public ScanDataSet GetOrgByStr(string str)
        {
           return iOrgInfo.GetOrgByStr(str);
        }
    }
}
