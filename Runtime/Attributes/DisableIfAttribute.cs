using System;
using SODD.Core;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    /// Disables the property or field in the Unity Inspector based on the result of a <see cref="Comparison"/> between the value of the named field or property and a specified value.
    /// </summary>
    /// <remarks>
    /// This attribute allows dynamic control over the editability of properties and fields in the Unity Inspector,
    /// enhancing the interactivity based on the current state of the object's properties or fields.
    /// </remarks>
    /// <example>
    /// The following example demonstrates the use of the DisableIfAttribute to disable a property based on the
    /// runtime value of another property:
    /// <code>
    /// public class ExampleBehavior : MonoBehaviour
    /// {
    ///     public bool toggle = true;
    ///
    ///     [DisableIf("toggle", false)]
    ///     public float disabledIfToggleIsFalse;
    /// }
    /// </code>
    /// In this example, the 'disabledIfToggleIsFalse' float property becomes non-editable in the Inspector
    /// if the 'toggle' boolean property is set to false.
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class DisableIfAttribute : PropertyAttribute
    {
        public readonly Comparison Comparison;
        public readonly string Name;
        public readonly object Value;

        public DisableIfAttribute(string name, object value, Comparison comparison = Comparison.Equals)
        {
            Name = name;
            Value = value;
            Comparison = comparison;
        }
    }
}