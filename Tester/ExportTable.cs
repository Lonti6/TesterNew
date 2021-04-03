using System;
using System.Windows.Forms;

namespace Tester
{
    class ExportTable
    {
        public static void ExportToExcel(Control.ControlCollection dgvs)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook ExcelWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet ExcelWorkSheet;
            ExcelWorkBook = ExcelApp.Workbooks.Add(System.Reflection.Missing.Value);
            ExcelWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            int q = 0;
            foreach (DataGridView dgv in dgvs)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    ExcelApp.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
                }
                ExcelApp.Cells[q + 2, 1] = dgv.Tag.ToString();
                q++;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.ColumnCount; j++)
                    {
                        ExcelApp.Cells[q + 2, j + 1] = dgv.Rows[i].Cells[j].Value;
                    }
                    q++;
                }
            }
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true;
        }
        public static void ExportToWord(Control.ControlCollection dgvs)
        {

            Microsoft.Office.Interop.Word.Application application = new Microsoft.Office.Interop.Word.Application();
            Object missing = Type.Missing;
            application.Documents.Add(ref missing, ref missing, ref missing, ref missing);
            Microsoft.Office.Interop.Word.Document document = application.ActiveDocument;
            Microsoft.Office.Interop.Word.Range range = application.Selection.Range;
            Object behiavor = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object autoFitBehiavor = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitFixed;
            int rows = 0;
            foreach (DataGridView dgv in dgvs)
            {
                rows += dgv.Rows.Count;
            }
            document.Tables.Add(range, rows + dgvs.Count + 1, 6, ref behiavor, ref autoFitBehiavor);
            int q = 1;
            foreach (DataGridView dgv in dgvs)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    document.Tables[1].Cell(1, i + 1).Range.Text = dgv.Columns[i].HeaderText;
                }
                document.Tables[1].Cell(q + 1, 1).Range.Text = dgv.Tag.ToString();
                q++;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        if (dgv.Rows[i].Cells[j].Value != null) document.Tables[1].Cell(q + 1, j + 1).Range.Text = dgv.Rows[i].Cells[j].Value.ToString();
                        else document.Tables[1].Cell(q + 1, j + 1).Range.Text = "";
                    }
                    q++;
                }
            }
            application.Visible = true;
        }
    }
}
