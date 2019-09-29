using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace RoslynOpcUa
{
    class App
    {
        private string filename;

        public bool Parse(string[] args)
        {
            filename = "";

            var parseResult = Parser.Default.ParseArguments<Option>(args);

            if (parseResult.Tag == ParserResultType.Parsed)
            {
                var parsed = parseResult as Parsed<Option>;
                var opt = parsed.Value;
                if (opt.Files.Count() == 1)
                {
                    filename = opt.Files.ElementAt(0);
                    return true;
                }
            }
            return false;
        }

        public string Load()
        {
            if (string.IsNullOrEmpty(filename))
                return null;

            return System.IO.File.ReadAllText(filename);
        }

        public void Run(string script)
        {
            var cs = CSharpScript.Create(script).WithOptions(ScriptOptions.Default.
                WithReferences(typeof(OpcUa.OpcUaClient).Assembly));
            cs.RunAsync().Wait();
        }
    }
}
