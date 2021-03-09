using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

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
            string language = pathProgram.Substring(pathProgram.LastIndexOf(".") + 1); // расширение
            StreamReader inputTxt = new StreamReader(pathInput); // данные импута
            string line;
            string file = pathProgram.Substring(pathProgram.LastIndexOf(@"\") + 1); // имя файла c hfcithtybtv
            string path = pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")); // папка где лежит file
            Stopwatch SW = new Stopwatch();
            switch (language)
            {
                case "py":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + path + " & pyinstaller -F " + file,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    process.WaitForExit();
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine())
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = path+"\\dist\\"+file.Substring(0, file.LastIndexOf("."))+".exe",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        SW.Restart();
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        SW.Stop();
                        memoryList.Add(process.PeakPagedMemorySize64.ToString());
                        timeList.Add(process.UserProcessorTime.Milliseconds.ToString());
                        process.WaitForExit();
                    }
                    
                    Directory.Delete(path + "\\" + "dist", true);
                    File.Delete(path+"\\"+ file.Substring(0, file.LastIndexOf(".")) + ".spec");
                    Directory.Delete(path + "\\" + "__pycache__", true);
                    Directory.Delete(path + "\\" + "build", true);
                    break;

                case "java":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + path + " & javac " + file,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine())
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c cd " + path + " & java -classpath . " + file.Substring(0,file.LastIndexOf(".")),
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        SW.Restart(); // Засекаем 
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        SW.Stop(); // отсекаем)
                        memoryList.Add(process.PeakWorkingSet64.ToString());
                        timeList.Add(SW.ElapsedMilliseconds.ToString());
                    }
                    File.Delete(pathProgram.Substring(0,pathProgram.LastIndexOf(".")) + ".class" );
                    break;

                case "class":
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine())
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c cd " + path + " & java -classpath . " + file.Substring(0, file.IndexOf(".")),
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                        });
                        
                        SW.Start(); // Засекаем 
                        process.StandardInput.WriteLine(line);//ввод входных данных
                        SW.Stop(); // отсекаем)

                        memoryList.Add(process.PeakPagedMemorySize64.ToString());

                        outputList.Add(process.StandardOutput.ReadLine());


                        timeList.Add(SW.ElapsedMilliseconds.ToString());
                    }
                    break;

                default:
                    var build = new BuildProject().CreateExe(pathProgram);
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine())
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
                        SW.Restart();
                        process.StandardInput.WriteLine(line);
                        outputList.Add(process.StandardOutput.ReadLine());
                        SW.Stop();
                        memoryList.Add(process.PeakPagedMemorySize64.ToString());
                        timeList.Add(SW.ElapsedMilliseconds.ToString());
                        process.Kill();
                    }

                    break;
            }
            return new List<string>[3]{outputList, memoryList, timeList};
        }
    }
}