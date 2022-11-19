using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE17
{
    internal class Transport: Ship
    {
        double maxcargo;
        public double Maxcargo
        {
            get { return maxcargo; }
            set { maxcargo = value; }
        }
        public Transport(string name, int weight, int maxspeed, double Maxcargo) : base(name, weight, maxspeed)
        {
            FindMax(Maxcargo, weight);
        }

        public void FindMax(double Maxcargo, int weight)
        {
            maxcargo = weight * .4;
        }

        public override string ToString()
        {
            return string.Format(base.ToString() + ("\nMax Cargo (in tons): " + Maxcargo));
        }

    }
}
