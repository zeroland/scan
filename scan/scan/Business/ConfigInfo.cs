using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using scan.Interface;

namespace scan.Business
{
    class ConfigInfo
    {
        IConfigInfo iConfigInfo;
        public ConfigInfo()
        {
            iConfigInfo = new SqlServer.ConfigInfo();
        }
        public bool AddConfig(DataTable dt)
        {
            return iConfigInfo.AddConfig(dt);
        }

        bool DelConfigInfo(string id)
        {
            return iConfigInfo.DelConfigInfo(id);
        }
        ScanDataSet GetConfigInfoByID(string id)
        {
            return iConfigInfo.GetConfigInfoByID(id);
        }
        ScanDataSet GetConfigInfoByStr(string str)
        {
            return iConfigInfo.GetConfigInfoByStr(str);
        }
    }
}
