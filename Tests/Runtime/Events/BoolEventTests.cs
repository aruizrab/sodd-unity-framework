using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Editor.Tests.Events
{
    public class BoolEventTests
    {
        private bool _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = false;
            _wasCalled = false;
        }

        private void Listener(bool value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void BoolEvent_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var boolEvent = ScriptableObject.CreateInstance<BoolEvent>();

            boolEvent.AddListener(Listener);

            // Act
            boolEvent.Invoke(true);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(true, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(boolEvent);
        }

        [Test]
        public void BoolEvent_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var boolEvent = ScriptableObject.CreateInstance<BoolEvent>();
            boolEvent.AddListener(Listener);

            // Act
            boolEvent.RemoveListener(Listener);
            boolEvent.Invoke(true);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(boolEvent);
        }
    }
}