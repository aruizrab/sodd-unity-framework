using System;
using UnityEngine;

namespace SODD.Attributes
{
    /// <summary>
    ///     Makes a property collapsible in the Unity Inspector.
    /// </summary>
    /// <remarks>
    ///     This attribute can be applied to any serializable field to enable it to be
    ///     collapsed or expanded in the Inspector with an optional custom label.
    /// </remarks>
    /// <example>
    ///     <code>
    /// public class MyComponent : MonoBehaviour
    /// {
    ///     [Collapsible("Click to Expand/Collapse")]
    ///     public int myCollapsibleInt;
    /// }
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class CollapsibleAttribute : PropertyAttribute
    {
        public CollapsibleAttribute(string label = "")
        {
            Label = label;
        }

        public string Label { get; private set; }
    }
}