using System;
using System.Collections.Generic;
using ArKorespV1.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArKorespTexts
{
    /// <summary>
    /// tests arango-entity mini framework
    /// class drives simple tests
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateCollectionTest()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);
            Assert.IsTrue(testDBSet.DeleteCollection(""));
        }

        [TestMethod]
        public void InsertData()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

            TestEntity rec = new TestEntity
            {
                FieldOne = "Test text 1",
                FieldTwo = true,
                FieldThree = 19,
                FieldFour = DateTime.Now,
                FieldFive = 2019.2019,
                SDATA = DateTime.Now
            };

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);
            Assert.IsTrue(testDBSet.DeleteCollection(""));
        }

        [TestMethod]
        public void DeleteData()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

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

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);

            var recinserted1 = testDBSet.Insert(rec1);
            Assert.IsNotNull(recinserted1);
            Assert.IsNotNull(recinserted1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 2);

            Assert.IsTrue(testDBSet.Delete(rec._id) == rec._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);
            Assert.IsTrue(testDBSet.Delete(rec1._id) == rec1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 0);
            Assert.IsTrue(testDBSet.DeleteCollection(""));
        }

        [TestMethod]
        public void UpdateData()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

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

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);

            var recinserted1 = testDBSet.Insert(rec1);
            Assert.IsNotNull(recinserted1);
            Assert.IsNotNull(recinserted1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 2);

            recinserted.FieldThree = 2019;
            recinserted1.FieldThree = 2019;

            Assert.IsNotNull(testDBSet.Update(recinserted));
            Assert.IsNotNull(testDBSet.Update(recinserted1));

            
            Assert.IsTrue(testDBSet.GetCount(" item.FieldThree == 2019 ") == 2);
            Assert.IsTrue(testDBSet.DeleteCollection(""));

            
        }

        [TestMethod]
        public void GetDataTest()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

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

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);

            var recinserted1 = testDBSet.Insert(rec1);
            Assert.IsNotNull(recinserted1);
            Assert.IsNotNull(recinserted1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 2);

            Assert.IsTrue(testDBSet.Get(""));
            Assert.IsTrue(testDBSet.Count == 2);

            TestEntity rec2 = new TestEntity
            {
                FieldOne = "Test  3",
                FieldTwo = true,
                FieldThree = -1,
                FieldFour = DateTime.Now.AddYears(1),
                FieldFive = 5121,
                SDATA = DateTime.Now.AddDays(-19)
            };

            var recinserted2 = testDBSet.Insert(rec2);
            Assert.IsNotNull(recinserted2);
            Assert.IsNotNull(recinserted2._id);
            Assert.IsTrue(testDBSet.GetCount("") == 3);

            Assert.IsTrue(testDBSet.Get(""));
            Assert.IsTrue(testDBSet.GetCount("") == 3);

            testDBSet.Clear();
            Assert.IsTrue(testDBSet.Get(" Contains(item.FieldOne, 'text' ) "));
            Assert.IsTrue(testDBSet.Count == 2);


            Assert.IsTrue(testDBSet.DeleteCollection(""));


        }

        [TestMethod]
        public void ArangoViewTest()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

            ADBSet<TestEntity> testDBSet1 = new TestEntityDBSet("trial");
            Assert.IsTrue(testDBSet1.alreadycreated);

            Assert.IsTrue(testDBSet.InitializeView("TestEntityView"));

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

            TestEntity rec2 = new TestEntity
            {
                FieldOne = "Test  3",
                FieldTwo = true,
                FieldThree = -1,
                FieldFour = DateTime.Now.AddYears(1),
                FieldFive = 5121,
                SDATA = DateTime.Now.AddDays(-19)
            };

            Assert.IsTrue(testDBSet.ModifyView("TestEntityView", testDBSet.CollectionName()));
            Assert.IsTrue(testDBSet.ModifyView("TestEntityView", "trial" + testDBSet1.CollectionName()));

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);

            var recinserted1 = testDBSet.Insert(rec1);
            Assert.IsNotNull(recinserted1);
            Assert.IsNotNull(recinserted1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 2);

            var recinserted2 = testDBSet1.Insert(rec2);
            Assert.IsNotNull(recinserted2);
            Assert.IsNotNull(recinserted2._id);
            Assert.IsTrue(testDBSet1.GetCount("") == 1);


            testDBSet.Clear();
            //use of view requires some time after modyfications - you must stop for a while otherwise it would no run            
            System.Threading.Thread.Sleep(2000);
            Assert.IsTrue(testDBSet.Query("for item in TestEntityView return item"));
            Assert.IsTrue(testDBSet.Count == 3);

            Assert.IsTrue(testDBSet.DeleteView("TestEntityView"));
            Assert.IsTrue(testDBSet.DeleteCollection(""));
            Assert.IsTrue(testDBSet1.DeleteCollection("trial"));

        }

        [TestMethod]
        public void EdgeTest()
        {
            ADBSet<TestEntity> testDBSet = new ADBSet<TestEntity>();
            Assert.IsTrue(testDBSet.alreadycreated);

            ADBSet<TestEntity> testDBSet1 = new TestEntityDBSet("trial");
            Assert.IsTrue(testDBSet1.alreadycreated);

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

            TestEntity rec2 = new TestEntity
            {
                FieldOne = "Test  3",
                FieldTwo = true,
                FieldThree = -1,
                FieldFour = DateTime.Now.AddYears(1),
                FieldFive = 5121,
                SDATA = DateTime.Now.AddDays(-19)
            };

            var recinserted = testDBSet.Insert(rec);
            Assert.IsNotNull(recinserted);
            Assert.IsNotNull(recinserted._id);
            Assert.IsTrue(testDBSet.GetCount("") == 1);

            var recinserted1 = testDBSet.Insert(rec1);
            Assert.IsNotNull(recinserted1);
            Assert.IsNotNull(recinserted1._id);
            Assert.IsTrue(testDBSet.GetCount("") == 2);

            var recinserted2 = testDBSet1.Insert(rec2);
            Assert.IsNotNull(recinserted2);
            Assert.IsNotNull(recinserted2._id);
            Assert.IsTrue(testDBSet1.GetCount("") == 1);

            AEdgeDBSet<TestEdge> edgetest = new AEdgeDBSet<TestEdge>();

            edgetest.CreateEdge(recinserted._id, recinserted2._id, new Dictionary<string, object>());
            edgetest.CreateEdge(recinserted1._id, recinserted2._id, new Dictionary<string, object>());

            var others = edgetest.GetOtherSide<TestEntity>(recinserted._id, Arango.Client.ADirection.Out);
            Assert.IsNotNull(others);
            Assert.IsTrue(others.Count == 1);
            Assert.IsTrue(others[0]._id == recinserted2._id);

            var others1 = edgetest.GetOtherSide<TestEntity>(recinserted2._id, Arango.Client.ADirection.In);
            Assert.IsNotNull(others1);
            Assert.IsTrue(others1.Count == 2);
            Assert.IsTrue(others1[0]._id == recinserted._id || others1[0]._id == recinserted1._id);
            Assert.IsTrue(others1[1]._id == recinserted1._id || others1[1]._id == recinserted._id);

            var others2 = edgetest.GetOtherSide<TestEntity>(recinserted2._id, Arango.Client.ADirection.Any);
            Assert.IsNotNull(others2);
            Assert.IsTrue(others2.Count == 2);

            Assert.IsTrue(edgetest.DeleteCollection(""));
            Assert.IsTrue(testDBSet.DeleteCollection(""));
            Assert.IsTrue(testDBSet1.DeleteCollection("trial"));

        }

    }
}
