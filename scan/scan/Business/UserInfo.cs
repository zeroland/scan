using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using scan.Interface;

namespace scan.Business
{
    public class UserInfo
    {
        IUserInfo iUserInfo;
        public  UserInfo()
        {
            iUserInfo = new SqlServer.UserInfo();
        }

        public bool AddUser(DataTable dt)
        {
            return iUserInfo.AddUser(dt);
        }
        public bool UpdateUser(DataTable dt)
        {
            return iUserInfo.UpdateUser(dt);
        }
        public bool DelUser(string id)
        {
            return iUserInfo.DelUser(id);
        }
        public ScanDataSet GetUserByUserInfo(string userCode, string password)
        {
            return iUserInfo.GetUserByUserInfo(userCode,password);
        }
    }
}
