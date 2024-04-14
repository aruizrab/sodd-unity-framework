using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a float payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>float</c> as the type parameter.
    ///         It is commonly used to handle numerical data that requires precision beyond integers, such as percentages, time
    ///         durations, distances, or health values.
    ///     </para>
    ///     <para>
    ///         Typical use cases include adjusting player speed, modifying game timers, changing health bars, or any
    ///         scenario where a change in a floating-point value needs to be communicated across different game components.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to define and use a <see cref="FloatEvent" /> to manage game completion
    ///     percentage:
    ///     <code>
    /// public class GamePercentageManager : MonoBehaviour
    /// {
    ///     public FloatEvent onCompletionIncreased; // Assign this through the Unity Editor.
    /// 
    ///     private float _completionPercentage = 0f;
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onCompletionIncreased.AddListener(OnCompletionIncreased);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onCompletionIncreased.RemoveListener(OnCompletionIncreased);
    ///     }
    /// 
    ///     private void OnCompletionIncreased(float percentage)
    ///     {
    ///         _completionPercentage += percentage;
    ///         Debug.Log("Completion percentage increased to: " + _completionPercentage + "%");
    ///     }
    /// }
    /// </code>
    ///     This example shows how <c>onCompletionIncreased</c> can be used to incrementally update the game's completion
    ///     percentage as players progress through levels or achieve specific milestones. The event system ensures that the
    ///     game logic related to tracking completion is decoupled from the actions that trigger progress.
    /// </example>
    public sealed class FloatEvent : Event<float>
    {
    }
}