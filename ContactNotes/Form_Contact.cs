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
            Gender.ComboBox_LoadGender(comboBox_Gender);
            //LoadStatus();
            //LoadPotentual();
            //LoadState();
            //LoadPhoneType();

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

            textBox_Email.Text = currentContact.EmailAddress;
            Address primaryAddress = currentContact.ContactAddressManager.GetPrimaryAddress();
            textBox_Address.Text = primaryAddress.AddressLineOne;
            textBox_City.Text = primaryAddress.City;
            comboBox_State.Text = primaryAddress.State;
            textBox_Zipcode.Text = primaryAddress.Zipcode;

            if (currentContact.VirtualParty == true)
            {
                checkBox_VirtualParty.Checked = true;
            }
            else
            {
                checkBox_VirtualParty.Checked = false;
            }
            textBox_WhoParty.Text = currentContact.VirtualPartyWho;

            if (currentContact.InPerson == true)
            {
                checkBox_InPerson.Checked = true;
            }
            else
            {
                checkBox_InPerson.Checked = false;
            }
            textBox_Who.Text = currentContact.InPersonWho;

            if (currentContact.Referal == true)
            {
                checkBox_Referal.Checked = true;
            }
            else
            {
                checkBox_Referal.Checked = false;
            }
            textBox_WhoRefered.Text = currentContact.ReferalWho;

            if (currentContact.DirectSalesWebsite == true)
            {
                checkBox_DirectSalesWebsite.Checked = true;
            }
            else
            {
                checkBox_DirectSalesWebsite.Checked = false;
            }

            if(currentContact.Other == false)
            {
                checkBox_Other.Checked = false;
            }
            else
            {
                checkBox_Other.Checked = true;
            }
            textBox_Where.Text = currentContact.OtherWhere;

            if (currentContact.IsActive == true)
            {
                 checkBox_IsActive.Checked= true;
            }
            else
            {
                checkBox_IsActive.Checked = false;
            }
        }

        private void button_Clear_Click(object sender, EventArgs e)
        {
            currentContact = new Contact();
            DisplayContact();
        }

        private void button_Save_Click(object sender, EventArgs e)
        {
            currentContact.FirstName=textBox_FirstName.Text;
            currentContact.LastName=textBox_LastName.Text;
            currentContact.Gender=comboBox_Gender.Text;

            currentContact.Status=comboBox_Status.Text;
            currentContact.Potentual=comboBox_Potentual.Text;
            currentContact.StatusUpdateDate=Convert.ToDateTime(textBox_StatusDate.Text);
            currentContact.BirthDate=Convert.ToDateTime(textBox_Birthday.Text);

            Phone primaryPhone = currentContact.ContactPhoneManager.GetPrimaryPhone();
            primaryPhone.ContactPhoneNumber=textBox_Phone.Text;
            primaryPhone.ContactPhoneTypeID=comboBox_PhoneType.Text;

            currentContact.EmailAddress=textBox_Email.Text;
            Address primaryAddress = currentContact.ContactAddressManager.GetPrimaryAddress();
            primaryAddress.AddressLineOne=textBox_Address.Text;
            primaryAddress.City=textBox_City.Text;
            primaryAddress.State=comboBox_State.Text;
            primaryAddress.Zipcode=textBox_Zipcode.Text;

            if (checkBox_VirtualParty.Checked == true)
            {
                currentContact.VirtualParty = true;
            }
            else
            {
                currentContact.VirtualParty = false;
            }
            currentContact.VirtualPartyWho=textBox_WhoParty.Text;

            if ( checkBox_InPerson.Checked == true)
            {
                currentContact.InPerson = true;
            }
            else
            {
                currentContact.InPerson = false;
            }
            currentContact.InPersonWho=textBox_Who.Text;

            if ( checkBox_Referal.Checked== true)
            {
                currentContact.Referal = true;
            }
            else
            {
                currentContact.Referal = false;
            }
            currentContact.ReferalWho=textBox_WhoRefered.Text;

            if ( checkBox_DirectSalesWebsite.Checked== true)
            {
                currentContact.DirectSalesWebsite = true;
            }
            else
            {
                currentContact.DirectSalesWebsite = false;
            }

            if ( checkBox_Other.Checked== false)
            {
                currentContact.Other = false;
            }
            else
            {
                currentContact.Other = true;
            }
            currentContact.OtherWhere = textBox_Where.Text;

            if (checkBox_IsActive.Checked == true)
            {
                currentContact.IsActive = true;
            }
            else
            {
                currentContact.IsActive = false;
            }

            currentContact.Save();
        }
    }
}
