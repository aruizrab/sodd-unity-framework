using UnityEngine;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     Handles input actions that provide Vector3 data.
    /// </summary>
    /// <remarks>
    ///     This class extends <see cref="InputActionHandler{T}" /> to specifically handle input actions that output Vector3
    ///     data,
    ///     such as 3D spatial movements or directional inputs. It is ideal for applications requiring precise control over 3D
    ///     space,
    ///     such as camera controls, character movement, or object manipulation.
    ///     Subscribers can listen to the events raised by this handler to react to the start, performance, or cancellation of
    ///     the
    ///     input action with Vector3 data.
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Vector3, fileName = nameof(Vector3InputActionHandler),
        order = Framework.MenuOrders.Vector3)]
    public sealed class Vector3InputActionHandler : InputActionHandler<Vector3>
    {
    }
}