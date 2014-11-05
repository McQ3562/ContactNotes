﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public partial class Form_Main : Form
    {
        Contact currentContact = new Contact();
        ContactManager currentContactManager = new ContactManager();
        NoteManager currentNoteManager = new NoteManager();

        public Form_Main()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_NewContact_Click(object sender, EventArgs e)
        {
            Form_Contact tmpContact = new Form_Contact();
            tmpContact.ShowDialog();
        }

        private void button_NewNote_Click(object sender, EventArgs e)
        {
            Form_Note tmpNote = new Form_Note();
            tmpNote.ShowDialog();
        }

        private void button_OpenContact_Click(object sender, EventArgs e)
        {
            Form_Contact tmpContact = new Form_Contact();
            tmpContact.ShowDialog();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            currentContactManager.GetContactList();
            currentContactManager.PopulateContactList(listView_CustomerList);


        }

        private void listView_CustomerList_DoubleClick(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selection = listView_CustomerList.SelectedItems;
            string FirstName = selection[0].SubItems[0].Text;
            string LastName = selection[0].SubItems[1].Text;
            string ContactID = selection[0].SubItems[2].Text;

            currentContact.ContactID = Convert.ToInt32(ContactID);
            currentContact.Load();

            DisplayContact();

            currentNoteManager.GetNoteList();
            currentNoteManager.PopulateNoteList(listView_NoteList);
        }

        public void DisplayContact()
        {

        }
    }
}
