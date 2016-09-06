﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

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
            return System.Configuration.ConfigurationManager.AppSettings[key].ToString();
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
    }
}