using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactNotes
{
    public class Phone
    {
        string contactPhoneID;
	    string contactPhoneNumber;
        string contactPhoneTypeID;
        string isPrimary;

        public string ContactPhoneID { get { return contactPhoneID; } set { contactPhoneID = value; } }
        public string ContactPhoneNumber { get { return contactPhoneNumber; } set { contactPhoneNumber = value; } }
        public string ContactPhoneTypeID { get { return contactPhoneTypeID; } set { contactPhoneTypeID = value; } }
        public string IsPrimary { get { return isPrimary; } set { isPrimary = value; } }

        public void Load()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_Phone @ContactPhoneID="+contactPhoneID);

            if(results.Count > 0)
            {
                contactPhoneNumber = results[1][1];
                contactPhoneTypeID = results[2][1];
                isPrimary = results[3][1];
            }
        }
    }
}
