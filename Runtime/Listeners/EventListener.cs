using SODD.Events;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents an abstract component that listens for events of a specific type <typeparamref name="T" />
    ///     and triggers UnityEvents in response.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class provides a foundation for creating scriptable event listeners. It implements the <see cref="IEventListener{T}" /> interface and inherits the <see cref="MonoBehaviour"/> class, simplifying the process of subscribing to and unsubscribing from events based on the
    ///         MonoBehaviour's lifecycle, ensuring that listeners are only active when the MonoBehaviour is enabled.
    ///     </para>
    ///     <para>
    ///         To create a custom event listener, inherit from this class and specify the payload type <typeparamref name="T" />, it can be any valid Unity type (e.g., int, string, GameObject, etc.). In the
    ///         Unity Editor, attach your new custom event listener component to a GameObject, assign the specific scriptable event to listen to and configure the response through the exposed
    ///         UnityEvent <see cref="onEventInvoked" />.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     A StringEvent Listener implementation would look like this:
    ///     <code>
    ///         public class StringEventListener : EventListener&lt;string&gt; {}
    ///     </code>
    /// </example>
    /// <seealso cref="IEventListener{T}" />
    /// <seealso cref="Event{T}" />
    /// <seealso cref="IEvent{T}" />
    public abstract class EventListener<T> : MonoBehaviour, IEventListener<T>
    {
        [SerializeField] protected Event<T> targetEvent;
        [SerializeField] protected UnityEvent<T> onEventInvoked;

        private void OnEnable()
        {
            StartListening(targetEvent);
        }

        private void OnDisable()
        {
            StopListening(targetEvent);
        }

        /// <summary>
        ///     Subscribes to the target event.
        /// </summary>
        /// <param name="event">The event to start listening to.</param>
        public void StartListening(IEvent<T> @event)
        {
            @event?.AddListener(OnEventInvoked);
        }

        /// <summary>
        ///     Unsubscribes from the target event.
        /// </summary>
        /// <param name="event">The event to stop listening to.</param>
        public void StopListening(IEvent<T> @event)
        {
            @event?.RemoveListener(OnEventInvoked);
        }

        /// <summary>
        ///     Called when the event is invoked, triggering the assigned UnityEvent.
        /// </summary>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        /// <param name="payload">The payload passed to the event.</param>
        public void OnEventInvoked(T payload)
        {
            onEventInvoked?.Invoke(payload);
        }
    }
}