using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks;

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
        }
        public void CreateAddressBook()
        {
            Console.Write("Enter the name of the address book: ");
            string name = Console.ReadLine();

            if (addressBooks.ContainsKey(name))
            {
                Console.WriteLine("Address book with the same name already exists.");
            }
            else
            {
                AddressBook addressBook = new AddressBook();
                addressBooks.Add(name, addressBook);
                Console.WriteLine($"Address book '{name}' created successfully.");
            }

            Console.WriteLine();
        }
        public void AddContact()
        {
            Console.Write("Enter the name of the address book to add the contact: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];

                Console.WriteLine("Enter contact details:");
                Console.Write("First Name: ");
                string firstName = Console.ReadLine();
                Console.Write("Last Name: ");
                string lastName = Console.ReadLine();
                if (addressBook.FindContactByName(firstName, lastName) != null)
                {
                    Console.WriteLine("Contact with the same name already exists in the address book.");
                }
                else
                {
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
                    addressBook.AddContact(contact);

                    Console.WriteLine("Contact added to the address book.");
                }
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void ViewAddressBook()
        {
            Console.Write("Enter the name of the address book to view: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.ViewAddressBook();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void EditContact()
        {
            Console.Write("Enter the name of the address book to edit the contact: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.EditContact();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void DeleteContact()
        {
            Console.Write("Enter the name of the address book to delete the contact: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.DeleteContact();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void SearchPersonInCityOrState()
        {
            Console.Write("Enter the city or state to search for: ");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks.Values)
            {
                searchResults.AddRange(addressBook.FindContactsByCityOrState(searchQuery));
            }
            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Search Results ({searchResults.Count}):");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
                    Console.WriteLine($"Address: {contact.Address}");
                    Console.WriteLine($"City: {contact.City}");
                    Console.WriteLine($"State: {contact.State}");
                    Console.WriteLine($"ZIP: {contact.Zip}");
                    Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
                    Console.WriteLine($"Email: {contact.Email}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No matching contacts found.");
            }

            Console.WriteLine();
        }
    }
}
