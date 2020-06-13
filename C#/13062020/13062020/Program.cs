using System;
using System.Collections.Generic;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

using System.Xml.Serialization;

using Newtonsoft.Json;



//BIN, JSON, XML, SOAP

namespace _13062020
{
    [DataContract]
    [Serializable]
    public class StudCard
    {
        [DataMember]
        public string Serial { get; set; }
        [DataMember]
        public string Number { get; set; }
        public override string ToString()
        {
            return $"{Serial,2} {Number,8}";
        }
    }
    [DataContract]
    [Serializable]
    public class Student
    {
        [DataMember]
        int ID;
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public DateTime Bday { get; set; }
        [DataMember]
        public StudCard card { get; set; }

        [NonSerialized]
        const string Univer = "ItStep";
        public Student() : this(null, DateTime.Now)
        {
        }
        public Student(string Name, DateTime Bday)
        {
            ID = Name is null ? 0 : Name.GetHashCode();
            this.Name = Name;
            this.Bday = Bday;
        }
        [OnSerializing]
        private void OnSerializing(StreamingContext context) {
            Name = Name.ToUpper();
        }
        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            Name = Name.ToLower();
        }




        public override string ToString()
        {
            return $"{ID,10} {Name,-15} {Bday.ToShortDateString(),-15} {Univer,-8} |{card}|";
        }

    }


    class Program
    {
        //Binary
        static void SaveBinary(string fname, Student s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    BinaryFormatter format = new BinaryFormatter();
                    format.Serialize(stream, s);
                }
                Console.WriteLine("SaveBinary is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static Student LoadBinary(string fname)
        {
            Student s = null;
            try
            {
                using (Stream stream = File.OpenRead(fname))
                {
                    BinaryFormatter format = new BinaryFormatter();
                    s = format.Deserialize(stream) as Student;
                }
                Console.WriteLine("LoadBinary is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return s;
        }
        //Soap
        static void SaveSoap(string fname, Student s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    SoapFormatter format = new SoapFormatter();
                    format.Serialize(stream, s);
                }
                Console.WriteLine("SaveSoap is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static Student LoadSoap(string fname)
        {
            Student s = null;
            try
            {
                using (Stream stream = File.OpenRead(fname))
                {
                    SoapFormatter format = new SoapFormatter();
                    s = format.Deserialize(stream) as Student;
                }
                Console.WriteLine("LoadSoap is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return s;
        }
        //XML
        static void SaveXML<T>(string fname, T s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    XmlSerializer format = new XmlSerializer(typeof(T));
                    format.Serialize(stream, s);
                }
                Console.WriteLine("SaveXML is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static T LoadXML<T>(string fname)
        {
            T s = default;
            try
            {
                using (Stream stream = File.OpenRead(fname))
                {
                    XmlSerializer format = new XmlSerializer(typeof(T));
                    s = (T)format.Deserialize(stream);
                }
                Console.WriteLine("LoadXML is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return s;
        }
        //Json
        static void SaveJSON<T>(string fname, T s)
        {
            try
            {
                using (Stream stream = File.Create(fname))
                {
                    
                    DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(T));
                    format.WriteObject(stream, s);
                }
                Console.WriteLine("SaveJSON is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static T LoadJSON<T>(string fname)
        {
            T s = default;
            try
            {
                using (Stream stream = File.OpenRead(fname))
                {
                    DataContractJsonSerializer format = new DataContractJsonSerializer(typeof(T));
                    s = (T)format.ReadObject(stream);
                }
                Console.WriteLine("LoadJSON is OK");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return s;
        }

        static void Main(string[] args)
        {
            Student st = new Student("Petro", new DateTime(1986, 10, 25)) { card = new StudCard { Number = "123456", Serial = "CX" } };
            Console.WriteLine(st);
            string fname = "Piter.bin";
            SaveBinary(fname, st);
            Student nst = LoadBinary(fname);
            Console.WriteLine(nst);


            fname = "Piter.soap";
            SaveSoap(fname, st);
            Student nstsoap = LoadSoap(fname);
            Console.WriteLine(nstsoap);

            fname = "Piter.xml";
            SaveXML(fname, st);
            Student nstxml = LoadXML<Student>(fname);
            Console.WriteLine(nstxml);

            List<Student> gr = new List<Student> {
            new Student("Petro", new DateTime(2009, 10, 25)) { card=new StudCard { Number ="123456", Serial="CX" } },
            new Student("Ivan", new DateTime(1963, 10, 25)) { card=new StudCard { Number ="6258578", Serial="ER" } },
            new Student("Stepan", new DateTime(1986, 10, 25)) { card=new StudCard { Number ="645977", Serial="CX" } },
            new Student("Ira", new DateTime(2030, 10, 25)) { card=new StudCard { Number ="888888", Serial="VB" } },
            new Student("Anna", new DateTime(1999, 10, 25)) { card=new StudCard { Number ="999456", Serial="CX" } }
            };
            //fname = "students.xml";
            //SaveXML(fname, gr);
            //List<Student> ngr = LoadXML<List<Student>>(fname);
            //Console.WriteLine(ngr);
            //Console.WriteLine(String.Join("\n",ngr));


            Console.WriteLine(String.Join("\n", gr));

            fname = "students.json";
            SaveJSON(fname, gr);
            List<Student> ngrj = LoadJSON<List<Student>>(fname);
           Console.WriteLine(String.Join("\n", ngrj));


            string json = JsonConvert.SerializeObject(gr, Formatting.Indented);         
      
            Console.WriteLine(json);



        }
    }
}
