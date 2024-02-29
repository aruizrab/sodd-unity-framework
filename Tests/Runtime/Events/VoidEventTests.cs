using NUnit.Framework;
using SODD.Core;
using SODD.Events;
using UnityEngine;

namespace SODD.Tests.Runtime.Events
{
    public class VoidEventTests
    {
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _wasCalled = false;
        }

        private void Listener(Void value)
        {
            _wasCalled = true;
        }

        [Test]
        public void VoidEvent_InvokesListener()
        {
            // Arrange
            var voidEvent = ScriptableObject.CreateInstance<VoidEvent>();

            voidEvent.AddListener(Listener);

            // Act
            voidEvent.Invoke();

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");

            // Cleanup
            Object.DestroyImmediate(voidEvent);
        }

        [Test]
        public void VoidEvent_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var voidEvent = ScriptableObject.CreateInstance<VoidEvent>();
            voidEvent.AddListener(Listener);

            // Act
            voidEvent.RemoveListener(Listener);
            voidEvent.Invoke();

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(voidEvent);
        }
    }
}