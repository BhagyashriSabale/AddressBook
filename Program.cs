using System;

namespace AddressBook
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book");
            AddressBookSystem addressBookSystem = new AddressBookSystem();
            while (true)
            {
                Console.WriteLine("Address Book System Menu:");
                Console.WriteLine("1. Create Address Book");
                Console.WriteLine("2. Add Contact");
                Console.WriteLine("3. View Address Book");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Search Person in City or State");
                Console.WriteLine("7. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookSystem.CreateAddressBook();
                        break;
                    case 2:
                        addressBookSystem.AddContact();
                        break;
                    case 3:
                        addressBookSystem.ViewAddressBook();
                        break;
                    case 4:
                        addressBookSystem.EditContact();
                        break;
                    case 5:
                        addressBookSystem.DeleteContact();
                        break;
                    case 6:
                        addressBookSystem.SearchPersonInCityOrState();
                        break;
                    case 7:
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