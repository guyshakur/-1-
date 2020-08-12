using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex01_05
{
    class Program
    {
        public static void Main()
        {
            PrintSatistics();
        }

        private static String readInputFromUser()
        {
            String inputFromUser;
            do
            {
                Console.WriteLine("Enter positive integer with 8 digits");
                inputFromUser = Console.ReadLine();

                if (isValidInput(inputFromUser) == false)
                {
                    Console.WriteLine("invalid input");
                }
            }
            while (isValidInput(inputFromUser) == false);

            return inputFromUser;
        }

        private static bool isValidInput(String i_inputString)
        {
            int inputIntThatParsed = parsedInt(i_inputString);

            return containsOnlyDigits(i_inputString) == true && inputIntThatParsed >= 0 && i_inputString.Length == 8;

        }

        private static int parsedInt(string i_inputString)
        {
            bool isParsed = int.TryParse(i_inputString, out int theParsedInt);
            return theParsedInt;
        }

        private static bool containsOnlyDigits(string i_inputString)
        {
            for (int i = 0; i < i_inputString.Length; i++)
            {
                char charFromInput = i_inputString.ElementAt(i);
                if (Char.IsDigit(charFromInput) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private static uint theBiggestDigitFromString(string i_String)
        {
            char charAtIndex = i_String.ElementAt(0);
            uint maxDigit = (uint)Char.GetNumericValue(charAtIndex);

            for (int i = 1; i < i_String.Length; i++)
            {
                charAtIndex = i_String.ElementAt(i);
                uint tempDigitToCompare = (uint)Char.GetNumericValue(charAtIndex);
                maxDigit= Math.Max(maxDigit, tempDigitToCompare);
            }
            return maxDigit;
        }

        private static uint theSmallestDigitFromString(string i_String)
        {
          char charAtIndex = i_String.ElementAt(0);
          uint minDigit = (uint) Char.GetNumericValue(charAtIndex);
          
            for(int i=1;i<i_String.Length;i++)
            {
                uint tempDigitToCompare = (uint) Char.GetNumericValue(charAtIndex);
                charAtIndex = i_String.ElementAt(i);
                minDigit= Math.Min(minDigit, tempDigitToCompare);

            }

           return minDigit;
        }  

        private static uint numberOfDigitsFromStringDividedWithFour(string i_String)
        {
            char charAtIndex = i_String.ElementAt(0);
            uint digitToCheck = (uint)Char.GetNumericValue(charAtIndex);
            uint numberOfDividerOfFour = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                charAtIndex = i_String.ElementAt(i);
                digitToCheck = (uint)Char.GetNumericValue(charAtIndex);
                if (digitToCheck % 4 == 0)
                {
                    numberOfDividerOfFour++;
                }

            }

           return numberOfDividerOfFour;
        }

        private static int numberOfDigitBiggestThanUnit(int i_integer)
        {
            int unit = i_integer % 10;
            int numOfDigitsBiggerThanUnit = 0;
            int theNextNumberFromInteger = 0;
            while (i_integer > 0)
            {
                i_integer /= 10;
                theNextNumberFromInteger = i_integer % 10;
                if (theNextNumberFromInteger > unit)
                {
                    numOfDigitsBiggerThanUnit++;
                }

            }
            return numOfDigitsBiggerThanUnit;
        }

        public static void PrintSatistics()
        {
            String input = readInputFromUser();
            bool parsed = int.TryParse(input, out int parseInput);

            String satisticsFormat = String.Format("the biggest digit is {0}.{1}The smallest digit is {2}.{3}there are {4}  numbers that divided by four without a reminder.{5}there are {6} digits that are bigger than unit place digit.", theBiggestDigitFromString(input), Environment.NewLine, theSmallestDigitFromString(input), Environment.NewLine, numberOfDigitsFromStringDividedWithFour(input), Environment.NewLine, numberOfDigitBiggestThanUnit(parseInput));
            Console.WriteLine(satisticsFormat);
        }
    }
}
