using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Editor.Tests.Variables
{
    public class Vector3VariableTests
    {
        private Vector3Variable _vector3Variable;
        private bool _eventTriggered;
        private Vector3 _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new Vector3Variable instance for testing
            _vector3Variable = ScriptableObject.CreateInstance<Vector3Variable>();
            _eventTriggered = false;
            _lastEventValue = default(Vector3);

            // Subscribe to the OnValueChanged event
            _vector3Variable.OnValueChanged.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_vector3Variable);
        }

        [Test]
        public void Vector3Variable_StoresAndUpdatesValueCorrectly()
        {
            var testValue = new Vector3(1.0f, 2.0f, 3.0f);

            // Act
            _vector3Variable.Value = testValue;

            // Assert
            Assert.AreEqual(testValue, _vector3Variable.Value, "Vector3Variable did not store the correct value.");
        }

        [Test]
        public void Vector3Variable_TriggersOnValueChangedEvent()
        {
            var testValue = new Vector3(4.0f, 5.0f, 6.0f);

            // Act
            _vector3Variable.Value = testValue;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual(testValue, _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void Vector3Variable_DoesNotTriggerEventForSameValue()
        {
            var initialValue = new Vector3(7.0f, 8.0f, 9.0f);
            _vector3Variable.Value = initialValue;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = default(Vector3);

            // Act
            _vector3Variable.Value = initialValue;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}