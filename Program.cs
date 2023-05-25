using System;

namespace AddressBook
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book");
            AddressBook addressBook = new AddressBook();
            while (true)
            {
                Console.WriteLine("Address Book Menu:");
                Console.WriteLine("1. Add Person");
                Console.WriteLine("2. View Address Book");
                Console.WriteLine("3. Edit Contact");
                Console.WriteLine("4. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBook.AddContact();
                        break;
                    case 2:
                        addressBook.ViewAddressBook();
                        break;
                    case 3:
                        addressBook.EditContact();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }

    }
}