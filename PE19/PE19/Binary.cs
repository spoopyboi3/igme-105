using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace PE19
{
    class Binary
    {
        //creates directory for later use
        public static void CreatingDirectory()
        {
            if(!Directory.Exists("PE19"))
            {
                Directory.CreateDirectory("PE19");
            }
            
        }

        //creates plane data
        public static void CreatePlanes()
        {
            Stream stream = File.OpenWrite("PE19/plane1.dat");
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write("Fokker DR 1");
            writer.Write("Germany");
            writer.Write('D');
            writer.Write('A');
            writer.Write(1000.00);
            writer.Write(13);
            writer.Close();

            Stream stream2 = File.OpenWrite("PE19/plane2.dat");
            writer = new BinaryWriter(stream2);
            writer.Write("SPAD XIII");
            writer.Write("France");
            writer.Write('A');
            writer.Write('A');
            writer.Write(1250.50);
            writer.Write(16);
            writer.Close();

            Stream stream3 = File.OpenWrite("PE19/plane3.dat");
            writer = new BinaryWriter(stream3);
            writer.Write("Sopwith Camel");
            writer.Write("England");
            writer.Write('C');
            writer.Write('A');
            writer.Write(890.00);
            writer.Write(15);
            writer.Close();

            Stream stream4 = File.OpenWrite("PE19/plane4.dat");
            writer = new BinaryWriter(stream4);
            writer.Write("Albatros D");
            writer.Write("Germany");
            writer.Write('B');
            writer.Write('A');
            writer.Write(1575.75);
            writer.Write(15);
            writer.Close();
        }

        //prints all plane data
        public static void PrintData()
        {

            string[] array = Directory.GetFiles("PE19");
            
            foreach(string file in array)
            {
                if(file.Contains("plane"))
                {
                    BinaryReader reader = new BinaryReader(File.OpenRead(file));
                    string data = reader.ReadString();
                    string data2 = reader.ReadString();
                    char data3 =  reader.ReadChar();
                    char data4 = reader.ReadChar();
                    double data5 = reader.ReadDouble();
                    int data6 = reader.ReadInt32();
                    Console.WriteLine("Name: " + data + "\nCountry: " + data2 + "\nTurn Mode: " + data3 + "\nAttack Mode: " + data4 + "\nCost: " + data5 + "\nMax Damage: " + data6 + "\n");
                }
                
            }
            
            
        }



    }
}
