using SODD.Events;
using UnityEngine;

namespace SODD.Editor.Events
{
    public abstract class EventEditor<T> : UnityEditor.Editor
    {
        private Event<T> _event;

        private void OnEnable()
        {
            _event = target as Event<T>;
        }

        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            // ReSharper disable once Unity.PerformanceCriticalCodeInvocation
            if (GUILayout.Button("Invoke") && _event) _event.Invoke(_event.payload);
        }
    }
}