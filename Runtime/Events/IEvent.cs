using System;

namespace SODD.Events
{
    /// <summary>
    ///     Represents an event that can be listened to and invoked.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    public interface IEvent<T>
    {
        /// <summary>
        ///     Adds a listener to the event.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="listener">The listener to add.</param>
        void AddListener(Action<T> listener);

        /// <summary>
        ///     Removes the specified listener from the event.
        /// </summary>
        /// <typeparam name="T">The type of the listener's argument.</typeparam>
        /// <param name="listener">The listener to be removed.</param>
        void RemoveListener(Action<T> listener);

        /// <summary>
        ///     Invokes the event and notifies all registered listeners with the specified payload.
        /// </summary>
        /// <typeparam name="T">The type of the payload.</typeparam>
        /// <param name="payload">The payload to pass to the listeners.</param>
        void Invoke(T payload);
    }
}