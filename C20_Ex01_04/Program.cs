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

        public static string ReadStringFromUser()
        {
            string inputFromUser;
            do
            {
                Console.WriteLine("Enter text of 12 chars of only english letters or only digits");
                inputFromUser = Console.ReadLine();




                if (IsValidInput(inputFromUser) == false)
                {
                    Console.WriteLine("invalid input");
                }

            }

            while (IsValidInput(inputFromUser) == false);


            return inputFromUser;

        }

        public static bool IsContainsNonAbc(string inputFromUser)
        {
            return true;
        }

        public static bool IsTheStringContainsLetters(string i_String)
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
        public static bool IsTheTextContainsDigits(string i_String)
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

        public static bool IsPalindrome(string i_String)
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

        public static bool IsValidInput(string i_String)
        {

            if (((i_String.Length != 12) || (IsTextIsEnglishLettersOrNumbers(i_String) == false) && (IsTheTextContainsDigits(i_String) == false))
                || ((IsTheTextContainsDigits(i_String) == true) && (IsTheStringContainsLetters(i_String) == true)))
            {
                return false;
            }


            return true;

        }
        //checking if the given text are having only english letters or numbers
        public static bool IsTextIsEnglishLettersOrNumbers(string i_String)
        {
            
            for(int i=0;i<i_String.Length;i++)
            {
                char charAtIndexFromString = i_String.ElementAt(i);

               if (!((charAtIndexFromString >= 'A' && charAtIndexFromString <= 'Z') || (charAtIndexFromString >= 'a' && charAtIndexFromString <= 'z') || Char.IsNumber(charAtIndexFromString) == true))
                {
                    return false;
                }
            }
            return true;
            


        }
        public static int NumberOfTheLowerCassesLetters(string i_String)
        {
            int counterOfLowerCasesLettes = 0;

            for (int i = 0; i < i_String.Length; i++)
            {
                char charOfString = i_String.ElementAt(i);
                if (Char.IsLower(charOfString) == true)
                {
                    counterOfLowerCasesLettes++;
                }

            }

            return counterOfLowerCasesLettes;
        }

        private static bool isTheStringIsAlphaBet(string i_String)
        {
            return IsTheStringContainsLetters(i_String) == true && IsTheTextContainsDigits(i_String) == false;


        }
        private static bool isTheStringIsNumber(string i_String)
        {
            return IsTheStringContainsLetters(i_String) == false && IsTheTextContainsDigits(i_String) == true;


        }

        private static int parsingCharToInt(char i_Char)
        {

           int parsedCharToInt= (int)Char.GetNumericValue(i_Char);

            return parsedCharToInt;

        }
        private static bool isTheNumberFromTheStringDividedByThree(string i_String)
        {
            
            int digit = parsingCharToInt(i_String.ElementAt(0));
            int sumOfDigits = i_String.ElementAt(0);
            for (int i=1;i<i_String.Length;i++)
            {
                digit = parsingCharToInt(i_String.ElementAt(i));
                sumOfDigits += digit;

            }
            return sumOfDigits % 3 == 0;



        }
        public static void PrintTheSatistics()
        {
            string inputString = ReadStringFromUser();
            string isPalindrome = "yes";
            if (IsPalindrome(inputString) == true)
            {
                isPalindrome = "is a Palindrome";
            }
            else
            {
                isPalindrome = "is Not a Palindrome";
            }
            string strTocheckIfPalindromeWithFormat = String.Format("{0}: {1}.", inputString, isPalindrome);
            Console.WriteLine(strTocheckIfPalindromeWithFormat);
            if (isTheStringIsNumber(inputString) == true)
            {
                string dividedByThree = "default";
                if (isTheNumberFromTheStringDividedByThree(inputString) == true)
                {
                    dividedByThree = "is";
                }
                else
                {
                    dividedByThree = "is not";
                }
                string strFormatToCheckIfNumberDivideByThree = String.Format("{0} divided by three without a reminder", dividedByThree);
                Console.WriteLine(strFormatToCheckIfNumberDivideByThree);
            }

            else if (isTheStringIsAlphaBet(inputString) == true)
            {
                int numOfLower = NumberOfTheLowerCassesLetters(inputString);
                string strFormatToCheckIfNumberDivideByThree = String.Format("the number of lowercases letters in the string is:{0}", numOfLower);
                Console.WriteLine(strFormatToCheckIfNumberDivideByThree);

            }

        }
    }
}
