using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;

namespace Tester
{
    class ExportTable
    {
        public static void ExportToExcel(DataGridView dgv) 
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            for (int i = 0; i<dgv.Columns.Count; i++) 
            {
                ExcelApp.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                for (int j = 0; j < dgv.ColumnCount; j++)
                {
                    ExcelApp.Cells[i + 2, j + 1] = dgv.Rows[i].Cells[j].Value;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        public static void ExportToWord(DataGridView dgv) 
        {
            int columns = dgv.Columns.Count;
            int rows = dgv.Rows.Count+1;
            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Object missing = Type.Missing;
            application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Document document = application.ActiveDocument;
            Microsoft.Office.Interop.Word.Range range = application.Selection.Range;
            Object behiavor = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed;
            document.Tables.Add(range, rows, columns, ref behiavor, ref autoFitBehiavor);
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                document.Tables[1].Cell(1, i+1).Range.Text = dgv.Columns[i].HeaderText;
            }
            for (int i = 1; i < rows; i++)
                for (int j = 0; j < columns; j++) 
                    {
                        if (dgv.Rows[i-1].Cells[j].Value != null) document.Tables[1].Cell(i + 1, j + 1).Range.Text = dgv.Rows[i-1].Cells[j].Value.ToString();
                        else document.Tables[1].Cell(i + 1, j + 1).Range.Text = "";
                }
            application.Visible = true;
        }
    }
}
