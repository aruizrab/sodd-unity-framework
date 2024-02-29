using System;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a generic event that can be listened to and invoked.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    public sealed class GenericEvent<T> : IEvent<T>
    {
        /// <summary>
        ///     Adds a listener to the event.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="listener">The listener to add.</param>
        /// <remarks>
        ///     This method adds a listener to the event. The listener will be triggered whenever the event is invoked.
        /// </remarks>
        public void AddListener(Action<T> listener)
        {
            Listeners += listener;
        }

        /// <summary>
        ///     Removes the specified listener from the event.
        /// </summary>
        /// <typeparam name="T">The type of the listener's argument.</typeparam>
        /// <param name="listener">The listener to be removed.</param>
        public void RemoveListener(Action<T> listener)
        {
            Listeners -= listener;
        }

        /// <summary>
        ///     Invokes the event and notifies all registered listeners with the specified payload.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="payload">The payload to pass to the listeners.</param>
        public void Invoke(T payload)
        {
            Listeners?.Invoke(payload);
        }

        /// <summary>
        ///     Represents a generic event that can be listened to and invoked.
        /// </summary>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        private event Action<T> Listeners;
    }
}