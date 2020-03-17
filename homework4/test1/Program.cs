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
            //为示例中的泛型链表类添加类似于List<T>类的ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，求最大值、最小值和求和（使用lambda表达式实现）
            GenericList<int> list = new GenericList<int>();
            for (int x = 0; x < 10; x++) {
                list.Add(x);
            }
            list.ForEach(x => Console.WriteLine(x));
            int max = int.MinValue;
            int min = int.MaxValue;
            int sum = 0;
            list.ForEach(x => { if (max < x) max = x; });
            Console.WriteLine($"max:{max}");
            list.ForEach(x => { if (min > x) min = x; });
            Console.WriteLine($"min:{min}");
            list.ForEach(x => sum+=x);
            Console.WriteLine($"sum:{sum}");


        }
        public class Node<T> { 
            public Node<T> Next { get; set; }
            public T Data { get; set; }
            public Node(T t) {
                Next = null;
                Data = t;
            }
        }

        public class GenericList<T> {
            private Node<T> head;
            private Node<T> tail;

            public GenericList() {
                tail = head = null;
            }
            public Node<T> Head { get => head; }
            public void Add(T t) {
                Node<T> n = new Node<T>(t);
                if (tail == null)
                {
                    head = tail = n;
                }
                else {
                    tail.Next = n;
                    tail = n;
                }
            }

            public void ForEach(Action<T> action)
            {
                Node<T> n = this.head;
                while (n != null) {
                    action(n.Data);
                    n = n.Next;
                }
            }


        }


    }
}
