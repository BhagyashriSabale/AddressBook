using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AddressBook
{
    internal class AddressBookSystem
    {
        private Dictionary<string, AddressBook> addressBooks;
        private Dictionary<string, List<Contact>> personsByCity;
        private Dictionary<string, List<Contact>> personsByState;

        public AddressBookSystem()
        {
            addressBooks = new Dictionary<string, AddressBook>();
            personsByCity = new Dictionary<string, List<Contact>>();
            personsByState = new Dictionary<string, List<Contact>>();
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

                    UpdatePersonsByCityAndState(contact);
                    Console.WriteLine("Contact added successfully.");
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
        public void ViewPersonsByCity()
        {
            Console.Write("Enter the city to view persons: ");
            string city = Console.ReadLine();

            if (personsByCity.ContainsKey(city))
            {
                List<Contact> persons = personsByCity[city];

                Console.WriteLine($"Persons in {city} ({persons.Count}):");
                foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Address: {person.Address}");
                    Console.WriteLine($"City: {person.City}");
                    Console.WriteLine($"State: {person.State}");
                    Console.WriteLine($"ZIP: {person.Zip}");
                    Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                    Console.WriteLine($"Email: {person.Email}");
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

            if (personsByState.ContainsKey(state))
            {
                List<Contact> persons = personsByState[state];

                Console.WriteLine($"Persons in {state} ({persons.Count}):");
                foreach (var person in persons)
                {
                    Console.WriteLine($"Name: {person.FirstName} {person.LastName}");
                    Console.WriteLine($"Address: {person.Address}");
                    Console.WriteLine($"City: {person.City}");
                    Console.WriteLine($"State: {person.State}");
                    Console.WriteLine($"ZIP: {person.Zip}");
                    Console.WriteLine($"Phone Number: {person.PhoneNumber}");
                    Console.WriteLine($"Email: {person.Email}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("No persons found in the specified state.");
            }

            Console.WriteLine();
        }
        public void GetCountByCity()
        {
            var cityCounts = personsByCity.ToDictionary(kv => kv.Key, kv => kv.Value.Count);

            Console.WriteLine("Number of persons by city:");
            foreach (var kvp in cityCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine();
        }
        public void GetCountByState()
        {
            var stateCounts = personsByState.ToDictionary(kv => kv.Key, kv => kv.Value.Count);

            Console.WriteLine("Number of persons by state:");
            foreach (var kvp in stateCounts)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }

            Console.WriteLine();
        }
        private void UpdatePersonsByCityAndState(Contact contact)
        {
            if (!personsByCity.ContainsKey(contact.City))
            {
                personsByCity[contact.City] = new List<Contact>();
            }
            personsByCity[contact.City].Add(contact);

            if (!personsByState.ContainsKey(contact.State))
            {
                personsByState[contact.State] = new List<Contact>();
            }
            personsByState[contact.State].Add(contact);
        }
        public void SortAddressBookByName()
        {
            Console.Write("Enter the name of the address book to sort: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.SortContactsByName();
                Console.WriteLine("Address book sorted by name.");
                addressBook.ViewAddressBook();
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }

        public void SortAddressBookByCity()
        {
            Console.Write("Enter the name of the address book to sort by city: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.SortByCity();
                Console.WriteLine("Address book sorted by city.");
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void SortAddressBookByState()
        {
            Console.Write("Enter the name of the address book to sort by state: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.SortByState();
                Console.WriteLine("Address book sorted by state.");
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        public void SortAddressBookByZip()
        {
            Console.Write("Enter the name of the address book to sort by ZIP: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
                AddressBook addressBook = addressBooks[addressBookName];
                addressBook.SortByZip();
                Console.WriteLine("Address book sorted by ZIP.");
            }
            else
            {
                Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }
        
        public void WriteAddressBookToFile()
        {
            Console.Write("Enter the name of the address book to write to a file: ");
            string addressBookName = Console.ReadLine();

            if (addressBooks.ContainsKey(addressBookName))
            {
               AddressBook addressBook = addressBooks[addressBookName];

               Console.Write("Enter the file name to write the address book: ");
               string fileName = Console.ReadLine();

               try
               {
                   using (StreamWriter writer = new StreamWriter(fileName))
                   {
                      foreach (var contact in addressBook.GetContacts())
                      {
                        writer.WriteLine($"{contact.FirstName},{contact.LastName},{contact.Address},{contact.City},{contact.State},{contact.Zip},{contact.PhoneNumber},{contact.Email}");
                      }
                   }

                   Console.WriteLine($"Address book written to {fileName}.");
               }
               catch (IOException ex)
               {
                  Console.WriteLine($"Error writing to file: {ex.Message}");
               }
            }
            else
            {
               Console.WriteLine("Address book not found.");
            }

            Console.WriteLine();
        }

        public void ReadAddressBookFromFile()
        {
           Console.Write("Enter the file name to read the address book: ");
           string fileName = Console.ReadLine();

            try
            {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        
                        string[] fields = line.Split(',');

                        string firstName = fields[0];
                        string lastName = fields[1];
                        string address = fields[2];
                        string city = fields[3];
                        string state = fields[4];
                        string zip = fields[5];
                        string phoneNumber = fields[6];
                        string email = fields[7];

                        
                    }
                }
                Console.WriteLine("Address book read from file.");
            }

            catch (IOException ex)
            {
                Console.WriteLine($"Error reading from file: {ex.Message}");
            }

            Console.WriteLine();
        }

    }
}
