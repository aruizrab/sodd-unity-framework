using System;
using UnityEngine;
using Logger = SODD.Core.Logger;
using Void = SODD.Core.Void;
#if UNITY_EDITOR
using UnityEditor;
using System.IO;
#pragma warning disable CS0414 // Field is assigned.
#endif

namespace SODD.Events
{
    /// <summary>
    ///     Provides a generic base class for scriptable event implementations, enabling events to be defined with specific
    ///     data types as payloads.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class serves as the base of the ScriptableObject-based event system provided by the SODD
    ///         Framework. It allows developers to create custom events that are reusable, and loosely coupled,
    ///         enhancing the modularity and flexibility of game architecture.
    ///     </para>
    ///     <para>
    ///         It implements the <see cref="IEvent{T}" /> interface, which includes methods to add or remove listeners, and
    ///         to invoke the event. This class can be extended to define events with any valid Unity type as a payload, such
    ///         as <c>int</c>, <c>string</c>, <c>GameObject</c>, etc.
    ///     </para>
    ///     <para>
    ///         The methods <see cref="AddListener(Action{T})" />, <see cref="RemoveListener(Action{T})" />, and
    ///         <see cref="Invoke(T)" /> provided by this class should suffice for basic event handling scenarios. Developers
    ///         can override these methods in derived classes to tailor event behavior to specific needs.
    ///     </para>
    ///     <para>
    ///         To create custom scriptable events, inherit from this class and specify the
    ///         payload type <typeparamref name="T" />.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Definition of a string event implementation:
    ///     <code>
    ///         [CreateAssetMenu(menuName = "My Events/String Event", fileName = nameof(StringEvent))]
    ///         public class StringEvent : Event&lt;string&gt; {}
    ///     </code>
    /// </example>
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
            Logger.LogAsset(this, "Invoked. " + (Void.Instance.Equals(payload) ? "" : $"Payload = {payload}"));
#endif
        }
    }
}