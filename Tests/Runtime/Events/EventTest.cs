using NUnit.Framework;
using SODD.Events;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SODD.Tests.Runtime.Events
{
    public class EventTest
    {
        private int _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = 0;
            _wasCalled = false;
        }

        private void Listener(int value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void Event_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var testEvent = ScriptableObject.CreateInstance<TestEvent>();
            const int expectedValue = 10;

            testEvent.AddListener(Listener);

            // Act
            testEvent.Invoke(expectedValue);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(expectedValue, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(testEvent);
        }

        [Test]
        public void Event_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var testEvent = ScriptableObject.CreateInstance<TestEvent>();
            testEvent.AddListener(Listener);

            // Act
            testEvent.RemoveListener(Listener);
            testEvent.Invoke(10);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(testEvent);
        }
        
        private class TestEvent : Event<int>
        {
        }
    }
}