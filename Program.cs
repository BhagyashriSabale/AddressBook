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
                Console.WriteLine("7. View Persons by City");
                Console.WriteLine("8. View Persons by State");
                Console.WriteLine("9. Get Count by City");
                Console.WriteLine("10. Get Count by State");
                Console.WriteLine("11. Sort contact by name");
                Console.WriteLine("12. Sort entries in addressbook by City, State, and ZIP");
                Console.WriteLine("13. Exit");
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
                        addressBookSystem.ViewPersonsByCity();
                        break;
                    case 8:
                        addressBookSystem.ViewPersonsByState();
                        break;
                    case 9:
                        addressBookSystem.GetCountByCity();
                        break;
                   
                    case 10:
                        addressBookSystem.GetCountByState();
                        break;
                    
                    case 11:
                        addressBookSystem.SortAddressBookByName();
                        break;

                        
                    case 12:
                        Console.WriteLine("Sort Address Book Menu:");
                        Console.WriteLine("1. Sort by City");
                        Console.WriteLine("2. Sort by State");
                        Console.WriteLine("3. Sort by ZIP");
                        Console.WriteLine("Enter your choice: ");
                        int sortChoice = Convert.ToInt32(Console.ReadLine());

                        switch (sortChoice)
                        {
                            case 1:
                                addressBookSystem.SortAddressBookByCity();
                                break;
                            case 2:
                                addressBookSystem.SortAddressBookByState();
                                break;
                            case 3:
                                addressBookSystem.SortAddressBookByZip();
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Please try again.");
                                break;
                        }

                        break;

                    case 13:
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