using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        bool VirtualParty { get { return virtualParty; } set { virtualParty = value; } }
        public string VirtualPartyWho { get { return virtualPartyWho; } set { virtualPartyWho = value; } }
        bool InPerson { get { return inPerson; } set { inPerson = value; } }
        public string InPersonWho { get { return inPersonWho; } set { inPersonWho = value; } }
        bool Referal { get { return referal; } set { referal = value; } }
        public string ReferalWho { get { return referalWho; } set { referalWho = value; } }
        bool DirectSalesWebsite { get { return directSalesWebsite; } set { directSalesWebsite = value; } }
        bool Other { get { return other; } set { other = value; } }
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
                Gender=results[3][1];

                BirthDate=Convert.ToDateTime(results[4][1]);

                Status = results[5][1];
                Potentual = results[6][1];
                StatusUpdateDate = Convert.ToDateTime(results[7][1]);

                if (results[8][1] == "Y")
                    VirtualParty = true;
                VirtualPartyWho=results[9][1];

                if (results[10][1] == "Y")
                    inPerson = true;
                InPersonWho=results[11][1];

                if (results[12][1] == "Y")
                    Referal = true;
                ReferalWho=results[13][1];

                if (results[14][1] == "Y")
                    DirectSalesWebsite = true;

                if (results[15][1] == "Y")
                    Other = true;

                OtherWhere = results[16][1];

                addressManager.ContactID = contactID.ToString();
                addressManager.LoadList();

                phoneManager.ContactID = contactID.ToString();
                phoneManager.LoadList();

            }
        }


    }
}
