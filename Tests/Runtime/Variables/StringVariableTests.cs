using NUnit.Framework;
using UnityEngine;
using SODD.Variables;

namespace SODD.Tests.Runtime.Variables
{
    public class StringVariableTests
    {
        private StringVariable _stringVariable;
        private bool _eventTriggered;
        private string _lastEventValue;

        [SetUp]
        public void SetUp()
        {
            // Create a new StringVariable for testing
            _stringVariable = ScriptableObject.CreateInstance<StringVariable>();
            _eventTriggered = false;
            _lastEventValue = "";

            // Subscribe to the OnValueChanged event
            _stringVariable.OnValueChanged.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            // Cleanup
            Object.DestroyImmediate(_stringVariable);
        }

        [Test]
        public void StringVariable_StoresAndUpdatesValueCorrectly()
        {
            // Act
            _stringVariable.Value = "Test String";

            // Assert
            Assert.AreEqual("Test String", _stringVariable.Value, "StringVariable did not store the correct value.");
        }

        [Test]
        public void StringVariable_TriggersOnValueChangedEvent()
        {
            // Act
            _stringVariable.Value = "New Value";

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual("New Value", _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void StringVariable_DoesNotTriggerEventForSameValue()
        {
            // Set an initial value
            _stringVariable.Value = "Initial";

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = "";

            // Act
            _stringVariable.Value = "Initial";

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }
    }
}