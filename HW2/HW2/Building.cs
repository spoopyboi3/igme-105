using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
/*Name: HW6 - The Getaway
 *Creator: Alex Gayne
 *Date: 11/17/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished 10/14-HW3 started
 */
namespace Getaway
{
    internal class Building
    {
        //variables and properties
        const string MY_COLORS = "red,orange,blue,purple,green,yellow,white,pink";
        public string My_Colors
        {
            get { return MY_COLORS; }
        }
        int dice = 0;
        int dice2 = 0;
        int total = 0;

        public int Dice
        {
            get { return dice; }
        }
        public int Dice2
        {
            get { return dice2; }
        }
        public int Total
        {
            get { return total; }
        }


        //dictionary
        Dictionary<int, Animals> crows = new Dictionary<int, Animals>();
        
        public Dictionary<int, Animals> Crows
        {
            get { return crows; }
        }

        //front door method
        public static void FrontDoor(string PlayerName, int dice, int dice2, int total)
        {
            Random rnd = new Random();
            dice = rnd.Next(1, 7);
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You reach the front door and go to open it, but it's locked.\nWhy would it just be left unlocked?");
            Console.WriteLine("You see that there's a note on the door. It says,\n\"" + PlayerName + ", the keys should be where they always are, hope you're okay, Love, MOM\"");
            Console.WriteLine("\nYou lift up the rug in front of the door but find only a pair of dice.\n\nConfused, you look back to the note and see a second section you had somehow missed. It's in different handwriting");
            Console.WriteLine("It says,\n\"Roll the dice and with the right amount you may enter\"\nYou look around but there isn't anyone else but you. Reluctantly, you roll the dice");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            dice2 = Setup.DiceRoll(1,7,2);
            total = dice + dice2;

            if (total < 4)
            {
                Console.WriteLine("\n\nYou rolled a " + total + ", but nothing happens.\nYou go to get back in the car to leave, but the car is locked.\nYou start to panic since you never locked it.");
                Console.WriteLine("You hear a noise behind you, but before you can turn around there is a sharp pain in your back.\nYou start to feel weak, then slowly fall to the ground. The last thing you see is a crow on a branch above you");
                Setup.GameEnd();
            }
            else
            {
                Console.WriteLine("\n\nYou rolled a " + total + ". Suddenly there is a loud thud as the key hits the door.\nYou spin around to see who it was, but all you see is a single crow on a branch");
                Console.WriteLine("You feel very anxious, so you quickly grab the key, unlock the door and enter.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            Console.WriteLine("Would you like to save or quit? (S/Q)");
            string answer = Console.ReadLine().ToUpper().Trim();
            if (answer == "S")
            {
                Setup.Save(2);
            }
            if (answer == "Q")
            {
                Setup.Quit();
            }
        }

        //challenge for once the door is open
        public static void FrontDoorChallenge(char letter, int[] eyes, int[] toes, string[] name, int[] legs, int Difficulty, bool isConsumed)
        {
            Animals animals = new Animals();
            int first = Setup.DiceRoll(0,11,1);
            int second = Setup.DiceRoll(0, 11, 1);
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Upon opening the door you see " + Difficulty + " crows. How strange...");
            Console.WriteLine("Only 2 crows are actually blocking your path");
            Console.WriteLine("The left crow has " + eyes[first] + " eyes, " + legs[first] + " legs, and " + toes[first] + " toes. This must be " + name[first] + "!\n(The number for legs came from what you entered at the start)");
            Console.WriteLine("The right crow has " + eyes[second] + " eyes, " + legs[second] + " legs, and " + toes[second] + " toes. This must be " + name[second] + "!\n(The number for legs came from what you entered at the start)");
            Console.WriteLine("Both are blocking you from entering the house, and theres no way around them");
            Console.WriteLine("Maybe you should try interacting with them");
            Console.WriteLine("Please enter which crow to interact with: (L)eft or (R)ight");
            string choice = Console.ReadLine().Trim().ToUpper();
            Setup.ValidateData(choice);
            letter = choice[0];
            if (letter == 'Q')
            {
                Setup.Quit();
            }
            switch(letter)
            {
                default:
                    Setup.GameEnd();
                    break;
                //crow interaction
                case 'L':
                    Console.WriteLine("You approach " + name[first] + " as it sits and watches you intelligently. It caws at you but other than that just watches");
                    Console.WriteLine("Please choose what to do: (F)eed it, (S)hoo away or (E)at");
                    choice = Console.ReadLine().Trim().ToUpper();
                    Setup.ValidateData(choice);
                    letter =choice[0];
                    if(letter == 'F')
                    {
                        Console.WriteLine("You pull some crackers out of your pocket and toss them to the animals.\nThey happily eat them and run out the door past you.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    }
                    if(letter == 'S')
                    {
                        Console.WriteLine("You try to shoo the crow away, but it lets out a high pitched screech.\nSuddenly you are swarmed by crows and pecked to death.");
                        goto default;
                    }
                    if(letter == 'E')
                    {
                        Console.WriteLine("What's wrong with you");
                        animals.Bite(animals.ISConsumed);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You stand and wait, waiting for so long you die of old age");
                        goto default;
                    }

                //rat interaction
                case 'R':
                    Console.WriteLine("You approach " + name[second] +  " as it sits and watches with beady eyes.\nIt lets out a squawk as you approach and flaps it's wings");
                    Console.WriteLine("Please choose what to do: (F)eed it, (S)hoo away, or (E)at");
                    choice = Console.ReadLine().Trim().ToUpper();
                    Setup.ValidateData(choice);
                    letter = choice[0];
                    if (letter == 'F')
                    {
                        Console.WriteLine("You pull some crackers out of your pocket and toss them to the crows.\nThey happily eat them, but more and more show up.\nEventually there is no food left, and they swarm and eat you.");
                        goto default;
                    }
                    if (letter == 'S')
                    {
                        Console.WriteLine("You step up to " + name[second] +  " and make a loud noise while waving your arms around.\nBoth get scared off.\nYou can pass through the door now\nPress enter to continue");
                        Console.ReadLine();
                        break;
                    }
                    if (letter == 'E')
                    {
                        Console.WriteLine("What's wrong with you");
                        animals.Bite(animals.ISConsumed);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You stand and wait, waiting for so long you die of old age");
                        goto default;
                    }
            }

        }

        //color finding method for object
        public static void ColorObject(string MY_COLORS)
        {
            int firstcomma = MY_COLORS.IndexOf(',');
            int secondcomma = MY_COLORS.IndexOf(',', firstcomma + 1);
            int thirdcomma = MY_COLORS.IndexOf(',', secondcomma + 1);
            string yourColor = MY_COLORS.Substring(secondcomma + 1, thirdcomma - secondcomma - 1);
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You proceed into the hallway.");
            Console.WriteLine("You enter and flip on a light switch. In front of you is the glowing " + yourColor + " lightbulb that's always been there");
            Console.WriteLine("Why you had a " + yourColor + " lightbulb is beyond you.");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }

        //Building rooms
        public static void BldgRooms(char letter, string Character, string PlayerName, List<string> FoodList)
        {
            int fooditem = Setup.DiceRoll(0, FoodList.Count, 1);
            //player moves the house
            while (letter != 'C')
            {
                Console.Clear();
                Console.WriteLine("========================================================================================================================");
                Console.WriteLine("Looking around, you see the coat rack, shoe mat, and numerous photos lining the wall");
                Console.WriteLine("You'd almost forgotten how long it's been since " + Character + " had gone missing. The photos painfully remind you of this.");
                Console.WriteLine("Suddenly the power cuts out! You remember the generator in the basement, and try to find it.");
                Console.WriteLine("The hallway connects to the living room, study, kitchen, bathroom, or closet");
                Console.WriteLine("\nPlease select where to go: (L)iving room, (S)tudy, (K)itchen, (B)athroom, (C)loset");
                string move = Console.ReadLine().ToUpper().Trim();
                Setup.ValidateData(move);
                letter = move[0];
                if (letter == 'Q')
                {
                    Setup.Quit();
                }

                switch (letter)
                {

                    default:

                        break;


                    //living room
                    case 'L':
                        Console.Clear();
                        Console.WriteLine("========================================================================================================================");
                        Console.WriteLine("Not much has changed in the living room, the furniture is all the same.\nYou remember how everyone would crowd around the tv to watch game shows at night\nThe tv is still broken from when things got a little heated one night.");
                        Console.WriteLine("\n\nYou decide to sit on the couch for a while, listening to the grandfatherclock ticking and crows cawing outside.");
                        Console.WriteLine("Looking outside, you recall how you and " + Character + " would play in the tree out front for hours.\nYou would always have to get called in for dinner, \"" + PlayerName + ", " + Character + "! Time to eat!\"");
                        Console.WriteLine("You decide to keep moving through the rest of the house.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;

                    //study
                    case 'S':
                        Console.Clear();
                        Console.WriteLine("========================================================================================================================");
                        Console.WriteLine("In the study the walls are lined with books, and there are a few chairs around the room with end tables and lamps.\nThe desk in the corner is covered in dust from years of neglect");
                        Console.WriteLine("The chairs are a nice leather material and quite comfortable.\nYou remember reading in the chairs while dad would be working at his desk in the corner.\nEven on vacation he still had work to do.");
                        Console.WriteLine("You decide to continue moving through the house.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;

                    //kitchen
                    case 'K':
                        Console.Clear();
                        Console.WriteLine("========================================================================================================================");
                        Console.WriteLine("Moving down the hall, you pass the stairs leading to the bedrooms. No reason to go there.\nIn the kitchen there is the large dining table with many chairs surrounding it.\nYou recall all the food and desserts that were made in here, especially the pies, those were the best");
                        Console.WriteLine("\n\nThere are still some dirty dishes in the sink that were never cleaned.\nOn the table there is rotting " + FoodList[Setup.DiceRoll(0, FoodList.Count, 1)]);
                        Thread.Sleep(2000);
                        Console.WriteLine("On the stove there's some rotting " + FoodList[Setup.DiceRoll(0, FoodList.Count, 1)]);
                        Thread.Sleep(2000);
                        Console.WriteLine("In the fridge there's a few rotting " + FoodList[Setup.DiceRoll(0, FoodList.Count, 1)]);
                        Console.WriteLine("\n\nAfter seeing that you decide to leave and keep looking.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;

                    //bathroom
                    case 'B':
                        Console.Clear();
                        Console.WriteLine("========================================================================================================================");
                        Console.WriteLine("Entering the bathroom there isn't much to see. You wonder how so many people shared just one bathroom.");
                        Console.WriteLine("There's a shower, toilet and sink with a mirror above it.\nLuckily, nothing has been used for quite some time");
                        Console.WriteLine("\n\nIt's getting pretty dark, you should really find that generator.\nYou leave the bathroom and keep looking.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;

                    //closet
                    case 'C':
                        Console.Clear();
                        Console.WriteLine("========================================================================================================================");
                        Console.WriteLine("You open the closet door and see nothing but coats hanging inside. But you notice something behind the clothes...");
                        Console.WriteLine("\n\nYou remember now! Everyone was always saying to stay out of the closet, now you remember why! \nThe door to the basement is hidden in the closet! You rush over to the closet and open it.");
                        Console.WriteLine("You move aside all the clothes and see the secret door they were hiding. You open it and look down into the darkness.");
                        Console.WriteLine("Luckily, there's a flashlight hanging on the wall in front of you. You grab it and flick the switch.\n\nIt still works! you aim the beam down the stairs and decend them carefully. Now to find that generator.\n\nPress enter to continue");
                        Console.ReadLine();
                        break;
                }
                Console.WriteLine("Would you like to save or quit? (S/Q)");
                string answer = Console.ReadLine().ToUpper().Trim();
                if (answer == "S")
                {
                    Setup.Save(3);
                }
                if (answer == "Q")
                {
                    Setup.Quit();
                }
            }
        }

    }
}
