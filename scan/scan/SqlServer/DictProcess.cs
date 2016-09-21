using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using System.Text;
using scan.Util;

namespace scan.SqlServer
{
    public class DictProcess : Interface.IDcitProcess
    {
        private string fileName = "DictProcess.xml";

        public void GetCenterData(ScanDataSet ds)
        {
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemAll");
            using (SqlConnection sqlConnection = new SqlConnection(Util.SqlHelper.GetConnSting()))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandText, sqlConnection))
                {
                    sqlDataAdapter.Fill(ds, ds.CenterData.TableName);
                }
            }            
        }
        

        public void GetItemDict(ScanDataSet ds)
        {
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemDict");
            using (SqlConnection sqlConnection = new SqlConnection(Util.SqlHelper.GetConnSting()))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(commandText, sqlConnection))
                {
                    sqlDataAdapter.Fill(ds, ds.ItemDict.TableName);
                }
            }
        }

        public DataSet GetIcdByStr(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetIcdByStr");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }
        public DataSet GetItemByID(string code)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemByID");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@code",code)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet GetDeptByStr(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetDeptByStr");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

        public DataSet GetOrgByStr(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetOrgByStr");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet GetItemByStr(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemByStr");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            { 
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

        public DataSet GetItemAll()
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemAll");

            
            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet GetStyle(string frcode)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetStyle");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@frcode",frcode)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
           
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet GetStyleByID(string id)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetStyleByID");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@id",id)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }

            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet MapItemByName(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "MapItemByName");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

        public DataSet GetItemDictByFRcodeKeyWord(string str,string frcode)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemDictByFRcodeKeyWord");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str),
                 new SqlParameter("@frcode",frcode)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }


        public DataSet GetItemDictByFRcodeScanName(string scanname,string frcode)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemDictByFRcodeScanName");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@scanname",scanname),
                  new SqlParameter("@frcode",frcode)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

        public DataSet GetItemDictByKeyWord(string str)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemDictByKeyWord");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@str",str)
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

       
        public DataSet GetItemDictByScanName(string scanname)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetItemDictByScanName");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@scanname",scanname)
                
            };

            try
            {
                ds = SqlHelper.ExecuteDataset(sqlConnection, commandType, commandText, sqlPrameter);
            }
            catch (Exception e)
            {

                throw e;
            }

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }
            return ds;

        }

        public string InsertStyle(IDictionary iDictionary)
        {
            string result = "";

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "insert", "ID", "InsertStyle");

            SqlParameter[] sqlParameters = new SqlParameter[] {                   
                     new SqlParameter("@code",iDictionary["code"].ToString()),
                     new SqlParameter("@name",iDictionary["name"].ToString()),
                     new SqlParameter("@frcode",iDictionary["frcode"].ToString())
            };

            try
            {

                result = SqlHelper.ExecuteScalar(sqlConnection, commandType, commandText, sqlParameters).ToString();
            }
            catch (Exception e)
            {

                throw e;
            }
            finally
            {
                SqlHelper.CloseConnection(sqlConnection);

                
            }
            return result;

        }

        public bool DelStyle(IDictionary iDictionary)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "delete", "ID", "DelStyle");

            SqlParameter[] sqlParameters = new SqlParameter[] {                   
                     new SqlParameter("@id",iDictionary["id"].ToString())                    
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

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }

            return result;
        }
  
    }
}
