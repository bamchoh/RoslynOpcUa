using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynOpcUa
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new App();
            if (!app.Parse(args))
            {
                Console.WriteLine("Wrong usage");
                return;
            }

            var script = app.Load();
            if (string.IsNullOrEmpty(script))
            {
                Console.WriteLine("Invalid script file");
                return;
            }

            app.Run(script);
        }
    }
}
