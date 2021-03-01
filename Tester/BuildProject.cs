using System.CodeDom.Compiler;
using System.Windows.Forms;

namespace Tester
{
    class BuildProject
    {
        public CompilerResults CreateExe(string pathProgram)
        {
            CodeDomProvider provider = CodeDomProvider.CreateProvider("cs");
            CompilerParameters parameters = new CompilerParameters() { GenerateExecutable = false,
                GenerateInMemory = true,
                //OutputAssembly = pathProgram.Substring(pathProgram.LastIndexOf(@"\")+1),
                OutputAssembly = "test.exe",
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
