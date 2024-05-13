using SODD.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace SODD.Observers
{
    /// <summary>
    ///     Represents an abstract component that observes changes in a <see cref="Variable{T}" /> of a specific type
    ///     <typeparamref name="T" />
    ///     and triggers UnityEvents in response.
    /// </summary>
    /// <typeparam name="T">The type of the variable being observed.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class provides a foundation for creating scriptable variable observers. It simplifies the process
    ///         of subscribing to and unsubscribing from variable
    ///         changes,
    ///         ensuring that observers are only active when the MonoBehaviour is enabled.
    ///     </para>
    ///     <para>
    ///         To create a custom variable observer, inherit from this class and specify the variable type
    ///         <typeparamref name="T" />,
    ///         which can be any valid Unity type (e.g., int, string, GameObject, etc.). In the Unity Editor, attach your new
    ///         custom
    ///         variable observer component to a GameObject, assign the specific scriptable variable to observe, and configure
    ///         the
    ///         response through the exposed UnityEvent <see cref="onValueChanged" />.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     An implementation example for an IntVariable observer might look like this:
    ///     <code>
    ///         public class IntVariableObserver : VariableObserver&lt;int&gt;
    ///         {
    ///         }
    /// </code>
    /// </example>
    /// <seealso cref="Variable{T}" />
    public abstract class VariableObserver<T> : MonoBehaviour
    {
        [SerializeField] private Variable<T> targetVariable;
        [SerializeField] private bool initialValueCheck = true;
        [SerializeField] private UnityEvent<T> onValueChanged;

        private void OnEnable()
        {
            if (initialValueCheck) OnVariableValueChanged(targetVariable.Value);
            targetVariable.AddListener(OnVariableValueChanged);
        }

        private void OnDisable()
        {
            targetVariable.RemoveListener(OnVariableValueChanged);
        }

        /// <summary>
        ///     Called when the variable's value changes.
        /// </summary>
        /// <param name="value">The new value of the variable.</param>
        protected virtual void OnVariableValueChanged(T value)
        {
            onValueChanged?.Invoke(value);
        }
    }
}