using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleContactManager
{
    public class ContactDisplay
    {
        public void DisplayContacts(List<Contact> contacts)
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
                return;
            }

            Console.WriteLine("\nContacts List:");
           
            Console.WriteLine($"{"Name",-20} {"Phone",-15} {"Email",-30}");
         
            foreach (var contact in contacts)
            {
                Console.WriteLine($"{contact.Name,-20} {contact.Phone,-15} {contact.Email,-30}");
            }
            Console.WriteLine("------------------------------------------------");
        }
    }
}
