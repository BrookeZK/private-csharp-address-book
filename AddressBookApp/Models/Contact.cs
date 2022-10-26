using System.Collections.Generic;

namespace AddressBookApp.Models
{
  public class Contact
  {
    public string FirstName { get; }
    public string LastName { get; }
    public string PhoneNumber { get; }
    public string Address { get; }
    
    public Contact(string first, string last, string phoneNumber, string address) {
      FirstName = first;
      LastName = last;
      PhoneNumber = phoneNumber;
      Address = address;
    }

    public string FullName() 
    {
      return FirstName + " " + LastName;
    }
  }
}