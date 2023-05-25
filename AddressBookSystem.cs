﻿using System;
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
                addressBook.AddContact();
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
    }
}
