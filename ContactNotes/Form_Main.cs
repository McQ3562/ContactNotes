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
    public partial class Form_Main : Form
    {
        public Contact currentContact = new Contact();
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
            tmpNote.ContactID = currentContact.ContactID;
            tmpNote.ShowDialog();
        }

        private void button_OpenContact_Click(object sender, EventArgs e)
        {
            Form_Contact tmpContact = new Form_Contact();
            tmpContact.CurrentContact = currentContact;
            tmpContact.ShowDialog();

            listView_CustomerList.Items.Clear();
            currentContactManager.GetContactList();
            currentContactManager.PopulateContactList(listView_CustomerList);
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            try
            {
                currentContactManager.GetContactList();
                currentContactManager.PopulateContactList(listView_CustomerList);

                PhoneType.LoadComboBox(comboBox_PhoneType);
                Status.LoadComboBox(comboBox_Status);
                Potentual.LoadComboBox(comboBox_Potentual);
                State.LoadComboBox(comboBox_State);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message + "/n" + err.InnerException + "/n" + err.StackTrace);
            }
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

            //Display Notes
            listView_NoteList.Items.Clear();
            currentNoteManager.GetNoteList(ContactID);
            currentNoteManager.PopulateNoteList(listView_NoteList);
        }

        private void listView_NoteList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem selectedItem = listView_NoteList.SelectedItems[0];
            Form_Note FN = new Form_Note();
            FN.ContactID = currentContact.ContactID;
            FN.NoteID = selectedItem.SubItems[2].Text;

            FN.ShowDialog();
        }

        public void DisplayContact()
        {
            textBox_FirstName.Text = currentContact.FirstName;
            textBox_LastName.Text = currentContact.LastName;
            comboBox_Status.Text = currentContact.Status;
            comboBox_Potentual.Text = currentContact.Potentual;
            textBox_StatusDate.Text = currentContact.StatusUpdateDate.ToString();

            Phone primaryPhone = currentContact.ContactPhoneManager.GetPrimaryPhone();
            textBox_Phone.Text = primaryPhone.ContactPhoneNumber;
            comboBox_PhoneType.Text = primaryPhone.ContactPhoneTypeID;

            Address primaryAddress = currentContact.ContactAddressManager.GetPrimaryAddress();
            textBox_Address.Text = primaryAddress.AddressLineOne;
            textBox_City.Text = primaryAddress.City;
            comboBox_State.Text = primaryAddress.State;
            textBox_Zipcode.Text = primaryAddress.Zipcode;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            string searchField;
            if (radioButton_First.Checked == true)
                searchField = "First";
            else if (radioButton_Last.Checked == true)
                searchField = "Last";
            else
                searchField = "Bolth";

            currentContactManager.PopulateContactListWithFilter(listView_CustomerList, textBox_Search.Text, searchField);

        }
    }
}
