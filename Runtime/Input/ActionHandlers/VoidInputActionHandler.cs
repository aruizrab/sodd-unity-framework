using SODD.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     A ScriptableObject that handles input actions that do not pass data.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <c>VoidInputActionHandler</c> is designed for input actions where the action itself is significant, but the
    ///         action's data is not.
    ///         This is common in scenarios such as button presses where the timing and occurrence of the action are important,
    ///         but the action does not
    ///         carry additional data (e.g., a jump or confirm button press).
    ///     </para>
    ///     <para>
    ///         This handler triggers events for the started, performed, and canceled phases of an input action, using a
    ///         <see cref="Void" /> type as payload to
    ///         signify the absence of specific data. This approach maintains consistency with the <c>InputActionHandler</c>
    ///         system while accommodating
    ///         actions that do not require data.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Void, fileName = nameof(VoidInputActionHandler),
        order = Framework.MenuOrders.Void)]
    public sealed class VoidInputActionHandler : InputActionHandler<Void>
    {
        /// <inheritdoc />
        protected override void OnActionStarted(InputAction.CallbackContext context)
        {
            if (onActionStarted) onActionStarted.Invoke(Void.Instance);
        }

        /// <inheritdoc />
        protected override void OnActionPerformed(InputAction.CallbackContext context)
        {
            if (onActionPerformed) onActionPerformed.Invoke(Void.Instance);
        }

        /// <inheritdoc />
        protected override void OnActionCanceled(InputAction.CallbackContext context)
        {
            if (onActionCanceled) onActionCanceled.Invoke(Void.Instance);
        }
    }
}