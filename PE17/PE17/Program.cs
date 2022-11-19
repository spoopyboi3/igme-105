using System;
/*Creator: Alex Gayne
 *IGME 105
 *Instructor: Ann Warren
 *Date: 11/16/2022
 *Purpose:complete requirements for PE 17
 *Modifications:
*/

/*1. The class you specify
 *2. The method does not exist outside of warship and won't work
 *3. No because it won't fire unless the value passed in is a warship
 */
namespace PE17 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Ship ship = new Ship("Shippy", 50, 75);

            Warship warship = new Warship("Boom", 45000, 117, 7);

            Transport transport = new Transport("Evergreen", 40000, 100, 0);
            


            Console.WriteLine(ship.ToString());
            Console.WriteLine(warship.ToString());
            Console.WriteLine(transport.ToString());
            TestPoly(transport,warship,transport);
        }

        public static void TestPoly(Ship value, Warship warship, Transport transport)
        {
            if (value == warship)
            {
                Warship.Firing();
                System.Environment.Exit(0);
            }
            Console.WriteLine(value.ToString());
            
        }
    }
}