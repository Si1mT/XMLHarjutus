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
                Console.WriteLine("1.New note\n2.Read notes\n3.Delete note\n4.Delete all notes");
                string answer = (Console.ReadLine());

                if (answer == "1")
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

                else if (answer == "2")
                {
                    Console.Clear();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    foreach (XmlNode note in xmlDocument.DocumentElement.ChildNodes)
                    {
                        Console.WriteLine(note.Attributes["Title"].Value + ":");
                        Console.WriteLine(note.Attributes["Content"].Value);
                        Console.WriteLine();
                    }
                    Console.ReadLine();
                }

                else if (answer == "3")//pooleli
                {
                    Console.Clear();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    XmlNodeList nodes = xmlDocument.SelectNodes("Notes");
                    foreach (XmlNode note in xmlDocument.DocumentElement.ChildNodes)
                    {
                        Console.WriteLine(note.Attributes["Title"].Value + ":");
                        Console.WriteLine(note.Attributes["Content"].Value);
                        Console.WriteLine();
                    }
                    Console.WriteLine("Enter the title of the note to delete");
                    var title = (Console.ReadLine());
                    foreach(XmlNode node in nodes)
                    {
                        if (node.Attributes["Title"].Value == title)
                        {
                            node.ParentNode.RemoveChild(node);
                            xmlDocument.Save("/../../SavedNotes.xml");

















                            //string nodetitle = node.Attributes["Title"].Value;
                            //string nodetitlestring = nodetitle.ToString();

                            //if (nodetitle != null && nodetitlestring == title)
                            //{
                            //    node.RemoveAll();
                            //    xmlDocument.Save("../../savednotes.xml");
                            //    //if (nodetitle == title)
                            //    //{
                            //    //    node.removeall();
                            //    //    xmldocument.save("../../savednotes.xml");
                            //    //}
                            //    //else
                            //    //{

                            //    //}
                            //}
                            //else; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
                        }
                        else; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ; ;
                        //var nodeTitle = node.GetAttribute("Name");//node.Attributes["Title"].Value;//node.Value;
                        //if (nodetitle == title)
                        //{
                        //    node.removeall();
                        //    xmldocument.save("../../savednotes.xml");
                        //}
                        //else
                        //{

                        //}
                    }
                }

                else if (answer == "4")
                {
                    Console.Clear();
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    //XmlNodeList nodes = xmlDocument.SelectNodes("Notes");
                    XmlNode nodeNotes = xmlDocument.SelectSingleNode("Notes");
                    nodeNotes.RemoveAll();
                    xmlDocument.Save("../../SavedNotes.xml");
                    Console.WriteLine("All notes deleted");
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
