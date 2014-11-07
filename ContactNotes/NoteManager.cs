using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public class NoteManager
    {
        List<Note> NoteList;

        public void GetNoteList(string ContactID)
        {
            NoteList = new List<Note>();

            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_NoteID_List @ContactID="+ContactID);

            if (results.Count > 0)
            {
                for (int counter = 1; counter < results[0].Count; counter++)
                {
                    Note tmpNote = new Note();
                    tmpNote.NoteID = Convert.ToInt32(results[0][counter]);
                    tmpNote.Load();

                    NoteList.Add(tmpNote);
                }
            }
        }

        public void PopulateNoteList(ListView currentListView)
        {
            currentListView.Items.Clear();

            foreach(Note tmpNote in NoteList)
            {
                ListViewItem tmpListViewItem;
                if(tmpNote.NoteTitle.Length>0)
                {
                    tmpListViewItem = new ListViewItem(TrimToFifty(tmpNote.NoteTitle));
                }
                else
                {
                    tmpListViewItem = new ListViewItem(TrimToFifty(tmpNote.NoteText));
                }

                tmpListViewItem.SubItems.Add(BuildDate(tmpNote.NoteCreated));
                tmpListViewItem.SubItems.Add(tmpNote.NoteID.ToString());

                currentListView.Items.Add(tmpListViewItem);
            }
        }

        private string TrimToFifty(string inputString)
        {
            string outputString = "";
            if(inputString == null)
            {
                return outputString;
            }
            else if(inputString.Length == 0)
            {
                return outputString;
            }
            else if(inputString.Length < 50)
            {
                return inputString;
            }
            else if(inputString.Length > 50)
            {
                return inputString.Substring(0, 50);
            }
            return outputString;
        }

        private string BuildDate(DateTime inputDateTime)
        {
            string outputString = "";
            outputString = inputDateTime.Month.ToString()+"/"+inputDateTime.Day.ToString()+"/"+inputDateTime.Year.ToString();

            return outputString;
        }
    }
}
