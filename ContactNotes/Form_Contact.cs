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
    public partial class Form_Contact : Form
    {
        Contact currentContact;

        public Contact CurrentContact { get { return currentContact; } set { currentContact = value; } }

        public Form_Contact()
        {
            InitializeComponent();
        }

        private void button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Contact_Load(object sender, EventArgs e)
        {
            DisplayContact();
        }

        public void DisplayContact()
        {
            textBox_FirstName.Text = currentContact.FirstName;
            textBox_LastName.Text = currentContact.LastName;
            comboBox_Gender.Text = currentContact.Gender;

            comboBox_Status.Text = currentContact.Status;
            comboBox_Potentual.Text = currentContact.Potentual;
            textBox_StatusDate.Text = currentContact.StatusUpdateDate.ToString();
            textBox_Birthday.Text = currentContact.BirthDate.ToString();

            Phone primaryPhone = currentContact.ContactPhoneManager.GetPrimaryPhone();
            textBox_Phone.Text = primaryPhone.ContactPhoneNumber;
            comboBox_PhoneType.Text = primaryPhone.ContactPhoneTypeID;

            Address primaryAddress = currentContact.ContactAddressManager.GetPrimaryAddress();
            textBox_Address.Text = primaryAddress.AddressLineOne;
            textBox_City.Text = primaryAddress.City;
            comboBox_State.Text = primaryAddress.State;
            textBox_Zipcode.Text = primaryAddress.Zipcode;


        }

    }
}
