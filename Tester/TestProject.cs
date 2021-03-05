using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace Tester
{
    class TestProject
    {
        private Process process;
        private List<string> outputList = new List<string>();
        private List<string> memoryList = new List<string>();
        private List<string> timeList = new List<string>();
        /// <summary>
        /// Прогон программы
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        public List<string>[] test(string pathProgram, string pathInput)
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
                        memoryList.Add(process.PeakWorkingSet64.ToString() + " byte");
                        outputList.Add(process.StandardOutput.ReadLine());
                        line = inputTxt.ReadLine();
                        process.Kill();
                        timeList.Add((process.ExitTime.Millisecond - process.StartTime.Millisecond).ToString());
                    }
                    break;

                case "java":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")) + " & javac " + file + " & exit",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    process.WaitForExit();
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
                        memoryList.Add(process.PeakWorkingSet64.ToString() + " byte");
                        outputList.Add(process.StandardOutput.ReadLine());
                        line = inputTxt.ReadLine();
                        process.WaitForExit();
                        //process.Kill(); // Этот калл по какой то причине не имеет доступа
                        timeList.Add((process.ExitTime.Millisecond - process.StartTime.Millisecond).ToString());
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
                        //ввод входных данных
                        process.StandardInput.WriteLine(line);
                        //макс памяти за время использования
                        memoryList.Add(process.PeakWorkingSet64.ToString() + " byte");
                        // то что вывела прога
                        outputList.Add(process.StandardOutput.ReadLine());
                        // след строка входных данных
                        line = inputTxt.ReadLine();
                        // проверяем закрылась ли прога
                        process.WaitForExit();
                        timeList.Add((process.ExitTime.Millisecond - process.StartTime.Millisecond).ToString());
                    }
                    break;

                default:
                    var build = new BuildProject().CreateExe(pathProgram);
                    while (line != null)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            //FileName = build.CompiledAssembly.FullName.Substring(0, build.CompiledAssembly.FullName.IndexOf(",")),
                            FileName = "test",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        process.StandardInput.WriteLine(line);
                        memoryList.Add(process.PeakWorkingSet64.ToString() + " byte");
                        outputList.Add(process.StandardOutput.ReadLine());
                        process.Kill();
                        timeList.Add((process.ExitTime.Millisecond - process.StartTime.Millisecond).ToString());
                        line = inputTxt.ReadLine();
                    }

                    break;
            }
            return new List<string>[3]{outputList, memoryList, timeList};
        }
    }
}