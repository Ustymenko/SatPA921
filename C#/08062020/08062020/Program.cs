using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Threading.Tasks;

namespace _08062020
{
    class Program
    {
        static void CreateXML()
        {
            try
            {
                using (var writer = new XmlTextWriter("students.xml", Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.WriteStartDocument();
                    {
                        writer.WriteDocType("students", null, null, "<!ENTITY hello \"Привіт, \">");
                        writer.WriteStartElement("students");
                        {
                            writer.WriteComment("test comment");
                            writer.WriteStartElement("student");
                            {
                                writer.WriteStartElement("pib");
                                {
                                    writer.WriteEntityRef("hello");
                                    writer.WriteString("Іваненко Іван Іванович");
                                }
                                writer.WriteEndElement();
                                writer.WriteElementString("bday", "02.05.1996");
                                writer.WriteElementString("avg", "10,99");
                                writer.WriteStartElement("address");
                                {
                                    writer.WriteAttributeString("region", "Житомирська обл.");
                                    writer.WriteAttributeString("country", "Україна");
                                    writer.WriteString("Житомир");
                                }

                            }
                            writer.WriteEndElement();
                        }
                        writer.WriteEndElement();
                    }
                    writer.WriteEndDocument();




                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void ReaderXML()
        {
            try
            {
                using (var reader = new XmlTextReader("Students.xml"))
                {
                    reader.WhitespaceHandling = WhitespaceHandling.None;
                    while (reader.Read())
                    {
                        Console.WriteLine($"NodeType={reader.NodeType,15} " +
                            $"Name={reader.Name,10} " +
                            $"Value={reader.Value,20}");
                        if (reader.AttributeCount > 0)
                        {
                            while (reader.MoveToNextAttribute())
                            {
                                Console.WriteLine($"NodeType={reader.NodeType,15} " +
                               $"Name={reader.Name,10} " +
                               $"Value={reader.Value,20}");
                            }
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        static void ShowNode(XmlNode node)
        {
            Console.WriteLine($"NodeType={node.NodeType,15} " +
                               $"Name={node.Name,10} Value={node.Value,20}");
            if (node.Attributes != null)
                foreach (XmlAttribute attrib in node.Attributes)
                    Console.WriteLine($"NodeType={attrib.NodeType,15} " +
                                $"Name={attrib.Name,10} Value={attrib.Value,20}");
            foreach (XmlNode item in node.ChildNodes)
                ShowNode(item);
        }
        static void ReadDOM()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Students.xml");
                ShowNode(doc.DocumentElement);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("doc Load");
        }
        static void AddNodeDOM()
        {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("Students.xml");
                XmlNode root= doc.DocumentElement;
                root.RemoveChild(root.FirstChild);
                XmlElement stud = doc.CreateElement("student");
                {
                    XmlElement pib = doc.CreateElement("pib");
                    {
                        XmlEntityReference xmlEntity = doc.CreateEntityReference("hello");
                        XmlText name = doc.CreateTextNode("Федоренко Федір Федорович");
                        pib.AppendChild(xmlEntity);
                        pib.AppendChild(name);
                    }
                    stud.AppendChild(pib);

                    XmlElement bday = doc.CreateElement("bday");
                    bday.InnerText = "25.05.2013";
                    stud.AppendChild(bday);

                    XmlElement avg = doc.CreateElement("avg");
                    avg.InnerText = "25,98";
                    stud.AppendChild(avg);

                    XmlElement address = doc.CreateElement("address");
                    {
                        XmlAttribute region = doc.CreateAttribute("region");
                        region.Value= "Житомирська обл.";
                        address.Attributes.Append(region);
                        
                        XmlAttribute country = doc.CreateAttribute("country");
                        country.Value= "Україна";
                        address.Attributes.Append(country);

                      
                        XmlText city = doc.CreateTextNode("Бердичів");
                        address.AppendChild(city);

                    }
                    stud.AppendChild(address);
                }
                root.AppendChild(stud);
                doc.Save("StudentsNew.xml");
                Console.WriteLine("Add node in tree");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }   
        }
        static void TestXPath() {
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("StudentsNew.xml");
                XmlNode root=doc.DocumentElement;
                XmlNodeList students = root.SelectNodes("*");
                foreach (XmlNode st in students)
                {
                    //Console.WriteLine(st.InnerText);
                    Console.WriteLine(st.OuterXml);
                }
                Console.WriteLine("-------------------------------------");
                root.SelectNodes("*")//   //student
                    .OfType<XmlNode>()
                    .Select(node => node.InnerText)
                    .ToList()
                    .ForEach(Console.WriteLine);
                Console.WriteLine("-------------------------------------");
                root.SelectNodes("//student/pib")  //  //pib
                    .OfType<XmlNode>()
                    .Select(node => node.InnerText)
                    .ToList()
                    .ForEach(Console.WriteLine);

                Console.WriteLine("-------------------------------------");
                root.SelectNodes("//address[@country='Україна']")  //  
                    .OfType<XmlNode>()
                    .Select(node => node.ParentNode.InnerText)
                    .ToList()
                    .ForEach(Console.WriteLine);
                Console.WriteLine("-------------------------------------");
                       
                Console.WriteLine("-------------------------------------");
                root.SelectNodes("//address")  //  //pib
                    .OfType<XmlNode>()
                    .Select(node =>  
                        node.InnerText+" "+
                        String.Join(" ", node.Attributes.OfType<XmlAttribute>().Select(at => at.InnerText).ToArray())
                          )
                    .ToList()
                    .ForEach(Console.WriteLine);
                Console.WriteLine("doc XPath");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }




        }
        static void Main(string[] args)
        {
            //XAML SVG
            // CreateXML();
            // ReaderXML();

            // ReadDOM();
            //AddNodeDOM();

            // XPath

            TestXPath();
            Console.ReadKey();
        }
    }
}
