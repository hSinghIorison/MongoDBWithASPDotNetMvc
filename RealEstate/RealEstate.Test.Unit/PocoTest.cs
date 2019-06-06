using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace RealEstate.Test.Unit
{
    [TestClass]
    public class PocoTest
    {
        [TestInitialize]
        public void TestInit()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        [TestMethod]
        public void Automatic()
        {
            var person = new Person
            {
                Age = 24,
                FirstName = "Bob",
            };
            person.Address.Add("101 some road");
            person.Address.Add("Unit 501");
            person.Contact.Email = "none@some.com";
            person.Contact.Phone = "01252687233";

            Console.Write(person.ToJson());
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public int Age { get; set; } 
        public List<string> Address = new List<string>();
        public Contact Contact = new Contact();
    }

    public class Contact
    {
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}