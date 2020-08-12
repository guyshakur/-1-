using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex01_02
{
	public class Program
	{
		private static int m_SizeOfSandClock = 5;

		public static void Main()
		{
			PrintSandClock(m_SizeOfSandClock);
		}

		private static void sandClock(int i_StarSize)
		{
			int sizeOfStar = m_SizeOfSandClock;

		   
			if (i_StarSize == 1)
			{
				printStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
			}
			
			else
			{
				printStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
				sandClock(i_StarSize - 2);
				printStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
			}
		}


		private static void printStar(int i_PrintStar, int i_PrintSpace)
		{
			for (int i = 0; i < i_PrintSpace; i++)
			{
				Console.Write(" ");
			}
			for (int i = 0; i < i_PrintStar; i++)
			{
				Console.Write("*");
			}
			Console.WriteLine();
		}

		
		private static void setSizeSandClock(int i_NewSize)
		{
			m_SizeOfSandClock = i_NewSize;
		}
		public static void PrintSandClock(int i_SizeOfSandClock)
		{
			setSizeSandClock(i_SizeOfSandClock);
			sandClock(i_SizeOfSandClock);
		}

	}


}
