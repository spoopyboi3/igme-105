using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trouble
{
    internal class Gameplay
    {

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
            Console.WriteLine("You rolled a " + dice + " for the penalty roll");
            if(dice == 1)
            {
                Console.WriteLine("You got your piece transported back to start!");
                PlayerPiece1 = 0;
            }
            if (dice >1 && dice <3)
            {
                Console.WriteLine("Nothing to see here, regular turn for you");
            }
            if (dice >2 && dice <5)
            {
                Console.WriteLine("Move an additional space!");
                PlayerPiece1 = PlayerPiece1 + 1;
            }
            if (dice >4 && dice <7)
            {
                Console.WriteLine("You hit it big! move 5 more spaces");
                PlayerPiece1 = PlayerPiece1 + 5;
            }
        }

        //Player turn
        public static void Turn(int PlayerTurn, string playerName, int PlayerPiece1, int BoardTotalMoves, string choice, int dice, int AIPiece1, string AIName)
        {
            //Game
            switch (PlayerTurn)
            {
                case 1: //Player turn
                    Console.WriteLine("\n");
                    Console.WriteLine(playerName + "'s turn");
                    //Check if win
                    while (PlayerPiece1 < BoardTotalMoves)// && PlayerPiece2 < BoardTotalMoves && PlayerPiece3 < BoardTotalMoves && PlayerPiece4 < BoardTotalMoves)
                    {
                        Console.WriteLine("Press enter to roll or Q to quit");
                        choice = Console.ReadLine().ToUpper().Trim();
                        if (choice == "Q")
                        {
                            Gameplay.Quit();
                        }
                        else
                        {
                            Console.Clear();
                            dice = Gameplay.Move(dice);
                            Console.WriteLine("You rolled a " + dice);
                            Console.WriteLine("Press enter to roll penalty die");
                            Console.ReadLine();
                            Gameplay.Penalty(dice, PlayerPiece1);
                            if (dice == 6)
                            {
                                if (PlayerPiece1 == 0)
                                {
                                    Console.WriteLine("You moved a piece onto the board");
                                    PlayerPiece1 = 1;
                                }
                                /*if (PlayerPiece2 == 0)
                                {
                                    Console.WriteLine("You moved another piece onto the board");
                                    PlayerPiece2 = 1;
                                }
                                if (PlayerPiece3 == 0)
                                {
                                    Console.WriteLine("You moved another piece onto the board");
                                    PlayerPiece3 = 1;
                                }
                                if (PlayerPiece4 == 0)
                                {
                                    Console.WriteLine("You moved your last piece onto the board");
                                    PlayerPiece4 = 1;
                                }*/
                                else
                                {
                                    Console.WriteLine("Your piece moved " + dice + " spaces");
                                    PlayerPiece1 = PlayerPiece1 + dice;
                                }
                                goto case 2;
                            }
                            //If 1, players except the one that rolled move piece onto home space
                            if (dice == 1)
                            {
                                if (AIPiece1 != 0)
                                {
                                    Console.WriteLine(AIName + "'s piece is already on the board");
                                }
                                if (AIPiece1 == 0)
                                {
                                    Console.WriteLine(AIName + "'s piece is on the board");
                                    AIPiece1 = 1;
                                }
                                goto case 2;
                            }
                            //if 2-5 check if piece on board can be moved, if so move that number of spaces
                            if (PlayerPiece1 > 0)
                            {
                                Console.WriteLine("Your piece moved " + dice + " spaces");
                                PlayerPiece1 = PlayerPiece1 + dice;
                                Console.WriteLine("Your piece has moved " + PlayerPiece1 + " spaces");
                            }
                            Console.WriteLine("Your turn is done");
                            goto case 2;
                        }



                    }

                    Console.WriteLine("You Win!");
                    break;

                case 2: //AI turn
                    dice = Gameplay.Move(dice);
                    Console.WriteLine("\n");
                    Console.WriteLine(AIName + "'s turn");
                    Console.WriteLine(AIName + " rolled a " + dice);
                    //Check if win
                    while (AIPiece1 < BoardTotalMoves)// && AIPiece2 < BoardTotalMoves && AIPiece3 < BoardTotalMoves && AIPiece4 < BoardTotalMoves)
                    {
                        if (dice == 6)
                        {
                            if (AIPiece1 == 0)
                            {
                                Console.WriteLine(AIName + " moved a piece onto the board");
                                AIPiece1 = 1;
                            }
                            /*if (AIPiece2 == 0)
                            {
                                Console.WriteLine(AIName+" moved another piece onto the board");
                                AIPiece2 = 1;
                            }
                            if (AIPiece3 == 0)
                            {
                                Console.WriteLine(AIName+" moved another piece onto the board");
                                AIPiece3 = 1;
                            }
                            if (AIPiece4 == 0)
                            {
                                Console.WriteLine(AIName+" moved their last piece onto the board");
                                AIPiece4 = 1;
                            }*/
                            else
                            {
                                Console.WriteLine(AIName + "'s piece moved " + dice + " spaces");
                                AIPiece1 = AIPiece1 + dice;
                            }
                            goto case 1;
                        }
                        //If 1, players except the one that rolled move piece onto home space
                        if (dice == 1)
                        {
                            if (PlayerPiece1 != 0)
                            {
                                Console.WriteLine(playerName + "'s piece is already on the board");
                            }
                            if (PlayerPiece1 == 0)
                            {
                                Console.WriteLine(playerName + "'s piece is on the board");
                                PlayerPiece1 = 1;
                            }
                            goto case 1;
                        }
                        //if 2-5 check if piece on board can be moved, if so move that number of spaces
                        if (AIPiece1 > 0)
                        {
                            Console.WriteLine(AIName + "'s piece moved " + dice + " spaces");
                            AIPiece1 = AIPiece1 + dice;
                            Console.WriteLine("The piece has moved " + AIPiece1 + " spaces");
                        }
                        Console.WriteLine(AIName + "'s turn is done");
                        goto case 1;
                    }

                    Console.WriteLine("You Lose!");

                    break;

                default:

                    break;

            }
        }


    }
}
