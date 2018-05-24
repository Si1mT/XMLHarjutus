using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLNotepad
{
    /// <summary>
    /// The class used to define attributes in the xml file
    /// <example>
    /// <code>
    /// <Note Title="noteTitle" Content="noteContent"/>
    /// </code>
    /// </example>
    /// </summary>
    class Note
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
