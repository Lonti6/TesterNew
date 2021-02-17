using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    public class GenerateTable
    {
        public static void GenerataTable(int countRows, List<string> name, DataGridView dgv) 
        {
            var column0 = new DataGridViewTextBoxColumn();
            column0.Width = 30;
            column0.HeaderText = name[0];
            dgv.Columns.Add(column0);
            //генерирую таблицу
            var column = new DataGridViewTextBoxColumn();
            column.Width = 30;
            column.HeaderText = name[0];
            dgv.Columns.Add(column);
            for (int i = 1; i<name.Count; i++) 
            {
<<<<<<< HEAD
                var column = new DataGridViewTextBoxColumn();
                column.Width = 55;
=======
                column = new DataGridViewTextBoxColumn();
>>>>>>> a488bf8eb4ffaf094669b169312faae8d0cf4b3d
                column.HeaderText = name[i];
                dgv.Columns.Add(column);
            }
            for (int i = 0; i<countRows; i++) 
            {
                dgv.Rows.Add();
            }
        }
        //изменяю значения в ячейках таблицы
        public static void ReValue(int numberRow, int numberCell, DataGridView dgv, string cellValue) 
        {
            dgv.Rows[numberRow].Cells[numberCell].Value = cellValue;
        }
    }
}
