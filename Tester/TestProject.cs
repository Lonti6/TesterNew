﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
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
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine())
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
                        memoryList.Add((process.PeakWorkingSet64).ToString());
                        timeList.Add((DateTime.Now - process.StartTime).Milliseconds.ToString()); 
                    }
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
                    process.WaitForExit();
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
                        process.StandardInput.WriteLine(line);
                        memoryList.Add(process.PeakWorkingSet64.ToString());
                        outputList.Add(process.StandardOutput.ReadLine());
                        
                        timeList.Add((DateTime.Now - process.StartTime).Milliseconds.ToString());
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
                        
                        process.StandardInput.WriteLine(line);//ввод входных данных

                        memoryList.Add(process.PeakWorkingSet64.ToString());

                        outputList.Add(process.StandardOutput.ReadLine());


                        timeList.Add((DateTime.Now - process.StartTime).Milliseconds.ToString());
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
                            RedirectStandardError = true,
                        
                        });
                        if (!process.HasExited)
                        {
                            process.StandardInput.WriteLine(line);
                            var mem = process.PeakWorkingSet64.ToString();
                            if (process.StandardError.EndOfStream)
                            {
                                outputList.Add(process.StandardOutput.ReadLine());
                                memoryList.Add(mem);
                                timeList.Add((DateTime.Now - process.StartTime).Milliseconds.ToString());
                                //process.Kill();
                            }

                            else
                            {
                                outputList.Add(process.StandardError.ReadToEnd());
                                memoryList.Add("Error");
                                timeList.Add("Error");
                            }
                        }

                        else
                        {
                            outputList.Add("Процесс завершил свою работу, раньше ввода данных");
                            memoryList.Add("Error");
                            timeList.Add("Error");
                        }

                    }

                    break;
            }
            return new List<string>[3]{outputList, memoryList, timeList};
        }

        private void Process_Exited(object sender, EventArgs e)
        {
            var a = (Process)sender;
            throw new NotImplementedException();
        }

    }
}