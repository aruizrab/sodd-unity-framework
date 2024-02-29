using System;
using UnityEngine;
using SODD.Attributes;
using SODD.Events;
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
    ///     <example>
    ///         Example of an IntVariable implementation:
    ///         <code>
    ///         public class IntVariable : Variable&lt;int&gt; {}
    ///     </code>
    ///     </example>
    /// <seealso cref="IVariable{T}"/>
    /// </remarks>
    public abstract class Variable<T> : ScriptableObject, IVariable, IVariable<T>
    {
        [SerializeField] 
        [OnValueChanged("OnSerializedValueChanged")]
        protected T value;

        [SerializeField]
        [Tooltip("Enable this setting to prevent other scripts from modifying the value of this variable.")]
        protected bool readOnly;
#if UNITY_EDITOR
        [Tooltip("Enable this setting to log the changes in value of this variable in the console.")]
        [SerializeField] private bool debug;
#endif
        public readonly ValueChangedEvent<T> OnValueChanged = new();

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
                OnValueChanged?.Invoke(value, this);
            }
        }
#if UNITY_EDITOR
        protected void OnSerializedValueChanged()
        {
            OnValueChanged?.Invoke(value, this);
        }
#endif
        public class ValueChangedEvent<TV> : IEvent<TV>
        {
            public void AddListener(Action<TV> listener)
            {
                Listeners += listener;
            }

            public void RemoveListener(Action<TV> listener)
            {
                Listeners -= listener;
            }

            public void Invoke(TV payload)
            {
                Listeners?.Invoke(payload);
            }


            private event Action<TV> Listeners;

            public void Invoke(TV payload, Variable<TV> parent)
            {
                Invoke(payload);
#if UNITY_EDITOR
                if (!parent.debug) return;
                var assetPath = AssetDatabase.GetAssetPath(parent);
                var filename = Path.GetFileName(assetPath).Replace(".asset", "");
                var linkToVariable = $"<a href=\"{assetPath}\">{filename}</a>";
                var message = $"[{parent.GetType().FullName}] {linkToVariable} value changed. New value = {payload}";
                Debug.Log(message);
#endif
            }
        }
    }
}