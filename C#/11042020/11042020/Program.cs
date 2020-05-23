using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11042020
{
    abstract class Human
    {
        uint id;
        protected string FirstName;
        protected string LastName;
        protected internal DateTime Bday;
        public Human(string LN, string FN, DateTime BD)
        {
            FirstName = FN;
            LastName = LN;
            Bday = BD;
            id = (uint)ToString().GetHashCode();
        }
        public Human() : this("No name", "No name", default) { }
        public override string ToString()
        {
            return $"|{id,-10}|{LastName,-15}|{FirstName,-15}|{Bday.ToShortDateString(),10}|";
        }
        public virtual void Print()
        {
            Console.WriteLine($"|{id,-10}|{LastName,-15}|{FirstName,-15}|{Bday.ToShortDateString(),10}|");
        }

        public abstract void Think();
    }
    class Student : Human
    {
        public string Univer { get; set; }
        public Student(string LN, string FN, DateTime BD, string uni) : base(LN, FN, BD)
        {
            // FirstName = FN;
            // LastName = LN;
            // Bday = BD;
            //// id = (uint)ToString().GetHashCode();
            Univer = uni;
        }
        public Student(string LN, string FN) : base(LN, FN, DateTime.Now)
        {
            Univer = "no name";
        }
        public Student()
        {
            Univer = "no name";
        }
        public override string ToString()
        {
            return $"{base.ToString()}{Univer,10}|";
        }
        public void PrintUniver()
        {
            Console.WriteLine($"Univer: {Univer}");
        }
        public override void Print()
        {
            Console.WriteLine($"|{LastName,-15}|{FirstName,-15}|{Bday.ToShortDateString(),10}|Univer: {Univer}");
        }

        public override void Think()
        {
            Console.WriteLine($"Думати як Student");
        }
    }
    sealed class Teacher : Human
    {
        public string subject { get; set; }
        public Teacher(string LN, string FN, DateTime BD, string uni) : base(LN, FN, BD)
        {
            subject = uni;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{subject,10}|";
        }
        public void PrintSubj()
        {
            Console.WriteLine($"subject: {subject}");
        }
        public override void Print()
        {
            Console.WriteLine($"|{LastName,-15}|{FirstName,-15}|{Bday.ToShortDateString(),10}|subject: {subject}");
        }
        public override void Think()
        {
            Console.WriteLine($"Думати як Teacher");
        }

    }
    class Worker : Human
    {
        public string job { get; set; }
        public Worker(string LN, string FN, DateTime BD, string uni) : base(LN, FN, BD)
        {
            job = uni;
        }

        public override string ToString()
        {
            return $"{base.ToString()}{job,10}|";
        }
        public void PrintJob()
        {
            Console.WriteLine($"job: {job}");
        }
        public override void Print()
        {
            Console.WriteLine($"|{LastName,-15}|{FirstName,-15}|{Bday.ToShortDateString(),10}|job: {job}");
        }
        public override void Think()
        {
            Console.WriteLine($"Думати як Worker");
        }

    }
    //class Tutor: Student
    //{
    //    public new void Print()
    //    {
    //        //string
    //        Console.WriteLine(base.ToString());
    //    }

    //}  
    //class Tutor : Student
    //{
    //    //public new void Print()
    //    //{
    //    //    //string
    //    //    Console.WriteLine(base.ToString());
    //    //}
    //    public sealed override void Print()
    //    {
    //        //string
    //        Console.WriteLine(base.ToString());
    //    }
    //}

    //class TEst : Tutor
    //{
    //    public override void Print()
    //    {
    //        //string
    //        Console.WriteLine(base.ToString());
    //    }

    //}
    class Program
    {
        static void Test1()
        {
            //Human h = new Human("Petrenko", "Petro", new DateTime(1999, 10, 25));
            //Console.WriteLine(h);
            //Human h2 = new Human();
            //Console.WriteLine(h2);
            //Student st1 = new Student("Ivanenko", "Ivan", new DateTime(1999, 5, 13), "It Step");
            //Console.WriteLine(st1);
        }
        static void Test2()
        {
            Human h;
            Student st1 = new Student("Ivanenko", "Ivan", new DateTime(1999, 5, 13), "It Step");
            h = st1;
            Console.WriteLine(h);
            ((Student)h).PrintUniver();

            Human[] arr = {
                new Student("Ivanenko", "Ivan", new DateTime(1999, 5, 13), "It Step"),
                new Teacher("Petrenko", "Inna", new DateTime(2010, 2, 13), "c++++"),
                new Worker("Stepanenko", "Anna", new DateTime(1963, 12, 26), "manager"),
              //  new Human("Vasylenko", "Piter", new DateTime(1985, 10, 26))
        };
            Console.WriteLine("------------------------------------------");
            foreach (var item in arr)
            {
                item.Print();
                item.Think();

                //(item as Student)?.Print();
                //(item as Worker)?.Print();
                //(item as Teacher)?.Print();

                //Console.WriteLine(item);
                //  ((Student)item).PrintUniver();
                // Console.WriteLine(item.GetType().Name);
                /////1
                // if (item.GetType().Name== "Student")
                //     ((Student)item).PrintUniver();
                // //2
                // try
                // {
                //     ((Student)item).PrintUniver();
                // }
                // catch { };
                // //3
                // Teacher teacher = item as Teacher;
                // if (teacher != null)
                //     teacher.PrintSubj();
                // //4
                // if (item is Worker)
                //     ((Worker)item).PrintJob();
                // //5
                // if (item is Worker)
                //     (item as Worker).PrintJob();
                // //6
                // if (item is Student st_temp)
                //     st_temp.PrintUniver();
                // //7
                // (item as Worker)?.PrintJob();

            }

        }

        static void Main(string[] args)
        {

            //  Test1();
            //  Test2();
            int a = 10;
            object ob = a;
            // double dd = (double)ob;

            int b = (int)ob;
            Console.WriteLine(a);
            Console.WriteLine(b);
            object ob2 = a;

            object[] arr = {
                    a,
                    25,
                    69.36,
                    true,
                   "Ivan"
            };
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
            double s = 0;
            foreach (var item in arr)
            {
               if (item is int) s+=(int)item;
               if (item is double) s+=(double)item;

            }

            Console.WriteLine("sum="+s);
            //Console.WriteLine(arr.Sum());





        }


    }
}
