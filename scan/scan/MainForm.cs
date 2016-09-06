using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using FREngine;
using FineReaderVisualComponents;

using System.IO;
using System.Collections;
using System.Xml;
using System.Threading;

namespace scan
{
    public partial class MainForm : Form, IScanCallback
    {
        public Sample.EngineLoader engineLoader = null;
        public ComponentSynchronizer synchronizer = null;
        public FREngine.FRDocument document = null;
        public ScanManager scanManager;
        private string scanFolder;
        private bool isRead = false;
        private int pageIndex;
        private string[] billStyle = { "Code", "Name", "Price", "Quantum", "Unit", "TotalPrice", "Rate" };
        private string[] billStyleName;
        public string guid=Guid.NewGuid().ToString();
        public string pName = "";
        public string beginName = "", endName = "",frcode="";
        private Hashtable dictHT = new Hashtable();
        public MainForm()
        {
            InitializeComponent();
           

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ScanTimer.Enabled = true;
         
        }

        private void BindItemType()
        {
            ScanDataSet.DictRow row = scanDataSet.Dict.NewDictRow();
            row["Code"] = "0";
            row["Name"] = "药品";
            scanDataSet.Dict.AddDictRow(row);
            row = scanDataSet.Dict.NewDictRow();
            row["Code"] = "1";
            row["Name"] = "诊疗";
            scanDataSet.Dict.AddDictRow(row);


        }

        private void GetStyleName()
        {
        
            if (billStyle.Length > 0)
            {
                billStyleName = new string[billStyle.Length];
                for (int i = 0; i < billStyle.Length; i++)
                {
                    switch (billStyle[i])
                    {
                        case "Code":
                            billStyleName[i] = "项目代码";
                            break;
                        case "Name":
                            billStyleName[i] = "项目名称";
                            break;
                        case "Spec":
                            billStyleName[i] = "规格";
                            break;
                        case "Quantum":
                            billStyleName[i] = "数量";
                            break;
                        case "Unit":
                            billStyleName[i] = "单位";
                            break;
                        case "Price":
                            billStyleName[i] = "单价";
                            break;
                        case "TotalPrice":
                            billStyleName[i] = "金额";
                            break;
                        case "Rate":
                            billStyleName[i] = "其他";
                            break;

                    }
                }
            }

        }

        private void BindFeeTpe()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("code");
            dt.Columns.Add("name");
            dt.Rows.Add(new string[] { "01", "药费" });
            dt.Rows.Add(new string[] { "0101", "西药费" });
            dt.Rows.Add(new string[] { "0102", "中草药费" });
            dt.Rows.Add(new string[] { "0103", "中成药费" });
            dt.Rows.Add(new string[] { "02", "治疗费" });
            dt.Rows.Add(new string[] { "0201", "一般治疗费" });
            dt.Rows.Add(new string[] { "0202", "中医治疗费" });
            dt.Rows.Add(new string[] { "0203", "特殊治疗费" });
            dt.Rows.Add(new string[] { "03", "手术费" });
            dt.Rows.Add(new string[] { "04", "材料费" });
            dt.Rows.Add(new string[] { "05", "检查费" });
            dt.Rows.Add(new string[] { "06", "化验费" });
            dt.Rows.Add(new string[] { "07", "床位费" });
            dt.Rows.Add(new string[] { "08", "护理费" });
            dt.Rows.Add(new string[] { "09", "其他费" });


            DataGridViewComboBoxColumn column=(DataGridViewComboBoxColumn)this.ScanDataGridView.Columns["FeeType"];
         
            column.DisplayMember = "name";
            column.ValueMember = "code";
            column.DataSource = dt;
            
        }

        private void init()
        {
            Application.DoEvents();
            try
            {
                synchronizer = new ComponentSynchronizerClass();
                synchronizer.DocumentViewer = (FineReaderVisualComponents.DocumentViewer)ScanDocumentViewer.GetOcx();
                synchronizer.ImageViewer = (FineReaderVisualComponents.ImageViewer)ScanImageViewer.GetOcx();
              

                engineLoader = new Sample.EngineLoader();
                engineLoader.Engine.LoadPredefinedProfile("Default");
                engineLoader.Engine.ParentWindow = this.Handle.ToInt64();
                engineLoader.Engine.ApplicationTitle = this.Text;
                
                document = engineLoader.Engine.CreateFRDocument();
                synchronizer.Document = document;
                document.OnProgress += new DIFRDocumentEvents_OnProgressEventHandler(Document_OnProgress);
                document.OnPageProcessed += new DIFRDocumentEvents_OnPageProcessedEventHandler(Document_OnPageProcessed);
             

                   DocumentProcessingParams param = engineLoader.Engine.CreateDocumentProcessingParams();
                param.PageProcessingParams.RecognizerParams.SetPredefinedTextLanguage("ChinesePRC");
                synchronizer.ProcessingParams = param;


                scanManager = engineLoader.Engine.CreateScanManager(false);

                this.BindItemType();
                this.BindFeeTpe();
                this.loadCenterData();
                this.loadItemDict();
                this.initValues();
                this.initDictCode();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
          
        }

        private void initValues()
        {
            this.frcode = Util.Util.GetAppSetting("rcode");
         
        }


        private void initDictCode()
        {
           
         
            this.dictHT["请选择"] = "";
            this.dictHT["自费材料"] = "499000002";
            this.dictHT["其他可报一次性材料"] = "499000001";
            this.dictHT["其他可报诊疗费"] = "999000002";
            this.dictHT["其他不可报诊疗费"] = "999000001";
            this.dictHT["可报销甲类西药"] = "W9999999999000a";
            this.dictHT["可报销乙类西药"] = "W9999999999000b";
            this.dictHT["可报销甲类中成药"] = "C9999999999000a";
            this.dictHT["可报销乙类中成药"] = "C9999999999000b";
            this.dictHT["可报销中药饮片"] = "P9999999999000y";
            this.dictHT["不可报西药"] = "W9999999999000z";
            this.dictHT["不可报中成药"] = "C9999999999000z";
            this.dictHT["不可报销中药饮片"] = "P9999999999000z";


            
            ArrayList arrList = new ArrayList(this.dictHT.Keys);
            foreach (string key in arrList)
            {
                this.DictToolStripComboBox.Items.Add(key);
            }
            this.DictToolStripComboBox.SelectedItem= "请选择";

        }


        void Document_OnPageProcessed(FRDocument Sender, int index, PageProcessingStageEnum stage)
        {
            if (stage == PageProcessingStageEnum.PPS_Synthesis)
            {
                document.Pages[pageIndex].Layout.Blocks.DeleteAll();

            }
            pageIndex = index;
           
        }

        private void loadCenterData()
        {
            new Business.DictProcess().GetCenterData(scanDataSet);
        }

        private void loadItemDict()
        {
            new Business.DictProcess().GetItemDict(scanDataSet);
        }

        private void clear()
        {
            if(document.Pages.Count>0)
            {
                int pageCount = document.Pages.Count;
                for (int i = 0; i < pageCount; i++)
                {
                    //删除一次 索引会重新生成  索引值用 0
                    document.Pages.DeleteAt(0);
                  
                }
              
            }
        }



        public void callBack(String guid,String name,String[] style)
        {
            if(!String.IsNullOrEmpty(guid)) this.guid = guid;
            if (!String.IsNullOrEmpty(name)) this.pName = name;


            if (style != null) this.billStyle = style;
            this.GetStyleName();


            this.scanDataSet.ScanDataTable.Clear();

            this.Text = "外诊扫描录入系统--当前患者" + name;
            if (this.billStyleName.Length > 0)
            {
                this.Text += "       当前清单格式:" + String.Join("|", this.billStyleName);
            }
        }


        //正在加载框采用子线程处理
        LoadForm loadForm;
        Thread MyProgressWait;
        private void ProgressBarWait()
        {
            loadForm = new LoadForm();
            loadForm.MdiParent = this.MdiParent;
            loadForm.ShowDialog();
            if (loadForm.DialogResult == DialogResult.OK)
            {
                loadForm.Dispose();
                loadForm.Close();
            }

        }

            void Document_OnProgress(FRDocument Sender, int percentage, ref bool cancel)
        {
            try
            {
                Application.DoEvents();
                ScanToolStripProgressBar.Value = percentage;
                if (percentage == 100)
                {
                    if (isRead)
                    {

                        this.pageIndex = synchronizer.PageIndex;


                          LayoutBlocks blocks = document.Pages[pageIndex].Layout.Blocks;
                       
                        for (int index = 0; index < blocks.Count; index++)
                        {
                            IBlock block = blocks[index];
                            if (block.Type == BlockTypeEnum.BT_Table)
                            {
                                TableBlock tableBlock = block.GetAsTableBlock();
                             
                                //遍历表格数据开始
                                int rowCount = (int)Math.Floor((double)tableBlock.Cells.Count / billStyle.Length);
                                for (int r = 0; r < rowCount; r++)
                                {
                                    ScanDataSet.ScanDataTableRow row = scanDataSet.ScanDataTable.NewScanDataTableRow();
                                    //添加页数 页中行号,gridview中也需添加
                                    row.PageNum = String.Format("第{0}页", Convert.ToString(pageIndex + 1));
                                   // row.PageRowNum = String.Format("第{0}行", Convert.ToString(r + 1));
                                
                                    for (int c = 0; c < billStyle.Length; c++)
                                    {
                                        IBlock textBlock = tableBlock.Cells[r * billStyle.Length + c].Block;
                                        if (textBlock.Type == BlockTypeEnum.BT_Text)
                                        {
                                            String data = this.getText(textBlock.GetAsTextBlock().Text.Paragraphs);
                                         
                                            data = Util.Util.Replace(data);
                                            String colName = billStyle[c];
                                            //按名称查询
                                            if (colName == "Name")
                                            {
                                                //  ScanDataSet.CenterDataRow centerRow = getCenterRow(data);
                                                row.OldName = data;
                                                data = Util.Util.ReplaceName(data);
                                                //获取显示名称 通过显示名称取中心编码
                                                //data = this.GetShowName(data);
                                                //取字典表scanname对应的数据 优先 
                                                Hashtable htFirst=  getItemDictRowByScanName(data);
                                                if (htFirst.Count > 0)
                                                {
                                                    ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];
                                                    row.CenterCode = centerRow.Code;
                                                    row.CenterName = centerRow.Name;
                                                    if (!centerRow.IsFormsNull())
                                                    {
                                                        row.CenterName = row.CenterName + "(" + centerRow.Forms + ")";
                                                    }


                                                    //if (!String.IsNullOrEmpty(htFirst["showname"].ToString()))
                                                    //{
                                                    //    data = htFirst["showname"].ToString();
                                                    //}

                                                    row.FeeType = centerRow.FeeType;
                                                    row.ItemType = centerRow.ItemType;
                                                    //if (Int32.Parse(htFirst["count"].ToString()) > 0)
                                                    //{
                                                    //    row.MapCount = Int32.Parse(htFirst["count"].ToString());
                                                    //}
                                                }

                                                if (row.IsCenterCodeNull())
                                                {
                                                    //取关键字like
                                                    Hashtable ht = getItemDictRowByKeyWord(data);
                                                    if (ht.Count > 0)
                                                    {
                                                        ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)ht["row"];
                                                        row.CenterCode = centerRow.Code;
                                                        row.CenterName = centerRow.Name;

                                                        if (!centerRow.IsFormsNull())
                                                        {
                                                            row.CenterName = row.CenterName + "(" + centerRow.Forms + ")";
                                                        }
                                                        //if (!String.IsNullOrEmpty(ht["showname"].ToString()))
                                                        //{
                                                        //    data = ht["showname"].ToString();
                                                        //}
                                                        row.FeeType = centerRow.FeeType;
                                                        row.ItemType = centerRow.ItemType;
                                                        //if (Int32.Parse(ht["count"].ToString()) > 0)
                                                        //{
                                                        //    row.MapCount = Int32.Parse(ht["count"].ToString());
                                                        //}
                                                    }
                                                }


                                               
                                            }
                                            //if (colName== "Quantum"|| colName == "Price" || colName == "TotalPrice")
                                            //{
                                            //    data = Util.Util.GetRegStr(data);
                                            //    data = formatPrice(data);
                                            //}
                                            if (colName == "Quantum")
                                            {
                                                row.OldQuantum = data;
                                                data = Util.Util.GetRegStr(data);
                                                data = formatPrice(data);
                                            }
                                            if (colName == "Price")
                                            {
                                                row.OldPrice = data;
                                                data = Util.Util.GetRegStr(data);
                                                data = formatPrice(data);
                                            }

                                            if (colName == "TotalPrice")
                                            {
                                                row.OldTotalPrice = data;
                                                data = Util.Util.GetRegStr(data);
                                                data = formatPrice(data);
                                            }


                                            if (row.Table.Columns.Contains(colName))
                                            { 
                                               row[colName] = data;
                                            }

                                           
                                         }
                                    }
                                try
                                {
                                    if (String.IsNullOrEmpty(row.Price))
                                    {
                                        if (!row.IsTotalPriceNull() && !row.IsQuantumNull())
                                        {
                                            row.Price = Convert.ToString(Math.Round(Convert.ToDouble(row.TotalPrice) / Convert.ToDouble(row.Quantum),4));
                                                if (row.Price.IndexOf("无穷")>-1)
                                                {
                                                    row.Price = "0";
                                                }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    showError(ex.Message);
                                }

                                    row.DetailGUID = Guid.NewGuid().ToString();

                                    //会出现空行的情况  名称为空不再保存
                                    if(!row.IsNameNull())
                                    { 
                                      scanDataSet.ScanDataTable.AddScanDataTableRow(row);
                                    }

                                }
                                //遍历表格数据结束
                                                              

                            }
                        }

                        //循环完之后 设置加载form 关闭
                        loadForm.DialogResult = DialogResult.OK;
                    }
                }
           }
            catch (Exception e)
            {
                showError(e.Message);
                loadForm.DialogResult = DialogResult.OK;
            }
            cancel = false;
        }


        private string GetShowName(string data)
        {
            DataTable dtFRcode = new Business.ItemProcess().GetShowNameByFRcodeScanName(data, this.frcode).Tables[0];
           
            if (dtFRcode.Rows.Count > 0)
            {
                data = dtFRcode.Rows[0]["showname"].ToString();
            }
            else
            {
                DataTable dt = new Business.ItemProcess().GetShowNameByScanName(data).Tables[0];
                if (dt.Rows.Count > 0)
                {
                    data = dt.Rows[0]["showname"].ToString();
                }
            }

            return data;
        }

        private String formatPrice(String data)
        {
            if (String.IsNullOrEmpty(data)) return "0";
            String result = data;
            if (SubstringCount(data, ".") > 1)
            {
                int processCount = 0;
                char[] charArray = data.ToCharArray();
                for (int i = 0; i < charArray.Length; i++)
                {

                    if (charArray[i].ToString() == ".")
                    {
                        if (processCount != SubstringCount(data, ".") - 1)
                        {
                            charArray[i] = ' ';
                            processCount += 1;
                        }



                    }
                }
                result = new String(charArray).Replace(" ", "");
               
            }

            return result;
        }

        private int SubstringCount(string str, string substring)
        {
            if (str.Contains(substring))
            {
                string strReplaced = str.Replace(substring, "");
                return (str.Length - strReplaced.Length) / substring.Length;
            }

            return 0;
        }
        private ScanDataSet.CenterDataRow getCenterRow(String data)
        {
            for (int r = 0; r < scanDataSet.CenterData.Count; r++)
            {
                ScanDataSet.CenterDataRow centerRow = scanDataSet.CenterData[r];
                if (data.IndexOf(centerRow.Name)>-1)
                {
                    return centerRow;
                }
            }
            return null;
        }


        /// <summary>
        /// 通过scanname showname 获取,加载数据的时候，两个值相等
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private Hashtable getItemDictRowByScanName(string data)
        {
            Hashtable ht = new Hashtable();
            ScanDataSet.CenterDataRow centerDataRow;
            int count = 0;
            string centercode = "";
            string firstCenterCode = "";
            string showname = "";
            DataTable dtItemDict = null;
            //改成存储过程
            DataSet ds = new Business.ItemProcess().GetItemDict(this.frcode, data);
            if (ds.Tables.Count > 0)
            {
               dtItemDict = ds.Tables[0];
                if (dtItemDict.Rows.Count > 0)
                {
                    DataRow dr = dtItemDict.Rows[0];
                    centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
                    showname = dr["showname"] == null ? "" : dr["showname"].ToString();
                    if (!String.IsNullOrEmpty(centercode))
                    {
                        if (String.IsNullOrEmpty(firstCenterCode))
                        {
                            firstCenterCode = centercode;
                        }

                    }
                }
            }
            
          


            //DataTable dtItemDictFRcode = new Business.DictProcess().GetItemDictByFRcodeScanName(data,this.frcode).Tables[0];
            //if (dtItemDictFRcode.Rows.Count > 0)
            //{

            //    DataRow dr = dtItemDictFRcode.Rows[0];

            //    centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
            //    if (!String.IsNullOrEmpty(centercode))
            //    {
            //        if (String.IsNullOrEmpty(firstCenterCode))
            //        {
            //            firstCenterCode = centercode;
            //        }

            //    }

            //}
            //else
            //{
            //    DataTable dtItemDict = new Business.DictProcess().GetItemDictByScanName(data).Tables[0];
            //    if (dtItemDict.Rows.Count > 0)
            //    {

            //        DataRow dr = dtItemDict.Rows[0];

            //        centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
            //        if (!String.IsNullOrEmpty(centercode))
            //        {
            //            if (String.IsNullOrEmpty(firstCenterCode))
            //            {
            //                firstCenterCode = centercode;
            //            }

            //        }

            //    }
            //}



            if (!String.IsNullOrEmpty(firstCenterCode))
            {
                ScanDataSet.CenterDataRow[] drCenterRow = (ScanDataSet.CenterDataRow[])scanDataSet.CenterData.Select("code='" + firstCenterCode + "'");
                if (drCenterRow.Length > 0)
                {
                    centerDataRow = drCenterRow[0];

                    ht.Add("row", centerDataRow);
                    //如果出现多个匹配项，则count+1，默认是0；》1，则有多个匹配项
                    ht.Add("count", count);
                    ht.Add("showname",showname);
                    return ht;
                }
            }

            return ht;
        }


        private Hashtable getItemDictRowByKeyWord(string data)
        {
            Hashtable ht = new Hashtable();
            ScanDataSet.CenterDataRow centerDataRow;
            int count = 0;
            string centercode = "";
            string firstCenterCode = "";
            string showname = "";
            DataTable dtItemDictFRcode = new Business.DictProcess().GetItemDictByFRcodeKeyWord(data,this.frcode).Tables[0];
            if (dtItemDictFRcode.Rows.Count > 0)
            {
                for (int i = 0; i < dtItemDictFRcode.Rows.Count; i++)
                {
                    DataRow dr = dtItemDictFRcode.Rows[i];
                    if (data.IndexOf(dr["keyword"].ToString()) > -1)
                    {
                        centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
                      
                        if (!String.IsNullOrEmpty(centercode))
                        {
                            if (String.IsNullOrEmpty(firstCenterCode))
                            {
                                firstCenterCode = centercode;
                                showname = dr["showname"] == null ? "" : dr["showname"].ToString();
                            }

                            if (!String.IsNullOrEmpty(firstCenterCode) && !centercode.Equals(firstCenterCode))
                            {

                                count += 1;


                            }

                        }
                    }
                }
            }
            else
            {
                DataTable dtItemDict = new Business.DictProcess().GetItemDictByKeyWord(data).Tables[0];
                if (dtItemDict.Rows.Count > 0)
                {
                    for (int i = 0; i < dtItemDict.Rows.Count; i++)
                    {
                        DataRow dr = dtItemDict.Rows[i];
                        if (data.IndexOf(dr["keyword"].ToString()) > -1)
                        {
                            centercode = dr["centercode"] == null ? "" : dr["centercode"].ToString();
                            if (!String.IsNullOrEmpty(centercode))
                            {
                                if (String.IsNullOrEmpty(firstCenterCode))
                                {
                                    firstCenterCode = centercode;
                                    showname = dr["showname"] == null ? "" : dr["showname"].ToString();
                                }

                                if (!String.IsNullOrEmpty(firstCenterCode) && !centercode.Equals(firstCenterCode))
                                {

                                    count += 1;


                                }

                            }
                        }
                    }
                }
            }


          

            if (!String.IsNullOrEmpty(firstCenterCode))
            {
                ScanDataSet.CenterDataRow[] drCenterRow = (ScanDataSet.CenterDataRow[])scanDataSet.CenterData.Select("code='" + firstCenterCode + "'");
                if (drCenterRow.Length > 0)
                {
                    centerDataRow = drCenterRow[0];

                    ht.Add("row", centerDataRow);
                    //如果出现多个匹配项，则count+1，默认是0；》1，则有多个匹配项
                    ht.Add("count", count);
                  //  ht.Add("showname",showname); like数据不准确  不取showname
                    return ht;
                }
            }
            
            return ht;
        }


        private String getText(Paragraphs paragraphs)
        {
            String data = "";
            for (int p = 0; p < paragraphs.Count; p++)
            {
                data += paragraphs[p].Text;
            }
            return data;
        }


        private void scan()
        {


            scanFolder = Application.StartupPath +"\\"+ this.guid;

            if (!Directory.Exists(scanFolder))
            {
                Directory.CreateDirectory(scanFolder);
            }
            
            //FREngine.ScanSources sources = scanManager.FindScanSources(ScanSourceUITypeEnum.SSUIT_All, ScanSourceApiTypeEnum.SSAT_All);
            FREngine.ScanSources sources = scanManager.FindScanSources(ScanSourceUITypeEnum.SSUIT_Scanner, ScanSourceApiTypeEnum.SSAT_Twain);
            if (sources.Count > 0)
            {
               
                FREngine.ScanSource scanSource = sources[0];
                FREngine.ScanSourceSettings settings = scanSource.ScanSettings;
                FREngine.ScanSourceCapabilities capabilities = scanSource.Capabilities;
               
                 settings.DuplexMode = capabilities.HasDuplexMode;
                settings.Resolution = 600;
              
                 settings.MultipleImagesEnabled = true;
                settings.PauseBetweenPagesMode = FREngine.ScanPauseModeEnum.SPM_PresetDelay;
                settings.Delay = 1;
                //ScanSourceUITypeEnum uiType = (ScanSourceUITypeEnum)Enum.Parse(typeof(ScanSourceUITypeEnum), "1");
                if (scanSource != null)
                {
                    //用beginscan 异步启动扫描  出现扫描界面无法弹出的情况  改为同步启动
                    scanSource.Scan(ScanSourceUITypeEnum.SSUIT_Scanner, scanFolder, this);
                }
                else
                {
                    this.showError("scanSource is null!");
                }
            }

        }
        
        private void open()
        {

            
            DialogResult result = ScanOpenFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                try
                {
                    string[] fileNames = ScanOpenFileDialog.FileNames;
                    for (int i = 0; i < fileNames.Length; i++)
                    {
                        document.AddImageFile(fileNames[i], null, null);
                    }
                    if (synchronizer.Document != null && synchronizer.Document.Pages.Count > 0)
                    {
                        synchronizer.PageIndex = 0;
                    }
                }
                catch (Exception ex)
                {
                    showError(ex.Message);
                }

            }
       
        }

        public void OnError(string sourceName, string message)
        {
            //    showError(message);
            MessageBox.Show("扫描错误:" + message);            
        }

        public void OnImageScanned(string sourceName, string path, ref bool cancel)
        {
            //   form.OnImageScanned(Path);
            MessageToolStripStatusLabel.Text = "正在扫描清单" + path + "...";
        }

        public void OnScanComplete()
        {
            string[] files=null;
            try
            {
                this.MessageToolStripStatusLabel.Text = "扫描完成,加载清单中...";

                 files = Directory.GetFiles(scanFolder);


                if (files.Length > 0)
                {
                    //如果存在文件先清空 ,不清空，则之前扫描的也追加上去，造成重复
                    this.clear();
                    for (int i = 0; i < files.Length; i++)
                    {
                        
                        document.AddImageFile(files[i], null, null);
                    }
                }

                if (synchronizer.Document != null && synchronizer.Document.Pages.Count > 0)
                {
                    synchronizer.PageIndex = 0;
                }
                this.MessageToolStripStatusLabel.Text = "扫描完成.";
            }
            catch (Exception ex)
            {
                showError(ex.Message+"文件路径:"+ scanFolder.ToString()+";文件长度:" + files.Length);
            }
        }







        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                document = null;
                synchronizer = null;
                engineLoader.Dispose();
                engineLoader = null;
                scanManager = null;
            }
            catch (Exception ex)
            {

                //保存关闭原因 有程序突然消失的情况
                System.IO.FileInfo fileinfo = new System.IO.FileInfo(Application.StartupPath + "\\" + "log4net.config");

                log4net.Config.XmlConfigurator.Configure(fileinfo);
                log4net.ILog log = log4net.LogManager.GetLogger("FileLogger_waizhen");
                log.Info("程序关闭原因:" + e.CloseReason.ToString()+"$异常关闭信息:"+ex.ToString());
            }
           
        }

        private void OpenToolStripButton_Click(object sender, EventArgs e)
        {
            this.open();
        }

        private void showError(String errorMessage)
        {
            MessageToolStripStatusLabel.Text = errorMessage;

        }

    

        private void ScanTimer_Tick(object sender, EventArgs e)
        {
            ScanTimer.Enabled = false;
            //SplashForm splashForm = new SplashForm();
            //splashForm.Show();


            //开启子线程弹出正在处理form 初始化之后之后关闭加载框
            MyProgressWait = new Thread(ProgressBarWait);
            MyProgressWait.Start();
         

            try
            {
                this.init();
            }
            catch (Exception ex)
            {
                this.loadForm.DialogResult = DialogResult.OK;
                throw ex;
            }
            finally
            {
                this.loadForm.DialogResult = DialogResult.OK;
            }

            

            //splashForm.Close();
           
            

        }

        private void ScanToolBar_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ScanDocumentViewer_OnLongOperationFinished(object sender, EventArgs e)
        {
         //   MessageBox.Show("ScanDocumentViewer_OnLongOperationFinished")
        
        }

       

        private void ScanDocumentViewer_OnDocumentChanged(object sender, AxFineReaderVisualComponents.DIDocumentViewerEvents_OnDocumentChangedEvent e)
        {
            //  MessageBox.Show("ScanDocumentViewer_OnDocumentChanged");
           
        }

        private void ScanImageViewer_OnReadPage(object sender, AxFineReaderVisualComponents.DIImageViewerEvents_OnReadPageEvent e)
        {
            isRead = true;
        }

        private void MessageToolStripStatusLabel_Click(object sender, EventArgs e)
        {

        }

        private void AddToolStripButton_Click(object sender, EventArgs e)
        {
           DialogResult result=new AddForm().ShowDialog(this);
           if (result == DialogResult.OK)
           {
               this.clear();
           }
        }


       

        private void save()
        {


            try
            {
                //根据guid获取记录,guid由登记主信息之后，传过来的
                DataSet dsZyjl = new Business.MainList().GetZyjlByGuid(guid);
                if (dsZyjl.Tables[0].Rows.Count < 1)
                {
                    this.TopMost = true;
                    MessageBox.Show("请先登记再保存！");
                }
                //应为从datagridview 中获取
                if (dsZyjl.Tables[0].Rows.Count > 0)
                {
                    //  DataTable dt = (DataTable)this.ScanDataGridView.DataSource;
                    bool result = true;
                    //获取保存在dataset中的数据
                    if (scanDataSet.ScanDataTable.Rows.Count > 0)
                    {
                        for (int i = 0; i < scanDataSet.ScanDataTable.Rows.Count; i++)
                        {

                         


                            Hashtable ht = new Hashtable();
                            ht.Add("pid", dsZyjl.Tables[0].Rows[0]["id"].ToString());

                          
                           

                            string code = scanDataSet.ScanDataTable.Rows[i]["code"] == null ? "" : scanDataSet.ScanDataTable.Rows[i]["code"].ToString();

                            if (String.IsNullOrEmpty(code))
                            {
                                code = i.ToString();
                            }

                          

                            string name = scanDataSet.ScanDataTable.Rows[i]["name"].ToString();
                            if (String.IsNullOrEmpty(name))
                            {
                                MessageBox.Show("项目名称不能为空!");
                            }
                            string spec = scanDataSet.ScanDataTable.Rows[i]["spec"] == null ? "" : scanDataSet.ScanDataTable.Rows[i]["spec"].ToString();
                            string unit = scanDataSet.ScanDataTable.Rows[i]["unit"] == null ? "" : scanDataSet.ScanDataTable.Rows[i]["unit"].ToString();
                            string quantum = scanDataSet.ScanDataTable.Rows[i]["quantum"].ToString();
                            string price = scanDataSet.ScanDataTable.Rows[i]["price"].ToString();
                            string totalprice = scanDataSet.ScanDataTable.Rows[i]["totalprice"].ToString();
                            // string paydate = scanDataSet.ScanDataTable.Rows[i]["paydate"] == null ? System.DateTime.Now.ToShortDateString() : scanDataSet.ScanDataTable.Rows[i]["paydate"].ToString();
                            string centercode = scanDataSet.ScanDataTable.Rows[i]["centercode"].ToString();
                            string centername = scanDataSet.ScanDataTable.Rows[i]["centername"].ToString();
                            string feetype = scanDataSet.ScanDataTable.Rows[i]["feetype"].ToString();
                            string itemtype = scanDataSet.ScanDataTable.Rows[i]["itemtype"].ToString();

                    

                            ht.Add("code", code.Replace(",", ".").Replace(" ", "").Replace("、", "."));
                            ht.Add("name", name.Replace(",", ".").Replace(" ", "").Replace("、", "."));
                            ht.Add("spec", spec);
                            ht.Add("unit", unit);
                            ht.Add("quantum", quantum);
                            ht.Add("price", price);
                            ht.Add("totalprice", totalprice);
                            ht.Add("paydate", System.DateTime.Now.ToShortDateString());
                            ht.Add("centercode", centercode);
                            ht.Add("centername", centername);
                            ht.Add("feetype", feetype);
                            ht.Add("itemtype", itemtype);
                            result = new Business.MainList().InsertFymx(ht);

                        }
                    }
                    else
                    {
                        this.TopMost = true;

                        MessageBox.Show("上传明细为空!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }

                    if (result)
                    {

                        this.TopMost = false;

                        MessageBox.Show("保存成功!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


                    }
                    else
                    {

                        this.TopMost = true;

                        MessageBox.Show("保存失败!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
            }
            catch (Exception ex)
            {

                showError(ex.ToString());
            }



        }

        //出现 空引用的异常  需 分析
        private void saveAndUpdate()
        {



            try
            {
                //根据guid获取记录,guid由登记主信息之后，传过来的
                DataSet dsZyjl = new Business.MainList().GetZyjlByGuid(guid);
                if (dsZyjl.Tables.Count>0 && dsZyjl.Tables[0].Rows.Count < 1)
                {
                    this.TopMost = true;
                    MessageBox.Show("请先登记再保存！");
                    return;
                }
                //应为从datagridview 中获取
                if (dsZyjl.Tables[0].Rows.Count > 0)
                {
            


                    bool result = true;
                    int rowcount = scanDataSet.ScanDataTable.Rows.Count;
                    //获取保存在dataset中的数据
                    if (scanDataSet.ScanDataTable.Rows.Count > 1)
                    {
                        //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
                        this.ScanDataGridView.EndEdit();

                        ((IEditableObject)this.ScanDataGridView.CurrentRow.DataBoundItem).EndEdit();
                        this.ScanDataGridView.CurrentCell = null;
                        Application.DoEvents();

                        for (int i = 0; i < scanDataSet.ScanDataTable.Rows.Count; i++)
                        {
                            //如果名称为空 不再保存 
                            string itemname = scanDataSet.ScanDataTable.Rows[i]["name"] == null ? "" : scanDataSet.ScanDataTable.Rows[i]["name"].ToString();
                            if (String.IsNullOrEmpty(itemname))
                                scanDataSet.ScanDataTable.Rows.RemoveAt(i);

                            scanDataSet.ScanDataTable.Rows[i]["pid"] = dsZyjl.Tables[0].Rows[0]["id"].ToString();
                            scanDataSet.ScanDataTable.Rows[i]["paydate"] = System.DateTime.Now.ToShortDateString();
                            string code = scanDataSet.ScanDataTable.Rows[i]["code"] == null ? i.ToString() : scanDataSet.ScanDataTable.Rows[i]["code"].ToString();
                            if (String.IsNullOrEmpty(code))
                            {
                                scanDataSet.ScanDataTable.Rows[i]["code"] = i.ToString();
                            }
                            
                            string detailGUID= scanDataSet.ScanDataTable.Rows[i]["DetailGUID"] == null ? Guid.NewGuid().ToString() : scanDataSet.ScanDataTable.Rows[i]["DetailGUID"].ToString();
                            if (String.IsNullOrEmpty(detailGUID))
                            {
                                scanDataSet.ScanDataTable.Rows[i]["DetailGUID"] = Guid.NewGuid().ToString();
                            }
                           string centercode= scanDataSet.ScanDataTable.Rows[i]["centercode"] == null ? i.ToString() : scanDataSet.ScanDataTable.Rows[i]["centercode"].ToString();
                            string centername = "";
                            DataTable dtname = new Business.DictProcess().GetItemByID(centercode).Tables[0];
                            if (dtname.Rows.Count > 0)
                            {
                                centername = dtname.Rows[0]["name"].ToString();
                            }

                            scanDataSet.ScanDataTable.Rows[i]["centername"] = centername;
                        }



                        new Business.ItemProcess().SaveAndUpdateDetail(scanDataSet.ScanDataTable);
                    }
                    else
                    {
                        this.TopMost = true;

                        MessageBox.Show("要保存的数据为空!", "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }

                    if (result)
                    {

                        this.TopMost = true;

                        MessageBox.Show("保存成功!保存的条数:"+ rowcount.ToString(), "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


                    }
                    else
                    {

                        this.TopMost = true;

                        MessageBox.Show("保存失败!rowcount:" + rowcount.ToString(), "保存提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                    }
                }
            }
            catch (Exception ex)
            {

                showError(ex.ToString());
            }



        }


        private void upload()
        {
            
                //获取数据记录再拼包
                //根据guid获取记录,guid由登记主信息之后，传过来的

                DataSet dsZyjl = new Business.MainList().GetZyjlByGuid(guid);
                if (dsZyjl.Tables[0].Rows.Count < 1)
                {
                    MessageBox.Show("请先登记再上传！");
                    return;
                }
               

            DataRow dr = dsZyjl.Tables[0].Rows[0];

            string result = "";
            try
            {
                result = new Business.MainList().UploadZyjl(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show("上传失败!==>" + ex.ToString(), "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                return;
            }

            /*
            <?xml version="1.0" encoding="UTF-8"?><businessdata><functioncode>200222</functioncode><state>0</state><result/><remark1/><remark2/><remark3/><remark4/><remark5/></businessdata>
            */
            this.TopMost = false;
            if (!String.IsNullOrEmpty(result))
            {
                try
                {
                    XmlDocument xdResult = new XmlDocument();
                    xdResult.LoadXml(result);
                    XmlElement rootResult = xdResult.DocumentElement;
                    string state = rootResult.SelectSingleNode("state").InnerText;


                    if (state.Equals("0"))
                    {
                        bool result1 = new Business.MainList().UpdateUploadZyjlById(dr["id"].ToString());
                        bool result2 = new Business.MainList().UpdateUploadFymxByPId(dr["id"].ToString());
                        if (result1 && result2)
                        {
                            MessageBox.Show("上传成功!", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }
                        else
                        {
                            MessageBox.Show("上传成功!更新上传标识异常！", "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
                        }

                    }
                    else
                    {
                        MessageBox.Show("上传失败!==>" + rootResult.SelectSingleNode("result").InnerText, "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

                    }
                }
                catch (Exception ex)
                {
                    this.showError("上传异常:"+ex.ToString());
                }
            }
            else
            {
                MessageBox.Show("上传失败!==>上传返回结果为空！" , "上传提示", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            }
              

           

          

        }

        private DataGridViewTextBoxEditingControl EditingControl = null;
        private void ScanDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            try
            {
                if (e.Control is DataGridViewTextBoxEditingControl && this.ScanDataGridView.Columns[this.ScanDataGridView.CurrentCell.ColumnIndex].Name == "CenterName")
                {

                    EditingControl = (DataGridViewTextBoxEditingControl)e.Control;

                    EditingControl.TextChanged -= new EventHandler(EditingControl_Event);
                    EditingControl.TextChanged += new EventHandler(EditingControl_Event);
                    //先-= 防止出现多次注册 
                    EditingControl.PreviewKeyDown -= new PreviewKeyDownEventHandler(EditingControl_PreKeyDown);


                    EditingControl.PreviewKeyDown += new PreviewKeyDownEventHandler(EditingControl_PreKeyDown);
                }
            }
            catch (Exception ex)
            {
                this.showError("中心项目编辑事件注册:"+ex.ToString());
            }

        }

        private void EditingControl_Event(object sender, EventArgs e)
        {


            try
            {
                if (this.ScanDataGridView.CurrentCell.ColumnIndex == this.ScanDataGridView.Columns["centername"].Index && !String.IsNullOrEmpty(((TextBox)sender).Text.Trim()))
                {

                    this.itemSearch1.SearchType = "Item";
                    this.itemSearch1.SearchText = ((TextBox)sender).Text;
                    this.itemSearch1.ControlId = this.ScanDataGridView.CurrentRow.Index.ToString();//传入行索引
                    this.itemSearch1.GetSearchData();

                    if (itemSearch1.Visible == false)
                    {
                        int columnIndex = ScanDataGridView.CurrentCell.ColumnIndex;
                        int rowIndex = ScanDataGridView.CurrentCell.RowIndex;
                        int dgvX = ScanDataGridView.Location.X;
                        int dgvY = ScanDataGridView.Location.Y;

                        int cellX = ScanDataGridView.GetCellDisplayRectangle(columnIndex - 1, rowIndex, false).X;
                        int cellY = ScanDataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Y;
                        int cellHeight = ScanDataGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Height;

                        //行在下方，弹出框在上方显示
                        if (this.ScanDataGridView.Height - cellY < itemSearch1.Height)
                        {
                            itemSearch1.Location = new System.Drawing.Point(dgvX + cellX, dgvY + cellY - this.itemSearch1.Height);
                        }
                        else
                        {
                            itemSearch1.Location = new System.Drawing.Point(dgvX + cellX, dgvY + cellY + cellHeight);
                        }


                        itemSearch1.Visible = true;

                    }


                }

                if (this.ScanDataGridView.CurrentCell.ColumnIndex == this.ScanDataGridView.Columns["centername"].Index && String.IsNullOrEmpty(((TextBox)sender).Text.Trim()) && itemSearch1.Visible)
                {
                    itemSearch1.Visible = false;
                }
            }
            catch (Exception ex)
            {
                this.showError("中心项目弹出事件："+ex.ToString());
            }


        }



        private void EditingControl_PreKeyDown(object sender,PreviewKeyDownEventArgs e)
        {

            try
            {
                if ((e.KeyCode == Keys.Enter || e.KeyCode == Keys.Up || e.KeyCode == Keys.Down) && itemSearch1.Visible == true)
                {

                    DataGridView ctl = ((DataGridView)this.itemSearch1.Controls["dataGridView1"]);
                    int rowCount = ctl.Rows.Count;
                    if (e.KeyCode == Keys.Down)
                    {
                        int rowindex = ctl.SelectedRows[0].Index;
                        if (!(rowindex == rowCount - 1))
                        {
                            ctl.Rows[rowindex + 1].Selected = true;
                        }
                        else
                        {
                            ctl.Rows[rowindex].Selected = true;
                            
                        }
                        ctl.FirstDisplayedScrollingRowIndex = rowindex;
                    }

                    if (e.KeyCode == Keys.Up)
                    {
                        int rowindex = ctl.SelectedRows[0].Index;
                        if (rowindex == 0)
                        {
                            ctl.Rows[rowindex].Selected = true;
                        }
                        else
                        {
                            ctl.Rows[rowindex - 1].Selected = true;
                        }
                        ctl.FirstDisplayedScrollingRowIndex = rowindex;

                    }

                    //this.itemSearch1.ParentFormPreKeyDownToChild(sender, e);
                    if (e.KeyCode == Keys.Enter)
                    {
                        this.itemSearch1.SetParentView();
                    }
                }

            }
            catch (Exception ex)
            {

                showError(ex.ToString());
            }


        }

        /// <summary>
        /// 重写父类处理按键事件  datagridview
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Down || keyData == Keys.Up )　　//监听回车事件　
            {
                if (this.ScanDataGridView.CurrentCell!=null&&this.ScanDataGridView.CurrentCell.OwningColumn.Name == "CenterName" && this.ScanDataGridView.IsCurrentCellInEditMode)　　//如果当前单元格处于编辑模式　
                {

                    return true;

                }

            }
            if (keyData == Keys.Enter)
            {
                System.Windows.Forms.SendKeys.Send("{TAB}");
                return true;
            }
                    //继续原来base.ProcessCmdKey中的处理　
                    return base.ProcessCmdKey(ref msg, keyData);
        }



      


        private void ScanDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           if(this.ScanDataGridView.Columns[e.ColumnIndex].Name=="CenterName")
            {
                this.clearGridView();
               
            }
        }

      

        private void updatePanel(string count, string totalPrice)
        {
            this.label1.Text = count;
            this.label2.Text = totalPrice;
            this.splitContainer3.Panel2.Update();
        }

        private void ScanImageViewer_OnActivePageChanged(object sender, AxFineReaderVisualComponents.DIImageViewerEvents_OnActivePageChangedEvent e)
        {
             ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_DrawTableBlock, true);

            //this.scanDataSet.ScanDataTable.EndLoadData();
           // this.scanDataSet.ScanDataTable.
            //this.Update();
           
        }

        
    

        private void ScanDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //单价 数量单元格发生变化  更新总金额
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "priceDataGridViewTextBoxColumn" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "Quantum" || this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalPriceDataGridViewTextBoxColumn")
            {
                try
                {
                    double price = Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value.ToString());
                    double quantum = Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["Quantum"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["Quantum"].Value.ToString());

                    double totalPrice= Convert.ToDouble(this.ScanDataGridView.Rows[e.RowIndex].Cells["totalPriceDataGridViewTextBoxColumn"].Value == DBNull.Value ? "0" : this.ScanDataGridView.Rows[e.RowIndex].Cells["totalPriceDataGridViewTextBoxColumn"].Value.ToString());

                    ////单价为空
                    //if (((System.Collections.IList)billStyle).Contains("Price"))
                    //{

                    //}
                    //else//   单价不为空 billStyle
                    //{

                    //}

                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "priceDataGridViewTextBoxColumn")
                    {
                        if(price!=0&&price.ToString().IndexOf("无穷")==-1)
                        { 
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["totalPriceDataGridViewTextBoxColumn"].Value = Math.Round(price * quantum, 2);
                        }
                    }

                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "Quantum" )
                    {
                        if (price != 0&& price.ToString().IndexOf("无穷")==-1)
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["totalPriceDataGridViewTextBoxColumn"].Value = Math.Round(price * quantum, 2);
                        }
                        else
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value = Math.Round(totalPrice/ quantum,4);
                        }

                        
                    }

                    if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalPriceDataGridViewTextBoxColumn")
                    {
                        if ((price == 0 || price.ToString().IndexOf("无穷") > -1))
                        {
                            this.ScanDataGridView.Rows[e.RowIndex].Cells["priceDataGridViewTextBoxColumn"].Value = Math.Round(totalPrice / quantum, 4);
                        }
                       


                    }










                }
                catch (Exception ex)
                {

                    showError("计算总金额:" + ex.ToString());
                }
            }

            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "totalPriceDataGridViewTextBoxColumn" )
            {
                this.ScanDataGridView.EndEdit();
                ((IEditableObject)this.ScanDataGridView.CurrentRow.DataBoundItem).EndEdit();

                int count = scanDataSet.ScanDataTable.Count;
                Double totalPrice = 0;
                for (int r = 0; r < scanDataSet.ScanDataTable.Count; r++)
                {
                    ScanDataSet.ScanDataTableRow centerRow = scanDataSet.ScanDataTable[r];
                    if (!centerRow.IsTotalPriceNull())
                    {
                        try
                        {
                            totalPrice += Convert.ToDouble(centerRow.TotalPrice);
                        }
                        catch (Exception ex)
                        {
                            showError(ex.Message);
                        }
                    }
                }



                //  totalPriceLabel.Text = "总金额:" + "11" + totalPrice.ToString("F2");
                updatePanel("总条数:" + count.ToString(), "总金额:" + totalPrice.ToString("F2"));
            }

            

        }



        private void ScanToolStripSplitButton_Click(object sender, EventArgs e)
        {
            
                this.MessageToolStripStatusLabel.Text = "正在扫描，请稍候...";
            try
            {
                this.scan();
            }
            catch (Exception)
            {
                MessageBox.Show("扫描仪连接中断！请稍后再试！");
            }
           
          
        }
        



        /// <summary>
        /// 获取单元格（名称）编辑之前的数据 用于存储项目字典
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanDataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            //if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "nameDataGridViewTextBoxColumn")
            //{
            //    this.beginName = this.ScanDataGridView.CurrentCell.Value.ToString();
            //    ////初始化值一样
            //    //this.endName = this.beginName;

            //    //赋值给原始值
            //   // this.ScanDataGridView.CurrentRow.Cells["oldName"].Value = this.beginName;
            //}
        }

        /// <summary>
        /// 获取单元格（名称）编辑之后的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "nameDataGridViewTextBoxColumn")
            {
                this.endName = this.ScanDataGridView.CurrentCell.Value == null ? "" : this.ScanDataGridView.CurrentCell.Value.ToString();
                this.beginName = this.ScanDataGridView.CurrentRow.Cells["oldName"].Value == null ? "" : this.ScanDataGridView.CurrentRow.Cells["oldName"].Value.ToString();


                //编辑项目名称之后  再次获取对照关系 
                Hashtable htFirst = getItemDictRowByScanName(this.endName);
                if (htFirst.Count > 0)
                {
                    ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value = centerRow.Code;
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterName"].Value = centerRow.Name;
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["ItemType"].Value = centerRow.ItemType;
                    this.ScanDataGridView.Rows[e.RowIndex].Cells["FeeType"].Value = centerRow.FeeType;

                    //if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                    //{
                    //    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, centerRow.Code, frcode);

                    //}
                   

                }
                else
                {
                    Hashtable ht = getItemDictRowByKeyWord(this.endName);
                    if (ht.Count > 0)
                    {
                        ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)ht["row"];
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value = centerRow.Code;
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterName"].Value = centerRow.Name;
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["ItemType"].Value = centerRow.ItemType;
                        this.ScanDataGridView.Rows[e.RowIndex].Cells["FeeType"].Value = centerRow.FeeType;
                        //if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                        //{
                        //    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, centerRow.Code, frcode);

                    }

                }




                string newCentercode = this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value == null ? "" : this.ScanDataGridView.Rows[e.RowIndex].Cells["CenterCode"].Value.ToString();
                //if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName) && String.IsNullOrEmpty(newCentercode))//没有取到对照关系也保存一份，
                //{
                //    if (!String.IsNullOrEmpty(this.beginName) && !String.IsNullOrEmpty(this.endName))
                //    {
                //        new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, "", frcode);
                //    }

                //}


                //中心编码不为空  更新对照关系
                if (!String.IsNullOrEmpty(this.beginName.Trim()) && !String.IsNullOrEmpty(this.endName.Trim()) && !String.IsNullOrEmpty(newCentercode))
                {
                    new Business.ItemProcess().UpdateItemDictRelation(this.beginName, this.endName, newCentercode, frcode);

                }



              
            }

            //删除中心名称 清空中心编码 
            if (this.ScanDataGridView.Columns[e.ColumnIndex].Name == "CenterName")
            {
                if (this.ScanDataGridView.CurrentCell.Value == DBNull.Value)
                {
                    this.ScanDataGridView.CurrentRow.Cells["centercode"].Value = null;
                }
            }

        }





        public void setBillStyle(String[] styles)
        {
            this.billStyle = styles;
            this.GetStyleName();
            

            if (this.Text.IndexOf("当前清单") > -1)
            {
            
                string replaceStr = this.Text.Substring(this.Text.IndexOf("当前清单格式"), this.Text.Length- this.Text.IndexOf("当前清单格式"));
                this.Text = this.Text.Replace(replaceStr, "       当前清单格式:" + String.Join("|", this.billStyleName));
            }
            else
            {
                this.Text += "       当前清单格式:" + String.Join("|",this.billStyleName);
            }

        }

        private void styleToolStripButton_Click(object sender, EventArgs e)
        {
            new SelectStyleForm().ShowDialog(this);
        }

       

       


       

       


     
        public void UpdateItemDictRelation(string oldName,string newName,string centercode)
        {
            
                new Business.ItemProcess().UpdateItemDictRelation(oldName, newName, centercode,frcode);
            //更新完对照关系  自动更新为空部分  太慢  去掉  可以开启子线程执行 测试下效率
           // this.maptoolStripButto_Click(null,null);
        }

        private void pointerToolStripButton_ButtonClick(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_SelectObject, true);
        }

      

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_BlockType_Text, true);
        }

        private void clearToolStripButton_Click(object sender, EventArgs e)
        {
            this.scanDataSet.ScanDataTable.Clear();
            //this.ScanDataGridView.DataSource = null;
            clearGridView();

            this.label1.Text="总条数:";
            this.label2.Text = "总金额:";
        }

        private void clearGridView()
        {
            if (this.itemSearch1.Visible == true)
            {
                this.itemSearch1.Visible = false;
               
            }
        }



        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            //开启子线程弹出正在处理form 初始化之后之后关闭加载框
            MyProgressWait = new Thread(ProgressBarWait);
            MyProgressWait.Start();

            try
            {
                clearGridView();
                this.saveAndUpdate();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                loadForm.DialogResult = DialogResult.OK;
            }
        }

        private void uploadToolStripButton_Click(object sender, EventArgs e)
        {
            //开启子线程弹出正在处理form 初始化之后之后关闭加载框
            MyProgressWait = new Thread(ProgressBarWait);
            MyProgressWait.Start();
            try
            {
                clearGridView();
                this.upload();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                this.loadForm.DialogResult = DialogResult.OK;
            }
        }

        private void readToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_Read, true);
            
        }

        private void analyzeToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_AnalyzeLayout, true);
        }

        private void horizontalToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_AddHorizSeparator, true);
        }

        private void verticalToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_AddVertSeparator, true);
        }

        private void delToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_DeleteBlock, true);
           

        }

      

        private void arrorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_SelectObject, true);
        }

        private void tableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_BlockType_Table, true);
        }

        private void arrorToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_SelectObject, true);
            
        }


        //出现不能通过已删除的行访问该行的信息  异常  需要分析   
        private void ScanDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < this.scanDataSet.ScanDataTable.Rows.Count&& this.scanDataSet.ScanDataTable.Rows[e.RowIndex].RowState != DataRowState.Detached)
            {
                try
                {
                    DataGridViewRow dr = this.ScanDataGridView.Rows[e.RowIndex];


                    // string mapCount = scanDataSet.ScanDataTable.Rows[e.RowIndex]["MapCount"] == DBNull.Value ? "0" : scanDataSet.ScanDataTable.Rows[e.RowIndex]["MapCount"].ToString();
                    string centerName = "";
                    if (this.scanDataSet.ScanDataTable.Rows[e.RowIndex].RowState != DataRowState.Detached)
                    {
                        centerName= scanDataSet.ScanDataTable.Rows[e.RowIndex]["CenterName"] == null ? "" : scanDataSet.ScanDataTable.Rows[e.RowIndex]["CenterName"].ToString();
                    }
                    

                    if (e.ColumnIndex == 0)
                    {
                        e.Value = e.RowIndex + 1;
                    }



                    if (String.IsNullOrEmpty(centerName))
                    {
                        if (dr.Cells["CenterName"].ColumnIndex == e.ColumnIndex)
                        {
                            dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                        }
                    }
                    
                    //扫描出的单位含有支、瓶、盒 且中心编码不为空  且项目类型不为 药品的
                    string unit = "";
                    if (this.scanDataSet.ScanDataTable.Rows[e.RowIndex].RowState != DataRowState.Detached)
                    {
                        unit = dr.Cells["unitDataGridViewTextBoxColumn"].Value==null?"": dr.Cells["unitDataGridViewTextBoxColumn"].Value.ToString();
                        string itemtype = dr.Cells["itemtype"].Value==null?"": dr.Cells["itemtype"].Value.ToString();
                        string hisname = dr.Cells["nameDataGridViewTextBoxColumn"].Value==null?"": dr.Cells["nameDataGridViewTextBoxColumn"].Value.ToString();



                        if (!String.IsNullOrEmpty(unit) && !String.IsNullOrEmpty(centerName)&&!String.IsNullOrEmpty(hisname))
                        {

                            if ((unit.IndexOf("支") != -1 || unit.IndexOf("瓶") != -1 || unit.IndexOf("盒") != -1 || unit.IndexOf("袋") != -1 || unit.IndexOf("片") != -1) && itemtype.Equals("1"))
                            {
                                dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                            }
                            if ((unit.IndexOf("次") != -1 ) && itemtype.Equals("0"))
                            {
                                dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                            }

                        }

                        if (String.IsNullOrEmpty(unit) && !String.IsNullOrEmpty(centerName) && !String.IsNullOrEmpty(hisname))
                        {

                            if ((hisname.IndexOf("支") != -1 || hisname.IndexOf("液") != -1 || hisname.IndexOf("袋") != -1 || hisname.IndexOf("瓶") != -1 || hisname.IndexOf("盒") != -1 || hisname.IndexOf("片") != -1) && itemtype.Equals("1"))
                            {
                                dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                            }

                           
                        }

                        if ((hisname.IndexOf("测定") != -1 || hisname.IndexOf("检查") != -1 || hisname.IndexOf("化学") != -1 || hisname.IndexOf("一次性") != -1) && itemtype.Equals("0"))
                        {
                            dr.Cells["CenterName"].Style.BackColor = Color.LightCoral;
                        }


                    }




                    //原始值与处理之后的值不一样
                    string nowQuantum = dr.Cells["Quantum"].Value == null ? "0" : dr.Cells["Quantum"].Value.ToString();
                    string OldQuantum = dr.Cells["OldQuantum"].Value == null ? "0" : dr.Cells["OldQuantum"].Value.ToString();
                    string nowPrice = dr.Cells["priceDataGridViewTextBoxColumn"].Value == null ? "0" : dr.Cells["priceDataGridViewTextBoxColumn"].Value.ToString();
                    string OldPrice = dr.Cells["OldPrice"].Value == null ? "0" : dr.Cells["OldPrice"].Value.ToString();
                    string nowTotalPrice = dr.Cells["totalPriceDataGridViewTextBoxColumn"].Value == null ? "0" : dr.Cells["totalPriceDataGridViewTextBoxColumn"].Value.ToString();
                    string OldTotalPrice = dr.Cells["OldTotalPrice"].Value == null ? "0" : dr.Cells["OldTotalPrice"].Value.ToString();


                    if (nowQuantum != OldQuantum)
                    {
                        dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                    }
                    if (nowPrice != OldPrice)
                    {
                        dr.Cells["priceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    }
                    if (nowTotalPrice != OldTotalPrice)
                    {
                        dr.Cells["totalPriceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    }

                    //值不为数值处理
                    double d_quantum = 0;
                    double d_price = 0;
                    double d_totalprice = 0;
                    if (!Double.TryParse(nowQuantum, out d_quantum))
                    {
                        dr.Cells["Quantum"].Value = 0;
                        dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                    }

                    if (!Double.TryParse(nowPrice, out d_price))
                    {
                        dr.Cells["priceDataGridViewTextBoxColumn"].Value = 0;
                        dr.Cells["priceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    }

                    if (!Double.TryParse(nowTotalPrice, out d_totalprice))
                    {
                        dr.Cells["totalPriceDataGridViewTextBoxColumn"].Value = 0;
                        dr.Cells["totalPriceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    }


                    //校验三个值关系
                    if (Math.Round(d_quantum * d_price,2) != d_totalprice)
                    {
                        dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                        dr.Cells["priceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                        dr.Cells["totalPriceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    }


                    //值为空  or 0 标红  改为上述方法判断   

                    //if (dr.Cells["Quantum"].Value == null || dr.Cells["Quantum"].Value.ToString() == "0")
                    //{
                    //    dr.Cells["Quantum"].Style.BackColor = Color.LightCoral;
                    //}
                    //if (dr.Cells["priceDataGridViewTextBoxColumn"].Value == null || dr.Cells["priceDataGridViewTextBoxColumn"].Value.ToString() == "0")
                    //{
                    //    dr.Cells["priceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    //}
                    //if (dr.Cells["totalPriceDataGridViewTextBoxColumn"].Value == null || dr.Cells["totalPriceDataGridViewTextBoxColumn"].Value.ToString() == "0")
                    //{
                    //    dr.Cells["totalPriceDataGridViewTextBoxColumn"].Style.BackColor = Color.LightCoral;
                    //}









                    //计算总金额
                    int count = scanDataSet.ScanDataTable.Count;
                    Double totalPrice = 0;
                    for (int r = 0; r < scanDataSet.ScanDataTable.Count; r++)
                    {
                        ScanDataSet.ScanDataTableRow centerRow = scanDataSet.ScanDataTable[r];
                        if (centerRow.RowState != DataRowState.Detached && !centerRow.IsTotalPriceNull())
                           
                        {
                            try
                            {
                                totalPrice += Convert.ToDouble(centerRow.TotalPrice);
                            }
                            catch (Exception ex)
                            {
                                showError("计算金额:"+ex.Message);
                            }
                        }
                    }

                    updatePanel("总条数:" + count.ToString(), "总金额:" + totalPrice.ToString("F2"));
                }
                catch (Exception ex)
                {
                   
                    this.showError("格式化单元格:" + ex.ToString());
                }
            }
        }


        private void GetTotalInfo()
        {
            int count = scanDataSet.ScanDataTable.Count;
            Double totalPrice = 0;
            for (int r = 0; r < scanDataSet.ScanDataTable.Count; r++)
            {
                ScanDataSet.ScanDataTableRow centerRow = scanDataSet.ScanDataTable[r];
                if (!centerRow.IsTotalPriceNull())
                {
                    try
                    {
                        totalPrice += Convert.ToDouble(centerRow.TotalPrice);
                    }
                    catch (Exception ex)
                    {
                        showError(ex.Message);
                    }
                }
            }

            updatePanel("总条数:" + count.ToString(), "总金额:" + totalPrice.ToString("F2"));
        }

      

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_DrawTableBlock, true);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.MessageToolStripStatusLabel.Text = "外诊扫描录入系统";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //开启子线程弹出正在处理form 识别完项目之后关闭加载框
            MyProgressWait = new Thread(ProgressBarWait);
            MyProgressWait.Start();
            try
            {
                new Thread(recogniseFile).Start();
            }
            catch (Exception ex)
            {
                this.showError(ex.ToString());
                loadForm.DialogResult = DialogResult.OK;
            }
        }

        private void recogniseFile()
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_Read, true);
        }

        private void tablestyletoolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_BlockType_Table, true);
        }

        private void drawtabletoolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_DrawTableBlock, true);
        }

        private void maptoolStripButto_Click(object sender, EventArgs e)
        {
            ScanDataSet.ScanDataTableRow[] scanDataTableRows = (ScanDataSet.ScanDataTableRow[])scanDataSet.ScanDataTable.Select("centercode is null or centercode =''");
            if (scanDataTableRows.Length > 0)
            {
                foreach (ScanDataSet.ScanDataTableRow row in scanDataTableRows)
                {
                    string name = row.Name;
                    Hashtable htFirst= getItemDictRowByScanName(name);
                    if (htFirst.Count > 0)
                    {
                        ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)htFirst["row"];
                        row.CenterCode = centerRow.Code;
                        row.CenterName = centerRow.Name;
                        if (!centerRow.IsFormsNull())
                        {
                            row.CenterName = row.CenterName + "(" + centerRow.Forms + ")";
                        }


                        row.FeeType = centerRow.FeeType;
                        row.ItemType = centerRow.ItemType;
                      
                    }

                    if (row.IsCenterCodeNull())
                    {
                        //取关键字like
                        Hashtable ht = getItemDictRowByKeyWord(name);
                        if (ht.Count > 0)
                        {
                            ScanDataSet.CenterDataRow centerRow = (ScanDataSet.CenterDataRow)ht["row"];
                            row.CenterCode = centerRow.Code;
                            row.CenterName = centerRow.Name;
                            row.FeeType = centerRow.FeeType;
                            row.ItemType = centerRow.ItemType;
                            
                        }
                    }

                }
            }

        }

        private void alterToolStripButton_Click(object sender, EventArgs e)
        {
            MainInfoList mainInfoList = new MainInfoList();
            mainInfoList.Owner = this;
            mainInfoList.ShowDialog();
        }
        
        private void ScanDocumentViewer_OnActivePageChanged(object sender, AxFineReaderVisualComponents.DIDocumentViewerEvents_OnActivePageChangedEvent e)
        {
           // this.pageIndex = synchronizer.PageIndex;
        }

        private void ScanDocumentViewer_OnDeletePages(object sender, AxFineReaderVisualComponents.DIDocumentViewerEvents_OnDeletePagesEvent e)
        {
          
        }



        private void MapToolStripButton_Click(object sender, EventArgs e)
        {
          
            //判断选中几行
            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {
               
                if (this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].EditedFormattedValue.ToString() == "True")
                {
                    //获取comboxvalue
                    if (this.DictToolStripComboBox.SelectedItem.ToString() != "请选择")
                    {
                        ScanDataSet.CenterDataRow centerDataRow;
                        string centercodet = this.dictHT[this.DictToolStripComboBox.SelectedItem.ToString()].ToString();
                        ScanDataSet.CenterDataRow[] drCenterRow = (ScanDataSet.CenterDataRow[])scanDataSet.CenterData.Select("code='" + centercodet + "'");


                        string endName = this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["nameDataGridViewTextBoxColumn"].Value.ToString();
                        string  beginName = this.ScanDataGridView.Rows[i].Cells["oldName"].Value == null ? "" : this.ScanDataGridView.Rows[i].Cells["oldName"].Value.ToString();
                       
                        if (drCenterRow.Length > 0)
                        {
                            centerDataRow = drCenterRow[0];
                            this.ScanDataGridView.Rows[i].Cells["centercode"].Value = centerDataRow.Code;
                            this.ScanDataGridView.Rows[i].Cells["centername"].Value = centerDataRow.Name;
                            this.ScanDataGridView.Rows[i].Cells["itemtype"].Value = centerDataRow.ItemType;
                            this.ScanDataGridView.Rows[i].Cells["feetype"].Value = centerDataRow.FeeType;

                            //批量对照之后 更新对照关系
                            if (!String.IsNullOrEmpty(beginName.Trim())&& !String.IsNullOrEmpty(endName.Trim()))
                            {
                                
                                  new Business.ItemProcess().UpdateItemDictRelation(beginName, endName, centerDataRow.Code, frcode);
                                
                            }

                            //对照之后 更新当前行非选中   
                            this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = false;

                        }

                        

                    }
                    else
                    {
                        MessageBox.Show("请选择要对照的中心项目!");
                        return;
                    }
                }

            }
            

        }

        private void toolStripButton2_Click_1(object sender, EventArgs e)
        {
         
            //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
            this.ScanDataGridView.EndEdit();

          
            this.ScanDataGridView.CurrentCell = null;
            Application.DoEvents();
            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {

                this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = true;
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
          
            //可能会有gridview 数据多，dataset 数据少，数据源没刷新的情况
            this.ScanDataGridView.EndEdit();

            this.ScanDataGridView.CurrentCell = null;
            Application.DoEvents();
            for (int i = 0; i < this.ScanDataGridView.Rows.Count; i++)
            {

                this.ScanDataGridView.Rows[i].Cells[this.ScanDataGridView.Columns["SelectCheck"].Index].Value = false;
            }
        }

        private void PointerToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_ChooseTool_SelectObject, true);
            
        }

        private void ItemToolStripButton_Click(object sender, EventArgs e)
        {
            DictViewForm  dict=  new DictViewForm();
            dict.ShowDialog();
        }

        private void InvertToolStripButton_Click(object sender, EventArgs e)
        {
            ScanImageViewer.Commands.DoCommand(MenuItemEnum.MI_RotateCounterClockwise, true);
           
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void ScanDocumentViewer_OnActivePageChanging(object sender, AxFineReaderVisualComponents.DIDocumentViewerEvents_OnActivePageChangingEvent e)
        {
           
        }

       

        private void gridToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        


    }
}
