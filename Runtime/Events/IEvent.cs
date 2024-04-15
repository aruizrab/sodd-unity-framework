using System;

namespace SODD.Events
{
    /// <summary>
    ///     Defines a generic interface for events that can have listeners added or removed, and be invoked with a payload of
    ///     type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">
    ///     The type of the event payload. This type parameter specifies the data type that listeners will
    ///     receive when the event is invoked.
    /// </typeparam>
    /// <remarks>
    ///     <para>
    ///         The <see cref="IEvent{T}" /> interface serves as the foundation of the loosely coupled event system based on
    ///         ScriptableObjects
    ///         provided by the SODD Framework, from which all scriptable events implement.
    ///     </para>
    ///     <para>
    ///         Listeners can subscribe to the event using <see cref="AddListener" /> and unsubscribe using
    ///         <see cref="RemoveListener" />. The event can be triggered using the <see cref="Invoke" />
    ///         method, which notifies all subscribed listeners, passing the specified payload to them.
    ///     </para>
    ///     <para>
    ///         Usage of this interface promotes a pattern where components can react to specific game events, enhancing
    ///         modularity and flexibility of the game's architecture.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example of defining a new event and subscribing a listener:
    ///     <code>
    ///     // Define a new event with a string payload
    ///     public class MyStringEvent : IEvent&lt;string&gt; {
    ///         private event Action&lt;string&gt; listeners;
    /// 
    ///         public void AddListener(Action&lt;string&gt; listener) => listeners += listener;
    /// 
    ///         public void RemoveListener(Action&lt;string&gt; listener) => listeners -= listener;
    /// 
    ///         public void Invoke(string payload) => listeners?.Invoke(payload);
    ///     }
    /// 
    ///     // Create an instance of the event
    ///     MyStringEvent myEvent = new MyStringEvent();
    /// 
    ///     // Define a listener method
    ///     void MyEventListener(string message) {
    ///         Debug.Log(message);
    ///     }
    /// 
    ///     // Subscribe the listener to the event
    ///     myEvent.AddListener(MyEventListener);
    /// 
    ///     // Invoke the event
    ///     myEvent.Invoke("Hello, World!");
    ///     </code>
    ///     This example will print "Hello, World!" to the console.
    /// </example>
    public interface IEvent<T>
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

        /// <summary>
        ///     Triggers the event, notifying all subscribed listeners and passing the specified payload to them.
        /// </summary>
        /// <param name="payload">
        ///     The payload to pass to the listeners.
        /// </param>
        /// <typeparam name="T">The type of the event payload.</typeparam>
        void Invoke(T payload);
    }
}