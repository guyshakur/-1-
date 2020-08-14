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

		private static void sandClock(StringBuilder i_StringWithStar, int i_StarSize)
		{
			int sizeOfStar = m_SizeOfSandClock;
					   
			if (i_StarSize == 1)
			{
				createStringWithStars(i_StringWithStar,i_StarSize, (sizeOfStar - i_StarSize) / 2);
			}
			
			else
			{
				createStringWithStars(i_StringWithStar,i_StarSize, (sizeOfStar - i_StarSize) / 2);
				sandClock(i_StringWithStar,i_StarSize - 2);
				createStringWithStars(i_StringWithStar,i_StarSize, (sizeOfStar - i_StarSize) / 2);
			}
		}


		private static void createStringWithStars(StringBuilder i_StringStar, int i_createStringWithStars, int i_PrintSpace)
		{
			for (int i = 0; i < i_PrintSpace; i++)
			{
				i_StringStar.Append(" "); //Console.Write(" ");
			}
			for (int i = 0; i < i_createStringWithStars; i++)
			{
				i_StringStar.Append("*"); //Console.Write("*");
			}
			i_StringStar.AppendLine("");//Console.WriteLine();
		}

		
		private static void setSizeSandClock(int i_NewSize)
		{
			m_SizeOfSandClock = i_NewSize;
		}
		public static void PrintSandClock(int i_SizeOfSandClock)
		{
			StringBuilder StringStar = new StringBuilder("");
			setSizeSandClock(i_SizeOfSandClock);
			sandClock(StringStar,i_SizeOfSandClock);
			Console.Write(StringStar);
		}

	}


}
