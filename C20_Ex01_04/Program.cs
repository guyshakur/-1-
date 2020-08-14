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
			getFromUserLetterAndDigitAndTheIfPolindromAndMoreStatistics();
		}

		private static string readStringFromUser()
		{
			string inputFromUser;
			do
			{
				Console.WriteLine("Enter text of 12 chars of only english letters or only digits");
				inputFromUser = Console.ReadLine();

				if (!isValidInput(inputFromUser))
				{
					Console.WriteLine("invalid input");
				}
			}
			while (!isValidInput(inputFromUser));

			return inputFromUser;
		}

		private static bool isTheStringContainsLetters(string i_String)
		{
			for (int i = 0; i < i_String.Length; i++)
			{
				char charFromString = i_String.ElementAt(i);

				if (Char.IsLetter(charFromString))// (charFromString>='A' && charFromString<='Z') || (charFromString>='a' && charFromString<='z')
				{
					return true;
				}

			}
			return false;
			/*
			 * return (charFromString>='A' && charFromString<='Z') || (charFromString>='a' && charFromString<='z') 
			 * *********************************עדיף מכל מה שיש למעלה
			 ********************אבל אם רוצים שיהיה יותר ברור אז פשוט להשאיר את מה שיש למעלה
			 **/
		}
		private static bool isTheTextContainsDigits(string i_String)
		{
			for (int i = 0; i < i_String.Length; i++)
			{
				char charFromString = i_String.ElementAt(i);

				if (Char.IsDigit(charFromString))
				{
					return true;
				}

			}
			return false;
		}

		private static bool isPalindrome(string i_String)
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
				return isPalindrome(i_String.Substring(1, i_String.Length - 2));
			}
		}

		private static bool isValidInput(string i_String)
		{
			if (((i_String.Length != 12) || (!isTextIsEnglishLettersOrNumbers(i_String)) && (!isTheTextContainsDigits(i_String)))
				|| ((isTheTextContainsDigits(i_String)) && (isTheStringContainsLetters(i_String))))
			{
				return false;
			}

			return true;
		}

		//checking if the given text are having only english letters or numbers
		private static bool isTextIsEnglishLettersOrNumbers(string i_String)
		{

			for (int i = 0; i < i_String.Length; i++)
			{
				char charAtIndexFromString = i_String.ElementAt(i);

				if (!((charAtIndexFromString >= 'A' && charAtIndexFromString <= 'Z') || (charAtIndexFromString >= 'a' 
					&& charAtIndexFromString <= 'z') || Char.IsNumber(charAtIndexFromString)))
				{
					return false;
				}
			}
			return true;
		}

		private static int numberOfTheLowerCassesLetters(string i_String)
		{
			int counterOfLowerCasesLettes = 0;

			for (int i = 0; i < i_String.Length; i++)
			{
				char charOfString = i_String.ElementAt(i);
				if (Char.IsLower(charOfString))
				{
					counterOfLowerCasesLettes++;
				}
			}
			return counterOfLowerCasesLettes;
		}

		private static bool isTheStringIsAlphaBet(string i_String)
		{
			return (isTheStringContainsLetters(i_String) && (!isTheTextContainsDigits(i_String)));
		}
		private static bool isTheStringIsNumber(string i_String)
		{
			return ((!isTheStringContainsLetters(i_String)) && isTheTextContainsDigits(i_String));
		}

		private static int parsingCharToInt(char i_Char)
		{
			int parsedCharToInt = (int)Char.GetNumericValue(i_Char);

			return parsedCharToInt;

		}

		private static bool isTheNumberFromTheStringDividedByThree(string i_String)
		{
			//int digit = parsingCharToInt(i_String.ElementAt(0));
			//int sumOfDigits = i_String.ElementAt(0);
			int sumOfDigits = 0;
			for (int i = 0/*1*/; i < i_String.Length; i++)
			{
				//digit = parsingCharToInt(i_String.ElementAt(i));
				//sumOfDigits += digit;
				sumOfDigits += parsingCharToInt(i_String.ElementAt(i));
			}
			return sumOfDigits % 3 == 0;
		}

		private static void getFromUserLetterAndDigitAndTheIfPolindromAndMoreStatistics()
		{
			string inputString = readStringFromUser();
			string isPalindrom = "";
			if (!isPalindrome(inputString))
			{
				isPalindrom = "not ";
			}
			string strTocheckIfPalindromeWithFormat = String.Format("{0}: is {1}a Polindrom.", inputString, isPalindrom);
			Console.WriteLine(strTocheckIfPalindromeWithFormat);
			if (isTheStringIsNumber(inputString))
			{
				string dividedByThree = "";
				if (!isTheNumberFromTheStringDividedByThree(inputString))
				{
					dividedByThree = "not ";
				}
				string strFormatToCheckIfNumberDivideByThree = String.Format("is {0}divided by three without a reminder", dividedByThree);
				Console.WriteLine(strFormatToCheckIfNumberDivideByThree);
			}

			else if (isTheStringIsAlphaBet(inputString))
			{
				int numOfLower = numberOfTheLowerCassesLetters(inputString);
				string strFormatToCheckIfNumberDivideByThree = 
					String.Format("the number of lowercases letters in the string is:{0}", numOfLower);
				Console.WriteLine(strFormatToCheckIfNumberDivideByThree);

			}

		}
	}
}
