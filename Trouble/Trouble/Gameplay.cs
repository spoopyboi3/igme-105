using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trouble
{
    internal class Gameplay
    {

        Dictionary<string, string> favcolors = new Dictionary<string, string>();
        public Dictionary<string, string> Favcolors
        {
            get { return favcolors; }
        }
        //ask for colors
        public static void FavoriteColors(Dictionary<string, string> favcolors)
        {
            string colors = "";
            Console.WriteLine("Please enter your favorite colors, you must enter at least 4");
            while(favcolors.Count <= 4)
            {
                Console.WriteLine("Enter a color:");
                string color = Console.ReadLine().Trim();
                favcolors.Add(color, colors);
            }
            while (favcolors.Count > 4 && favcolors.Count <= 8)
            {
                Console.WriteLine("Want to enter more?");
                string response = Console.ReadLine();
                if(response == "N")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter a color:");
                    string color = Console.ReadLine().Trim();
                    favcolors.Add(color, colors);
                }
            }

        }


        //list of surprises
        List<string> surprises = new List<string>();
        public static void AddSurprise(List<string> surprises)
        {
            surprises.Add(surprises[0]);
            surprises[0] = "You get attacked by aliens! Back 2 spaces";
            surprises.Add(surprises[1]);
            surprises[1] = "Fishmen attack! Back to start";
            surprises.Add(surprises[2]);
            surprises[2] = "Knights ride with you! Forward 1 space";
            surprises.Add(surprises[3]);
            surprises[3] = "Bandits hold you up! Back 3 spaces";
            surprises.Add(surprises[4]);
            surprises[4] = "Nothing happens";
            surprises.Add(surprises[5]);
            surprises[5] = "Burst of energy! Forward 2 spaces";
        }

        public List<string> Surprises
        {
            get { return surprises; }
        }


        //Rolls to move piece
        static int Move(int dice)
        {
            Random rnd = new Random();
            dice = rnd.Next(1, 7);
            return dice;
        }

        //Quits game
        static void Quit()
        {
            Console.WriteLine("The game will now end, thanks for playing!\nPress enter to exit");
            Console.ReadLine();
            System.Environment.Exit(0);
        }

        //Penalty method
        static void Penalty(int dice, int PlayerPiece1)
        {
            Random rnd = new Random();
            dice = rnd.Next(1, 7);
            Console.WriteLine("\nYou rolled a " + dice + " for the penalty roll");
            if(dice == 1)
            {
                Console.WriteLine("You got your piece transported back to start!");
                PlayerPiece1 = 0;
            }
            if (dice >1 && dice <3)
            {
                Console.WriteLine("Move back 3 spaces");
                PlayerPiece1 = PlayerPiece1 - 3;
            }
            if (dice >2 && dice <5)
            {
                Console.WriteLine("Move back 1 space");
                PlayerPiece1 = PlayerPiece1 - 1;
            }
            if (dice >4 && dice <7)
            {
                Console.WriteLine("You got lucky... no penalty");
            }
        }

        //Figures out first player
        public static int FirstPlayer(int dice, string firstPlayer, Player[] Players, int PlayerTurn)
        {

            if (dice < 3 && dice > 0)
            {
                firstPlayer = Players[0].playerName;
                PlayerTurn = 1;
            }
            if (dice <5 && dice > 2)
            {
                firstPlayer = Players[1].playerName;
                PlayerTurn = 1;
            }
            Console.WriteLine("The first player is: " + firstPlayer);
            Console.WriteLine("Press enter to start");
            Console.ReadLine();
            return PlayerTurn;
        }

        //checks if player has won
        internal static bool CheckVictory(Player[] Players, int BoardTotalMoves)
        {
            bool winner = false;
            foreach(Player player in Players)
            {
                if (player.Pieces[0] >= BoardTotalMoves && player.Pieces[1] >= BoardTotalMoves && player.Pieces[2] >= BoardTotalMoves && player.Pieces[3] >= BoardTotalMoves)
                {
                    winner = true;
                }
            }
            return winner;
        }


        //Board
        internal static void Board(string[,] Board)
        {
            for(int i = 0; i < Board.GetLength(0); i++)
            {
                for( int j = 0; j < Board.GetLength(1); j++)
                {
                    
                    if(i == 0 || i == 6 || j == 0 || j == 6)
                    {
                        Console.Write("   X");
                    }
                    else
                    {
                        Console.Write("   O");
                    }
                }
                Console.WriteLine("");
            }
            
            
        }



        //Player turn
        public static void Turn(int PlayerTurn, int BoardTotalMoves, string choice, int dice, Player[] Players, int NumPlayers, string[,] Board, List<string> surprises)
        {
            Random random = new Random();
            AddSurprise(surprises);
            //Game
            //Player turn
            Console.WriteLine("\n");
            //Check if win
                    
            while (!CheckVictory(Players, BoardTotalMoves))
            {
                        for (int i = 0; i < NumPlayers; i++)
                        {
                            if (i <= NumPlayers - 1)
                            {
                                Console.WriteLine("\n" + Players[i].playerName + "'s turn");

                                Gameplay.Board(Board);
                                Console.WriteLine("\nPress enter to roll or Q to quit");
                                choice = Console.ReadLine().ToUpper().Trim();
                                if (choice == "Q")
                                {
                                    Gameplay.Quit();
                                }
                                else
                                {
                                    dice = Gameplay.Move(dice);
                                    Console.WriteLine("You rolled a " + dice);
                                    if (dice == 6)
                                    {
                                        if (Players[i].Pieces[0] == 0)
                                        {
                                            Console.WriteLine("You moved a piece onto the board");
                                            Players[i].Pieces[0] = 1;
                                        }
                                        else if (Players[i].Pieces[1] == 0)
                                        {
                                            Console.WriteLine("You moved another piece onto the board");
                                            Players[i].Pieces[1] = 1;
                                        }
                                        else if (Players[i].Pieces[2] == 0)
                                        {
                                            Console.WriteLine("You moved another piece onto the board");
                                            Players[i].Pieces[2] = 1;
                                        }
                                        else if (Players[i].Pieces[3] == 0)
                                        {
                                            Console.WriteLine("You moved your last piece onto the board");
                                            Players[i].Pieces[3] = 1;
                                        }
                                        else
                                        {
                                            for (int j = 0; j < Players[i].Pieces.Length; j++)
                                            {
                                                if (Players[i].Pieces[j] > 0 && Players[i].Pieces[j] <= BoardTotalMoves)
                                                {
                                                    Console.WriteLine("Your piece moved " + dice + " spaces");
                                                    Players[i].Pieces[j] = Players[i].Pieces[j] + dice;
                                                    Console.WriteLine("Your piece has moved " + Players[i].Pieces[j] + " spaces");
                                                    break;
                                                }
                                            }
                                        }

                                    }
                                    //If 1, players except the one that rolled move piece onto home space
                                    if (dice == 1)
                                    {
                                        Console.WriteLine("Press enter to roll penalty die");
                                        Console.ReadLine();
                                        Gameplay.Penalty(dice, Players[i].Pieces[0]);
                                        if (Players[Players.Length - 1].Pieces[0] != 0)
                                        {
                                            Console.WriteLine(Players[Players.Length - 1].AIName + "'s piece is already on the board");
                                        }
                                        if (Players[Players.Length - 1].Pieces[0] == 0)
                                        {
                                            Console.WriteLine(Players[Players.Length - 1].AIName + "'s piece is on the board");
                                            Players[Players.Length - 1].Pieces[0] = 1;
                                        }

                                    }
                                    //if 2-5 check if piece on board can be moved, if so move that number of spaces
                                    for (int j = 0; j < Players[i].Pieces.Length; j++)
                                    {
                                        if (Players[i].Pieces[j] > 0 && Players[i].Pieces[j] <= BoardTotalMoves)
                                        {
                                            Console.WriteLine("Your piece moved " + dice + " spaces");
                                            Players[i].Pieces[j] = Players[i].Pieces[j] + dice;
                                            Console.WriteLine("Your piece has moved " + Players[i].Pieces[j] + " spaces");
                                            break;
                                        }
                                    }

                                    if (Players[i].Pieces[0] == 5 || Players[i].Pieces[0] == 10 || Players[i].Pieces[0] == 16 || Players[i].Pieces[0] == 20 || Players[i].Pieces[0] == 25)
                                    {
                                        string card = surprises[random.Next(0, 6)];
                                        Console.WriteLine(card);
                                    }

                                    Console.WriteLine("Your turn is done");
                                    
                                }

                            }


                            else if (i == NumPlayers)
                            {

                                Gameplay.Board(Board);
                                dice = Gameplay.Move(dice);
                                Console.WriteLine("\n");
                                Console.WriteLine(Players[Players.Length - 1].AIName + "'s turn");
                                Console.WriteLine(Players[Players.Length - 1].AIName + " rolled a " + dice);
                                //Check if win

                                if (dice == 6)
                                {
                                    if (Players[Players.Length - 1].Pieces[0] == 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + " moved a piece onto the board");
                                        Players[Players.Length - 1].Pieces[0] = 1;
                                    }
                                    if (Players[Players.Length - 1].Pieces[1] == 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + " moved another piece onto the board");
                                        Players[Players.Length - 1].Pieces[1] = 1;
                                    }
                                    if (Players[Players.Length - 1].Pieces[2] == 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + " moved another piece onto the board");
                                        Players[Players.Length - 1].Pieces[2] = 1;
                                    }
                                    if (Players[Players.Length - 1].Pieces[3] == 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + " moved their last piece onto the board");
                                        Players[Players.Length - 1].Pieces[3] = 1;
                                    }
                                    else
                                    {
                                        for (int j = 0; j < Players[i].Pieces.Length; j++)
                                        {
                                            if (Players[i].Pieces[j] > 0 && Players[i].Pieces[j] <= BoardTotalMoves)
                                            {
                                                Console.WriteLine("Your piece moved " + dice + " spaces");
                                                Players[i].Pieces[j] = Players[i].Pieces[j] + dice;
                                                Console.WriteLine("Your piece has moved " + Players[i].Pieces[j] + " spaces");
                                                break;
                                            }
                                        }
                                    }

                                }
                                //If 1, players except the one that rolled move piece onto home space
                                if (dice == 1)
                                {
                                    if (Players[Players.Length - 1].Pieces[0] != 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + "'s piece is already on the board");
                                    }
                                    if (Players[Players.Length - 1].Pieces[0] == 0)
                                    {
                                        Console.WriteLine(Players[Players.Length - 1].AIName + "'s piece is on the board");
                                        Players[i].Pieces[0] = 1;
                                    }

                                }
                                //if 2-5 check if piece on board can be moved, if so move that number of spaces
                                for (int j = 0; j < Players[i].Pieces.Length; j++)
                                {
                                    if (Players[i].Pieces[j] > 0 && Players[i].Pieces[j] <= BoardTotalMoves)
                                    {
                                        Console.WriteLine("Your piece moved " + dice + " spaces");
                                        Players[i].Pieces[j] = Players[i].Pieces[j] + dice;
                                        Console.WriteLine("Your piece has moved " + Players[i].Pieces[j] + " spaces");
                                        break;
                                    }
                                }
                                
                                Console.WriteLine(Players[Players.Length - 1].AIName + "'s turn is done");

                            }
                        }
            }


            Console.WriteLine("Winner!");
                    

            
        }


    }
}
