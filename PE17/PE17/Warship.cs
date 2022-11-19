using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE17
{
    internal class Warship: Ship
    {
        int numguns = 6;

        public Warship(string name, int weight, int maxspeed, int numguns): base(name, weight, maxspeed)
        {
            this.numguns = numguns;
        }


        public override string ToString()
        {
            return string.Format(base.ToString() + ("\nNumber of guns: " + numguns));
        }


        public static void Firing()
        {
            Console.WriteLine("Firing 5 guns");
        }

    }
}
