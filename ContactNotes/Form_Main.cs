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
        Contact currentContact;
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

        private void listView_CustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentNoteManager.GetNoteList();
            currentNoteManager.PopulateNoteList(listView_NoteList);
        }

        private void listView_CustomerList_DoubleClick(object sender, EventArgs e)
        {
            //currentContact = 
            string test = listView_CustomerList.SelectedItems[0].SubItems[1].Text;
            DisplayCurrentContact();
        }

        private void DisplayCurrentContact()
        {
            textBox_FirstName.Text = currentContact.FirstName;
            textBox_LastName.Text = currentContact.LastName;
            //textBox_PhoneNumber.Text = currentContact.
            //comboBox_PhoneType.Text = currentContact.
            //comboBox_Status.Text = currentContact.
            //comboBox_Potentual.Text = currentContact.
            //textBox_Address.Text = currentContact
            //textBox_City.Text = currentContact
            //comboBox_State.Text = currentContact
            //textBox_Zipcode.Text = currentContact

        }
    }
}
