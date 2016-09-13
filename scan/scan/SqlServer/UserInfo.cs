using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using scan.Interface;
using scan.Util;

namespace scan.SqlServer
{
    public class UserInfo : IUserInfo
    {
        public bool AddUser(DataTable dt)
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

                        SqlCommand insertCommand = new SqlCommand(@"INSERT INTO hzyl_wz_user (usercode, username, password, frcode, fremark1, fremark2,forgid,site) VALUES(@usercode, @username, @password, @frcode, @fremark1, @fremark2,@forgid,@site)", sqlConnection, sqlTranscation);

                        insertCommand.Parameters.Add(new SqlParameter("@usercode", SqlDbType.VarChar, 50, "usercode"));
                        insertCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, "username"));
                        insertCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20, "password"));
                        insertCommand.Parameters.Add(new SqlParameter("@frcode", SqlDbType.VarChar, 20, "frcode"));
                        insertCommand.Parameters.Add(new SqlParameter("@fremark1", SqlDbType.VarChar, 20, "fremark1"));
                        insertCommand.Parameters.Add(new SqlParameter("@fremark2", SqlDbType.VarChar, 20, "fremark2"));
                        insertCommand.Parameters.Add(new SqlParameter("@forgid", SqlDbType.VarChar, 20, "forgid"));
                        insertCommand.Parameters.Add(new SqlParameter("@site", SqlDbType.VarChar, 20, "site"));

                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_user
SET usercode = @usercode,
	username = @username,
	password = @password,
	frcode = @frcode,
	fremark1 = @fremark1,
	fremark2 = @fremark2,
    site=@site,
	status = @status,forgid=@forgid where id = @id", sqlConnection, sqlTranscation);

                        updateCommand.Parameters.Add(new SqlParameter("@usercode", SqlDbType.VarChar, 50, "usercode"));
                        updateCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, "username"));
                        updateCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20, "password"));
                        updateCommand.Parameters.Add(new SqlParameter("@frcode", SqlDbType.VarChar, 20, "frcode"));
                        updateCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 20, "status"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark1", SqlDbType.VarChar, 20, "fremark1"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark2", SqlDbType.VarChar, 20, "fremark2"));
                        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20, "id"));
                        updateCommand.Parameters.Add(new SqlParameter("@forgid", SqlDbType.VarChar, 20, "forgid"));
                        updateCommand.Parameters.Add(new SqlParameter("@site", SqlDbType.VarChar, 20, "site"));



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

        public bool UpdateUser(DataTable dt)
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

                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_user
SET usercode = @usercode,
	username = @username,
	password = @password,
	frcode = @frcode,
	fremark1 = @fremark1,
	fremark2 = @fremark2,
    site=@site,
	status = @status,forgid=@forgid where id = @id", sqlConnection, sqlTranscation);

                        updateCommand.Parameters.Add(new SqlParameter("@usercode", SqlDbType.VarChar, 50, "usercode"));
                        updateCommand.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 50, "username"));
                        updateCommand.Parameters.Add(new SqlParameter("@password", SqlDbType.VarChar, 20, "password"));
                        updateCommand.Parameters.Add(new SqlParameter("@frcode", SqlDbType.VarChar, 20, "frcode"));
                        updateCommand.Parameters.Add(new SqlParameter("@status", SqlDbType.VarChar, 20, "status"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark1", SqlDbType.VarChar, 20, "fremark1"));
                        updateCommand.Parameters.Add(new SqlParameter("@fremark2", SqlDbType.VarChar, 20, "fremark2"));
                        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 20, "id"));
                        updateCommand.Parameters.Add(new SqlParameter("@forgid", SqlDbType.VarChar, 20, "forgid"));
                        updateCommand.Parameters.Add(new SqlParameter("@forgid", SqlDbType.VarChar, 20, "site"));

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


        public bool DelUser(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = "delete from hzyl_wz_user where id=@id";

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

        public ScanDataSet GetUserByUserInfo(string userCode,string password)
        {
            ScanDataSet scanDataSet = new ScanDataSet();
           

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("select t1.*,t2.orgname from hzyl_wz_user t1,base_org_info t2 where t1.forgid=t2.orgid and  usercode=@usercode and password=@password",sqlConnection))
            {
                sqlCommand.Parameters.Add("@usercode", SqlDbType.VarChar, 20).Value=userCode;
                sqlCommand.Parameters.Add("@password", SqlDbType.VarChar, 20).Value= password;
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(scanDataSet, scanDataSet.UserInfo.TableName);
                }
            }
            SqlHelper.CloseConnection(sqlConnection);
            return scanDataSet;
        }

        public ScanDataSet GetUserByID(string id)
        {
            ScanDataSet scanDataSet = new ScanDataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("select t1.*,t2.orgname ,(CASE WHEN t1.status=1 THEN '启用' ELSE '注销' END ) statusname from hzyl_wz_user t1,base_org_info t2 where t1.forgid=t2.orgid /*and t1.status=1 and t2.status=1*/ and t1.id=@id", sqlConnection))
            {
                sqlCommand.Parameters.Add("@id", SqlDbType.VarChar, 20).Value = id;
              
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(scanDataSet, scanDataSet.UserInfo.TableName);
                }
            }
            SqlHelper.CloseConnection(sqlConnection);
            return scanDataSet;
        }

        public ScanDataSet GetUserByStr(string str)
        {
            ScanDataSet scanDataSet = new ScanDataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlCommand sqlCommand = new SqlCommand("select t1.*,t2.orgname ,(CASE WHEN t1.status=1 THEN '启用' ELSE '注销' END ) statusname from hzyl_wz_user t1,base_org_info t2 where t1.forgid=t2.orgid /*and t1.status=1 and t2.status=1*/ " + str, sqlConnection))
            {
                

                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                {
                    sqlDataAdapter.SelectCommand = sqlCommand;
                    sqlDataAdapter.Fill(scanDataSet, scanDataSet.UserInfo.TableName);
                }
            }
            SqlHelper.CloseConnection(sqlConnection);
            return scanDataSet;
        }
    }
}
