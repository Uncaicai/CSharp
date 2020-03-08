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
            String[] type = { "rectangle", "square", "triangle"};  //表示可用的形状
            int[] parameterNumbers = { 2, 1, 3 };  //创建对应形状所需要的参数
            Shape shape;
            double sumArea = 0.0;
            for (int i = 0; i < 10; i++)
            {
                int randomType = new Random().Next(0, type.Length);
                double[] parameters = new double[parameterNumbers[randomType]];  //参数
                do
                {
                    for (int j = 0; j < parameters.Length; j++)
                    {
                        Random random = new Random(Guid.NewGuid().GetHashCode());
                        parameters[j] = random.NextDouble() + random.Next(0, 100);
                    }
                    shape = ShapeFactory.Product(type[randomType], parameters);
                } while (shape == null);
                sumArea += shape.Area;
            }
            Console.WriteLine($"The total area is {sumArea}.");
        }
    }

    abstract class Shape {
        abstract public double Area { get; }
        abstract public void IsLegal();
    }
   
    class Rectangle :Shape
    {
        private double width;
        private double height;
        public double Width
        {
            get => width;
        }
        public double Height
        {
            get => height;
        }

        public Rectangle(double width, double height)
    {
        this.width = width;
        this.height = height;
        IsLegal();
    }
        public override void IsLegal()
        {
            if (width<=0 || height<=0) Console.WriteLine("Rectangle is illegal");
        }
        public override double Area
        {
            get => width * height;
        }


    }

    class Triangle : Shape
    {
        private double a;
        private double b;
        private double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override void IsLegal()
        {
            double maxSide = Math.Max(Math.Max(a, b), c);
            if (a <= 0 || b <= 0 || b <= 0 || a + b + c - maxSide < maxSide)
            {
                Console.WriteLine("This triangle is illegal!");
                a = b = c = 0.0;
            }
        }
        public override double Area
        {
            get
            {
                double p = 0.5 / (a + b + c);
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }
    }

    class Square : Rectangle{
        public double side;
        public double Side
        {
            get => side;
        }
        public Square(double side) : base(side, side)
        {
            this.side = side;
        }
    public override void IsLegal()
        {
            if (side<=0)
            {
                Console.WriteLine("This square is illegal!");
                side= 0.0;
            }
        }
    }

    class ShapeFactory
    {
        public static Shape Product(String type, double[] values)
        {
            Shape shape = null;
            switch (type)
            {
                case "rectangle":
                    if (values.Length != 2)
                    {
                        Console.WriteLine("The parameter length is incorrect!");
                        break;
                    }
                    shape = new Rectangle(values[0], values[1]);
                    break;
                case "square":
                    if (values.Length != 1)
                    {
                        Console.WriteLine("The parameter length is incorrect!");
                        break;
                    }
                    shape = new Square(values[0]);
                    break;
                case "triangle":
                    if (values.Length != 3)
                    {
                        Console.WriteLine("The parameter length is incorrect!");
                        break;
                    }
                    double maxValue = Math.Max(Math.Max(values[0], values[1]), values[2]);
                    if (values[0] + values[1] + values[2] - maxValue < maxValue)
                    {
                        Console.WriteLine("The parameter is incorrect!");
                        break;
                    }
                    shape = new Triangle(values[0], values[1], values[2]);
                    break;
            }
            return shape;

        }



    }
}
