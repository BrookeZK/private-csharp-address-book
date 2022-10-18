using System.Collections.Generic;

namespace AddressBookApp.Models
{
  public class Contact
  {
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public string Address { get; }
    private static List<Contact> _allContacts = new List<Contact>{};
    
    public Contact(string first, string last, string phoneNumber) {
      FirstName = first;
      LastName = last;
      PhoneNumber = phoneNumber;
      _allContacts.Add(this);
    }

    public string FullName() 
    {
      return FirstName + " " + LastName;
    }

    public static List<Contact> GetAll()
    {
      return _allContacts;
    }
  }
}