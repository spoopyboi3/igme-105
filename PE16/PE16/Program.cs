using System;
/*Creator: Alex Gayne
 *Date: 11/14/2022 
 *Course: IGME 105 
 *Instructor: Ann Warren
 *Purpose: Complete requirements for PE 16
 *Modifications:
*/

namespace PE16
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            King king = new King();

            king.Row = 12;
            king.Col = 12;
            Console.WriteLine("King created at position <" + king.Row + "," + king.Col + ">, is alive: " + king.Alive);
            king.MoveUp(2, king.Row);
            Console.WriteLine("King is at position <" + king.Row + "," + king.Col + ">, is alive: " + king.Alive);
            king.MoveRight(1, king.Col);
            Console.WriteLine("King is at position <" + king.Row + "," + king.Col + ">, is alive: " + king.Alive);
            king.MoveDiagonalDR(2,2,king.Row,king.Col);
            Console.WriteLine("King is at position <" + king.Row + "," + king.Col + ">, is alive: " + king.Alive);
            Console.WriteLine("An archer has killed your king, be a better ruler next time");
            king.Alive = false;
            Console.WriteLine("Is alive: " + king.Alive);
            Console.WriteLine("Press enter to exit");
            Console.ReadLine();


        }
    }
}