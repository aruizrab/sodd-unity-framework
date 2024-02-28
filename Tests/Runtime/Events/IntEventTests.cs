using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class IntEventTests
    {
        private IntEvent _intEvent;
        private int _lastReceivedValue;
        private bool _eventWasInvoked;

        [SetUp]
        public void SetUp()
        {
            // Create a new IntEvent instance for testing
            _intEvent = ScriptableObject.CreateInstance<IntEvent>();
            _eventWasInvoked = false;
            _lastReceivedValue = 0;
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup after each test
            Object.DestroyImmediate(_intEvent);
        }

        private void TestListener(int value)
        {
            _lastReceivedValue = value;
            _eventWasInvoked = true;
        }

        [Test]
        public void IntEvent_InvokesListenerWithCorrectValue()
        {
            // Arrange
            const int testValue = 10;
            _intEvent.AddListener(TestListener);

            // Act
            _intEvent.Invoke(testValue);

            // Assert
            Assert.IsTrue(_eventWasInvoked, "The event should have been invoked.");
            Assert.AreEqual(testValue, _lastReceivedValue, "The listener did not receive the correct value.");
        }

        [Test]
        public void IntEvent_ListenerCanBeRemoved()
        {
            // Arrange
            _intEvent.AddListener(TestListener);
            _intEvent.RemoveListener(TestListener);

            // Act
            _intEvent.Invoke(10);

            // Assert
            Assert.IsFalse(_eventWasInvoked, "The listener should not have been invoked after removal.");
        }
    }
}