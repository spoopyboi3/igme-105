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
    internal class Yard
    {
        const int STEPS_NEEDED = 40;
        public int Steps_Needed
        {
            get { return STEPS_NEEDED; }
        }
        public static void Walking(string Character, int STEPS_NEEDED)
        {
            //Start in the yard
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You pull into the long driveway and move through the trees that hide the house.\nYou weren't expecting it to look so run down.");
            Console.WriteLine("\n\nAll the momories of this place, both good and bad, start coming back.\nYou remember how happy everyone was before " + Character + " went missing.");
            Console.WriteLine("Once every few months the family would come here on vacation. The scenic views never failed to take your breath away.");
            Console.WriteLine("The police didn't ever find " + Character + "'s body. Only their shoes were found.");
            Console.WriteLine("\n\nYou push the thought from your mind and get out of the car. \nThe cool breeze hits your face and rustles the leaves around you, almost as if the trees were speaking to you.");
            Console.WriteLine("You take a deep breath, feeling the air fill your lungs, and start walking towards the front door.\n\nPlease enter a number for how many steps you take");


            //Set up steps variable for user input
            int Steps = 0;
            int walked;
            //Move through the yard to front door
            while (Steps < STEPS_NEEDED)
            {
                bool success = int.TryParse(Console.ReadLine().Trim(), out walked);
                Steps = Steps + walked;
                Console.WriteLine("You've walked " + Steps + " steps so far");
                if (Steps >= STEPS_NEEDED)
                {
                    break;
                }
                Console.WriteLine("You still have not reached the house. Please enter a number of steps to take:");
            }
            Console.WriteLine("You walked all the way up to the house and have reached the front door, although you felt as if you were being watched\nPress enter to continue");
            Console.ReadLine();
            Console.Clear();
        }


    }
}
