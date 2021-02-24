using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace Tester
{
    class Tester
    { 
        /// <summary>
        /// конструктор экземпляра TestTask
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        /// <param name="pathOutput">ссылка на выходные данные теста</param>
        public Tester(string pathProgram)
        {
            var outputexe = CompilingProgram(pathProgram);
            Process.Start(outputexe.);
        }
        /// <summary>
        /// получение текстового представления файла .cs
        /// </summary>
        private string GetStrCode(string pathProgram)
        {
            // создаём класс с текстом из файла
            StreamReader sr = new StreamReader(pathProgram);

            // создаём переменную которая будет содержать весь текст файла
            string outTxt = "";

            // строка из файла
            string line = sr.ReadLine();

            // цикл для последовательной записи строк
            while (line != null)
            {
                // записываем строку
                outTxt += line;
                // берём очередную строку из файла
                line = @sr.ReadLine();
            }
            // закрываем файл
            sr.Close();
            return outTxt;
        }

        /// <summary>
        /// компиляция программы и получение результатов теста
        /// </summary>
        private void CompilingProgram(string pathProgram)
        {
            string code = @GetStrCode(pathProgram);
            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            CompilerParameters parameters = new CompilerParameters() { GenerateExecutable = false, GenerateInMemory = true };

            var compilerResult = provider.CompileAssemblyFromSource(parameters, new string[] { code });

            if (compilerResult.Errors.HasErrors)
            {
                foreach (CompilerError err in compilerResult.Errors)
                {
                    MessageBox.Show("ERROR {0} :" + err.ErrorText);
                }
            }

            var test = compilerResult.CompiledAssembly.GetType("Test", false);

            while (true)
            {
                Console.WriteLine("Enter number:");

                int n = 0;

                if (!int.TryParse(Console.ReadLine(), out n))
                {
                    Console.WriteLine();
                    continue;
                }

                n = (int)test.InvokeMember("Calc", System.Reflection.BindingFlags.InvokeMethod |
                                                   System.Reflection.BindingFlags.NonPublic |
                                                   System.Reflection.BindingFlags.Static, null, test, new object[] { n });

                Console.WriteLine($"Result: {n}");
                Console.WriteLine();
            }
        }

    }
}