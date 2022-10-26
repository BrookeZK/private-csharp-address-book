using System;
using System.Collections.Generic;
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
    Console.WriteLine("~~~~~~~~~~~~~Main~Menu~~~~~~~~~~~~~~");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("What would you like to do?");
    Console.WriteLine("You can select from the following menu items:");

    Console.WriteLine("---------------------------");
    Console.WriteLine("1. See all contacts.");
    Console.WriteLine("2. Add a new contact.");
    Console.WriteLine("3. See a contact's details.");
    Console.WriteLine("4. Delete a contact.");
    Console.WriteLine("5. Exit program.");
    Console.WriteLine("---------------------------");
    Navigate();
  }

  static void Navigate()
  {
    Console.WriteLine("Please make your selection by entering '1', '2', '3', '4', or '5'.");
    string selection = Console.ReadLine();

    if (selection == "1")
    {
      SeeAllContacts();
    }
    else if (selection == "2")
    {
      AddContact();
    } 
    else if (selection == "3")
    {
      ContactDetails();
    } 
    else if (selection == "4")
    {
      DeleteContact();
    } 
    else if (selection == "5")
    {
      Goodbye();
    } 
    else
    {
      Console.WriteLine("Your response doesn't match any of our options. Please try again!");
      Navigate();
    }
  }

  static void Goodbye()
  {
    Console.WriteLine("Are you sure you want to exit? Please enter 'yes' or 'no':");
    string userInput = Console.ReadLine();
    if (userInput == "no")
    {
      Menu();
    }
  }

  static void SeeAllContacts()
  {
    Console.WriteLine("~~~~~~~~~~~~All~Contacts~~~~~~~~~~~~");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    if (addressBook.Contacts.Count == 0)
    {
      Console.WriteLine("There are no contacts yet!");
    }
    else
    {
      foreach (KeyValuePair<int, Contact> contact in addressBook.Contacts) 
      {
        Console.WriteLine($"ID {contact.Key} ------------");
        Console.WriteLine($"Name: {contact.Value.FullName()}");
        Console.WriteLine($"Phone Number: {contact.Value.PhoneNumber}");
        Console.WriteLine($"Address: {contact.Value.Address}");
        Console.WriteLine("-----------------");
      }
    }
    Menu();
  }

  static void AddContact()
  {
    Console.WriteLine("~~~~~~~~~~~Add~New~Contact~~~~~~~~~~");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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
    Console.WriteLine("--> SUCCESS!! The contact has been added.");
    Menu();
  }

  static int IdConfirmation()
  {
    int id = 0;
    Console.WriteLine("To view a contact's details or delete a contact, you need the contact's ID.");
    Console.WriteLine("Do you have the contact's ID?");
    Console.WriteLine("If not, you can find each contact's ID by reviewing the entire list of contacts."); Console.WriteLine("Please enter 'yes' if you have the contact's ID.");
    Console.WriteLine("Please enter 'no' to review the list of contact's to find a contact ID.");
    Console.WriteLine("To return to the main menu, hit any key.");
    string userInput = Console.ReadLine();
    if (userInput == "yes")
    {
      Console.WriteLine("Please enter the contact's id now: ");
      string stringId = Console.ReadLine();
      id = int.Parse(stringId);
    }
    else if (userInput == "no")
    {
      SeeAllContacts();
      IdConfirmation();
    }
    else 
    {
      Menu();
    }
    return id;
  }

  static void ContactDetails()
  {
    int id = IdConfirmation();
    try
    {
      Contact contact = addressBook.FindContact(id);
      Console.WriteLine("~~~~~~~~~~~Contact~Details~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      Console.WriteLine($"Name: {contact.FullName()}");
      Console.WriteLine($"Phone Number: {contact.PhoneNumber}");
      Console.WriteLine($"Address: {contact.Address}");
      Console.WriteLine("-----------------");
      Menu();
    }
    catch
    {
      IdError();
    }
  }

  static void DeleteContact()
  {
    int id = IdConfirmation();
    try
    {
      Console.WriteLine("~~~~~~~~~~~Delete~Contact~~~~~~~~~~~");
      Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
      addressBook.DeleteContact(id);
      Console.WriteLine("...");
      Console.WriteLine("...");
      Console.WriteLine("--> SUCCESS!! The contact has been deleted.");
      Menu();
    }
    catch
    {
      IdError();
    }
  }

  static void IdError()
  {
    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    Console.WriteLine("The id you entered did not match a contact in your address book.");
    Console.WriteLine("Please try again.");
    Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    Menu();
  }
}