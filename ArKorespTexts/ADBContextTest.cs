using System;
using Arango.Client;
using ArKorespV1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArKorespTexts
{
    [TestClass]
    public class ADBContextTest
    {
        [TestMethod]
        public void CreateAndDropCollection()
        {
            ADBContext db = new ADBContext("127.0.0.1",8529,"obieg","tomasz","tomasz");
            Assert.IsTrue(ASettings.HasConnection("obieg"));

            bool created;
            bool collectioncreate = db.InitializeCollection<TestEntity>(out created);
            Assert.IsTrue(collectioncreate);
            Assert.IsTrue(created);
            Assert.IsTrue(db.DeleteCollection<TestEntity>(""));

        }

        [TestMethod]
        public void InsertAndDeleteData()
        {
            ADBContext db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
            Assert.IsTrue(ASettings.HasConnection("obieg"));

            bool created;
            bool collectioncreate = db.InitializeCollection<TestEntity>(out created);
            Assert.IsTrue(collectioncreate);
            Assert.IsTrue(created);

            TestEntity rec = new TestEntity
            {
                FieldOne = "Test text 1",
                FieldTwo = true,
                FieldThree = 19,
                FieldFour = DateTime.Now,
                FieldFive = 2019.2019,
                SDATA = DateTime.Now
            };

            TestEntity rec1 = new TestEntity
            {
                FieldOne = "Test text 2",
                FieldTwo = false,
                FieldThree = 119,
                FieldFour = DateTime.Now,
                FieldFive = 2018.2018,
                SDATA = DateTime.Now.AddDays(-19)
            };

            string wynik = db.Insert<TestEntity>(rec);
            Assert.IsTrue(wynik != "");

            string wynik1 = db.Insert<TestEntity>(rec1);
            Assert.IsTrue(wynik1 != "");

            int rcount = db.GetCount<TestEntity>("");
            Assert.IsTrue(rcount == 2);

            string delres = db.Delete(wynik);
            Assert.IsTrue(delres.Equals(wynik));

            rcount = db.GetCount<TestEntity>("");
            Assert.IsTrue(rcount == 1);

            delres = db.Delete(wynik1);
            Assert.IsTrue(delres.Equals(wynik1));

            rcount = db.GetCount<TestEntity>("");
            Assert.IsTrue(rcount == 0);

            Assert.IsTrue(db.DeleteCollection<TestEntity>(""));

        }

        [TestMethod]
        public void UpdateDataTest()
        {
            ADBContext db = new ADBContext("127.0.0.1", 8529, "obieg", "tomasz", "tomasz");
            Assert.IsTrue(ASettings.HasConnection("obieg"));

            bool created;
            bool collectioncreate = db.InitializeCollection<TestEntity>(out created);
            Assert.IsTrue(collectioncreate);
            Assert.IsTrue(created);

            TestEntity rec = new TestEntity
            {
                FieldOne = "Test text 1",
                FieldTwo = true,
                FieldThree = 19,
                FieldFour = DateTime.Now,
                FieldFive = 2019.2019,
                SDATA = DateTime.Now
            };

            TestEntity rec1 = new TestEntity
            {
                FieldOne = "Test text 2",
                FieldTwo = false,
                FieldThree = 119,
                FieldFour = DateTime.Now,
                FieldFive = 2018.2018,
                SDATA = DateTime.Now.AddDays(-19)
            };

            string wynik = db.Insert<TestEntity>(rec);
            Assert.IsTrue(wynik != "");
            rec._id = wynik;
            
            string wynik1 = db.Insert<TestEntity>(rec1);
            Assert.IsTrue(wynik1 != "");
            rec1._id = wynik1;
            


            int rcount = db.GetCount<TestEntity>(" Contains(item.FieldOne,'text') ");
            Assert.IsTrue(rcount == 2);

            rec.FieldOne = "Changed field";

            var updated = db.Update<TestEntity>(rec);
            rcount = db.GetCount<TestEntity>(" Contains(item.FieldOne,'text') ");
            Assert.IsTrue(rcount == 1);


            Assert.IsTrue(db.DeleteCollection<TestEntity>(""));

        }

    }
}
