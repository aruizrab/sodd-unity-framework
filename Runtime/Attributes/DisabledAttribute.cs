using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Disables the property or field, making it visible in the Unity Inspector but not editable.
    /// </summary>
    /// <remarks>
    ///     This attribute is useful for displaying properties or fields in the Inspector without
    ///     allowing changes at runtime. This can be particularly helpful for debugging or for
    ///     showing calculated values.
    /// </remarks>
    /// <example>
    ///     Here is how you can apply the DisabledAttribute to a property in your class:
    ///     <code>
    /// public class ExampleClass : MonoBehaviour
    /// {
    ///     [Disabled]
    ///     public float ReadOnlyValue;
    /// 
    ///     void Update()
    ///     {
    ///         ReadOnlyValue = CalculateSomeValue();
    ///     }
    /// 
    ///     private float CalculateSomeValue()
    ///     {
    ///         return Time.deltaTime * 100;
    ///     }
    /// }
    /// </code>
    ///     In this example, <c>ReadOnlyValue</c> is displayed in the Unity Inspector but cannot be
    ///     modified by users, ensuring that only calculated values are shown.
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisabledAttribute : PropertyAttribute
    {
    }
}