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
                NotePad notePad = new NotePad();
                Console.Clear();
                Console.WriteLine("1.New note\n2.Read notes\n3.Delete note\n4.Delete all notes");
                string answer = (Console.ReadLine());
                
                if (answer == "1")
                {
                    notePad.Write();
                }

                else if (answer == "2")
                {
                    notePad.Read();
                }

                else if (answer == "3")
                {
                    notePad.Delete();
                }

                else if (answer == "4")
                {
                    notePad.DeleteAll();
                }
                
                else
                {
                    Console.Clear();
                    Console.WriteLine("Not a correct input");
                    Console.ReadLine();
                }
            }
        }
    }
}
