﻿using System;
using System.Collections.Generic;
using System.CodeDom.Compiler;
using System.Diagnostics;
using Microsoft.CSharp;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Tester
{
    class Tester
    {
        private Process process;
        private string pathProgram, pathInput, pathOutput;
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
                outTxt += line;
                // берём очередную строку из файла
                line = @sr.ReadLine();
            }
            // закрываем файл
            sr.Close();
            return outTxt;
        }

        /// <summary>
        /// компиляция программы
        /// </summary>
        public void CreateExe()
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            CompilerParameters parameters = new CompilerParameters() { GenerateExecutable = false, GenerateInMemory = true, OutputAssembly = "test.exe", CompilerOptions = "/target:winexe" };
            CompilerResults compilerResult = provider.CompileAssemblyFromFile(parameters, pathProgram);
            //вывод ошибок
            if (compilerResult.Errors.HasErrors)
            {
                foreach (CompilerError err in compilerResult.Errors)
                {
                    MessageBox.Show("ERROR {0} :" + err.ErrorText);
                }
            }

        }

        public void RunProject()
        {
            process = Process.Start(new ProcessStartInfo
            {
                FileName = "test",
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
            });
            //process.BeginOutputReadLine();
            process.StandardInput.WriteLine("6");
            MessageBox.Show($"Result: {process.StandardOutput.ReadToEnd()}");
            process.Close();

        }
    }
}