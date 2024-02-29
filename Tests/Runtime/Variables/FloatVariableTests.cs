using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Tests.Runtime.Variables
{
    public class FloatVariableTests
    {
        private FloatVariable _floatVariable;
        private bool _eventTriggered;
        private float _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new FloatVariable for testing
            _floatVariable = ScriptableObject.CreateInstance<FloatVariable>();
            _eventTriggered = false;
            _lastEventValue = 0;

            // Subscribe to the OnValueChanged event
            _floatVariable.OnValueChanged.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_floatVariable);
        }

        [Test]
        public void FloatVariable_StoresAndUpdatesValueCorrectly()
        {
            // Act
            _floatVariable.Value = 10;

            // Assert
            Assert.AreEqual(10, _floatVariable.Value, "FloatVariable did not store the correct value.");
        }

        [Test]
        public void FloatVariable_TriggersOnValueChangedEvent()
        {
            // Act
            _floatVariable.Value = 5;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual(5, _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void FloatVariable_DoesNotTriggerEventForSameValue()
        {
            // Set an initial value
            _floatVariable.Value = 3;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = 0;

            // Act
            _floatVariable.Value = 3;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}