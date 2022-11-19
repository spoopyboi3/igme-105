using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Name: HW6 - The Getaway
 *Creator: Alex Gayne
 *Date: 11/17/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished 10/14-HW3 started
 */
namespace Getaway
{
    internal class BrownRat: BigRat
    {
        const int attackSkill = 2;

        public BrownRat() : base(attackSkill)
        {
            string name = "Brown rat";
        }

        public override void Attack(int attackSkill)
        {
            bool attack = IsAttackSuccessful(attackSkill);
            if (attack == true)
            {
                Console.WriteLine("The Brown rat's attack was successful...");
                Console.WriteLine("The Brown rat slaps you with its tail!");
                Setup.GameEnd();
            }
            else
            {
                Console.WriteLine("The Brown rat's attack failed...");
                Console.WriteLine("As it runs away it pulls all the cobwebs down! How convenient\nPress enter to continue");
            }
        }
    }
}
