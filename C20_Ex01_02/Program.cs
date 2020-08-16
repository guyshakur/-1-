using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex01_02
{
	public class Program
	{
		public static void Main()
		{
			int sizeOfSandClock = 5;
			PrintSandClock(sizeOfSandClock);
		}

		private static void sandClock(StringBuilder i_StringWithStar, int i_StarSize,int i_TotalSize)
		{
			if (i_StarSize == 1)
			{
				createStringWithStars(i_StringWithStar,i_StarSize, (i_TotalSize - i_StarSize) / 2);
			}
			else
			{
				createStringWithStars(i_StringWithStar,i_StarSize, (i_TotalSize - i_StarSize) / 2);
				sandClock(i_StringWithStar,i_StarSize - 2, i_TotalSize);
				createStringWithStars(i_StringWithStar,i_StarSize, (i_TotalSize - i_StarSize) / 2);
			}
		}

		private static void createStringWithStars(StringBuilder i_StringStar, int i_createStringWithStars, int i_PrintSpace)
		{
			//add space to the string
			for (int i = 0; i < i_PrintSpace; i++)
			{
				i_StringStar.Append(" ");
			}
			//add star to the string
			for (int i = 0; i < i_createStringWithStars; i++)
			{
				i_StringStar.Append("*");
			}
			//in end line we add new line to stringBuilder
			i_StringStar.AppendLine("");
		}
		
		public static void PrintSandClock(int i_SizeOfSandClock)
		{
			StringBuilder StringStar = new StringBuilder("");
			sandClock(StringStar,i_SizeOfSandClock,i_SizeOfSandClock);
			Console.Write(StringStar);
		}

	}


}
