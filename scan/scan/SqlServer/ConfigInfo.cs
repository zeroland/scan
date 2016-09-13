using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using scan.Interface;
using scan.Util;

namespace scan.SqlServer
{
    class ConfigInfo : IConfigInfo
    {
        public bool AddConfig(DataTable dt)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlTransaction sqlTranscation = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {

                        SqlCommand insertCommand = new SqlCommand(@"INSERT INTO hzyl_wz_config (frcode,forgid, wsurl, sdkpath, sdksn, fremark1, fremark2, site,status,dbtype,server,username,password,dbname)
VALUES (@frcode,@forgid, @wsurl, @sdkpath, @sdksn, @fremark1, @fremark2, @site,@status,@dbtype,@server,@username,@password,@dbname)", sqlConnection, sqlTranscation);

                        insertCommand.Parameters.Add(new SqlParameter("@frcode", SqlDbType.VarChar, 50, "frcode"));
                        insertCommand.Parameters.Add(new SqlParameter("@forgid", SqlDbType.VarChar, 50, "forgid"));
                        insertCommand.Parameters.Add(new SqlParameter("@wsurl", SqlDbType.VarChar, 50, "wsurl"));
                        insertCommand.Parameters.Add(new SqlParameter("@sdkpath", SqlDbType.VarChar, 20, "sdkpath"));
                        insertCommand.Parameters.Add(new SqlParameter("@sdksn", SqlDbType.VarChar, 20, "sdksn"));
                        insertCommand.Parameters.Add(new SqlParameter("@fremark1", SqlDbType.VarChar, 20, "fremark1"));
                        insertCommand.Parameters.Add(new SqlParameter("@fremark2", SqlDbType.VarChar, 20, "fremark2"));
                        insertCommand.Parameters.Add(new SqlParameter("@site", SqlDbType.VarChar, 20, "site"));
                        insertCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 20, "status"));
                        insertCommand.Parameters.Add(new SqlParameter("@dbtype", SqlDbType.VarChar, 20, "dbtype"));
                        insertCommand.Parameters.Add(new SqlParameter("@server", SqlDbType.VarChar, 20, "server"));
                        insertCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 20, "username"));
                        insertCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20, "password"));
                        insertCommand.Parameters.Add(new SqlParameter("@dbname", SqlDbType.VarChar, 20, "dbname"));


                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_config
SET  wsurl = @wsurl,
	sdkpath = @sdkpath,
	sdksn = @sdksn,
	fremark1 = @fremark1,
	fremark2 = @fremark2,
    status = @status ,    
    site = @site,
    dbtype=@dbtype,
    server=@server,
    username=@username,
    password=@password ,
   dbname =@dbname 
	where id=@id
", sqlConnection, sqlTranscation);

                        updateCommand.Parameters.Add(new SqlParameter("@wsurl", SqlDbType.VarChar, 50, "wsurl"));
                        updateCommand.Parameters.Add(new SqlParameter("@sdkpath", SqlDbType.VarChar, 50, "sdkpath"));
                        updateCommand.Parameters.Add(new SqlParameter("@sdksn", SqlDbType.VarChar, 20, "sdksn"));
                       
                        updateCommand.Parameters.Add(new SqlParameter("@site", SqlDbType.VarChar, 20, "site"));
                        updateCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 20, "status"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark1", SqlDbType.VarChar, 20, "fremark1"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark2", SqlDbType.VarChar, 20, "fremark2"));
                        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20, "id"));
                        updateCommand.Parameters.Add(new SqlParameter("@dbtype", SqlDbType.VarChar, 20, "dbtype"));
                        updateCommand.Parameters.Add(new SqlParameter("@server", SqlDbType.VarChar, 20, "server"));
                        updateCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 20, "username"));
                        updateCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20, "password"));
                        updateCommand.Parameters.Add(new SqlParameter("@dbname", SqlDbType.VarChar, 20, "dbname"));


                        sqlDataAdapter.InsertCommand = insertCommand;
                        sqlDataAdapter.UpdateCommand = updateCommand;

                        sqlDataAdapter.Update(dt);
                    }

                }
                catch (Exception e)
                {
                    result = false;
                    sqlTranscation.Rollback();
                    throw e;
                }
                sqlTranscation.Commit();
            }
            sqlConnection.Close();
            return result;
        }


        public bool DelConfigInfo(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = "delete from hzyl_wz_config where id=@id";

            SqlParameter[] sqlParameters = new SqlParameter[] {
                     new SqlParameter("@id",id)
            };

            try
            {
                SqlHelper.ExecuteNonQuery(sqlConnection, commandType, commandText, sqlParameters);
            }
            catch (Exception e)
            {

                result = false;
                throw e;
            }

            SqlHelper.CloseConnection(sqlConnection);

            return result;
        }

        public ScanDataSet GetConfigInfoByID(string id)
        {
            ScanDataSet scanDataSet = new ScanDataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("select t1.*,t2.orgname ,(CASE WHEN t1.status=1 THEN '启用' ELSE '注销' END ) statusname from hzyl_wz_config t1,base_org_info t2 where t1.forgid=t2.orgid /*and t1.status=1 and t2.status=1*/ and t1.id=@id", sqlConnection))
            {
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(scanDataSet, scanDataSet.ConfigInfo.TableName);
                }
            }
            SqlHelper.CloseConnection(sqlConnection);
            return scanDataSet;
        }

        public ScanDataSet GetConfigInfoByStr(string str)
        {
            ScanDataSet scanDataSet = new ScanDataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("select t1.*,t2.orgname ,(CASE WHEN t1.status=1 THEN '启用' ELSE '注销' END ) statusname from hzyl_wz_config t1,base_org_info t2 where t1.forgid=t2.orgid /*and t1.status=1 and t2.status=1*/ " + str, sqlConnection))
            {


                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(scanDataSet, scanDataSet.ConfigInfo.TableName);
                }
            }
            SqlHelper.CloseConnection(sqlConnection);
            return scanDataSet;
        }
    }
}
