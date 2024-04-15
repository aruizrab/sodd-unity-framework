using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a string payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>string</c> as the type parameter.
    ///         It is particularly useful for handling textual data within the game, such as user input, notifications, or
    ///         dynamic text updates.
    ///     </para>
    ///     <para>
    ///         Typical use cases include sending messages between systems, updating UI text elements, or logging debug
    ///         information.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use a <see cref="StringEvent" /> for displaying messages in a
    ///     game's UI:
    ///     <code>
    /// public class UIManager : MonoBehaviour
    /// {
    ///     public StringEvent onDisplayMessage; // Assign this through the Unity Editor.
    ///     public UnityEngine.UI.Text messageText; // Assign this UI text element in the Unity Editor.
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onDisplayMessage.AddListener(DisplayMessage);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onDisplayMessage.RemoveListener(DisplayMessage);
    ///     }
    /// 
    ///     private void DisplayMessage(string message)
    ///     {
    ///         messageText.text = message;
    ///     }
    /// }
    /// </code>
    ///     This example shows how the <c>onDisplayMessage</c> event can be used to update a UI text element whenever a new
    ///     message needs to be displayed. This approach decouples the UI update logic from the rest of the game logic,
    ///     enhancing modularity and maintainability.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.String, fileName = nameof(StringEvent), order = Framework.MenuOrders.String)]
    public sealed class StringEvent : Event<string>
    {
    }
}