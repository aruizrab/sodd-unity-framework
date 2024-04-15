using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Calls the specified method when the associated field's value is changed in the Unity Editor.
    /// </summary>
    /// <remarks>
    ///     <para>
    ///         This attribute is designed to automatically invoke a method when a serialized field's value is updated. It is
    ///         primarily used within the SODD Framework to log changes
    ///         of scriptable variable values in the console when their debug option is enabled.
    ///     </para>
    ///     <para>
    ///         The method specified by the attribute should have no parameters and exist within the same class as the field it
    ///         is associated with.
    ///     </para>
    /// </remarks>
    /// <example>
    ///     <code>
    /// using UnityEngine;
    /// using SODD.Attributes;
    /// 
    /// public class Example : MonoBehaviour
    /// {
    ///     [OnValueChanged("OnHealthChanged")]
    ///     public int health;
    /// 
    ///     private void OnHealthChanged()
    ///     {
    ///         Debug.Log("Health value changed to: " + health);
    ///     }
    /// }
    /// </code>
    ///     This example demonstrates the attribute applied to a health field, where any change in the editor
    ///     will automatically call the OnHealthChanged method to handle related updates or logic.
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class OnValueChangedAttribute : PropertyAttribute
    {
        public readonly string MethodName;

        public OnValueChangedAttribute(string methodName)
        {
            MethodName = methodName;
        }
    }
}