using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trouble
{
    internal class Player
    {
        //variables
        Random random = new Random();
        internal string playerName = "John";
        internal int PLayerAge = 2;
        internal string playerPieceColor = "Red";
        //AI info
        internal string AIName = "CPU";
        internal string AIColor = "Yellow";
        internal int AIStart;

        //constructors       
        public Player(int PlayerStart, int BoardRedStart, int BoardBlueStart, int BoardGreenStart, int BoardYellowStart)
        {
            random = new Random();
            this.playerName = PlayerName(playerName);
            this.playerName = PlayerAge(PLayerAge, playerName);
            this.playerPieceColor = PlayerInfo(playerPieceColor, PlayerStart, BoardRedStart, BoardBlueStart, BoardGreenStart, BoardYellowStart);
        }
        
        public Player(string playerPieceColor, int BoardRedStart, int BoardBlueStart, int BoardGreenStart, int BoardYellowStart)
        {
            random = new Random();
            this.AIName = AIPlayer(AIName);
            this.AIColor = AIPieceColor(playerPieceColor, AIColor, AIName, AIStart, BoardYellowStart, BoardGreenStart, BoardRedStart, BoardBlueStart);
        }
        //Gets player name
        static string PlayerName(string playerName)
        {
            //require correct info
            Console.Write("\nEnter Name... ");
            playerName = Console.ReadLine().Trim();

            while (string.IsNullOrEmpty(playerName))
            {
                Console.WriteLine("Sorry, please try again");
                playerName = Console.ReadLine().Trim();

            }
            return playerName;
        }

        //Gets age of player
        static string PlayerAge(int PLayerAge, string playerName)
        {
            Console.Write("\n\nPlease enter your age: ");
            //hold until valid info is given
            bool parse = int.TryParse(Console.ReadLine().Trim(), out PLayerAge);
            //if no age was given assign default age
            while (parse == false)
            {
                Console.WriteLine("Sorry, try again");
                parse = int.TryParse(Console.ReadLine().Trim(), out PLayerAge);
            }
            //add age to name
            playerName = playerName + "(" + PLayerAge.ToString() + ")";
            Console.WriteLine("Welcome " + playerName);
            return playerName;
        }

        //Player picks pieces
        static string PlayerInfo(string playerPieceColor, int PlayerStart, int BoardRedStart, int BoardBlueStart, int BoardGreenStart, int BoardYellowStart)
        {
            Console.Write("\n\nWhat Color Piece? (R=Red, B=Blue, G=Green, Y=Yellow)");
            playerPieceColor = Console.ReadLine().Trim().ToUpper();
            //check for characters
            if (playerPieceColor.Length > 1)
            {
                playerPieceColor = playerPieceColor.Substring(0, 1);
            }

            //check for valid response
            while (string.IsNullOrEmpty(playerPieceColor))
            {
                Console.WriteLine("Sorry, try again");
                playerPieceColor = Console.ReadLine().Trim().ToUpper();
                if (playerPieceColor.Length > 1)
                {
                    playerPieceColor = playerPieceColor.Substring(0, 1);
                }

            }
            //using a switch statement
            switch (playerPieceColor)
            {
                case "R":
                    playerPieceColor = "Red";
                    Console.WriteLine("You are red");
                    PlayerStart = BoardRedStart;
                    break;
                case "B":
                    playerPieceColor = "Blue";
                    Console.WriteLine("You are blue");
                    PlayerStart = BoardBlueStart;
                    break;
                case "G":
                    playerPieceColor = "Green";
                    Console.WriteLine("You are green");
                    PlayerStart = BoardGreenStart;
                    break;
                case "Y":
                    playerPieceColor = "Yellow";
                    Console.WriteLine("You are yellow");
                    PlayerStart= BoardYellowStart;
                    break;
                default:
                    Console.WriteLine("Incorrect, you get \"grey\"");
                    playerPieceColor = "Green";
                    PlayerStart = BoardGreenStart;
                    break;
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            return playerPieceColor;
        }



        //Figures out first player
        public static int FirstPlayer(int dice, string firstPlayer, string playerName, int PlayerTurn, string AIName)
        {
            
            if (dice < 4 && dice > 0)
            {
                firstPlayer = playerName;
                PlayerTurn = 1;
            }

            else
            {
                firstPlayer = AIName;
                PlayerTurn = 2;
            }
            Console.WriteLine("The first player is: " + firstPlayer);
            //Roll Dice
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            return PlayerTurn;
        }

        //gets AI player name
        static string AIPlayer(string AIName)
        {
            Console.Write("\n\nPlease enter a name for the AI... ");
            AIName = Console.ReadLine().Trim();

            //check for valid response
            while (string.IsNullOrEmpty(AIName))
            {
                Console.WriteLine("Sorry, try again");
                AIName = Console.ReadLine().Trim();
            }
            return AIName;
        }

        //AI color is chosen
        static string AIPieceColor(string playerPieceColor, string AIColor, string AIName, int AIStart, int BoardYellowStart, int BoardGreenStart, int BoardRedStart, int BoardBlueStart)
        {
            if (playerPieceColor == "Red")
            {
                AIColor = "Yellow";
                Console.WriteLine(AIName + " will be " + AIColor);
                AIStart = BoardYellowStart;
            }
            if (playerPieceColor == "Blue")
            {
                AIColor = "Green";
                Console.WriteLine(AIName + " will be " + AIColor);
                AIStart = BoardGreenStart;
            }
            if (playerPieceColor == "Yellow")
            {
                AIColor = "Red";
                Console.WriteLine(AIName + " will be " + AIColor);
                AIStart = BoardRedStart;
            }
            if (playerPieceColor == "Green")
            {
                AIColor = "Blue";
                Console.WriteLine(AIName + " will be " + AIColor);
                AIStart = BoardBlueStart;
            }
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
            return AIColor;
        }

    }
}
