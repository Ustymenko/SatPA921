using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace _30052020
{
    class Student
    {
        public string PIB { get; set; }
        public DateTime Bday { get; set; }
        public double AvgMarks { get; set; }
        public override string ToString() =>
             $"|{PIB,-15}|{Bday.ToShortDateString()}|{AvgMarks,10:f2}|\n";
    }

    class Program
    {
        static void Test1()
        {
            int[] mas = { 10, 20, 30, 15, 16, 19, -5, -3, 6 };
            var numbers = mas.Select(x => x * 2);
            // var numbers = mas.Select(x=>x*2).ToList();
            Console.WriteLine(String.Join(", ", numbers));

            mas[1] = 50;
            Console.WriteLine(String.Join(", ", numbers));
            foreach (var a in numbers)
            {
                Console.Write(a + "\t");
            }
        }

        static void TestWhere()
        {
            int[] mas = { 10, -20, 30, 15, 16, 19, -5, -3, 6 };
            Console.WriteLine(String.Join(", ", mas));
            List<int> list = new List<int>();
            foreach (var el in mas)
                if (el < 0)
                    list.Add(el);
            Console.WriteLine(String.Join(", ", list));
            //--------------------LINQ------------------------
            var quary1 = from a in mas
                         where a < 0
                         select a;
            Console.WriteLine(String.Join(", ", quary1));

            var quary2 = mas.Where(el => el < 0);
            Console.WriteLine(String.Join(", ", quary2));

            var quary4 = mas.Where((el, index) => el < 0 && index % 2 == 1);
            Console.WriteLine(String.Join(", ", quary4));





            //----------------------------------
            string[] pib = { "Petrenko", "Ivanenko", "Stepanenko", "Pashkivskiy" };

            var quary3 = from st in pib
                             //where st[0]=='P'
                         where st.StartsWith("P")
                         select st;
            quary3 = pib.Where(st => st.StartsWith("P"));
            Console.WriteLine(String.Join(", ", quary3));

            quary3 = from st in pib
                     where st.StartsWith("P")
                     where st.EndsWith("o")
                     select st;
            //    quary3 = pib.Where(st =>  st.StartsWith("P") && st.EndsWith("o"));
            quary3 = pib
               .Where(st => st.StartsWith("P"))
               .Where(st => st.EndsWith("o"));
            Console.WriteLine(String.Join(", ", quary3));


        }

        static void TestSelect()
        {
            int[] mas = { 10, -20, 30, 15, 16, 19, -5, -3, 6 };

            var quary1 = mas.Select(el => el / 2.0);
            Console.WriteLine(String.Join("\t ", quary1));

            List<Student> groups = new List<Student> {
                new Student{ PIB="Petrenko", Bday=new DateTime(2010,10,15), AvgMarks=10.99},
                new Student{ PIB="Ivanenko", Bday=new DateTime(1996,10,15), AvgMarks=5.6},
                new Student{ PIB="Isak", Bday=new DateTime(2013,10,15), AvgMarks=3.99},
                new Student{ PIB="Tokar", Bday=new DateTime(2012,10,15), AvgMarks=6},
                new Student{ PIB="Pavlenko", Bday=new DateTime(2006,10,15), AvgMarks=8}
            };

            var quary2 = from st in groups
                         select st;
            quary2 = groups.Select(s => s);
            Console.WriteLine(String.Join("", quary2));
            Console.WriteLine("------------------------------------------------");
            var quary3 = from st in groups
                         select st.PIB;
            quary3 = groups.Select(s => s.PIB);
            Console.WriteLine(String.Join("\n", quary3));
            Console.WriteLine("------------------------------------------------");
            quary3 = from st in groups
                     select st.PIB + st.AvgMarks;
            quary3 = groups.Select(s => s.PIB + s.AvgMarks);
            Console.WriteLine(String.Join("\n", quary3));

            var quary4 = from st in groups
                         select new { st.PIB, st.AvgMarks };
            quary4 = groups.Select(st => new { st.PIB, st.AvgMarks });
            Console.WriteLine(String.Join("\n", quary4));

            int[] a_arr = Enumerable.Range(1, 9).ToArray(); //{ 1,2,3,4,5,6,7,8,9 };
            int[] b_arr = Enumerable.Range(1, 9).ToArray();// { 1,2,3,4,5,6,7,8,9 };

            var mult = from a in a_arr
                       from b in b_arr
                       select $"{a,2} *{b,2}={a * b}";
            //Console.WriteLine(String.Join("\n", mult));
            var mult2 = a_arr.SelectMany(
                x => b_arr,
                (a, b) => $"{a,2} *{b,2}={a * b}"
                );
            Console.WriteLine(String.Join("\n", mult2));


        }

        static void TestSort()
        {
            List<Student> groups = new List<Student> {
                new Student{ PIB="Petrenko", Bday=new DateTime(2010,10,15), AvgMarks=10.99},
                new Student{ PIB="Ivanenko", Bday=new DateTime(1996,10,15), AvgMarks=5.6},
                new Student{ PIB="Isak", Bday=new DateTime(2013,10,15), AvgMarks=3.99},
                new Student{ PIB="Ivanenko", Bday=new DateTime(1990,10,15), AvgMarks=6},
                new Student{ PIB="Pavlenko", Bday=new DateTime(2006,10,15), AvgMarks=8}
            };
            Console.WriteLine(String.Join("", groups));
            Console.WriteLine("------------------------------------------------");
            //var quary1 = from st in groups
            //             orderby st.PIB
            //             select st;
            // var quary1 = groups.OrderBy(st => st.PIB);
            //var quary1 = from st in groups
            //             orderby st.PIB, st.Bday
            //             select st;
           // var quary1 = groups.OrderBy(st => st.PIB).ThenBy(st => st.Bday);
            //var quary1 = from st in groups
            //             orderby st.PIB descending, st.Bday ascending
            //             select st;
            var quary1 = groups
                .OrderByDescending(st => st.PIB)
                .ThenBy(st => st.Bday);

            Console.WriteLine(String.Join("", quary1));




        }
        static void Main(string[] args)
        {
            //Test1();
            // TestWhere();
            // TestSelect();
            TestSort();

            int[] mas = { 10, -20, 30, 15, 16, 19, -5, -3, 6 };
            int qr = mas.First();
            qr = mas.First(x=>x<0);
          
            //Take 
        }
    }
}
