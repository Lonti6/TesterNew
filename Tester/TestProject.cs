using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Drawing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tester
{
    class TestProject
    {

        private Process process;
        private DataGridView dgv;
        private List<string> outputList = new List<string>();
        private List<string> memoryList = new List<string>();
        private List<string> timeList = new List<string>();
        private string file = null;
        private string pathInput = null;
        private string cache = Environment.CurrentDirectory + @"\cache\";

        string fileName = null; // имя файла c расширением
        string filePath = null; // папка где лежит file
        string fileLanguage = null; // расширение
        public Dictionary<int, int> procID = new Dictionary<int, int>();
        public TestProject(string file, string pathInput, ref DataGridView dgv)
        {
            this.pathInput = pathInput;
            this.file = file;
            this.dgv = dgv;
            this.filePath = file.Substring(0, file.LastIndexOf(@"\") + 1);
            this.fileName = file.Substring(file.LastIndexOf(@"\") + 1);
            this.fileLanguage = this.fileName.Substring(this.fileName.LastIndexOf(".") + 1);
            this.fileName = this.fileName.Substring(0, this.fileName.LastIndexOf('.'));
        }
        public async void startAsync()
        {
            await Task.Run(() => start());
        }
        public void start()
        {
            string manifest, jar, classFile;
            outputList.Clear();
            string line;
            StreamReader inputTxt = new StreamReader(pathInput); // данные импута
            int i = 0;
            switch (fileLanguage)
            {
                case "py":
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "cmd",
                            Arguments = "/c \"" + file + "\"",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,
                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.EnableRaisingEvents = true;
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
                case "jar":
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        process = Process.Start(new ProcessStartInfo
                        {
                            FileName = "java",
                            Arguments = @"-jar " + file,
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,
                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.EnableRaisingEvents = true;
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
                    process.WaitForExit();
                    //File.Delete(file);
                    break;
                case "java":
                    manifest = fileName + ".mf";
                    jar = fileName + ".jar";
                    classFile = fileName + ".class";
                    using (FileStream fs = File.Create(cache + manifest))
                    {
                        byte[] text = new UTF8Encoding(true).GetBytes("Manifest-Version: 1.0 \nMain-Class:" + fileName);
                        fs.Write(text, 0, text.Length);
                    }

                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + cache +
                                    " && javac -d " + cache + " \"" + file + "\"" +
                                    " && jar cfe " + jar + " " + fileName + " " + classFile,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    process.WaitForExit();
                    File.Delete(cache + classFile);
                    File.Delete(cache + manifest);
                    file = cache + jar;
                    goto case "jar";

                case "class":
                    classFile = fileName + ".class";
                    if (File.Exists(cache + classFile))
                    {
                        File.Delete(cache + classFile);
                    }
                    File.Copy(file, cache + classFile);
                    manifest = fileName + ".mf";
                    jar = fileName + ".jar";

                    using (FileStream fs = File.Create(cache + manifest))
                    {
                        byte[] text = new UTF8Encoding(true).GetBytes("Manifest-Version: 1.0 \nMain-Class:" + fileName);
                        fs.Write(text, 0, text.Length);
                    }

                    process = Process.Start(new ProcessStartInfo
                    {
                        FileName = "cmd",
                        Arguments = "/c cd " + cache +
                                    " && jar cfe " + jar + " " + fileName + " " + classFile,
                        CreateNoWindow = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        RedirectStandardInput = true,
                    });
                    process.WaitForExit();
                    File.Delete(cache + classFile);
                    file = cache + jar;
                    goto case "jar";

                default:
                    i = 0;
                    var build = new BuildProject().CreateExe(file);
                    for (line = inputTxt.ReadLine(); line != null; line = inputTxt.ReadLine(), i++)
                    {
                        // стартуем процесс с нашими настройками
                        process = Process.Start(new ProcessStartInfo
                        {
                            //FileName = build.CompiledAssembly.FullName.Substring(0, build.CompiledAssembly.FullName.IndexOf(",")),
                            FileName = cache + fileName + ".exe",
                            CreateNoWindow = true,
                            UseShellExecute = false,
                            RedirectStandardOutput = true,
                            RedirectStandardInput = true,
                            RedirectStandardError = true,


                        });

                        //сохраняем соотношение номер строки с айдишником процесса. Чтобы потом знать к какой строке какой процесс принадлежит
                        procID.Add(process.Id, i);

                        process.EnableRaisingEvents = true;
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
                    process.WaitForExit();
                    //File.Delete(cache + fileName + ".exe");
                    break;
            }
        }
        private async void MemoryObserver(Process process)
        {
            //await Task.Run();
        }
        private void Process_Exited(object sender, EventArgs e)
        {
            var process = (Process)sender;
            dgv[5, procID[process.Id]].Value = (process.ExitTime - process.StartTime).Milliseconds.ToString();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            var process = (Process)sender;
            // записываем память, если ошибка выловилась то записываем её
            try
            {
                dgv[4, procID[process.Id]].Value = process.PeakWorkingSet64.ToString();
            }
            catch (Exception err)
            {
                
                if (dgv[4, procID[process.Id]].Value != "")
                    dgv[4, procID[process.Id]].Value = "[ERROR]" + err.Message + "[ERROR]";
            }

            if (dgv.Rows[procID[process.Id]].Cells[0].Style.BackColor == Properties.Settings.Default.ErrorBGColor)
                return;
            //записываем выходные данные
            dgv[3, procID[process.Id]].Value += e.Data;
            // проверяем верны ли ответы с ожидаемыми ответами
            if (dgv[2, procID[process.Id]].Value.ToString() == dgv[3, procID[process.Id]].Value.ToString())
            {
                //окрашиваем всё как в смешариках
                foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                    item.Style.BackColor = Properties.Settings.Default.TrueBGColor;
            }
            else
            {
                foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                    item.Style.BackColor = Properties.Settings.Default.FalseBGColor;
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
            foreach (DataGridViewCell item in dgv.Rows[procID[process.Id]].Cells)
                item.Style.BackColor = Properties.Settings.Default.ErrorBGColor;
            //записываем бэгус
            dgv[3, procID[process.Id]].Value += "[ERROR] " + e.Data + " [ERROR] ";
            //в память пишем еррор
            dgv[4, procID[process.Id]].Value = "ERROR";
            //в время пишем еррор
            dgv[5, procID[process.Id]].Value = "ERROR";
        }
    }
}