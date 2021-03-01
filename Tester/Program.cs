using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tester
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // как пользоваться гайд
/*            {
                //создаёшь экземпляр класса
                TestProject test = new TestProject();
                //метод возвращает List<string> с данными которые вывела прога. первое - путь на cs файл, второе путь к входным данным.
                List<string> outputPrgoram = test.test(@"ConsoleApp3\ConsoleApp3\Program.cs", @"data\1\1\input.txt");
                StreamReader trueOutput = new StreamReader(@"");
                string line = trueOutput.ReadLine();
                while (line != null)
                {
                    // тут сравниваешь line с строкой в List<string> и записываешь булевой куда тебе нужно
                    line = trueOutput.ReadLine();
                }
            }*/
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            
        }
    }
}
