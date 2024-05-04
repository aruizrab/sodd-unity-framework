using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Tests.Runtime.Variables
{
    public class BoolVariableTests
    {
        private BoolVariable _boolVariable;
        private bool _eventTriggered;
        private bool _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new BoolVariable for testing
            _boolVariable = ScriptableObject.CreateInstance<BoolVariable>();
            _eventTriggered = false;
            _lastEventValue = false;

            // Subscribe to the OnValueChanged event
            _boolVariable.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_boolVariable);
        }

        [Test]
        public void BoolVariable_StoresAndUpdatesValueCorrectly()
        {
            // Act
            _boolVariable.Value = true;

            // Assert
            Assert.IsTrue(_boolVariable.Value, "BoolVariable did not store the correct value.");
        }

        [Test]
        public void BoolVariable_TriggersOnValueChangedEvent()
        {
            // Act
            _boolVariable.Value = true;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.IsTrue(_lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void BoolVariable_DoesNotTriggerEventForSameValue()
        {
            // Set an initial value
            _boolVariable.Value = false;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = false;

            // Act
            _boolVariable.Value = false;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}