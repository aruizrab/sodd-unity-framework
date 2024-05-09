using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Hides the property or field in the Unity Inspector if the value of the specified field or property matches any
    ///     of the given values.
    /// </summary>
    /// <remarks>
    ///     This attribute can be used to conditionally hide properties or fields from the Unity Inspector based on the state
    ///     of other properties or fields within the same object. It is particularly useful for simplifying user interfaces by
    ///     hiding irrelevant options dependent on other configurations.
    /// </remarks>
    /// <example>
    ///     The following example shows how to use the HideIfMatchAttribute to hide a property when another property's value
    ///     matches any of the specified conditions:
    ///     <code>
    /// public class MyComponent : MonoBehaviour
    /// {
    ///     public string currentState;
    /// 
    ///     [HideIfMatch("currentState", "init", "start")]
    ///     public float sensitiveSetting;
    /// }
    /// </code>
    ///     In this example, the 'sensitiveSetting' float property will be hidden in the Inspector if the 'currentState'
    ///     string property is either "init" or "start".
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class HideIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public HideIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}