using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace scan.Interface
{
    interface IUserInfo
    {
         bool AddUser(DataTable dt);
         bool UpdateUser(DataTable dt);
         bool DelUser(string id);
         ScanDataSet GetUserByUserInfo(string userCode,string password);
    }
}
