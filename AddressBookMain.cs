using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    internal class AddressBookMain
    {
        private Dictionary<string, AddressBook> addressBooks;

        public AddressBookMain()
        {
            addressBooks = new Dictionary<string, AddressBook>();
        }

        public void CreateAddressBook()
        {
            Console.Write("Enter the name of the address book: ");
            string addressBookName = Console.ReadLine();

            if (!addressBooks.ContainsKey(addressBookName))
            {
                addressBooks[addressBookName] = new AddressBook();
                Console.WriteLine("Address book created successfully.");
            }
            else
            {
                Console.WriteLine("Address book already exists.");
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
                addressBook.AddContact();
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

        public void AddMultiplePersons()
        {
            Console.Write("Enter the name of the address book to add multiple persons: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.AddMultiplePersons();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }

        public void AddMultipleAddressBooks()
        {
            Console.Write("Enter the number of address books to add: ");
            int numAddressBooks = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < numAddressBooks; i++)
            {
                CreateAddressBook();
            }
        }

        public void EnsureNoDuplicateEntries()
        {
            Console.Write("Enter the name of the address book to ensure no duplicate entries: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.EnsureNoDuplicateEntries();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }

        public void SearchPersonInCityOrState()
        {
            Console.Write("Enter the city or state to search for persons: ");
            string searchQuery = Console.ReadLine();

            List<Contact> searchResults = new List<Contact>();

            foreach (var addressBook in addressBooks.Values)
            {
                searchResults.AddRange(addressBook.FindContactsByCityOrState(searchQuery));
            }

            if (searchResults.Count > 0)
            {
                Console.WriteLine($"Search Results for '{searchQuery}':");
                foreach (var contact in searchResults)
                {
                    Console.WriteLine(contact);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No persons found matching the search query.");
            }

            Console.WriteLine();
        }

        public void ViewPersonsByCity()
        {
            Console.Write("Enter the city to view persons: ");
            string city = Console.ReadLine();

            List<Contact> persons = new List<Contact>();

            foreach (var addressBook in addressBooks.Values)
            {
                persons.AddRange(addressBook.FindContactsByCityOrState(city));
            }

            if (persons.Count > 0)
            {
                Console.WriteLine($"Persons in {city}:");
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No persons found in the specified city.");
            }

            Console.WriteLine();
        }

        public void ViewPersonsByState()
        {
            Console.Write("Enter the state to view persons: ");
            string state = Console.ReadLine();

            List<Contact> persons = new List<Contact>();

            foreach (var addressBook in addressBooks.Values)
            {
                persons.AddRange(addressBook.FindContactsByCityOrState(state));
            }

            if (persons.Count > 0)
            {
                Console.WriteLine($"Persons in {state}:");
                foreach (var person in persons)
                {
                    Console.WriteLine(person);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No persons found in the specified state.");
            }

            Console.WriteLine();
        }

        public void SortAddressBook()
        {
            Console.Write("Enter the name of the address book to sort: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.SortContactsByName();
                Console.WriteLine("Address book sorted successfully.");
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }

    }
}
