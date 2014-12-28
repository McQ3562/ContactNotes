using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

    public class PhoneType
    {
        string phoneTypeID;
        string phoneTypeName;
        string phoneTypeDiscription;

        public string PhoneTypeID { get { return phoneTypeID; } set { phoneTypeID = value; } }
        public string PhoneTypeName { get { return phoneTypeName; } set { phoneTypeName = value; } }
        public string PhoneTypeDiscription { get { return phoneTypeDiscription; } set { phoneTypeDiscription = value; } }

        public void Load(string LoadPhoneTypeID)
        {
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_PhoneType @PhoneTypeID=" + LoadPhoneTypeID);

            if(results.Count> 0)
            {
                PhoneTypeID = results[0][1];
                PhoneTypeName = results[1][1];
                PhoneTypeDiscription = results[2][1];
            }

        }

        public static List<PhoneType> GetPhoneTypeList()
        {
            List<PhoneType> returnList = new List<PhoneType>();
            List<List<string>> results;
            DB_Connection conn = new DB_Connection(DB_ConnectionString.GetContactNotesConnectionString());
            results = conn.ReturnQuery("sp_GET_PhoneTypeList");

            if (results.Count > 0)
            {
                for(int counter=1;counter<results[0].Count;counter++)
                {
                    PhoneType tmpPhoneType = new PhoneType();
                    tmpPhoneType.Load(results[0][counter]);

                    returnList.Add(tmpPhoneType);
                }
            }

            return returnList;
        }

        public static void LoadComboBox(ComboBox LoadPhoneList)
        {
            List<PhoneType> tmpPhoneTypeList = PhoneType.GetPhoneTypeList();
            LoadPhoneList.DataSource = tmpPhoneTypeList;
            LoadPhoneList.DisplayMember = "PhoneTypeName";
            LoadPhoneList.ValueMember = "PhoneTypeID";
        }
    }
}
