using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

using System.Text;

using scan.Util;
using System.Collections;

namespace scan.SqlServer
{
    class MainList : Interface.IMainList
    {
        private string fileName = "MainList.xml";
        public DataSet GetInhosList()
        {
            DataSet ds = new DataSet();         
            

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetMainList");

           

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

        public DataSet GetMainInfoList(string sdx,Hashtable ht)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;

            string str = "";
            if (ht["condition"]!=null)
            {
                str = " and (zyh like '%" + ht["condition"].ToString() + "%' or ylzh like '%" + ht["condition"].ToString() + "%' or name like '%" + ht["condition"].ToString() + "%')";
            }
            // string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetMainInfoList");

            string commandText = @" SELECT t.* ,(SELECT name FROM hzyl_dict_dept a WHERE a.code=t.ryks) ryksname,(SELECT name FROM hzyl_dict_dept b WHERE b.code=t.cyks) cyksname,(SELECT c.icdname FROM hzyl_dict_icd c WHERE c.icdcode=t.cyzd) cyzdname,(SELECT d.name FROM hzyl_dict_org d WHERE d.code=t.yljg) orgname,isnull((SELECT sum(convert(DECIMAL(20,6),e.totalprice))  FROM hzyl_wz_fymx e WHERE e.pid=t.id),0) totalprice FROM hzyl_wz_zyjl t  WHERE isUpload=0 and sdx=@sdx " + str;

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@sdx",sdx)
               
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

        

        public DataSet GetZyjlById(int id)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetZyjlById");

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

        public DataSet GetZyjlByGuid(string guid)
        {
            DataSet ds = new DataSet();


            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetZyjlByGuid");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@guid",guid)
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

        /// <summary>
        /// 插入住院记录
        /// </summary>
        /// <param name="iDictionary">参数数组放到字典中</param>
        /// <returns></returns>
        public bool InsertZyjl(IDictionary iDictionary)
        {
            bool result = true;
            
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "InsertZyjl");

           // string[] parameters = { "@sdx", "@zyh", "@yljg", "@ylzh", "@name", "@idcard", "@jzlx", "@rysj", "@cysj", "@sjzyts", "@ryks", "@ryksname", "@cyks", "@cyksname", "@jzys", "@ryzt", "@cyzt", "@ryzd", "@cyzd" };
            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@sdx",iDictionary["sdx"].ToString()),
                     new SqlParameter("@zyh",iDictionary["zyh"].ToString()),
                      new SqlParameter("@yljg",iDictionary["yljg"]==null?"":iDictionary["yljg"].ToString()),
                       new SqlParameter("@ylzh",iDictionary["ylzh"]==null?"":iDictionary["ylzh"].ToString()),
                        new SqlParameter("@name",iDictionary["name"].ToString()),
                         new SqlParameter("@idcard",iDictionary["idcard"]==null?"":iDictionary["idcard"].ToString()),
                          new SqlParameter("@jzlx",iDictionary["jzlx"].ToString()),
                           new SqlParameter("@rysj",Convert.ToDateTime(iDictionary["rysj"].ToString())),
                            new SqlParameter("@cysj",Convert.ToDateTime(iDictionary["cysj"].ToString())),
                             new SqlParameter("@sjzyts",iDictionary["sjzyts"].ToString()),
                             new SqlParameter("@ryks",iDictionary["ryks"]==null?"":iDictionary["ryks"].ToString()),
                         
                             new SqlParameter("@cyks",iDictionary["cyks"]==null?"":iDictionary["cyks"].ToString()),
                          
                               new SqlParameter("@jzys",iDictionary["jzys"]==null?"":iDictionary["jzys"].ToString()),
                                new SqlParameter("@ryzt",iDictionary["ryzt"]==null?"":iDictionary["ryzt"].ToString()),
                                 new SqlParameter("@cyzt",iDictionary["cyzt"]==null?"":iDictionary["cyzt"].ToString()),
                                  new SqlParameter("@ryzd",iDictionary["ryzd"]==null?"":iDictionary["ryzd"].ToString()),
                                   new SqlParameter("@cyzd",iDictionary["cyzd"]==null?"":iDictionary["cyzd"].ToString()),
                                   new SqlParameter("@guid",iDictionary["guid"].ToString())

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


        public bool InsertFymx(IDictionary iDictionary)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "insert", "ID", "InsertFymx");
            
            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@pid",iDictionary["pid"].ToString()),
                     new SqlParameter("@code",iDictionary["code"].ToString()),
                      new SqlParameter("@name",iDictionary["name"].ToString()),
                       new SqlParameter("@spec",iDictionary["spec"]==null?"":iDictionary["spec"]),
                        new SqlParameter("@unit",iDictionary["unit"]==null?"":iDictionary["unit"]),
                         new SqlParameter("@quantum",iDictionary["quantum"].ToString()),
                          new SqlParameter("@price",iDictionary["price"].ToString()),
                           new SqlParameter("@totalprice",iDictionary["totalprice"].ToString()),
                            new SqlParameter("@paydate",Convert.ToDateTime(iDictionary["paydate"].ToString())),
                             new SqlParameter("@centercode",iDictionary["centercode"].ToString()),
                             new SqlParameter("@centername",iDictionary["centername"].ToString()),

                             new SqlParameter("@feetype",iDictionary["feetype"].ToString()),

                             
                                new SqlParameter("@itemtype",iDictionary["itemtype"].ToString())
                               

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


        public bool UpdateUploadZyjlById(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "update", "ID", "UpdateUploadZyjlById");

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

            finally
            {
                SqlHelper.CloseConnection(sqlConnection);
            }

            return result;
        }

        public bool UpdateUploadFymxByPId(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "update", "ID", "UpdateUploadFymxByPId");

            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@pid",id)

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

        public bool DeleteZyjlById(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "delete", "ID", "DeleteZyjlById");
            string commandTextDetail= xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "delete", "ID", "DeleteFymxById");

            SqlParameter[] sqlParameters = new SqlParameter[] {
                    new SqlParameter("@id",id)

            };
            SqlParameter[] sqlParametersDetail = new SqlParameter[] {
                    new SqlParameter("@pid",id)

            };

            try
            {
                SqlHelper.ExecuteNonQuery(sqlConnection, commandType, commandText, sqlParameters);
                 SqlHelper.ExecuteNonQuery(sqlConnection, commandType, commandTextDetail, sqlParametersDetail);
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


        public bool DelDetailByID(string id)
        {
            bool result = true;

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;
         
            string commandTextDetail = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "delete", "ID", "DeleteFymxByDetailId");

          
            SqlParameter[] sqlParametersDetail = new SqlParameter[] {
                    new SqlParameter("@id",id)

            };

            try
            {

                SqlHelper.ExecuteNonQuery(sqlConnection, commandType, commandTextDetail, sqlParametersDetail);
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
