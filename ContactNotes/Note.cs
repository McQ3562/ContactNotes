using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public class Note
    {
        int noteID;
        string noteTitle;
        string noteText;
        DateTime noteCreated;
        DateTime noteEdited;

        public int NoteID
        {
            get { return noteID; }
            set { noteID = value; }
        }
        public string NoteTitle
        {
            get { return noteTitle; }
            set { noteTitle = value; }
        }
        public string NoteText
        {
            get { return noteText; }
            set { noteText = value; }
        }
        public DateTime NoteCreated
        {
            get { return noteCreated; }
            set { noteCreated = value; }
        }
        public DateTime NoteEdited
        {
            get { return noteEdited; }
            set { noteEdited = value; }
        }

        public void Save()
        {
            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_ADD_Note @NoteTitle='"+noteTitle+"' @Note='"+noteText+"'");
        }

        public void Load()
        {
            List<List<string>> results = new List<List<string>>();
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_Note @NoteID=" + noteID);

            noteID = Convert.ToInt32(results[0][1]);
            noteTitle = results[1][1];
            noteText = results[2][1];
            noteCreated = Convert.ToDateTime(results[3][1]);
            noteEdited = Convert.ToDateTime(results[4][1]);
        }

        public static List<Note> LoadList(int ContactID)
        {
            List<Note> noteList = new List<Note>();
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_NoteID_List @ContactID="+ContactID.ToString());

            if(results.Count > 0)
            {
                for(int counter=1;counter<results[0].Count;counter++)
                {
                    Note tmpNote = new Note();
                    tmpNote.NoteID = Convert.ToInt32(results[0][counter]);
                    tmpNote.Load();

                    noteList.Add(tmpNote);
                }
            }
            return noteList;
        }

        public static void LoadListView(ListView ListViewToLoad, int ContactID)
        {
            List<Note> noteList = Note.LoadList(ContactID);
            foreach (Note tmpNote in noteList)
            {
                ListViewItem tmpItem = new ListViewItem(tmpNote.NoteTitle);
                tmpItem.SubItems.Add(tmpNote.NoteEdited.ToString());
                tmpItem.SubItems.Add(tmpNote.NoteID.ToString());

                ListViewToLoad.Items.Add(tmpItem);
            }
        }
    }
}
