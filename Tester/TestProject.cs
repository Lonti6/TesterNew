using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tester
{
    class TestProject
    {
        private Process process;
        private List<string> outputList = new List<string>();
        /// <summary>
        /// Прогон программы
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        public List<string> test(string pathProgram, string pathInput)
        {

            outputList.Clear();
            StreamReader inputTxt = new StreamReader(pathInput);
            string line = inputTxt.ReadLine();
            while (line != null)
            {
                var build = new BuildProject().CreateExe(pathProgram);
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
                outputList.Add(process.StandardOutput.ReadLine());
                process.Kill();
                line = inputTxt.ReadLine();
            }
            return outputList;
        }
    }
}