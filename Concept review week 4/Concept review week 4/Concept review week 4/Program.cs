/*Name: Review
 *Creator: Alex Gayne
 *Date: 9/16/2022
 *Purpose: Review
 *Modifications:
 */

namespace Getaway
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string PlayerName = "Jo";
            string PlayerName2 = "John";
            //Make two AI players
            string AIName = "Jimmy";
            string AIName2 = "Joel";
            string Game;

            //Ask for player names
            Console.WriteLine("Please enter a name Player 1: ");
            PlayerName = Console.ReadLine().Trim();
            Console.WriteLine("Please enter a name Player 2: ");
            PlayerName2 = Console.ReadLine().Trim();

            //What game do they want to play
            Console.WriteLine("Please enter a name for the game you are playing: ");
            Game = Console.ReadLine().Trim();

            //Welcome to game
            Console.Clear();
            Console.WriteLine("Welcome to " + Game + "!");
            Console.WriteLine("Players are: " + PlayerName + ", " + PlayerName2 + ", " + AIName + ", and " + AIName2);
            //tell AI didn't like that
            Console.WriteLine("\n\nActually, " + AIName + " didn't like that name, so could you pick a different one?");
            Game = Console.ReadLine().Trim();


            //Welcome part 2
            Console.WriteLine("Welcome to " + Game + "! Now we can start for real.");
            //rules
            Console.WriteLine("You will roll three die, two of them will be added and then divided by the third\nPlayer with the highest result wins");
            
            Console.WriteLine("\nPress enter to determine first player");
            Console.ReadLine();
            Console.Clear();

            //roll number to determine first player
            Random rnd = new Random();
            int dice1 = rnd.Next(1, 6);
            int dice2 = rnd.Next(1, 6);
            int dice3 = rnd.Next(1, 6);
            int result1;
            int result2;
            int result3;
            int result4;
            int winner;
            string firstPlayer = PlayerName;
            string secondPlayer = PlayerName2; 
            
            
            if (dice1 < 3 && dice1 > 0)
            {
                firstPlayer = PlayerName;
                secondPlayer = PlayerName2;
                
            }

            if (dice1 > 2 && dice1 < 5)
            {
                firstPlayer = PlayerName2;
                secondPlayer = PlayerName;
            }
            else
            {
                firstPlayer = PlayerName;
                secondPlayer= PlayerName2;
            }
            


            Console.WriteLine("The first player is " + firstPlayer);
            Console.WriteLine("The second player is " + secondPlayer);
            Console.WriteLine("The third player is " + AIName);
            Console.WriteLine("The fourth player is " + AIName2);
            //roll three die, add first two, divide by third
            //if result = 0, roll three again and double first if less than 6
            
            //first player
            Console.WriteLine(firstPlayer + " , press enter to roll the dice");
            Console.ReadLine();
            dice1 = rnd.Next(1,6);
            dice2 = rnd.Next(1,6);
            dice3 = rnd.Next(1, 6);
            Console.WriteLine("You rolled a " + dice1 + ", " + dice2 + ", and a " + dice3);
            result1 = (dice1 + dice2) / dice3;

            if (result1 == 0)
            {
                Console.WriteLine(firstPlayer + ", you got a zero, please roll again");
                Console.ReadLine();
                if (dice1 < 6)
                {
                    dice1 = dice1 * 2;
                    result1 = (dice1 +dice2) / dice3;
                    Console.WriteLine(firstPlayer + " got a " + result1);
                }
                
                else
                {
                    result1 = (dice1 +dice2) / dice3;
                    Console.WriteLine(firstPlayer + ", you got " + result1);
                }

                
            }
            else
            {
                Console.WriteLine(firstPlayer + ", you got a " + result1);
            }


            //second player
            Console.WriteLine(secondPlayer + " , press enter to roll the dice");
            Console.ReadLine();
            dice1 = rnd.Next(1, 6);
            dice2 = rnd.Next(1, 6);
            dice3 = rnd.Next(1, 6);
            Console.WriteLine("You rolled a " + dice1 + ", " + dice2 + ", and a " + dice3);
            result2 = (dice1 + dice2) / dice3;

            if (result2 == 0)
            {
                Console.WriteLine(secondPlayer + ", you got a zero, please roll again");
                Console.ReadLine();
                if (dice1 < 6)
                {
                    dice1 = dice1 * 2;
                    result2 = (dice1 + dice2) / dice3;
                    Console.WriteLine(secondPlayer + " got a " + result2);
                }

                else
                {
                    result2 = (dice1 + dice2) / dice3;
                    Console.WriteLine(secondPlayer + ", you got " + result2);
                }


            }
            else
            {
                Console.WriteLine(secondPlayer + ", you got a " + result2);
            }

            if(result1>result2)
            {
                winner = result1;
            }
            else
            {
                winner = result2;
            }

            //third player
            Console.WriteLine(AIName + " , press enter to roll the dice");
            Console.ReadLine();
            dice1 = rnd.Next(1, 6);
            dice2 = rnd.Next(1, 6);
            dice3 = rnd.Next(1, 6);
            Console.WriteLine("You rolled a " + dice1 + ", " + dice2 + ", and a " + dice3);
            result3 = (dice1 + dice2) / dice3;

            if (result3 == 0)
            {
                Console.WriteLine(AIName + ", you got a zero, please roll again");
                Console.ReadLine();
                if (dice1 < 6)
                {
                    dice1 = dice1 * 2;
                    result3 = (dice1 + dice2) / dice3;
                    Console.WriteLine(AIName + " got a " + result3);
                }

                else
                {
                    result3 = (dice1 + dice2) / dice3;
                    Console.WriteLine(AIName + ", you got " + result3);
                }


            }
            else
            {
                Console.WriteLine(AIName + ", you got a " + result3);
            }

            if(result3>winner)
            {
                winner = result3;
            }

            //fourth player
            Console.WriteLine(AIName2 + " , press enter to roll the dice");
            Console.ReadLine();
            dice1 = rnd.Next(1, 6);
            dice2 = rnd.Next(1, 6);
            dice3 = rnd.Next(1, 6);
            Console.WriteLine("You rolled a " + dice1 + ", " + dice2 + ", and a " + dice3);
            result4 = (dice1 + dice2) / dice3;

            if (result4 == 0)
            {
                Console.WriteLine(AIName2 + ", you got a zero, please roll again");
                Console.ReadLine();
                if (dice1 < 6)
                {
                    dice1 = dice1 * 2;
                    result4 = (dice1 + dice2) / dice3;
                    Console.WriteLine(AIName2 + " got a " + result4);
                }

                else
                {
                    result4 = (dice1 + dice2) / dice3;
                    Console.WriteLine(AIName2 + ", you got " + result4);
                }


            }
            else
            {
                Console.WriteLine(AIName2 + ", you got a " + result4);
            }
            
            if(result4>winner)
            {
                winner = result4;
            }
            
            

            //determine winner by highest roll

            if(winner == result1)
            {
                Console.WriteLine("The winner is " + firstPlayer);
            }

            if(winner == result2)
            {
                Console.WriteLine("The winner is " + secondPlayer);
            }
            
            if(winner==result3)
            {
                Console.WriteLine("The winner is " + AIName);
            }
            if(winner==result4)
            {
                Console.WriteLine("The winner is " + AIName2);
            }




        }
    }
}