using UnityEngine;

namespace SODD.Events
{
    /// <summary>
    ///     Represents a scriptable event that carries a Vector2 payload.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This class extends the generic <see cref="Event{T}" /> class, specifying <c>Vector2</c> as the type parameter.
    ///         It is particularly useful for scenarios involving 2D vectors, such as player movement, touch inputs, or any
    ///         other two-dimensional data transmission.
    ///     </para>
    ///     <para>
    ///         Typical use cases include capturing player directional inputs, tracking touch gestures, or sending
    ///         coordinates for game elements to react to.
    ///     </para>
    ///     <para>
    ///         This class can be created as a ScriptableObject asset directly from the Unity Editor.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example demonstrating how to use a <see cref="Vector2Event" /> for capturing and handling 2D
    ///     player input in a game:
    ///     <code>
    /// using UnityEngine;
    /// using SODD.Events;
    /// 
    /// public class PlayerController : MonoBehaviour
    /// {
    ///     public Vector2Event onPlayerMove; // Assign this through the Unity Editor.
    /// 
    ///     private Vector2 _direction;
    /// 
    ///     private void OnEnable()
    ///     {
    ///         onPlayerMove.AddListener(OnPlayerMove);
    ///     }
    /// 
    ///     private void OnDisable()
    ///     {
    ///         onPlayerMove.RemoveListener(OnPlayerMove);
    ///     }
    /// 
    ///     private void FixedUpdate()
    ///     {
    ///         // Move player based on _direction
    ///     }
    /// 
    ///     private void OnPlayerMove(Vector2 direction)
    ///     {
    ///         _direction = direction;
    ///     }
    /// }
    /// </code>
    ///     This example shows how the <c>onPlayerMove</c> event can be used to read and respond to 2D movement inputs from the
    ///     player. This method decouples input gathering from movement logic, allowing for more modular and easily
    ///     maintainable code.
    /// </example>
    [CreateAssetMenu(menuName = Framework.Events.Vector2, fileName = nameof(Vector2Event),
        order = Framework.MenuOrders.Vector2)]
    public sealed class Vector2Event : Event<Vector2>
    {
    }
}