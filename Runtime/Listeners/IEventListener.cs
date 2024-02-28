using SODD.Events;

namespace SODD.Listeners
{
    /// <summary>
    ///     Represents a listener for an event of type T.
    /// </summary>
    /// <typeparam name="T">The type of the event payload.</typeparam>
    public interface IEventListener<T>
    {
        /// <summary>
        ///     Starts listening to the specified event by adding the supplied event listener.
        /// </summary>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        /// <param name="event">The event to listen to.</param>
        /// <remarks>
        ///     This method adds the <see cref="OnEventInvoked" /> method as a listener to the specified event,
        ///     which will be invoked whenever the event is triggered.
        /// </remarks>
        void StartListening(IEvent<T> @event)
        {
            @event?.AddListener(OnEventInvoked);
        }

        /// <summary>
        ///     Stops listening to an event.
        /// </summary>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        /// <param name="event">The event to stop listening to.</param>
        void StopListening(IEvent<T> @event)
        {
            @event?.RemoveListener(OnEventInvoked);
        }

        /// <summary>
        ///     Defines a method that is called when an event is invoked.
        /// </summary>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        /// <param name="payload">The payload passed to the event.</param>
        void OnEventInvoked(T payload);
    }
}