using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JesseWiebe
{
    class LocationNumerals
    {
        //originally was going to implement this using ascii encoding but
        //decided that creating a char array would be more efficient not 
        //having to repeatedly call an ascii conversion
        private char[] Alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

        /// <summary>
        /// takes in an integer value and gives back the location numeral
        /// string, via binary conversion
        /// </summary>
        /// <param name="inputValue">integer to be converted</param>
        /// <returns>location numeral</returns>
        public string IntegerToLocationNumeral(int inputValue)
        {
            string returnValue = "";
            char[] binaryArray = Convert.ToString(inputValue, 2).ToCharArray();
            int count = 0;
            Array.Reverse(binaryArray);

            foreach (char c in binaryArray)
            {
                if (c.Equals('1'))
                {
                    returnValue += Alphabet[count];
                }
                count++;
            }

            return returnValue;
        }

        /// <summary>
        /// converts a location numerical from a set of characters to an integer value
        /// utilizes an array corresponding to the alphabet to correctly assign
        /// values to find the correct power
        /// </summary>
        /// <param name="inputValue">a set of characters representing location 
        /// numerals</param>
        /// <returns>the integer value of the numerals</returns>
        public int LocationNumeralToInteger(string inputValue)
        {
            char[] values = inputValue.ToCharArray();
            int returnValue = 0;
            int power = 0;

            foreach (char v in values)
            {
                power = Array.IndexOf(Alphabet, v);
                returnValue += (int)Math.Pow(2, power);
            }


            return returnValue;
        }

        /// <summary>
        /// utilizes the above private methods i created to convert a 
        /// location from unordered to ordered as well as removing duplicates
        /// </summary>
        /// <param name="inputValue">string representing the unordered location numerals</param>
        /// <returns>string representing the ordered location numerals</returns>
        public string AbbreviateLocationNumeral(string inputValue)
        {
            int total = LocationNumeralToInteger(inputValue);

            return IntegerToLocationNumeral(total);
        }
    }
}
