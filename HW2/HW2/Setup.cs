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
    internal class Setup
    {
        
        
        //start new game or load progress
        public static int NewGame()
        {
            try
            {
                Console.WriteLine("Start a new game or load previous save? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    return Setup.Load();
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }

        //save progress
        public static void Save(int progress)
        {
            try
            {
                Console.WriteLine("Saving will overwrite your previous save, are you sure? (Y/N)");
                string response = Console.ReadLine().ToUpper();
                if (response == "Y")
                {
                    StreamWriter writer = new StreamWriter("HW2Save.txt");
                    writer.WriteLine(progress.ToString());
                    writer.Close();
                    Console.WriteLine("Success, enter to continue");
                    Console.ReadLine();
                }
            }
            catch
            {
                Console.WriteLine("Your funeral... enter to continue");
                Console.ReadLine();
            }
        }

        //load progress
        public static int Load()
        {
            try
            {
                StreamReader reader = new StreamReader("HW2Save.txt");
                int progress;
                int.TryParse(reader.ReadLine(), out progress);
                reader.Close();
                return progress;
            }
            catch { return 0; }
        }


        string character = "John";
        public string Character
        {
            get { return character; }
            set { character = value; }
        }
        string playername = "Jo";
        char letter = 'Y';
        public char Letter
        {
            get { return letter; }
            set { letter = value; }
        }
        public string PlayerName
        {
            get {return playername;}
            set { playername = value; }
        }
        //array and properties for user numbers
        int[] numbers = new int[10];
        public int[] Numbers
        {
            get {return numbers;}
        }


        static List<string> Foodlist = new List<string>();

        public List<string> FoodList
        {
            get { return Foodlist; }
        }

        int difficulty = 2;
        public int Difficulty
        {
            get { return difficulty; } 
            
            set { difficulty = value; } 
        }
        

        //difficulty method
        public static int DifficultyChoice(int difficulty, Dictionary<int, Animals> crows)
        {

            Console.WriteLine("Please select a difficulty level (enter 1, 2, or 3): ");
            bool success = int.TryParse(Console.ReadLine().Trim(), out difficulty);
            if (difficulty == 1)
            {
                crows.Add(1, new Animals());
            }
            if (difficulty == 2)
            {
                crows.Add(2, new Animals());
            }
            else if (difficulty == 3)
            {
                crows.Add(3, new Animals());
            }
            return difficulty;
        }


        //get list of food from user
        public static void UserItemInput(List<string> FoodList, char letter)
        {
            Console.WriteLine("Please enter some foods you like. You must enter at least 4\nThis will be used later");
            string item = Console.ReadLine();
            Setup.ValidateData(item);
            FoodList.Add(item);
            while (FoodList.Count < 4)
            {
                Console.WriteLine("Please enter another food item:");
                item = Console.ReadLine();
                Setup.ValidateData(item);
                FoodList.Add(item);
            }
            while (letter != 'N')
            {
                Console.WriteLine("Would you like to add more items: (Y/N)");
                string answer = Console.ReadLine().ToUpper().Trim();
                Setup.ValidateData(answer);
                letter = answer[0];
                //Display message depending on input
                if (letter == 'Y')
                {
                    Console.WriteLine("Please enter another food item:");
                    item = Console.ReadLine();
                    Setup.ValidateData(item);
                    FoodList.Add(item);
                }
                if (letter == 'N')
                {
                    Console.WriteLine("Ok, lets continue");
                    break;
                }
            }
            Console.WriteLine("You entered: ");
            foreach(string items in FoodList)
            {
                Console.WriteLine(items);
            }
        }


        //get info from user
        public static int[] GatherData(int[] numbers, int[] legs, char letter)
        {
            Console.WriteLine("We will now collect some data to personalize the game to you more\nYou must enter 10 numbers");
            for(int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Numbers entered: " + i + " of " + numbers.Length);
                bool success = int.TryParse(Console.ReadLine().Trim(), out numbers[i]);
                legs[i] = numbers[i];
            }
            Console.WriteLine("You have given:\n" + numbers[0]);
            Console.WriteLine(numbers[1]);
            Console.WriteLine(numbers[2]);
            Console.WriteLine(numbers[3]);
            Console.WriteLine(numbers[4]);
            Console.WriteLine(numbers[5]);
            Console.WriteLine(numbers[6]);
            Console.WriteLine(numbers[7]);
            Console.WriteLine(numbers[8]);
            Console.WriteLine(numbers[9]);

            Setup.UserItemInput(Foodlist, letter);
            return numbers;
        }


        //Dice roll method
        public static int DiceRoll(int start, int end, int multiplier)
        {
            Random random = new Random();
            int sides = random.Next(start, end);
            return sides*multiplier/multiplier;
        }


        //Validate data entered by user
        public static string ValidateData(string entry)
        {
            string response = entry;
            while(string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Invalid entry, please try again");
                response = Console.ReadLine().Trim().ToUpper();
            }
            return response;
        }

        //get player name
        public static string GetPlayer(string PlayerName)
        {
            Console.WriteLine("\nPlease enter your name: ");
            PlayerName = Console.ReadLine().Trim();
            //get correct info
            Setup.ValidateData(PlayerName);
            if (PlayerName == "Quit")
            {
                Setup.Quit();
            }
            return PlayerName;
        }

        //gets second name
        public static string GetCharacter(string Character)
        {
            Console.WriteLine("\nPlease enter another name: ");
            Character = Console.ReadLine().Trim();
            //get correct info
            Setup.ValidateData(Character);
            if (Character == "Quit")
            {
                Setup.Quit();
            }
            return Character;
            Console.Clear();
        }

        //Welcome to game
        public static void Welcome()
        {
            //Greet player
            Console.WriteLine("Welcome to THE GETAWAY");

            //Rules
            Console.WriteLine("\nIn this text based game you must choose what you want the character to do\nFor responses, please type an option from the parentheses as it is shown.\nYou can also type (Quit) at any time to exit the game");
            Console.WriteLine("\nThere will be some light obstacles/puzzles in certain sections of the game\nOther than that, the game is straightforward");
            Console.WriteLine("The game can be a little scary at certain points, so be warned");
        }


        //Story introduction
        public static void Intro(string PlayerName, string Character, char letter)
        {
            Console.WriteLine("==========================================");
            Console.WriteLine("Player Name: " + PlayerName);
            Console.WriteLine("\nSecond Name: " + Character);
            Console.WriteLine("\nIs this correct? (Y/N)");
            string answer = Console.ReadLine().ToUpper().Trim();
            Setup.ValidateData(answer);
            letter = answer[0];
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
                Setup.Quit();
            }
            //Would they like to play?
            Console.WriteLine("\nReady to start the game? (Y/N)");
            answer = Console.ReadLine().ToUpper().Trim();
            Setup.ValidateData(answer);
            letter = answer[0];
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
                Setup.Quit();
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
            Console.WriteLine("You brush the man off, and after getting gas continue the rest of the way.\n\n");
            Console.WriteLine("Would you like to save or quit? (S/Q)");
            answer = Console.ReadLine().ToUpper().Trim();
            if(answer == "S")
            {
                Setup.Save(1);
            }
            if(answer == "Q")
            {
                Setup.Quit();
            }
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

        //Game end method
        public static void GameEnd()
        {
            Console.WriteLine("GAME OVER\nPress enter to quit");
            Console.ReadLine();
            System.Environment.Exit(0);
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
