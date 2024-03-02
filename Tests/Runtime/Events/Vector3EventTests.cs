using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class Vector3EventTests
    {
        private Vector3 _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = Vector3.zero;
            _wasCalled = false;
        }

        private void Listener(Vector3 value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void Vector3Event_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var vector3Event = ScriptableObject.CreateInstance<Vector3Event>();
            var expectedValue = new Vector3(3,5);

            vector3Event.AddListener(Listener);

            // Act
            vector3Event.Invoke(expectedValue);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(expectedValue, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(vector3Event);
        }

        [Test]
        public void Vector3Event_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var vector3Event = ScriptableObject.CreateInstance<Vector3Event>();
            vector3Event.AddListener(Listener);

            // Act
            vector3Event.RemoveListener(Listener);
            vector3Event.Invoke(Vector3.down);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(vector3Event);
        }
    }
}