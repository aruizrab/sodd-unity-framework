using SODD.Events;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SODD.Input.ActionHandlers
{
    /// <summary>
    ///     Represents an ScriptableObject event that handles input actions and triggers scriptable events in response.
    /// </summary>
    /// <typeparam name="T">The data type of the input value, defined by the input action being handled.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class serves as the base for all input action handler implementations. It facilitates the
    ///         decoupling of input handling logic from GameObjects and components by providing ScriptableObjects that
    ///         translate the events provided by Unity's Input System into the event system based on scriptable events provided
    ///         by the SODD Framework.
    ///     </para>
    ///     <para>
    ///         This class listens to three phases of an input action—started, performed, and canceled—and invokes
    ///         the corresponding scriptable events.
    ///     </para>
    ///     <para>
    ///         To use <c>InputActionHandler&lt;T&gt;</c>, create a subclass specifying the appropriate type for
    ///         <typeparamref name="T" />
    ///         based on your input action's expected output. Then, assign input action references and connect event listeners
    ///         to handle specific input events.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Below is an example of how to create a concrete implementation of <c>InputActionHandler&lt;T&gt;</c> for handling
    ///     <see cref="Vector2" /> input actions, commonly used for 2D movement:
    ///     <code>
    ///         [CreateAssetMenu(menuName = "InputHandlers/Vector2InputActionHandler")]
    ///         public class Vector2InputActionHandler : InputActionHandler&lt;Vector2&gt;
    ///         {
    ///             // Override methods if needed for custom behavior upon input events.
    ///         }
    ///     </code>
    ///     In the Unity Editor, create an instance of this ScriptableObject and assign the input action reference along with
    ///     any event subscribers to handle the input action events.
    /// </example>
    /// <seealso cref="Event{T}" />
    public abstract class InputActionHandler<T> : ScriptableObject where T : struct
    {
        /// <summary>
        ///     Reference to the <see cref="InputAction" /> to be handled.
        /// </summary>
        [SerializeField] protected InputActionReference inputActionReference;

        /// <summary>
        ///     Event triggered when the input action starts.
        /// </summary>
        /// <typeparam name="T">The type of the action payload.</typeparam>
        [SerializeField] protected Event<T> onActionStarted;

        /// <summary>
        ///     Event triggered when the input action is performed.
        /// </summary>
        /// <typeparam name="T">The type of the action payload.</typeparam>
        [SerializeField] protected Event<T> onActionPerformed;

        /// <summary>
        ///     Event triggered when the input action is canceled.
        /// </summary>
        /// <typeparam name="T">The type of the action payload.</typeparam>
        [SerializeField] protected Event<T> onActionCanceled;

        private void OnEnable()
        {
            if (!inputActionReference) return;

            var action = inputActionReference.action;

            action.started += OnActionStarted;
            action.performed += OnActionPerformed;
            action.canceled += OnActionCanceled;
            action.Enable();
        }

        private void OnDisable()
        {
            if (!inputActionReference) return;

            var action = inputActionReference.action;

            action.started -= OnActionStarted;
            action.performed -= OnActionPerformed;
            action.canceled -= OnActionCanceled;
            action.Disable();
        }

        /// <summary>
        ///     Virtual method called when the input action starts.
        /// </summary>
        /// <param name="context">Context of the input action callback.</param>
        protected virtual void OnActionStarted(InputAction.CallbackContext context)
        {
            if (onActionStarted) onActionStarted.Invoke(context.ReadValue<T>());
        }

        /// <summary>
        ///     Virtual method called when the input action is performed.
        /// </summary>
        /// <param name="context">Context of the input action callback.</param>
        protected virtual void OnActionPerformed(InputAction.CallbackContext context)
        {
            if (onActionPerformed) onActionPerformed.Invoke(context.ReadValue<T>());
        }

        /// <summary>
        ///     Virtual method called when the input action is canceled.
        /// </summary>
        /// <param name="context">Context of the input action callback.</param>
        protected virtual void OnActionCanceled(InputAction.CallbackContext context)
        {
            if (onActionCanceled) onActionCanceled.Invoke(context.ReadValue<T>());
        }
    }
}