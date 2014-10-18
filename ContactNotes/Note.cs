using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactNotes
{
    class Note
    {
        string noteTitle;
        string note;

        public string NoteTitle
        {
            get { return noteTitle; }
            set { noteTitle = value; }
        }
        public string Note
        {
            get { return note; }
            set { note = value; }
        }
    }
}
