using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace REGEX
{
    class Program
    {
        static void Test1()
        {
            string text = "Петро 1 був  13 прийнятий на роботу 03.05.2020 Іван був прийнятий на роботу 04.05.2020 Степан був прийнятий на роботу 08.17.2019  2019Q08f17";
            Regex regex = new Regex(@"\d{2}\.\d{2}\.\d{4}");
            Match match = regex.Match(text);
            while (match.Success)
            {
                Console.WriteLine($"{match.Value}");
                match = match.NextMatch();
            }

            MatchCollection collection = regex.Matches(text);
            Console.WriteLine($"Count ={collection.Count}");
            foreach (Match item in collection)
            {
                Console.WriteLine($"{item.Value} {item.Index}");
            }

            string ntext = regex.Replace(text, "10.10.2010");
            Console.WriteLine(ntext);

            ntext = Regex.Replace(text, @"\d{2}\.\d{2}\.\d{4}", "10.10.2010");
            Console.WriteLine(ntext);

            string phPattern = @"^\+\d{2}\(\d{3}\)-\d{2}-\d{2}-\d{3}$";
            Console.Write("Enter phone: (+XX(XXX)-XX-XX-XXX)");
            string phone = Console.ReadLine();///"+38(067)-13-25-393";
            regex = new Regex(phPattern);
            if (regex.IsMatch(phone))
                Console.WriteLine("phone correct.");
            else
                Console.WriteLine(" phone is not correct!");




        }
        static void Main(string[] args)
        {
            Test1();


        }
    }
}
