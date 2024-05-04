using NUnit.Framework;
using SODD.Variables;
using UnityEngine;

namespace SODD.Tests.Runtime.Variables
{
    public class VariableTests
    {
        private bool _eventTriggered;
        private int _lastEventValue;
        private TestIntVariable _testVariable;

        [SetUp]
        public void SetUp()
        {
            // Initialize a new instance of TestIntVariable for each test
            _testVariable = ScriptableObject.CreateInstance<TestIntVariable>();
            _eventTriggered = false;
            _lastEventValue = 0;

            // Subscribe to the OnValueChanged event
            _testVariable.AddListener(value =>
            {
                _eventTriggered = true;
                _lastEventValue = value;
            });
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(_testVariable);
        }

        [Test]
        public void Variable_StoresAndUpdatesValueCorrectly()
        {
            // Act
            _testVariable.Value = 10;

            // Assert
            Assert.AreEqual(10, _testVariable.Value, "IntVariable did not store the correct value.");
        }

        [Test]
        public void Variable_TriggersOnValueChangedEvent()
        {
            // Act
            _testVariable.Value = 5;

            // Assert
            Assert.IsTrue(_eventTriggered, "OnValueChanged event was not triggered.");
            Assert.AreEqual(5, _lastEventValue, "OnValueChanged event did not pass the correct value.");
        }

        [Test]
        public void Variable_DoesNotTriggerEventForSameValue()
        {
            // Set an initial value
            _testVariable.Value = 3;

            // Reset the event tracking variables
            _eventTriggered = false;
            _lastEventValue = 0;

            // Act
            _testVariable.Value = 3;

            // Assert
            Assert.IsFalse(_eventTriggered, "OnValueChanged event was triggered for the same value.");
        }

        [Test]
        public void Variable_SetReadOnly_PreventsValueChange()
        {
            // Arrange
            _testVariable.ReadOnly = true;
            var originalValue = _testVariable.Value;
            const int newValue = 10;

            // Act
            _testVariable.Value = newValue;

            // Assert
            Assert.AreEqual(originalValue, _testVariable.Value,
                "The variable's value should not change when it is read-only.");
        }

        private class TestIntVariable : Variable<int>
        {
            public bool ReadOnly
            {
                set => readOnly = value;
            }
        }
    }
}