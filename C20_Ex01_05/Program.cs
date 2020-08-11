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

        private static String ReadInputFromUser()
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
        private static int theBiggestDigit(int i_integer)
        {
            int maxDigit = i_integer % 10;
            i_integer /= 10;
            while (i_integer > 0)
            {
                if (i_integer % 10 == 9)
                {
                    return 9;
                }


                maxDigit = Math.Max(i_integer % 10, maxDigit);

                i_integer /= 10;
            }
            return maxDigit;
        }
        private static int theSmallestDigit(int i_integer)
        {
          int minDigit = i_integer % 10;
            i_integer /= 10;
            while (i_integer > 0)
            {
                if (i_integer % 10 == 0)
                {
                    return 0;
                }

                minDigit = Math.Min(i_integer % 10, minDigit);

                i_integer /= 10;
            }
            return minDigit;

        }

        private static int numOfDigitsDividedByForWithoutReminder(int i_integer)
        {

            int numOfDividerOfFour = 0;

            while (i_integer > 0)
            {
                int nextDigit = i_integer % 10;
                i_integer /= 10;
                if (nextDigit % 4 == 0)
                {
                    numOfDividerOfFour++;
                }
            }
            return numOfDividerOfFour;
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
            String input = ReadInputFromUser();
            bool parsed = int.TryParse(input, out int parseInput);

            String satisticsFormat = String.Format("the biggest digit is {0}.{1}The smallest digit is {2}.{3}there are {4}  numbers that divided by four without a reminder.{5}there are {6} digits that are bigger than unit place digit.", theBiggestDigit(parseInput), Environment.NewLine, theSmallestDigit(parseInput), Environment.NewLine, numOfDigitsDividedByForWithoutReminder(parseInput), Environment.NewLine, numberOfDigitBiggestThanUnit(parseInput));
            Console.WriteLine(satisticsFormat);

        }


    }
}
