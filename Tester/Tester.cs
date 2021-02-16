using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

namespace Tester
{
    class Tester
    {
        
        private string pathInput, pathOutput, pathProgram;
        /// <summary>
        /// конструктор экземпляра TestTask
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        /// <param name="pathOutput">ссылка на выходные данные теста</param>
        public Tester(string pathProgram, string pathInput, string pathOutput)
        {
            this.pathProgram = pathProgram;
            this.pathInput = pathInput;
            this.pathOutput = pathOutput;
        }
        /// <summary>
        /// получение текстового представления файла .cs
        /// </summary>
        private string GetStrCode()
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
                outTxt += sr.ReadLine();

                // берём очередную строку из файла
                line = sr.ReadLine();
            }
            // закрываем файл
            sr.Close();
            return outTxt;
        }

        /// <summary>
        /// компиляция программы и полчение результатов теста
        /// </summary>
        public void Start()
        {
            string source = @GetStrCode();

            // информация о компиляторе
            Dictionary<string, string> providerOptions = new Dictionary<string, string>
            {
                {"CompilerVersion", "v3.5"}
            };
            CSharpCodeProvider provider = new CSharpCodeProvider(providerOptions);

            // параметры компиляции
            CompilerParameters compilerParams = new CompilerParameters
                {OutputAssembly = "D:\\Foo.EXE", GenerateExecutable = false};

            // Компиляция 
            CompilerResults results = provider.CompileAssemblyFromSource(compilerParams, source);

            // Выводим информацию об ошибках 
            Console.WriteLine("Number of Errors: {0}", results.Errors.Count);
            foreach (CompilerError err in results.Errors)
            {
                Console.WriteLine("ERROR {0}", err.ErrorText);
            }
        }

    }
}
