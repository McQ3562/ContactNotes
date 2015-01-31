using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ContactNotes
{
    public class ContactManager
    {
        List<Contact> contactList;

        public void GetContactList()
        {
            contactList = new List<Contact>();

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

        public void PopulateContactListWithFilter(ListView currentListView, string FilterString, string SearchField)
        {
            bool foundFlag;

            currentListView.Items.Clear();

            foreach (Contact tmpContact in contactList)
            {
                foundFlag = false;
                if(((SearchField == "First") || (SearchField == "Bolth")) && (tmpContact.FirstName.IndexOf(FilterString) > -1))
                    foundFlag = true;

                if (((SearchField == "Last") || (SearchField == "Bolth")) && (tmpContact.LastName.IndexOf(FilterString) > -1))
                    foundFlag = true;

                if(foundFlag == true)
                {
                    ListViewItem tmpItem = new ListViewItem(tmpContact.FirstName);
                    tmpItem.SubItems.Add(tmpContact.LastName);
                    tmpItem.SubItems.Add(tmpContact.ContactID.ToString());

                    currentListView.Items.Add(tmpItem);
                }
            }
        }
    }
}
