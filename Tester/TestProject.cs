using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;

namespace Tester
{
    class TestProject
    {
        
        private Process process;
        private DataGridView dgv;
        private List<string> outputList = new List<string>();
        private List<string> memoryList = new List<string>();
        private List<string> timeList = new List<string>();
        private string pathProgram = null;
        private string pathInput = null;
        private string cache = Environment.CurrentDirectory + @"\cache\";

        string file = null; // имя файла c расширением
        string path = null; // папка где лежит file
        string language = null; // расширение
        public Dictionary<int, int> procID = new Dictionary<int,int>();
        public TestProject(string pathProgram, string pathInput, ref DataGridView dgv)
        {
            this.pathInput = pathInput;
            this.pathProgram = pathProgram;
            this.dgv = dgv;
            this.path = pathProgram.Substring(0, pathProgram.LastIndexOf(@"\")+1);
            this.language = pathProgram.Substring(pathProgram.LastIndexOf(".") + 1);
            this.file = pathProgram.Substring(pathProgram.LastIndexOf(@"\") + 1);
            this.file = this.file.Substring(0, this.file.LastIndexOf('.'));
        }
        /// <summary>
        /// Прогон программы
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        public void start()
        {
            outputList.Clear();
            string line;
            StreamReader inputTxt = new StreamReader(pathInput); // данные импута
            int i = 0;
            switch (language)
            {
                case "py":
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c \"" + pathProgram + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,
                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();

                        // указываем на наши методы
                        process.OutputDataReceived += Process_OutputDataReceived;
                        process.ErrorDataReceived += Process_ErrorDataReceived;
                        process.Exited += Process_Exited;

                        //разбиваем строку ожидаемых ответов на подстроки разделённые нашим разделителем.
                        var parseStr = line.Split(new string[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var str in parseStr)
                        {
                            process.StandardInput.WriteLine(str);
                        }
                    }
                    break;

                case "java":
                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c javac " + "\"" + pathProgram + "\"" + " && jar -cvf " + cache + "Test.jar -C " + path + file + ".class .",
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    process.WaitForExit();
                    File.Delete(path + file + ".class");
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "java",
                            Arguments = @"-jar " + cache + file + ".jar",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,
                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();

                        // указываем на наши методы
                        process.OutputDataReceived += Process_OutputDataReceived;
                        process.ErrorDataReceived += Process_ErrorDataReceived;
                        process.Exited += Process_Exited;

                        //разбиваем строку ожидаемых ответов на подстроки разделённые нашим разделителем.
                        var parseStr = line.Split(new string[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var str in parseStr)
                        {
                            process.StandardInput.WriteLine(str);
                        }
                    }
                    break;

                case "class":
                    i = 0;
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c cd " + path + " & java -classpath . " + file +"." + language,
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,
                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();

                        // указываем на наши методы
                        process.OutputDataReceived += Process_OutputDataReceived;
                        process.ErrorDataReceived += Process_ErrorDataReceived;
                        process.Exited += Process_Exited;

                        //разбиваем строку ожидаемых ответов на подстроки разделённые нашим разделителем.
                        var parseStr = line.Split(new string[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var str in parseStr)
                        {
                            process.StandardInput.WriteLine(str);
                        }
                    }
                    break;

                default:
                    i = 0;
                    var build = new BuildProject().CreateExe(pathProgram);
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        // стартуем процесс с нашими настройками
                        process = Process.Start(new ProcessStartInfo
                        {
                            //FileName = build.CompiledAssembly.FullName.Substring(0, build.CompiledAssembly.FullName.IndexOf(",")),
                            FileName = @"cache\default",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,


                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);
                        
                        process.BeginErrorReadLine();
                        process.BeginOutputReadLine();

                        // указываем на наши методы
                        process.OutputDataReceived += Process_OutputDataReceived;
                        process.ErrorDataReceived += Process_ErrorDataReceived;
                        process.Exited += Process_Exited;
                        
                        //разбиваем строку ожидаемых ответов на подстроки разделённые нашим разделителем.
                        var parseStr = line.Split(new string[] { @"\n" }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (var str in parseStr)
                        {
                            process.StandardInput.WriteLine(str);
                        }
                        
                    }
                    //File.Delete(@"cache\default.exe");
                    break;
            }
        }
        private void Process_Exited(object sender, EventArgs e)
        {
            //залупа пока что не работает
            var process = (Process)sender;
            if (dgv[2, procID[process.Id]].Value == dgv[3, procID[process.Id]].Value)
            {
                foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                    item.Style.BackColor = Color.LightGreen;
            }
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var process = (Process)sender;
            if (dgv.Rows[procID[process.Id]].Cells[0].Style.BackColor == Color.DarkRed)
                return;
            //записываем выходные данные
            dgv[3, procID[process.Id]].Value += e.Data;
            // проверяем верны ли ответы с ожидаемыми ответами
            if (dgv[2, procID[process.Id]].Value.ToString() == dgv[3, procID[process.Id]].Value.ToString())
            {
                //окрашиваем всё как в смешариках
                foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                    item.Style.BackColor = Color.LightGreen;
            }
            else
            {
                foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                    item.Style.BackColor = Color.Red;
            }
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            //на случай если метод вызовется с пустой ошибкой.
            if (e.Data == null)
            {
                return;
            }
            var process = (Process)sender;
            //окрашиваем кровью существ обитающих в аду
            foreach(DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                item.Style.BackColor = Color.DarkRed;
            //записываем бэгус
            dgv[3, procID[process.Id]].Value += "[ERROR] "+ e.Data + " [ERROR] ";
            //в память пишем еррор
            dgv[4, procID[process.Id]].Value = "ERROR";
            //в время пишем еррор
            dgv[5, procID[process.Id]].Value = "ERROR";
        }
    }
}