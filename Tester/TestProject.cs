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
            string language = pathProgram.Substring(pathProgram.LastIndexOf(".") + 1);
            StreamReader inputTxt = new StreamReader(pathInput);
            string line = inputTxt.ReadLine();
            string file = pathProgram.Substring(pathProgram.LastIndexOf(@"\") + 1);
            string path = pathProgram.Substring(0, pathProgram.LastIndexOf(@"\"));
            switch (language)
            {
                case "py":
                    while (line != null)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c " + pathProgram,
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        line = inputTxt.ReadLine();
                        process.Kill();
                    }
                    break;

                case "java":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")) + " & javac " + file,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    while (line != null)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c cd " + pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")) + " & java -classpath . " + file.Substring(0, file.IndexOf(".")),
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        line = inputTxt.ReadLine();
                        process.StandardInput.WriteLine("exit");
                    }
                    File.Delete(pathProgram.Substring(0,pathProgram.LastIndexOf(".")) + ".class" );
                    break;

                case "class":
                    while (line != null)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c cd " + pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")) + " & java -classpath . " + file.Substring(0, file.IndexOf(".")),
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        line = inputTxt.ReadLine();
                        process.Kill();
                    }
                    break;

                default:
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

                    break;
            }
            return outputList;
        }
    }
}