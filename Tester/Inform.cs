using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    class Inform
    {
        public static string pathInp;
        public static string pathOut;
        public static List<TextBox> elemInp = new List<TextBox> { }; //текстовые поля генерациии инпутов
        public static List<TextBox> elemOut = new List<TextBox> { };//текстовые поля генерациии аутпутов
        public static int count;
    }
}
