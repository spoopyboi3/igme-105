using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trouble
{
    internal class Setup
    {
        //Welcomes player
        public static void Welcome()
        {
            //Welcome
            Console.WriteLine("\tWelcome to Trouble!\n\tTotally different than Sorry!");
            //Rules
            Console.WriteLine("-----------------------------RULES----------------------------");
            Console.WriteLine("Be the first to get all your pieces into your Home Base\nRoll the die to move your piece. A 6 is needed to move from home base\nA 1 puts an opponents piece on their start space\nWatch out for opponents pieces that can send you back to start!");
            Console.Write("Press ENTER to start");
            Console.ReadLine();
            Console.Clear();
        }

        //Displays all info for players and AI
        public static void AllInfo(string playerName, string playerPieceColor, string AIName, string AIColor)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            Console.WriteLine("Player Name: " + playerName + "\t\t\tPlayer Piece Color: " + playerPieceColor);
            Console.WriteLine("AI Name: " + AIName + "\t\t\t\tAI Piece Color: " + AIColor);
            Console.Write("\n\nCurrent Date and Time is : ");
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
