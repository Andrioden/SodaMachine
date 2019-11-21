using System;
using System.Collections.Generic;
using System.Text;

namespace SodaSystems.Core
{
    public class Soda
    {
        public string Name { get; set; }
        public int Units { get; set; }
        public int UnitCost { get; set; } = 20; // Default to 20 to avoid costly mistakes
    }
}
