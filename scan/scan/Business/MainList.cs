using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace scan.Business
{
    public class MainList
    {
        public DataSet GetInhosList()
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.GetInhosList();
        }

        public bool InsertZyjl(IDictionary iDictionary)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.InsertZyjl(iDictionary);
        }

        public DataSet GetZyjlById(int id)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.GetZyjlById(id);
        }

        public DataSet GetZyjlByGuid(string guid)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.GetZyjlByGuid(guid);
        }

        public bool InsertFymx(IDictionary iDictionary)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.InsertFymx(iDictionary);
        }

        public DataSet GetMainInfoList(string sdx, Hashtable ht)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.GetMainInfoList(sdx, ht);
        }

        public bool UpdateUploadZyjlById(string id)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.UpdateUploadZyjlById(id);
        }
        public bool UpdateUploadFymxByPId(string id)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.UpdateUploadFymxByPId(id);
        }

        public bool DeleteZyjlById(string id)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.DeleteZyjlById(id);
        }

        public string UploadZyjl(DataRow dr)
        {
            Hashtable ht = new Hashtable();
            ht.Add("id", dr["id"].ToString());

            DataTable dtDetail = new Business.ItemProcess().GetDetailById(ht).Tables[0];
            

            Hashtable htPackage = new Hashtable();
            ht.Add("d101_01", dr["yljg"].ToString() == "" ? Util.Util.GetAppSetting("inhosOrg") : dr["yljg"].ToString());
            ht.Add("d401_19", dr["sdx"].ToString());
            ht.Add("t104_01", dr["zyh"].ToString());
            ht.Add("t104_02", "0");//个人编号默认为0 上传中获取 23027527
            ht.Add("t104_03", dr["name"].ToString());
            ht.Add("t104_04", "1");//性别 上传获取
            ht.Add("t104_05", dr["idcard"].ToString());
            ht.Add("t104_06", "0");//年龄 上传获取
            ht.Add("t104_07", "0");//家庭编号 上传获取 5323045
            ht.Add("t104_08", dr["ylzh"].ToString());
            ht.Add("t104_09", dr["zyh"].ToString());
            ht.Add("t104_10", dr["jzlx"].ToString());
            ht.Add("t104_11", Convert.ToDateTime(dr["rysj"]).ToString("yyyyMMddHHmm"));
            ht.Add("t104_12", Convert.ToDateTime(dr["cysj"]).ToString("yyyyMMddHHmm"));
            ht.Add("t104_13", dr["sjzyts"].ToString());
            ht.Add("t104_16", dr["ryks"].ToString() == "" ? "3099" : dr["ryks"].ToString());
            ht.Add("t104_16_n", "");
            ht.Add("t104_17", dr["cyks"].ToString() == "" ? "3099" : dr["cyks"].ToString());
            ht.Add("t104_17_n", dr["cyksname"].ToString());
            ht.Add("t104_18", dr["jzys"].ToString());
            ht.Add("t104_19", dr["ryzt"].ToString() == "" ? "3" : dr["ryzt"].ToString());
            ht.Add("t104_20", dr["cyzt"].ToString() == "" ? "1" : dr["cyzt"].ToString());
            ht.Add("t104_21", dr["cyzd"].ToString() == "" ? "J39.900" : dr["cyzd"].ToString());
            ht.Add("i208_05", dr["orgname"].ToString());
            ht.Add("i208_06", "0");//特殊补偿标识为0
            ht.Add("i208_07", "0");//转诊单编号默认为0
            ht.Add("i208_08", System.DateTime.Now.Year);//默认为当前年度
            ht.Add("remark1", "3");//0 ，1， 2 为即时结报 非即时结报 ，添加类型3为外诊扫描录入上传
            ht.Add("remark2", "0");// remark字段再次确认下
            ht.Add("remark3", "0");
            ht.Add("i208_09", dr["guid"].ToString());

            XmlDocument xd = new XmlDocument();
            xd.Load(Util.Util.GetXMLPath("200222.xml"));
            XmlElement root = xd.DocumentElement;

            foreach (XmlNode xn in root.ChildNodes)
            {
                if (ht.ContainsKey(xn.Name))
                {
                    xn.InnerText = ht[xn.Name].ToString();
                }
            }

            //拼接明细包
            XmlDocument xdDetail = new XmlDocument();
            XmlElement rootDetail = xdDetail.CreateElement("list");
            xdDetail.AppendChild(rootDetail);
            for (int i = 0; i < dtDetail.Rows.Count; i++)
            {

                //校验中心编码不能为空
                string centercode = dtDetail.Rows[i]["centercode"] == null ? "" : dtDetail.Rows[i]["centercode"].ToString();
                if (String.IsNullOrEmpty(centercode))
                {
                   
                     string hisname= dtDetail.Rows[i]["name"].ToString().Replace(">", "").Replace("<", "").Replace("〉", "");
                    throw new ApplicationException("中心编码不能为空!请先对照再上传!医院名称:"+ hisname);
                 
                }



                XmlElement item = xdDetail.CreateElement("item");
                item.SetAttribute("id", (i + 1).ToString());


                XmlElement t105_01 = xdDetail.CreateElement("t105_01");
                t105_01.InnerText = dtDetail.Rows[i]["id"].ToString();

                XmlElement t105_02 = xdDetail.CreateElement("t105_02");
                t105_02.InnerText = dtDetail.Rows[i]["zyh"].ToString();

                XmlElement t105_03 = xdDetail.CreateElement("t105_03");
                t105_03.InnerText = dtDetail.Rows[i]["feetype"].ToString();

                XmlElement t105_04 = xdDetail.CreateElement("t105_04");
                t105_04.InnerText = dtDetail.Rows[i]["centercode"].ToString();

                XmlElement t105_05 = xdDetail.CreateElement("t105_05");
                t105_05.InnerText = "";//规格改为传空 

                XmlElement t105_07 = xdDetail.CreateElement("t105_07");
                string t105_07Value = dtDetail.Rows[i]["price"] == null ? "0" : dtDetail.Rows[i]["price"].ToString();
                if (String.IsNullOrEmpty(t105_07Value)) t105_07Value = "0";
                t105_07.InnerText = t105_07Value;

                XmlElement t105_08 = xdDetail.CreateElement("t105_08");
                string t105_08Value = dtDetail.Rows[i]["quantum"] == null ? "0" : dtDetail.Rows[i]["quantum"].ToString();
                if (String.IsNullOrEmpty(t105_08Value)) t105_08Value = "0";
                t105_08.InnerText = t105_08Value;

                XmlElement t105_10 = xdDetail.CreateElement("t105_10");
                string t105_10Value = dtDetail.Rows[i]["totalprice"] == null ? "0" : dtDetail.Rows[i]["totalprice"].ToString();
                if (String.IsNullOrEmpty(t105_10Value)) t105_10Value = "0";
                t105_10.InnerText = t105_10Value;


                XmlElement t105_12 = xdDetail.CreateElement("t105_12");
                t105_12.InnerText = dr["jzys"].ToString();

                XmlElement t105_15 = xdDetail.CreateElement("t105_15");
                t105_15.InnerText = "外诊扫描";//经办人默认

                XmlElement t105_17 = xdDetail.CreateElement("t105_17");
                t105_17.InnerText = Convert.ToDateTime(dtDetail.Rows[i]["paydate"]).ToString("yyyyMMddHHmm");

                XmlElement i208_01 = xdDetail.CreateElement("i208_01");
                i208_01.InnerText = dtDetail.Rows[i]["centername"].ToString().Replace(">", "").Replace("<", "").Replace("〉", "");

                XmlElement i208_02 = xdDetail.CreateElement("i208_02");
                i208_02.InnerText = dtDetail.Rows[i]["centercode"].ToString();

                XmlElement i208_03 = xdDetail.CreateElement("i208_03");
                i208_03.InnerText = "";//单位改为传空

                XmlElement i208_04 = xdDetail.CreateElement("i208_04");
                i208_04.InnerText = dtDetail.Rows[i]["itemtype"].ToString();




                XmlElement i208_05 = xdDetail.CreateElement("i208_05");
                i208_05.InnerText = "0";
                XmlElement i208_06 = xdDetail.CreateElement("i208_06");
                i208_06.InnerText = "1";
                XmlElement i208_07 = xdDetail.CreateElement("i208_07");
                i208_07.InnerText = "1";
                XmlElement i208_08 = xdDetail.CreateElement("i208_08");
                XmlElement remark1 = xdDetail.CreateElement("remark1");
                remark1.InnerText = "0";
                XmlElement remark2 = xdDetail.CreateElement("remark2");
                XmlElement remark3 = xdDetail.CreateElement("remark3");
                XmlElement remark4 = xdDetail.CreateElement("remark4");
                XmlElement remark5 = xdDetail.CreateElement("remark5");
                XmlElement i208_09 = xdDetail.CreateElement("i208_09");
                i208_09.InnerText = "0";
                XmlElement i208_10 = xdDetail.CreateElement("i208_10");
                i208_10.InnerText = "0";


                item.AppendChild(t105_01);
                item.AppendChild(t105_02);
                item.AppendChild(t105_03);
                item.AppendChild(t105_04);
                item.AppendChild(t105_05);
                item.AppendChild(t105_07);
                item.AppendChild(t105_08);
                item.AppendChild(t105_10);
                item.AppendChild(t105_12);
                item.AppendChild(t105_15);
                item.AppendChild(t105_17);
                item.AppendChild(i208_01);
                item.AppendChild(i208_02);
                item.AppendChild(i208_03);
                item.AppendChild(i208_04);
                item.AppendChild(i208_05);
                item.AppendChild(i208_06);
                item.AppendChild(i208_07);
                item.AppendChild(i208_08);
                item.AppendChild(remark1);
                item.AppendChild(remark2);
                item.AppendChild(remark3);
                item.AppendChild(remark4);
                item.AppendChild(remark5);
                item.AppendChild(i208_09);
                item.AppendChild(i208_10);
                rootDetail.AppendChild(item);



            }

            //拼最终包
            StringBuilder sb = new StringBuilder();
            //  XmlDocument xdPackage = new XmlDocument();
            //  xdPackage.Load("../../Xmls/soap.xml");

            //  sb.Append("<![CDATA[");
            XmlNode businessdata = xd.SelectSingleNode("businessdata");

            XmlElement tmp = xd.CreateElement("tmp");
            tmp.InnerXml = xdDetail.InnerXml;

            businessdata.AppendChild(tmp);

            sb.Append(xd.InnerXml.Replace("<tmp>", "").Replace("</tmp>", ""));
            //  sb.Append("]]>");

            //保存包记录 RollingLogFileAppender_waizhen
            System.IO.FileInfo fileinfo = new System.IO.FileInfo(Application.StartupPath + "\\" + "log4net.config");

            log4net.Config.XmlConfigurator.Configure(fileinfo);
            log4net.ILog log = log4net.LogManager.GetLogger("FileLogger_waizhen");
            log.Info("住院记录ID:"+ dr["id"].ToString()+"姓名:"+ dr["name"].ToString()+  sb.ToString() );


            //string result = xdPackage.InnerXml.Replace("<![CDATA[]]>", sb.ToString());
            WebReference.HospitalServiceImpService service = new WebReference.HospitalServiceImpService();

            //需要加密url
            service.Url = "http://125.46.57.77:80/xyhnccmp2/HospitalServicePort";
            //service.Timeout = 20000;
            string result = service.funMain(sb.ToString());
            return result;
        }


    }
}
