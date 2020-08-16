using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex01_01
{
	class Program
	{
		private static int m_SizeOfArgs = 4;
		private static int m_LenghOfNumberBinary = 8;


		public static void Main()
		{
			getFromUserFourNumberBinaryAndPrintAfterConvertToDecimalPlusStatistics();
		}

		private static void getFromUserFourNumberBinaryAndPrintAfterConvertToDecimalPlusStatistics()
		{
			StringBuilder argsDecimal = new StringBuilder("");
			int countOfPow;

			readArrayFromUser(out StringBuilder argsBinary);

			for (int i = 0; i < m_SizeOfArgs; i++)
			{
				argsDecimal.AppendLine(convertToDecimal(int.Parse(argsBinary.ToString(i * m_LenghOfNumberBinary, m_LenghOfNumberBinary))).ToString());
			}
			countOfPow = counterZeroAndOne(argsBinary, out int countOfOne, out int countOfZero);

			Console.WriteLine(argsDecimal.ToString());
			Console.WriteLine("we have {0} zeros and {1} ones in average", Math.Round((float)countOfZero / m_SizeOfArgs), Math.Round((float)countOfOne / m_SizeOfArgs));
			Console.WriteLine("There are {0} numbers that are power of 2", countOfPow);
			Console.WriteLine("There are {0} numbers which are an ascending series", checkIfAsc(argsDecimal));
			Console.WriteLine("The general average of the inserted numbers is {0}", averageNumber(argsDecimal));

		}

		/// <summary>
		/// read binary number from user, and use with methos CheckIfBinary to check if not problm..
		/// </summary>
		private static void readArrayFromUser(out StringBuilder o_ReadStringFromUser)
		{
			o_ReadStringFromUser = new StringBuilder("");
			String checkIfRightStr;

			Console.WriteLine("Please enter {0} numbers binary with 8 digits, to convert to decimal", m_SizeOfArgs);
			for (int counterOfScan = 0; counterOfScan < m_SizeOfArgs;)
			{
				Console.WriteLine("Please enter {0} option from {1} options", counterOfScan + 1, m_SizeOfArgs);
				checkIfRightStr = Console.ReadLine();

				if (!int.TryParse(checkIfRightStr, out int checkIfRight))
				{
					Console.WriteLine("You need to press just number without letters\nPlease try again");
				}
				else if (!checkIfBinary(checkIfRight))
				{
					Console.WriteLine("You need to press just 0 or 1 numbers\nPlease try again");
				}
				else if (checkIfRightStr.Length != m_LenghOfNumberBinary)
				{
					Console.WriteLine("You need to press exactly {0} digits\nPlease try again", m_LenghOfNumberBinary);
				}
				else
				{
					o_ReadStringFromUser.Append(checkIfRightStr);
					counterOfScan++;
				}
			}
		}

		/// <summary>
		/// check if the number is binary.
		/// </summary>
		static bool checkIfBinary(int i_NnumberToCheck)
		{
			int number = i_NnumberToCheck;
			bool flag = true;

			while (number != 0 && flag == true)
			{
				if (!(number % 10 == 0 || number % 10 == 1))
				{
					flag = false;
				}
				number /= 10;
			}

			return flag;
		}

		/// <summary>
		/// this methos convert binary number to decimal number. 
		/// </summary>
		private static int convertToDecimal(int i_BinaryNumber)
		{
			int decimalNumber = 0;
			int baseOfNumber = 1;

			while (i_BinaryNumber != 0)
			{
				decimalNumber += (baseOfNumber * (i_BinaryNumber % 10));
				i_BinaryNumber /= 10;
				baseOfNumber *= 2;
			}

			return decimalNumber;
		}
		/// <summary>
		/// this methods check how many zero and one have in Strings, and use methods SumZeroAndOne to check if the number is pow of 2. 
		/// </summary>
		private static int counterZeroAndOne(StringBuilder i_Args, out int o_One, out int o_Zero)
		{
			o_One = 0;
			o_Zero = 0;
			int CounterToPow = 0; //בדיקה אם זה חזקה

			for (int size = 0; size < m_SizeOfArgs; size++)
			{
				if (sumZeroAndOne(int.Parse(i_Args.ToString(size * m_LenghOfNumberBinary, m_LenghOfNumberBinary)), ref o_One, ref o_Zero))
				// (בודק אם זה אכן חזקה של 2 (אם כן אז אמור להיות 1 פעם אחת ו0 7 פעמים
				{
					CounterToPow++;
				}
			}

			return CounterToPow;
		}

		/// <summary>
		/// check if the number is pow of 2.
		/// </summary>
		private static bool sumZeroAndOne(int i_Number, ref int io_One, ref int io_Zero)
		{
			int checkIfPow = 0;
			bool flagToReturn = false;

			for (int i = 0; i < m_LenghOfNumberBinary; i++)
			// we need this, becuase if i have 00110010, after 6 times the while break (if we write 'while(i_number!=0)')
			//and we miss 2 zero to add to io_Zero.
			{
				if (i_Number % 10 == 0)
				{
					io_Zero++;
				}
				else
				{
					io_One++;
					checkIfPow++;
				}
				i_Number /= 10;
			}

			if (checkIfPow == 1)
			{
				flagToReturn = true;
			}

			return flagToReturn;
		}

		private static int checkIfAsc(StringBuilder i_Args)
		{
			int counterAsc = 0;
			StringBuilder arg = new StringBuilder("");

			for (int i = 0; i < i_Args.Length; i++)
			{
				bool flagToCheckDuplicateDigit = true;
				while ((i_Args[i] != '\n') && (i_Args[i] != '\r'))
				{
					arg.Append(i_Args[i]);
					i++;
				}

				if ((arg.Length <= 1))
				{
					flagToCheckDuplicateDigit = false;
				}

				else
				{

					for (int runOnDigit = 0; runOnDigit < arg.Length - 1; runOnDigit++)
					{
						if ((int.Parse(arg.ToString(runOnDigit, 1)) >= int.Parse(arg.ToString(runOnDigit + 1, 1))))
						{
							flagToCheckDuplicateDigit = false;
						}
					}
				}

				if (flagToCheckDuplicateDigit)
				{
					counterAsc++;
				}
				arg.Remove(0, arg.Length);
			}
			return counterAsc;
		}

		private static float averageNumber(StringBuilder i_Args)
		{
			StringBuilder args = new StringBuilder("");
			int sum = 0;
			for (int endString = 0; endString < i_Args.Length; endString++)
			{
				while (i_Args[endString] != '\n')
				{
					args.Append(i_Args[endString]);
					endString++;
				}
				sum += int.Parse(args.ToString());
				args.Remove(0, args.Length);
			}

			return sum / m_SizeOfArgs;
		}
	}
}


