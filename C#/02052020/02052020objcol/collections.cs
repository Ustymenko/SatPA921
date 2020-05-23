using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02052020objcol
{
    public static class StringCountWordsExtension
    {
        public static Int32 CountWords(this string text)
        {
            return text.Split(" .,!?".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
    public static class CollectionsExtension
    {
        public static void Print(this ArrayList list, string name = "")
        {
            Console.WriteLine($"{name}");
            foreach (var el in list)
                Console.Write(el + "\t");
            Console.WriteLine();
        }
        public static void Print(this Stack list, string name = "")
        {
            Console.WriteLine($"{name}");
            foreach (var el in list)
                Console.Write(el + "\t");
            Console.WriteLine();
        }
        public static void Print(this Queue list, string name = "")
        {
            Console.WriteLine($"{name}");
            foreach (var el in list)
                Console.Write(el + "\t");
            Console.WriteLine();
        }
       // public static void Print(this Hashtable list, string name = "")
        public static void Print(this IDictionary list, string name = "")
        {
            Console.WriteLine($"{name}");
            foreach (var key in list.Keys)
                Console.Write(key.GetHashCode()+" ");
            Console.WriteLine();
            foreach (var key in list.Values)
                Console.Write(key.GetHashCode() + " ");
            Console.WriteLine();
            //foreach (DictionaryEntry el in list)
            //    Console.WriteLine(el.Key + "\t"+ el.Value);
            foreach (var key in list.Keys)
                Console.WriteLine(key + "\t" + list[key]);
            Console.WriteLine();
        }
    }
    class MyCompIntRevers : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is int X && y is int Y)
                return -X.CompareTo(Y);
            throw new InvalidCastException();
        }
    }

    class Program
    {
        static void TestArrayList()
        {
            ArrayList list1 = new ArrayList();
            list1.Add(10);
            list1.Add(25.36);
            list1.Add(true);
            list1.Add("It Step");
            list1.Print("list1");
            list1.AddRange(new int[] { 10, 2, 6, 9, -9, 5, -2 });
            list1.Print();
            list1.Insert(1, 555);
            list1.InsertRange(2, new int[] { 100, 20, 60 });
            list1.Print();
            list1.Remove("It Step");
            list1.RemoveAt(4);
            list1.RemoveRange(4, 3);
            list1.Print();

            //list1.Add("It Step");
            list1.Sort();
            list1.Print();
            // list1.Reverse();
            list1.Sort(new MyCompIntRevers());
            list1.Print();


            Console.WriteLine($"list1[5] { list1[5] } ");
            Console.WriteLine($"Count { list1.Count } ");
            Console.WriteLine($"Capacity { list1.Capacity } ");
            list1.TrimToSize();
            Console.WriteLine($"Capacity { list1.Capacity } ");

            //string str = "Несе Галя воду, коромисло гнеться.";
            //Console.WriteLine("count ="+str.CountWords());




        }

        static void TestStack()
        { //LIFO
            Stack stack = new Stack();
            stack.Push(10);
            stack.Push("It");
            stack.Push(DateTime.Now);
            stack.Push(20);
            stack.Push(30);
            stack.Print();
            Console.WriteLine("Peek = " + stack.Peek());
            stack.Pop();
            stack.Print();
            if (stack.Contains("It6"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            stack.Clear();

        }
        static void TestQueue() //FIFO
        {
            Queue queue = new Queue();
            queue.Enqueue(10);
            queue.Enqueue("It");
            queue.Enqueue(DateTime.Now);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Print();
            Console.WriteLine("Peek = " + queue.Peek());
            queue.Dequeue();
            queue.Print();
            if (queue.Contains("It"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
            queue.Clear();

        }
        static void TestHashtable()
        {
            Hashtable table = new Hashtable{
                {10,"Petrenko" },
                {5.96,"Ivanenko" },
                {true,"Stepanenko" },
            };
            table.Print();
            table.Add(20, "Teteruk");
            table.Print();
            //table[30] = "Petruk";
            if (!table.ContainsKey(30))
                table.Add(30, "Ivanyuk");
            table.Print();
            if (table.ContainsValue("Teteruk"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");

            table.Remove(10);
            table.Print();


        }
        static void TestSortedList()
        {
            SortedList list = new SortedList();
            list.Add(10, "Piter");
            list.Add(40, "Peter");
            list.Add(20, "Teteruk");
            list.Print();
            if (!list.ContainsKey(30))
                list.Add(30, "Ivanyuk");
            list.Print();
            if (list.ContainsValue("Teteruk"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
        static void TestSortedListRev()
        {
            SortedList list = new SortedList(new MyCompIntRevers());
            list.Add(10, "Piter");
            list.Add(40, "Peter");
            list.Add(20, "Teteruk");
            list.Print();
            if (!list.ContainsKey(30))
                list.Add(30, "Ivanyuk");
            list.Print();
            if (list.ContainsValue("Teteruk"))
                Console.WriteLine("Yes");
            else
                Console.WriteLine("No");
        }
        static void Main(string[] args)
        {
            //  TestArrayList();
            //  TestStack();
            //  TestQueue();
            //  TestHashtable();
            TestSortedList();
            TestSortedListRev();

        }
    }
}
