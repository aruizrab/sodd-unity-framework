using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Tests.Runtime.Variables
{
    public class Vector2VariableTests
    {
        private Vector2Variable _vector2Variable;
        private bool _eventTriggered;
        private Vector2 _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new Vector2Variable instance for testing
            _vector2Variable = ScriptableObject.CreateInstance<Vector2Variable>();
            _eventTriggered = false;
            _lastEventValue = default(Vector2);

            // Subscribe to the OnValueChanged event
            _vector2Variable.OnValueChanged.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_vector2Variable);
        }

        [Test]
        public void Vector2Variable_StoresAndUpdatesValueCorrectly()
        {
            var testValue = new Vector2(1.0f, 2.0f);

            // Act
            _vector2Variable.Value = testValue;

            // Assert
            Assert.AreEqual(testValue, _vector2Variable.Value, "Vector2Variable did not store the correct value.");
        }

        [Test]
        public void Vector2Variable_TriggersOnValueChangedEvent()
        {
            var testValue = new Vector2(3.0f, 4.0f);

            // Act
            _vector2Variable.Value = testValue;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual(testValue, _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void Vector2Variable_DoesNotTriggerEventForSameValue()
        {
            var initialValue = new Vector2(5.0f, 6.0f);
            _vector2Variable.Value = initialValue;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = default(Vector2);

            // Act
            _vector2Variable.Value = initialValue;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}