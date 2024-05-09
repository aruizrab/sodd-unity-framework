using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Disables the property or field in the Unity Inspector if the value of the specified field or property
    ///     matches any of the given values.
    /// </summary>
    /// <remarks>
    ///     This attribute is useful for dynamically controlling the editability of properties and fields based on the state of
    ///     other properties or fields in the same object, particularly when multiple conditions could trigger a disable state.
    /// </remarks>
    /// <example>
    ///     The following example demonstrates how to use the DisableIfMatchAttribute to disable a property when
    ///     another property's value matches any specified value:
    ///     <code>
    /// public class ExampleBehaviour : MonoBehaviour
    /// {
    ///     public string state;
    /// 
    ///     [DisableIfMatch("state", "initial", "loading")]
    ///     public float progress;
    /// }
    /// </code>
    ///     In this example, the 'progress' float property becomes non-editable in the Inspector
    ///     if the 'state' string property is either "initial" or "loading".
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisableIfMatchAttribute : PropertyAttribute
    {
        public readonly string Name;
        public readonly object[] Values;

        public DisableIfMatchAttribute(string name, params object[] values)
        {
            Name = name;
            Values = values;
        }
    }
}