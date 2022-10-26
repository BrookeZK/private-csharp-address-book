using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookApp.Models;
using System.Collections.Generic;
using System;

namespace AddressBookApp.Tests
{
  [TestClass]
  public class AddressBookTests
  {
    [TestMethod]
    public void AddressBookConstructor_CreatesInstanceOfAddressBook_AddressBook()
    {
      AddressBook newAddressBook = new AddressBook();
      Assert.AreEqual(typeof(AddressBook), newAddressBook.GetType());
    }

    [TestMethod]
    public void GetContacts_ReturnsContacts_Dictionary()
    {
      Dictionary<int, Contact> testComparison = new Dictionary<int, Contact> {};
      AddressBook newAddressBook = new AddressBook();
      CollectionAssert.AreEqual(testComparison, newAddressBook.Contacts);
    }

    [TestMethod]
    public void AssignId_IncrementsCurrentIdAndReturnsValue_Int()
    {
      AddressBook newAddressBook = new AddressBook();
      Assert.AreEqual(1, newAddressBook.AssignId());
    }

    [TestMethod]
    public void AddContact_AddsContactToContactsDictionary_Void()
    {
      AddressBook newAddressBook = new AddressBook();
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      newAddressBook.AddContact(newContact);

      Assert.AreEqual(1, newAddressBook.Contacts.Count);
      Assert.AreEqual(newContact, newAddressBook.Contacts[1]);
    }

    [TestMethod]
    public void FindContact_FindsContactById_Contact()
    {
      AddressBook newAddressBook = new AddressBook();
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Contact newContact2 = new Contact("camelia", "juarez", "415-332-9841", "5 N Mountain");
      newAddressBook.AddContact(newContact);
      newAddressBook.AddContact(newContact2);
      Assert.AreEqual(newContact2, newAddressBook.FindContact(2));
    }

    [TestMethod]
    public void FindContact_FindsContactById_NullReferenceException()
    {
      AddressBook newAddressBook = new AddressBook();
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Contact newContact2 = new Contact("camelia", "juarez", "415-332-9841", "5 N Mountain");
      newAddressBook.AddContact(newContact);
      newAddressBook.AddContact(newContact2);
      Assert.ThrowsException<NullReferenceException>(() => newAddressBook.FindContact(3));
    }

    [TestMethod]
    public void DeleteContact_DeletesContactById_Void()
    {
      AddressBook newAddressBook = new AddressBook();
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Contact newContact2 = new Contact("camelia", "juarez", "415-332-9841", "5 N Mountain");
      newAddressBook.AddContact(newContact);
      newAddressBook.AddContact(newContact2);
      newAddressBook.DeleteContact(1);
      Assert.AreEqual(false, newAddressBook.Contacts.ContainsKey(1));
      Assert.AreEqual(true, newAddressBook.Contacts.ContainsKey(2));
    }

    [TestMethod]
    public void DeleteContact_DeletesContactById_NullReferenceException()
    {
      AddressBook newAddressBook = new AddressBook();
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      newAddressBook.AddContact(newContact);
      Assert.ThrowsException<NullReferenceException>(() => newAddressBook.DeleteContact(2));
    }
  }
}