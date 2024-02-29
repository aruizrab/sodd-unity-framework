using System;
using NUnit.Framework;
using SODD.Events;

namespace SODD.Tests.Editor.Events
{
    [TestFixture]
    public class GenericEventTests
    {
        [SetUp]
        public void SetUp()
        {
            _event = new GenericEvent<int>();
        }

        private GenericEvent<int> _event;

        [Test]
        public void AddListener_ShouldAddListener()
        {
            var called = 0;
            Action<int> listener = payload => { called++; };

            _event.AddListener(listener);
            _event.Invoke(10);

            Assert.AreEqual(1, called);
        }

        [Test]
        public void RemoveListener_ShouldRemoveListener()
        {
            var called = 0;
            Action<int> listener = payload => { called++; };

            _event.AddListener(listener);
            _event.Invoke(10);

            _event.RemoveListener(listener);
            _event.Invoke(10);

            Assert.AreEqual(1, called);
        }

        [Test]
        public void Invoke_ShouldTriggerAllListeners()
        {
            int called1 = 0, called2 = 0;
            Action<int> listener1 = payload => { called1 += payload; };
            Action<int> listener2 = payload => { called2 += payload; };

            _event.AddListener(listener1);
            _event.AddListener(listener2);
            _event.Invoke(10);

            Assert.AreEqual(10, called1);
            Assert.AreEqual(10, called2);
        }
    }
}