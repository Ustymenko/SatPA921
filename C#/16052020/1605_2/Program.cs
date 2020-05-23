using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1605_2
{
    public delegate double FuncDelegate(double a, double b);

    public class Matem
    {
        public double Sum(double a, double b) { return a + b; }
        public double Sub(double a, double b) { return a - b; }
        public static double Mult(double a, double b) { return a * b; }
        public static double Div(double a, double b) { return a / b; }
    }

    class Program
    {
        static void Test()
        {
            Console.WriteLine("Enter a?b  ?(+-*/) ");
            string expression = Console.ReadLine(); ///20+30
            char sign = ' ';
            try
            {
                if (expression.Contains('+')) sign = '+';
                if (expression.Contains('-')) sign = '-';
                if (expression.Contains('*')) sign = '*';
                if (expression.Contains('/')) sign = '/';

                string[] numbers = expression.Split(sign);
                double a = double.Parse(numbers[0]);
                double b = double.Parse(numbers[1]);

                Matem matem = new Matem();
                FuncDelegate func = null;
                double res = 0;
                switch (sign)
                {
                    case '+': func = matem.Sum; break;
                    case '-': func = new FuncDelegate(matem.Sub); break;
                    case '*': func = Matem.Mult; break;
                    case '/': func = Matem.Div; break;
                    default:
                        throw new Exception("no sign");
                }
                //    Console.WriteLine($"{a}{sign}{b}={func?.Invoke(a,b)}");
                Console.WriteLine($"{a}{sign}{b}={func(a, b)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        static void Test3()
        {
            Console.WriteLine("Enter a?b  ?(+-*/) ");
            string expression = Console.ReadLine(); ///20+30
            char sign = ' ';
            try
            {
                if (expression.Contains('+')) sign = '+';
                if (expression.Contains('-')) sign = '-';
                if (expression.Contains('*')) sign = '*';
                if (expression.Contains('/')) sign = '/';

                string[] numbers = expression.Split(sign);
                double a = double.Parse(numbers[0]);
                double b = double.Parse(numbers[1]);

                FuncDelegate func = null;
                double res = 0;
                switch (sign)
                {
                    case '+': func = delegate (double x, double y) { return x + y; }; break;
                    case '-': func = delegate (double x, double y) { return x - y; }; break;
                    case '*': func = delegate (double x, double y) { return x * y; }; break;
                    case '/': func = delegate (double x, double y) { return x / y; }; break;
                    default:
                        throw new Exception("no sign");
                }
                //    Console.WriteLine($"{a}{sign}{b}={func?.Invoke(a,b)}");
                Console.WriteLine($"{a}{sign}{b}={func(a, b)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        static void Test4()
        {
            Console.WriteLine("Enter a?b  ?(+-*/) ");
            string expression = Console.ReadLine(); ///20+30
            char sign = ' ';
            try
            {
                if (expression.Contains('+')) sign = '+';
                if (expression.Contains('-')) sign = '-';
                if (expression.Contains('*')) sign = '*';
                if (expression.Contains('/')) sign = '/';

                string[] numbers = expression.Split(sign);
                double a = double.Parse(numbers[0]);
                double b = double.Parse(numbers[1]);
                FuncDelegate func = null;
                switch (sign)
                {
                    case '+': func = (x, y) => x + y; break;
                    case '-': func = (x, y) => x - y; break;
                    case '*': func = (x, y) => x * y; break;
                    case '/': func = (x, y) => x / y; break;
                    default:
                        throw new Exception("no sign");
                }
                //    Console.WriteLine($"{a}{sign}{b}={func?.Invoke(a,b)}");
                Console.WriteLine($"{a}{sign}{b}={func(a, b)}");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
        delegate int Dtwo(int a,int b);
        delegate int Done(int a);
        delegate void Dzero();

        static void Test5()
        {
            Dtwo sum = (x, y) => x + y;
            Console.WriteLine(sum(10,30));
            Done kub = x => x*x*x;
            Console.WriteLine(kub(2));
            Dzero Hello = ()=> Console.WriteLine("Hello");
            Hello();
        }

        static int CountInArrPos(int[] arr)
        {
            int count = 0;
            foreach (var el in arr)
            {
                if (el > 0)
                    count++;
            }
            return count;
        }
        static int CountInArrNeg(int[] arr)
        {
            int count = 0;
            foreach (var el in arr)
            {
                if (el < 0)
                    count++;
            }
            return count;
        }
      
        delegate bool TestBool(int el);
        //static int CountInArr(int[] arr, TestBool Test)
        static int CountInArr(int[] arr, Predicate<int> Test)
        {
            int count = 0;
            foreach (var el in arr)
            {
                if (Test(el))
                    count++;
            }
            return count;
        }
        static bool Above(int el) => el > 0;
        static void Test6()
        {
            int[] mas = {10,-20,30,-20,11,32,-98,23,0,3 };
            //Console.WriteLine(CountInArrPos(mas));
            //Console.WriteLine(CountInArrNeg(mas));
            //Console.WriteLine(CountInArrNeg(mas));
            Console.WriteLine(CountInArr(mas,Above));
            Console.WriteLine(CountInArr(mas,x=>x<0));
            Console.WriteLine(CountInArr(mas,x=>x==0));
            Console.WriteLine(CountInArr(mas,x=>(x&1)==1)); //непарні
            Console.WriteLine(CountInArr(mas,x=>(x&1)!=1)); //парні

        }

        static void Test7()
        {
            // delegate void Dzero();
         //void Action
            Action action = () => Console.WriteLine("Hello");
            action();
            Action<string> action1 = x=> Console.WriteLine(x);
            action1("Help");


            Func<int,int> kub = x => x * x * x;
            Console.WriteLine(kub(2));

            Func<int, double> tt = x => x /2.5;
            Console.WriteLine(tt(9));

            Func<int, int,int > sum = (x, y) => x + y;
            Console.WriteLine(sum(10, 30));

            int[] mas = { 10, -20, 30, -20, 11, 32, -98, 23, 0, 3 };
            Predicate<int> above = x => x > 0;
            Console.WriteLine(CountInArr(mas, Above));
            Console.WriteLine(CountInArr(mas, above));

        }



        static void Test2()
        {
            Matem matem = new Matem();
            FuncDelegate func = matem.Sum;
            func += matem.Sub;
            func += Matem.Mult;
            func += Matem.Div;
            double a = 10, b = 20;
            Console.WriteLine($"{a} {b}={func(a, b)}");
            Console.WriteLine($"+--------------------------------------");
            foreach (FuncDelegate f in func.GetInvocationList())
            {
                Console.WriteLine($"{a} {f.Method.Name} {b}={f(a, b)}");
            }



        }
        static void Main(string[] args)
        {
            // Test();
            // Test2();
            //Test3();
           // Test5();
            //Test6(); 
            Test7();
        }
    }
}
