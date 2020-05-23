using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02052020
{
    class Program
    {
        static double Div(int a, int b)
        {
            if (b == 0)
            {
                //throw new DivideByZeroException();
                Exception exc = new Exception("div by 0");
                exc.HelpLink = "ukr.net";
                exc.Data.Add("Час помилки", DateTime.Now);
                exc.Data.Add("Причина", "Бо з математики 2 у 3 класі");
                throw exc;
            }
            return a / b;   // 1/3 ->0
        }
        static void Main(string[] args)
        {
            int f = 20;
            try
            {
                Console.Write("Enter x=");
                int x = int.Parse(Console.ReadLine());
                try
                {
                    Console.Write("Enter y=");
                    int y = int.Parse(Console.ReadLine());
                    double r = Div(x, y);
                    Console.WriteLine($"{x}/{y}={r}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("try 2");
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.Source);
                    throw;
                }
                //catch
                //{
                //}

            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("try 1");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.Source);
            }
            catch (Exception ex) when(f==10)
            {
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("Source: " + ex.Source);
                Console.WriteLine("TargetSite: " + ex.TargetSite);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("HelpLink: " + ex.HelpLink);
                foreach (DictionaryEntry item in ex.Data)
                    Console.WriteLine(item.Key + ":\t" + item.Value);
            }
            catch (Exception ex) when (f > 10)
            {
                Console.WriteLine("Message: " + ex.Message);
            }
            catch
            {
                Console.WriteLine("catch");
            }
            finally
            {
                Console.WriteLine("The end");
            }

            Console.ReadKey();

        }
    }
}
