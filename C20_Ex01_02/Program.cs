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

            //m_SizeOfSandClock = 5;
            PrintSandClock(m_SizeOfSandClock);
        }

        private static void SandClock(int i_StarSize)
        {
            int sizeOfStar = m_SizeOfSandClock;

            if (i_StarSize == 0)
            {
                Console.WriteLine();
                return;
            }
            if (i_StarSize == 1)
            {
                PrintStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
                return;
            }
            if (i_StarSize == 2)
            {
                PrintStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
                Console.WriteLine();
                PrintStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
            }
            else
            {
                PrintStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
                SandClock(i_StarSize - 2);
                PrintStar(i_StarSize, (sizeOfStar - i_StarSize) / 2);
            }
        }


        private static void PrintStar(int i_PrintStar, int i_PrintSpace)
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

        //
        public static void SetSizeSandClock(int i_NewSize)
        {
            m_SizeOfSandClock = i_NewSize;
        }
        public static void PrintSandClock(int i_SizeOfSandClock)
        {
            SandClock(i_SizeOfSandClock);
        }

    }


}
