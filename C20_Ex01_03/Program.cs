using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C20_Ex01_03


{
    class Program
    {
        public static void Main()
        {
            printSandWatchFromInputNumberOfStars();
        }

        public static int ReadNumberFromUser()
        {
            String numberStr;
            int inputParsedFromUser;
            bool isParseFromUser;
            do
            {
                Console.WriteLine("Enter number for sand clock ,please grater from 1 and not letters");
                numberStr = Console.ReadLine();
                isParseFromUser = int.TryParse(numberStr, out inputParsedFromUser);

                if ((isParseFromUser == false) || (inputParsedFromUser <= 0))
                {
                    Console.WriteLine("invalid input");

                }

            }
            while ((isParseFromUser == false) || (inputParsedFromUser <= 0));


            return inputParsedFromUser;
        }

        private static void printSandWatchFromInputNumberOfStars()
        {
            C20_Ex01_02.Program.PrintSandClock(ReadNumberFromUser());
        }
    }
}

