using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Office.Core;
using Microsoft.Office.Interop;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace RemoteCIMPC
{
    class ExcelHelper
    {
        public static string path = @"IP规划191122.xlsx";
        //public static string tablename = "EAS和DFS IP";

        public static DataTable readExcel()
        {
            Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Sheets sheets;
            Microsoft.Office.Interop.Excel.Workbook workbook = null;
            object oMissiong = System.Reflection.Missing.Value;
            DataTable dt = new DataTable();

//            wath.Start();

            try
            {
                if (app == null)
                {
                    return null;
                }

                workbook = app.Workbooks.Open(path, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);

                //将数据读入到DataTable中——Start   

                sheets = workbook.Worksheets;
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)sheets.get_Item(1);//读取第一张表
                if (worksheet == null)
                    return null;

                string cellContent;
                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                Microsoft.Office.Interop.Excel.Range range;

                //负责列头Start
                DataColumn dc;
                int ColumnID = 1;
                range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, 1];
                while (range.Text.ToString().Trim() != "")
                {
                    dc = new DataColumn();
                    dc.DataType = Type.GetType("System.String");
                    dc.ColumnName = range.Text.ToString().Trim();
                    dt.Columns.Add(dc);

                    range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[1, ++ColumnID];
                }
                //End

                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();

                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Microsoft.Office.Interop.Excel.Range)worksheet.Cells[iRow, iCol];

                        cellContent = (range.Value2 == null) ? "" : range.Text.ToString();

                        //if (iRow == 1)
                        //{
                        //    dt.Columns.Add(cellContent);
                        //}
                        //else
                        //{
                        dr[iCol - 1] = cellContent;
                        //}
                    }

                    //if (iRow != 1)
                    dt.Rows.Add(dr);
                }

//                wath.Stop();
//                TimeSpan ts = wath.Elapsed;

                //将数据读入到DataTable中——End
                return dt;
            }
            catch
            {

                return null;
            }
/*            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
*/
        }




    }
}
