using System.Collections.Generic;

namespace AddressBookApp.Models
{
  public class AddressBook
  {
    public List<Contact> Contacts { get; } = new List<Contact>{};
    private int _currentId = 0;

    public void AddContact(Contact newContact) 
    {
      newContact.id = AssignId();
      Contacts.Add(newContact);
    }

    public int AssignId() 
    {
      _currentId += 1;
      return _currentId;
    }

    #nullable enable
    public Contact? FindContact(int id)
    {
      return Contacts.Find(contact => contact.id == id);
    }
    #nullable disable

    public void DeleteContact(Contact contact) 
    {
      Contacts.Remove(contact);
    }
  }
}