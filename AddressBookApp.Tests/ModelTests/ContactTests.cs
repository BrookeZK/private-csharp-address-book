using Microsoft.VisualStudio.TestTools.UnitTesting;
using AddressBookApp.Models;

namespace AddressBookApp.Tests
{
  [TestClass]
  public class ContactTests
  {
    [TestMethod]
    public void ContactConstructor_CreatesInstanceOfContact_Contact()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual(typeof(Contact), newContact.GetType());
    }

    [TestMethod]
    public void GetContactFirstName_ReturnsValue_String()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual("brandy", newContact.FirstName);
    }

    [TestMethod]
    public void GetContactLastName_ReturnsValue_String()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual("woo", newContact.LastName);
    }

    [TestMethod]
    public void GetContactPhoneNumber_ReturnsValue_String()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual("503-442-2333", newContact.PhoneNumber);
    }

    [TestMethod]
    public void GetContactAddress_ReturnsValue_String()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual("1224 SE Kwisp", newContact.Address);
    }

    [TestMethod]
    public void FullName_ReturnsContactFirstAndLastNames_String()
    {
      Contact newContact = new Contact("brandy", "woo", "503-442-2333", "1224 SE Kwisp");
      Assert.AreEqual("brandy woo", newContact.FullName());
    }
  }
}