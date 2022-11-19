using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Creator: Alex Gayne
 * IGME 105
 * Professor: Ann Warren
 * modifications:
 *date:11/7/2022
 *task: complete requirements for PE14-15
 *given: two army men (rifle, grenade), two fantasy (skeleton and unicorn), one car (green family car)
 *github link: git@kgcoe-git.rit.edu:atg5699/igme-105.git
*/
namespace PE14_15
{
    abstract class RulingClass
    {
        string name;
        //parent class
        public RulingClass()
        {
            Console.WriteLine("Enter a name for your soldier");
            name = Console.ReadLine().Trim();
        }
        public string Name { get { return name; } }
        int health;
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        protected string typefighter;
        public string TypeFighter
        {
            get { return typefighter; }
            set { typefighter = value; }
        }
        int damage;
        public int Damage
        {
            get { return damage; }
            set
            {
                damage = value;
            }
        }
        public virtual void Fight2(Magic magic)
        {
            Console.WriteLine(magic.Name + " the skeleton attacks and deals " + Damage + " damage.");
        }
        public abstract void Fight(Army army);
        

    }
}
