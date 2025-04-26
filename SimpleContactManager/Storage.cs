using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactManager
{
    public class Storage
    {
        private readonly List<Contact> contacts;

        public Storage()
        {
            contacts = new List<Contact>();
        }

        public bool AddContact(Contact contact)
        {
            contacts.Add(contact);
            return true;
        }

        public bool UpdateContact(string name, Contact updatedContact)
        {
            var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
                return false;

            contact.Name = updatedContact.Name;
            contact.Phone = updatedContact.Phone;
            contact.Email = updatedContact.Email;
            return true;
        }

        public bool DeleteContact(string name)
        {
            var contact = contacts.Find(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (contact == null)
                return false;

            contacts.Remove(contact);
            return true;
        }

        public List<Contact> GetAllContacts()
        {
            return new List<Contact>(contacts);
        }
    }
}
