using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class Vector2EventTests
    {
        private Vector2 _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = Vector2.zero;
            _wasCalled = false;
        }

        private void Listener(Vector2 value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void Vector2Event_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var vector2Event = ScriptableObject.CreateInstance<Vector2Event>();
            var expectedValue = new Vector2(3,5);

            vector2Event.AddListener(Listener);

            // Act
            vector2Event.Invoke(expectedValue);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(expectedValue, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(vector2Event);
        }

        [Test]
        public void Vector2Event_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var vector2Event = ScriptableObject.CreateInstance<Vector2Event>();
            vector2Event.AddListener(Listener);

            // Act
            vector2Event.RemoveListener(Listener);
            vector2Event.Invoke(Vector2.down);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(vector2Event);
        }
    }
}