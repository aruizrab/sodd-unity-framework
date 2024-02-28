using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class FloatEventTests
    {
        private float _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = 0f;
            _wasCalled = false;
        }

        private void Listener(float value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void FloatEvent_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var floatEvent = ScriptableObject.CreateInstance<FloatEvent>();
            var expectedValue = 10.5f;

            floatEvent.AddListener(Listener);

            // Act
            floatEvent.Invoke(expectedValue);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(expectedValue, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(floatEvent);
        }

        [Test]
        public void FloatEvent_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var floatEvent = ScriptableObject.CreateInstance<FloatEvent>();
            floatEvent.AddListener(Listener);

            // Act
            floatEvent.RemoveListener(Listener);
            floatEvent.Invoke(10.5f);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(floatEvent);
        }
    }
}