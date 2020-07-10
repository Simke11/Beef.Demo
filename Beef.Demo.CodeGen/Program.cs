using Beef.CodeGen;
using System;
using System.Threading.Tasks;

namespace Beef.Demo.CodeGen
{
    class Program
    {
        static Task<int> Main(string[] args)
        {
            return CodeGenConsoleWrapper.Create("Beef", "Demo").Supports(entity: true, refData: true).RunAsync(args);
        }
    }
}
