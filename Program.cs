using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JesseWiebe;
using System.Threading.Tasks;

namespace JesseWiebe
{
    class Program
    {

        static void Main(string[] args)
        {
            LocationNumerals ln = new LocationNumerals();
            string input;
            Console.WriteLine("Enter an integer to be converted to a location numeral: ");
            input = Console.ReadLine();
            int intInput = int.Parse(input);
            Console.WriteLine(String.Format("The integer {0} was converted to {1}", intInput, ln.IntegerToLocationNumeral(intInput)));
            Console.WriteLine("Enter a location numeral to be converted to an integer: ");
            input = Console.ReadLine();
            Console.WriteLine("The location numeral {0} was converted to  the integer value {1}", input, ln.LocationNumeralToInteger(input));
            Console.WriteLine("Enter an unorder location numeral to be sorted/reduced: ");
            input = Console.ReadLine();
            Console.WriteLine("Location Numeral {0} has been sorted to location numeral {1}.", input, ln.AbbreviateLocationNumeral(input));
            Console.ReadKey();
        }

    }
}
