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

        public bool DelDetailByID(string id)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.DelDetailByID(id);
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


        public DataSet CombineFeeDetail(string pid)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.CombineFeeDetail(pid); 
        }

        public bool ComputeFeeDetail(string pid)
        {
            Interface.IMainList iMainList = new SqlServer.MainList();
            return iMainList.ComputeFeeDetail(pid);
        }


        public void ExportDataToExcelByGrid(string id)
        {
            try
            {
                DataSet dsZyjl = this.GetZyjlById(int.Parse(id));
                if (dsZyjl.Tables.Count > 0 && dsZyjl.Tables[0].Rows.Count > 0)
                {
                    DataRow drZyjl = dsZyjl.Tables[0].Rows[0];
                    string name = drZyjl["name"].ToString();
                    string ybhm= drZyjl["ylzh"].ToString();

                    //创建报表对象
                    Util.ReportShow reportShow = new Util.ReportShow("shenhe.grf");
                    reportShow.SetParameter("name", name);
                    reportShow.SetParameter("ybhm", ybhm);

                    //先计算 在再并导出

                    Business.MainList mainList = new Business.MainList();

                    bool result = mainList.ComputeFeeDetail(id);

                    if (result)
                    {
                        DataSet ds = this.CombineFeeDetail(id);

                       

                        //甲类总费用
                        string classAFee = "";
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            DataTable dtCombineResult = ds.Tables[0];

                            //计算总费用
                             string zfy= dtCombineResult.Compute("sum(金额)","").ToString();
                            reportShow.SetParameter("zfy", zfy);

                            //计算甲类费用  
                            DataRow[] drClassA = dtCombineResult.Select("自付比=0 ");
                            if (drClassA.Length > 0)
                            {                               
                                object obj = dtCombineResult.Compute("sum(金额)", "自付比=0 ");
                                if (obj != DBNull.Value)
                                {
                                    classAFee = obj.ToString();
                                }
                                reportShow.SetParameter("ClassAFee", classAFee);
                            }

                            //计算乙类费用  10%
                            DataRow[] drClassB10Array = dtCombineResult.Select("自付比=0.1 ");

                            if (drClassB10Array.Length > 0)
                            {
                                //计算10%的总费用  自付总金额
                                string ClassB10Zfy= dtCombineResult.Compute("sum(金额)", "自付比=0.1 ").ToString();
                                string ClassB10SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.1 ").ToString();
                                reportShow.SetParameter("ClassB10Zfy", ClassB10Zfy);
                                reportShow.SetParameter("ClassB10SFeeTotal", ClassB10SFeeTotal);


                                DataTable dtClassB10 = dtCombineResult.Clone();
                                foreach (DataRow drClassB10 in drClassB10Array)
                                {
                                    dtClassB10.Rows.Add(drClassB10.ItemArray);
                                }

                                for (int i = 0; i < dtClassB10.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dtClassB10.Columns.Count; j++)
                                    {
                                        switch (dtClassB10.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("B10Name" + (i + 1), dtClassB10.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("B10Fee" + (i + 1), dtClassB10.Rows[i]["金额"].ToString());
                                                break;
                                            case "自付金额":
                                                reportShow.SetParameter("B10SFee" + (i + 1), dtClassB10.Rows[i]["自付金额"].ToString());
                                                break;
                                        }
                                    }
                                }

                            }

                            //计算乙类费用  20% 
                            DataRow[] drClassB20Array = dtCombineResult.Select("自付比=0.2 ");

                            if (drClassB20Array.Length > 0)
                            {
                                //计算20%的总费用  自付总金额
                                string ClassB20Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.2 ").ToString();
                                string ClassB20SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.2 ").ToString();
                                reportShow.SetParameter("ClassB20Zfy", ClassB20Zfy);
                                reportShow.SetParameter("ClassB20SFeeTotal", ClassB20SFeeTotal);


                                DataTable dtClassB20 = dtCombineResult.Clone();
                                foreach (DataRow drClassB20 in drClassB20Array)
                                {
                                    dtClassB20.Rows.Add(drClassB20.ItemArray);
                                }

                                for (int i = 0; i < dtClassB20.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dtClassB20.Columns.Count; j++)
                                    {
                                        switch (dtClassB20.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("B20Name" + (i + 1), dtClassB20.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("B20Fee" + (i + 1), dtClassB20.Rows[i]["金额"].ToString());
                                                break;
                                            case "自付金额":
                                                reportShow.SetParameter("B20SFee" + (i + 1), dtClassB20.Rows[i]["自付金额"].ToString());
                                                break;
                                        }
                                    }
                                }

                            }


                            //计算乙类费用  30% 
                            DataRow[] drClassB30Array = dtCombineResult.Select("自付比=0.3 ");

                            if (drClassB30Array.Length > 0)
                            {
                                //计算30%的总费用  自付总金额
                                string ClassB30Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.3 ").ToString();
                                string ClassB30SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.3 ").ToString();
                                reportShow.SetParameter("ClassB30Zfy", ClassB30Zfy);
                                reportShow.SetParameter("ClassB30SFeeTotal", ClassB30SFeeTotal);


                                DataTable dtClassB30 = dtCombineResult.Clone();
                                foreach (DataRow drClassB30 in drClassB30Array)
                                {
                                    dtClassB30.Rows.Add(drClassB30.ItemArray);
                                }

                                for (int i = 0; i < dtClassB30.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dtClassB30.Columns.Count; j++)
                                    {
                                        switch (dtClassB30.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("B30Name" + (i + 1), dtClassB30.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("B30Fee" + (i + 1), dtClassB30.Rows[i]["金额"].ToString());
                                                break;
                                            case "自付金额":
                                                reportShow.SetParameter("B30SFee" + (i + 1), dtClassB30.Rows[i]["自付金额"].ToString());
                                                break;
                                        }
                                    }
                                }

                            }


                            //计算乙类费用  40% 
                            DataRow[] drClassB40Array = dtCombineResult.Select("自付比=0.4 ");

                            if (drClassB40Array.Length > 0)
                            {
                                //计算40%的总费用  自付总金额
                                string ClassB40Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.4 ").ToString();
                                string ClassB40SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.4 ").ToString();
                                reportShow.SetParameter("ClassB40Zfy", ClassB40Zfy);
                                reportShow.SetParameter("ClassB40SFeeTotal", ClassB40SFeeTotal);


                                DataTable dtClassB40 = dtCombineResult.Clone();
                                foreach (DataRow drClassB40 in drClassB40Array)
                                {
                                    dtClassB40.Rows.Add(drClassB40.ItemArray);
                                }

                                for (int i = 0; i < dtClassB40.Rows.Count; i++)
                                {
                                    for (int j = 0; j < dtClassB40.Columns.Count; j++)
                                    {
                                        switch (dtClassB40.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("B40Name" + (i + 1), dtClassB40.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("B40Fee" + (i + 1), dtClassB40.Rows[i]["金额"].ToString());
                                                break;
                                            case "自付金额":
                                                reportShow.SetParameter("B40SFee" + (i + 1), dtClassB40.Rows[i]["自付金额"].ToString());
                                                break;
                                        }
                                    }
                                }

                            }



                            decimal SelfFeeTotal = 0;
                            //计算全自付费用
                            DataRow[] drSelfFee = dtCombineResult.Select("自付比=1");
                            if (drSelfFee.Length > 0)
                            {
                                object objSelfFee= dtCombineResult.Compute("sum(金额)", "自付比=1");
                                if (objSelfFee != DBNull.Value)
                                {
                                    SelfFeeTotal += Decimal.Parse(objSelfFee.ToString());
                                }



                                DataTable dtClassC = dtCombineResult.Clone();
                                foreach (DataRow drC in drSelfFee)
                                {
                                    dtClassC.Rows.Add(drC.ItemArray);
                                }


                                for (int i = 0; i < dtClassC.Rows.Count; i++)
                                {
                                  
                                    for (int j = 0; j < dtClassC.Columns.Count; j++)
                                    {
                                        switch (dtClassC.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("CName" + (i + 1), dtClassC.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("CFee" + (i + 1), dtClassC.Rows[i]["金额"].ToString());
                                                break;
                                           
                                        }
                                    }
                                }

                            }



                            //计算自付比>0 <1 超限价部分
                            DataRow[] drOverFee = dtCombineResult.Select("自付比>0 and 自付比<1 and 超限价金额>0");
                            if (drOverFee.Length > 0)
                            {
                                object objOverFee = dtCombineResult.Compute("sum(金额)", "自付比>0 and 自付比<1 and 超限价金额>0");
                                if (objOverFee != DBNull.Value)
                                {
                                    SelfFeeTotal += Decimal.Parse(objOverFee.ToString());
                                }



                                DataTable dtClassD = dtCombineResult.Clone();
                                foreach (DataRow drD in drOverFee)
                                {
                                    dtClassD.Rows.Add(drD.ItemArray);
                                }


                                for (int i = 0; i < dtClassD.Rows.Count; i++)
                                {

                                    for (int j = 0; j < dtClassD.Columns.Count; j++)
                                    {
                                        switch (dtClassD.Columns[j].ColumnName)
                                        {
                                            case "项目名称":
                                                reportShow.SetParameter("CName" + (i + 1+ drSelfFee.Length), dtClassD.Rows[i]["项目名称"].ToString());
                                                break;
                                            case "金额":
                                                reportShow.SetParameter("CFee" + (i + 1+ drSelfFee.Length), dtClassD.Rows[i]["金额"].ToString());
                                                break;

                                        }
                                    }
                                }

                            }

                            if(SelfFeeTotal>0)
                            { 
                              reportShow.SetParameter("SelfFeeTotal",Convert.ToString(SelfFeeTotal));
                            }

                            reportShow.Show();

                        }



                    }
                    else
                    {
                        MessageBox.Show("计算费用明细失败！");
                        return;
                    }

                }
                else
                {
                    throw new ApplicationException("未获取到该住院记录的信息!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public void ExportDataToExcelByGridCombine(string id)
        {
            try
            {
                DataSet dsZyjl = this.GetZyjlById(int.Parse(id));
                if (dsZyjl.Tables.Count > 0 && dsZyjl.Tables[0].Rows.Count > 0)
                {
                    DataRow drZyjl = dsZyjl.Tables[0].Rows[0];
                    string name = drZyjl["name"].ToString();
                    string ybhm = drZyjl["ylzh"].ToString();

                    //创建报表对象
                    Util.ReportShow reportShow = new Util.ReportShow("shenhe_old.grf");
                    reportShow.SetParameter("name", name);
                    reportShow.SetParameter("ybhm", ybhm);

                    //先计算 在再并导出

                    Business.MainList mainList = new Business.MainList();

                    bool result = mainList.ComputeFeeDetail(id);

                    if (result)
                    {
                        DataSet ds = this.CombineFeeDetail(id);



                        //甲类总费用
                        string classAFee = "";
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            DataTable dtCombineResult = ds.Tables[0];

                            //计算总费用
                            string zfy = dtCombineResult.Compute("sum(金额)", "").ToString();
                            reportShow.SetParameter("zfy", zfy);

                            //计算甲类费用  
                            DataRow[] drClassA = dtCombineResult.Select("自付比=0 ");
                            if (drClassA.Length > 0)
                            {
                                object obj = dtCombineResult.Compute("sum(金额)", "自付比=0 ");
                                if (obj != DBNull.Value)
                                {
                                    classAFee = obj.ToString();
                                }
                                reportShow.SetParameter("ClassAFee", classAFee);
                            }


                            //创建新表
                            DataSet dsClassB = new DataSet();
                            DataTable dtClassB = dtCombineResult.Clone();
                            dtClassB.Columns.Add("项目编码1");
                            dtClassB.Columns.Add("项目名称1");
                            dtClassB.Columns.Add("金额1");
                            dtClassB.Columns.Add("自付比1");
                            dtClassB.Columns.Add("自付金额1");
                            dtClassB.Columns.Add("超限价金额1");
                            int rowNum = 0;//新表的总行数


                            //计算乙类费用  10%
                            DataRow[] drClassB10Array = dtCombineResult.Select("自付比=0.1");

                            if (drClassB10Array.Length > 0)
                            {
                                //计算10%的总费用  自付总金额
                                string ClassB10Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.1 ").ToString();
                                string ClassB10SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.1 ").ToString();
                                reportShow.SetParameter("ClassB10Zfy", ClassB10Zfy);
                                reportShow.SetParameter("ClassB10SFeeTotal", ClassB10SFeeTotal);


                                for (int i = 1; i <= drClassB10Array.Length; i++)
                                {
                                    //奇数
                                    if (Util.Util.IsOdd(i))
                                    {

                                        dtClassB.Rows.Add(drClassB10Array[i - 1].ItemArray);
                                        rowNum++;
                                    }
                                    else//偶数
                                    {
                                        dtClassB.Rows[rowNum-1]["项目编码1"] = drClassB10Array[i - 1]["项目编码"];
                                        dtClassB.Rows[rowNum - 1]["项目名称1"] = drClassB10Array[i - 1]["项目名称"];
                                        dtClassB.Rows[rowNum - 1]["金额1"] = drClassB10Array[i - 1]["金额"];
                                        dtClassB.Rows[rowNum - 1]["自付比1"] = drClassB10Array[i - 1]["自付比"];
                                        dtClassB.Rows[rowNum - 1]["自付金额1"] = drClassB10Array[i - 1]["自付金额"];
                                        dtClassB.Rows[rowNum - 1]["超限价金额1"] = drClassB10Array[i - 1]["超限价金额"];

                                    }                                  
                                }                                
                            }


                            //计算乙类费用  20%
                            DataRow[] drClassB20Array = dtCombineResult.Select("自付比=0.2");

                            if (drClassB20Array.Length > 0)
                            {
                                //计算20%的总费用  自付总金额
                                string ClassB20Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.2 ").ToString();
                                string ClassB20SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.2 ").ToString();
                                reportShow.SetParameter("ClassB20Zfy", ClassB20Zfy);
                                reportShow.SetParameter("ClassB20SFeeTotal", ClassB20SFeeTotal);


                                for (int i = 1; i <= drClassB20Array.Length; i++)
                                {
                                    //奇数
                                    if (Util.Util.IsOdd(i))
                                    {

                                        dtClassB.Rows.Add(drClassB20Array[i - 1].ItemArray);
                                        rowNum++;
                                    }
                                    else//偶数
                                    {
                                        dtClassB.Rows[rowNum - 1]["项目编码1"] = drClassB20Array[i - 1]["项目编码"];
                                        dtClassB.Rows[rowNum - 1]["项目名称1"] = drClassB20Array[i - 1]["项目名称"];
                                        dtClassB.Rows[rowNum - 1]["金额1"] = drClassB20Array[i - 1]["金额"];
                                        dtClassB.Rows[rowNum - 1]["自付比1"] = drClassB20Array[i - 1]["自付比"];
                                        dtClassB.Rows[rowNum - 1]["自付金额1"] = drClassB20Array[i - 1]["自付金额"];
                                        dtClassB.Rows[rowNum - 1]["超限价金额1"] = drClassB20Array[i - 1]["超限价金额"];

                                    }
                                }
                            }


                            //计算乙类费用  30%
                            DataRow[] drClassB30Array = dtCombineResult.Select("自付比=0.3");

                            if (drClassB30Array.Length > 0)
                            {
                                //计算30%的总费用  自付总金额
                                string ClassB30Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.3 ").ToString();
                                string ClassB30SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.3 ").ToString();
                                reportShow.SetParameter("ClassB30Zfy", ClassB30Zfy);
                                reportShow.SetParameter("ClassB30SFeeTotal", ClassB30SFeeTotal);


                                for (int i = 1; i <= drClassB30Array.Length; i++)
                                {
                                    //奇数
                                    if (Util.Util.IsOdd(i))
                                    {

                                        dtClassB.Rows.Add(drClassB30Array[i - 1].ItemArray);
                                        rowNum++;
                                    }
                                    else//偶数
                                    {
                                        dtClassB.Rows[rowNum - 1]["项目编码1"] = drClassB30Array[i - 1]["项目编码"];
                                        dtClassB.Rows[rowNum - 1]["项目名称1"] = drClassB30Array[i - 1]["项目名称"];
                                        dtClassB.Rows[rowNum - 1]["金额1"] = drClassB30Array[i - 1]["金额"];
                                        dtClassB.Rows[rowNum - 1]["自付比1"] = drClassB30Array[i - 1]["自付比"];
                                        dtClassB.Rows[rowNum - 1]["自付金额1"] = drClassB30Array[i - 1]["自付金额"];
                                        dtClassB.Rows[rowNum - 1]["超限价金额1"] = drClassB30Array[i - 1]["超限价金额"];

                                    }
                                }
                            }

                            //计算乙类费用  40%
                            DataRow[] drClassB40Array = dtCombineResult.Select("自付比=0.4");

                            if (drClassB40Array.Length > 0)
                            {
                                //计算40%的总费用  自付总金额
                                string ClassB40Zfy = dtCombineResult.Compute("sum(金额)", "自付比=0.4 ").ToString();
                                string ClassB40SFeeTotal = dtCombineResult.Compute("sum(自付金额)", "自付比=0.4 ").ToString();
                                reportShow.SetParameter("ClassB40Zfy", ClassB40Zfy);
                                reportShow.SetParameter("ClassB40SFeeTotal", ClassB40SFeeTotal);


                                for (int i = 1; i <= drClassB40Array.Length; i++)
                                {
                                    //奇数
                                    if (Util.Util.IsOdd(i))
                                    {

                                        dtClassB.Rows.Add(drClassB40Array[i - 1].ItemArray);
                                        rowNum++;
                                    }
                                    else//偶数
                                    {
                                        dtClassB.Rows[rowNum - 1]["项目编码1"] = drClassB40Array[i - 1]["项目编码"];
                                        dtClassB.Rows[rowNum - 1]["项目名称1"] = drClassB40Array[i - 1]["项目名称"];
                                        dtClassB.Rows[rowNum - 1]["金额1"] = drClassB40Array[i - 1]["金额"];
                                        dtClassB.Rows[rowNum - 1]["自付比1"] = drClassB40Array[i - 1]["自付比"];
                                        dtClassB.Rows[rowNum - 1]["自付金额1"] = drClassB40Array[i - 1]["自付金额"];
                                        dtClassB.Rows[rowNum - 1]["超限价金额1"] = drClassB40Array[i - 1]["超限价金额"];

                                    }
                                }
                            }




                            //创建新自费表
                            DataSet dsClassC = new DataSet();
                            DataTable dtClassC = dtCombineResult.Clone();
                            dtClassC.Columns.Add("项目编码1");
                            dtClassC.Columns.Add("项目名称1");
                            dtClassC.Columns.Add("金额1");
                            dtClassC.Columns.Add("自付比1");
                            dtClassC.Columns.Add("自付金额1");
                            dtClassC.Columns.Add("超限价金额1");

                            dtClassC.Columns.Add("项目编码2");
                            dtClassC.Columns.Add("项目名称2");
                            dtClassC.Columns.Add("金额2");
                            dtClassC.Columns.Add("自付比2");
                            dtClassC.Columns.Add("自付金额2");
                            dtClassC.Columns.Add("超限价金额2");

                            int rowNumSelf = 0;//新表的总行数


                            //计算全自付费用
                            DataRow[] drSelfFeeArray = dtCombineResult.Select("自付比=1 or (自付比>0 and 自付比<1 and 超限价金额>0)");
                            if (drSelfFeeArray.Length > 0)
                            {
                                


                                //如果 自付比=1 全自费
                                //如果 自付比>0 and 自付比<1 and 超限价金额>0  超限价
                                for (int i = 1; i <= drSelfFeeArray.Length; i++)
                                {
                                    string nameOver = "";
                                    string nameAllSelf = "";

                                    if (drSelfFeeArray[i - 1]["自付比"].ToString() == "1")
                                        nameAllSelf = "(全自费)";

                                    if(drSelfFeeArray[i - 1]["自付比"].ToString() != "1" && drSelfFeeArray[i - 1]["自付比"].ToString() != "0" && drSelfFeeArray[i - 1]["超限价金额"].ToString() != "0")
                                        nameOver = "(超)";


                                    //第一列
                                    if (i % 3 == 1)
                                    {
                                        object[] objArray = new object[]{
drSelfFeeArray[i - 1]["项目编码"],drSelfFeeArray[i - 1]["项目名称"] + nameOver + nameAllSelf,drSelfFeeArray[i - 1]["金额"],drSelfFeeArray[i - 1]["自付比"],drSelfFeeArray[i - 1]["自付金额"],drSelfFeeArray[i - 1]["超限价金额"]
                                        };


                                        // dtClassC.Rows.Add(drSelfFeeArray[i - 1].ItemArray);
                                        dtClassC.Rows.Add(objArray);
                                        rowNumSelf++;
                                    }
                                    else if (i % 3 == 2)//第二列
                                    {
                                        dtClassC.Rows[rowNumSelf - 1]["项目编码1"] = drSelfFeeArray[i - 1]["项目编码"];
                                        dtClassC.Rows[rowNumSelf - 1]["项目名称1"] = drSelfFeeArray[i - 1]["项目名称"] + nameOver + nameAllSelf;
                                        dtClassC.Rows[rowNumSelf - 1]["金额1"] = drSelfFeeArray[i - 1]["金额"];
                                        dtClassC.Rows[rowNumSelf - 1]["自付比1"] = drSelfFeeArray[i - 1]["自付比"];
                                        dtClassC.Rows[rowNumSelf - 1]["自付金额1"] = drSelfFeeArray[i - 1]["自付金额"];
                                        dtClassC.Rows[rowNumSelf - 1]["超限价金额1"] = drSelfFeeArray[i - 1]["超限价金额"];
                                    }
                                    else//第三列
                                    {
                                        dtClassC.Rows[rowNumSelf - 1]["项目编码2"] = drSelfFeeArray[i - 1]["项目编码"];
                                        dtClassC.Rows[rowNumSelf - 1]["项目名称2"] = drSelfFeeArray[i - 1]["项目名称"] + nameOver + nameAllSelf;
                                        dtClassC.Rows[rowNumSelf - 1]["金额2"] = drSelfFeeArray[i - 1]["金额"];
                                        dtClassC.Rows[rowNumSelf - 1]["自付比2"] = drSelfFeeArray[i - 1]["自付比"];
                                        dtClassC.Rows[rowNumSelf - 1]["自付金额2"] = drSelfFeeArray[i - 1]["自付金额"];
                                        dtClassC.Rows[rowNumSelf - 1]["超限价金额2"] = drSelfFeeArray[i - 1]["超限价金额"];

                                    }
                                }



                            }



                        











                            //Util.Util.WriteExcel(dtClassB, "d:/test.xls");
                            dsClassB.Tables.Add(dtClassB);
                            dsClassC.Tables.Add(dtClassC);
                            reportShow.Report.LoadDataFromXML(dsClassB.GetXml());

                            grproLib.GridppReport subReport = new grproLib.GridppReport();

                            reportShow.Report.ControlByName("SubReport").AsSubReport.Report = subReport;
                            subReport.LoadDataFromXML(dsClassC.GetXml());

                            reportShow.Show();

                        }



                    }
                    else
                    {
                        MessageBox.Show("计算费用明细失败！");
                        return;
                    }

                }
                else
                {
                    throw new ApplicationException("未获取到该住院记录的信息!");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
