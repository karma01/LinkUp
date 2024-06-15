using Contacts.Views;

namespace Contacts.Models
{
    public static class ContactRepo
    {
        private static List<ContactsInfo> _contactsList = new List<ContactsInfo>()
        {
            new ContactsInfo(){ContactId=1, Name ="karma" ,Email = "psgf@gmail.com"},

            new ContactsInfo() {ContactId =2, Name ="Paw" ,Email = "psfe71@gmail.com"},

            new ContactsInfo(){ContactId = 3, Name ="Bink" ,Email = "pfee716@gmail.com"}
        };

        public static List<ContactsInfo> GetContacts() => _contactsList;

        public static ContactsInfo GetContactByID(int id)
        {
            var contact = _contactsList.FirstOrDefault(x => x.ContactId == id);
        if(contact == null)
            {
                contact = new ContactsInfo();
            }
        return contact;
        }

        public static void UpdateContacts(int id, ContactsInfo contactInfo)
        {
            var prevContact = GetContactByID(id);

            if (prevContact != null)
            {
                contactInfo.ContactId = prevContact.ContactId;
                contactInfo.Name = prevContact.Name;
                contactInfo.Email = prevContact.Email;
                contactInfo.Phone = prevContact.Phone;
            }
        }
        public static void AddContact(ContactsInfo contactsInfo)
        {
            int maxid = _contactsList.Max(x => x.ContactId);
            contactsInfo.ContactId = maxid;
            _contactsList.Add(contactsInfo);

        }
        public static void RemoveContact(int id)
        {

            var contact = _contactsList.FirstOrDefault(x => x.ContactId == id);
            if (contact != null)
            {
                _contactsList.Remove(contact);
            }


        }
        public static List<ContactsInfo> SearchContacts(string id)
        {
            var contact = _contactsList.Where(x=>!string.IsNullOrWhiteSpace(x.Name)&& x.Name.StartsWith(id,StringComparison.OrdinalIgnoreCase)).ToList();

            if (contact == null ||contact.Count<=0)
            {
                contact = _contactsList.Where(x => !string.IsNullOrWhiteSpace(x.Email) && x.Email.StartsWith(id, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            
            if (contact == null||contact.Count<=0) 
            {
                contact = _contactsList.Where(x => !string.IsNullOrWhiteSpace(x.Phone) && x.Phone.StartsWith(id, StringComparison.OrdinalIgnoreCase)).ToList();
            }


            return contact;


        }


    }
}