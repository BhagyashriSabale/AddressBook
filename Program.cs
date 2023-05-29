using System;

namespace AddressBook
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome Address Book");
            AddressBookMain addressBookMain = new AddressBookMain();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Address Book Program");
                Console.WriteLine("1. Create New Address Book");
                Console.WriteLine("2. Add Contact to Address Book");
                Console.WriteLine("3. View contact in Address Book");
                Console.WriteLine("4. Edit Contact in Address Book");
                Console.WriteLine("5. Delete Contact from Address Book");
                Console.WriteLine("6. Add Multiple Persons to Address Book");
                Console.WriteLine("7. Add Multiple Address Books to the System");
                Console.WriteLine("8. Ensure No Duplicate Entries in Address Book");
                Console.WriteLine("9. Search Person in City or State");
                Console.WriteLine("10. View Persons by City");
                Console.WriteLine("11. View Persons by State");
                Console.WriteLine("12. Get count by City");
                Console.WriteLine("13. Get count by State");
                Console.WriteLine("14. Sort Address Book by Person's Name");
                Console.WriteLine("15. Exit");
                Console.WriteLine("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        addressBookMain.CreateAddressBook();
                        break;
                    case 2:
                        addressBookMain.AddContact();
                        break;
                    case 3:
                        addressBookMain.ViewAddressBook();
                        break;
                    case 4:
                        addressBookMain.EditContact();
                        break;
                    case 5:
                        addressBookMain.DeleteContact();
                        break;
                    case 6:
                        addressBookMain.AddMultipleAddressBooks();
                        break;
                    case 7: 
                        addressBookMain.AddMultiplePersons();
                        break;
                    case 8:
                        addressBookMain.EnsureNoDuplicateEntries();
                        break;
                    case 9:
                        addressBookMain.SearchPersonInCityOrState();
                        break;
                    case 10:
                        addressBookMain.ViewPersonsByCity();
                        break;
                    case 11:
                        addressBookMain.ViewPersonsByState();
                        break;
                    case 12:
                        addressBookMain.GetCountByCity();
                        break;
                    case 13:
                        addressBookMain.GetCountByState();
                        break;
                    case 14: 
                        addressBookMain.SortAddressBook();
                        break;
                    case 15:
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

            }
        }

    }
}