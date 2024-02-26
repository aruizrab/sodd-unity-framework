using SODD.Events;
using UnityEngine;

namespace SODD.Editor.Events
{
    /// <summary>
    ///     Base class for custom event editors.
    /// </summary>
    /// <typeparam name="T">The type of payload for the event.</typeparam>
    public abstract class EventEditor<T> : UnityEditor.Editor
    {
        private Event<T> _event;

        private void OnEnable()
        {
            _event = (Event<T>)target;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            if (GUILayout.Button("Invoke")) _event.Invoke(_event.payload);
        }
    }
}