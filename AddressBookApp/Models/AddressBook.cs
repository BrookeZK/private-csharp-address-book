using System.Collections.Generic;

namespace AddressBookApp.Models
{
  public class AddressBook
  {
    public string Name { get; set; }
    public Dictionary<int, Contact> Contacts { get; } = new Dictionary<int, Contact>{};
    private int _currentId = 0;

    public AddressBook(string name) {
      Name = name;
    }

    public void AddContact(Contact newContact) 
    {
      int id = AssignId();
      Contacts.Add(id, newContact);
    }

    public int AssignId() 
    {
      _currentId += 1;
      return _currentId;
    }

    public Contact? FindContact(int id)
    {
      if (Contacts[id] == null)
      {
        return null;
      }
      else 
      {
        return Contacts[id];
      }
    }

    public bool? DeleteContact(int id) 
    {
      if (Contacts[id] == null)
      {
        return null;
      }
      else 
      {
        Contacts.Remove(id);
        return true;
      }
    }
  }
}