/*Name: Trouble
 *Creator: Alex Gayne
 *Date: 8/26/2022
 *Purpose: Make Trouble video game
 *Modifications: 8/31-Completion of welcome and rules, created player, ai, die, and board int-atg 9/13 - made adjustments based on feedback, worked on PE06 9/24-PE09 finished 9/28-PE10 almost finished
 */

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
            //Player info
            int PlayerPiece1 = 0;
            int AIPiece1 = 0;
            int PlayerStart = 7;

            string choice = "Buh";
            //constant cant be changed or else more players than should be able to play, program wouldn't work as intended
            const int Players = 2;

            //Board constants, shouldn't be changed for starting and ending purposes
            const int BoardYellowStart = 0;
            const int BoardRedStart = 7;
            const int BoardGreenStart = 14;
            const int BoardBlueStart = 21;
            const int BoardTotalMoves = 25;
            int PlayerTurn = 0;
            //welcome player
            Setup.Welcome();

            //Default creation of objects does not work now
            //create player
            Player player = new Player(PlayerStart, BoardRedStart, BoardBlueStart, BoardGreenStart, BoardYellowStart);
            Player AI = new Player(player.playerPieceColor, BoardRedStart, BoardBlueStart, BoardGreenStart, BoardYellowStart);

            //display all info
            Setup.AllInfo(player.playerName, player.playerPieceColor, AI.AIName, AI.AIColor);
            
            //Determine first player
            //We can use a previously created random because we can reuse one over and over again
            string firstPlayer = player.playerName;
            Random rnd = new Random();
            int dice = rnd.Next(1, 7);

            PlayerTurn = Player.FirstPlayer(dice, firstPlayer, player.playerName, PlayerTurn, AI.AIName);




            //Game starts here
            Gameplay.Turn(PlayerTurn, player.playerName, PlayerPiece1, BoardTotalMoves, choice, dice, AIPiece1, AI.AIName);
            
        }
    }
}