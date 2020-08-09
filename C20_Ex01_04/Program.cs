using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;



namespace C20_Ex01_04
{
    class Program
    {
        public static void Main()
        {
            PrintTheSatistics();
        }

        public static String ReadStringFromUser()
        {
            String inputFromUser;
            do
            {
                Console.WriteLine("Enter text with only english letters or only digits");
                inputFromUser = Console.ReadLine();




                if (IsValidInput(inputFromUser) == false)
                {
                    Console.WriteLine("invalid input");
                }

            }

            while (IsValidInput(inputFromUser) == false);


            return inputFromUser;

        }

        private static bool IsContainsNonAbc(string inputFromUser)
        {
            return true;
        }

        private static bool IsTheStringContainsLetters(String i_String)
        {
            for (int i = 0; i < i_String.Length; i++)
            {
                char charFromString = i_String.ElementAt(i);

                if (Char.IsLetter(charFromString) == true)
                {
                    return true;

                }

            }
            return false;
        }
        private static bool IsTheTextContainsDigits(String i_String)
        {
            for (int i = 0; i < i_String.Length; i++)
            {
                char charFromString = i_String.ElementAt(i);

                if (Char.IsDigit(charFromString) == true)
                {
                    return true;

                }

            }
            return false;
        }

        private static bool IsPalindrome(String i_String)
        {
            if (i_String.Length <= 1)
            {
                return true;
            }
            else if (i_String.ElementAt(0) != i_String.ElementAt(i_String.Length - 1))
            {
                return false;
            }
            else
            {
                return IsPalindrome(i_String.Substring(1, i_String.Length - 2));
            }





        }

        private static bool IsValidInput(String i_string)
        {

            if ((HasEnglishLetters(i_string) == false) && (IsTheTextContainsDigits(i_string) == false)
                || (IsTheTextContainsDigits(i_string) == true) && IsTheStringContainsLetters(i_string) == true)
            {
                return false;
            }


            return true;

        }
        private static bool HasEnglishLetters(String i_string)
        {

            bool isTheInputContainsEnglishLetters = Regex.IsMatch(i_string, "^[a-zA-Z0-9]*$");


            return isTheInputContainsEnglishLetters;


        }
        private static int NumberOfLowerCases(String i_string)
        {
            int counterOfLowerCasesLettes = 0;

            for (int i = 0; i < i_string.Length; i++)
            {
                char charOfString = i_string.ElementAt(i);
                if (Char.IsLower(charOfString) == true)
                {
                    counterOfLowerCasesLettes++;
                }

            }

            return counterOfLowerCasesLettes;
        }

        private static bool isTheStringIsAlphaBet(String i_string)
        {
            return IsTheStringContainsLetters(i_string) == true && IsTheTextContainsDigits(i_string) == false;


        }
        private static bool isTheStringIsNumber(String i_string)
        {
            return IsTheStringContainsLetters(i_string) == false && IsTheTextContainsDigits(i_string) == true;


        }

        private static long parseStringToNumber(String i_string)
        {
            long.TryParse(i_string, out long parsedLongFromString);

            return parsedLongFromString;

        }
        private static bool isTheNumberDivideByThree(String i_string)
        {

            return parseStringToNumber(i_string) % 3 == 0;



        }
        public static void PrintTheSatistics()
        {
            String inputString = ReadStringFromUser();
            String isPalindrome = "yes";
            if (IsPalindrome(inputString) == true)
            {
                isPalindrome = "is a Palindrome";
            }
            else
            {
                isPalindrome = "is Not a Palindrome";
            }
            String strTocheckIfPalindromeWithFormat = String.Format("{0}: {1}.", inputString, isPalindrome);
            Console.WriteLine(strTocheckIfPalindromeWithFormat);
            if (isTheStringIsNumber(inputString) == true)
            {
                String dividedByThree = "default";
                if (isTheNumberDivideByThree(inputString) == true)
                {
                    dividedByThree = "is";
                }
                else
                {
                    dividedByThree = "is not";
                }
                String strFormatToCheckIfNumberDivideByThree = String.Format("{0} divided by three without a reminder", dividedByThree);
                Console.WriteLine(strFormatToCheckIfNumberDivideByThree);
            }

            else if (isTheStringIsAlphaBet(inputString) == true)
            {
                int numOfLower = NumberOfLowerCases(inputString);
                String strFormatToCheckIfNumberDivideByThree = String.Format("the number of lowercases letters in the string is:{0}", numOfLower);
                Console.WriteLine(strFormatToCheckIfNumberDivideByThree);

            }

        }
    }
}
