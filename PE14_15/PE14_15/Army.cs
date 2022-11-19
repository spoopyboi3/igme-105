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
    internal class Army: RulingClass
    {
        public Army() : base() 
        { 
            typefighter = "Army";
            Health = 50;
            Damage = 25;
        
        }

        public override void Fight(Army army)
        {
            Console.WriteLine(army.Name + " the soldier attacks and deals " + Damage + " damage");

        }
    }
}
