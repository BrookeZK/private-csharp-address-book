using System;
using AddressBookApp.Models;

class Program
{
  public static AddressBook addressBook = new AddressBook();

  static void Main()
  {
    Console.WriteLine("####################################");
    Console.WriteLine("### Welcome to Address Book App! ###");
    Console.WriteLine("####################################");
    Menu();
  }

  static void Menu()
  {
    Console.WriteLine("~~~~~~~Main~Menu~~~~~~~");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("You can select from the following menu items:");

    Console.WriteLine("---------------------------");
    Console.WriteLine("1. Add a new contact.");
    Console.WriteLine("2. See all contacts.");
    Console.WriteLine("3. Exit program.");
    Console.WriteLine("---------------------------");

    Console.WriteLine("Please enter your selection by entering '1', '2', or '3'.");
    string selection = Console.ReadLine();

    if (selection == "1")
    {
      AddContact();
    }
    else if (selection == "2")
    {
      SeeAllContacts();
    } 
    else 
    {
      Goodbye();
    } 
  }

  static void Goodbye()
  {
    Console.WriteLine("Are you sure you want to exit? Please enter 'yes' or 'no'.");
    string response = Console.ReadLine();
    if (response == "no")
    {
      Menu();
    }
  }

  static void SeeAllContacts()
  {
    Console.WriteLine("~~~~~~~All~Contacts~~~~~~~");
    foreach (Contact contact in addressBook.Contacts) 
    {
      Console.WriteLine($"ID {contact.id} ------");
      Console.WriteLine($"Name: {contact.FullName()}");
      Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
      Console.WriteLine($"Address: {contact.Address}");
      Console.WriteLine("-----------------");
    }
    Console.WriteLine("What would you like to do next?");
    Console.WriteLine("1. Return to menu page.");
    Console.WriteLine("2. Manage a contact's details.");
    Console.WriteLine("3. Exit.");

    Console.WriteLine("Please enter your selection by entering '1', '2', or '3'.");
    string selection = Console.ReadLine();

    if (selection == "1")
    {
      Menu();
    }
    else if (selection == "2")
    {
      Console.WriteLine("To see or manage a contact's details, please enter in the ID. If necessary, review the list of contacts to locate the id of the contact that you wish to view.");
      string stringId = Console.ReadLine();
      int id = int.Parse(stringId);
      ContactDetails(id);
    } 
    else 
    {
      Goodbye();
    } 
  }

  static void AddContact()
  {
    Console.WriteLine("~~~~~~~Add~New~Contact~~~~~~~");
    Console.WriteLine("Please enter a first name:");
    string first = Console.ReadLine();
    Console.WriteLine("Please enter a last name:");
    string last = Console.ReadLine();
    Console.WriteLine("Please enter a phone number:");
    string phone = Console.ReadLine();
    Console.WriteLine("Please enter an address:");
    string address = Console.ReadLine();
    Contact newContact = new Contact(first, last, phone, address);
    addressBook.AddContact(newContact);
    Console.WriteLine("...");
    Console.WriteLine("...");
    Console.WriteLine("Success!!");
    Menu();
  }

  static void ContactDetails(int id)
  {
    Contact contact = addressBook.FindContact(id);
    if (contact == null)
    {
      Console.WriteLine("The id you entered did not match a contact in your address book.");
      Console.WriteLine("Please try again.");
      SeeAllContacts();
    }
    else 
    {
      Console.WriteLine("~~~~~~~Contact~Details~~~~~~~");
      Console.WriteLine($"Name: {contact.FullName()}");
      Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
      Console.WriteLine($"Address: {contact.Address}");
      Console.WriteLine("-----------------");
      Console.WriteLine("What would you like to do next?");
      Console.WriteLine("1. Delete contact.");
      Console.WriteLine("1. Return to menu page.");
      Console.WriteLine("3. Exit.");

      Console.WriteLine("Please enter your selection by entering '1', '2', or '3'.");
      string selection = Console.ReadLine();

      if (selection == "1")
      {
        addressBook.DeleteContact(contact);
        Console.WriteLine("...");
        Console.WriteLine("...");
        Console.WriteLine("Success!!");
        Menu();
      }
      else if (selection == "2")
      {
        Menu();
      } 
      else 
      {
        Goodbye();
      } 
    }
  }
}