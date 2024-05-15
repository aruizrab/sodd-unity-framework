using System;
using System.Collections.Generic;
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
    ///     Represents an abstract variable of type <typeparamref name="T" />.
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
    ///         Additionally, the class implements the <see cref="IListenableEvent{T}" /> interface, which allows listeners to
    ///         be added and notified when the value of the variable changes.
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
    public abstract class Variable<T> : ScriptableObject, IVariable, IVariable<T>, IListenableEvent<T>
    {
        [SerializeField] [Disabled] [Tooltip("Variable's unique identifier.")]
        private string id;
        
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
        protected readonly IEvent<T> OnValueChanged = new GenericEvent<T>();

        /// <summary>
        ///     Gets the variable's unique identifier.
        /// </summary>
        public string Id => id;
        
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
                if (readOnly || EqualityComparer<T>.Default.Equals(this.value, value))
                {
                    return;
                }
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

        /// <summary>
        ///     Registers an action to be called when the variable's value changes.
        /// </summary>
        /// <param name="listener">The action to invoke when the value changes.</param>
        public void AddListener(Action<T> listener)
        {
            OnValueChanged.AddListener(listener);
        }

        /// <summary>
        ///     Unregisters an action previously added to listen for value changes.
        /// </summary>
        /// <param name="listener">The action to remove.</param>
        public void RemoveListener(Action<T> listener)
        {
            OnValueChanged.RemoveListener(listener);
        }
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (!string.IsNullOrEmpty(id)) return;
            id = GUID.Generate().ToString();
            EditorUtility.SetDirty(this);
        }
#endif
    }
}