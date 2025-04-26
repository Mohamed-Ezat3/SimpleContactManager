using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace SimpleContactManager
{
    public enum MenuOption
    {
        Invalid = 0, 
        AddContact = 1,
        EditContact = 2,
        DeleteContact = 3,
        ViewAllContacts = 4,
        ViewLogs = 5,
        Exit = 6
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\n\t\tSimple contact Manager");
            ListLogger logger = new ListLogger();
            Storage storage = new Storage();
            ContactManager contactManager = new ContactManager(storage, logger);
            ContactDisplay contactDisplay = new ContactDisplay();
            while (true)
            {
                Console.WriteLine("1 Add contact");
                Console.WriteLine("2 Edit contact");
                Console.WriteLine("3 Delete contact");
                Console.WriteLine("4 View All contacts");
                Console.WriteLine("5 View Logs");
                Console.WriteLine("6 Exit");
                Console.Write("Choose an option: ");

                string input = Console.ReadLine();
                MenuOption choice = ParseMenuOption(input);
                switch (choice)
                {
                    case MenuOption.AddContact:
                        Console.Write("Enter name: ");
                        string name = Console.ReadLine();
                        Console.Write("Enter phone: ");
                        string phone = Console.ReadLine();
                        Console.Write("Enter email: ");
                        string email = Console.ReadLine();

                        var contact = new Contact(name, phone, email);
                        if (contactManager.AddContact(contact))
                            Console.WriteLine("Contact added successfully.");
                        else
                            Console.WriteLine("Error: Invalid contact data.");
                        break;

                    case MenuOption.EditContact:
                        Console.Write("Enter name of contact to edit: ");
                        string oldName = Console.ReadLine();
                        Console.Write("Enter new name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter new phone: ");
                        string newPhone = Console.ReadLine();
                        Console.Write("Enter new email: ");
                        string newEmail = Console.ReadLine();

                        var updatedContact = new Contact(newName, newPhone, newEmail);
                        if (contactManager.UpdateContact(oldName, updatedContact))
                            Console.WriteLine("Contact updated successfully.");
                        else
                            Console.WriteLine("Error: Invalid data or contact not found.");
                        break;

                    case MenuOption.DeleteContact:
                        Console.Write("Enter name of contact to delete: ");
                        string deleteName = Console.ReadLine();
                        if (contactManager.DeleteContact(deleteName))
                            Console.WriteLine("Contact deleted successfully.");
                        else
                            Console.WriteLine("Error: Contact not found.");
                        break;

                    case MenuOption.ViewAllContacts:
                        var contacts = contactManager.GetAllContacts();
                        contactDisplay.DisplayContacts(contacts);
                        break;

                    case MenuOption.ViewLogs:
                        var logs = logger.GetLogs();
                        if (logs.Count == 0)
                        {
                            Console.WriteLine("No logs available.");
                        }
                        else
                        {
                            Console.WriteLine("\nLogs:");
                            foreach (var log in logs)
                            {
                                Console.WriteLine(log);
                            }
                        }
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }
        private static MenuOption ParseMenuOption(string input)
        {
            if (int.TryParse(input, out int value) && Enum.IsDefined(typeof(MenuOption), value))
            {
                return (MenuOption)value;
            }
            return MenuOption.Invalid;
        }
    }
}