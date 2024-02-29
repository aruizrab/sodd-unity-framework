using System;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#pragma warning disable CS0414 // Field is assigned.
#endif

namespace SODD.Events
{
    /// <summary>
    ///     Represents an abstract event that can be listened to and invoked.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class serves as the base for all scriptable event implementations. It implements
    ///         the <see cref="IEvent{T}" /> interface allowing listeners to subscribe to and unsubscribe from events
    ///         and provides a method to invoke the event with a specific payload.
    ///     </para>
    ///     <para>
    ///         To create custom scriptable events, inherit from this class and specify the
    ///         payload type <typeparamref name="T" />, it can be any valid Unity type (e.g., int, string, GameObject, etc.).
    ///         Then, in your derived classes, you can override the necessary methods (if needed) and add more properties
    ///         or methods that are specific to your requirements. However, the base
    ///         <see cref="Event{T}.AddListener">AddListener</see>,
    ///         <see cref="Event{T}.RemoveListener">RemoveListener</see> and <see cref="Event{T}.Invoke">Invoke</see>
    ///         methods, already implemented by this abstract class, should be enough to handle basic use cases.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     A StringEvent implementation would look like this:
    ///     <code>
    ///         public class StringEvent : Event&lt;string&gt; {}
    ///     </code>
    /// </example>
    /// <seealso cref="IEvent{T}" />
    public abstract class Event<T> : ScriptableObject, IEvent<T>
    {
#if UNITY_EDITOR
        [SerializeField] 
        [Tooltip("The payload value to be sent when this event is triggered from the inspector panel.")]
        public T payload;

        [SerializeField] 
        [Tooltip("Enable this setting to log the invocations of this event in the console.")]
        public bool debug;
#endif

        protected readonly GenericEvent<T> GenericEvent = new();
        
        /// <inheritdoc />
        public void AddListener(Action<T> listener)
        {
            GenericEvent.AddListener(listener);
        }

        /// <inheritdoc />
        public void RemoveListener(Action<T> listener)
        {
            GenericEvent.RemoveListener(listener);
        }

        /// <inheritdoc />
        public void Invoke(T payload)
        {
            GenericEvent.Invoke(payload);
#if UNITY_EDITOR
            if (!debug) return;
            var assetPath = AssetDatabase.GetAssetPath(this);
            var filename = Path.GetFileName(assetPath).Replace(".asset", "");
            var linkToEvent = $"<a href=\"{assetPath}\">{filename}</a>";
            var message = $"[{GetType().FullName}] {linkToEvent} invoked. Payload = {payload}";
            Debug.Log(message);
#endif
        }
    }
}