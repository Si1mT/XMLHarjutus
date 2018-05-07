using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLNotepad
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.New note\n2.Read notes");
                int answer = int.Parse(Console.ReadLine());
                    
                if (answer == 1)
                {
                    Console.Clear();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    XmlNode xmlNode = xmlDocument.SelectSingleNode("Notes");
                    XmlNode node = xmlDocument.CreateElement("Note");
                    XmlAttribute Title = xmlDocument.CreateAttribute("Title");
                    Console.WriteLine("Insert note title:");
                    Title.Value = (Console.ReadLine());
                    node.Attributes.Append(Title);
                    XmlAttribute Content = xmlDocument.CreateAttribute("Content");
                    Console.WriteLine("Insert note content:");
                    Content.Value = Console.ReadLine();
                    node.Attributes.Append(Content);
                    xmlNode.AppendChild(node);
                    xmlDocument.Save("../../SavedNotes.xml");
                }

                else if(answer==2)
                {
                    Console.Clear();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    foreach(XmlNode note in xmlDocument.DocumentElement.ChildNodes)
                    {
                        Console.WriteLine(note.Attributes["Title"].Value+":");
                        Console.WriteLine(note.Attributes["Content"].Value);
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }

                else
                {

                }
            }
        }

        class Note
        {
            public string Title { get; set; }
            public string Content { get; set; }
        }
    }
}
