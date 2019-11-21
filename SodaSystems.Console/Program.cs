using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SodaSystems.Core;

namespace SodaSystems.Console
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            SodaMachineConsole sodaMachineConsole = new SodaMachineConsole();
            sodaMachineConsole.Start();
        }
    }
}
