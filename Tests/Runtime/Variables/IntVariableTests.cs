using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Tests.Runtime.Variables
{
    public class IntVariableTests
    {
        private IntVariable _intVariable;
        private bool _eventTriggered;
        private int _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new IntVariable for testing
            _intVariable = ScriptableObject.CreateInstance<IntVariable>();
            _eventTriggered = false;
            _lastEventValue = 0;

            // Subscribe to the OnValueChanged event
            _intVariable.OnValueChanged.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_intVariable);
        }

        [Test]
        public void IntVariable_StoresAndUpdatesValueCorrectly()
        {
            // Act
            _intVariable.Value = 10;

            // Assert
            Assert.AreEqual(10, _intVariable.Value, "IntVariable did not store the correct value.");
        }

        [Test]
        public void IntVariable_TriggersOnValueChangedEvent()
        {
            // Act
            _intVariable.Value = 5;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual(5, _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void IntVariable_DoesNotTriggerEventForSameValue()
        {
            // Set an initial value
            _intVariable.Value = 3;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = 0;

            // Act
            _intVariable.Value = 3;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}