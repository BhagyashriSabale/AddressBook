using System;

namespace AddressBook
{
    internal class Program
    {
        static List<Contact> addressBook = new List<Contact>();
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book");
            while (true)
            {
                Console.WriteLine("Address Book Menu:");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. View Address Book");
                Console.WriteLine("3. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        AddContact();
                        break;
                    case 2:
                        ViewAddressBook();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }
        static void AddContact()
        {
            Console.WriteLine("Enter contact details:");
            Console.Write("First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Address: ");
            string address = Console.ReadLine();
            Console.Write("City: ");
            string city = Console.ReadLine();
            Console.Write("State: ");
            string state = Console.ReadLine();
            Console.Write("ZIP: ");
            string zip = Console.ReadLine();
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Contact contact = new Contact(firstName, lastName, address, city, state, zip, phoneNumber, email);
            addressBook.Add(contact);

            Console.WriteLine("Contact added to the address book.");
            Console.WriteLine();
        }
        static void ViewAddressBook()
        {
            if (addressBook.Count == 0)
            {
                Console.WriteLine("Address book is empty.");
            }
            else
            {
                Console.WriteLine("Address Book:");
                foreach (var contact in addressBook)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address} {contact.City} {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine();
                }
            }
        }

    }
}