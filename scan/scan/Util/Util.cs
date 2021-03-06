﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace scan.Util
{
    public class Util
    {


        public static string GetXMLPath(string fileName)
        {


            //return System.AppDomain.CurrentDomain.BaseDirectory+"../../Xmls/" + fileName;
            //return Application.CommonAppDataPath + @"\Xml\"+fileName;


            // #if DEBUG
            //             return @"..\..\Xmls\" + fileName;
            //  #else
            //         return Application.CommonAppDataPath + @"\Xml\"+fileName; 
            // #endif 
            return Directory.GetCurrentDirectory() + "\\Xmls\\" + fileName;

        }

        public static string GetAppSetting(string key)
        {
            IList list = (IList)System.Configuration.ConfigurationManager.AppSettings.AllKeys;
            if (list.Contains(key))
            {
                string value= System.Configuration.ConfigurationManager.AppSettings[key].ToString();
                return value;
            }
            else
            {
                return "";
            }
        }

        public static string GeConSetting(string key)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[key] != null)
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings[key].ConnectionString;
            }
            else
            {
                return "";
            }
            
        }



        /// <summary>
        /// 是否需要解密
        /// </summary>
        /// <param name="key"></param>
        /// <param name="decrypt"></param>
        /// <returns></returns>
        public static string GetAppSettingDecrypt(string key,bool decrypt)
        {
            IList list = (IList)System.Configuration.ConfigurationManager.AppSettings.AllKeys;
            if (list.Contains(key))
            {
                if (decrypt)
                {
                  return  GetDecryptedValue(System.Configuration.ConfigurationManager.AppSettings[key].ToString());
                }
                else
                {
                    return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
                }
            }
            else
            {
                return "";
            }
        }

        public static string Replace(string str)
        {
            return str.Replace("、,", ".").Replace(" ", "").Replace(",", ".").Replace("，", ".").Replace(":","").Replace("^","").Replace("?","").Replace("？","").Replace("|","");
        }

        public static string ReplaceName(string str)//卜 一  乂/  氺*
        {
            return str.Replace("、,", ".").Replace(" ", "").Replace(",", ".").Replace("，", ".").Replace(":", "").Replace("^", "").Replace("?", "").Replace("？", "").Replace("|", "").Replace("卜", "一").Replace("乂","/").Replace("氺","").Replace("#","").Replace("*","");
        }

        public static string EncrptMd5(string str)
        {
            if (!String.IsNullOrEmpty(str))
            {
                Byte[] strBytes = Encoding.UTF8.GetBytes(str);
                MD5 md5 = new MD5CryptoServiceProvider();
                Byte[] md5Bytes = md5.ComputeHash(strBytes);

                return BitConverter.ToString(md5Bytes).Replace("-", "");
            }
            return "";
        }

        public static string GetRegStr(string str)
        {
            string pattern = @"[^\d^\.]*";
            string result = "";
           

            result= Regex.Replace(str, pattern, "");
          

            return result;
        }

        private static TripleDESCryptoServiceProvider GetCryptoProvider()
        {
            TripleDESCryptoServiceProvider provider = new TripleDESCryptoServiceProvider();

            provider.IV = Convert.FromBase64String("SuFjcEmp/TE=");
            provider.Key = Convert.FromBase64String("KIPSToILGp6fl+3gXJvMsN4IajizYBBT");

            return provider;
        }

        public static string GetEncryptedValue(string inputValue)
        {
            TripleDESCryptoServiceProvider provider =   GetCryptoProvider();

            // 创建内存流来保存加密后的流
            MemoryStream mStream = new MemoryStream();

            // 创建加密转换流
            CryptoStream cStream = new CryptoStream(mStream,
            provider.CreateEncryptor(), CryptoStreamMode.Write);

            // 使用UTF8编码获取输入字符串的字节。
            byte[] toEncrypt = new UTF8Encoding().GetBytes(inputValue);

            // 将字节写到转换流里面去。
            cStream.Write(toEncrypt, 0, toEncrypt.Length);
            cStream.FlushFinalBlock();

            // 在调用转换流的FlushFinalBlock方法后，内部就会进行转换了,此时mStream就是加密后的流了。
            byte[] ret = mStream.ToArray();

            // Close the streams.
            cStream.Close();
            mStream.Close();

            //将加密后的字节进行64编码。
            return Convert.ToBase64String(ret);
        }

        public static string GetDecryptedValue(string inputValue)
        {
            TripleDESCryptoServiceProvider provider = GetCryptoProvider();

            byte[] inputEquivalent = Convert.FromBase64String(inputValue);

            // 创建内存流保存解密后的数据
            MemoryStream msDecrypt = new MemoryStream();

            // 创建转换流。
            CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                                                        provider.CreateDecryptor(),
                                                        CryptoStreamMode.Write);

            csDecrypt.Write(inputEquivalent, 0, inputEquivalent.Length);

            csDecrypt.FlushFinalBlock();
            csDecrypt.Close();

            //获取字符串。
            return new UTF8Encoding().GetString(msDecrypt.ToArray());
        }

        public static void WriteContent(string path,string content)
        {
            try
            {
                Stream stream = new FileStream(path, FileMode.Append);
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(content);
                stream.Write(bytes,0,content.Length);
                stream.Close();
                //StreamWriter sw = new StreamWriter(stream);
                //sw.Write(content);
                //sw.Close(); stream.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// app.config 节点添加 更新 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="encrypt">是否需要加密:true,加密;false,不需要加密</param>

        public static void WriteAppSetting(string key, string value, bool encrypt)
        {
            //key的值为空  则写key value
            if (String.IsNullOrEmpty(GetAppSetting(key)))
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

                if (encrypt)
                {
                    configuration.AppSettings.Settings.Add(key, GetEncryptedValue(value));
                }
                else
                {
                    configuration.AppSettings.Settings.Add(key, value);
                }

                configuration.Save(System.Configuration.ConfigurationSaveMode.Modified);
                //refresh
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");

            }
            //key 不为空 更新 value
            else
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                if (encrypt)
                {
                    configuration.AppSettings.Settings[key].Value = GetEncryptedValue(value);
                }
                else
                {
                    configuration.AppSettings.Settings[key].Value = value;
                   
                }

                configuration.Save(System.Configuration.ConfigurationSaveMode.Modified);
                //refresh
                System.Configuration.ConfigurationManager.RefreshSection("appSettings");
            }

        }

        /// <summary>
        /// app.config connectionStrings 添加 更新 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="encrypt">是否需要加密:true,加密;false,不需要加密</param>

        public static void WriteConSetting(string key, string value, bool encrypt)
        {
            //key的值为空  则写key value
            if (String.IsNullOrEmpty(GeConSetting(key)))
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);

                if (encrypt)
                {
                    System.Configuration.ConnectionStringSettings conSetting = new System.Configuration.ConnectionStringSettings();
                    conSetting.ConnectionString.Insert(0, GetEncryptedValue(value));

                    configuration.ConnectionStrings.ConnectionStrings.Add(conSetting);
                }
                else
                {
                    System.Configuration.ConnectionStringSettings conSetting = new System.Configuration.ConnectionStringSettings();
                    conSetting.ConnectionString.Insert(0, value);

                    configuration.ConnectionStrings.ConnectionStrings.Add(conSetting);
                }

                configuration.Save(System.Configuration.ConfigurationSaveMode.Modified);
                //refresh
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");

            }
            //key 不为空 更新 value
            else
            {
                System.Configuration.Configuration configuration = System.Configuration.ConfigurationManager.OpenExeConfiguration(System.Configuration.ConfigurationUserLevel.None);
                if (encrypt)
                {
                  

                    configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString = GetEncryptedValue(value);
                }
                else
                {
                    configuration.ConnectionStrings.ConnectionStrings[key].ConnectionString = value;
                }

                configuration.Save(System.Configuration.ConfigurationSaveMode.Modified);
                //refresh
                System.Configuration.ConfigurationManager.RefreshSection("connectionStrings");
            }

        }


        /// <summary>
        /// 通过NPOI导出excel
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filePath"></param>
        public static void WriteExcel(DataTable dt, string filePath)
        {
            if (!string.IsNullOrEmpty(filePath) && null != dt && dt.Rows.Count > 0)
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet(dt.TableName);

                NPOI.SS.UserModel.IRow row = sheet.CreateRow(0);
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(i + 1);
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        row2.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                    }
                }
                // 写入到客户端  
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    book = null;
                }
            }
        }

        /// <summary>
        /// 写入多个表
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="filePath"></param>
        public static void WriteExcels(DataSet ds, string filePath)
        {
            if (ds.Tables.Count > 0)
            {
                NPOI.HSSF.UserModel.HSSFWorkbook book = new NPOI.HSSF.UserModel.HSSFWorkbook();
                NPOI.SS.UserModel.ISheet sheet = book.CreateSheet();
                int rownum = 0;
                foreach (DataTable dt in ds.Tables)
                {
                    if (!string.IsNullOrEmpty(filePath) && null != dt && dt.Rows.Count > 0)
                    {
                        NPOI.SS.UserModel.IRow row = sheet.CreateRow(rownum);
                        rownum++;
                        for (int i = 0; i < dt.Columns.Count; i++)
                        {
                            row.CreateCell(i).SetCellValue(dt.Columns[i].ColumnName);
                           
                        }
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            NPOI.SS.UserModel.IRow row2 = sheet.CreateRow(rownum);
                            rownum++;
                            for (int j = 0; j < dt.Columns.Count; j++)
                            {
                                row2.CreateCell(j).SetCellValue(Convert.ToString(dt.Rows[i][j]));
                               
                            }
                        }

                    }
                }

                // 写入到客户端  
                using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
                {
                    book.Write(ms);
                    using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                    book = null;
                }
            }

           
    }

        /// <summary>
        /// 判断奇数
        /// </summary>
        /// <param name="n"></param>
        /// <returns>奇数true 偶数false</returns>

        public static bool IsOdd(int n)
        {
            return Convert.ToBoolean(n % 2);
        }

    }
}
