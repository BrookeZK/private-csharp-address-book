using System.Collections.Generic;
using System;

namespace AddressBookApp.Models
{
  public class AddressBook
  {
    public Dictionary<int, Contact> Contacts { get; } = new Dictionary<int, Contact>{};
    private int _currentId = 0;

    public int AssignId() 
    {
      _currentId += 1;
      return _currentId;
    }

    public void AddContact(Contact newContact) 
    {
      int id = AssignId();
      Contacts.Add(id, newContact);
    }

    public Contact FindContact(int id)
    {
      if (Contacts.ContainsKey(id))
      {
        return Contacts[id];
      }
      else
      {
        throw new NullReferenceException();
      }
    }

    public void DeleteContact(int id) 
    {
      if (Contacts.ContainsKey(id))
      {
        Contacts.Remove(id);
      }
      else
      {
        throw new NullReferenceException();
      }
    }
  }
}