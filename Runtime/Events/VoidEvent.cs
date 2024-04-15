using UnityEngine;
using Void = SODD.Core.Void;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries no payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>Void</c> as the type parameter.
    ///         It is ideal for situations where the occurrence of the event is important, but no data needs to be
    ///         communicated.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use a <see cref="VoidEvent" /> to trigger a level reset in a
    ///     game:
    ///     <code>
    /// public class LevelManager : MonoBehaviour
    /// {
    ///     public VoidEvent onLevelReset; // Assign this through the Unity Editor.
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onLevelReset.AddListener(ResetLevel);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onLevelReset.RemoveListener(ResetLevel);
    ///     }
    /// 
    ///     private void ResetLevel()
    ///     {
    ///         // Add logic here to reset the level
    ///     }
    /// }
    /// </code>
    ///     This example shows how the <c>onLevelReset</c> event can be used to initiate a level reset without needing to pass
    ///     any specific data. This ensures that the action to reset can be easily triggered from multiple parts of the game
    ///     without any dependencies on the event sender.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.Void, fileName = nameof(VoidEvent), order = Framework.MenuOrders.Void)]
    public sealed class VoidEvent : Event<Void>
    {
        public void Invoke()
        {
            Invoke(Void.Instance);
        }
    }
}