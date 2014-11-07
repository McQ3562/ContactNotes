using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactNotes
{
    public class PhoneManager
    {
        List<Phone> PhoneList = new List<Phone>();

        string contactID;
        public string ContactID { get { return contactID; } set { contactID = value; } }

        public void LoadList()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_PhoneID_List @ContactID="+contactID);

            if (results.Count > 0)
            {
                for (int counter = 1; counter < results[0].Count-1; counter++)
                {
                    Phone tmpPhone = new Phone();
                    tmpPhone.ContactPhoneID = results[0][counter];
                    tmpPhone.Load();

                    PhoneList.Add(tmpPhone);
                }
            }
        }

        public Phone GetPrimaryPhone()
        {
            Phone primaryPhone = new Phone();

            foreach(Phone tempPhone in PhoneList)
            {
                if (tempPhone.IsPrimary == "Y")
                {
                    primaryPhone = tempPhone;
                    break;
                }
            }

            return primaryPhone;
        }
    }
}
