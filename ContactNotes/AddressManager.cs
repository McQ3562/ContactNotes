using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactNotes
{
    class AddressManager
    {
        string contactID;
        List<Address> addressList = new List<Address>();

        public string ContactID { get { return contactID; } set { contactID = value; } }

        public void LoadList()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_AddressID_List @ContactID="+contactID);

            if (results.Count > 0)
            {
                for (int counter = 0; counter <= results.Count - 1; counter++)
                {
                    Address tmpAddress = new Address();
                    tmpAddress.AddressID = results[counter][1];
                    tmpAddress.Load();

                    addressList.Add(tmpAddress);
                }
            }
        }
    }
}
