using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE14_15
{
    internal class SetUp
    {
        
        public static void DisplayArmy(Army army)
        {
            Console.WriteLine("Soldier Attributes: " + army.TypeFighter + "\nName: " + army.Name + "\nHealth: " + army.Health + "\nDamage: " + army.Damage);
        }


        public static void DisplayMagic(Magic magic)
        {
            Console.WriteLine("Skeleton Attributes: " + magic.TypeFighter + "\nName: " + magic.Name + "\nHealth: " + magic.Health + "\nDamage: " + magic.Damage);
        }
    }
}
