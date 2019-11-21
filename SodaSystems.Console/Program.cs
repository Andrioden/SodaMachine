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
                new Soda { Name = "coke", Units = 5, UnitCost = 20 },
                new Soda { Name = "sprite", Units = 3, UnitCost = 20 },
                new Soda { Name = "fanta", Units = 3, UnitCost = 20 }
            });

            sodaMachineConsole.Start();
        }
    }
}
