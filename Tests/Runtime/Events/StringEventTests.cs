using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class StringEventTests
    {
        private string _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = "";
            _wasCalled = false;
        }

        private void Listener(string value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void StringEvent_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var stringEvent = ScriptableObject.CreateInstance<StringEvent>();
            var expectedValue = "string";

            stringEvent.AddListener(Listener);

            // Act
            stringEvent.Invoke(expectedValue);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(expectedValue, _receivedValue, "Listener did not receive the correct value.");

            // Cleanup
            Object.DestroyImmediate(stringEvent);
        }

        [Test]
        public void StringEvent_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var stringEvent = ScriptableObject.CreateInstance<StringEvent>();
            stringEvent.AddListener(Listener);

            // Act
            stringEvent.RemoveListener(Listener);
            stringEvent.Invoke("string");

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(stringEvent);
        }
    }
}