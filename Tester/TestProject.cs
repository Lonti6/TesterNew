using System;
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
    class TestProject
    {
        private Process process;
        private List<string> outputList;
        /// <summary>
        /// конструктор экземпляра TestTask
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        /// <param name="pathOutput">ссылка на выходные данные теста</param>



        public void test(string pathProgram, string pathInput)
        {
            StreamReader inputTxt = new StreamReader(pathInput);
            string line = inputTxt.ReadLine();
            while (line != null)
            {
                CompilerResults build = new BuildProject().CreateExe(pathProgram);
                process = Process.Start(new ProcessStartInfo
                {
                    //FileName = build.CompiledAssembly.FullName.Substring(0, build.CompiledAssembly.FullName.IndexOf(",")),
                    FileName = "test",
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                });
                //process.BeginOutputReadLine();
                process.StandardInput.WriteLine(line);
                /*process.BeginErrorReadLine();
                if (process.StandardError.ReadLine().Length > 0)
                {
                    MessageBox.Show($"Error: {process.StandardError.ReadLine()}");
                }*/

                MessageBox.Show($"Result: {process.StandardOutput.ReadLine()}");
                process.Kill();


                line = inputTxt.ReadLine();
            }
            

        }
    }
}