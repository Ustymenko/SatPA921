using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLL_Sharp;
using System.Runtime.InteropServices;

namespace TEST_DLL
{
    class Program
    {
        static void Testdllsharp()
        {

            Message.Show("Hello");
        }
        class WinAPI
        {
            [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "MessageBox")]
            public static extern int Message(IntPtr ptr, string text,
                string caption, int type);

            [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern int printf(string format, int k, double d);

            [DllImport("msvcrt.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.Cdecl)]
            public static extern int printf(string format, __arglist);
        }

        class MyDLL
        {
            [DllImport("DLLCPP.dll")]
            public static extern double Add(double a, double b);
            [DllImport("DLLCPP.dll")]
            public static extern double Sub(double a, double b);
            [DllImport("DLLCPP.dll")]
            public static extern double Mult(double a, double b);
            [DllImport("DLLCPP.dll")]
            public static extern double Div(double a, double b);
        }

        static void Main(string[] args)
        {
            //Testdllsharp();

            WinAPI.Message(IntPtr.Zero, "Привіт", "Вікно", 0);
            int m = 10;
            double d = 9.99;
            WinAPI.printf("m=%d  d=%f\n", m, d);
            WinAPI.printf("%d * %f =%f ", __arglist(m, d, m * d));


            double a = 10;
            double b = 0;
            Console.WriteLine($"\n{a}+{b}={MyDLL.Add(a,b)}");
            Console.WriteLine($"{a}-{b}={MyDLL.Sub(a,b)}");
            Console.WriteLine($"{a}*{b}={MyDLL.Mult(a,b)}");
            Console.WriteLine($"{a}/{b}={MyDLL.Div(a,b)}");


            Console.ReadKey();
        }
    }
}
