using System;
using UnityEngine;

namespace SODD.Variables
{
    /// <summary>
    ///     Represents a reference holder for values of type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">The type of the data held by this reference.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This class provides a flexible mechanism to reference values either directly as serialized fields within a
    ///         MonoBehaviour
    ///         or ScriptableObject, or indirectly through a reference to a <see cref="Variable{T}" /> asset. This allows
    ///         developers to switch between inner instance-specific values and shared variable value without modifying the code that uses said values.
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
    public class ValueReference<T>
    {
        [SerializeField] private bool useField;
        [SerializeField] private T field;
        [SerializeField] private Variable<T> variable;

        /// <summary>
        ///     Gets or sets the value of the reference, choosing between a local field and an external variable based on
        ///     configuration.
        /// </summary>
        public T Value
        {
            get
            {
                if (!useField && variable) return variable.Value;
                return field;
            }
            set
            {
                if (!useField && variable) variable.Value = value;
                else field = value;
            }
        }
    }
}