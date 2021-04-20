using System;
using System.CodeDom.Compiler;
using System.Windows.Forms;
using System.IO;

namespace Tester
{
    class BuildProject
    {
        private string cache = Environment.CurrentDirectory + @"\cache\";
        string fileName = null, language = null; // имя файла c расширением

        public CompilerResults CreateExe(string pathProgram)
        {
            fileName = pathProgram.Substring(pathProgram.LastIndexOf(@"\")+1);
            language = fileName.Substring(fileName.LastIndexOf(".") + 1);
            fileName = fileName.Substring(0, fileName.LastIndexOf("."));
            CodeDomProvider provider = CodeDomProvider.CreateProvider(language);
            CompilerParameters parameters = new CompilerParameters() { GenerateExecutable = false,
                GenerateInMemory = true,
                //OutputAssembly = pathProgram.Substring(pathProgram.LastIndexOf(@"\")+1),
                OutputAssembly = cache + fileName + ".exe",
                CompilerOptions = "/target:winexe" };
            CompilerResults compilerResult = provider.CompileAssemblyFromFile(parameters, pathProgram);
            //вывод ошибок
            if (compilerResult.Errors.HasErrors)
            {
                foreach (CompilerError err in compilerResult.Errors)
                {
                    MessageBox.Show("ERROR {0} :" + err.ErrorText);
                }
            }

            return compilerResult;
        }
    }
}
