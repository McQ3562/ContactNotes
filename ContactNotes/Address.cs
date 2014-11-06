using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactNotes
{
    class Address
    {
        string addressID;
        string addressLineOne;
        string city;
        string state;
        string stateABR;
        string zipcode;
        string isPrimary;

        public string AddressID { get { return addressID; } set { addressID = value; } }
        public string AddressLineOne { get { return addressLineOne; } set { addressLineOne = value; } }
        public string City { get { return city; } set { city = value; } }
        public string State { get { return state; } set { state = value; } }
        public string StateABR { get { return stateABR; } set { stateABR = value; } }
        public string Zipcode { get { return zipcode; } set { zipcode = value; } }
        public string IsPrimary { get { return isPrimary; } set { isPrimary = value; } }

        public void Load()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_Address @ContactAddressID="+addressID);

            if (results.Count > 0)
            {
                addressLineOne = results[0][1];
                city = results[0][1];
                state = results[1][1];
                stateABR = results[2][1];
                zipcode = results[3][1];
                isPrimary = results[4][1];
            }
        }
    }
}
