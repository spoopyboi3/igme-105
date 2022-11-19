using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*Name: HW5 - The Getaway
 *Creator: Alex Gayne
 *Date: 11/17/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished 10/14-HW3 started
 */
namespace Getaway
{
    internal class BlackRat: BigRat, Iedible
    {
        private bool isConsumed = false;

        public bool ISConsumed
        {
            get { return isConsumed; }
            set { isConsumed = value; }
        }

        public void Bite(bool ISConsumed)
        {
            if (isConsumed == false)
            {
                Console.WriteLine("There's still a bit left, keep going");
            }
            else
            {
                Console.WriteLine("You ate it... Monster");
            }
        }

        public bool IsConsumed()
        {
            isConsumed = true;
            return isConsumed;
        }

        const int attackSkill = 4;
        public int AttackSkill
        {
            get { return attackSkill; }
        }

        public BlackRat(): base(attackSkill)
        {
            string name = "Black rat";
        }

        public override void Attack(int attackSkill)
        {
            bool attack = IsAttackSuccessful(attackSkill);
            if (attack == true)
            {
                Console.WriteLine("The Black rat's attack was successful...");
                Console.WriteLine("The Black rat jumps at you and bites out a chunk of flesh!");
                Setup.GameEnd();
            }
            else
            {
                Console.WriteLine("The Black rat's attack failed...");
                Console.WriteLine("As it runs away it pulls all the cobwebs down! How convenient\nPress enter to continue");
            }
        }
    }
}
