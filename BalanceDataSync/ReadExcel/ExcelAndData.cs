
using System.Data;
using System.Configuration;
using System.Web;

using System.IO;
using System.Text;
using NPOI;
using NPOI.HPSF;
using NPOI.HSSF;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.POIFS;
using NPOI.Util;
using System;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using System.Windows.Forms;
using System.Windows;
using System.Collections.Generic;

namespace BalanceDataSync
{
    public class NPOIHelper
    {
        private static NPOIHelper _instance;

        public static NPOIHelper Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new NPOIHelper();
                }
                return NPOIHelper._instance;
            }
          
        }
        /// <summary>
        /// DataTable导出到Excel文件
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        /// <param name="strFileName">保存位置</param>
        public  void Export(DataTable dtSource, string strHeaderText, string strFileName)
        {
            using (MemoryStream ms = Export(dtSource, strHeaderText))
            {
                using (FileStream fs = new FileStream(strFileName, FileMode.Create, FileAccess.Write))
                {
                    byte[] data = ms.ToArray();
                    fs.Write(data, 0, data.Length);
                    fs.Flush();
                }
            }
        }

        /// <summary>
        /// DataTable导出到Excel的MemoryStream
        /// </summary>
        /// <param name="dtSource">源DataTable</param>
        /// <param name="strHeaderText">表头文本</param>
        public  MemoryStream Export(DataTable dtSource, string strHeaderText)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            
            HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet();
           
            #region 右击文件 属性信息
            {
                DocumentSummaryInformation dsi = PropertySetFactory.CreateDocumentSummaryInformation();
                dsi.Company = "NPOI";
                workbook.DocumentSummaryInformation = dsi;

                SummaryInformation si = PropertySetFactory.CreateSummaryInformation();
                si.Author = "文件作者信息"; //填加xls文件作者信息
                si.ApplicationName = "创建程序信息"; //填加xls文件创建程序信息
                si.LastAuthor = "最后保存者信息"; //填加xls文件最后保存者信息
                si.Comments = "作者信息"; //填加xls文件作者信息
                si.Title = "标题信息"; //填加xls文件标题信息
                si.Subject = "主题信息";//填加文件主题信息
                si.CreateDateTime = DateTime.Now;
                workbook.SummaryInformation = si;
            }
            #endregion

            HSSFCellStyle dateStyle = (HSSFCellStyle)workbook.CreateCellStyle();
            HSSFDataFormat format = (HSSFDataFormat)workbook.CreateDataFormat();
            dateStyle.DataFormat = format.GetFormat("yyyy-mm-dd");
            dateStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            HSSFCellStyle CommonStyle = (HSSFCellStyle)workbook.CreateCellStyle();
              CommonStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            
            //取得列宽
            int[] arrColWidth = new int[dtSource.Columns.Count];
            foreach (DataColumn item in dtSource.Columns)
            {
                arrColWidth[item.Ordinal] = Encoding.GetEncoding(936).GetBytes(item.ColumnName.ToString()).Length;
            }
            for (int i = 0; i < dtSource.Rows.Count; i++)
            {
                for (int j = 0; j < dtSource.Columns.Count; j++)
                {
                    int intTemp = Encoding.GetEncoding(936).GetBytes(dtSource.Rows[i][j].ToString()).Length;
                    if (intTemp > arrColWidth[j])
                    {
                        arrColWidth[j] = intTemp;
                    }
                }
            } 
            int rowIndex = 0; 
            foreach (DataRow row in dtSource.Rows)
            {
                #region 新建表，填充表头，填充列头，样式
                if (rowIndex == 65535 || rowIndex == 0)
                {
                    if (rowIndex != 0)
                    {
                        sheet = (HSSFSheet)workbook.CreateSheet();
                    }

                    #region 表头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(0);
                        headerRow.HeightInPoints = 25;
                        headerRow.CreateCell(0).SetCellValue(strHeaderText);

                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment =  NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 20;
                        font.Boldweight = 00;
                        headStyle.SetFont(font);
                        headerRow.GetCell(0).CellStyle = headStyle;
                        sheet.AddMergedRegion(new Region(0, 0, 0, dtSource.Columns.Count - 1));
                       
                    }
                    #endregion


                    #region 列头及样式
                    {
                        HSSFRow headerRow = (HSSFRow)sheet.CreateRow(1);
                        HSSFCellStyle headStyle = (HSSFCellStyle)workbook.CreateCellStyle();
                        headStyle.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
                        HSSFFont font = (HSSFFont)workbook.CreateFont();
                        font.FontHeightInPoints = 12;
                        font.Boldweight = 400;
                        headStyle.SetFont(font); 
                        foreach (DataColumn column in dtSource.Columns)
                        {
                            headerRow.CreateCell(column.Ordinal).SetCellValue(column.ColumnName);
                            headerRow.GetCell(column.Ordinal).CellStyle = headStyle;

                            //设置列宽
                            sheet.SetColumnWidth(column.Ordinal, (arrColWidth[column.Ordinal] + 1) * 256); 
                        }
                        //headerRow.Dispose();
                    }
                    #endregion

                    rowIndex = 2;
                }
                #endregion
                #region 填充内容
                HSSFRow dataRow = (HSSFRow)sheet.CreateRow(rowIndex);
                foreach (DataColumn column in dtSource.Columns)
                {
                    HSSFCell newCell = (HSSFCell)dataRow.CreateCell(column.Ordinal);
                    
                    string drValue = row[column].ToString();

                    switch (column.DataType.ToString())
                    {
                        case "System.String"://字符串类型
                            newCell.SetCellValue(drValue);
                             newCell.CellStyle = CommonStyle;//普通样式
                            break;
                        case "System.DateTime"://日期类型
                            DateTime dateV;
                            DateTime.TryParse(drValue, out dateV);
                            newCell.SetCellValue(dateV);

                            newCell.CellStyle = dateStyle;//格式化显示
                            break;
                        case "System.Boolean"://布尔型
                            bool boolV = false;
                            bool.TryParse(drValue, out boolV);
                            newCell.SetCellValue(boolV);
                            newCell.CellStyle = CommonStyle;//普通样式
                            break;
                        case "System.Int16"://整型
                        case "System.Int32":
                        case "System.Int64":
                        case "System.Byte":
                            int intV = 0;
                            int.TryParse(drValue, out intV);
                            newCell.SetCellValue(intV);
                            newCell.CellStyle = CommonStyle;//普通样式
                            break;
                        case "System.Decimal"://浮点型
                        case "System.Double":
                            double doubV = 0;
                            double.TryParse(drValue, out doubV);
                            newCell.SetCellValue(doubV);
                            newCell.CellStyle = CommonStyle;//普通样式
                            break;
                        case "System.DBNull"://空值处理
                            newCell.SetCellValue("");
                            newCell.CellStyle = CommonStyle;//普通样式
                            break;
                        default:
                            newCell.SetCellValue("");
                            newCell.CellStyle = CommonStyle;//普通样式
                            break;
                    }

                }
                #endregion

                rowIndex++;
            } 
            using (MemoryStream ms = new MemoryStream())
            {
                workbook.Write(ms);
                
                ms.Flush();
                ms.Position = 0;
               
                //sheet.Dispose();
                
                //workbook.Dispose();//一般只用写这一个就OK了，他会遍历并释放所有资源，但当前版本有问题所以只释放sheet
                return ms;
            } 
        }

      
        /// <summary>读取excel
        /// 默认第二行为标头
        /// </summary>
        /// <param name="strFileName">excel文档路径</param>
        /// <returns></returns>
        public  DataTable Import(string strFileName)
        {
            if (!File.Exists(strFileName))
            {
                return null;
            }
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Extension.ToLower() == ".xlsx")
            {

                return Import2007(strFileName);
            }
            else
            {
                DataTable dt=Import2003(strFileName);
                return dt;
            }
                //Excel.Application app = new Excel.ApplicationClass();
                //Excel.Workbook m_workbook = app.Workbooks.Open(
                //     strFileName,
                //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //    Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                //    Type.Missing, Type.Missing);
                //strFileName = strFileName.Substring(0, strFileName.LastIndexOf(".")) + "temp.xls";
                //m_workbook.SaveAs(strFileName, Excel.XlFileFormat.xlExcel8, Type.Missing, Type.Missing, Type.Missing,
                //    Type.Missing, Excel.XlSaveAsAccessMode.xlNoChange, Type.Missing, Type.Missing,
                //    Type.Missing, Type.Missing, Type.Missing);
                //m_workbook.Close();
            
            
        }
        public DataTable ImportMonth(string strFileName)
        {
            if (!File.Exists(strFileName))
            {
                return null;
            }
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Extension.ToLower() == ".xlsx")
            {

                return ImportNew2007(strFileName);
            }
            else
            {
                DataTable dt = ImportNew2003(strFileName);
                return dt;
            }
        }
        public DataTable ImportAccountLink(string strFileName)
        {
            if (!File.Exists(strFileName))
            {
                return null;
            }
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Extension.ToLower() == ".xlsx")
            {

                return ImportNew2007(strFileName,0);
            }
            else
            {
                DataTable dt = ImportNew2003(strFileName,0);
                return dt;
            }
        }
        public DataTable ImportSalary(string strFileName)
        {
            if (!File.Exists(strFileName))
            {
                return null;
            }
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Extension.ToLower() == ".xlsx")
            {

                return ImportNew2007(strFileName, 0);
            }
            else
            {
                DataTable dt = ImportSalary2003(strFileName,0);
                return dt;
            }
        }
        private DataTable ImportSalary2003(string strFileName, int defaultrowhead = 1)
        {


            DataTable dt = new DataTable();

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);


            System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

            HSSFRow headerRow = (HSSFRow)sheet.GetRow(defaultrowhead);// 默认第一行为标头
            int cellCount = headerRow.LastCellNum;

            for (int j = 0; j < cellCount; j++)
            {
                HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                dt.Columns.Add(cell.ToString());
            }

            for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
            {


                HSSFRow row = (HSSFRow)sheet.GetRow(i);
                if (row ==null )
                {
                    continue;
                }
                DataRow dataRow = dt.NewRow();

                for (int j = row.FirstCellNum; j < cellCount; j++)
                {
                    if (row.GetCell(j) != null)
                        if (row.GetCell(j).CellType == NPOI.SS.UserModel.CellType.NUMERIC)
                        {
                            int s = row.GetCell(j).CellStyle.DataFormat;
                            if (s == 14 || s == 31 || s == 57 || s == 58)
                            {
                                DateTime date = row.GetCell(j).DateCellValue;
                                dataRow[j] = date.ToString();
                            }
                            else
                            {
                                dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                            }
                        }
                        else if (row.GetCell(j).CellType == NPOI.SS.UserModel.CellType.FORMULA)
                        {
                            //double number = row.GetCell(j).NumericCellValue;
                            if (row.GetCell(j).CachedFormulaResultType == NPOI.SS.UserModel.CellType.NUMERIC)
                            {
                                dataRow[j] = row.GetCell(j).NumericCellValue.ToString();
                            }
                            else if(row.GetCell(j).CachedFormulaResultType == NPOI.SS.UserModel.CellType.STRING)
                            {
                                dataRow[j] = row.GetCell(j).StringCellValue;
                            }
                           
                        }
                        else
                        {
                            dataRow[j] = row.GetCell(j).ToString();
                        }
                }

                dt.Rows.Add(dataRow);
                //App.Current.Dispatcher.Invoke(new Action(delegate()
                //{
                //    MainWindow MW = (MainWindow)App.Current.MainWindow;
                //    MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                //    jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                //    MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                //}));
            }
            return dt;

        }

        private DataTable ImportNew2003(string strFileName,int defaultrowhead=1)
        {
            

                DataTable dt = new DataTable();

                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);

               
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                HSSFRow headerRow = (HSSFRow)sheet.GetRow(defaultrowhead);// 默认第一行为标头
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                    dt.Columns.Add(cell.ToString());
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {


                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dt.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            if (row.GetCell(j).CellType == NPOI.SS.UserModel.CellType.NUMERIC)
                            {
                                int s = row.GetCell(j).CellStyle.DataFormat;
                                if (s == 14 || s == 31 || s == 57 || s == 58)
                                {
                                    DateTime date = row.GetCell(j).DateCellValue;
                                    dataRow[j] = date.ToString();
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                            else
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                    }

                    dt.Rows.Add(dataRow);
                    //App.Current.Dispatcher.Invoke(new Action(delegate()
                    //{
                    //    MainWindow MW = (MainWindow)App.Current.MainWindow;
                    //    MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                    //    jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                    //    MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    //}));
                }
                return dt;
           
        }
        private DataTable ImportNew2007(string strFileName, int defaultrowhead = 1)
        {
            
                DataTable dt = new DataTable();

                XSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
                XSSFSheet sheet = (XSSFSheet)hssfworkbook.GetSheetAt(0);
                
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                XSSFRow headerRow = (XSSFRow)sheet.GetRow(defaultrowhead);// 默认第二行为标头
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    XSSFCell cell = (XSSFCell)headerRow.GetCell(j);
                    dt.Columns.Add(cell.ToString());
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    XSSFRow row = (XSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dt.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }
                    dt.Rows.Add(dataRow);
                    
                }
                return dt;
           
        }


        private  DataTable Import2003(string strFileName)
        {
             
                DataTable dt = new DataTable();

                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                HSSFRow headerRow = (HSSFRow)sheet.GetRow(0);// 默认第一行为标头
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                    dt.Columns.Add(cell.ToString());
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                   

                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dt.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            if (row.GetCell(j).CellType == NPOI.SS.UserModel.CellType.NUMERIC)
                            {
                                int s = row.GetCell(j).CellStyle.DataFormat;
                                if (s == 14 || s == 31 || s == 57 || s == 58)
                                {
                                    DateTime date = row.GetCell(j).DateCellValue;
                                    dataRow[j] = date.ToString();
                                }
                                else
                                {
                                    dataRow[j] = row.GetCell(j).ToString();
                                }
                            }
                            else
                            {
                                dataRow[j] = row.GetCell(j).ToString();
                            }
                    }

                    dt.Rows.Add(dataRow);
                    
                }
                return dt;
         
        }
        private  DataTable Import2007(string strFileName)
        {
           
                DataTable dt = new DataTable();

                XSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new XSSFWorkbook(file);
                }
                XSSFSheet sheet = (XSSFSheet)hssfworkbook.GetSheetAt(0);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                XSSFRow headerRow = (XSSFRow)sheet.GetRow(0);// 默认第二行为标头
                int cellCount = headerRow.LastCellNum;

                for (int j = 0; j < cellCount; j++)
                {
                    XSSFCell cell = (XSSFCell)headerRow.GetCell(j);
                    dt.Columns.Add(cell.ToString());
                }

                for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                {
                    XSSFRow row = (XSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dt.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        if (row.GetCell(j) != null)
                            dataRow[j] = row.GetCell(j).ToString();
                    }

                    dt.Rows.Add(dataRow);
                }
                return dt;
           
        }

        #region 导入人员信息表
        /// <summary>
        /// 导入人员信息表
        /// </summary>
        /// <param name="strFileName"></param>
        /// <returns></returns>
        public List<DataTable> ImportPersonInfo(string strFileName, int defaultrowhead = 0, int colomns = 0)
        {
            if (!File.Exists(strFileName))
            {
                return null;
            }
            FileInfo fi = new FileInfo(strFileName);
            if (fi.Extension.ToLower() == ".xlsx")
            {

                return null;
            }
            else
            {
                List<DataTable> tables = ImportPersonInfo2003(strFileName, defaultrowhead, colomns);
                return tables;
            }
        }
        private List<DataTable> ImportPersonInfo2003(string strFileName, int defaultrowhead = 0,int colomns=0)
        {


           

            HSSFWorkbook hssfworkbook;
            using (FileStream file = new FileStream(strFileName, FileMode.Open, FileAccess.Read))
            {
                hssfworkbook = new HSSFWorkbook(file);
            }
            int sheetcount = hssfworkbook.NumberOfSheets;
            List<DataTable> tables = new List<DataTable>();
            for (int k = 0; k < sheetcount; k++)
            {

                DataTable dt = new DataTable();
                HSSFSheet sheet = (HSSFSheet)hssfworkbook.GetSheetAt(k);
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();

                HSSFRow headerRow = (HSSFRow)sheet.GetRow(defaultrowhead);
                int cellCount = 0;
                int rowstartindex = 0;
                if (colomns > 0)
                {
                    cellCount = colomns;
                    for (int j = 0; j < cellCount; j++)
                    {
                        dt.Columns.Add(j.ToString());
                    }
                }
                else
                {
                    cellCount = headerRow.LastCellNum;
                    rowstartindex = sheet.FirstRowNum;
                    for (int j = 0; j < cellCount; j++)
                    {
                        HSSFCell cell = (HSSFCell)headerRow.GetCell(j);
                        dt.Columns.Add(cell.ToString());
                    }
                }

                for (int i = (rowstartindex + 1); i <= sheet.LastRowNum; i++)
                {


                    HSSFRow row = (HSSFRow)sheet.GetRow(i);
                    if (row == null)
                    {
                        continue;
                    }
                    DataRow dataRow = dt.NewRow();

                    for (int j = row.FirstCellNum; j < cellCount; j++)
                    {
                        CellRangeAddress mergedRegion = null;
                        NPOI.SS.UserModel.ICell cell = row.GetCell(j);
                        if (cell.IsMergedCell)
                        {
                            mergedRegion= getMergedRegionForCell(cell);
                            if (mergedRegion != null)
                            {
                                cell = sheet.GetRow(mergedRegion.FirstRow).GetCell(mergedRegion.FirstColumn);
                            }
                    
                        }
                        if (cell != null)
                            if (cell.CellType == NPOI.SS.UserModel.CellType.NUMERIC)
                            {
                                int s = cell.CellStyle.DataFormat;
                                if (s == 14 || s == 31 || s == 57 || s == 58)
                                {
                                    DateTime date = cell.DateCellValue;
                                    dataRow[j] = date.ToString();
                                }
                                else
                                {
                                    dataRow[j] = cell.NumericCellValue.ToString();
                                }
                            }
                            else if (cell.CellType == NPOI.SS.UserModel.CellType.FORMULA)
                            {
                                //double number = row.GetCell(j).NumericCellValue;
                                if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.NUMERIC)
                                {
                                    dataRow[j] = cell.NumericCellValue.ToString();
                                }
                                else if (cell.CachedFormulaResultType == NPOI.SS.UserModel.CellType.STRING)
                                {
                                    dataRow[j] = cell.StringCellValue;
                                }

                            }
                            else
                            {
                                dataRow[j] = cell.ToString();
                            }
                    }

                    dt.Rows.Add(dataRow);
                    //App.Current.Dispatcher.Invoke(new Action(delegate()
                    //{
                    //    MainWindow MW = (MainWindow)App.Current.MainWindow;
                    //    MW.pro.progressBar.Value = MW.pro.progressBar.Value + 1;
                    //    jinDu = MW.pro.progressBar.Value / MW.pro.progressBar.Maximum * 100;
                    //    MW.pro.jinDu.Text = "当前进度:" + jinDu.ToString("#0.00") + "%";

                    //}));
                }
                tables.Add(dt);
            }
            return tables;

        }
        public CellRangeAddress getMergedRegionForCell(NPOI.SS.UserModel.ICell c)
        {
            NPOI.SS.UserModel.ISheet s = c.Sheet;
            for (int i = 0; i < s.NumMergedRegions; i++)
            {
                CellRangeAddress mergedRegion = s.GetMergedRegion(i);
                if (mergedRegion.IsInRange(c.RowIndex, c.ColumnIndex))
                {
                    return mergedRegion;
                }
            }
            
            return null;
        }
        #endregion


    }
}


  
