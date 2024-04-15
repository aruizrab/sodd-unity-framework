using UnityEngine;
using SODD.Attributes;
using SODD.Events;
using Logger = SODD.Core.Logger;
#if UNITY_EDITOR
using System.IO;
using UnityEditor;
#endif

namespace SODD.Variables
{
    /// <summary>
    ///     Represents an abstract variable of type T.
    /// </summary>
    /// <typeparam name="T">The type of the variable.</typeparam>
    /// <remarks>
    ///     <para>
    ///         This abstract class serves as the base for all scriptable variable implementations.
    ///         It implements the <see cref="IVariable{T}" /> interface allowing the creation of data containers that can be
    ///         easily manipulated within the Unity Editor and
    ///         referenced across different scripts, making it useful for a wide range
    ///         of applications, such as game settings, runtime configurations, or shared data across different
    ///         game components.
    ///     </para>
    ///     <para>
    ///         The value of the variable can be marked as read-only to prevent modification at runtime.
    ///         Additionally, the class provides an event, OnValueChanged, which is invoked whenever
    ///         the value of the variable is changed, allowing for reactive programming patterns.
    ///     </para>
    ///     <para>
    ///         To create custom scriptable variable, inherit from this class and specify the
    ///         payload type <typeparamref name="T" />, it can be any valid Unity type (e.g., int, string, GameObject, etc.).
    ///     </para>
    /// </remarks>
    /// <example>
    ///     Example of an IntVariable implementation:
    ///     <code>
    ///         [CreateAssetMenu(menuName = "My Variables/Int Variable", fileName = nameof(StringVariable))]
    ///         public class IntVariable : Variable&lt;int&gt; {}
    ///     </code>
    /// </example>
    public abstract class Variable<T> : ScriptableObject, IVariable, IVariable<T>
    {
        [SerializeField] 
        [OnValueChanged("HandleValueChange")]
        protected T value;

        [SerializeField]
        [Tooltip("Enable this setting to prevent other scripts from modifying the value of this variable.")]
        protected bool readOnly;
#if UNITY_EDITOR
        [Tooltip("Enable this setting to log the changes in value of this variable in the console.")]
        [SerializeField] private bool debug;
#endif
        
        /// <summary>
        /// An event that is triggered whenever the value of the variable changes.
        /// </summary>
        public readonly GenericEvent<T> OnValueChanged = new();

        object IVariable.Value
        {
            get => Value;
            set => Value = (T)value;
        }

        /// <summary>
        ///     Gets or sets the value of the variable.
        /// </summary>
        /// <value>The current value of the variable.</value>
        public T Value
        {
            get => value;
            set
            {
                if (readOnly) return;
                if (this.value != null && this.value.Equals(value)) return;
                this.value = value;
                HandleValueChange();
            }
        }
        
        /// <summary>
        /// Invokes the OnValueChanged event and can log the change if debugging is enabled.
        /// </summary>
        protected void HandleValueChange()
        {
            OnValueChanged?.Invoke(value);
#if UNITY_EDITOR
            if (!debug) return;
            Logger.LogAsset(this, $"Value changed. New value = {value}");
#endif
        }
    }
}