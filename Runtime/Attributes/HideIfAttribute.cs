using System;
using SODD.Core;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Hides the property or field in the Unity Inspector if the specified <see cref="Comparison"/> between the value of the named
    ///     field or property and a given value evaluates to true.
    /// </summary>
    /// <remarks>
    ///     Use this attribute to conditionally hide properties or fields from the Unity Inspector based on the state of other
    ///     properties or fields within the same object. This can be particularly useful for cleaning up the inspector by
    ///     hiding
    ///     irrelevant options based on the current configuration or state.
    /// </remarks>
    /// <example>
    ///     Here is how you can apply the HideIfAttribute:
    ///     <code>
    /// public class MyComponent : MonoBehaviour
    /// {
    ///     public bool showAdvancedOptions;
    ///     
    ///     [HideIf("showAdvancedOptions", false)]
    ///     public float advancedSetting;
    /// }
    /// </code>
    ///     In this example, 'advancedSetting' will be hidden in the Inspector if 'showAdvancedOptions' is false.
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class HideIfAttribute : PropertyAttribute
    {
        public readonly Comparison Comparison;
        public readonly string Name;
        public readonly object Value;

        public HideIfAttribute(string name, object value, Comparison comparison = Comparison.Equals)
        {
            Name = name;
            Value = value;
            Comparison = comparison;
        }
    }
}