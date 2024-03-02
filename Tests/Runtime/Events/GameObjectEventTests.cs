using NUnit.Framework;
using SODD.Events;
using UnityEngine;

namespace SODD.Editor.Tests.Events
{
    public class GameObjectEventTests
    {
        private GameObject _receivedValue;
        private bool _wasCalled;

        [SetUp]
        public void SetUp()
        {
            _receivedValue = null;
            _wasCalled = false;
        }

        private void Listener(GameObject value)
        {
            _receivedValue = value;
            _wasCalled = true;
        }

        [Test]
        public void GameObjectEvent_InvokesListenerWithCorrectValue()
        {
            // Arrange
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var testGameObject = new GameObject("TestGameObject");
            gameObjectEvent.AddListener(Listener);

            // Act
            gameObjectEvent.Invoke(testGameObject);

            // Assert
            Assert.IsTrue(_wasCalled, "Listener was not called.");
            Assert.AreEqual(testGameObject, _receivedValue, "Listener did not receive the correct GameObject.");

            // Cleanup
            Object.DestroyImmediate(testGameObject);
            Object.DestroyImmediate(gameObjectEvent);
        }

        [Test]
        public void GameObjectEvent_RemoveListener_StopsReceivingEvents()
        {
            // Arrange
            var gameObjectEvent = ScriptableObject.CreateInstance<GameObjectEvent>();
            var testGameObject = new GameObject("TestGameObject");
            gameObjectEvent.AddListener(Listener);

            // Act
            gameObjectEvent.RemoveListener(Listener);
            gameObjectEvent.Invoke(testGameObject);

            // Assert
            Assert.IsFalse(_wasCalled, "Listener was called after being removed.");

            // Cleanup
            Object.DestroyImmediate(testGameObject);
            Object.DestroyImmediate(gameObjectEvent);
        }
    }
}