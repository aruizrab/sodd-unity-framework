using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     A ScriptableObject that handles input actions passing boolean data.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         The <c>BoolInputActionHandler</c> is designed to process boolean input actions, providing a structured and
    ///         reusable way to react to button press or toggle events within Unity's Input System. This concrete
    ///         implementation of  <see cref="InputActionHandler{T}" /> offers specific overrides for the action started,
    ///         performed, and canceled
    ///         events, translating input action data to boolean values.
    ///     </para>
    /// </remarks>
    [CreateAssetMenu(menuName = Framework.Input.ActionHandlers.Bool, fileName = nameof(BoolInputActionHandler),
        order = Framework.MenuOrders.Bool)]
    public sealed class BoolInputActionHandler : InputActionHandler<bool>
    {
        /// <inheritdoc />
        protected override void OnActionStarted(InputAction.CallbackContext context)
        {
            var value = context.ReadValueAsButton();
            if (onActionStarted) onActionStarted.Invoke(value);
            if (targetVariable) targetVariable.Value = value;
        }

        /// <inheritdoc />
        protected override void OnActionPerformed(InputAction.CallbackContext context)
        {
            var value = context.ReadValueAsButton();
            if (onActionPerformed) onActionPerformed.Invoke(value);
            if (targetVariable) targetVariable.Value = value;
        }

        /// <inheritdoc />
        protected override void OnActionCanceled(InputAction.CallbackContext context)
        {
            var value = context.ReadValueAsButton();
            if (onActionCanceled) onActionCanceled.Invoke(value);
            if (targetVariable) targetVariable.Value = value;
        }
    }
}