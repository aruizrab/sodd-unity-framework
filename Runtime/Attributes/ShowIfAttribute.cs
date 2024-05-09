using System;
using SODD.Core;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Shows the property or field in the Unity Inspector if the specified <see cref="Comparison" /> between the value of
    ///     the named
    ///     field or property and a given value evaluates to true. The property or field is hidden otherwise.
    /// </summary>
    /// <remarks>
    ///     This attribute enables dynamic control over the visibility of properties and fields in the Unity Inspector,
    ///     depending on the state of other properties or fields within the same object. It is particularly useful for
    ///     creating more intuitive and manageable interfaces by displaying only relevant options based on conditional logic.
    /// </remarks>
    /// <example>
    ///     Here is an example of how to use the ShowIfAttribute:
    ///     <code>
    /// public class MyComponent : MonoBehaviour
    /// {
    ///     public bool toggleFeature;
    /// 
    ///     [ShowIf("toggleFeature", true)]
    ///     public float featureSpecificSetting;
    /// }
    /// </code>
    ///     In this example, 'featureSpecificSetting' will be visible in the Inspector only if 'toggleFeature' is true.
    /// </example>
    /// s
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ShowIfAttribute : PropertyAttribute
    {
        public readonly Comparison Comparison;
        public readonly string Name;
        public readonly object Value;

        public ShowIfAttribute(string name, object value, Comparison comparison = Comparison.Equals)
        {
            Name = name;
            Value = value;
            Comparison = comparison;
        }
    }
}