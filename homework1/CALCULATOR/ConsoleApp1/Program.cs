using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                try
                {
                    Console.WriteLine("请输入第1个数字");
                    double n1 = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("请输入+,-,*,/任意1种运算符");
                    string ss = Console.ReadLine();
                    Console.WriteLine("请输入第2个数字：");
                    double n2 = Convert.ToDouble(Console.ReadLine());
                    switch (ss)
                    {
                        case "+":
                            double n11 = n1 + n2;
                            Console.WriteLine("进行加法运算的结果为" + n11);
                            break;
                        case "-":
                            double n12 = n1 - n2;
                            Console.WriteLine("进行减法运算的结果" + n12);
                            break;
                        case "*":
                            double n13 = n1 * n2;
                            Console.WriteLine("进行乘法运算的结果为" + n13);
                            break;
                        case "/":
                            while (n2 == 0)
                            {
                                Console.WriteLine("请输入一个非零数 ");
                                n2 = Convert.ToInt32(Console.ReadLine());
                            }
                            double n14 = n1 / n2;
                            Console.WriteLine("进行除法运算的结果" + n14);
                            break;

                        default:
                            Console.WriteLine("您输入的运算符有误！！");
                            break;

                    }

                    Console.ReadKey();
                }
                catch (FormatException)
                {
                    Console.WriteLine("输入有误，请重新输入");
                }
            }
        }
    }
}

