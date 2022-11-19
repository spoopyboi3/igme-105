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
            Console.Clear();
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
        public static void AllInfo(int NumPlayers, Player[] Players)
        {
            Console.Clear();
            Console.WriteLine("--------------------------------------------------------------------------------------------------");
            for (int i = 0; i < NumPlayers; i++)
            {
                if (i < NumPlayers - 1)
                {
                    Console.WriteLine("Player Name: " + Players[i].PlayerNameGet + "\t\t\tPlayer Piece Color: " + Players[i].playerPieceColor);
                }
                else
                {
                    Console.WriteLine("AI Name: " + Players[i].AIName + "\t\t\t\tAI Piece Color: " + Players[i].AIColor);
                }
            }
            Console.Write("\n\nCurrent Date and Time is : ");
            DateTime now = DateTime.Now;
            Console.WriteLine(now);
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
