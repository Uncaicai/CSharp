using System;
using System.Linq;

namespace test2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 1, 2, 3, 4, 6, 5, -1, 0 };
            // int[] array = new int[] {  };
            Console.WriteLine("Min:{0}", Min(array));
            Console.WriteLine("Min:{0}", Max(array));
            Console.WriteLine("Min:{0}", Average(array));
            Console.WriteLine("Min:{0}", array.Sum());
        }
        public static int Min(int[] array)
        {
            if (array == null) throw new Exception("数组空异常");
            int value = 0;
            bool hasValue = false;
            foreach (int x in array)
            {
                if (hasValue)
                {
                    if (x < value) value = x;
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new Exception("没找到");//没找到用抛出异常返回
        }

        public static int Max(int[] array)
        {
            if (array == null) throw new Exception("数组空异常");
            int value = 0;
            bool hasValue = false;
            foreach (int x in array)
            {
                if (hasValue)
                {
                    if (x > value)
                        value = x;
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new Exception("没找到");
        }

        public static double? Average(int[] array)
        {
            if (array == null) throw new Exception("数组空异常");
            long sum = 0;
            long count = 0;
            checked
            {
                foreach (int? v in array)
                {
                    if (v != null)
                    {
                        sum += v.GetValueOrDefault();
                        count++;
                    }
                }
            }
            if (count > 0) return (double)sum / count;
            return null;
        }

    }
}
