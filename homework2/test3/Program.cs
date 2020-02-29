using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test3
{
    class Program
    {
        static void Main(string[] args)
        {
           // int[] array = new int[] { 1, 2, 3, 4, 6, 5, -1, 0 };
            int[] a = new int[105];
            for (int i = 2; i < a.Length; i++)
            {
                a[i] = 1;
            }//初始化数组
            for (int i = 2; i <= 100; i++)
            {
                if (a[i] == 1)
                {
                    int j = i + 1;
                    while (j <= 100)
                    {
                        if (a[j] == 1 && j % i == 0)//判断j是否为合数
                        {
                            a[j] = 0;
                        }
                        j++;
                    }
                }
            }
            for (int i = 2; i < 101; i++) if (a[i] == 1) Console.WriteLine(i);

        }
    }
}
