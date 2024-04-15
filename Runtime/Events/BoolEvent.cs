using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a boolean payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>bool</c> as the type parameter.
    ///         It is used to create events that need to communicate a boolean value, such as toggling a state, confirming a
    ///         condition, or triggering binary decisions.
    ///     </para>
    ///     <para>
    ///         Use cases might include signaling game state changes, user interactions that have two states (like on/off
    ///         switches), or as a response to certain player actions in a game.
    ///     </para>
    ///     <para>
    ///         This class can be instantiated as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to use a <see cref="BoolEvent" /> in a script to handle player actions like
    ///     crouching:
    ///     <code>
    /// public class BoolEventExample : MonoBehaviour
    /// {
    ///     public BoolEvent onCrouch; // Assign the event through the Unity Editor.
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onCrouch.AddListener(OnCrouch);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onCrouch.RemoveListener(OnCrouch);
    ///     }
    /// 
    ///     private void OnCrouch(bool isCrouching)
    ///     {
    ///         if (isCrouching)
    ///         {
    ///             // Set movement speed to crouching speed
    ///         }
    ///         else
    ///         {
    ///             // Set movement speed to normal speed
    ///         }
    ///     }
    /// }
    /// </code>
    ///     This example illustrates how the <c>onCrouch</c> event can be triggered by various game mechanisms such as player
    ///     input or specific gameplay triggers like a tutorial session. Importantly, the script is indifferent regarding who
    ///     triggers the event, focusing solely on responding to the event itself.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.Bool, fileName = nameof(BoolEvent), order = Framework.MenuOrders.Bool)]
    public sealed class BoolEvent : Event<bool>
    {
    }
}