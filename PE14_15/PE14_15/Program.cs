using System;
/*Creator: Alex Gayne
 * IGME 105
 * Professor: Ann Warren
 * modifications:
 *date:11/7/2022
 *task: complete requirements for PE14-15
 *given: two army men (rifle, grenade), two fantasy (skeleton and unicorn), one car (green family car)
 *github link: git@kgcoe-git.rit.edu:atg5699/igme-105.git
*/

namespace PE14_15 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Random random = new Random();
            Army army = new Army();
            Magic magic = new Magic();
            Car car = new Car();


            List <Army> list = new List <Army>();
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                list.Add(new Army());
            }
            Car[] array = new Car[3];

            List <Magic> list2 = new List <Magic>();
            for (int i = 0; i < random.Next(1, 5); i++)
            {
                list2.Add(new Magic());
            }

            SetUp.DisplayArmy(list[0]);
            SetUp.DisplayMagic(list2[0]);
            Console.WriteLine("Car Attributes: " + "\nName: " + car.Cars + "\nSpeed: " + car.Speed);

            Console.WriteLine("\n\nFighting will commence, fighter with the most health after 2 rounds wins\nPress enter to continue");
            Console.ReadLine();
            army.Fight(list[random.Next(0, list.Count)]);
            magic.Health = magic.Health - army.Damage;
            magic.Fight2(list2[random.Next(0, list2.Count)]);
            army.Health = army.Health - magic.Damage;
            army.Fight(list[random.Next(0, list.Count)]);
            magic.Health = magic.Health - army.Damage;
            magic.Fight2(list2[random.Next(0, list2.Count)]);
            army.Health = army.Health - magic.Damage;
            if(army.Health > magic.Health)
            {
                Console.WriteLine("The army wins!\nPress enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("The skeletons win!\nPress enter to exit");
                Console.ReadLine();
                System.Environment.Exit(0);
            }

        }
    }
}