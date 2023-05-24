using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressBook
    {
        private List<Contact> contacts;

        public AddressBook()
        {
            contacts = new List<Contact>();
        }
        public void AddContact()
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
            contacts.Add(contact);

            Console.WriteLine("Contact added to the address book.");
            Console.WriteLine();
        }
        public void ViewAddressBook()
        {
            if (contacts.Count == 0)
            {
                Console.WriteLine("Address book is empty.");
            }
            else
            {
                Console.WriteLine("Address Book:");
                foreach (var contact in contacts)
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
