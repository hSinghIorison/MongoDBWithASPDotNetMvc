using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Bson.Serialization;

namespace RealEstate.Test.Unit
{
    [TestClass]
    public class BsonDocumentTest
    {
        [TestInitialize]
        public void TestInit()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        [TestMethod]
        public void EmptyDocument()
        {
            var bsonDocument = new BsonDocument();
            Console.Write(bsonDocument.ToJson());
        }

        [TestMethod]
        public void AddElement()
        {
            var person = new BsonDocument
            {
                {"age", new BsonInt32(24)},
                { "firstName", new BsonString("bob")},
                {"IsAlive", true }
            };

            Console.Write(person);
        }

        [TestMethod]
        public void AddArray()
        {
            var person = new BsonDocument();
            person.Add("address", new BsonArray(new[] {"101 Some Road", "Unit 501"}));

            Console.Write(person);
        }

        [TestMethod]
        public void EmbeddedDocument()
        {
            var person = new BsonDocument();
            person.Add("contact", new BsonDocument
            {
                {"phone", "01252687235" },
                {"email", "none@some.com" }
            });

            Console.Write(person);
        }

        [TestMethod]
        public void ToBson()
        {
            var person = new BsonDocument
            {
                {"firstName", "Bob" }
            };

            var bsonBytes = person.ToBson();
            Console.WriteLine(BitConverter.ToString(bsonBytes));

            var bsonDocument = BsonSerializer.Deserialize<BsonDocument>(bsonBytes);
            Console.Write(bsonDocument);
        }
    }
}
