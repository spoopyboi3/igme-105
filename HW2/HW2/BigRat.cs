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
    abstract class BigRat
    {
        private int attackSkill;

        public BigRat(int attackSkill)
        {
            this.attackSkill = attackSkill;
            
        }

        public abstract void Attack(int attackSkill);

        protected bool IsAttackSuccessful(int attackSkill)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            if(attackSkill >= dice)
            {
                return true;
            }
            return false;
        }


    }
}
