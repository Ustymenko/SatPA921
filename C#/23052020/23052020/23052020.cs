using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _23052020
{
    //event
    class Student
    {
        public String Name { get; set; }
        public DateTime Bday { get; set; }
        public List<int> marks = new List<int>();//5,3,10,11,8
        public void SetMark(int m) => marks.Add(m);
        public override string ToString() => $"|{Name,-10}|{Bday.ToShortDateString(),12}|" +
                $"{String.Join(", ", marks)}|";
    }
    class Aspirant
    {
        public String Name { get; set; }
        public DateTime Bday { get; set; }
        public List<int> marks = new List<int>();//5,3,10,11,8
        public void SetOcinka(int m) => marks.Add(m);
        public override string ToString() => $"|{Name,-10}|{Bday.ToShortDateString(),12}|" +
                $"{String.Join(", ", marks)}|";
    }
    delegate void DelegateMark(int m);
    class Teacher
    {
        public String Name { get; set; }
        public DateTime Bday { get; set; }
        public override string ToString() => $"|{Name,-10}|{Bday.ToShortDateString(),12}|";

        public event DelegateMark Exam;

        DelegateMark[] hal = new DelegateMark[3];
        public event DelegateMark ExamThree12
        {
            add
            {
                for (int i = 0; i < hal.Length; i++)
                {
                    if (hal[i] is null)
                    {
                        hal[i] = value;
                        break;
                    }
                }
            }
            remove
            {

                for (int i = 0; i < hal.Length; i++)
                {
                    if (hal[i] == value)
                    {
                        hal[i] = null;
                        break;
                    }
                }


            }
        }

        public void SetMark()
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            //Exam(rnd.Next(1,13));
            //if (Exam!=null)
            //    Exam.Invoke(rnd.Next(1,13));
            Exam?.Invoke(rnd.Next(1, 13));
        }
        public void SetMarkH()
        {
            foreach (var method in hal)
            {
                method?.Invoke(55);
            }
        }
    }

    class Program
    {
        static void Test()
        {
            Teacher teacher = new Teacher
            {
                Name = "Ivan",
                Bday = new DateTime(1996, 10, 25),

            };


            Student st1 = new Student
            {
                Name = "Piter",
                Bday = new DateTime(1996, 10, 25),
                marks = new List<int> { 10 }
            };
            Console.WriteLine(st1);
            Aspirant asp1 = new Aspirant
            {
                Name = "Stepan",
                Bday = new DateTime(2013, 10, 25),
                marks = new List<int> { 3 }
            };
            Console.WriteLine(asp1);

            teacher.Exam += Start_Exam;
            teacher.Exam += st1.SetMark;
            teacher.Exam += asp1.SetOcinka;
            teacher.Exam += Finish_Exam;
            teacher.SetMark();
            Console.WriteLine(st1);
            Console.WriteLine(asp1);
        }
        static void Test2()
        {
            Teacher teacher = new Teacher
            {
                Name = "Ivan",
                Bday = new DateTime(1996, 10, 25),
            };
            Student[] gr = {
                new Student { Name = "Piter", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 10,5,6 }},
                 new Student { Name = "Ira", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 10,6 }},
                  new Student { Name = "Anna", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 5,6 }},
                   new Student { Name = "Igor", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 8}}
            };
            Aspirant[] gra = {
                new Aspirant { Name = "APiter", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 11,10,5,6 }},
                 new Aspirant { Name = "AIra", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 10,6 ,4}},
                  new Aspirant { Name = "AAnna", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 5,8,6 }},
                   new Aspirant { Name = "AIgor", Bday = new DateTime(1996, 10, 25),
                                marks = new List<int> { 8,9}}
            };

            Console.WriteLine($"{String.Join("\n", gr.ToList())}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{String.Join("\n", gra.ToList())}");

            for (int i = 0; i < gr.Length; i++)
                teacher.Exam += gr[i].SetMark;

            for (int i = 0; i < gra.Length; i++)
                teacher.Exam += gra[i].SetOcinka;

            teacher.Exam -= gr[1].SetMark;

            for (int i = 0; i < gr.Length; i++)
                teacher.ExamThree12 += gr[i].SetMark;

            teacher.ExamThree12 -= gr[2].SetMark;

            for (int i = 0; i < gra.Length; i++)
                teacher.ExamThree12 += gra[i].SetOcinka;

            //teacher.Exam += Start_Exam;
            //teacher.Exam += st1.SetMark;
            //teacher.Exam += asp1.SetOcinka;
            //teacher.Exam += Finish_Exam;
            teacher.SetMark();
            teacher.SetMarkH();


            Console.WriteLine("-------------------MMM--------------------");
            Console.WriteLine($"{String.Join("\n", gr.ToList())}");
            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"{String.Join("\n", gra.ToList())}");
        }

        private static void Start_Exam(int m)
        {
            Console.WriteLine("Start_Exam"); ;
        }
        private static void Finish_Exam(int m)
        {
            Console.WriteLine("Finish_Exam"); ;
        }

        static void Main(string[] args)
        {
            //  Test();
            Test2();
        }
    }
}
