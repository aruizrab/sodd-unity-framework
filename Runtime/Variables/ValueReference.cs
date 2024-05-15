using System;
using System.Collections.Generic;
using SODD.Attributes;
using SODD.Events;
using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     Represents a reference holder for values of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The type of the data held by this reference.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This class provides a flexible mechanism to reference values either directly as serialized fields, or
    ///         indirectly through a reference to a <see cref="Variable{T}" /> asset. This allows
    ///         developers to switch between inner instance-specific values and shared variable values without modifying the
    ///         code that uses said values.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example of using ValueReference to switch between a local and shared value:
    ///     <code>
    /// public class Player : MonoBehaviour
    /// {
    ///     public ValueReference&lt;int&gt; maxHealth;
    /// 
    ///     void Start()
    ///     {
    ///         Debug.Log("Max Health: " + maxHealth.Value);
    ///     }
    /// }
    /// </code>
    ///     In this example, the <c>maxHealth</c> can be configured in the Unity Editor to use either a local field value
    ///     or a reference to a shared Variable&lt;int&gt; asset. This allows for easy adjustments in gameplay mechanics
    ///     without
    ///     needing to touch the source code.
    /// </example>
    [Serializable]
    public class ValueReference<T> : IVariable<T>, IListenableEvent<T>
    {
        [SerializeField] private bool useField;

        [SerializeField] [OnValueChanged("HandleValueChange")]
        private T field;

        [SerializeField] private Variable<T> variable;

        private readonly IEvent<T> _onValueChanged = new GenericEvent<T>();

        /// <summary>
        ///     Registers an action to be called when the referenced value changes.
        /// </summary>
        /// <param name="listener">The action to invoke when the value changes.</param>
        public void AddListener(Action<T> listener)
        {
            if (useField) _onValueChanged?.AddListener(listener);
            else variable?.AddListener(listener);
        }

        /// <summary>
        ///     Unregisters an action previously added to listen for value changes.
        /// </summary>
        /// <param name="listener">The action to remove.</param>
        public void RemoveListener(Action<T> listener)
        {
            if (useField) _onValueChanged?.RemoveListener(listener);
            else variable?.RemoveListener(listener);
        }

        /// <summary>
        ///     Gets or sets the value of the reference, choosing between a local field and an external variable based on
        ///     configuration.
        /// </summary>
        public T Value
        {
            get => useField ? field : variable ? variable.Value : default;
            set
            {
                if (useField)
                {
                    if (EqualityComparer<T>.Default.Equals(field, value)) return;
                    field = value;
                    _onValueChanged?.Invoke(value);
                    return;
                }

                if (!variable) return;

                variable.Value = value;
            }
        }

        public string Id { get; }

        private void HandleValueChange()
        {
            _onValueChanged?.Invoke(field);
        }
    }
}