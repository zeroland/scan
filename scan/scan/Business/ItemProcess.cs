using System;
using System.Collections.Generic;
using System.Data;

using System.Text;

using scan.Interface;
namespace scan.Business
{
    class ItemProcess
    {
        public DataSet GetDetailById(System.Collections.IDictionary iDictionary)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.GetDetailById(iDictionary);

        }

        public DataSet GetShowNameByScanName(string scanname)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.GetShowNameByScanName(scanname);
        }

        public DataSet GetShowNameByFRcodeScanName(string scanname,string frcode)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.GetShowNameByFRcodeScanName(scanname, frcode);
        }

        public bool UpdateDetailInfo(DataTable dt)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.UpdateDetailInfo(dt);
        }

        public bool SaveAndUpdateDetail(DataTable dt)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.SaveAndUpdateDetail(dt);
        }

        public bool UpdateZyjl(DataTable dt)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.UpdateZyjl(dt);
        }

        public void UpdateItemDictRelation(string scanname ,string showname,string centercode, string frcode)
        {
            //开始 结束名字 都不为数值才更新
            double result = 0;
            if (!String.IsNullOrEmpty(scanname.Trim()) && !String.IsNullOrEmpty(showname.Trim()) && !double.TryParse(scanname.Trim(), out result) && !double.TryParse(showname.Trim(), out result))
            {
                IItemProcess itemProcess = new SqlServer.ItemProcess();
                itemProcess.UpdateItemDictRelation(scanname, showname, centercode, frcode);
            }
            else
            {
                return;
            }

            
        }

        public DataSet GetItemDict(string frcode, string str)
        {
            IItemProcess itemProcess = new SqlServer.ItemProcess();
            return itemProcess.GetItemDict(frcode,str);
        }
    }
}
