using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace XMLNotepad
{
    /// <summary>
    /// The class <c>NotePad</c> holds the functions used for reading, writing, deleting and deleting all notes
    /// </summary>
    /// <remarks>
    /// Inherits from the <c>XmlDocument</c> class
    /// </remarks>
    class NotePad : XmlDocument
    {
        /// <summary>
        /// Displays all saved notes
        /// </summary>
        /// <remarks>
        /// uses a foreach loop to write out notes one by one
        /// </remarks>
        public void Read()
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

        /// <summary>
        /// Creates a xml note by asking the user to input the note title and content
        /// </summary>
        public void Write()
        {
            Console.Clear();
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load("../../SavedNotes.xml");
            XmlNode xmlNode = xmlDocument.SelectSingleNode("Notes");
            XmlNode node = xmlDocument.CreateElement("Note");
            XmlAttribute Title = xmlDocument.CreateAttribute("Title");
            while (true)
             {
                Console.Clear();
                Console.WriteLine("Insert note title:");
                Title.Value = (Console.ReadLine());
                string titleString = Title.Value;
                if (string.IsNullOrWhiteSpace(Title.Value))
                {
                    Console.Clear();
                    Console.WriteLine("Title can't be empty");
                    Console.ReadLine();
                }
                else
                {
                    break;
                }
             }
            node.Attributes.Append(Title);
            XmlAttribute Content = xmlDocument.CreateAttribute("Content");
            Console.WriteLine("Insert note content:");
            Content.Value = Console.ReadLine();
            node.Attributes.Append(Content);
            xmlNode.AppendChild(node);
            xmlDocument.Save("../../SavedNotes.xml");
        }

        /// <summary>
        /// Deletes a single note by asking the title of the note that should be deleted
        /// </summary>
        public void Delete()
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
            foreach (XmlNode node in xmlDocument.DocumentElement.ChildNodes)
            {
                if (node.Attributes["Title"].Value == title)
                {
                    node.ParentNode.RemoveChild(node);
                    xmlDocument.Save("../../SavedNotes.xml");
                }

                else
                {

                }
            }
        }

        /// <summary>
        /// Deletes all currently saved notes, asks for confirmation before deleting all notes
        /// </summary>
        public void DeleteAll()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Are you sure?(y/n)");
                string sureAnswer = (Console.ReadLine());

                if (sureAnswer == "y")
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load("../../SavedNotes.xml");
                    XmlNode nodeNotes = xmlDocument.SelectSingleNode("Notes");
                    nodeNotes.RemoveAll();
                    xmlDocument.Save("../../SavedNotes.xml");
                    Console.Clear();
                    Console.WriteLine("All notes deleted");
                    Console.ReadLine();
                    break;
                }
                else if (sureAnswer == "n")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid answer");
                    Console.ReadLine();
                }
            }
        }
    }
}
