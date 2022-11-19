/*Name: PE05
 *Creator: Alex Gayne
 *Date: 9/9/2022
 *Purpose: Use the math class to complete assignment
 *Modifications:
 */

namespace PE05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Math Class portion

            double a = 30;
            // converting value to radians
            double b = (a * (Math.PI)) / 180;

            double c = 60;
            double d = (c * (Math.PI)) / 180;
            Console.WriteLine("Sine of 30 degrees is " + b);
            Console.WriteLine("\nCosine of 60 degrees is " + d);
            
            double e = 7;
            double f = Math.Pow(e,6);
            Console.WriteLine("\n7 to the sixth power is " + f);

            int max3 = Math.Max(30, Math.Max(20, 25));
            Console.WriteLine("\nThe Maximum of 20, 25 and 30 is " + max3);

            Console.WriteLine("\n9876.4321 as an integer is " + Math.Truncate(9876.4321));

            double g = 78.688;
            Console.WriteLine("\n78.688 rounded is " + Math.Round(g));

            //String Class portion
            Console.ReadLine();
            Console.Clear();
            //string created
            string s = "The user interface designers of Windows 10 should be ";
            Console.WriteLine(s);
            string answer = Console.ReadLine();
            //user response added to phrase
            Console.WriteLine(s + answer);
            //objectives
            Console.WriteLine("\nIs there a z in the phrase? " + s.IndexOf('z') + " There is not");
            
            Console.WriteLine("\nWhere is ther an s? " + s.IndexOf('s') + " spaces in");
            
            Console.WriteLine("\nWhere is the fourth word? " + s.IndexOf("designers"));

            Console.WriteLine("\nThe phrase is " + s.Length + " characters long\n");

            Console.WriteLine(s.ToLower());

            Console.WriteLine(s.ToUpper());
            Console.ReadLine();
            Console.Clear();

            //String Formatting portion
            const double tax = .825;
            Console.WriteLine("How much would you pay for a sub?");
            
            string price = Console.ReadLine();
            int numericvalue;
            bool isNumber = int.TryParse(price, out numericvalue);
            double actualprice = int.Parse(price);
            
            actualprice = actualprice + .12;
            Console.WriteLine(actualprice + " is what you would be paying without taxes");
            double combined;
            combined = actualprice * tax;
            actualprice = actualprice + combined;
            Console.WriteLine(actualprice + " is what youd pay with tax");
            
        }
    }
}