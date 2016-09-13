using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using scan.Interface;

namespace scan.Business
{
    public class ConfigInfo
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

        public bool DelConfigInfo(string id)
        {
            return iConfigInfo.DelConfigInfo(id);
        }
        public ScanDataSet GetConfigInfoByID(string id)
        {
            return iConfigInfo.GetConfigInfoByID(id);
        }
        public ScanDataSet GetConfigInfoByStr(string str)
        {
            return iConfigInfo.GetConfigInfoByStr(str);
        }
    }
}
