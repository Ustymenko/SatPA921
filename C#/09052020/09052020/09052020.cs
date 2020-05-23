using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _09052020 //Generics
{
    //  public class Point<T> where T:struct
    //   public class Point<T> where T:class
    //   public class Point<T> where T: new()
    //   public class Point<T> where T: Human
    //   public class Point<T> where T: IHuman
    //public class Test<T, U> where T : struct where U: Human,new()
    //{ 
    //}
    public class Point<T> where T: struct
    {
        T x;
        T y;
        public static T color;
        public Point(T X, T Y)
        {
            x = X;
            y = Y;
        }
        public Point() : this(default, default(T))
        {
        }
        //public Point()
        //{
        //    x = default;
        //    y = default(T);
        //}
        public void SetX(T X) { x = X; }
        public void SetY(T Y) { y = Y; }
        public T GetX() { return x; }
        public T GetY() { return y; }
        public override string ToString()
        {
            return $"({x};{y}-[{color}])";
        }
    }

    public class Circle : Point<double> 
    {
        double r;
        public Circle() { }
        public Circle(double x, double y, double R) : base(x, y) { r = R; }
        public override string ToString()
        {
            return $"{base.ToString()} R={r}";
        }

    }

    public class Circle<T> : Point<T> where T : struct
    {
        T r;
        public Circle() { }
        public Circle(T x, T y, T R) : base(x, y) { r = R; }
        public override string ToString()
        {
            return $"{base.ToString()} R={r}";
        }

    }
    public class Kolo<U>
    {
        public class Point2<T>
        {
            T x;
            T y;
            public static T color;
            public Point2(T X, T Y)
            {
                x = X;
                y = Y;
            }
            public Point2() : this(default, default(T))
            {
            }
            //public Point()
            //{
            //    x = default;
            //    y = default(T);
            //}
            public void SetX(T X) { x = X; }
            public void SetY(T Y) { y = Y; }
            public T GetX() { return x; }
            public T GetY() { return y; }
            public override string ToString()
            {
                return $"({x};{y}-[{color}])";
            }
        }
        U r;
        Point2<U> center;//Point<int> center;
        public Kolo() { }
        public Kolo(U x, U y, U R) {
            center = new Point2<U>(x,y);
            r = R; 
        }
        public override string ToString()
        {
            return $"{center} R={r}";
        }

    }

    class Program
    {
        static void Test1()
        {
            Point<double>.color = 50;
            Point<int> point = new Point<int>(5, 9);
            Console.WriteLine(point);
            point.SetX(10);
            point.SetY(20);
            Point<int>.color = 250;
            Console.WriteLine(point);
            Point<int> point2 = new Point<int>();
            Console.WriteLine(point2);
            Point<double> point3 = new Point<double>(5.3, 9.6);
            Console.WriteLine(point3);

            //Point<Point<int>> point4 =
            //    new Point<Point<int>>(point, new Point<int>(10, 98));
            //Console.WriteLine(point4);

        }
        static void Test2()
        {
            Point<double>.color = 5555;
            Point<int>.color = 50;
            Circle circle = new Circle();
            Console.WriteLine(circle);

            Circle circle2 = new Circle(10.3, 36.32, 9.99);
            Console.WriteLine(circle2);

            Circle<int> circle3 = new Circle<int>(10, 36, 9);
            Console.WriteLine(circle3);

            Circle<double> circle4 = new Circle<double>(10.65, 36.527, 9.45);
            Console.WriteLine(circle4);

            Kolo<double> kolo = new Kolo<double>(18.5, 6.27, 3.45);
            Console.WriteLine(kolo);

            Kolo<double>.Point2<int> p = new Kolo<double>.Point2<int>(90,80);
            p.SetY(9999);
            Console.WriteLine(p);

        }

        //static void Swap(ref int a,ref int b) {
        //    int t = a;
        //    a = b;
        //    b = t;
        //}
        static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }
        static T Max<T>(T[] arr) where T: IComparable<T>
        {
            T max = arr[0];
            foreach (var item in arr)
            {
                if (item.CompareTo(max)>0)
                    max = item;
            }
            return max;
        }

        static void Main(string[] args)
        {
            //Test1();
            Test2();

            double a = 10, b = 20;
            Console.WriteLine($"a={a} b={b}");
            Swap(ref a,ref b);
            Console.WriteLine($"a={a} b={b}");


        }
    }
}
