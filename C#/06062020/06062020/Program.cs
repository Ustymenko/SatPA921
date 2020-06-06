using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace _06062020
{
    class Program
    {
        static void SaveFileFS(string file)
        {
            using (FileStream stream = new FileStream(
                file, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                byte[] header = { 0xFF, 0xFE };        // UCS-2  LE BOM
                stream.Write(header, 0, header.Length);

                string text = "Hello Несе Галя воду";
                byte[] textBytes = Encoding.Unicode.GetBytes(text);

                stream.Write(textBytes, 0, textBytes.Length);
                Console.WriteLine("File saved");

                //stream.Close();
            }

            //FileStream stream2=null;
            //try {
            //    stream2 = new FileStream(
            //    file, FileMode.Create, FileAccess.Write, FileShare.None);
            //}
            //finally {       stream2.Dispose();       }

        }

        static void LoadFileFS(string file)
        {
            using (FileStream stream = new FileStream(
                file, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                byte[] textBytes = new byte[stream.Length - 2];

                //  stream.Read(textBytes, 0, 2);
                stream.Seek(2, SeekOrigin.Begin);
                //  Console.WriteLine(stream.Position);
                stream.Read(textBytes, 0, textBytes.Length);
                string text = Encoding.Unicode.GetString(textBytes);

                Console.WriteLine(text);
                Console.WriteLine("File load");


            }



        }
        static void SaveFileSW(string file)
        {
            using (StreamWriter stream =
                //  new StreamWriter(file,false,Encoding.Unicode))
                new StreamWriter(file, true, Encoding.Unicode))
            {
                string text = "10\n20";
                stream.WriteLine(text);
                Console.WriteLine("File saved");
            }

        }
        static void LoadFileSW(string file)
        {
            using (StreamReader stream = new StreamReader(file, Encoding.Unicode))
            {
                // Console.WriteLine(stream.EndOfStream);
                //// Console.WriteLine(stream.Peek());//72
                // Console.WriteLine((char)stream.Peek());//H
                // Console.WriteLine((char)stream.Read());//H

                // string text = stream.ReadToEnd();

                // Console.WriteLine(text);

                int a = int.Parse(stream.ReadLine());
                int b = int.Parse(stream.ReadLine());
                Console.WriteLine($"{a}+{b}={a + b}");

                Console.WriteLine("File load");


            }
        }

        static void SaveFileBW(string file)
        {
            using (FileStream stream = new FileStream(file, FileMode.Create))
            {
                using (BinaryWriter bs = new BinaryWriter(stream, Encoding.Unicode))
                {
                    string text = "Hello HelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHelloHello+ + + +";
                    bs.Write(text);
                    bs.Write(5);
                    //bs.Write(15.966);
                    //bs.Write(true);
                    Console.WriteLine("File saved");
                }
            }
        }
        static void LoadFileBW(string file)
        {
            using (FileStream stream = new FileStream(file, FileMode.Open))
            {
                using (BinaryReader br = new BinaryReader(stream, Encoding.Unicode))
                {
                    string text = br.ReadString();
                    int i = br.ReadInt32();
                    //double  d = br.ReadDouble();
                    //bool  b = br.ReadBoolean();

                    Console.WriteLine(text);
                    Console.WriteLine(i);
                    //Console.WriteLine(d);
                    //Console.WriteLine(b);

                    Console.WriteLine("File load");
                }
            }
        }
        static void SaveFile(string file)
        {
            FileInfo fileInf = new FileInfo(file);
            if (fileInf.Exists)
            {
                Console.WriteLine($"{fileInf.FullName}");
                Console.WriteLine($"{fileInf.Name}");
                Console.WriteLine($"{fileInf.CreationTime}");
                Console.WriteLine($"{fileInf.Length}");

                //string text = File.ReadAllText(file);
                // Console.WriteLine($"{text}");
                string[] lines = File.ReadAllLines(file);
                File.WriteAllLines(file, lines);
                File.AppendAllText(file, "8778787458");

                Console.WriteLine($"{String.Join("\n", lines)}");
            }
            else
            {
                File.WriteAllText(file, "Hello Привіт");
            }

            //DriveInfo
            //Directory, DirectoryInfo
        }

        static void InfoDirectory()
        {
            DirectoryInfo directory = new DirectoryInfo(@"c:\Qt\");
            if (directory.Exists)
            {
                Console.WriteLine(directory.FullName);
                Console.WriteLine(directory.CreationTime);

                //void TT(string d)
                directory.GetFiles()
                    .Where(fi=>fi.Length>500)
                    .Select(fi => fi.Name +"\t"+ fi.Length)
                    .ToList()
                    .ForEach(Console.WriteLine);
            }



        }
        static void Main(string[] args)
        {
            string file = "2.txt";
            //SaveFileFS(file);
            //LoadFileFS(file);
            // SaveFileSW(file);
            //  LoadFileSW(file);

            //file = "3.txt";
            //SaveFileBW(file);
            //LoadFileBW(file);
            file = "4.txt";
            // SaveFile(file);

            InfoDirectory();


        }
    }
}
