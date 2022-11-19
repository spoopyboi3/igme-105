using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2
{
    internal class Computer
    {
        //list of colors
        List <string> colors = new List<string>();
        //property for use in main
        public List<string> Colors
        {
            get { return colors; }
        }

        //possible colors
        string[] startingcolors = new string[4] {"R", "B", "G", "Y"};
        //user guess array
        string[] guess = new string[4];
        //properties
        public string[] StartingColors
        {
            get { return startingcolors; }
        }

        string userguess;
        public string Userguess
        {
            get { return userguess; }
        }
        //selects random colors
        public static string SelectColor(string[] StartingColors)
        {
            //Random created
            Random random = new Random();
            int number = random.Next(0, 4);
            string chosencolor = StartingColors[number];
            return chosencolor;
        }

        //Method to fill list for this game
        public static void CreateCode(string[] StartingColors, List<string> Colors)
        {
            for (int i = 0; i < 4;)
            {
                i++;
                Colors.Add(SelectColor(StartingColors));
                bool success = true;
            }
            Console.WriteLine("Colors for this game have been chosen!\nPress enter to continue");
            Console.ReadLine();
        }

        //Validate data entered by user
        public static string ValidateData(string entry)
        {

            string response = entry;
            
            while (string.IsNullOrEmpty(response))
            {
                Console.WriteLine("Invalid entry, please try again");
                response = Console.ReadLine().Trim().ToUpper();
            }
            
            return response;
        }


        //color values for T or F
        string color1;
        string color2;
        string color3;
        string color4;
        //properties to be used in main
        public string Color1
        {
            get { return color1; }
        }
        public string Color2
        {
            get { return color2; }
        }
        public string Color3
        {
            get { return color3; }
        }
        public string Color4
        {
            get { return color4; }
        }

        //variable for taking first letter
        char letter;
        //property for main
        public char Letter
        {
            get { return letter; }
        }
        //Method for user guessing
        public static void UserCheck(string userguess, List<string> colors, string color1, string color2, string color3, string color4, char letter)
        {
            Console.WriteLine("Please enter your first guess:");
            userguess = Console.ReadLine().Trim().ToUpper();
            ValidateData(userguess);
            letter = userguess[0];
            while (letter != 'R' && letter != 'B' && letter != 'G' && letter != 'Y')
            {
                Console.WriteLine("Invalid entry, try again");
                userguess = Console.ReadLine().Trim().ToUpper();
                ValidateData(userguess);
                letter = userguess[0];
            }
            if (userguess == colors[0])
            {
                color1 = "T";
            }
            else
            {
                color1 = "F";
            }
            Console.WriteLine("Please enter your second guess:");
            userguess = Console.ReadLine().Trim().ToUpper();
            ValidateData(userguess);
            letter = userguess[0];
            while (letter != 'R' && letter != 'B' && letter != 'G' && letter != 'Y')
            {
                Console.WriteLine("Invalid entry, try again");
                userguess = Console.ReadLine().Trim().ToUpper();
                ValidateData(userguess);
                letter = userguess[0];
            }
            if (userguess == colors[1])
            {
                color2 = "T";
            }
            else
            {
                color2 = "F";
            }
            Console.WriteLine("Please enter your third guess:");
            userguess = Console.ReadLine().Trim().ToUpper();
            ValidateData(userguess);
            letter = userguess[0];
            while (letter != 'R' && letter != 'B' && letter != 'G' && letter != 'Y')
            {
                Console.WriteLine("Invalid entry, try again");
                userguess = Console.ReadLine().Trim().ToUpper();
                ValidateData(userguess);
                letter = userguess[0];
            }
            if (userguess == colors[2])
            {
                color3 = "T";
            }
            else
            {
                color3 = "F";

            }
            Console.WriteLine("Please enter your fourth guess:");
            userguess = Console.ReadLine().Trim().ToUpper();
            ValidateData(userguess);
            letter = userguess[0];
            while (letter != 'R' && letter != 'B' && letter != 'G' && letter != 'Y')
            {
                Console.WriteLine("Invalid entry, try again");
                userguess = Console.ReadLine().Trim().ToUpper();
                ValidateData(userguess);
                letter = userguess[0];
            }
            
            if (userguess == colors[3])
            {
                color4 = "T";

            }
            else
            {
                color4 = "F";

            }

            Console.WriteLine("Here's what's right so far (T is correct, F is incorrect): " + color1 + " " +color2 +  " " +color3 + " " +color4);
            
            CheckWin(color1, color2, color3, color4);
            Console.WriteLine("Keep trying!\nPress enter to continue");
            Console.ReadLine();
        }


        //checks if user has won
        public static void CheckWin(string color1, string color2, string color3, string color4)
        {
            if (color1 == "T" && color2 == "T" && color3 == "T" && color4 == "T")
            {
                Console.WriteLine("You Win!\nPress enter to close the game");
                Console.ReadLine();
                System.Environment.Exit(0);

            }
            
        }

    }
}
