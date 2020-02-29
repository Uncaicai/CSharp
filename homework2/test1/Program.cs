using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
                Console.WriteLine("enter a number:");
                int i = Convert.ToInt32(Console.ReadLine());
                Analyse(i);

         
    }

        public static void Analyse(int i)
        {
            int j = 2;
            while (i > 1)
            {
                for (j = 2; j < i; j++)
                {
                    if (i % j == 0)
                    {
                        Console.WriteLine(j);
                        break;
                    }
                }
                i = i / j;
            }
            Console.WriteLine(j);
        }
    }
}
