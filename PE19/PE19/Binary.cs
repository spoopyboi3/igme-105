using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE19
{
    class Binary
    {


        public static void CreatePlanes()
        {
            Stream stream = File.OpenWrite("plane1.dat");
            BinaryWriter writer = new BinaryWriter(stream);
            writer.Write("Fokker DR 1");
            writer.Write("Germany");
            writer.Write('D');
            writer.Write('A');
            writer.Write(1000.00);
            writer.Write(13);
            writer.Close();

            Stream stream2 = File.OpenWrite("plane2.dat");
            writer = new BinaryWriter(stream);
            writer.Write("SPAD XIII");
            writer.Write("France");
            writer.Write('A');
            writer.Write('A');
            writer.Write(1250.50);
            writer.Write(16);
            writer.Close();

            Stream stream3 = File.OpenWrite("plane3.dat");
            writer = new BinaryWriter(stream);
            writer.Write("Sopwith Camel");
            writer.Write("England");
            writer.Write('C');
            writer.Write('A');
            writer.Write(890.00);
            writer.Write(15);
            writer.Close();

            Stream stream4 = File.OpenWrite("plane4.dat");
            writer = new BinaryWriter(stream);
            writer.Write("Albatros D");
            writer.Write("Germany");
            writer.Write('B');
            writer.Write('A');
            writer.Write(1575.75);
            writer.Write(15);
            writer.Close();
        }

        public static void PrintData()
        {
            for(int i = 0; i < 4; i++)
            {
                Directory.Exists("plane" + i + ".dat");
                Console.WriteLine("Name: " + plane1.dat[0] );
            }
        }



    }
}
