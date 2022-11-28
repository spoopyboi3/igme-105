using System;
using System.IO;
/*Creator: Alex Gayne
 *Course: IGME 105
 *Instructor: Ann Warren
 *Date: 11/28/2022
 *Purpose: Complete practice exercise #18
 *Modifications:
*/
namespace PE18 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CreateFile();
            StreamReader reader = new StreamReader("PE18.txt");
            DisplayData(reader);

        }

        //creates text file
        public static void CreateFile()
        {
            StreamWriter writer = new StreamWriter("PE18.txt");
            writer.WriteLine("Fokker DR 1,Germany,D,A,13");
            writer.WriteLine("SPAD XIII,France,A,A,16");
            writer.WriteLine("Sopwith Camel,England,C,A,15");
            writer.WriteLine("Albatros D,Germany,B,A,15");
            writer.Close();
        }

        //reads data and displays it
        public static void DisplayData(StreamReader reader)
        {
            string line;
            string[] array;

            while ((line = reader.ReadLine()) != null)
            {
               array = line.Split(",");
                Console.WriteLine("Name:" + array[0] + " Country:" + array[1] + " Turn Mode:" + array[2] + " Attack Mode:" + array[3] + " Max Damage:" + array[4]); 
            }
        }
    }
}