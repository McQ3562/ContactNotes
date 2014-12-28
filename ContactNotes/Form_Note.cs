using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public partial class Form_Note : Form
    {
        int contactID;
        string noteID;
        Note currentNote;

        public int ContactID { get { return contactID; } set { contactID = value; } }
        public string NoteID { get { return noteID; } set { noteID = value; } }

        public Form_Note()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            textBox_NoteTitle.Text = "";
            textBox_Note.Text = "";
            textBox_CreateDate.Text = "";
            textBox_LastEditDate.Text = "";

            currentNote = new Note();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void Form_Note_Load(object sender, EventArgs e)
        {
            Note.LoadListView(listView_Note, ContactID);
            
            if(NoteID != null)
            {
                DisplayNote(NoteID);
            }
        }

        private void listView_Note_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem tmpItem = listView_Note.SelectedItems[0];
            DisplayNote(tmpItem.SubItems[2].Text);
        }

        private void DisplayNote(string NoteID)
        {
            Note tmpNote = new Note();
            tmpNote.NoteID = Convert.ToInt32(NoteID);
            tmpNote.Load();

            textBox_NoteTitle.Text = tmpNote.NoteTitle;
            textBox_Note.Text = tmpNote.NoteText;
            textBox_CreateDate.Text = tmpNote.NoteCreated.ToShortDateString();
            textBox_LastEditDate.Text = tmpNote.NoteEdited.ToShortDateString();
        }
    }
}
