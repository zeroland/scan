using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using System.Text;
using scan.Interface;
using scan.Util;
using System.Data.SqlClient;
namespace scan.SqlServer
{
    public class ItemProcess : IItemProcess
    {
        
        private string fileName= "ItemProcess.xml";

      

        public DataSet GetDetailById(IDictionary iDictionary)
        {
            DataSet ds = new DataSet();
            string id = iDictionary["id"] ==null?"": iDictionary["id"].ToString();
            if (String.IsNullOrEmpty(id)) throw new ArgumentException("id");

            SqlConnection sqlConnection= SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;

         
            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetDetailById");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@pid",id)            
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

        public DataSet GetShowNameByScanName(string scanname)
        {
            DataSet ds = new DataSet();
       
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetShowNameByScanName");

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

        public DataSet GetShowNameByFRcodeScanName(string scanname,string frcode)
        {
            DataSet ds = new DataSet();

            SqlConnection sqlConnection = SqlHelper.GetConnection();
            CommandType commandType = CommandType.Text;


            string commandText = xmlHelper.GetTextByAttribute(Util.Util.GetXMLPath(fileName), "select", "ID", "GetShowNameByFRcodeScanName");

            SqlParameter[] sqlPrameter = {
                new SqlParameter("@scanname",scanname),
                 new SqlParameter("@sdx",frcode)
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


        public bool UpdateDetailInfo(DataTable dt)
        {
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlTransaction sqlTranscation = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {

                        SqlCommand insertCommand = new SqlCommand(@"INSERT INTO hzyl_wz_fymx (pid, code, name, spec, unit, quantum, price, totalprice,  centercode,feetype,itemtype)
VALUES (@pid, @code, @name, @spec, @unit, @quantum, @price, @totalprice, @centercode,@feetype,@itemtype)", sqlConnection, sqlTranscation);

                        insertCommand.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar, 20, "pid"));
                        insertCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 20, "code"));
                        insertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 20, "name"));
                        insertCommand.Parameters.Add(new SqlParameter("@spec", SqlDbType.VarChar, 20, "spec"));
                        insertCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.VarChar, 20, "unit"));
                        insertCommand.Parameters.Add(new SqlParameter("@quantum", SqlDbType.VarChar, 20, "quantum"));
                        insertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 20, "price"));
                        insertCommand.Parameters.Add(new SqlParameter("@totalprice", SqlDbType.VarChar, 20, "totalprice"));
                        //  insertCommand.Parameters.Add(new SqlParameter("@paydate", SqlDbType.DateTime, 20, "paydate"));
                        insertCommand.Parameters.Add(new SqlParameter("@centercode", SqlDbType.VarChar, 20, "centercode"));
                        insertCommand.Parameters.Add(new SqlParameter("@feetype", SqlDbType.VarChar, 20, "feetype"));
                        insertCommand.Parameters.Add(new SqlParameter("@itemtype", SqlDbType.VarChar, 20, "itemtype"));

                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_fymx SET code=@code,name=@name,spec=@spec,@unit=@unit,quantum=@quantum,price=@price,totalprice=@totalprice,centercode=@centercode,feetype=@feetype,itemtype=@itemtype where id=@id", sqlConnection, sqlTranscation);

                        updateCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 30, "code"));
                        updateCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 50, "name"));
                        updateCommand.Parameters.Add(new SqlParameter("@spec", SqlDbType.VarChar, 30, "spec"));
                        updateCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.VarChar, 30, "unit"));
                        updateCommand.Parameters.Add(new SqlParameter("@quantum", SqlDbType.VarChar, 30, "quantum"));
                        updateCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 30, "price"));
                        updateCommand.Parameters.Add(new SqlParameter("@totalprice", SqlDbType.VarChar, 30, "totalprice"));
                        //updateCommand.Parameters.Add(new SqlParameter("@paydate", SqlDbType.DateTime, 30, "paydate"));
                        updateCommand.Parameters.Add(new SqlParameter("@centercode", SqlDbType.VarChar, 30, "centercode"));
                        updateCommand.Parameters.Add(new SqlParameter("@feetype", SqlDbType.VarChar, 30, "feetype"));
                        updateCommand.Parameters.Add(new SqlParameter("@itemtype", SqlDbType.VarChar, 30, "itemtype"));
                        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 30, "id"));

                        sqlDataAdapter.InsertCommand = insertCommand;
                        sqlDataAdapter.UpdateCommand = updateCommand;

                        sqlDataAdapter.Update(dt);
                    }
                    sqlTranscation.Commit();
                }
                catch (Exception e)
                {
                    sqlTranscation.Rollback();
                    throw e;
                }
                finally
                {
                 sqlConnection.Close();
                }
            }
           
            return true;
        }


        public bool SaveAndUpdateDetail(DataTable dt)
        {
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlTransaction sqlTranscation = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {
                      



                        SqlCommand insertCommand = new SqlCommand(@"INSERT INTO hzyl_wz_fymx (pid, code, name, spec, unit, quantum, price, totalprice, paydate, centercode,centername,feetype,itemtype,detailguid)
VALUES (@pid, @code, @name, @spec, @unit, @quantum, @price, @totalprice, @paydate,@centercode,@centername,@feetype,@itemtype,@detailguid)", sqlConnection, sqlTranscation);

                        insertCommand.Parameters.Add(new SqlParameter("@pid", SqlDbType.VarChar, 20, "pid"));
                        insertCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 100, "code"));
                        insertCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100, "name"));
                        insertCommand.Parameters.Add(new SqlParameter("@spec", SqlDbType.VarChar, 100, "spec"));
                        insertCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.VarChar, 100, "unit"));
                        insertCommand.Parameters.Add(new SqlParameter("@quantum", SqlDbType.VarChar, 100, "quantum"));
                        insertCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 100, "price"));
                        insertCommand.Parameters.Add(new SqlParameter("@totalprice", SqlDbType.VarChar, 100, "totalprice"));
                        insertCommand.Parameters.Add(new SqlParameter("@paydate", SqlDbType.DateTime, 100, "paydate"));
                        insertCommand.Parameters.Add(new SqlParameter("@centercode", SqlDbType.VarChar, 100, "centercode"));
                        insertCommand.Parameters.Add(new SqlParameter("@centername", SqlDbType.VarChar, 100, "centername"));
                        insertCommand.Parameters.Add(new SqlParameter("@feetype", SqlDbType.VarChar, 20, "feetype"));
                        insertCommand.Parameters.Add(new SqlParameter("@itemtype", SqlDbType.VarChar, 20, "itemtype"));
                        insertCommand.Parameters.Add(new SqlParameter("@detailguid", SqlDbType.VarChar, 100, "detailguid"));


                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_fymx SET code=@code,name=@name,spec=@spec,@unit=@unit,quantum=@quantum,price=@price,totalprice=@totalprice,centercode=@centercode,centername=@centername,feetype=@feetype,itemtype=@itemtype ,paydate=@paydate where detailguid=@detailguid", sqlConnection, sqlTranscation);
                        //updateCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 30, System.Data.ParameterDirection.Input,false));
                        updateCommand.Parameters.Add(new SqlParameter("@code", SqlDbType.VarChar, 100, "code"));
                        updateCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100, "name"));
                        updateCommand.Parameters.Add(new SqlParameter("@spec", SqlDbType.VarChar, 100, "spec"));
                        updateCommand.Parameters.Add(new SqlParameter("@unit", SqlDbType.VarChar, 100, "unit"));
                        updateCommand.Parameters.Add(new SqlParameter("@quantum", SqlDbType.VarChar, 100, "quantum"));
                        updateCommand.Parameters.Add(new SqlParameter("@price", SqlDbType.VarChar, 30, "price"));
                        updateCommand.Parameters.Add(new SqlParameter("@totalprice", SqlDbType.VarChar, 30, "totalprice"));
                      
                        updateCommand.Parameters.Add(new SqlParameter("@centercode", SqlDbType.VarChar, 100, "centercode"));
                        updateCommand.Parameters.Add(new SqlParameter("@centername", SqlDbType.VarChar, 100, "centername"));

                        updateCommand.Parameters.Add(new SqlParameter("@feetype", SqlDbType.VarChar, 30, "feetype"));
                        updateCommand.Parameters.Add(new SqlParameter("@itemtype", SqlDbType.VarChar, 30, "itemtype"));
                        updateCommand.Parameters.Add(new SqlParameter("@paydate", SqlDbType.DateTime, 100, "paydate"));
                        updateCommand.Parameters.Add(new SqlParameter("@detailguid", SqlDbType.VarChar, 100, "detailguid"));


                        sqlDataAdapter.InsertCommand = insertCommand;
                        sqlDataAdapter.UpdateCommand = updateCommand;

                        sqlDataAdapter.Update(dt);
                    }
                    sqlTranscation.Commit();
                }
                catch (Exception e)
                {
                    sqlTranscation.Rollback();
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
            
            return true;
        }


        public bool UpdateZyjl(DataTable dt)
        {
            SqlConnection sqlConnection = SqlHelper.GetConnection();
            sqlConnection.Open();
            using (SqlTransaction sqlTranscation = sqlConnection.BeginTransaction())
            {
                try
                {
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter())
                    {



                        SqlCommand updateCommand = new SqlCommand(@"UPDATE hzyl_wz_zyjl
SET zyh = @zyh,	
	ylzh = @ylzh,
	name = @name	
	where id=@id
", sqlConnection, sqlTranscation);
                       
                        updateCommand.Parameters.Add(new SqlParameter("@zyh", SqlDbType.VarChar, 100, "zyh"));
                        updateCommand.Parameters.Add(new SqlParameter("@ylzh", SqlDbType.VarChar, 100, "ylzh"));
                        updateCommand.Parameters.Add(new SqlParameter("@name", SqlDbType.VarChar, 100, "name"));
                        updateCommand.Parameters.Add(new SqlParameter("@id", SqlDbType.VarChar, 100, "id"));      
                        sqlDataAdapter.UpdateCommand = updateCommand;

                        sqlDataAdapter.Update(dt);
                    }
                    sqlTranscation.Commit();
                }
                catch (Exception e)
                {
                    sqlTranscation.Rollback();
                    throw e;
                }
                finally
                {
                    sqlConnection.Close();
                }
            }

            return true;
        }



        public void UpdateItemDictRelation(string scanname, string showname, string centercode,string frcode)
        {

            // prc_updateitemdictrelation  
            string spName = "prc_updateitemdictrelationbyfrcode_end";
            string[] strArray = { scanname , showname , centercode , frcode }; 

           
            int result = SqlHelper.ExecuteNonQuery(SqlHelper.GetConnSting(), spName, strArray);
          

        }

        public DataSet GetItemDict(string frcode, string str )
        {

            string spName = "prc_getitemdict";
            string[] strArray = { frcode, str};
            DataSet ds = new DataSet();


            return ds = SqlHelper.ExecuteDataset(SqlHelper.GetConnSting(), spName, strArray);

              
        }

        //public DataSet GetItemDictByPrcAutoPage(int pagesize,int currentpage,string str,out int totalcount)
        //{
        //    DataSet ds = new DataSet();


        //    CommandType commandType = CommandType.StoredProcedure;


        //    SqlParameter[] sqlPrameter = {
        //        new SqlParameter("@pagesize",pagesize),
        //         new SqlParameter("@currentpage",currentpage),
        //         new SqlParameter("@str",str)
        //    };
        //    using (SqlConnection sqlConnection = SqlHelper.GetConnection())
        //    {

        //    }


        //        SqlHelper.CloseConnection(sqlConnection);
        //    return ds;
        //}

    }
}
