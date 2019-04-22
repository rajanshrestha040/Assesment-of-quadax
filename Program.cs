using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastermind
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable ht = new Hashtable();
            int wrongPosCount = 0;
            int rightPosCount = 0;
            string numberStr;
            int life = 10;
            int wrongNumberCount = 0;
            Boolean winFlag = false;
            Random randn = new Random();
            int randNumb;

            for (int i = 0; i < 4; i++)
            {
                randNumb = randn.Next(1, 7);
                ht.Add(i, randNumb);
            }

            foreach (DictionaryEntry dr in ht)
            {
                Console.WriteLine(dr.Value);
            }

            while (!winFlag)
            {
                Console.WriteLine("Enter a 4 digit number with each digit being between 1 and 6");

                numberStr = Console.ReadLine();

                int[] number = new int[numberStr.Length];

                for (int i = 0; i < number.Length; i++)
                {
                    number[i] = (int)Char.GetNumericValue(numberStr[i]);

                    if (ht.ContainsValue(number[i]))
                    {
                        if (Convert.ToInt32(ht[i]) == number[i])
                        {
                            rightPosCount++;
                        }
                        else
                        {
                            wrongPosCount++;
                        }
                    }
                    else
                    {
                        wrongNumberCount++;
                    }

                }

                if (wrongPosCount == 0 && wrongNumberCount == 0)
                {
                    winFlag = true;
                }

                Console.WriteLine("The number of correct numbers in correct Position are:-");
                for (int i = 0; i < rightPosCount; i++)
                {
                    Console.Write("  +  ");
                }

                Console.WriteLine();
                Console.WriteLine("The number of correct numbers in wrong Positions are:-");

                for (int j = 0; j < wrongPosCount; j++)
                {
                    Console.Write("   -   ");
                }

                life--;

                if (life < 0)
                {
                    break;
                }
                wrongPosCount = 0;
                rightPosCount = 0;
                wrongNumberCount = 0;
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine("You have {0} chances left", life);
            }

            if (winFlag == true)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You Lose");
            }

            Console.ReadLine();



        }
    }
}
