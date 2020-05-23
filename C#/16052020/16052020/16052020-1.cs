using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _16052020
{
    static class MyExtension
    {
        static public void Print<T>(this List<T> list, char ch = '\t')
        {
            foreach (var item in list)
                Console.Write($"{item}" + ch);
            Console.Write("\n--------------------------------------------\n");
        }
        static public void Print<T>(this LinkedList<T> list, char ch = '\t')
        {
            foreach (var item in list)
                Console.Write($"{item}" + ch);
            Console.Write("\n--------------------------------------------\n");
        }
        static public void Print<Tk, Tv>(this Dictionary<Tk,Tv> dic, char ch = '\t')
        {
            foreach (var item in dic)
                Console.Write($"{item.Key,-10} {item.Value}" + ch);
            Console.Write("\n--------------------------------------------\n");
        }

    }
    class CMPdate : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x is null || y is null) return 1;
            return x.Bday.CompareTo(y.Bday);
        }
    }
    class Student : IComparable<Student>, IEquatable<Student>
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }

        public int CompareTo(Student other)
        {
            //  Name.CompareTo(other.Name)
            return String.Compare(Name, other.Name);
        }

        public override string ToString()
        {
            return $" {Name,-10} {Bday.ToShortDateString()}";
        }

        public override bool Equals(object obj)
        {
            return this.ToString() == obj.ToString();
        }

        public bool Equals(Student other)
        {
            return other != null &&
                   Name == other.Name &&
                   Bday == other.Bday;
        }

        public override int GetHashCode()
        {
            int hashCode = -1892292941;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
            hashCode = hashCode * -1521134295 + Bday.GetHashCode();
            return hashCode;
        }
    }



    class Program
    {
        static public int CompareDate(Student x, Student y)
        {
            if (x is null || y is null) return 1;
            return x.Bday.CompareTo(y.Bday);
        }

        static void TestList()
        {

            List<int> list1 = new List<int>();
            list1.Add(10);
            list1.AddRange(new int[] { 20, 3, 40, 5, 60, 7 });
            list1.Sort();
            // list1.Reverse();
            list1.Print();


            // list1.Add(10.96);
            List<double> list2 = new List<double>();
            list2.AddRange(new double[] { 2.330, 3, 4.0, 5.69, 60, 7 });
            list2.Sort();
            list2.Print();


            List<Student> gr = new List<Student>();
            gr.Add(new Student { Name = "Ivan", Bday = new DateTime(1998, 10, 23) });
            gr.Add(new Student { Name = "Anna", Bday = new DateTime(2010, 10, 23) });
            gr.Add(null);
            gr.Add(new Student { Name = "Piter", Bday = new DateTime(2013, 10, 23) });
            gr.Add(new Student { Name = "Igor", Bday = new DateTime(2000, 10, 23) });
            gr.Print('\n');
            gr.Sort();
            gr.Print('\n');
            //gr.Sort(new CMPdate());
            //   gr.Sort(CompareDate);
            gr.Sort((a, b) => (a is null || b is null) ? 1 : a.Bday.CompareTo(b.Bday));
            gr.Print('\n');

            gr.RemoveAt(0);
            gr.Print('\n');


        }

        static void TestLinkedList()
        {
            LinkedList<Student> students = new LinkedList<Student>();

            LinkedListNode<Student> nodeIvan = students.AddFirst(
                new Student { Name = "Ivan", Bday = new DateTime(1998, 10, 23) });

            students.AddLast(
                new Student { Name = "Piter", Bday = new DateTime(2013, 10, 23) });

            students.AddAfter(nodeIvan, new Student { Name = "Anna", Bday = new DateTime(2010, 10, 23) });
            students.AddBefore(nodeIvan, new Student { Name = "Ira", Bday = new DateTime(2014, 10, 23) });

            //students[1] error O(1)
            students.Print('\n');

            Console.WriteLine(nodeIvan.Next.Next.Value);
            Console.WriteLine(nodeIvan.Previous.Value);

            var node = students.Find(new Student { Name = "Piter", Bday = new DateTime(2013, 10, 23) });

            if (node is null)
                Console.WriteLine("no");
            else
                Console.WriteLine("yes");
            // students.sort -error

            // var sss= students.OrderBy(s => s).ToList();
            //          ///sss.Print('\n');
            //students = new LinkedList<Student>(students.OrderBy(s => s));
            //students.Print('\n');

            //students = new LinkedList<Student>(students.OrderByDescending(s => s));
            //students.Print('\n');

            students = new LinkedList<Student>(students.OrderBy(s => s.Bday));
            students.Print('\n');


        }


        static void TestDictionary()
        {
            Dictionary<string, Student> dic = new Dictionary<string, Student>();

            dic.Add("Ivan",new Student { Name = "Ivan", Bday = new DateTime(1998, 10, 23) });
            dic.Add("Anna", new Student { Name = "Anna", Bday = new DateTime(2010, 10, 23) });
            dic.Add("Piter", new Student { Name = "Piter", Bday = new DateTime(2013, 10, 23) });
            dic.Add("Igor", new Student { Name = "Igor", Bday = new DateTime(2000, 10, 23) });
          //  dic.Add("Igor", new Student { Name = "Igor", Bday = new DateTime(2000, 10, 23) });

            dic["Stepan"] = new Student { Name = "Stepan", Bday = new DateTime(1963, 10, 23) };

            dic.Print('\n');

            if (dic.ContainsKey("Igor"))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");

            if (dic.ContainsValue(new Student { Name = "Stepan", Bday = new DateTime(1963, 10, 23) }))
                Console.WriteLine("yes");
            else
                Console.WriteLine("no");
            Console.WriteLine(dic.Count);
            dic.Remove("Igor");
            dic.Print('\n');
           

        }
        static void Main(string[] args)
        {
            //TestList();
            //TestLinkedList();
            TestDictionary();
        }
    }
}
