using System;
/*Name: Alex Gayne
 * IGME 105
 * Ann Warren
 * Exam #2
*/
namespace Exam2
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Config config = new Config();
            Computer computer = new Computer();
            
            //welcome player
            Config.Welcome();
            //rules
            Config.Rules();

            //Get colors for this game
            Computer.CreateCode(computer.StartingColors, computer.Colors);

            //loop 8 times or exit
            for (int i = 1; i <= config.Rounds; i++)
            {
                Console.WriteLine("Round " + i + " of 8");
                Computer.UserCheck(computer.Userguess, computer.Colors, computer.Color1, computer.Color2, computer.Color3, computer.Color4, computer.Letter);

            }

            Config.EndGame();


        }
    }
}