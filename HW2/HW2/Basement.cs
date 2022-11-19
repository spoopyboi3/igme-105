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
    internal class Basement
    {

        string baseMove;

        public string BaseMove
        {
            get { return baseMove; }
        }
        //Basement method
        public static void BasementRooms(string baseMove, char letter, int attackSkill)
        {
            //first room
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You make it down the steps into the basement and shine the flashlight around.\nYou see plenty of boxes that were packed up and left here, never being moved like they were supposed to be");
            Console.WriteLine("You start to move through the basement to try and find the generator.\n\nIn front of you are a mass of cobwebs. How long has it been since anyone came down here?");
            Random random = new Random();
            int enemy = random.Next(1, 3);
            BigRat creature;
            if (enemy == 1)
            {
                creature = new BlackRat();
                Console.WriteLine("Before you also lays a Black Rat!");
            }
            else
            {
                creature = new BrownRat();
                Console.WriteLine("Before you also lays a Brown Rat!");
            }

            Console.WriteLine("You look and see a broom next to you, but you also have the flashlight. You have to get through them somehow.\nPlease choose what to do: (T)ouch creature, (F)lashlight, (B)room, or (P)ush through");
            baseMove = Console.ReadLine().Trim().ToUpper();
            Setup.ValidateData(baseMove);
            letter = baseMove[0];

            if(letter == 'T')
            {
                creature.Attack(attackSkill);
                Console.ReadLine();
            }
            if (letter == 'F')
            {
                Console.WriteLine("\n\nYou use the flashlight to push away the cobwebs and a few spiders fall on your arms!\nThey're small though, so you brush them off and keep moving.\nPress enter to continue");
                Console.ReadLine();
            }
            if (letter == 'B')
            {
                Console.WriteLine("\n\nYou grab the broom and push the cobwebs away, then keep moving through the basement.\nPress enter to continue");
                Console.ReadLine();
            }
            if (letter == 'P')
            {
                Console.WriteLine("\n\nYou try to push your way through the cobwebs, but they're too thick!\nYou get stuck and struggle for a while, but can't get out!\nAfter some time a swarm of spiders starts to cover you in webbing.");
                Console.WriteLine("You try to keep them away but it's too late...");
                Setup.GameEnd();
            }
            if (letter == 'Q')
            {
                Setup.Quit();
            }

            //second room
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Moving to the next room, you see a dresser has fallen in front of the other door!\nYou look around and see an axe against the wall. Maybe you could chop it down...\nThere's also a dolly you could use to try and lift the dresser");
            Console.WriteLine("Please choose what to do: (A)xe, (D)olly, or (B)rute force");
            baseMove = Console.ReadLine().Trim().ToUpper();
            Setup.ValidateData(baseMove);
            letter = baseMove[0];

            if (letter == 'Q')
            {
                Setup.Quit();
            }
            if (letter == 'A')
            {
                Console.WriteLine("\n\nYou grab the axe and start to chop up the dresser.\nAfter some time, it's small enough that you can move it and go through the door.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if (letter == 'D')
            {
                Console.WriteLine("\n\nYou grab the dolly and push it under the dresser.\nUsing your knowledge of leverage you easily move it aside and go through the door.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if (letter == 'B')
            {
                Monster monster = new Monster();
                Console.WriteLine("\n\nYou try to just lift the dresser on your own, but it's really heavy. You decide to empty it to make things easier.\nWhen you open it, hundreds of bones fall out!\nYou scream and go to run, but something grabs you!\nBefore you can react a monster bites you in half!");
                Setup.GameEnd();
            }

            //third rooom
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Continuing on, you walk into the next room but have to quickly stop...\nThe floor is gone! You nearly fell into a large cavern, close call.\nLooking around you see a plank of wood, but there's also a whip hanging on the wall.\nHow strange...\nYou have to get across somehow.");
            Console.WriteLine("Please choose what to do: (P)lank, (W)hip, or (J)ump");
            baseMove = Console.ReadLine().Trim().ToUpper();
            Setup.ValidateData(baseMove);
            letter = baseMove[0];

            if (letter == 'Q')
            {
                Setup.Quit();
            }
            if (letter == 'P')
            {
                Console.WriteLine("You grab the plank of wood and lay it across the gap. Stepping onto it carefully, you start to walk across.\nAt about halfway across, the plank breaks!\nYou fall for what seems like forever before hitting the ground");
                Setup.GameEnd();
            }
            if (letter == 'W')
            {
                Console.WriteLine("\n\nYou grab the whip hanging on the wall and see a beam hanging just above the cavern.\n\"Just like the movies.\" you think. You throw the whip and wrap it around the beam.\nAfter giving it a small tug, you leap off and swing across the cavern to the other side!");
                Console.WriteLine("You can hardly believe that worked! you continue to the next room.\nPress enter to continue");
                Console.ReadLine();
            }
            if (letter == 'J')
            {
                Console.WriteLine("You step back for a better run-up and hope for the best.\nYou run and jump across, almost falling into the cavern but making it across safely");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }

            //final room
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You've made it to the generator!");
            Console.WriteLine("You walk up to the generator and start to turn it on. As you do so, you hear what sounds like footsteps behind you.\n\nYou quickly turn around and shine the light, but there's nothing.");
            Console.WriteLine("You go back to the generator, and try to turn it on as fast as you can. More noises on your left.\nYou shine the light, but again, nothing.");
            Console.WriteLine("Please choose what to do: (K)eep trying the generator, (R)un, or (I)nvestigate noises");
            baseMove = Console.ReadLine().Trim().ToUpper();
            Setup.ValidateData(baseMove);
            letter = baseMove[0];

            if (letter == 'Q')
            {
                Setup.Quit();
            }
            if (letter == 'K')
            {
                Console.WriteLine("\n\nYou've almost got it, just a few more seconds. Your heart is practically beating out of your chest. \nEach second seems to drag for an eternity, but you finally turn it on!");
                Console.WriteLine("\n\nPlease press enter to continue");
                Console.ReadLine();
            }
            if (letter == 'R')
            {
                Console.WriteLine("\"This isn't worth it\" you think to yourself. You start to leave.");
                Console.WriteLine("\n\nPlease press enter to continue");
                Console.ReadLine();
            }
            if (letter == 'I')
            {
                Console.WriteLine("\n\nWhat could be making those noises? You walk around trying to find the source.\nLooking around, you shine the light on a horrific monster! You scream, but before you can run it grabs you!\nYou feel a sharp pain and everything goes dark...");
                Setup.GameEnd();
            }

        }


    }
}
