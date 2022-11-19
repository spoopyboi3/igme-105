using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE17
{
    internal class Ship
    {
        private string name;
        private int weight;
        private int maxspeed;

        public string Name
        {
            get { return name; }
        }
        public int Weight
        {
            get { return weight; }
        }
        public int MaxSpeed
        {
            get { return maxspeed; }
        }

        public Ship(string name, int weight, int maxspeed)
        {
            this.name = name;
            this.weight = weight;
            this.maxspeed = maxspeed;
        }

        public override string ToString()
        {
            return string.Format("Name: "+ name + "\nWeight (in tons): " + weight + "\nMax Speed: " + maxspeed);
        }
    }
}
