using Lucene.Net.Analysis;
using Lucene.Net.Analysis.PanGu;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;

using System.Text;
using System.Windows.Forms;

namespace scan
{
    public partial class ItemMappingForm : Form
    {
        
        public ItemMappingForm()
        {
            InitializeComponent();
        }


        protected void GetDetails()
        {
            Hashtable ht = new Hashtable();
            ht.Add("id","1");
            DataTable dt= new Business.ItemProcess().GetDetailById(ht).Tables[0];
            this.DetailGridView.AutoGenerateColumns = false;
            this.DetailGridView.DataSource = dt;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定查询吗?", "查询明细", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                this.GetDetails();
            }
            
        }

      

        private void button2_Click(object sender, EventArgs e)
        {
          
            DataTable dt = (DataTable)this.DetailGridView.DataSource;

            DataRow dr= dt.NewRow();
            dr["pid"] = dt.Rows[0]["pid"];
            dt.Rows.Add(dr);
            DetailGridView.DataSource = dt;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = 0;
            //判断选中几行
            for (int i = 0; i < this.DetailGridView.Rows.Count; i++)
            {
                if (this.DetailGridView.Rows[i].Cells[0].EditedFormattedValue.ToString() == "True")
                {
                    count++;
                }

            }


            MessageBox.Show("选中" + count + "行");
            

        }

       

       

        private void btnfc_Click(object sender, EventArgs e)
        {
            DataTable dt = new Business.DictProcess().GetItemAll().Tables[0];


            //第一个版本应该保存body和title，搜索结果形成超链接，不显示正文。

            string indexPath = "c:/index";
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory);
            if (isUpdate)
            {
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new PanGuAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);


            for (int i = 0; i < dt.Rows.Count; i++)
            {


                //为避免重复索引，所以先删除number=i的记录，再重新添加
                writer.DeleteDocuments(new Term("code", dt.Rows[i]["code"].ToString()));

                Document document = new Document();
                //只有对需要全文检索的字段才ANALYZED
                document.Add(new Field("code", dt.Rows[i]["code"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("name", dt.Rows[i]["name"].ToString(), Field.Store.YES, Field.Index.ANALYZED));

                writer.AddDocument(document);

            }



            //Document document = new Document();
            ////只有对需要全文检索的字段才ANALYZED
            //document.Add(new Field("code", "codes", Field.Store.YES, Field.Index.NOT_ANALYZED));
            //document.Add(new Field("name", "我的阿莫西林", Field.Store.YES, Field.Index.ANALYZED));

            //writer.AddDocument(document);

            writer.Close();
            directory.Close();//不要忘了Close，否则索引结果搜不到
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string indexPath = "c:/index";
            string kw = textBox1.Text;
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NoLockFactory());
            IndexReader reader = IndexReader.Open(directory, true);
            IndexSearcher searcher = new IndexSearcher(reader);
            PhraseQuery query = new PhraseQuery();

            //todo:把用户输入的关键词进行拆词
            //char[] str = textBox1.Text.ToCharArray();
            //for (int i = 0; i < str.Length; i++)
            //{
            //    query.Add(new Term("name", str[i].ToString()));
            //}

            List<String> list = new List<string>();
            Analyzer analyzer = new PanGuAnalyzer();
            TokenStream tokenStream = analyzer.TokenStream("", new StringReader(textBox1.Text));
            Token token = null;
            while ((token = tokenStream.Next()) != null)
            {
                list.Add(token.TermText());
            }

            for (int i = 0; i < list.Count; i++)
            {
                query.Add(new Term("name", list[i].ToString()));
            }

            query.SetSlop(100);
            TopScoreDocCollector collector = TopScoreDocCollector.create(100, true);
            searcher.Search(query, null, collector);
            ScoreDoc[] docs = collector.TopDocs(0, collector.GetTotalHits()).scoreDocs;
          
            for (int i = 0; i < docs.Length; i++)
            {
                int docId = docs[i].doc;//取到文档的编号（主键，这个是Lucene .net分配的）
                //检索结果中只有文档的id，如果要取Document，则需要Doc再去取
                //降低内容占用
                Document doc = searcher.Doc(docId);//根据id找Document
                string code = doc.Get("code");
                string name = doc.Get("name");

                MessageBox.Show("code:"+ code+ "name:"+ name);
            }
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DataTable dt = new Business.DictProcess().GetItemAll().Tables[0];


            //第一个版本应该保存body和title，搜索结果形成超链接，不显示正文。

            string indexPath = "c:/index";
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory);
            if (isUpdate)
            {
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new StandardAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);


            for (int i = 0; i < dt.Rows.Count; i++)
            {


                //为避免重复索引，所以先删除number=i的记录，再重新添加
                writer.DeleteDocuments(new Term("code", dt.Rows[i]["code"].ToString()));

                Document document = new Document();
                //只有对需要全文检索的字段才ANALYZED
                document.Add(new Field("code", dt.Rows[i]["code"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("name", dt.Rows[i]["name"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                writer.AddDocument(document);

            }
            writer.Close();
            directory.Close();//不要忘了Close，否则索引结果搜不到
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataTable dt = new Business.DictProcess().GetItemAll().Tables[0];


            //第一个版本应该保存body和title，搜索结果形成超链接，不显示正文。

            string indexPath = "c:/index";
            FSDirectory directory = FSDirectory.Open(new DirectoryInfo(indexPath), new NativeFSLockFactory());
            bool isUpdate = IndexReader.IndexExists(directory);
            if (isUpdate)
            {
                //如果索引目录被锁定（比如索引过程中程序异常退出），则首先解锁
                if (IndexWriter.IsLocked(directory))
                {
                    IndexWriter.Unlock(directory);
                }
            }
            IndexWriter writer = new IndexWriter(directory, new Util.CJKAnalyzer(), !isUpdate, Lucene.Net.Index.IndexWriter.MaxFieldLength.UNLIMITED);


            for (int i = 0; i < dt.Rows.Count; i++)
            {


                //为避免重复索引，所以先删除number=i的记录，再重新添加
                writer.DeleteDocuments(new Term("code", dt.Rows[i]["code"].ToString()));

                Document document = new Document();
                //只有对需要全文检索的字段才ANALYZED
                document.Add(new Field("code", dt.Rows[i]["code"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                document.Add(new Field("name", dt.Rows[i]["name"].ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));

                writer.AddDocument(document);

            }
            writer.Close();
            directory.Close();//不要忘了Close，否则索引结果搜不到
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Analyzer analyzer = new PanGuAnalyzer();
            TokenStream tokenStream = analyzer.TokenStream("",new StringReader(textBox2.Text));
            Token token = null;
            while ((token = tokenStream.Next()) != null)
            {
                MessageBox.Show(token.TermText());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)this.DetailGridView.DataSource;
            bool result= new Business.ItemProcess().UpdateDetailInfo(dt);
            if (result)
            {
                MessageBox.Show("保存成功!");
            }
        }



        private DataGridViewTextBoxEditingControl EditingControl = null;
        private void DetailGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is DataGridViewTextBoxEditingControl)
            {
                EditingControl = (DataGridViewTextBoxEditingControl)e.Control;
               
                EditingControl.TextChanged += new EventHandler(EditingControl_Event);
            }
        }

        private void EditingControl_Event(object sender,EventArgs e )
        {
           
            
            if (this.DetailGridView.CurrentCell.ColumnIndex == this.DetailGridView.Columns["centername"].Index && !String.IsNullOrEmpty(((TextBox)sender).Text))
            {

                this.itemSearch1.SearchType = "Item";
                this.itemSearch1.SearchText = ((TextBox)sender).Text;
                this.itemSearch1.ControlId = this.DetailGridView.CurrentRow.Index.ToString();//传入行索引
                this.itemSearch1.GetSearchData();

                if (itemSearch1.Visible == false)
                {
                    int columnIndex = DetailGridView.CurrentCell.ColumnIndex;
                    int rowIndex = DetailGridView.CurrentCell.RowIndex;
                    int dgvX = DetailGridView.Location.X;
                    int dgvY = DetailGridView.Location.Y;

                    int cellX = DetailGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).X;
                    int cellY = DetailGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Y;
                    int cellHeight = DetailGridView.GetCellDisplayRectangle(columnIndex, rowIndex, false).Height;
                    itemSearch1.Location = new Point(dgvX + cellX, dgvY + cellY+ cellHeight);
                    itemSearch1.Visible = true;
                    this.itemSearch1.Focus();
                }


            }

        }

      



        /// <summary>
        /// 循环gridview like匹配中心项目
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMap_Click(object sender, EventArgs e)
        {
            DataTable dt= (DataTable)this.DetailGridView.DataSource;
            if (dt.Rows.Count > 0)
            {
                Business.DictProcess dictProcess= new Business.DictProcess();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string oldName = dt.Rows[i]["name"].ToString();
                    string centerCode = "";
                    string centerName = "";
                    DataTable resultDt= dictProcess.MapItemByName(oldName).Tables[0];
                    if (resultDt.Rows.Count > 0)
                    {
                        centerCode = resultDt.Rows[0]["code"].ToString();
                        centerName = resultDt.Rows[0]["name"].ToString();

                        dt.Rows[i]["centercode"] = centerCode;
                        dt.Rows[i]["centername"] = centerName;
                    }

                }

                this.DetailGridView.DataSource = dt;
                MessageBox.Show("匹配成功");
              
            }
          
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //DataTable dt = (DataTable)this.DetailGridView.DataSource;
            //DataRow dr = new DataRow();
        }
    }
}
