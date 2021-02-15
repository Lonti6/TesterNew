using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tester
{
    class TestTask
    {
        
        public string pathInput, pathOutput, pathProgram;
        /// <summary>
        /// создание экземпляра TestTask
        /// </summary>
        /// <param name="pathProgram">ссылка на программу</param>
        /// <param name="pathInput">ссылка на входные данные теста</param>
        /// <param name="pathOutput">ссылка на выходные данные теста</param>
        public TestTask(string pathProgram, string pathInput, string pathOutput)
        {
            this.pathProgram = pathProgram;
            this.pathInput = pathInput;
            this.pathOutput = pathOutput;
        }

        

        public void StartTest(){
            Process taskProcess = new Process();
            taskProcess.StartInfo.FileName = pathProgram;
            taskProcess.StartInfo.CreateNoWindow = false;
            taskProcess.StartInfo.Arguments = pathInput;
            taskProcess.Start();
        }
    }
}
