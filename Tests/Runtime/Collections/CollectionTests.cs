using NUnit.Framework;
using SODD.Collections;
using UnityEngine;

namespace SODD.Tests.Runtime.Collections
{
    public class CollectionTests
    {
        private TestCollection _testCollection;

        [SetUp]
        public void SetUp()
        {
            _testCollection = ScriptableObject.CreateInstance<TestCollection>();
        }

        [TearDown]
        public void TearDown()
        {
            if (_testCollection != null)
                Object.DestroyImmediate(_testCollection);
        }

        [Test]
        public void Collection_AddItem_IncreasesCount()
        {
            _testCollection.Add(1);
            Assert.AreEqual(1, _testCollection.Count);
        }

        [Test]
        public void Collection_RemoveItem_DecreasesCount()
        {
            _testCollection.Add(1);
            _testCollection.Remove(1);
            Assert.AreEqual(0, _testCollection.Count);
        }

        [Test]
        public void Collection_Clear_EmptiesCollection()
        {
            _testCollection.Add(1);
            _testCollection.Add(2);
            _testCollection.Clear();
            Assert.AreEqual(0, _testCollection.Count);
        }

        [Test]
        public void Collection_Contains_ReturnsCorrectValue()
        {
            _testCollection.Add(1);
            Assert.IsTrue(_testCollection.Contains(1));
            Assert.IsFalse(_testCollection.Contains(2));
        }

        [Test]
        public void Collection_AddItem_TriggersOnItemAddedEvent()
        {
            var eventTriggered = false;
            var eventItem = 0;
            
            _testCollection.OnItemAdded.AddListener(item =>
            {
                eventTriggered = true;
                eventItem = item;
            });

            _testCollection.Add(1);

            Assert.IsTrue(eventTriggered);
            Assert.AreEqual(1, eventItem);
        }

        [Test]
        public void Collection_RemoveItem_TriggersOnItemRemovedEvent()
        {
            _testCollection.Add(1);

            var eventTriggered = false;
            var eventItem = 0;
            
            _testCollection.OnItemRemoved.AddListener(item =>
            {
                eventTriggered = true;
                eventItem = item;
            });

            _testCollection.Remove(1);

            Assert.IsTrue(eventTriggered);
            Assert.AreEqual(1, eventItem);
        }

        private class TestCollection : Collection<int>
        {
        }
    }
}