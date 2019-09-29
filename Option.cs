using System.Collections.Generic;
using CommandLine;

namespace RoslynOpcUa
{
    public class Option
    {
        [Value(1, MetaName = "files")]
        public IEnumerable<string> Files { get; set; }
    }
}
