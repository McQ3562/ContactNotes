using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public class Contact
    {
        AddressManager addressManager = new AddressManager();
        PhoneManager phoneManager = new PhoneManager();

        int contactID;
	    string firstName;
	    string lastName;
	    string gender;
	    DateTime birthDate;
        string status;
        string potentual;
        DateTime statusUpdateDate;
        string emailAddress;
        string emailAddressType;
	    bool virtualParty = false;
	    string virtualPartyWho;
	    bool inPerson = false;
	    string inPersonWho;
	    bool referal = false;
	    string referalWho;
	    bool directSalesWebsite = false;
	    bool other = false;

	    string otherWhere;
	    bool isActive;

        public int ContactID { get { return contactID; } set { contactID = value; } }
        public string FirstName { get { return firstName; } set { firstName = value; } }
        public string LastName { get { return lastName; } set { lastName = value; } }
        public string Gender { get { return gender; } set { gender = value; } }
        public DateTime BirthDate { get { return birthDate; } set { birthDate = value; } }
        public string Status { get{return status;} set {status = value;} }
        public string Potentual { get { return potentual; } set { potentual = value; } }
        public DateTime StatusUpdateDate { get { return statusUpdateDate; } set { statusUpdateDate = value; } }
        public string EmailAddress { get { return emailAddress; } set { emailAddress = value; } }
        public string EmailAddressType { get { return emailAddressType; } set { emailAddressType = value; } }
        public bool VirtualParty { get { return virtualParty; } set { virtualParty = value; } }
        public string VirtualPartyWho { get { return virtualPartyWho; } set { virtualPartyWho = value; } }
        public bool InPerson { get { return inPerson; } set { inPerson = value; } }
        public string InPersonWho { get { return inPersonWho; } set { inPersonWho = value; } }
        public bool Referal { get { return referal; } set { referal = value; } }
        public string ReferalWho { get { return referalWho; } set { referalWho = value; } }
        public bool DirectSalesWebsite { get { return directSalesWebsite; } set { directSalesWebsite = value; } }
        public bool Other { get { return other; } set { other = value; } }
        public string OtherWhere { get { return otherWhere; } set { otherWhere = value; } }
        public bool IsActive { get { return isActive; } set { isActive = value; } }
        public AddressManager ContactAddressManager { get { return addressManager; } set { addressManager = value; } }
        public PhoneManager ContactPhoneManager { get { return phoneManager; } set { phoneManager = value; } }

        public void Load()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_Contact @ContactID="+contactID);

            if (results.Count > 0)
            {
                contactID = Convert.ToInt32(results[0][1]);
                FirstName=results[1][1];
                LastName=results[2][1];

                string tmpGender = results[3][1];
                if (tmpGender == "M")
                    Gender = "Male";
                else if(tmpGender=="F")
                    Gender = "Female";

                BirthDate=Convert.ToDateTime(results[4][1]);

                Status = results[5][1];
                Potentual = results[6][1];
                StatusUpdateDate = Convert.ToDateTime(results[7][1]);
                EmailAddress = results[8][1];

                if (results[9][1] == "Y")
                    VirtualParty = true;
                VirtualPartyWho=results[10][1];

                if (results[11][1] == "Y")
                    inPerson = true;
                InPersonWho=results[12][1];

                if (results[13][1] == "Y")
                    Referal = true;
                ReferalWho=results[14][1];

                if (results[15][1] == "Y")
                    DirectSalesWebsite = true;

                if (results[16][1] == "Y")
                    Other = true;

                OtherWhere = results[17][1];

                if (results[18][1] == "Active")
                    IsActive = true;
                else
                    IsActive = false;

                addressManager.ContactID = contactID.ToString();
                addressManager.LoadList();

                phoneManager.ContactID = contactID.ToString();
                phoneManager.LoadList();

            }
        }

        public void Save()
        {
            string translatedIsActive;
            if(IsActive==true)
            {
                translatedIsActive = "Active";
            }
            else
            {
                translatedIsActive = "InActive";
            }

            string translatedGender;
            if (Gender == "Male")
                translatedGender = "M";
            else
                translatedGender = "F";

            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            string SQL = @"sp_SET_Contact 
	                    @ContactID={17},
                        @FirstName='{0}',
	                    @LastName='{1}',
	                    @Gender='{2}',
	                    @BirthDate='{3}',
	                    @StatusID='{4}',
	                    @PotentualID='{5}',
	                    @EmailAddress='{6}',
	                    @VirtualParty='{7}',
	                    @VirtualPartyWho='{8}',
	                    @InPerson='{9}',
	                    @InPersonWho='{10}',
	                    @Referal='{11}',
	                    @ReferalWho='{12}',
	                    @DirectSalesWebsite='{13}',
	                    @Other='{14}',
	                    @OtherWhere='{15}',
	                    @IsActive='{16}'";
            SQL = String.Format(SQL, FirstName, LastName, translatedGender, BirthDate, Status, Potentual, EmailAddress, VirtualParty, VirtualPartyWho, InPerson, inPersonWho, Referal, ReferalWho, DirectSalesWebsite, Other, OtherWhere, translatedIsActive, ContactID);
            conn.ReturnQuery(SQL);
        }
    }

    public class Gender
    {
        string genderID;
        string genderName;

        public string GenderID { get { return genderID; } set { genderID = value; } }
        public string GenderName { get { return genderName; } set { genderName = value; } }

        public static List<Gender> LoadList()
        {
            List<Gender> returnList = new List<ContactNotes.Gender>();

            Gender tmpGender = new Gender();
            tmpGender.GenderID = "M";
            tmpGender.GenderName = "Male";

            returnList.Add(tmpGender);

            tmpGender = new Gender();
            tmpGender.GenderID = "F";
            tmpGender.GenderName = "Female";

            returnList.Add(tmpGender);

            return returnList;
        }

        public static void ComboBox_LoadGender(ComboBox ComboBoxGender)
        {
            List<Gender> genderList = ContactNotes.Gender.LoadList();
            ComboBoxGender.DataSource = genderList;
            ComboBoxGender.ValueMember = "genderID";
            ComboBoxGender.DisplayMember = "genderName";
        }
    }
}
