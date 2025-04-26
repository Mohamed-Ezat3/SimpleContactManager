using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactManager
{
    public class ContactManager
    {
        private readonly Storage storage;
        private readonly ListLogger logger;

        public ContactManager(Storage storage, ListLogger logger)
        {
            this.storage = storage;
            this.logger = logger;
        }

        public bool AddContact(Contact contact)
        {
            if (!contact.IsValid())
            {
                logger.Log("Failed to add contact: Invalid data");
                return false;
            }
            storage.AddContact(contact);
            logger.Log($"Added contact: {contact.Name}");
            return true;
        }

        public bool UpdateContact(string name, Contact updatedContact)
        {
            if (!updatedContact.IsValid())
            {
                logger.Log("Failed to update contact: Invalid data");
                return false;
            }
            if (!storage.UpdateContact(name, updatedContact))
            {
                logger.Log($"Failed to update contact: {name} not found");
                return false;
            }
            logger.Log($"Updated contact: {name} to {updatedContact.Name}");
            return true;
        }
        public bool DeleteContact(string name)
        {
            if (!storage.DeleteContact(name))
            {
                logger.Log($"Failed to delete contact: {name} not found");
                return false;
            }
            logger.Log($"Deleted contact: {name}");
            return true;
        }
        public List<Contact> GetAllContacts()
        {
            return storage.GetAllContacts();
        }
    }
}
