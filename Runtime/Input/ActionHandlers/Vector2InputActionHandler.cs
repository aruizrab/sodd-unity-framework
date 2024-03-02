using UnityEngine;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     A ScriptableObject that handles input actions producing <see cref="Vector2" /> values.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <c>Vector2InputActionHandler</c> is optimized for input actions where the output is a two-dimensional
    ///         vector, such as directional inputs from a joystick or touchpad. Typical use cases include controlling character
    ///         movement, camera panning, or any scenario requiring directional input.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Vector2, fileName = nameof(Vector2InputActionHandler),
        order = Framework.MenuOrders.Vector2)]
    public sealed class Vector2InputActionHandler : InputActionHandler<Vector2>
    {
    }
}