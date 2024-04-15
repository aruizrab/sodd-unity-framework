using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries an integer payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>int</c> as the type parameter.
    ///         It is commonly used to communicate numeric values, such as scores, health points, or other quantifiable game
    ///         mechanics.
    ///     </para>
    ///     <para>
    ///         Typical use cases include signaling changes in player scores, enemy health, or counting game items. This class
    ///         enables events to be triggered with integer data, facilitating interaction between different components of the
    ///         game
    ///         without tight coupling.
    ///     </para>
    ///     <para>
    ///         This class can be instantiated as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use an <see cref="IntEvent" /> to track changes in a game
    ///     score:
    ///     <code>
    /// public class ScoreManager : MonoBehaviour
    /// {
    ///     public IntEvent onUpdateScore; // Assign this through the Unity Editor.
    /// 
    ///     private int _score;
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onScoreChanged.AddListener(OnUpdateScore);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onScoreChanged.RemoveListener(OnUpdateScore);
    ///     }
    /// 
    ///     private void OnUpdateScore(int increment)
    ///     {
    ///         _score += increment;
    ///     }
    /// }
    /// </code>
    ///     This example shows a score manager that tracks and updates the player's score based on increments received through
    ///     an event.
    ///     Multiple components in the game, such as enemies when slain or coins when collected, can trigger this event to
    ///     notify
    ///     the need to increase the score without directly referencing the score manager.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.Int, fileName = nameof(IntEvent), order = Framework.MenuOrders.Int)]
    public sealed class IntEvent : Event<int>
    {
    }
}