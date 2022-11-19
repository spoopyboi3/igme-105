/*Name: Trouble
 *Creator: Alex Gayne
 *Date: 8/26/2022
 *Purpose: Make Trouble video game
 *Modifications: 8/31-Completion of welcome and rules, created player, ai, die, and board int-atg 9/13 - made adjustments based on feedback, worked on PE06 9/24-PE09 finished 9/28-PE10 almost finished
 */
//Class on 10/17 extra credit: to fix the foreach section of the code you should put ref before the class name so that it can reference the information it has to search through
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Trouble
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Gameplay gameplay = new Gameplay();
            //Player info
            string[,] Board = new string[7, 7];
            
            int PlayerStart = 7;

            string choice = "Buh";
            //Board constants, shouldn't be changed for starting and ending purposes
            const int BoardYellowStart = 0;
            const int BoardRedStart = 7;
            const int BoardGreenStart = 14;
            const int BoardBlueStart = 21;
            const int BoardTotalMoves = 25;
            int PlayerTurn = 1;
            //constant cant be changed or else more players than should be able to play, program wouldn't work as intended
            Console.WriteLine("How many players?");
            int NumPlayers = 2;
            bool success = int.TryParse(Console.ReadLine().Trim(), out NumPlayers);
            const int PLAYERS = 4;
            
            while(NumPlayers > PLAYERS)
            {
                Console.WriteLine("Invalide, must be 4 or less players");
                success = int.TryParse(Console.ReadLine().Trim(), out NumPlayers);
            }

            
            //welcome player
            Setup.Welcome();
            Gameplay.FavoriteColors(gameplay.Favcolors);
            //Default creation of objects does not work now
            //create player
            //set array for max players
            Player[] Players = new Player[NumPlayers];
            
            
            for (int i = 0; i < NumPlayers; i++)
            {
                if (i < NumPlayers - 1)
                {
                    Players[i] = new Player(PlayerStart, BoardRedStart, BoardBlueStart, BoardGreenStart, BoardYellowStart);
                    
                }
                else
                {
                    Players[i] = new Player("Yellow", BoardRedStart, BoardBlueStart, BoardGreenStart, BoardYellowStart);
                    
                }
            }
           
            //display all info
            Setup.AllInfo(NumPlayers, Players);
            
            //Determine first player
            //We can use a previously created random because we can reuse one over and over again
            string firstPlayer = Players[0].playerName;
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);
            
            PlayerTurn = Gameplay.FirstPlayer(dice, firstPlayer, Players, PlayerTurn);

            
            
            //Game starts here
            Gameplay.Turn(PlayerTurn, BoardTotalMoves, choice, dice, Players, NumPlayers, Board, gameplay.Surprises);
            
        }
    }
}