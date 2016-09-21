using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using scan.Util;

namespace scan.SqlServer
{
    class OrgInfo :scan.Interface.IOrgInfo
    {
        public ScanDataSet GetOrgByStr(string str)
        {
            ScanDataSet scanDataSet = new ScanDataSet();
          
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            try
            {

                using (SqlCommand sqlCommand = new SqlCommand("select * from base_org_info where status=1 " + str, sqlConnection))
                {

                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.Fill(scanDataSet, scanDataSet.BaseOrgInfo.TableName);
                    }
                }
            }
            
            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }

            
            return scanDataSet;
        }
    }
}
