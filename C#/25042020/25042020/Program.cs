using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Тема Інтерфейси
namespace _25042020
{
    public interface IShow
    {
        void Show();
    }
    public interface IArea
    {
        double Square();
    }
    public interface ICharacterGeometri : IArea
    {
        double Perimeter();
    }
    //public interface ICharacterGeometri
    //{
    //    double Square();
    //    double Perimeter();
    //}

    class Human : IShow, IComparable, ICloneable
    {
        public string Name { get; set; }
        public DateTime Bday { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone(); //???? not ref
           // return new Human {Name = Name, Bday= Bday };
        }

        public int CompareTo(object obj)
        {
            if (obj is Human h) {
                return Name.CompareTo(h.Name);
            }
            throw new Exception("Bad cast");
        }

        public void Show()
        {
            Console.WriteLine($"Human: Name:{Name,15}  Bday:{Bday.ToShortDateString()} ");
        }
        public override string ToString()
        {
            return $"|{Name,-15}|{Bday.ToShortDateString()}|";
        }
    }
    class DateComp : IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Human h1 && y is Human h2)
            {
                return DateTime.Compare(h1.Bday, h2.Bday);
            }
            throw new Exception("Bad cast");
        }
    }


    class Workers: IEnumerable
    {
        Human[] Humans = {
            new Human { Name = "Petro", Bday = new DateTime(1996, 5, 23) },
            new Human { Name = "Avram", Bday = new DateTime(1998, 5, 13) },
            new Human { Name = "Piter", Bday = new DateTime(1993, 5, 20) },
            new Human { Name = "Igor", Bday = new DateTime(1960, 5, 3) },
            new Human { Name = "Anna", Bday = new DateTime(2019, 5, 10) }
        };

        

        public IEnumerator GetEnumerator()
        {
            return Humans.GetEnumerator();
        }
        public void Sort()
        {
            Array.Sort(Humans);
        }
        public void Sort(IComparer CMP)
        {
            Array.Sort(Humans,CMP);
        }

    }




    class Circle : ICharacterGeometri, IShow
    {
        public double R { get; set; }
        public double Perimeter()
        {
            return 2 * Math.PI * R;
        }
        public void Show()
        {
            Console.WriteLine($"Circle: R={R}");
        }
        public double Square()
        {
            return Math.PI * R * R;
        }
    }
    class Rectangle : ICharacterGeometri, IShow
    {
        public double a { get; set; }
        public double b { get; set; }
        public double Perimeter()
        {
            return 2 * (b + a);
        }
        public void Show()
        {
            Console.WriteLine($"Rectangle: a={a} b={b}");
        }
        public double Square()
        {
            return b * a;
        }
    }

    interface IA
    {
        void Show();
    }
    interface IB
    {
        void Show();
    }
    interface IC
    {
        void Show();
    }
    class MyClass : IA, IB, IC
    {
        //public void Show()
        //{
        //    Console.WriteLine("Hello");
        //}
        void IA.Show()
        {
            Console.WriteLine("Hello IA.Show");
        }
        void IB.Show()
        {
            Console.WriteLine("Hello IB.Show");
        }
        void IC.Show()
        {
            Console.WriteLine("Hello IC.Show");
        }
    }


    class Program
    {
        public static void Main()
        {
            //Task1();
            // Task2();
            Task3();
        }
        public static void Task3()
        {
            Workers workers = new Workers();
            foreach (var human in workers)
                   Console.WriteLine(human);
            Console.WriteLine("---------------------------------------------------");
            workers.Sort();
            foreach (var human in workers)
                   Console.WriteLine(human);
            Console.WriteLine("---------------------------------------------------");
            workers.Sort(new DateComp());
            foreach (var human in workers)
                Console.WriteLine(human);
            Console.WriteLine("---------------------------------------------------");
            Human H = new Human { Name = "Petro", Bday = new DateTime(1996, 5, 23) };
            Human nH = H.Clone() as Human;
            nH.Name = "Ivan";
            Console.WriteLine(H);
            Console.WriteLine(nH);

        }
        public static void Task2()
        {
            MyClass my = new MyClass();
            //  my.Show();


            IA ia = my;
            ia.Show();

            IB ib = my;
            ib.Show();

            (my as IC)?.Show();


        }
        public static void Task1()
        {
            Circle C = new Circle { R = 1 };
            // C.Show();
            TestIShow(C);
            TestICharacterGeometri(C);
            Rectangle R = new Rectangle { a = 2, b = 5 };
            //    R.Show();
            TestIShow(R);
            TestICharacterGeometri(R);
            Human H = new Human { Name = "Petro", Bday = new DateTime(1996, 5, 23) };
            //   H.Show();
            TestIShow(H);
            // TestICharacterGeometri(H);

            IShow ishow = H;

            ishow.Show();

            Human H2 = (Human)ishow;
            if (ishow is Human H3)
            {
                H3.Name = "Igor";
            }

            // H2.Name = "Ivan";
            // ishow.Name = "";
            ishow.Show();
            //ishow = C;
            //ishow = R;


        }
        public static void TestIShow(IShow ishow)
        {
            ishow.Show();
        }
        public static void TestICharacterGeometri(ICharacterGeometri ob)
        {
            Console.WriteLine($"{ob.GetType().Name} Perimeter:{ob.Perimeter()}  Square:{ob.Square()} ");

        }



    }
}
