using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    class ContactManager
    {
        List<Contact> contactList = new List<Contact>();

        public void GetContactList()
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_ContactID_List");

            if (results.Count > 0)
            {
                for (int counter = 1; counter < results[0].Count; counter++)
                {
                    Contact tmpContact = new Contact();
                    tmpContact.ContactID = Convert.ToInt32(results[0][counter]);
                    tmpContact.Load();

                    contactList.Add(tmpContact);
                }
            }
        }

        public void PopulateContactList(ListView currentListView)
        {
            foreach (Contact tmpContact in contactList)
            {
                ListViewItem tmpItem = new ListViewItem(tmpContact.FirstName);
                tmpItem.SubItems.Add(tmpContact.LastName);
                tmpItem.SubItems.Add(tmpContact.ContactID.ToString());

                currentListView.Items.Add(tmpItem);
            }
        }
    }
}
