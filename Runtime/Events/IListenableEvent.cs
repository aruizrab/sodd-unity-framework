using System;

namespace SODD.Events
{
    /// <summary>
    ///     Defines a generic interface for events with payloads of
    ///     type <typeparamref name="T" /> that can have listeners added or removed.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the event payload. This type parameter specifies the data type that listeners will
    ///     receive when the event is invoked.
    /// </typeparam>
    /// <remarks>
    ///     <para>
    ///         The <see cref="IListenableEvent{T}" /> interface serves as the foundation for scriptable events and scriptable
    ///         variables.
    ///     </para>
    ///     <para>
    ///         Listeners can subscribe to the event using <see cref="AddListener" /> and unsubscribe using
    ///         <see cref="RemoveListener" />. When the event is internally triggered, it notifies all subscribed listeners,
    ///         passing the specified payload to them.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Implementing <see cref="IListenableEvent{T}" /> for a custom event system:
    ///     <code>
    ///  public class HealthChangedEvent : IListenableEvent&lt;int&gt;
    ///  {
    ///      private event Action&lt;int&gt; _onHealthChanged;
    ///  
    ///      public void AddListener(Action&lt;int&gt; listener)
    ///      {
    ///          _onHealthChanged += listener;
    ///      }
    ///  
    ///      public void RemoveListener(Action&lt;int&gt; listener)
    ///      {
    ///          _onHealthChanged -= listener;
    ///      }
    ///  
    ///      private void Invoke(int newHealth)
    ///      {
    ///          _onHealthChanged?.Invoke(newHealth);
    ///      }
    ///  }
    ///  </code>
    ///     In this example, <c>HealthChangedEvent</c> uses an internal event delegate to manage subscribing and unsubscribing
    ///     of listeners,
    ///     and provides a private method <c>Invoke</c> to invoke all subscribed listeners with the current health value.
    /// </example>
    public interface IListenableEvent<out T>
    {
        /// <summary>
        ///     Subscribes a listener to the event, allowing it to be notified when the event is invoked.
        /// </summary>
        /// <param name="listener">
        ///     The listener to add. It is a method that matches the signature of the <see cref="Action{T}" />
        ///     delegate, accepting a single parameter of type <typeparamref name="T" />.
        /// </param>
        /// <typeparam name="T">The type of the listener's argument.</typeparam>
        void AddListener(Action<T> listener);

        /// <summary>
        ///     Unsubscribes a previously added listener from the event, preventing it from being notified when the event is
        ///     invoked.
        /// </summary>
        /// <param name="listener">
        ///     The listener to remove. It must be the same instance that was previously added with
        ///     <see cref="AddListener" />.
        /// </param>
        /// <typeparam name="T">The type of the listener's argument.</typeparam>
        void RemoveListener(Action<T> listener);
    }
}