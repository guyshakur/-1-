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

        private static int readNumberFromUser()
        {
            String numberStr;
            int inputParsedFromUser;
            bool isParseFromUser;
            do
            {
                Console.WriteLine("Enter number for sand clock ,please grater from 0 and not letters");
                numberStr = Console.ReadLine();
                isParseFromUser = int.TryParse(numberStr, out inputParsedFromUser);

                if ((!isParseFromUser) || (inputParsedFromUser <= 0))
                {
                    Console.WriteLine("invalid input");
                }
            }
            while ((isParseFromUser == false) || (inputParsedFromUser <= 0));

            return inputParsedFromUser;
        }

        private static void printSandWatchFromInputNumberOfStars()
        {
            int numberFromUser = readNumberFromUser();
            numberFromUser = (numberFromUser / 2) * 2; ///if the number i get is even the number not change
                                                        /// if the number is odd i change the number to the number - 1 --> even and smaller from what i get in 1. 
            C20_Ex01_02.Program.PrintSandClock(numberFromUser + 1); /// i add to the number 1 to change the number to odd.
        /**
         * for example if i get from user the number 5. i divide with 2 and get 2 and multiple with 2 and i get 4. and when i send to the methods PrintSandClock 
         * i send 5. but if i get from user 6, i divide with 2 and get 3 and multiple with 2 and get 6. and when i send to the methods i send 7.
         * anywhy i send number odd.
         */
        }
    }
}

