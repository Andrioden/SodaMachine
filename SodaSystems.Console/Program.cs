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
            SodaMachineConsole sodaMachineConsole = new SodaMachineConsole(new List<Soda>
            {
                new Soda { Name = "coke", Amount = 5 },
                new Soda { Name = "sprite", Amount = 3 },
                new Soda { Name = "fanta", Amount = 3 }
            });

            sodaMachineConsole.Start();
        }
    }
}
