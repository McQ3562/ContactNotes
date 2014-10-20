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
        Note currentNote;
        NoteManager noteManager;
        List<Note> noteList = new List<Note>();

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

        }

        private void button_Save_Click(object sender, EventArgs e)
        {

        }

        private void Form_Note_Load(object sender, EventArgs e)
        {
            LoadNoteList();
        }

        public void LoadNoteList()
        {
            
        }
    }
}
