/*Name: HW2 - The Getaway
 *Creator: Alex Gayne
 *Date: 9/9/2022
 *Purpose: Make a text based adventure game
 *Modifications: 9/12 - Fixed issue with Y/N response at start, added more story, created steps puzzle and all responses 9/24- started adding content for HW2 assignment (random, nested ifs, switch, loops) 9/27-HW2 mostly finished
 */

//Git repository link: git@kgcoe-git.rit.edu:atg5699/igme-105.git
namespace Getaway
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Set player values
            string PlayerName;
            string Character;
            const int STEPS_NEEDED = 40;
            int dice = 0;
            int dice2 = 0;
            int total = 0;
            const string MY_COLORS = "red,orange,blue,purple,green,yellow,white,pink";
            string baseMove = "No";
            //Greet player
            Console.WriteLine("Welcome to THE GETAWAY");

            //Rules
            Console.WriteLine("\nIn this text based game you must choose what you want the character to do\nFor responses, please type an option from the parentheses as it is shown.\nYou can also type (Quit) at any time to exit the game");
            Console.WriteLine("\nThere will be some light obstacles/puzzles in certain sections of the game\nOther than that, the game is straightforward");
            Console.WriteLine("The game can be a little scary at certain points, so be warned");
            Console.WriteLine("\nPlease enter your name: ");
            PlayerName = Console.ReadLine().Trim();
            //get correct info
            while (string.IsNullOrEmpty(PlayerName))
            {
                Console.WriteLine("Sorry, try again");
                PlayerName = Console.ReadLine().Trim();
            }
            if (PlayerName == "Quit")
            {
                Quit();
            }
            Console.WriteLine("\nPlease enter another name: ");
            Character = Console.ReadLine().Trim();
            //get correct info
            while (string.IsNullOrEmpty(Character))
            {
                Console.WriteLine("Sorry, try again");
                Character = Console.ReadLine().Trim();
            }
            if (Character == "Quit")
            {
                Quit();
            }
            Console.Clear();
            Console.WriteLine("==========================================");
            Console.WriteLine("Player Name: " + PlayerName);
            Console.WriteLine("\nSecond Name: " + Character);
            Console.WriteLine("\nIs this correct? (Y/N)");
            string response = Console.ReadLine().ToUpper().Trim();
            char letter = response[0];
            //Display message depending on input
            if (letter == 'Y')
            {
                Console.WriteLine("\nGreat!");
            }
            if (letter == 'N')
            {
                Console.WriteLine("All this effort for nothing");
                System.Environment.Exit(0);
            }
            if (letter != 'Y')
            {
                Console.WriteLine("Sorry, I'll assume you meant Y");
            }
            if (letter == 'Q')
            {
                Quit();
            }
            //Would they like to play?
            Console.WriteLine("\nReady to start the game? (Y/N)");
            string response2 = Console.ReadLine().ToUpper().Trim();
            letter = response2[0];
            if (letter == 'Y')
            {
                Console.Clear();
            }
            if (letter == 'N')
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nC O W A R D");
                Console.ForegroundColor = ConsoleColor.White;
                System.Environment.Exit(0);
            }
            if (letter != 'Y')
            {
                Console.WriteLine("Lets just start, press enter");
                Console.ReadLine();
            }
            if (letter == 'Q')
            {
                Quit();
            }


            //Story 
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("After the funeral, you all went to hear the reading of the will.\nYou weren't really paying attention to what everyone else got.");
            Console.WriteLine("The only thing that was left to you was the old getaway place. You wonder what kind of sick joke this is.");
            Console.WriteLine("\n\nAfter a few weeks, you decide to go see how the place has been holding up for all these years.\nYou do own it now after all.");
            Console.WriteLine("You prepare some things to take with you, but aren't fully prepared to go back.\nNevertheless, you get in the car and start to drive");
            Console.WriteLine("\n\nAs you're getting closer you have to stop and get gas.\nThe store clerk says, \"You're " + PlayerName + ", right? Why would you come back here after everything that happened with " + Character + "?\"");
            Console.WriteLine("You brush the man off, and after getting gas continue the rest of the way.\n\nPress enter to continue");
            Console.ReadLine();


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
            bool success = int.TryParse(Console.ReadLine().Trim(), out Steps);
            //Move through the yard to front door
            if (Steps < STEPS_NEEDED && Steps > 0)
            {
                Console.WriteLine("You take " + Steps + " heavy steps, stop for a moment and see you're still " + (STEPS_NEEDED - Steps) + " steps away.\nYou continue up the rest of the path to the house.\n\nPress enter to continue");
            }
            if (Steps > STEPS_NEEDED)
            {
                Console.WriteLine("You were so anxious to get into the house that you ran straight into the front door.\nIf that wasn't there, you would've gone " + (Steps - STEPS_NEEDED) + " steps into the house.\n\nPress enter to continue");
            }
            if (Steps == STEPS_NEEDED)
            {
                Console.WriteLine("You walk up to the house and reach the front door without any issues, besides the feeling of dread you have.\n\nPress enter to continue");
            }
            if (Steps == 0)
            {
                Console.WriteLine("You freeze on the spot. After about half an hour you come to, still standing in place.\nYou feel like you're being watched, and rush up all " + STEPS_NEEDED + " steps to the front door.\n\nPress enter to continue");
            }
            Console.ReadLine();
            Console.Clear();

            //Front door is locked, use method
            FrontDoor(PlayerName, dice, dice2, total);

            //Make it into the house, start in lower hallway, connects to living room and study
            ColorObject(MY_COLORS);

            //Player moves through house untill reaching basement
            BldgRooms(letter, Character, PlayerName);

            //in basement, move through obstacles to generator
            BasementRooms(baseMove, letter);

            //ending sequence
            Ending(PlayerName, Character);


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
            Console.WriteLine("It says,\n\"Roll the dice and with the right amount you may enter\"\nYou look around but there isn't anyone else but you. Reluctantly, you roll the die");
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            dice2 = rnd.Next(1, 7);
            total = dice + dice2;

            if (total < 4)
            {
                Console.WriteLine("\n\nYou rolled a " + total + ", but nothing happens.\nYou go to get back in the car to leave, but the car is locked.\nYou start to panic since you never locked it.");
                Console.WriteLine("You hear a noise behind you, but before you can turn around there is a sharp pain in your back.\nYou start to feel weak, then slowly fall to the ground. The last thing you see is a crow on a branch above you");
                Console.WriteLine("\n\nGAME OVER\nPress enter to quit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("\n\nYou rolled a " + total + ". Suddenly there is a loud thud as the key hits the door.\nYou spin around to see who it was, but all you see is a single crow on a branch");
                Console.WriteLine("You feel very anxious, so you quickly grab the key, unlock the door and enter.");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
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

        //quits the game
        public static void Quit()
        {
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("So you want to quit? Ok then, thanks for playing!");
            Console.WriteLine("Press enter to exit the game");
            Console.ReadLine();
            System.Environment.Exit(0);
        }

        //Building rooms
        public static void BldgRooms(char letter, string Character, string PlayerName)
        {
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
                string move1 = Console.ReadLine().ToUpper().Trim();
                letter = move1[0];
                if (letter == 'Q')
                {
                    Quit();
                }
                while (string.IsNullOrEmpty(move1) || (letter != 'L' && letter != 'S' && letter != 'K' && letter != 'B' && letter != 'C'))
                {
                    Console.WriteLine("Invalid input, please try again");
                    move1 = Console.ReadLine().ToUpper().Trim();
                    letter = move1[0];
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
                        Console.WriteLine("\n\nThere are still some dirty dishes in the sink that were never cleaned.\nFlies and other bugs hover around what little food is left on the plates and in the trash");
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
            }
        }

        //Basement method
        public static void BasementRooms(string baseMove, char letter)
        {
            //first room
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("You make it down the steps into the basement and shine the flashlight around.\nYou see plenty of boxes that were packed up and left here, never being moved like they were supposed to be");
            Console.WriteLine("You start to move through the basement to try and find the generator.\n\nIn front of you are a mass of cobwebs. How long has it been since anyone came down here?");
            Console.WriteLine("You look and see a broom next to you, but you also have the flashlight. You have to get through them somehow.\nPlease choose what to do: (F)lashlight, (B)room, or (P)ush through");
            baseMove = Console.ReadLine().Trim().ToUpper();
            letter = baseMove[0];
            while (string.IsNullOrEmpty(baseMove) || (letter != 'F' && letter != 'B' && letter != 'P'))
            {
                Console.WriteLine("Invalid input, please try again");
                baseMove = Console.ReadLine().Trim().ToUpper();
                letter = baseMove[0];
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
                Console.WriteLine("You try to keep them away but it's too late...\n\nGAME OVER\nPress enter to quit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            if (letter == 'Q')
            {
                Quit();
            }

            //second room
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Moving to the next room, you see a dresser has fallen in front of the other door!\nYou look around and see an axe against the wall. Maybe you could chop it down...\nThere's also a dolly you could use to try and lift the dresser");
            Console.WriteLine("Please choose what to do: (A)xe, (D)olly, or (B)rute force");
            baseMove = Console.ReadLine().Trim().ToUpper();
            letter = baseMove[0];
            while (string.IsNullOrEmpty(baseMove) || (letter != 'A' && letter != 'B' && letter != 'D'))
            {
                Console.WriteLine("Invalid input, please try again");
                baseMove = Console.ReadLine().Trim().ToUpper();
                letter = baseMove[0];
            }
            if (letter == 'Q')
            {
                Quit();
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
                Console.WriteLine("\n\nYou try to just lift the dresser on your own, but it's really heavy. You decide to empty it to make things easier.\nWhen you open it, hundreds of bones fall out!\nYou scream and go to run, but you slip and fall on a ribcage.\nYou hit your head hard on the ground and die instantly");
                Console.WriteLine("\nGAME OVER\nPress enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }

            //third rooom
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("Continuing on, you walk into the next room but have to quickly stop...\nThe floor is gone! You nearly fell into a large cavern, close call.\nLooking around you see a plank of wood, but there's also a whip hanging on the wall.\nHow strange...\nYou have to get across somehow.");
            Console.WriteLine("Please choose what to do: (P)lank, (W)hip, or (J)ump");
            baseMove = Console.ReadLine().Trim().ToUpper();
            letter = baseMove[0];
            while (string.IsNullOrEmpty(baseMove) || (letter != 'P' && letter != 'W' && letter != 'J'))
            {
                Console.WriteLine("Invalid input, please try again");
                baseMove = Console.ReadLine().Trim().ToUpper();
                letter = baseMove[0];
            }
            if (letter == 'Q')
            {
                Quit();
            }
            if (letter == 'P')
            {
                Console.WriteLine("You grab the plank of wood and lay it across the gap. Stepping onto it carefully, you start to walk across.\nAt about halfway across, the plank breaks!\nYou fall for what seems like forever before hitting the ground");
                Console.WriteLine("\nGAME OVER\nPress enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
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
            letter = baseMove[0];
            while (string.IsNullOrEmpty(baseMove) || (letter != 'K' && letter != 'R' && letter != 'I'))
            {
                Console.WriteLine("Invalid input, please try again");
                baseMove = Console.ReadLine().Trim().ToUpper();
                letter = baseMove[0];
            }
            if (letter == 'Q')
            {
                Quit();
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
                Console.WriteLine("\nGAME OVER\nPress enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }

        }


        //Ending sequence
        public static void Ending(string PlayerName, string Character)
        {
            Console.Clear();
            Console.WriteLine("========================================================================================================================");
            Console.WriteLine("All of a sudden, a very loud noise, almost a roar, is heard to your right!\nYou turn and look, and are met with the most horrific creature you've ever seen!");
            Console.WriteLine("You stumble a little, but get your footing and start to run as fast as you can.\nYou run through all the rooms again, moving through the obstacles. You hear it pursuing behind you.\nYou rush through the house and out the front door, running across the yard and jumping into the car.");
            Console.WriteLine("As you start the car, you hear another roar, and look to see the creature standing at the front door looking at you.");
            Console.WriteLine("\n\nIt opens its mouth, and actually start to speak to you.\n\"Where are you going " + PlayerName + "? Don't you want to see " + Character + " again?\"");
            Console.WriteLine("You scream in horror. It can't be real, monsters don't exist.\nYou peel out of the driveway and floor it away from the house.");
            Console.WriteLine("THE END");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n\n\nThank you so much for playing! I hope you enjoyed it and weren't too scared! Please press enter to end the game");
            Console.ReadLine();
            System.Environment.Exit(0);
        }
    }
}
